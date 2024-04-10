using System;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal abstract class MathFunctionEvaluator : IFunctionEvaluator
{
    public abstract string FunctionName { get; }

    public CompositeExpression CreateExpression(ExpressionEvaluationTerm expressionToParse, Func<ExpressionEvaluationTerm, CompositeExpression> expressionResolver)
    {
        CompositeExpression functionBody = expressionResolver(expressionToParse with {Exponent = 1});
        Fraction power = expressionToParse.Exponent;
        if (functionBody.IsConstant) // constant expression (directly evaluate the function)
        {
            var constantTerm = (ExpressionTerm)functionBody;
            Fraction resultingValue = Evaluate(constantTerm.Coefficient);
            return ExpressionTerm.Constant(resultingValue.Pow(power));
        }
         // we cannot expand a function of x
        return new ExpressionTerm(1, power, new CustomFunction(FunctionName, functionBody));
    }

    public abstract Fraction Evaluate(Fraction value);
}
