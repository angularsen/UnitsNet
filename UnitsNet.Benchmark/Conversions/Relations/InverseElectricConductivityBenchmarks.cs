using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob]
// [DryJob]
public class InverseElectricConductivityBenchmarks
{
    private static readonly double Value = 123.456;
    
    [ParamsAllValues]
    public ElectricConductivityUnit Unit { get; set; }
    private ElectricConductivity TestQuantity => new(Value, Unit);
    
    
    [Benchmark(Baseline = true)]
    public ElectricResistivity Inverse()
    {
        return TestQuantity.Inverse();
    }
}
