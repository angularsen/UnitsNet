// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class TryParseInvalidUnitBenchmarks
{
    private const int NbAbbreviations = 1000;

    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
    private readonly Random _random = new(42);
    private string[] _invalidUnits = [];

    [GlobalSetup]
    public void Setup()
    {
        _invalidUnits = Enumerable.Range(0, NbAbbreviations).Select(_ => GenerateInvalidUnit()).ToArray();
        // initializes the QuantityInfoLookup and the abbreviations cache
        Mass.TryParseUnit("_invalid", Culture, out _);
        Volume.TryParseUnit("_invalid", Culture, out _);
        Density.TryParseUnit("_invalid", Culture, out _);
        Pressure.TryParseUnit("_invalid", Culture, out _);
        VolumeFlow.TryParseUnit("_invalid", Culture, out _);
    }

    private string GenerateInvalidUnit()
    {
        var sb = new StringBuilder();
        var length = _random.Next(1, 10);
        for (var i = 0; i < length; i++)
        {
            sb.Append((char)_random.Next('a', 'z'));
        }

        return sb.ToString();
    }


    [Benchmark(Baseline = true)]
    public bool TryParseMassUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Mass.TryParseUnit(unitToParse, Culture, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool TryParseVolumeUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Volume.TryParseUnit(unitToParse, Culture, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool TryParseDensityUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Density.TryParseUnit(unitToParse, Culture, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool TryParsePressureUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Pressure.TryParseUnit(unitToParse, Culture, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool TryParseVolumeFlowUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = VolumeFlow.TryParseUnit(unitToParse, Culture, out _);
        }

        return success;
    }
}
