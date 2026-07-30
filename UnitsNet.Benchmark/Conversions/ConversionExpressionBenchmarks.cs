// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace UnitsNet.Benchmark.Conversions;

[MemoryDiagnoser]
public class ConversionExpressionBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    private static readonly ConversionExpression[] DefaultExpression = Quantity.Infos.SelectMany(GetUnreducedExpressionsForQuantity).ToArray();
    private static readonly ConversionExpression[] ReducedExpression = Quantity.Infos.SelectMany(GetReducedExpressionsForQuantity).ToArray();

    private static readonly ConvertValueDelegate[] ConversionFunctions = ReducedExpression.Select(x => (ConvertValueDelegate)x).ToArray();

    private static IEnumerable<ConversionExpression> GetUnreducedExpressionsForQuantity(QuantityInfo quantityInfo)
    {
        return from fromUnit in quantityInfo.UnitInfos
            from toUnit in quantityInfo.UnitInfos
            select fromUnit.ConversionToBase.Evaluate(toUnit.ConversionFromBase);
    }

    private static IEnumerable<ConversionExpression> GetReducedExpressionsForQuantity(QuantityInfo quantityInfo)
    {
        return from fromUnit in quantityInfo.UnitInfos
            from toUnit in quantityInfo.UnitInfos
            select fromUnit.ConversionToBase.Evaluate(toUnit.ConversionFromBase, true);
    }

    [Benchmark(Baseline = true)]
    public QuantityValue ConvertWithDefaultExpression()
    {
        QuantityValue result = QuantityValue.Zero;
        foreach (ConversionExpression expression in DefaultExpression)
        {
            result = expression.Evaluate(Value);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithReducedExpression()
    {
        QuantityValue result = QuantityValue.Zero;
        foreach (ConversionExpression expression in ReducedExpression)
        {
            result = expression.Evaluate(Value);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithFunctions()
    {
        QuantityValue result = QuantityValue.Zero;
        foreach (ConvertValueDelegate function in ConversionFunctions)
        {
            result = function(Value);
        }

        return result;
    }
}
