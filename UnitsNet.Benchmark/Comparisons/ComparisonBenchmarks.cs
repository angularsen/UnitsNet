using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using UnitsNet.Units;

namespace UnitsNet.Benchmark.Comparisons;

[MemoryDiagnoser]
// [SimpleJob(RuntimeMoniker.Net48)]
[SimpleJob(RuntimeMoniker.Net90)]
// [ShortRunJob(RuntimeMoniker.Net48)]
// [ShortRunJob(RuntimeMoniker.Net80)]
// [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
// [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
// [Config(typeof(Config))]
public class ComparisonBenchmarksTestingAlloc
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
    
    
    // [ParamsSource(nameof(GetQuantitiesToCompare))]
    // public (string, Mass, Mass) QuantitiesToCompare { get; set; }
    //
    // public static (string, Mass, Mass)[] GetQuantitiesToCompare => new[] { ("100 g and 95 g", Mass.From(100, MassUnit.Gram), Mass.From(95, MassUnit.Gram)) };
    
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
    
    // [Benchmark]
    // public bool Equals()
    // {
    //     return _leftQuantity.Equals(_rightQuantity);
    // }
    
    // [Benchmark(Baseline = true)]
    // public bool EqualsTolerance()
    // {
    //     return _leftQuantity.Equals(_rightQuantity, Tolerance);
    // }
    //
    // [Benchmark(Baseline = false)]
    // public bool EqualsToleranceBoxed()
    // {
    //     IQuantity<Mass, MassUnit> left = _leftQuantity;
    //     IQuantity<Mass, MassUnit> right = _rightQuantity;
    //     return left.Equals(right, Tolerance);
    // }

    [Benchmark(Baseline = true)]
    public bool EqualsWith3Concrete()
    {
        return LinearQuantityExtensions.EqualsAbsolute(_leftQuantity, _rightQuantity, Tolerance);
    }
    
    [Benchmark]
    public bool EqualsWithOptional()
    {
        return LinearQuantityExtensions.Equals(_leftQuantity, _rightQuantity, Tolerance);
    }

    // [Benchmark]
    // public bool EqualsWithConcrete_1_0_0()
    // {
    //     IQuantityInstance<Mass> right = _rightQuantity;
    //     IQuantityInstance<Mass> tolerance = Tolerance;
    //     
    //     return QuantityExtensions.EqualsVector<Mass, IQuantityInstance<Mass>, IQuantityInstance<Mass>>(_leftQuantity, right, tolerance);
    // }
    //
    // [Benchmark]
    // public bool EqualsWithConcrete_1_0_1()
    // {
    //     IVectorQuantity<Mass> right = _rightQuantity;
    //     return QuantityExtensions.EqualsVector<Mass, IQuantityInstance<Mass>, Mass>(_leftQuantity, right, Tolerance);
    // }
    //
    // [Benchmark]
    // public bool EqualsWithConcrete_1_1_0()
    // {
    //     IVectorQuantity<Mass> tolerance = Tolerance;
    //     return QuantityExtensions.EqualsVector<Mass, Mass, IQuantityInstance<Mass>>(_leftQuantity, _rightQuantity, tolerance);
    // }

    // [Benchmark]
    // public bool EqualsWithConcrete_0_1_1()
    // {
    //     IVectorQuantity<Mass> left = _leftQuantity;
    //     return QuantityExtensions.EqualsVector<IVectorQuantity<Mass>, Mass, Mass>(left, _rightQuantity, Tolerance);
    // }
    //
    // [Benchmark]
    // public bool EqualsWithConcrete_0_0_1()
    // {
    //     IVectorQuantity<Mass> left = _leftQuantity;
    //     IVectorQuantity<Mass> right = _rightQuantity;
    //     
    //     return QuantityExtensions.EqualsVector<IVectorQuantity<Mass>, IVectorQuantity<Mass>, Mass>(left, right, Tolerance);
    // }
    //
    // [Benchmark]
    // public bool EqualsWithInterface()
    // {
    //     IVectorQuantity<Mass> left = _leftQuantity;
    //     IVectorQuantity<Mass> right = _rightQuantity;
    //     IVectorQuantity<Mass> tolerance = Tolerance;
    //     
    //     
    //     return QuantityExtensions.EqualsVector<IVectorQuantity<Mass>, IVectorQuantity<Mass>, IVectorQuantity<Mass>>(left, right, tolerance);
    // }
    

    // private static bool CompareGeneric4<TQuantity, TLeft, TRight, TTolerance>(TLeft left, TRight right, TTolerance tolerance)
    //     where TLeft : IComparableQuantity<TQuantity>
    //     where TRight : IComparableQuantity<TQuantity>
    //     where TTolerance : IComparableQuantity<TQuantity>
    //     where TQuantity : IComparableQuantity<TQuantity>
    // {
    //     return QuantityExtensions.EqualsVector<TQuantity, TLeft, TRight, TTolerance>(left, right, tolerance);
    // }

    // [Benchmark]
    // public bool EqualsWithToleranceEnum()
    // {
    //     return _leftQuantity.EqualsWithToleranceEnum(_rightQuantity, Tolerance);
    // }
    
    
    // public IEnumerable<object[]> Operands()
    // {
    //     Console.Out.WriteLine("Preparing the operands");
    //     // equal value and unit
    //     yield return [Mass.From(42, Mass.BaseUnit), Mass.From(42, Mass.BaseUnit)];
    //     // equal value and unit
    //     yield return [Mass.FromGrams(42), Mass.FromGrams(42)];
    //     // zero in another unit
    //     yield return [Mass.Zero, Mass.FromGrams(0)];
    //     // same quantity in another unit
    //     yield return [Mass.FromGrams(42), Mass.FromMilligrams(42000)];
    //     // different value and same unit
    //     yield return [Mass.FromGrams(42), Mass.FromGrams(42.1)];
    //     // huge values, same unit
    //     yield return [Mass.FromGrams(BigInteger.Pow(-10, 37)), Mass.FromGrams(new QuantityValue(1, BigInteger.Pow(10, 12)))];
    //     // huge values, different units
    //     yield return [Mass.FromGrams(BigInteger.Pow(-10, 37)), Mass.FromMilligrams(new QuantityValue(1, BigInteger.Pow(10, 12)))];
    //     // Math.PI, same unit
    //     yield return [Mass.FromGrams(UnitMath.PI), Mass.FromGrams(UnitMath.PI)];
    //     // Math.PI, different units
    //     yield return [Mass.FromGrams(UnitMath.PI), Mass.FromMilligrams(UnitMath.PI)];
    //     // very close fractions, same units
    //     yield return [Mass.FromGrams(12.3456789987654321m), Mass.FromGrams(12.3456789987654322m)];
    // }
    //
    // [Benchmark]
    // [ArgumentsSource(nameof(Operands), Priority = -1)]
    // public bool Equals(Mass a, Mass b)
    // {
    //     return a.Equals(b);
    // }
    //
    // [Benchmark]
    // [ArgumentsSource(nameof(Operands))]
    // public bool EqualsTolerance(Mass a, Mass b)
    // {
    //     return a.Equals(b, Tolerance);
    // }
    //
    // [Benchmark]
    // [ArgumentsSource(nameof(Operands))]
    // public int CompareTo(Mass a, Mass b)
    // {
    //     return a.CompareTo(b);
    // }
    //
    // private class Config : ManualConfig
    // {
    //     public Config()
    //     {
    //         Orderer = new CustomOrderer();
    //     }
    // }
    //
    // public class CustomOrderer : DefaultOrderer
    // {
    //     protected override IEnumerable<BenchmarkCase> GetSummaryOrderForGroup(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
    //     {
    //         return benchmarksCase
    //             .OrderBy(b => b.Parameters["a"])
    //             .ThenBy(b => b.Parameters["b"])
    //             .ThenBy(b => b.Parameters["CachingMode"])
    //             .ThenBy(b => b.Parameters["Frozen"])
    //             .ThenBy(b => b.Parameters["Runtime"]);
    //     }
    // }
}
