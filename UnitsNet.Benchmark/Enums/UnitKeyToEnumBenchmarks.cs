// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class UnitKeyToEnumBenchmarks
{
    private const int NbIterations = 500;
    private static readonly UnitKey UnitKey = MassUnit.Gram;

    [Benchmark(Baseline = true)]
    public int ManualCast()
    {
        UnitKey unitKey = UnitKey;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            if ((MassUnit)unitKey.UnitEnumValue == MassUnit.Gram)
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ExplicitCast()
    {
        UnitKey unitKey = UnitKey;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            if ((MassUnit)unitKey == MassUnit.Gram)
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ExplicitCastBoxed()
    {
        UnitKey unitKey = UnitKey;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            if (MassUnit.Gram.Equals((Enum)unitKey))
            {
                total++;
            }
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ToUnit()
    {
        UnitKey unitKey = UnitKey;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            if (unitKey.ToUnit<MassUnit>() == MassUnit.Gram)
            {
                total++;
            }
        }

        return total;
    }
}
