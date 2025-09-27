using System;
using System.Globalization;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal class PowFunctionEvaluator : IFunctionEvaluator
{
    public string Namespace => nameof(System.Math);
    public string FunctionName => nameof(System.Math.Pow);

    public bool ExpandNonConstantExpressions { get; set; } = false; // while it's possible to expand the expression (even for non-rational powers)- probably we shouldn't

    public CompositeExpression CreateExpression(ExpressionEvaluationTerm expressionToParse,
        Func<ExpressionEvaluationTerm, CompositeExpression> expressionResolver)
    {
        var functionParams = expressionToParse.Expression.Split(',');
        if (functionParams.Length != 2 || !Fraction.TryParse(functionParams[1], out Fraction exponentParsed))
        {
            throw new FormatException($"The provided string is not in the correct format for the Pow function {expressionToParse}");
        }

        CompositeExpression functionBody = expressionResolver(new ExpressionEvaluationTerm(functionParams[0], 1));
        Fraction power = expressionToParse.Exponent * exponentParsed;

        if (functionBody.IsConstant)
        {
            var singleTerm = (ExpressionTerm)functionBody;
            Fraction coefficient = singleTerm.Coefficient.Pow(power);
            return ExpressionTerm.Constant(coefficient);
        }

        if (!ExpandNonConstantExpressions)
        {
            return new ExpressionTerm(1, 1, new CustomFunction(Namespace, FunctionName, functionBody, power.ToDecimal().ToString(CultureInfo.InvariantCulture)));
        }

        // while it's possible to expand the expression (even for non-rational powers)- we shouldn't, as the operation would not be reversible: the result of (x^0.5)^2 may be different from x
        if (functionBody.Terms.Count == 1) 
        {
            var singleTerm = (ExpressionTerm)functionBody;
            Fraction coefficient = singleTerm.Coefficient.Pow(power);
            return singleTerm with { Coefficient = coefficient, Exponent = singleTerm.Exponent * power };
        }

        // TODO see about handling the multi-term expansion (at least for integer exponents)
        return new ExpressionTerm(1, 1, new CustomFunction(Namespace, FunctionName, functionBody, power.ToDecimal().ToString(CultureInfo.InvariantCulture)));
    }
}
