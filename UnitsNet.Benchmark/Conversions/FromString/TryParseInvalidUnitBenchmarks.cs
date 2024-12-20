// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class TryParseInvalidUnitBenchmarks
{
    private readonly Random _random = new(42);
    private string[] _invalidUnits = [];

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _invalidUnits = Enumerable.Range(0, NbAbbreviations).Select(_ => GenerateInvalidUnit()).ToArray();
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
            success = Mass.TryParseUnit(unitToParse, out MassUnit _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool TryParseVolumeUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Volume.TryParseUnit(unitToParse, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool ParseDensityUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Density.TryParseUnit(unitToParse, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool ParsePressureUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = Pressure.TryParseUnit(unitToParse, out _);
        }

        return success;
    }

    [Benchmark(Baseline = false)]
    public bool ParseVolumeFlowUnit()
    {
        var success = true;
        foreach (var unitToParse in _invalidUnits)
        {
            success = VolumeFlow.TryParseUnit(unitToParse, out _);
        }

        return success;
    }
}
