using System;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal class PowFunctionEvaluator : IFunctionEvaluator
{
    public string FunctionName => nameof(System.Math.Pow);

    public ExpressionEvaluationTerm GetFunctionBody(string expressionToParse, Fraction exponent)
    {
        var functionParams = expressionToParse.Split(',');
        if (functionParams.Length != 2 || !Fraction.TryParse(functionParams[1], out Fraction exponentParsed))
        {
            throw new FormatException($"The provided string is not in the correct format for the Pow function {expressionToParse}");
        }

        return new ExpressionEvaluationTerm(functionParams[0], exponent * exponentParsed);
    }

    public CompositeExpression CreateExpression(Fraction coefficient, Fraction exponent, CompositeExpression functionBody)
    {
        return functionBody;
    }
}
