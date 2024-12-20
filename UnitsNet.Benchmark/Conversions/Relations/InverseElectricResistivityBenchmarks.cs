using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob]
public class InverseElectricResistivityBenchmarks
{
    private static readonly double Value = 123.456;
    
    [ParamsAllValues]
    public ElectricResistivityUnit Unit { get; set; }
    private ElectricResistivity TestQuantity => new(Value, Unit);
    
    
    [Benchmark(Baseline = true)]
    public ElectricConductivity Inverse()
    {
        return TestQuantity.Inverse();
    }
}
