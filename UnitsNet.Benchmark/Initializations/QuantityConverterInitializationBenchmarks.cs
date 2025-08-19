// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Initializations;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityConverterInitializationBenchmarks
{
    private readonly UnitParser _unitParser = UnitParser.Default;

    [Params(ConversionCachingMode.BaseOnly, ConversionCachingMode.All)]
    public ConversionCachingMode ConversionCachingMode { get; set; }

    [Params(true, false)]
    public bool ReduceConstants { get; set; }

    [Benchmark(Baseline = false)]
    public UnitConverter CreateDynamic()
    {
        return UnitConverter.Create(_unitParser, new QuantityConverterBuildOptions(false, ConversionCachingMode, ReduceConstants));
    }

    [Benchmark(Baseline = false)]
    public UnitConverter CreateFrozen()
    {
        return UnitConverter.Create(_unitParser, new QuantityConverterBuildOptions(true, ConversionCachingMode, ReduceConstants));
    }
}
