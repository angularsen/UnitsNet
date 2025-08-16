// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class SumOfVolumesWithSameUnitsBenchmarks
{
    private static readonly QuantityValue Value = 1.23;
    
    private Volume[] _quantities;

    [Params(10, 1000)]
    public int NbOperations { get; set; }
    
    [Params(true)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(VolumeUnit.CubicMeter, VolumeUnit.Liter, VolumeUnit.Milliliter)]
    public VolumeUnit Unit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        Quantity.From(Value, Volume.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)
        
        _quantities = Enumerable.Range(0, NbOperations).Select(_ => Volume.From(Value, Unit)).ToArray();
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
