// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class BoxedEnumToIntegerBenchmarks
{
    private const int NbIterations = 1000;

    private static readonly Enum Unit = MassUnit.Gram;

    [Benchmark(Baseline = true)]
    public int ConvertToInt32()
    {
        Enum unit = Unit;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += Convert.ToInt32(unit);
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ConvertWithCast()
    {
        Enum unit = Unit;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += (int)(object)unit;
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ConvertWithUnsafe()
    {
        Enum unit = Unit;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += Unsafe.Unbox<int>(unit);
        }

        return total;
    }
}
