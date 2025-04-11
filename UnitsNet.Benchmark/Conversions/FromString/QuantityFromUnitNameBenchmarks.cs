using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Conversions.FromString;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net80)]
public class QuantityFromUnitNameBenchmarks
{
    private readonly Random _random = new(42);
    private string[] _unitNames;

    [Params(1000)]
    public int NbAbbreviations { get; set; }

    [GlobalSetup(Target = nameof(FromMassUnitName))]
    public void PrepareMassUnits()
    {
        _unitNames = _random.GetItems(Mass.Info.UnitInfos.Select(x => x.Name).ToArray(), NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeUnitName))]
    public void PrepareVolumeUnits()
    {
        _unitNames = _random.GetItems(Volume.Info.UnitInfos.Select(x => x.Name).ToArray(), NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromPressureUnitName))]
    public void PreparePressureUnits()
    {
        _unitNames = _random.GetItems(Pressure.Info.UnitInfos.Select(x => x.Name).ToArray(), NbAbbreviations);
    }

    [GlobalSetup(Target = nameof(FromVolumeFlowUnitName))]
    public void PrepareVolumeFlowUnits()
    {
        _unitNames = _random.GetItems(VolumeFlow.Info.UnitInfos.Select(x => x.Name).ToArray(), NbAbbreviations);
    }

    [Benchmark(Baseline = true)]
    public IQuantity FromMassUnitName()
    {
        IQuantity quantity = null;
        foreach (var unitName in _unitNames)
        {
            quantity = Quantity.From(1, nameof(Mass), unitName);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeUnitName()
    {
        IQuantity quantity = null;
        foreach (var unitName in _unitNames)
        {
            quantity = Quantity.From(1, nameof(Volume), unitName);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromPressureUnitName()
    {
        IQuantity quantity = null;
        foreach (var unitName in _unitNames)
        {
            quantity = Quantity.From(1, nameof(Pressure), unitName);
        }

        return quantity;
    }

    [Benchmark(Baseline = false)]
    public IQuantity FromVolumeFlowUnitName()
    {
        IQuantity quantity = null;
        foreach (var unitName in _unitNames)
        {
            quantity = Quantity.From(1, nameof(VolumeFlow), unitName);
        }

        return quantity;
    }
}
