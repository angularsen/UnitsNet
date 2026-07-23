// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using BenchmarkDotNet.Attributes;
using UnitsNet.Units;

namespace UnitsNet.Benchmark;

[MemoryDiagnoser]
public class UnitsNetBenchmarks
{
    private readonly Length _length = Length.FromMeters(3);
    private readonly IQuantity _lengthIQuantity = Length.FromMeters(3);

    static UnitsNetBenchmarks()
    {
        UnitsNetSetup.ConfigureDefaults(builder => builder.WithConverterOptions(new QuantityConverterBuildOptions(true, ConversionCachingMode.All)));
    }

    [Benchmark]
    [BenchmarkCategory("Construction")]
    public Length Constructor()
    {
        return new Length(3, LengthUnit.Meter);
    }

    [Benchmark]
    [BenchmarkCategory("Construction")]
    public Length Constructor_SI()
    {
        return new Length(3, UnitSystem.SI);
    }

    [Benchmark]
    [BenchmarkCategory("Construction")]
    public Length FromMethod()
    {
        return Length.FromMeters(3);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation")]
    public QuantityValue ToProperty()
    {
        return _length.Centimeters;
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Value")]
    public QuantityValue As()
    {
        return _length.As(LengthUnit.Centimeter);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Value")]
    public QuantityValue As_SI()
    {
        return _length.As(UnitSystem.SI);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Quantity")]
    public Length ToUnit()
    {
        return _length.ToUnit(LengthUnit.Centimeter);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Quantity")]
    public Length ToUnit_SI()
    {
        return _length.ToUnit(UnitSystem.SI);
    }

    [Benchmark]
    [BenchmarkCategory("ToString")]
    public string ToStringTest()
    {
        return _length.ToString();
    }

    [Benchmark]
    [BenchmarkCategory("Parsing")]
    public Length Parse()
    {
        return Length.Parse("3.0 m");
    }

    [Benchmark]
    [BenchmarkCategory("Parsing")]
    public bool TryParseValid()
    {
        return Length.TryParse("3.0 m", out _);
    }

    [Benchmark]
    [BenchmarkCategory("Parsing")]
    public bool TryParseInvalid()
    {
        return Length.TryParse("3.0 zoom", out _);
    }

    [Benchmark]
    [BenchmarkCategory("Construction")]
    public IQuantity QuantityFrom()
    {
        return Quantity.From(3, LengthUnit.Meter);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Value")]
    public QuantityValue IQuantity_As()
    {
        return _lengthIQuantity.As(LengthUnit.Centimeter);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Value")]
    public QuantityValue IQuantity_As_SI()
    {
        return _lengthIQuantity.As(UnitSystem.SI);
    }

    [Benchmark]
    [BenchmarkCategory("Transformation, Quantity")]
    public IQuantity IQuantity_ToUnit()
    {
        return _lengthIQuantity.ToUnit(LengthUnit.Centimeter);
    }

    [Benchmark]
    [BenchmarkCategory("ToString")]
    public string IQuantity_ToStringTest()
    {
        return _lengthIQuantity.ToString();
    }
}
