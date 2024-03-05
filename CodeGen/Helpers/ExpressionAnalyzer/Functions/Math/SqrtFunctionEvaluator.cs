using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal class SqrtFunctionEvaluator : IFunctionEvaluator
{
    public string FunctionName => nameof(System.Math.Sqrt);

    public ExpressionEvaluationTerm GetFunctionBody(string expressionToParse, Fraction exponent)
    {
        return new ExpressionEvaluationTerm(expressionToParse, exponent / Fraction.Two);
    }

    public CompositeExpression CreateExpression(Fraction coefficient, Fraction exponent, CompositeExpression functionBody)
    {
        return functionBody;
    }
}