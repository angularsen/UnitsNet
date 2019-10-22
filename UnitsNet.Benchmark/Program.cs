using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UnitsNet.Units;

namespace UnitsNet.Benchmark
{
    [MemoryDiagnoser]
    public class UnitsNetBenchmarks
    {
        private Length<double> length = Length<double>.FromMeters(3.0);
        private IQuantity lengthIQuantity = Length<double>.FromMeters(3.0);

        [Benchmark]
        public Length<double> Constructor() => new Length<double>( 3.0, LengthUnit.Meter);

        [Benchmark]
        public Length<double> Constructor_SI() => new Length<double>( 3.0, UnitSystem.SI);

        [Benchmark]
        public Length<double> FromMethod() => Length<double>.FromMeters(3.0);

        [Benchmark]
        public double ToProperty() => length.Centimeters;

        [Benchmark]
        public double As() => length.As(LengthUnit.Centimeter);

        [Benchmark]
        public double As_SI() => length.As(UnitSystem.SI);

        [Benchmark]
        public Length<double> ToUnit() => length.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        public Length<double> ToUnit_SI() => length.ToUnit(UnitSystem.SI);

        [Benchmark]
        public string ToStringTest() => length.ToString();

        [Benchmark]
        public Length<double> Parse() => Length<double>.Parse("3.0 m");

        [Benchmark]
        public bool TryParseValid() => Length<double>.TryParse("3.0 m", out var l);

        [Benchmark]
        public bool TryParseInvalid() => Length<double>.TryParse("3.0 zoom", out var l);

        [Benchmark]
        public IQuantity QuantityFrom() => Quantity.From<double>( 3.0, LengthUnit.Meter);

        [Benchmark]
        public double IQuantity_As() => lengthIQuantity.As(LengthUnit.Centimeter);

        [Benchmark]
        public double IQuantity_As_SI() => lengthIQuantity.As(UnitSystem.SI);

        [Benchmark]
        public IQuantity IQuantity_ToUnit() => lengthIQuantity.ToUnit(LengthUnit.Centimeter);

        [Benchmark]
        public string IQuantity_ToStringTest() => lengthIQuantity.ToString();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<UnitsNetBenchmarks>();
        }
    }
}
