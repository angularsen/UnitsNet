using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Operators.Additions;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class AddTwoVolumesWithRandomUnitsBenchmarks
{
    private static readonly QuantityValue LeftValue = 1.23;
    private static readonly QuantityValue RightValue = 4.56;

    private readonly Random _random = new(42);
    private (Volume left, Volume right)[] _operands;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [ParamsAllValues]
    public ConversionCachingMode CachingMode { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));

        _operands = _random.GetRandomQuantities<Volume, VolumeUnit>(LeftValue, Volume.Units.ToArray(), NbOperations)
            .Zip(_random.GetRandomQuantities<Volume, VolumeUnit>(RightValue, Volume.Units.ToArray(), NbOperations),
                (left, right) => (left, right))
            .ToArray();
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
