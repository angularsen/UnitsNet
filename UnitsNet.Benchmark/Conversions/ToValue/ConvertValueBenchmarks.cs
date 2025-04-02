using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class ConvertValueBenchmarks
{
    private static readonly double Value = 123.456;
    
    
    [Benchmark(Baseline = true)]
    public double ConvertWithConverter()
    {
        double result = default;
        foreach (QuantityInfo quantityInfo in Quantity.Infos)
        {
            foreach (UnitInfo fromUnitInfo in quantityInfo.UnitInfos)
            {
                foreach (UnitInfo toUnitInfo in quantityInfo.UnitInfos)
                {
                    result = UnitConverter.Convert(Value, fromUnitInfo.Value, toUnitInfo.Value);
                }
            }
        }

        return result;
    }
    
    [Benchmark(Baseline = false)]
    public double ConvertFromQuantity()
    {
        double result = default;
        foreach (QuantityInfo quantityInfo in Quantity.Infos)
        {
            foreach (UnitInfo fromUnitInfo in quantityInfo.UnitInfos)
            {
                foreach (UnitInfo toUnitInfo in quantityInfo.UnitInfos)
                {
                    result = Quantity.From(Value, fromUnitInfo.Value).As(toUnitInfo.Value);
                }
            }
        }

        return result;
    }
    

    [GlobalSetup]
    public void PrepareTo_ConvertWith_FullyCachedFrozenDictionary()
    {
        var nbQuantities = Quantity.Infos.Count;
    }
    
}
