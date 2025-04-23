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
public class SumOfMassesWithRandomUnitsBenchmarks
{
    private static readonly double Value = 1.23;

    private readonly Random _random = new(42);
    private Mass[] _quantities;

    [Params(1000)]
    public int NbOperations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _quantities = _random.GetRandomQuantities<Mass, MassUnit>(Value, Mass.Units.ToArray(), NbOperations).ToArray();
    }
    
    [Benchmark(Baseline = true)]
    public Mass SumOfMasses()
    {
#if NET
        return UnitsNet.GenericMath.GenericMathExtensions.Sum(_quantities);
#else
        Mass sum = Mass.Zero;
        foreach (var quantity in _quantities)
        {
            sum = quantity + sum;
        }

        return sum;
#endif
    }

    [Benchmark(Baseline = false)]
    public Mass SumOfMassesWithBaseUnit()
    {
        return _quantities.Sum(Mass.BaseUnit);
    }

    [Benchmark(Baseline = false)]
    public Mass SumOfMassesWithInMilligrams()
    {
        return _quantities.Sum(MassUnit.Milligram);
    }
}
