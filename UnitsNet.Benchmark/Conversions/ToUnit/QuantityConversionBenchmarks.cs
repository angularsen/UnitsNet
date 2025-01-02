using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.ToUnit;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class QuantityConversionBenchmarks
{
    private static readonly IReadOnlyCollection<IQuantity> Quantities =
        Quantity.Infos.SelectMany(x => x.UnitInfos).Select(u => Quantity.From(123.456, u.Value)).ToList();

    [Benchmark(Baseline = true)]
    public double ConvertOnce()
    {
        double result = 0;
        foreach (IQuantity quantity in Quantities)
        {
            foreach (UnitInfo unitInfo in quantity.QuantityInfo.UnitInfos)
            {
                result = quantity.As(unitInfo.Value);
            }
        }

        return result;
    }
}
