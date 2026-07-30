#if NET

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Enums;

[SimpleJob(RuntimeMoniker.Net80)]
public class EnumFromNameBenchmarks
{
    private const int NbIterations = 1000;

    private const string Unit = "Gram";
    private static readonly QuantityInfo<Mass, MassUnit> MassInfo = Mass.Info;

    [Benchmark(Baseline = true)]
    public void GetUnitFromEnum()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            MassUnit _ = GetUnitFromEnum<MassUnit>(Unit, false);
        }
    }

    [Benchmark(Baseline = false)]
    public void GetUnitFromEnumIgnoreCase()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            MassUnit _ = GetUnitFromEnum<MassUnit>(Unit, true);
        }
    }

    [Benchmark(Baseline = false)]
    public void GetUnitFromInfo()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            MassUnit _ = GetUnitFromInfo(MassInfo, Unit);
        }
    }

    [Benchmark(Baseline = false)]
    public void GetUnitFromInfoIgnoreCase()
    {
        for (var i = 0; i < NbIterations; i++)
        {
            MassUnit _ = GetUnitFromInfoIgnoreCase(MassInfo, Unit);
        }
    }

    private static TUnit GetUnitFromEnum<TUnit>(ReadOnlySpan<char> unitNamePart, bool ignoreCase) where TUnit : struct, Enum
    {
        if (Enum.TryParse(unitNamePart, ignoreCase, out TUnit unit))
        {
            return unit;
        }

        throw new UnitNotFoundException();
    }

    private static TUnit GetUnitFromInfo<TUnit>(QuantityInfo<TUnit> quantityInfo, ReadOnlySpan<char> unitNamePart) where TUnit : struct, Enum
    {
        IReadOnlyList<UnitInfo<TUnit>> unitInfos = quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo<TUnit> unitInfo = unitInfos[i];
            if (unitNamePart.Equals(unitInfo.Name, StringComparison.Ordinal))
            {
                return unitInfo.Value;
            }
        }

        throw new UnitNotFoundException();
    }

    private static TUnit GetUnitFromInfoIgnoreCase<TUnit>(QuantityInfo<TUnit> quantityInfo, ReadOnlySpan<char> unitNamePart) where TUnit : struct, Enum
    {
        IReadOnlyList<UnitInfo<TUnit>> unitInfos = quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo<TUnit> unitInfo = unitInfos[i];
            if (unitNamePart.Equals(unitInfo.Name, StringComparison.OrdinalIgnoreCase))
            {
                return unitInfo.Value;
            }
        }

        throw new UnitNotFoundException();
    }
}
#endif
