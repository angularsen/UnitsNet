// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class SumOfVolumesWithSimilarImperialUnitsBenchmarks
{
    private static readonly double Value = 1.23;

    private readonly Random _random = new(42);
    private Volume[] _quantities;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(VolumeUnit.ImperialOunce, VolumeUnit.ImperialGallon)]
    public VolumeUnit StartingUnit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        Quantity.From(Value, Volume.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)

        _quantities = _random.GetRandomQuantities<Volume, VolumeUnit>(Value, [VolumeUnit.ImperialOunce, VolumeUnit.ImperialQuart, VolumeUnit.ImperialGallon], NbOperations - 1)
            .Prepend(Volume.From(Value, StartingUnit)).ToArray();
        Volume firstQuantity = _quantities[0];
        Console.Out.WriteLine("Quantities prepared: starting unit = {0}", firstQuantity.Unit);
    }
    
    [Benchmark(Baseline = true)]
    public Volume SumOfVolumes()
    {
        return _quantities.Sum();
    }

    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInBaseUnit()
    {
        return _quantities.Sum(Volume.BaseUnit);
    }

    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInStartingUnit()
    {
        return _quantities.Sum(StartingUnit);
    }
}
