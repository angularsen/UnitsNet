// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class SumOfVolumesWithRandomUnitsWithIteratorBenchmarks
{
    private static readonly double Value = 1.23;

    private readonly Random _random = new(41);
    private Volume[] _quantities;

    [Params(10, 100, 1000)]
    public int NbOperations { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _quantities = _random.GetRandomQuantities<Volume, VolumeUnit>(Value, Volume.Units, NbOperations).ToArray();
        Quantity.From(Value, Volume.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)
        Console.Out.WriteLine("Quantities prepared: starting unit = {0}", _quantities[0].Unit);
    }
    
    [Benchmark(Baseline = true)]
    public Volume SumOfVolumes()
    {
#if NET
        return UnitsNet.GenericMath.GenericMathExtensions.Sum(_quantities);
#else
        throw new NotImplementedException();
#endif
    }
}
