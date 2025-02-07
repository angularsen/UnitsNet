using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class EnumToIntegerBenchmarks
{
    private const int NbIterations = 1000;

    private const MassUnit Unit = MassUnit.Gram;

    [Benchmark(Baseline = true)]
    public int ConvertToInt32()
    {
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += Convert.ToInt32(Unit);
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int ConvertWithCast()
    {
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += (int)Unit;
        }

        return total;
    }

    // #if NET
    [Benchmark(Baseline = false)]
    public int ConvertWithUnsafe()
    {
        MassUnit unit = Unit;
        var total = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            total += Unsafe.As<MassUnit, int>(ref unit);
        }

        return total;
    }
    // #endif
}
