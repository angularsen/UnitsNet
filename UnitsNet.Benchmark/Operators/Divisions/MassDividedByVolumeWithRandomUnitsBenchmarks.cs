// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Divisions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class MassDividedByVolumeWithRandomUnitsBenchmarks
{
    private static readonly double MassValue = 1.23;
    private static readonly double VolumeValue = 9.42;

    private readonly Random _random = new(42);
    private (Mass left, Volume right)[] _operands;

    [Params(1000)]
    public int NbOperations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _operands = _random.GetRandomQuantities<Mass, MassUnit>(MassValue, Mass.Units, NbOperations)
            .Zip(_random.GetRandomQuantities<Volume, VolumeUnit>(VolumeValue, Volume.Units, NbOperations), (mass, volume) => (volume: mass, density: volume))
            .ToArray();
    }

    [Benchmark]
    public Density MassByVolume()
    {
        Density result = default;
        foreach ((Mass mass, Volume volume) in _operands)
        {
            result = mass / volume;
        }

        return result;
    }
}
