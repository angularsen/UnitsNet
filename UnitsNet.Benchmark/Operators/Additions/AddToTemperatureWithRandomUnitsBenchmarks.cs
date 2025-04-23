// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class AddToTemperatureWithRandomUnitsBenchmarks
{
    private static readonly double LeftValue = 1.23;
    private static readonly double RightValue = 4.56;

    private readonly Random _random = new(42);
    private (Temperature left, TemperatureDelta right)[] _operands;

    [Params(1_000)]
    public int NbOperations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _operands = _random.GetRandomQuantities<Temperature, TemperatureUnit>(LeftValue, Temperature.Units.ToArray(), NbOperations)
            .Zip(_random.GetRandomQuantities<TemperatureDelta, TemperatureDeltaUnit>(RightValue, TemperatureDelta.Units.ToArray(), NbOperations),
                (left, right) => (left, right))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public Temperature AddToTemperature()
    {
        Temperature sum = default;
        foreach ((Temperature left, TemperatureDelta right) in _operands)
        {
            sum = left + right; // intentionally not summing the results
        }

        return sum;
    }
}
