using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math.Trigonometry;

internal class AsinFunctionEvaluator : MathFunctionEvaluator
{
    public override string FunctionName => nameof(System.Math.Asin);

    public override Fraction Evaluate(Fraction value)
    {
        return Fraction.FromDoubleRounded(System.Math.Asin(value.ToDouble()));
    }
}
