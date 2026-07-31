using System;
using System.Collections.Generic;
using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace UnitsNet.Benchmark.Operators.Powers;

[MemoryDiagnoser]
// [ShortRunJob]
// [DryJob]
public class SqrtBenchmarks {
    public static IEnumerable<QuantityValue> FractionsToTest => [
        2,
        3,
        QuantityValue.FromTerms(4, 6),
        12.345m,
        9187.45m,
        1024
    ];

    [Params(15, 30, 45, 90)]
    public int Accuracy { get; set; }
    
    [ParamsSource(nameof(FractionsToTest))]
    public QuantityValue Fraction { get; set; }


    [Benchmark(Baseline = true)]
    public QuantityValue Sqrt() {
        return QuantityValue.Sqrt(Accuracy);
    }
}

