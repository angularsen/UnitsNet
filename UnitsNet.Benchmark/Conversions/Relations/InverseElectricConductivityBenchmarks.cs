using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob]
public class InverseElectricConductivityBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [ParamsAllValues]
    public ElectricConductivityUnit Unit { get; set; }

    private ElectricConductivity TestQuantity
    {
        get => new(Value, Unit);
    }

    [GlobalSetup]
    public void Setup()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
    }

    [Benchmark(Baseline = true)]
    public ElectricResistivity Inverse()
    {
        return TestQuantity.Inverse();
    }
}
