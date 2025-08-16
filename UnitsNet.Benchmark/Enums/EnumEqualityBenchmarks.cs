// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class EnumEqualityBenchmarks
{
    private const int NbIterations = 1000;
    
    private const MassUnit Unit = MassUnit.Gram;

    [Benchmark(Baseline = true)]
    public bool IsEqualWithComparer()
    {
        const MassUnit targetUnit = MassUnit.Gram;
        var result = false;
        for (var i = 0; i < NbIterations; i++)
        {
            result = EqualityComparer<MassUnit>.Default.Equals(Unit, targetUnit);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public bool IsNotEqualWithComparer()
    {
        const MassUnit targetUnit = MassUnit.Milligram;
        var result = false;
        for (var i = 0; i < NbIterations; i++)
        {
            result = EqualityComparer<MassUnit>.Default.Equals(Unit, targetUnit);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public bool IsEqualWithUnsafe()
    {
        const MassUnit targetUnit = MassUnit.Gram;
        var result = false;
        for (var i = 0; i < NbIterations; i++)
        {
            result = UnitEqualityComparer<MassUnit>.Default.Equals(Unit, targetUnit);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public bool IsNotEqualWithUnsafe()
    {
        const MassUnit targetUnit = MassUnit.Milligram;
        var result = false;
        for (var i = 0; i < NbIterations; i++)
        {
            result = UnitEqualityComparer<MassUnit>.Default.Equals(Unit, targetUnit);
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public bool IsEqualWithOperator()
    {
        const MassUnit targetUnit = MassUnit.Gram;
        var result = false;
        for (var i = 0; i < NbIterations; i++)
        {
            result = Unit == targetUnit;
        }

        return result;
    }

    [Benchmark(Baseline = false)]
    public bool IsNotEqualWithOperator()
    {
        const MassUnit targetUnit = MassUnit.Milligram;
        var result = true;
        for (var i = 0; i < NbIterations; i++)
        {
            result = Unit == targetUnit;
        }

        return result;
    }

    public class UnitEqualityComparer<TUnit> : IEqualityComparer<TUnit> where TUnit : struct, Enum
    {
        // Singleton instance of the comparer
        public static readonly UnitEqualityComparer<TUnit> Default = new();

        private UnitEqualityComparer()
        {
        }

        public bool Equals(TUnit x, TUnit y)
        {
            // Use Unsafe.As to convert enums to integers for comparison
            var xInt = Unsafe.As<TUnit, int>(ref x);
            var yInt = Unsafe.As<TUnit, int>(ref y);
            return xInt == yInt;
        }

        public int GetHashCode(TUnit obj)
        {
            // Use Unsafe.As to convert enum to integer for hash code calculation
            var objInt = Unsafe.As<TUnit, int>(ref obj);
            return objInt.GetHashCode();
        }
    }
}
