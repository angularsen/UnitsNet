// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Comparisons;

// [MemoryDiagnoser]
// [ShortRunJob(RuntimeMoniker.Net48)]
// [ShortRunJob(RuntimeMoniker.Net80)]
// public class GetHashCodeBenchmarks
// {
//
//     // [Params(true, false)]
//     [Params(true)]
//     public bool Frozen { get; set; }
//
//     // [Params(ConversionCachingMode.All, ConversionCachingMode.None)]
//     [Params(ConversionCachingMode.All)]
//     public ConversionCachingMode CachingMode { get; set; }
//     
//     [Params(true, false)]
//     public bool ReduceQuantityValues { get; set; }
//
//
//     [GlobalSetup]
//     public void GlobalSetup()
//     {
//         UnitsNetSetup.ConfigureDefaults(builder => builder
//             .WithQuantities([Mass.Info])
//             .WithConverterOptions(new QuantityConverterBuildOptions(Frozen, CachingMode)));
//     }
//
//     private IEnumerable<Mass> GetQuantities() {
//         // equal value and unit
//         yield return Mass.From(42, Mass.BaseUnit);
//         // zero in another unit
//         yield return Mass.FromGrams(0);
//         // equal value and unit
//         yield return Mass.FromGrams(42);
//         // same quantity in another unit
//         yield return Mass.FromMilligrams(42_000);
//         // decimal value 
//         yield return Mass.FromGrams(42.1);
//         // huge values in numerator
//         yield return Mass.FromGrams(BigInteger.Pow(-10, 37));
//         // huge values in denominator
//         yield return Mass.FromGrams(new QuantityValue(1, BigInteger.Pow(10, 12)));
//         // Math.PI in base unit
//         yield return Mass.From(UnitMath.PI, Mass.BaseUnit);
//         // Math.PI, different units
//         yield return Mass.FromGrams(UnitMath.PI);
//         // very precise decimal
//         yield return Mass.FromGrams(12.3456789987654321m);
//     }
//
//     public IEnumerable<Mass> Operands()
//     {
//         if (ReduceQuantityValues)
//         {
//             return GetQuantities().Select(x => new Mass(QuantityValue.Reduce(x.Value), x.Unit));
//         }
//         
//         return GetQuantities();
//     }
//
//     [Benchmark]
//     [ArgumentsSource(nameof(Operands))]
//     public int GetHashCode(Mass a)
//     {
//         return a.GetHashCode();
//     }
// }
