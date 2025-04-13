using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class ConvertValueBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    
    #region Benchmarks

    [Benchmark(Baseline = true)]
    public QuantityValue ConvertWith_FullyCachedFrozenDictionary()
    {
        return ConvertAll();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_FullyCachedDynamicDictionary()
    {
        return ConvertAll();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_SemiCachedFrozenDictionary()
    {
        return ConvertAll();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithoutCaching()
    {
        return ConvertAll();
    }
    
    private QuantityValue ConvertAll()
    {
        UnitConverter converter = UnitConverter.Default;
        QuantityValue result = default;
        foreach (QuantityInfo quantityInfo in Quantity.Infos)
        {
            foreach (UnitInfo fromUnitInfo in quantityInfo.UnitInfos)
            {
                foreach (UnitInfo toUnitInfo in quantityInfo.UnitInfos)
                {
                    result = converter.ConvertValue(Value, fromUnitInfo.UnitKey, toUnitInfo.UnitKey);
                }
            }
        }

        return result;
    }

    #endregion

    #region Setup

    [GlobalSetup(Target = nameof(ConvertWith_FullyCachedFrozenDictionary))]
    public void PrepareTo_ConvertWith_FullyCachedFrozenDictionary()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(true, ConversionCachingMode.All, true)));
    }
    
    [GlobalSetup(Target = nameof(ConvertWith_FullyCachedDynamicDictionary))]
    public void PrepareTo_ConvertWith_FullyCachedDynamicDictionary()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(false, ConversionCachingMode.All, true)));
    }

    [GlobalSetup(Target = nameof(ConvertWith_SemiCachedFrozenDictionary))]
    public void PrepareTo_ConvertWith_SemiCachedFrozenDictionary()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(true, ConversionCachingMode.BaseOnly, true)));
    }

    [GlobalSetup(Target = nameof(ConvertWithoutCaching))]
    public void PrepareTo_ConvertWithoutCaching()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(true, ConversionCachingMode.None)));
    }

    #endregion
}
