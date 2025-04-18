using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using CodeGen.Helpers.ExpressionAnalyzer.Functions;
using CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;
using CodeGen.Helpers.ExpressionAnalyzer.Functions.Math.Trigonometry;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer;

internal class ExpressionEvaluator // TODO make public (and move out in a separate project)
{
    public static readonly Fraction Pi = FractionExtensions.FromDoubleRounded(Math.PI, 16);
    private readonly IReadOnlyDictionary<string, Fraction> _constantValues;
    private readonly Dictionary<string, CompositeExpression> _expressionsEvaluated = [];

    private readonly IReadOnlyDictionary<string, IFunctionEvaluator> _functionEvaluators;

    public ExpressionEvaluator(string parameterName, params IFunctionEvaluator[] functionEvaluators)
        : this(parameterName, functionEvaluators.ToDictionary(x => x.FunctionName), new Dictionary<string, Fraction>())
    {
    }

    public ExpressionEvaluator(string parameterName, IReadOnlyDictionary<string, Fraction> constantValues, params IFunctionEvaluator[] functionEvaluators)
        : this(parameterName, functionEvaluators.ToDictionary(x => x.FunctionName), constantValues)
    {
    }

    public ExpressionEvaluator(string parameterName, IReadOnlyDictionary<string, IFunctionEvaluator> functionEvaluators,
        IReadOnlyDictionary<string, Fraction> constantValues)
    {
        ParameterName = parameterName;
        _constantValues = constantValues;
        _functionEvaluators = functionEvaluators;
    }

    public string ParameterName { get; }

    protected string Add(CompositeExpression expression)
    {
        var label = "{" + (char)('a' + _expressionsEvaluated.Count) + "}";
        _expressionsEvaluated[label] = expression;
        return label;
    }

    public CompositeExpression Evaluate(ExpressionEvaluationTerm expressionEvaluationTerm) // TODO either replace by string or add a coefficient
    {
        if (TryParseExpressionTerm(expressionEvaluationTerm.Expression, expressionEvaluationTerm.Exponent, out ExpressionTerm? expressionTerm))
        {
            return expressionTerm;
        }

        var expressionToParse = expressionEvaluationTerm.Expression;
        Fraction exponent = expressionEvaluationTerm.Exponent;
        string previousExpression;
        do
        {
            previousExpression = expressionToParse;
            // the regex captures the innermost occurrence of a function group: "Sin(x)", "Pow(x, y)", "(x + 1)" are all valid matches
            expressionToParse = Regex.Replace(expressionToParse, @"(\w*)\(([^()]*)\)", match =>
            {
                var functionName = match.Groups[1].Value;
                var functionBodyToParse = match.Groups[2].Value;
                var evaluationTerm = new ExpressionEvaluationTerm(functionBodyToParse, exponent);
                if (string.IsNullOrEmpty(functionName)) // standard grouping (technically this is equivalent to f(x) -> x)
                {
                    // all terms within the group are expanded: extract the simplified expression
                    CompositeExpression expression = ReplaceTokenizedExpressions(evaluationTerm);
                    return Add(expression);
                }

                if (_functionEvaluators.TryGetValue(functionName, out IFunctionEvaluator? functionEvaluator))
                {
                    // resolve the expression using the custom function evaluator
                    CompositeExpression expression = functionEvaluator.CreateExpression(evaluationTerm, ReplaceTokenizedExpressions);
                    return Add(expression);
                }

                throw new FormatException($"No function evaluator available for {functionName}({functionBodyToParse})");
            });
        } while (previousExpression != expressionToParse);

        return ReplaceTokenizedExpressions(expressionEvaluationTerm with { Expression = expressionToParse });
    }

