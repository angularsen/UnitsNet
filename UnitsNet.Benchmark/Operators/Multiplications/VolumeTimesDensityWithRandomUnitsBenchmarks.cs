// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.
using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Multiplications;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class VolumeTimesDensityWithRandomUnitsBenchmarks
{
    private static readonly QuantityValue DensityValue = 1.23;
    private static readonly QuantityValue VolumeValue = 9.42;

    private readonly Random _random = new Random(42);
    private (Volume volume, Density density)[] _operands;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }
    
    [ParamsAllValues]
    public ConversionCachingMode CachingMode { get; set; }


    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        
        _operands = _random.GetRandomQuantities<Volume, VolumeUnit>(VolumeValue, Volume.Units.ToArray(), NbOperations)
            .Zip(_random.GetRandomQuantities<Density, DensityUnit>(DensityValue, Density.Units.ToArray(), NbOperations),
                (volume, density) => (volume, density))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public Mass VolumeTimesDensity()
    {
        Mass result = default;
        foreach ((Volume volume, Density density) in _operands)
        {
            result = volume * density;
        }

        return result;
    }
    
    [Benchmark(Baseline = false)]
    public Mass DensityTimesVolume()
    {
        Mass result = default;
        foreach ((Volume volume, Density density) in _operands)
        {
            result = density * volume;
        }

        return result;
    }
}
