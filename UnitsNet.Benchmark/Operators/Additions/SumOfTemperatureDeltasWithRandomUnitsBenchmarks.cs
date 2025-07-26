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
[SimpleJob(RuntimeMoniker.Net80)]
public class SumOfTemperatureDeltasWithRandomUnitsBenchmarks
{
    private static readonly QuantityValue Value = 1.23;

    private readonly Random _random = new(42);
    private TemperatureDelta[] _quantities;

    [Params(10, 1000)]
    public int NbOperations { get; set; }

    [Params(true)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        
        _quantities = _random.GetRandomQuantities<TemperatureDelta, TemperatureDeltaUnit>(Value, TemperatureDelta.Units.ToArray(), NbOperations).ToArray();
    }

    [Benchmark(Baseline = true)]
    public TemperatureDelta SumOfDeltas()
    {
#if NET
        return UnitsNet.GenericMath.GenericMathExtensions.Sum(_quantities);
#else
        TemperatureDelta sum = TemperatureDelta.Zero;
        foreach (TemperatureDelta quantity in _quantities)
        {
            sum = quantity + sum;
        }

        return sum;
#endif
    }

    [Benchmark(Baseline = false)]
    public TemperatureDelta SumOfVolumesInBaseUnit()
    {
        return _quantities.Sum(TemperatureDelta.BaseUnit);
    }

    [Benchmark(Baseline = false)]
    public TemperatureDelta SumOfTemperatureDeltasInDegreeFahrenheit()
    {
        return _quantities.Sum(TemperatureDeltaUnit.DegreeFahrenheit);
    }
}
