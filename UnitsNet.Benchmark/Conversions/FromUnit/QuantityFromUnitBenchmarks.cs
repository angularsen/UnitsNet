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

    [Benchmark(Baseline = true)]
    public void QuantityFromUnit()
    {
        foreach (Enum baseUnit in BaseUnits)
        {
            IQuantity quantity = Quantity.From(1, baseUnit);
        }
    }

    [Benchmark]
    public void QuantityTryFromUnit()
    {
        foreach (Enum baseUnit in BaseUnits)
        {
            var success = Quantity.TryFrom(1, baseUnit, out _);
        }
    }
}
