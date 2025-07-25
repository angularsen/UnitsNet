using System;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class QuantityFromUnitAbbreviationBenchmarks
{
    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
    private readonly Random _random = new(42);
    private string[] _massUnits;
    private string[] _pressureUnits;
    private string[] _volumeFlowUnits;
    private string[] _volumeUnits = [];

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup(Target = nameof(FromMassUnitAbbreviation))]
    public void PrepareMassUnits()
    {
        // can't have "mg" or "g" (see Acceleration.StandardGravity) and who knows what more...
        _massUnits = _random.GetItems(["kg", "lbs", "Mlbs"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeUnitAbbreviation))]
    public void PrepareVolumeUnits()
    {
        _volumeUnits = _random.GetItems(["ml", "l", "cm³", "m³"], NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromPressureUnitAbbreviation))]
    public void PreparePressureUnits()
    {
        _pressureUnits = _random.GetRandomAbbreviations<PressureUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeFlowUnitAbbreviation))]
    public void PrepareVolumeFlowUnits()
    {
        // can't have "bpm" (see Frequency)
        _volumeFlowUnits =
            _random.GetItems(
                UnitsNetSetup.Default.UnitAbbreviations.GetAllUnitAbbreviationsForQuantity(typeof(VolumeFlowUnit)).Where(x => x != "bpm").ToArray(),
                NbAbbreviations);
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
