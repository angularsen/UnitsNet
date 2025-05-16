// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Initializations;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class UnitAbbreviationsCacheInitializationBenchmarks
{
    [GlobalSetup]
    public void InitializeUnitsNetSetup()
    {
        var quantities = Quantity.Infos.Count;
    }

    [Benchmark(Baseline = true)]
    public string Default()
    {
        var cache = UnitAbbreviationsCache.CreateDefault();
        return cache.GetDefaultAbbreviation(MassUnit.Gram);
    }

    [Benchmark]
    public string EmptyWithCustomMapping()
    {
        var cache = new UnitAbbreviationsCache();
        cache.MapUnitToDefaultAbbreviation(MassUnit.Gram, "zz");
        return cache.GetDefaultAbbreviation(MassUnit.Gram);
    }

    [Benchmark]
    public string WithSpecificQuantity()
    {
        var cache = new UnitAbbreviationsCache([Mass.Info]);
        return cache.GetDefaultAbbreviation(MassUnit.Gram);
    }

    [Benchmark]
    public string WithSpecificQuantityAndCustomMapping()
    {
        var cache = new UnitAbbreviationsCache([Mass.Info]);
        cache.MapUnitToDefaultAbbreviation(MassUnit.Gram, "zz");
        return cache.GetDefaultAbbreviation(MassUnit.Gram);
    }
}
