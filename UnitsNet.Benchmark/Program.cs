using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UnitsNet.Units;

namespace UnitsNet.Benchmark
{
    [MemoryDiagnoser]
    public class UnitsNetBenchmarks
    {
        private readonly Length _length = Length.FromMeters(3.0);
        private readonly IQuantity _lengthIQuantity = Length.FromMeters(3.0);

        [Benchmark]
        [BenchmarkCategory("Construction")]
        public Length Constructor() => new Length(3.0, LengthUnit.Meter);

        [Benchmark]
        [BenchmarkCategory("Construction")]
        public Length Constructor_SI() => new Length(3.0, UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("Construction")]
        public Length FromMethod() => Length.FromMeters(3.0);

        [Benchmark]
        [BenchmarkCategory("Transformation")]
        public double ToProperty() => _length.Centimeters;

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double As() => _length.As(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double As_SI() => _length.As(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public Length ToUnit() => _length.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public Length ToUnit_SI() => _length.ToUnit(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("ToString")]
        public string ToStringTest() => _length.ToString();

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public Length Parse() => Length.Parse("3.0 m");

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public bool TryParseValid() => Length.TryParse("3.0 m", out _);

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public bool TryParseInvalid() => Length.TryParse("3.0 zoom", out _);

        [Benchmark]
        [BenchmarkCategory("Construction")]
        public IQuantity QuantityFrom() => Quantity.From(3.0, LengthUnit.Meter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double IQuantity_As() => _lengthIQuantity.As(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double IQuantity_As_SI() => _lengthIQuantity.As(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public IQuantity IQuantity_ToUnit() => _lengthIQuantity.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("ToString")]
        public string IQuantity_ToStringTest() => _lengthIQuantity.ToString();
    }

    class Program
    {
        static void Main(string[] args)
            => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
