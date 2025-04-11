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
[SimpleJob(RuntimeMoniker.Net80)]
public class AddTwoMassesWithRandomUnitsBenchmarks
{
    private static readonly double LeftValue = 1.23;
    private static readonly double RightValue = 4.56;

    private readonly Random _random = new(42);
    private (Mass left, Mass right)[] _operands;

    [Params(1_000)]
    public int NbOperations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _operands = _random.GetRandomQuantities<Mass, MassUnit>(LeftValue, Mass.Units, NbOperations)
            .Zip(_random.GetRandomQuantities<Mass, MassUnit>(RightValue, Mass.Units, NbOperations),
                (left, right) => (left, right))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public Mass AddTwoMasses()
    {
        Mass sum = default;
        foreach ((Mass left, Mass right) in _operands)
        {
            sum = left + right; // intentionally not summing the results
        }

        return sum;
    }
}
