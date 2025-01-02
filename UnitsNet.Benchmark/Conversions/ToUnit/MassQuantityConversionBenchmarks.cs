using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToUnit;

[MemoryDiagnoser]
public class MassQuantityConversionBenchmarks
{
    private static readonly Mass FromMass = new(12345.67, MassUnit.Milligram);
    private static readonly Dictionary<(MassUnit, MassUnit), Func<Mass, Mass>> ConversionFunctions = GetConversionsFunctions();

    private static Dictionary<(MassUnit, MassUnit), Func<Mass, Mass>> GetConversionsFunctions()
    {
        var functions = new Dictionary<(MassUnit, MassUnit), Func<Mass, Mass>>();
        foreach (MassUnit unit in Mass.Units)
        {
            foreach (MassUnit otherUnit in Mass.Units)
            {
                functions.Add((unit, otherUnit), mass => mass.ToUnit(otherUnit));
            }
        }

        // functions[(MassUnit.Milligram, MassUnit.Gram)] = mass => new Mass(mass.Value * new QuantityValue(1, 1000), MassUnit.Gram);
        functions[(MassUnit.Milligram, MassUnit.Gram)] = mass => new Mass(mass.Value / 1000, MassUnit.Gram);

        return functions;
    }

    [Benchmark(Baseline = true)]
    public Mass ConvertFromMilligramToGram() => FromMass.ToUnit(MassUnit.Gram);

    [Benchmark]
    public Mass ConvertFromMilligramToGramWithDictionary() => ConversionFunctions[(MassUnit.Milligram, MassUnit.Gram)](FromMass);
}
