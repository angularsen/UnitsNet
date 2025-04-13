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
public class AddTwoMassesWithSameUnitsBenchmarks
{
    private static readonly QuantityValue LeftValue = 1.23;
    private static readonly QuantityValue RightValue = 4.56;

    private (Mass left, Mass right)[] _operands;

    [Params(1000)]
    public int NbOperations { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(MassUnit.Kilogram, MassUnit.Gram, MassUnit.Milligram)]
    public MassUnit Unit { get; set; }

    [GlobalSetup]
    public void PrepareQuantities()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        
        _operands = Enumerable.Range(0, NbOperations).Select(_ => (Mass.From(LeftValue, Unit), Mass.From(RightValue, Unit))).ToArray();
    }

    [Benchmark(Baseline = true)]
    public Mass AddTwoMasses()
    {
        Mass sum = default;
        foreach ((Mass left, Mass right) in _operands)
        {
            sum = left + right; // intentionally not summing the results
        }

        return sum;
    }
}
