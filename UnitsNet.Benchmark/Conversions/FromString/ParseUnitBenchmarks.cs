using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class ParseUnitBenchmarks
{
    private readonly Random _random = new(42);
    private string[] _densityUnits;
    private string[] _massUnits;
    private string[] _pressureUnits;
    private string[] _volumeFlowUnits;
    private string[] _volumeUnits = [];

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup(Target = nameof(ParseMassUnit))]
    public void PrepareMassUnits()
    {
        _massUnits = _random.GetItems(["mg", "g", "kg", "lbs", "Mlbs"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(ParseVolumeUnit))]
    public void PrepareVolumeUnits()
    {
        _volumeUnits = _random.GetItems(["ml", "l", "L", "cm³", "m³"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(ParseDensityUnit))]
    public void PrepareDensityUnits()
    {
        _densityUnits = _random.GetRandomAbbreviations<DensityUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(ParsePressureUnit))]
    public void PreparePressureUnits()
    {
        _pressureUnits = _random.GetRandomAbbreviations<PressureUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(ParseVolumeFlowUnit))]
    public void PrepareVolumeFlowUnits()
    {
        _volumeFlowUnits = _random.GetRandomAbbreviations<VolumeFlowUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [Benchmark(Baseline = true)]
    public MassUnit ParseMassUnit()
    {
        MassUnit unit = default;
        foreach (var unitToParse in _massUnits)
        {
            unit = Mass.ParseUnit(unitToParse);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public VolumeUnit ParseVolumeUnit()
    {
        VolumeUnit unit = default;
        foreach (var unitToParse in _volumeUnits)
        {
            unit = Volume.ParseUnit(unitToParse);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public DensityUnit ParseDensityUnit()
    {
        DensityUnit unit = default;
        foreach (var unitToParse in _densityUnits)
        {
            unit = Density.ParseUnit(unitToParse);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public PressureUnit ParsePressureUnit()
    {
        PressureUnit unit = default;
        foreach (var unitToParse in _pressureUnits)
        {
            unit = Pressure.ParseUnit(unitToParse);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public VolumeFlowUnit ParseVolumeFlowUnit()
    {
        VolumeFlowUnit unit = default;
        foreach (var unitToParse in _volumeFlowUnits)
        {
            unit = VolumeFlow.ParseUnit(unitToParse);
        }

        return unit;
    }
}
