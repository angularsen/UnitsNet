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
public class QuantityFromStringBenchmarks
{
    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
    private static readonly string ValueToParse = 123.456.ToString(Culture);

    private readonly Random _random = new(42);
    private string[] _quantitiesToParse;

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup(Target = nameof(FromMassString))]
    public void PrepareMassStrings()
    {
        // can't have "mg" or "g" (see Acceleration.StandardGravity) and who knows what more...
        _quantitiesToParse = _random.GetItems(["kg", "lbs", "Mlbs"], NbAbbreviations).Select(abbreviation => $"{ValueToParse} {abbreviation}").ToArray();
    }

    [GlobalSetup(Target = nameof(FromVolumeString))]
    public void PrepareVolumeStrings()
    {
        _quantitiesToParse = _random.GetItems(["ml", "l", "cm³", "m³"], NbAbbreviations).Select(abbreviation => $"{ValueToParse} {abbreviation}").ToArray();;
    }

    [GlobalSetup(Target = nameof(FromPressureString))]
    public void PreparePressureStrings()
    {
        _quantitiesToParse = _random.GetRandomAbbreviations<PressureUnit>(UnitsNetSetup.Default.UnitAbbreviations, NbAbbreviations).Select(abbreviation => $"{ValueToParse} {abbreviation}").ToArray();;
    }

    [GlobalSetup(Target = nameof(FromVolumeFlowString))]
    public void PrepareVolumeFlowStrings()
    {
        // can't have "bpm" (see Frequency)
        _quantitiesToParse =
            _random.GetItems(
                UnitsNetSetup.Default.UnitAbbreviations.GetAllUnitAbbreviationsForQuantity(typeof(VolumeFlowUnit)).Where(x => x != "bpm").ToArray(),
                NbAbbreviations).Select(abbreviation => $"{ValueToParse} {abbreviation}").ToArray();
    }

    [Benchmark(Baseline = true)]
    public IQuantity FromMassString()
    {
        IQuantity quantity = null;
        foreach (var quantityString in _quantitiesToParse)
        {
            quantity = Quantity.Parse(Culture, typeof(Mass), quantityString);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeString()
    {
        IQuantity quantity = null;
        foreach (var quantityString in _quantitiesToParse)
        {
            quantity = Quantity.Parse(Culture, typeof(Volume), quantityString);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromPressureString()
    {
        IQuantity quantity = null;
        foreach (var quantityString in _quantitiesToParse)
        {
            quantity = Quantity.Parse(Culture, typeof(Pressure), quantityString);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeFlowString()
    {
        IQuantity quantity = null;
        foreach (var quantityString in _quantitiesToParse)
        {
            quantity = Quantity.Parse(Culture, typeof(VolumeFlow), quantityString);
        }

        return quantity;
    }
}
