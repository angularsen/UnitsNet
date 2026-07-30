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
public class TypeHashcodeBenchmarks
{
    private const int NbIterations = 1000;

    private static readonly Type TestType = typeof(VolumeUnit);
    private static readonly string TestTypeFullName = typeof(VolumeUnit).FullName!;

    [Benchmark(Baseline = true)]
    public int TypeHashcode()
    {
        var hash = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            hash += TestType.GetHashCode();
        }

        return hash;
    }

    [Benchmark(Baseline = false)]
    public int TypeFullNameHashcode()
    {
        var hash = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            hash += TestType.FullName!.GetHashCode();
        }

        return hash;
    }

    [Benchmark(Baseline = false)]
    public int FullNameHashcode()
    {
        var hash = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            hash += TestTypeFullName.GetHashCode();
        }

        return hash;
    }

    [Benchmark(Baseline = false)]
    public int TestTypeName()
    {
        var hash = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            hash += TestType.Name!.GetHashCode();
        }

        return hash;
    }
}
