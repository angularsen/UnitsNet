// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class UnitKeyEqualsBenchmarks
{
    private const int NbIterations = 1000;

    private static readonly UnitKey UnitKey = UnitKey.ForUnit(VolumeUnit.CubicMeter);
    private static readonly UnitKey OtherUnitKey = UnitKey.ForUnit(VolumeUnit.AcreFoot);
    private readonly Type OtherUnitType = UnitKey.UnitEnumType;
    private readonly int OtherUnitValue = UnitKey.UnitEnumValue;

    private readonly Type UnitType = UnitKey.UnitEnumType;
    private readonly int UnitValue = UnitKey.UnitEnumValue;

    [Benchmark(Baseline = true)]
    public bool EqualsRecord()
    {
        bool equal = false;
        for (var i = 0; i < NbIterations; i++)
        {
            equal = UnitKey.Equals(OtherUnitKey);
        }

        return equal;
    }

    [Benchmark(Baseline = false)]
    public bool OperatorEqualsRecord()
    {
        bool equal = false;
        for (var i = 0; i < NbIterations; i++)
        {
            equal = UnitKey == OtherUnitKey;
        }
        
        return equal;
    }

    [Benchmark]
    public bool OperatorEqualsManual()
    {
        bool equal = false;
        for (var i = 0; i < NbIterations; i++)
        {
            equal = UnitType == OtherUnitType && UnitValue == OtherUnitValue;
        }
        
        return equal;
    }
}