    private CompositeExpression ReplaceTokenizedExpressions(ExpressionEvaluationTerm tokenizedExpression)
    {
        // all groups and function are expanded: we're left with a standard arithmetic expression such as "4 * a + 2 * b * x - c - d + 5"
        // with a, b, c, d representing the previously evaluated expressions
        var result = new CompositeExpression();
        var stringBuilder = new StringBuilder();
        ArithmeticOperationToken lastToken = ArithmeticOperationToken.Addition;
        CompositeExpression? runningExpression = null;
        foreach (var character in tokenizedExpression.Expression)
        {
            if (!TryReadToken(character, out ArithmeticOperationToken currentToken)) // TODO use None?
            {
                continue;
            }

            switch (currentToken)
            {
                case ArithmeticOperationToken.Addition or ArithmeticOperationToken.Subtraction:
                {
                    if (stringBuilder.Length == 0) // ignore the leading sign
                    {
                        lastToken = currentToken;
                        continue;
                    }

                    // we're at the end of a term expression
                    CompositeExpression lastTerm = ParseTerm();
                    if (runningExpression is null)
                    {
                        result.AddTerms(lastTerm);
                    }
                    else // the last term is part of a running multiplication
                    {
                        result.AddTerms(runningExpression * lastTerm);
                        runningExpression = null;
                    }

                    lastToken = currentToken;
                    break;
                }
                case ArithmeticOperationToken.Multiplication or ArithmeticOperationToken.Division:
                {
                    CompositeExpression previousTerm = ParseTerm();
                    if (runningExpression is null)
                    {
                        runningExpression = previousTerm;
                    }
                    else // the previousTerm term is part of a running multiplication (which is going to be followed by at least one more multiplication/division)
                    {
                        runningExpression *= previousTerm;
                    }

                    lastToken = currentToken;
                    break;
                }
            }
        }

        CompositeExpression finalTerm = ParseTerm();
        if (runningExpression is null)
        {
            result.AddTerms(finalTerm);
        }
        else
        {
            result.AddTerms(runningExpression * finalTerm);
        }

        return result;

        bool TryReadToken(char character, out ArithmeticOperationToken token)
        {
            switch (character)
            {
                case '+':
                    token = ArithmeticOperationToken.Addition;
                    return true;
                case '-':
                    token = ArithmeticOperationToken.Subtraction;
                    return true;
                case '*':
                    token = ArithmeticOperationToken.Multiplication;
                    return true;
                case '/':
                    token = ArithmeticOperationToken.Division;
                    return true;
                case not ' ':
                    stringBuilder.Append(character);
                    break;
            }

            token = default;
            return false;
        }

        CompositeExpression ParseTerm()
        {
            var previousExpression = stringBuilder.ToString();
            stringBuilder.Clear();
            if (_expressionsEvaluated.TryGetValue(previousExpression, out CompositeExpression? expression))
            {
                return lastToken switch
                {
                    ArithmeticOperationToken.Subtraction => expression.Negate(),
                    ArithmeticOperationToken.Division => expression.Invert(),
                    _ => expression
                };
            }

            if (TryParseExpressionTerm(previousExpression, tokenizedExpression.Exponent, out ExpressionTerm? expressionTerm))
            {
                return lastToken switch
                {
                    ArithmeticOperationToken.Subtraction => expressionTerm.Negate(),
                    ArithmeticOperationToken.Division => expressionTerm.Invert(),
                    _ => expressionTerm
                };
            }

            throw new FormatException($"Failed to parse the previous token: {previousExpression}");
        }
    }


    private bool TryParseExpressionTerm(string expressionToParse, Fraction exponent, [MaybeNullWhen(false)] out ExpressionTerm expressionTerm)
    {
        if (expressionToParse == ParameterName)
        {
            expressionTerm = new ExpressionTerm(Fraction.One, exponent);
            return true;
        }

        if (_constantValues.TryGetValue(expressionToParse, out Fraction constantExpression) || Fraction.TryParse(expressionToParse, out constantExpression))
        {
            if (exponent.Numerator == exponent.Denominator)
            {
                expressionTerm = ExpressionTerm.Constant(constantExpression);
                return true;
            }

            if (exponent.Denominator.IsOne)
            {
                expressionTerm = ExpressionTerm.Constant(Fraction.Pow(constantExpression, (int)exponent.Numerator));
                return true;
            }

            // constant expression using a non-integer power: there is currently no Fraction.Pow(Fraction, Fraction)
            expressionTerm = ExpressionTerm.Constant(FractionExtensions.FromDoubleRounded(Math.Pow(constantExpression.ToDouble(), exponent.ToDouble())));
            return true;
        }

        expressionTerm = null;
        return false;
    }

    public static string ReplaceDecimalNotations(string expression, Dictionary<string, Fraction> constantValues)
    {
        return Regex.Replace(expression, @"\d*(\.\d*)?[eE][-\+]?\d*[dD]?", match =>
        {
            var tokens = match.Value.ToLower().Replace("d", "").Split('e');
            if (tokens.Length != 2 || !Fraction.TryParse(tokens[0], out Fraction mantissa) || !int.TryParse(tokens[1], out var exponent))
            {
                throw new FormatException($"The expression contains invalid tokens: {expression}");
            }

            var label = $"{{v{constantValues.Count}}}";
            constantValues[label] = mantissa * Fraction.Pow(10, exponent);
            return label;
        }).Replace("d", string.Empty); // TODO these are force-generated for the BitRate (we should stop doing it)
    }

    public static string ReplaceMathPi(string expression, Dictionary<string, Fraction> constantValues)
    {
        return Regex.Replace(expression, @"Math\.PI", _ =>
        {
            constantValues[nameof(Pi)] = Pi;
            return nameof(Pi);
        });
    }

    public static CompositeExpression Evaluate(string expression, string parameter)
    {
        var constantExpressions = new Dictionary<string, Fraction>();

        expression = ReplaceDecimalNotations(expression, constantExpressions); // TODO expose an IPreprocessor (or something)
        expression = ReplaceMathPi(expression, constantExpressions);
        expression = expression.Replace("Math.", string.Empty);

        // these are no longer necessary
        // var expressionEvaluator = new ExpressionEvaluator(parameter, constantExpressions,
        //     new SqrtFunctionEvaluator(),
        //     new PowFunctionEvaluator(),
        //     new SinFunctionEvaluator(),
        //     new AsinFunctionEvaluator());
        var expressionEvaluator = new ExpressionEvaluator(parameter, constantExpressions);

        return expressionEvaluator.Evaluate(new ExpressionEvaluationTerm(expression, Fraction.One));
    }

    private enum ArithmeticOperationToken
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
