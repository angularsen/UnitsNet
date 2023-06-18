#nullable enable
using System;

namespace UnitsNet.Tests
{
    internal class DummyIQuantity : IQuantity
    {
        public BaseDimensions Dimensions => throw new NotImplementedException();

        public QuantityInfo QuantityInfo => throw new NotImplementedException();

        bool IQuantity.Equals(IQuantity? other, IQuantity tolerance) => throw new NotImplementedException();

        public Enum Unit => throw new NotImplementedException();

        public QuantityValue Value => throw new NotImplementedException();

        public double As(Enum unit ) => throw new NotImplementedException();

        public double As(UnitSystem unitSystem ) => throw new NotImplementedException();

        public bool Equals(IQuantity? other, double tolerance, ComparisonType comparisonType) => throw new NotImplementedException();

        public string ToString(IFormatProvider? provider) => throw new NotImplementedException();

        public string ToString(string? format, IFormatProvider? formatProvider) => throw new NotImplementedException();

        public IQuantity ToUnit(Enum unit, UnitConverter unitConverter) => throw new NotImplementedException();

        public IQuantity ToUnit(Enum unit ) => throw new NotImplementedException();

        public IQuantity ToUnit(UnitSystem unitSystem ) => throw new NotImplementedException();
    }
}
