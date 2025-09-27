using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Comparisons;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
public class ComparisonBenchmarks
{
    private static readonly Mass Tolerance = Mass.FromNanograms(1);

    // [Params(true, false, Priority = 3)]
    [Params(true)]
    public bool Frozen { get; set; }

    // [Params(ConversionCachingMode.All, ConversionCachingMode.None, Priority = 2)]
    [Params(ConversionCachingMode.All)]
    public ConversionCachingMode CachingMode { get; set; }
    

    // [Params(MassUnit.Milligram, MassUnit.Gram, MassUnit.Kilogram)]
    [Params(MassUnit.Milligram)]
    public MassUnit LeftUnit { get; set; }
    
    // [Params(MassUnit.Gram, MassUnit.Kilogram)]
    // [Params(MassUnit.Gram)]
    [Params(MassUnit.Milligram)]
    public MassUnit RightUnit { get; set; }

    [ParamsSource(nameof(LeftValues))]
    public QuantityValue LeftValue { get; set; }

    public QuantityValue[] LeftValues => [95];
    
    
    [ParamsSource(nameof(RightValues))]
    public QuantityValue RightValue { get; set; }

    public QuantityValue[] RightValues => [95];
    
    private Mass _leftQuantity, _rightQuantity;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        Console.Out.WriteLine("Preparing the configuration..");
        UnitsNetSetup.ConfigureDefaults(builder => builder
            .WithQuantities([Mass.Info])
            .WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
        Console.Out.WriteLine("Default configuration set.");
        Quantity.From(QuantityValue.Zero, MassUnit.Kilogram);
        
        _leftQuantity = new Mass(LeftValue, LeftUnit);
        _rightQuantity = new Mass(RightValue, RightUnit);
    }
    
    [Benchmark]
    public bool Equals()
    {
        return _leftQuantity.Equals(_rightQuantity);
    }
    
    [Benchmark(Baseline = true)]
    public bool EqualsTolerance()
    {
        return _leftQuantity.Equals(_rightQuantity, Tolerance);
    }
    
    [Benchmark(Baseline = false)]
    public bool EqualsToleranceBoxed()
    {
        Mass left = _leftQuantity;
        IQuantity<Mass, MassUnit> right = _rightQuantity;
        return left.Equals(right, Tolerance);
    }
}
