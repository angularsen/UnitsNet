// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class ConvertValueToAnotherQuantityUnitBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    // these are the currently supported options
    // (typeof(Area), typeof(ReciprocalArea)),
    // (typeof(Density), typeof(SpecificVolume)),
    // (typeof(ElectricConductivity), typeof(ElectricResistivity)),
    // (typeof(Length), typeof(ReciprocalLength))
    [Params(typeof(Area), typeof(Density), typeof(Length))]
    public Type TypeToTest { get; set; }
    
    private UnitConverter _quantityConverter;
    
    #region Benchmarks

    [Benchmark(Baseline = true)]
    public QuantityValue ConvertWith_FullyCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_FullyCachedDynamicDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_SemiCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_TargetCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_EmptyFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithoutCaching()
    {
        return ConvertWithConverter();
    }
    
    private QuantityValue ConvertWithConverter()
    {
        // return ConvertWithBaseUnits();
        return ConvertWithAllUnits();
        // return ConvertAllOnce();
    }
    
    private QuantityValue ConvertWithAllUnits()
    {
        QuantityValue result = default;
        if (TypeToTest == typeof(Density))
        {
            foreach (DensityUnit fromUnit in Density.Units)
            {
                foreach (SpecificVolumeUnit toUnit in SpecificVolume.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
            
            foreach (SpecificVolumeUnit fromUnit in SpecificVolume.Units)
            {
                foreach (DensityUnit toUnit in Density.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
        }
        else if (TypeToTest == typeof(Area))
        {
            foreach (AreaUnit fromUnit in Area.Units)
            {
                foreach (ReciprocalAreaUnit toUnit in ReciprocalArea.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
            
            foreach (ReciprocalAreaUnit fromUnit in ReciprocalArea.Units)
            {
                foreach (AreaUnit toUnit in Area.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
        }
        else if (TypeToTest == typeof(Length))
        {
            foreach (LengthUnit fromUnit in Length.Units)
            {
                foreach (ReciprocalLengthUnit toUnit in ReciprocalLength.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
            
            foreach (ReciprocalLengthUnit fromUnit in ReciprocalLength.Units)
            {
                foreach (LengthUnit toUnit in Length.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
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
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.All, true));
    }
    
    [GlobalSetup(Target = nameof(ConvertWith_FullyCachedDynamicDictionary))]
    public void PrepareTo_ConvertWith_FullyCachedDynamicDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(false, ConversionCachingMode.All, true));
    }

    [GlobalSetup(Target = nameof(ConvertWith_SemiCachedFrozenDictionary))]
    public void PrepareTo_ConvertWith_SemiCachedFrozenDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.BaseOnly, true));
    }

    [GlobalSetup(Target = nameof(ConvertWith_TargetCachedFrozenDictionary))]
    public void PrepareTo_ConvertWith_TargetCachedFrozenDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.None, true)
            .WithCustomCachingOptions<Area>(new ConversionCacheOptions(ConversionCachingMode.All, true))
            .WithCustomCachingOptions<ReciprocalArea>(new ConversionCacheOptions(ConversionCachingMode.All, true))
            .WithCustomCachingOptions<Density>(new ConversionCacheOptions(ConversionCachingMode.All, true))
            .WithCustomCachingOptions<SpecificVolume>(new ConversionCacheOptions(ConversionCachingMode.All, true))
            .WithCustomCachingOptions<Length>(new ConversionCacheOptions(ConversionCachingMode.All, true))
            .WithCustomCachingOptions<ReciprocalLength>(new ConversionCacheOptions(ConversionCachingMode.All, true)));
    }

    [GlobalSetup(Target = nameof(ConvertWith_EmptyFrozenDictionary))]
    public void PrepareTo_ConvertWith_EmptyFrozenDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.None, true));
    }

    [GlobalSetup(Target = nameof(ConvertWithoutCaching))]
    public void PrepareTo_ConvertWithoutCaching()
    {
        _quantityConverter = new UnitConverter(UnitParser.Default);
    }

    #endregion

}
