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
public class AddTwoVolumesWithSameUnitsBenchmarks
{
    private static readonly QuantityValue LeftValue = 1.23;
    private static readonly QuantityValue RightValue = 4.56;

    private (Volume left, Volume right)[] _operands;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }
    
    [Params(VolumeUnit.CubicMeter, VolumeUnit.Liter, VolumeUnit.Milliliter)]
    public VolumeUnit Unit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        
        _operands = Enumerable.Range(0, NbOperations).Select(_ => (Volume.From(LeftValue, Unit), Volume.From(RightValue, Unit))).ToArray();
    }

    [Benchmark(Baseline = true)]
    public Volume AddTwoVolumes()
    {
        Volume sum = default;
        foreach ((Volume left, Volume right) in _operands)
        {
            sum = left + right; // intentionally not summing the results
        }

        return sum;
    }
}
