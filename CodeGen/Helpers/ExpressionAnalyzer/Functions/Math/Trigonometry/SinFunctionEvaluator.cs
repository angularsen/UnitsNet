using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math.Trigonometry;

internal class SinFunctionEvaluator : MathFunctionEvaluator
{
    public override string FunctionName => nameof(System.Math.Sin);

    public override Fraction Evaluate(Fraction value)
    {
        return Fraction.FromDoubleRounded(System.Math.Sin(value.ToDouble()));
    }
}
