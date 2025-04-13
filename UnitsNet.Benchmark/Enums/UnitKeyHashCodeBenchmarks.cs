// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

// [MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class UnitKeyHashCodeBenchmarks
{
    private const int NbIterations = 1000;

    private static readonly UnitKey UnitKey = UnitKey.ForUnit(VolumeUnit.CubicMeter);

    private readonly Type UnitType = UnitKey.UnitType;
    private readonly int UnitValue = UnitKey.UnitValue;

    [Benchmark(Baseline = true)]
    public int GetHashCodeRecord()
    {
        int hashCode = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            hashCode += UnitKey.GetHashCode();
        }

        return hashCode;
    }

    [Benchmark]
    public int GetCustomHashCode()
    {
        int hashCode = 0;
        for (var i = 0; i < NbIterations; i++)
        {
#if NET
            hashCode += HashCode.Combine(UnitType, UnitValue);
#else
            hashCode += (UnitType.GetHashCode() * 397) ^ UnitValue;
#endif
        }
        
        return hashCode;
    }

    [Benchmark]
    public int GetCustomHashCodeUnchecked()
    {
        int hashCode = 0;
        for (var i = 0; i < NbIterations; i++)
        {
            if (UnitType != null)
            {
                unchecked
                {
                    hashCode += (UnitType.GetHashCode() * 397) ^ UnitValue;
                }
            }
        }

        return hashCode;
    }
}
