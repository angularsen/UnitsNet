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
public class SumOfMassesWithRandomUnitsBenchmarks
{
    private static readonly QuantityValue Value = 1.23;

    private readonly Random _random = new(42);
    private Mass[] _quantities;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(true)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        Quantity.From(Value, Mass.BaseUnit); // TODO we need a better way to "disable" the lazy loading of the _quantitiesByUnitType (QuantityInfoLookup)
        
        _quantities = _random.GetRandomQuantities<Mass, MassUnit>(Value, Mass.Units.ToArray(), NbOperations).ToArray();
    }
    
    [Benchmark(Baseline = true)]
    public Mass SumOfMasses()
    {
        return _quantities.Sum();
    }
    
// #if NET
//     [Benchmark(Baseline = false)]
//     public Mass SumOfMassesWithGenericExtension()
//     {
//         return UnitsNet.GenericMath.GenericMathExtensions.Sum(_quantities);
//     }
// #endif

    // [Benchmark(Baseline = false)]
    // public Mass SumOfMassesWithBaseUnit()
    // {
    //     return _quantities.Sum(Mass.BaseUnit);
    // }
    //
    // [Benchmark(Baseline = false)]
    // public Mass SumOfMassesWithNonBaseUnit()
    // {
    //     return _quantities.Sum(MassUnit.Milligram);
    // }
}
