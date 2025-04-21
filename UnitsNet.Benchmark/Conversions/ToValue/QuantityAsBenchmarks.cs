// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToValue;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class QuantityAsBenchmarks
{
    private readonly Random _random = new Random(42);
    private static readonly double Value = 123.456;

    [Params(1000)]
    public int NbConversions { get; set; }

    private (Mass Quantity, MassUnit Unit)[] _massConversions = [];
    private (Volume Quantity, VolumeUnit Unit)[] _volumeConversions = [];
    private (Density Quantity, DensityUnit Unit)[] _densityConversions = [];
    private (Pressure Quantity, PressureUnit Unit)[] _pressureConversions = [];
    private (VolumeFlow Quantity, VolumeFlowUnit Unit)[] _volumeFlowConversions = [];


    [GlobalSetup(Target = nameof(MassAs))]
    public void PrepareMassConversionsToTest()
    {
        _massConversions = _random.GetRandomConversions<Mass, MassUnit>(Value, Mass.Units.ToArray(), NbConversions);
    }

    [GlobalSetup(Target = nameof(VolumeAs))]
    public void PrepareVolumeConversionsToTest()
    {
        _volumeConversions = _random.GetRandomConversions<Volume, VolumeUnit>(Value, Volume.Units.ToArray(), NbConversions);
    }

    [GlobalSetup(Target = nameof(DensityAs))]
    public void PrepareDensityConversionsToTest()
    {
        _densityConversions = _random.GetRandomConversions<Density, DensityUnit>(Value, Density.Units.ToArray(), NbConversions);
    }
    
    [GlobalSetup(Target = nameof(PressureAs))]
    public void PreparePressureConversionsToTest()
    {
        _pressureConversions = _random.GetRandomConversions<Pressure, PressureUnit>(Value, Pressure.Units.ToArray(), NbConversions);
    }
    
    [GlobalSetup(Target = nameof(VolumeFlowAs))]
    public void PrepareVolumeFlowConversionsToTest()
    {
        _volumeFlowConversions = _random.GetRandomConversions<VolumeFlow, VolumeFlowUnit>(Value, VolumeFlow.Units.ToArray(), NbConversions);
    }

    [Benchmark(Baseline = true)]
    public void MassAs()
    {
        foreach (var conversion in _massConversions)
        {
            conversion.Quantity.As(conversion.Unit);
        }
    }

    [Benchmark]
    public void VolumeAs()
    {
        foreach (var conversion in _volumeConversions)
        {
            conversion.Quantity.As(conversion.Unit);
        }
    }

    [Benchmark]
    public void DensityAs()
    {
        foreach (var conversion in _densityConversions)
        {
            conversion.Quantity.As(conversion.Unit);
        }
    }

    [Benchmark]
    public void PressureAs()
    {
        foreach (var conversion in _pressureConversions)
        {
            conversion.Quantity.As(conversion.Unit);
        }
    }

    [Benchmark]
    public void VolumeFlowAs()
    {
        foreach (var conversion in _volumeFlowConversions)
        {
            conversion.Quantity.As(conversion.Unit);
        }
    }
}
