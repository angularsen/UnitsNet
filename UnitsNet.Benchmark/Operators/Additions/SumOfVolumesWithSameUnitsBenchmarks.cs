// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class SumOfVolumesWithSameUnitsBenchmarks
{
    private static readonly double Value = 1.23;
    
    private Volume[] _quantities;

    [Params(10, 1000)]
    public int NbOperations { get; set; }

    [Params(VolumeUnit.CubicMeter, VolumeUnit.Liter, VolumeUnit.Milliliter)]
    public VolumeUnit Unit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        _quantities = Enumerable.Range(0, NbOperations).Select(_ => Volume.From(Value, Unit)).ToArray();
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
