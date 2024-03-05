using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal abstract class MathFunctionEvaluator : IFunctionEvaluator
{
    public abstract string FunctionName { get; }

    public ExpressionEvaluationTerm GetFunctionBody(string expressionToParse, Fraction exponent)
    {
        return new ExpressionEvaluationTerm(expressionToParse, Fraction.One);
    }

    public CompositeExpression CreateExpression(Fraction coefficient, Fraction exponent, CompositeExpression functionBody)
    {
        ExpressionTerm expression;
        if (functionBody.IsConstant) // constant expression (directly evaluate the function)
        {
            var constantTerm = (ExpressionTerm)functionBody;
            Fraction resultingValue = Evaluate(constantTerm.Coefficient);
            expression = constantTerm with { Coefficient = resultingValue };
        }
        else // we cannot expand a function of x
        {
            expression = new ExpressionTerm(coefficient, exponent, new CustomFunction(FunctionName, functionBody));
        }

        return expression;
    }

    public abstract Fraction Evaluate(Fraction value);
}
