// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Enums;

[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class GetBoxedEnumValuesBenchmarks
{
    private readonly Dictionary<Type, QuantityInfo> _quantityInfos = Quantity.Infos.ToDictionary(x => x.UnitType);

    [Benchmark(Baseline = true)]
    public int GetEnumValues()
    {
        var total = 0;
        foreach (Type unitType in _quantityInfos.Keys)
        {
            foreach (Enum unitValue in Enum.GetValues(unitType).Cast<Enum>())
            {
                var unitKey = (UnitKey)unitValue;
                total += unitKey.UnitEnumValue;
            }
        }

        return total;
    }

    [Benchmark(Baseline = false)]
    public int GetEnumValuesWithDictionary()
    {
        var total = 0;
        foreach (Type unitType in _quantityInfos.Keys)
        {
            foreach (UnitInfo unitInfo in _quantityInfos[unitType].UnitInfos)
            {
                total += unitInfo.UnitKey.UnitEnumValue;
            }
        }

        return total;
    }
}
