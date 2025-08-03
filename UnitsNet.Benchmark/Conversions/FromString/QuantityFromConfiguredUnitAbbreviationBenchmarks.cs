// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityFromConfiguredUnitAbbreviationBenchmarks
{
    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
    private readonly Random _random = new(42);
    private string[] _densityUnits;
    private string[] _massUnits;
    private string[] _pressureUnits;
    private string[] _volumeFlowUnits;
    private string[] _volumeUnits = [];

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithQuantities([Mass.Info, Volume.Info, Density.Info, Pressure.Info, VolumeFlow.Info]));
    }

    [GlobalSetup(Target = nameof(FromMassUnitAbbreviation))]
    public void PrepareMassUnits()
    {
        PrepareQuantities();
        _massUnits = _random.GetItems(["mg", "g", "kg", "lbs", "Mlbs"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeUnitAbbreviation))]
    public void PrepareVolumeUnits()
    {
        PrepareQuantities();
        _volumeUnits = _random.GetItems(["ml", "l", "cm³", "m³"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromDensityUnitAbbreviation))]
    public void PrepareDensityUnits()
    {
        PrepareQuantities();
        _densityUnits = _random.GetRandomAbbreviations<DensityUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromPressureUnitAbbreviation))]
    public void PreparePressureUnits()
    {
        PrepareQuantities();
        _pressureUnits = _random.GetRandomAbbreviations<PressureUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeFlowUnitAbbreviation))]
    public void PrepareVolumeFlowUnits()
    {
        PrepareQuantities();
        _volumeFlowUnits = _random.GetRandomAbbreviations<VolumeFlowUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [Benchmark(Baseline = true)]
    public IQuantity FromMassUnitAbbreviation()
    {
        IQuantity quantity = null;
        foreach (var unitToParse in _massUnits)
        {
            quantity = Quantity.FromUnitAbbreviation(Culture, 1, unitToParse);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeUnitAbbreviation()
    {
        IQuantity quantity = null;
        foreach (var unitToParse in _volumeUnits)
        {
            quantity = Quantity.FromUnitAbbreviation(Culture, 1, unitToParse);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromDensityUnitAbbreviation()
    {
        IQuantity quantity = null;
        foreach (var unitToParse in _densityUnits)
        {
            quantity = Quantity.FromUnitAbbreviation(Culture, 1, unitToParse);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromPressureUnitAbbreviation()
    {
        IQuantity quantity = null;
        foreach (var unitToParse in _pressureUnits)
        {
            quantity = Quantity.FromUnitAbbreviation(Culture, 1, unitToParse);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeFlowUnitAbbreviation()
    {
        IQuantity quantity = null;
        foreach (var unitToParse in _volumeFlowUnits)
        {
            quantity = Quantity.FromUnitAbbreviation(Culture, 1, unitToParse);
        }

        return quantity;
    }
}
