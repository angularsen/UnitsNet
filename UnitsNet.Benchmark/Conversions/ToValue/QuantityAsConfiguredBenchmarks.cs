// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityAsConfiguredBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    private readonly Random _random = new(42);

    private (Mass Quantity, MassUnit Unit)[] _massConversions = [];
    private (VolumeFlow Quantity, VolumeFlowUnit Unit)[] _volumeFlowConversions = [];

    [Params(1000)]
    public int NbConversions { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [ParamsAllValues]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(true, false)]
    public bool CacheSpecific { get; set; }

    [GlobalSetup]
    public void ConfigureCaching()
    {
        var converterOptions = new QuantityConverterBuildOptions(Frozen, CachingMode);
        if (CacheSpecific)
        {
            converterOptions = converterOptions
                .WithCustomCachingOptions<Mass>(new ConversionCacheOptions())
                .WithCustomCachingOptions<VolumeFlow>(new ConversionCacheOptions());
        }

        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(converterOptions));
    }

    [GlobalSetup(Target = nameof(MassAs))]
    public void PrepareMassConversionsToTest()
    {
        ConfigureCaching();
        _massConversions = _random.GetRandomConversions<Mass, MassUnit>(Value, Mass.Units, NbConversions);
    }

    [GlobalSetup(Target = nameof(VolumeFlowAs))]
    public void PrepareVolumeFlowConversionsToTest()
    {
        ConfigureCaching();
        _volumeFlowConversions = _random.GetRandomConversions<VolumeFlow, VolumeFlowUnit>(Value, VolumeFlow.Units, NbConversions);
    }

    [Benchmark(Baseline = true)]
    public void MassAs()
    {
        foreach ((Mass quantity, MassUnit unit) in _massConversions)
        {
            quantity.As(unit);
        }
    }

    [Benchmark]
    public void VolumeFlowAs()
    {
        foreach ((VolumeFlow quantity, VolumeFlowUnit unit) in _volumeFlowConversions)
        {
            quantity.As(unit);
        }
    }
}
