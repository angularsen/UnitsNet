// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class QuantityAsBenchmarks
{
    private static readonly QuantityValue Value = 123.456;
    private readonly Random _random = new(42);

    private (Mass Quantity, MassUnit Unit)[] _massConversions = [];
    private (Volume Quantity, VolumeUnit Unit)[] _volumeConversions = [];
    private (Density Quantity, DensityUnit Unit)[] _densityConversions = [];
    private (Pressure Quantity, PressureUnit Unit)[] _pressureConversions = [];
    private (VolumeFlow Quantity, VolumeFlowUnit Unit)[] _volumeFlowConversions = [];

    [Params(1000)]
    public int NbConversions { get; set; }

    // [Params(false)]
    [Params(true, false)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void ConfigureCaching()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
    }

    [GlobalSetup(Target = nameof(MassAs))]
    public void PrepareMassConversionsToTest()
    {
        ConfigureCaching();
        // _massConversions = _random.GetRandomConversions<Mass, MassUnit>(Value, [MassUnit.Milligram, MassUnit.Microgram], NbConversions);
        _massConversions = _random.GetRandomConversions<Mass, MassUnit>(Value, Mass.Units, NbConversions);
    }

    [GlobalSetup(Target = nameof(VolumeAs))]
    public void PrepareVolumeConversionsToTest()
    {
        ConfigureCaching();
        _volumeConversions = _random.GetRandomConversions<Volume, VolumeUnit>(Value, Volume.Units, NbConversions);
    }

    [GlobalSetup(Target = nameof(DensityAs))]
    public void PrepareDensityConversionsToTest()
    {
        ConfigureCaching();
        _densityConversions = _random.GetRandomConversions<Density, DensityUnit>(Value, Density.Units, NbConversions);
    }

    [GlobalSetup(Target = nameof(PressureAs))]
    public void PreparePressureConversionsToTest()
    {
        ConfigureCaching();
        _pressureConversions = _random.GetRandomConversions<Pressure, PressureUnit>(Value, Pressure.Units, NbConversions);
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
    public void VolumeAs()
    {
        foreach ((Volume quantity, VolumeUnit unit) in _volumeConversions)
        {
            quantity.As(unit);
        }
    }

    [Benchmark]
    public void DensityAs()
    {
        foreach ((Density quantity, DensityUnit unit) in _densityConversions)
        {
            quantity.As(unit);
        }
    }

    [Benchmark]
    public void PressureAs()
    {
        foreach ((Pressure quantity, PressureUnit unit) in _pressureConversions)
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
