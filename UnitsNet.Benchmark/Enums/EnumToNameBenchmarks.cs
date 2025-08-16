#if NET

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class EnumToNameBenchmarks
{
    private const int NbIterations = 1000;

    private const MassUnit Unit = MassUnit.Gram;
    private static readonly QuantityInfo<Mass, MassUnit> MassInfo = Mass.Info;

    [Benchmark(Baseline = true)]
    public void GetNameFromEnum()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var _ = GetNameFromEnum(Unit);
        }
    }

    [Benchmark(Baseline = false)]
    public void GetNameFromInfo()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            var _ = GetNameFromInfo(MassInfo, Unit);
        }
    }

    private static string GetNameFromEnum<TUnit>(TUnit unit) where TUnit : struct, Enum
    {
        return unit.ToString();
    }

    private static string GetNameFromInfo<TUnit>(QuantityInfo<TUnit> quantityInfo, TUnit unit) where TUnit : struct, Enum
    {
        return quantityInfo[unit].Name;
    }
}
#endif
