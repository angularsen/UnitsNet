using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.FromUnit;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityFromUnitBenchmarks
{
    private static readonly Enum[] BaseUnits = Quantity.Infos.Select(x => x.BaseUnitInfo.Value).ToArray();
    
    private static readonly UnitKey[] BaseUnitKeys = Quantity.Infos.Select(x => x.BaseUnitInfo.UnitKey).ToArray();

    [GlobalSetup]
    public void Setup()
    {
        Quantity.From(1, Mass.BaseUnit);
    }

    [Benchmark(Baseline = true)]
    public void QuantityFromUnit()
    {
        foreach (Enum baseUnit in BaseUnits)
        {
            IQuantity quantity = Quantity.From(QuantityValue.One, baseUnit);
        }
    }

    [Benchmark]
    public void QuantityFromUnitKey()
    {
        foreach (UnitKey baseUnit in BaseUnitKeys)
        {
            IQuantity quantity = Quantity.From(QuantityValue.One, baseUnit);
        }
    }

    [Benchmark]
    public void QuantityTryFromUnit()
    {
        foreach (Enum baseUnit in BaseUnits)
        {
            var success = Quantity.TryFrom(QuantityValue.One, baseUnit, out _);
        }
    }
}
