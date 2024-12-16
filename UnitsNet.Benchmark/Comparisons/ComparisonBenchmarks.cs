using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace UnitsNet.Benchmark.Comparisons;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net80)]
public class ComparisonBenchmarks
{
    private static readonly Mass Tolerance = Mass.FromNanograms(1);

    public static IEnumerable<object[]> Operands()
    {
        // equal value and unit
        yield return [Mass.From(42, Mass.BaseUnit), Mass.From(42, Mass.BaseUnit)];
        // equal value and unit
        yield return [Mass.FromGrams(42), Mass.FromGrams(42)];
        // zero in another unit
        yield return [Mass.Zero, Mass.FromGrams(0)];
        // same quantity in another unit
        yield return [Mass.FromGrams(42), Mass.FromMilligrams(42000)];
        // same quantity in another unit (in reverse)
        yield return [Mass.FromMilligrams(42000), Mass.FromGrams(42)];
        // different value and same unit
        yield return [Mass.FromGrams(42), Mass.FromGrams(42.1)];
        // huge values, same unit
        yield return [Mass.FromGrams(-1e37), Mass.FromGrams(1 / 1e12)];
        // huge values, different units
        yield return [Mass.FromGrams(-1e37), Mass.FromMilligrams(1 / 1e12)];
        // Math.PI, same unit
        yield return [Mass.FromGrams(Math.PI), Mass.FromGrams(Math.PI)];
        // Math.PI, different units
        yield return [Mass.FromGrams(Math.PI), Mass.FromMilligrams(Math.PI)];
        // very close fractions, same units
        yield return [Mass.FromGrams(12.3456789987654321), Mass.FromGrams(12.3456789987654322)];
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public bool Equals(Mass a, Mass b)
    {
        return a.Equals(b);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public bool EqualsTolerance(Mass a, Mass b)
    {
        return a.Equals(b, Tolerance);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public bool GetHashCode(Mass a, Mass b)
    {
        return a.GetHashCode() == b.GetHashCode();
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public int CompareTo(Mass a, Mass b)
    {
        return a.CompareTo(b);
    }
}
