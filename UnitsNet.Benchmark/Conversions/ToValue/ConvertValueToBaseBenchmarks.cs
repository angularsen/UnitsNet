// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class ConvertValueToBaseBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    
    #region Benchmarks

    [Benchmark(Baseline = true)]
    public QuantityValue ConvertWith_FullyCachedFrozenDictionary()
    {
        return ConvertWithBase();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_FullyCachedDynamicDictionary()
    {
        return ConvertWithBase();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_SemiCachedFrozenDictionary()
    {
        return ConvertWithBase();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithoutCaching()
    {
        return ConvertWithBase();
    }

    private QuantityValue ConvertWithBase()
    {
        UnitConverter converter = UnitConverter.Default;
        QuantityValue result = default;
        foreach (QuantityInfo quantityInfo in Quantity.Infos)
        {
            UnitKey baseUnitKey = quantityInfo.BaseUnitInfo.UnitKey;
            foreach (UnitInfo unitInfo in quantityInfo.UnitInfos)
            {
                UnitKey unitKey = unitInfo.UnitKey;
                result = converter.ConvertValue(Value, unitKey, baseUnitKey);
                result = converter.ConvertValue(Value, baseUnitKey, unitKey);
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
