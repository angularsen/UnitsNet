using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

// [ShortRunJob(RuntimeMoniker.Net48)]
// [ShortRunJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[ShortRunJob]
public class InverseElectricResistivityBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [ParamsAllValues]
    public ElectricResistivityUnit Unit { get; set; }

    private ElectricResistivity TestQuantity
    {
        get => new(Value, Unit);
    }

    [GlobalSetup]
    public void Setup()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
    }

    [Benchmark(Baseline = true)]
    public ElectricConductivity Inverse()
    {
        return TestQuantity.Inverse();
    }
}
