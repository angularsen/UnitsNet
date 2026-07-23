// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
public class SumOfVolumesWithRandomAndUnitsConfigurationBenchmarksNet9
{
    private static readonly QuantityValue Value = 1.23;

    private readonly Random _random = new(42);
    private Volume[] _quantities;

    [Params(1000)]
    public int NbOperations { get; set; }
    
    [Params(true, false)]
    public bool Frozen { get; set; }

    [Params(true, false)]
    public bool ReducedConstants { get; set; }

    [Params(ConversionCachingMode.None, ConversionCachingMode.BaseOnly, ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode, ReducedConstants)));
        Quantity.From(Value, Volume.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)
        
        _quantities = _random.GetRandomQuantities<Volume, VolumeUnit>(Value, Volume.Units.ToArray(), NbOperations).ToArray();
        Console.Out.WriteLine("Quantities prepared: starting unit = {0} ({1})", _quantities[0].Unit, _quantities[0].QuantityInfo[_quantities[0].Unit].ConversionToBase);
    }
    
    [Benchmark(Baseline = true)]
    public Volume SumOfVolumes()
    {
        return _quantities.Sum();
    }

    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInBaseUnit()
    {
        return _quantities.Sum(Volume.BaseUnit);
    }
    
    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInMilliliter()
    {
        return _quantities.Sum(VolumeUnit.Milliliter);
    }
}
