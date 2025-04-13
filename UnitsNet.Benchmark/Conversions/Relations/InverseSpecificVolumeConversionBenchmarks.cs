using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.Relations;

[MemoryDiagnoser]
[ShortRunJob]
public class InverseSpecificVolumeConversionBenchmarks
{
    private static readonly QuantityValue Value = 123.456;

    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }

    [Params(true, false)]
    public bool Frozen { get; set; }

    [ParamsAllValues]
    public SpecificVolumeUnit Unit { get; set; }

    private SpecificVolume TestQuantity
    {
        get => new(Value, Unit);
    }
    
    [GlobalSetup]
    public void Setup()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
    }

    [Benchmark(Baseline = true)]
    public Density Inverse()
    {
        return TestQuantity.Inverse();
    }
}
