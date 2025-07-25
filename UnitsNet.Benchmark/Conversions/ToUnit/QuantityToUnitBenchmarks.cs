// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToUnit;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityToUnitBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    private readonly Random _random = new(42);

    private (Mass Quantity, MassUnit Unit)[] _massConversions = [];
    private (VolumeFlow Quantity, VolumeFlowUnit Unit)[] _volumeFlowConversions = [];

    [Params(1000)]
    public int NbConversions { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void ConfigureCaching()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
    }

    [GlobalSetup(Target = nameof(MassToUnit))]
    public void PrepareMassConversionsToTest()
    {
        ConfigureCaching();
        _massConversions = _random.GetRandomConversions<Mass, MassUnit>(Value, Mass.Units, NbConversions);
    }

    [GlobalSetup(Target = nameof(VolumeFlowToUnit))]
    public void PrepareVolumeFlowConversionsToTest()
    {
        ConfigureCaching();
        _volumeFlowConversions = _random.GetRandomConversions<VolumeFlow, VolumeFlowUnit>(Value, VolumeFlow.Units, NbConversions);
    }

    [Benchmark(Baseline = true)]
    public void MassToUnit()
    {
        foreach ((Mass quantity, MassUnit unit) in _massConversions)
        {
            quantity.ToUnit(unit);
        }
    }

    [Benchmark]
    public void VolumeFlowToUnit()
    {
        foreach ((VolumeFlow quantity, VolumeFlowUnit unit) in _volumeFlowConversions)
        {
            quantity.ToUnit(unit);
        }
    }
}
