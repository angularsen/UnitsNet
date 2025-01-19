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
public class SumOfVolumesWithSimilarSIUnitsBenchmarks
{
    private static readonly double Value = 1.23;

    private readonly Random _random = new(42);
    private Volume[] _quantities;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(VolumeUnit.Milliliter, VolumeUnit.Liter)]
    public VolumeUnit StartingUnit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        Quantity.From(Value, Volume.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)

        _quantities = _random.GetRandomQuantities<Volume, VolumeUnit>(Value, [VolumeUnit.Microliter, VolumeUnit.Milliliter, VolumeUnit.Liter], NbOperations - 1)
            .Prepend(Volume.From(Value, StartingUnit)).ToArray();
        Volume firstQuantity = _quantities[0];
        Console.Out.WriteLine("Quantities prepared: starting unit = {0}", firstQuantity.Unit);
    }
    
    [Benchmark(Baseline = true)]
    public Volume SumOfVolumes()
    {
#if NET
        return UnitsNet.GenericMath.GenericMathExtensions.Sum(_quantities);
#else
        Volume sum = Volume.Zero;
        foreach (var quantity in _quantities)
        {
            sum = quantity + sum;
        }

        return sum;
#endif
    }

    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInBaseUnit()
    {
        return _quantities.Sum(Volume.BaseUnit);
    }

    [Benchmark(Baseline = false)]
    public Volume SumOfVolumesInMilliliter()
    {
        return _quantities.Sum(VolumeUnit.Milliliter);
    }
}
