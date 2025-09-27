// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
// [DryJob]
// [ShortRunJob]
[SimpleJob(RunStrategy.ColdStart, launchCount:10)]
public class QuantityConverterColdStartBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    [Params(typeof(Volume), typeof(Mass), typeof(Density), typeof(Pressure))]
    public Type TypesToTest { get; set; }
    
    private UnitConverter _quantityConverter;
    
    #region Benchmarks

    [Benchmark(Baseline = true)]
    public QuantityValue ConvertWith_FullyCachedFrozenDictionary()
    {
        return ConvertWithConverter();
    }
    
    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_EmptyFrozenDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWith_EmptyDynamicDictionary()
    {
        return ConvertWithConverter();
    }

    [Benchmark(Baseline = false)]
    public QuantityValue ConvertWithTheNoCachingConverter()
    {
        return ConvertWithConverter();
    }
    
    private QuantityValue ConvertWithConverter()
    {
        QuantityValue result = default;
        if (TypesToTest == typeof(Volume))
        {
            foreach (VolumeUnit fromUnit in Volume.Units)
            {
                foreach (VolumeUnit toUnit in Volume.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
        }
        else if (TypesToTest == typeof(Mass))
        {
            foreach (MassUnit fromUnit in Mass.Units)
            {
                foreach (MassUnit toUnit in Mass.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
        }
        else if (TypesToTest == typeof(Density))
        {
            foreach (DensityUnit fromUnit in Density.Units)
            {
                foreach (DensityUnit toUnit in Density.Units)
                {
                    result = _quantityConverter.ConvertValue(Value, fromUnit, toUnit);
                }
            }
        }
        else if (TypesToTest == typeof(Pressure))
        {
            foreach (PressureUnit fromUnit in Pressure.Units)
            {
                foreach (PressureUnit toUnit in Pressure.Units)
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
    
    [GlobalSetup(Target = nameof(ConvertWith_EmptyFrozenDictionary))]
    public void PrepareTo_ConvertWith_EmptyFrozenDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.None, true));
    }

    [IterationSetup(Target = nameof(ConvertWith_EmptyDynamicDictionary))]
    public void PrepareTo_ConvertWith_EmptyStandardDictionary()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(false, ConversionCachingMode.None, true));
    }

    [GlobalSetup(Target = nameof(ConvertWithTheNoCachingConverter))]
    public void PrepareTo_ConvertWithTheNoCachingConverter()
    {
        _quantityConverter = UnitConverter.Create(UnitParser.Default, new QuantityConverterBuildOptions(true, ConversionCachingMode.None, true));
    }

    #endregion

}
