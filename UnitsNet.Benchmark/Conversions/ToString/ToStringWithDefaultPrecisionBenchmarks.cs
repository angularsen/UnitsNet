using System;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Conversions.ToString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class ToStringWithDefaultPrecisionBenchmarks
{
    private static readonly QuantityValue Value = 123.456m;
    private readonly Random _random = new(42);

    private Mass[] _masses = [];
    private VolumeFlow[] _volumeFlows = [];

    [Params(1000)]
    public int NbConversions { get; set; }

    [Params("G", "S", "E", "N", "A")]
    public string Format { get; set; }

    [GlobalSetup(Target = nameof(MassToString))]
    public void PrepareMassesToTest()
    {
        _masses = _random.GetRandomQuantities<Mass, MassUnit>(Value, Mass.Units.ToArray(), NbConversions).ToArray();
    }

    [GlobalSetup(Target = nameof(VolumeFlowToString))]
    public void PrepareVolumeFlowsToTest()
    {
        _volumeFlows = _random.GetRandomQuantities<VolumeFlow, VolumeFlowUnit>(Value, VolumeFlow.Units.ToArray(), NbConversions).ToArray();
    }

    [Benchmark(Baseline = true)]
    public void MassToString()
    {
        foreach (Mass quantity in _masses)
        {
            var result = quantity.ToString(Format, CultureInfo.InvariantCulture);
        }
    }

    [Benchmark]
    public void VolumeFlowToString()
    {
        foreach (VolumeFlow quantity in _volumeFlows)
        {
            var result = quantity.ToString(Format, CultureInfo.InvariantCulture);
        }
    }
}
