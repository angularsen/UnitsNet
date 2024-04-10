using System;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

internal class SqrtFunctionEvaluator : IFunctionEvaluator
{
    public string FunctionName => nameof(System.Math.Sqrt);
    public bool ExpandNonConstantExpressions { get; set; } = false; // while it's possible to expand the expression (even for non-rational powers)- probably we shouldn't
    
    public CompositeExpression CreateExpression(ExpressionEvaluationTerm expressionToParse, Func<ExpressionEvaluationTerm, CompositeExpression> expressionResolver)
    {
        CompositeExpression functionBody = expressionResolver(expressionToParse with {Exponent = 1});
        if (functionBody.IsConstant)
        {
            var constantTerm = (ExpressionTerm)functionBody;
            Fraction coefficient = constantTerm.Coefficient.Pow(expressionToParse.Exponent * FractionExtensions.OneHalf);
            return ExpressionTerm.Constant(coefficient);
        }
        
        if (!ExpandNonConstantExpressions)
        {
            return new ExpressionTerm(1, expressionToParse.Exponent, new CustomFunction(FunctionName, functionBody));
        }
        
        // while it's possible to expand the expression (even for non-rational powers)- we shouldn't, as the operation would not be reversible: the result of (x^0.5)^2 may be different from x
        Fraction power = expressionToParse.Exponent * FractionExtensions.OneHalf;
        if (functionBody.Terms.Count == 1) 
        {
            var constantTerm = (ExpressionTerm)functionBody;
            Fraction coefficient = constantTerm.Coefficient.Pow(power);
            return constantTerm with { Coefficient = coefficient, Exponent = constantTerm.Exponent * power };
        }

        // TODO see about handling the multi-term expansion (at least for integer exponents)
        return new ExpressionTerm(1, power, new CustomFunction(FunctionName, functionBody));
    }
}
