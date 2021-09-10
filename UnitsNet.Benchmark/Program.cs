using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UnitsNet.Units;

namespace UnitsNet.Benchmark
{
    [MemoryDiagnoser]
    public class UnitsNetBenchmarks
    {
        private Length length = Length.FromMeters(3.0);
        private IQuantity lengthIQuantity = Length.FromMeters(3.0);

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
        public double ToProperty() => length.Centimeters;

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double As() => length.As(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double As_SI() => length.As(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public Length ToUnit() => length.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public Length ToUnit_SI() => length.ToUnit(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("ToString")]
        public string ToStringTest() => length.ToString();

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public Length Parse() => Length.Parse("3.0 m");

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public bool TryParseValid() => Length.TryParse("3.0 m", out var l);

        [Benchmark]
        [BenchmarkCategory("Parsing")]
        public bool TryParseInvalid() => Length.TryParse("3.0 zoom", out var l);

        [Benchmark]
        [BenchmarkCategory("Construction")]
        public IQuantity QuantityFrom() => Quantity.From(3.0, LengthUnit.Meter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double IQuantity_As() => lengthIQuantity.As(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("Transformation, Value")]
        public double IQuantity_As_SI() => lengthIQuantity.As(UnitSystem.SI);

        [Benchmark]
        [BenchmarkCategory("Transformation, Quantity")]
        public IQuantity IQuantity_ToUnit() => lengthIQuantity.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        [BenchmarkCategory("ToString")]
        public string IQuantity_ToStringTest() => lengthIQuantity.ToString();
    }

    class Program
    {
        static void Main(string[] args)
            => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
