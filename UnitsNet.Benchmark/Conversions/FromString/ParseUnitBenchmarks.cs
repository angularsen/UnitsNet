using System;
using System.Globalization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

// [MemoryDiagnoser]
// [SimpleJob(RuntimeMoniker.Net48)]
// [SimpleJob(RuntimeMoniker.Net80)]
// public class IsTerminatingValueBenchmarks
// {
//     private QuantityValue Value = QuantityValue.FromTerms(1, 350);
//     // private QuantityValue Value = QuantityValue.FromTerms(1, 350 * 12345);
//     // private QuantityValue Value = QuantityValue.FromPowerOfTen(1, 350 * 12345, -20);
//
//     [Benchmark(Baseline = true)]
//     public bool HasTerminatingDecimal()
//     {
//         return QuantityValue.HasFiniteDecimalExpansion(Value);
//     }
//     [Benchmark(Baseline = false)]
//     public bool HasTerminatingDecimalBitwise()
//     {
//         return Value.ToString("G", CultureInfo.InvariantCulture).Length < 16;
//     }
// }

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class ParseUnitBenchmarks
{
    private const int NbAbbreviations = 1000;

    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
    private readonly Random _random = new(42);
    private string[] _densityUnits;
    private string[] _massUnits;
    private string[] _pressureUnits;
    private string[] _volumeFlowUnits;
    private string[] _volumeUnits = [];

    [GlobalSetup(Target = nameof(ParseMassUnit))]
    public void PrepareMassUnits()
    {
        _massUnits = _random.GetItems(["mg", "g", "kg", "lbs", "Mlbs"], NbAbbreviations);
        // initializes the QuantityInfoLookup and the abbreviations cache
        Mass.TryParseUnit("_invalid", Culture, out _);
    }

    [GlobalSetup(Target = nameof(ParseVolumeUnit))]
    public void PrepareVolumeUnits()
    {
        _volumeUnits = _random.GetItems(["ml", "l", "L", "cm³", "m³"], NbAbbreviations);
        // initializes the QuantityInfoLookup and the abbreviations cache
        Volume.TryParseUnit("_invalid", Culture, out _);
    }

    [GlobalSetup(Target = nameof(ParseDensityUnit))]
    public void PrepareDensityUnits()
    {
        _densityUnits = _random.GetRandomAbbreviations<DensityUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
        // initializes the QuantityInfoLookup and the abbreviations cache
        Density.TryParseUnit("_invalid", Culture, out _);
    }

    [GlobalSetup(Target = nameof(ParsePressureUnit))]
    public void PreparePressureUnits()
    {
        _pressureUnits = _random.GetRandomAbbreviations<PressureUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
        // initializes the QuantityInfoLookup and the abbreviations cache
        Pressure.TryParseUnit("_invalid", Culture, out _);
    }

    [GlobalSetup(Target = nameof(ParseVolumeFlowUnit))]
    public void PrepareVolumeFlowUnits()
    {
        _volumeFlowUnits = _random.GetRandomAbbreviations<VolumeFlowUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
        VolumeFlow.ParseUnit(_volumeFlowUnits[0], Culture);
    }

    [Benchmark(Baseline = true)]
    public MassUnit ParseMassUnit()
    {
        MassUnit unit = default;
        foreach (var unitToParse in _massUnits)
        {
            unit = Mass.ParseUnit(unitToParse, Culture);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public VolumeUnit ParseVolumeUnit()
    {
        VolumeUnit unit = default;
        foreach (var unitToParse in _volumeUnits)
        {
            unit = Volume.ParseUnit(unitToParse, Culture);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public DensityUnit ParseDensityUnit()
    {
        DensityUnit unit = default;
        foreach (var unitToParse in _densityUnits)
        {
            unit = Density.ParseUnit(unitToParse, Culture);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public PressureUnit ParsePressureUnit()
    {
        PressureUnit unit = default;
        foreach (var unitToParse in _pressureUnits)
        {
            unit = Pressure.ParseUnit(unitToParse, Culture);
        }

        return unit;
    }

    [Benchmark(Baseline = false)]
    public VolumeFlowUnit ParseVolumeFlowUnit()
    {
        VolumeFlowUnit unit = default;
        foreach (var unitToParse in _volumeFlowUnits)
        {
            unit = VolumeFlow.ParseUnit(unitToParse, Culture);
        }

        return unit;
    }
}
