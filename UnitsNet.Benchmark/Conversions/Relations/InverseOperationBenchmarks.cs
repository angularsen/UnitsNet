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
// [ShortRunJob]
public class InverseOperationBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    
    // new (typeof(Area), typeof(ReciprocalArea)),
    // new (typeof(Density), typeof(SpecificVolume)),
    // new (typeof(ElectricConductivity), typeof(ElectricResistivity)),
    // new (typeof(Length), typeof(ReciprocalLength)),
    
    [Params(typeof(Area), typeof(Density), typeof(Length))]
    public Type TypeToTest { get; set; }
    
    private UnitConverter _quantityConverter;
    
    #region Benchmarks

    [Benchmark(Baseline = true)]
    public IQuantity ConvertWith_FullyCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public IQuantity ConvertWith_FullyCachedDynamicDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public IQuantity ConvertWith_SemiCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public IQuantity ConvertWith_TargetCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public IQuantity ConvertWith_EmptyFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public IQuantity ConvertWithoutCaching()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public IQuantity ConvertWithInverse()
    {
        IQuantity result = default;
        if (TypeToTest == typeof(Density))
        {
            foreach (DensityUnit fromUnit in Density.Units)
            {
                var quantity = Density.From(Value, fromUnit);
                result = quantity.Inverse();
            }
            
            foreach (SpecificVolumeUnit fromUnit in SpecificVolume.Units)
            {
                var quantity = SpecificVolume.From(Value, fromUnit);
                result = quantity.Inverse();
            }
        }
        else if (TypeToTest == typeof(Area))
        {
            foreach (AreaUnit fromUnit in Area.Units)
            {
                var quantity = Area.From(Value, fromUnit);
                result = quantity.Inverse();
            }
            
            foreach (ReciprocalAreaUnit fromUnit in ReciprocalArea.Units)
            {
                var quantity = ReciprocalArea.From(Value, fromUnit);
                result = quantity.Inverse();
            }
        }
        else if (TypeToTest == typeof(Length))
        {
            foreach (LengthUnit fromUnit in Length.Units)
            {
                var quantity = Length.From(Value, fromUnit);
                result = quantity.Inverse();
            }
            
            foreach (ReciprocalLengthUnit fromUnit in ReciprocalLength.Units)
            {
                var quantity = ReciprocalLength.From(Value, fromUnit);
                result = quantity.Inverse();
            }
        }

        return result;
    }
    
    private IQuantity ConvertWithConverter()
    {
        // return ConvertWithBaseUnits();
        return ConvertWithAllUnits();
        // return ConvertAllOnce();
    }
    
    private IQuantity ConvertWithAllUnits()
    {
        IQuantity result = default;
        if (TypeToTest == typeof(Density))
        {
            foreach (DensityUnit fromUnit in Density.Units)
            {
                var quantity = Density.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, SpecificVolume.Info);
            }
            
            foreach (SpecificVolumeUnit fromUnit in SpecificVolume.Units)
            {
                var quantity = SpecificVolume.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, Density.Info);
            }
        }
        else if (TypeToTest == typeof(Area))
        {
            foreach (AreaUnit fromUnit in Area.Units)
            {
                var quantity = Area.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, ReciprocalArea.Info);
            }
            
            foreach (ReciprocalAreaUnit fromUnit in ReciprocalArea.Units)
            {
                var quantity = ReciprocalArea.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, Area.Info);
            }
        }
        else if (TypeToTest == typeof(Length))
        {
            foreach (LengthUnit fromUnit in Length.Units)
            {
                var quantity = Length.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, ReciprocalLength.Info);
            }
            
            foreach (ReciprocalLengthUnit fromUnit in ReciprocalLength.Units)
            {
                var quantity = ReciprocalLength.From(Value, fromUnit);
                result = _quantityConverter.ConvertTo(quantity.Value, quantity.Unit, Length.Info);
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

    [GlobalSetup(Target = nameof(ConvertWithInverse))]
    public void PrepareTo_ConvertWithInverse()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(true, ConversionCachingMode.All)));
    }

    #endregion

}
