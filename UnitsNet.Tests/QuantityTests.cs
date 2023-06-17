// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public partial class QuantityTests
    {
        private static readonly CultureInfo Russian = CultureInfo.GetCultureInfo("ru-RU");

        [Fact]
        public void GetHashCodeForDifferentQuantitiesWithSameValuesAreNotEqual()
        {
            var length = new Length(1.0, (LengthUnit)2);
            var area = new Area(1.0, (AreaUnit)2);

            Assert.NotEqual(length.GetHashCode(), area.GetHashCode());
        }

        [Theory]
        [InlineData("10 m", "9.89 m" , "0.1 m", false)] // +/- 0.1m absolute tolerance and some additional margin tolerate rounding errors in test case.
        [InlineData("10 m", "9.91 m" , "0.1 m", true)]
        [InlineData("10 m", "10.09 m", "0.1 m", true)]
        [InlineData("10 m", "1009 cm", "0.1 m", true)]  // Different unit, still equal.
        [InlineData("10 m", "10.11 m", "0.1 m", false)]
        [InlineData("10 m", "8.9 m"  , "0.1 m", false)] // +/- 1m relative tolerance (10%) and some additional margin tolerate rounding errors in test case.
        public void Equals_IGenericEquatableQuantity(string q1String, string q2String, string toleranceString, bool expectedEqual)
        {
            // This interfaces implements .NET generic math interfaces.
            IQuantity<Length, LengthUnit, double> q1 = ParseLength(q1String);
            IQuantity<Length, LengthUnit, double> q2 = ParseLength(q2String);
            IQuantity<Length, LengthUnit, double> tolerance = ParseLength(toleranceString);

            Assert.Equal(expectedEqual, q1.Equals(q2, tolerance));
        }

        [Theory]
        [InlineData("10 m", "9.89 m" , "0.1 m", false)] // +/- 0.1m absolute tolerance and some additional margin tolerate rounding errors in test case.
        [InlineData("10 m", "9.91 m" , "0.1 m", true)]
        [InlineData("10 m", "10.09 m", "0.1 m", true)]
        [InlineData("10 m", "1009 cm", "0.1 m", true)]  // Different unit, still equal.
        [InlineData("10 m", "10.11 m", "0.1 m", false)]
        [InlineData("10 m", "8.9 m"  , "0.1 m", false)] // +/- 1m relative tolerance (10%) and some additional margin tolerate rounding errors in test case.
        public void Equals_IQuantity(string q1String, string q2String, string toleranceString, bool expectedEqual)
        {
            IQuantity q1 = ParseLength(q1String);
            IQuantity q2 = ParseLength(q2String);
            IQuantity tolerance = ParseLength(toleranceString);

            Assert.NotEqual(q1, q2); // Strict equality should not be equal.
            Assert.Equal(expectedEqual, q1.Equals(q2, tolerance));
        }

        [Fact]
        public void Equals_IQuantity_OtherIsNull_ReturnsFalse()
        {
            IQuantity q1 = ParseLength("10 m");
            IQuantity? q2 = null;
            IQuantity tolerance = ParseLength("0.1 m");

            Assert.False(q1.Equals(q2, tolerance));
        }

        [Fact]
        public void Equals_IQuantity_OtherIsDifferentType_ReturnsFalse()
        {
            IQuantity q1 = ParseLength("10 m");
            IQuantity q2 = Mass.FromKilograms(10);
            IQuantity tolerance = Mass.FromKilograms(0.1);

            Assert.False(q1.Equals(q2, tolerance));
        }

        [Fact]
        public void Equals_IQuantity_ToleranceIsDifferentType_Throws()
        {
            IQuantity q1 = ParseLength("10 m");
            IQuantity q2 = ParseLength("10 m");
            IQuantity tolerance = Mass.FromKilograms(0.1);

            Assert.Throws<ArgumentException>(() => q1.Equals(q2, tolerance));
        }

        [Fact]
        public void Equals_GenericEquatableIQuantity_OtherIsNull_ReturnsFalse()
        {
            IQuantity<Length, LengthUnit, double> q1 = ParseLength("10 m");
            IQuantity<Length, LengthUnit, double>? q2 = null;
            IQuantity<Length, LengthUnit, double> tolerance = ParseLength("0.1 m");

            Assert.False(q1.Equals(q2, tolerance));
        }

        [Fact]
        public void TryFrom_ValidQuantityNameAndUnitName_ReturnsTrueAndQuantity()
        {
            void AssertFrom(string quantityName, string unitName, Enum expectedUnit)
            {
                Assert.True(Quantity.TryFrom(5, quantityName, unitName, out IQuantity? quantity));
                Assert.NotNull(quantity);
                Assert.Equal(5, quantity!.Value);
                Assert.Equal(expectedUnit, quantity.Unit);
            }

            AssertFrom("Length", "Centimeter", LengthUnit.Centimeter);
            AssertFrom("Mass", "Kilogram", MassUnit.Kilogram);
        }

        [Fact]
        public void TryFrom_InvalidQuantityNameAndUnitName_ReturnsFalseAndNull()
        {
            void AssertInvalid(string quantityName, string unitName)
            {
                Assert.False(Quantity.TryFrom(5, quantityName, unitName, out IQuantity? quantity));
                Assert.Null(quantity);
            }

            AssertInvalid("Length", "InvalidUnit");
            AssertInvalid("InvalidQuantity", "Kilogram");
        }

        [Fact]
        public void From_ValidQuantityNameAndUnitName_ReturnsQuantity()
        {
            void AssertFrom(string quantityName, string unitName, Enum expectedUnit)
            {
                IQuantity quantity = Quantity.From(5, quantityName, unitName);
                Assert.NotNull(quantity);
                Assert.Equal(5, quantity.Value);
                Assert.Equal(expectedUnit, quantity.Unit);
            }

            AssertFrom("Length", "Centimeter", LengthUnit.Centimeter);
            AssertFrom("Mass", "Kilogram", MassUnit.Kilogram);
        }

        [Fact]
        public void From_InvalidQuantityNameOrUnitName_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => Quantity.From(5, "Length", "InvalidUnit"));
            Assert.Throws<UnitNotFoundException>(() => Quantity.From(5, "InvalidQuantity", "Kilogram"));
        }

        [Fact]
        public void FromUnitAbbreviation_ReturnsQuantity()
        {
            IQuantity q = Quantity.FromUnitAbbreviation(5, "cm");
            Assert.Equal(5, q.Value);
            Assert.Equal(LengthUnit.Centimeter, q.Unit);
        }

        [Fact]
        public void TryFromUnitAbbreviation_ReturnsQuantity()
        {
            Assert.True(Quantity.TryFromUnitAbbreviation(5, "cm", out IQuantity? q));
            Assert.Equal(LengthUnit.Centimeter, q!.Unit);
        }

        [Fact]
        public void FromUnitAbbreviation_MatchingCulture_ReturnsQuantity()
        {
            IQuantity q = Quantity.FromUnitAbbreviation(Russian, 5, "см");
            Assert.Equal(5, q.Value);
            Assert.Equal(LengthUnit.Centimeter, q.Unit);
        }

        [Fact]
        public void TryFromUnitAbbreviation_MatchingCulture_ReturnsQuantity()
        {
            Assert.False(Quantity.TryFromUnitAbbreviation(Russian, 5, "cm", out IQuantity? q));
        }

        [Fact]
        public void FromUnitAbbreviation_MismatchingCulture_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => Quantity.FromUnitAbbreviation(Russian, 5, "cm")); // Expected "см"
        }

        [Fact]
        public void TryFromUnitAbbreviation_MismatchingCulture_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => Quantity.FromUnitAbbreviation(Russian, 5, "cm")); // Expected "см"
        }

        [Fact]
        public void FromUnitAbbreviation_InvalidAbbreviation_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => Quantity.FromUnitAbbreviation(5, "nonexisting-unit"));
        }

        [Fact]
        public void TryFromUnitAbbreviation_InvalidAbbreviation_ThrowsUnitNotFoundException()
        {
            Assert.False(Quantity.TryFromUnitAbbreviation(5, "nonexisting-unit", out IQuantity? q));
            Assert.Null(q);
        }

        [Fact]
        public void FromUnitAbbreviation_AmbiguousAbbreviation_ThrowsAmbiguousUnitParseException()
        {
            // MassFraction.Percent
            // Ratio.Percent
            // VolumeConcentration.Percent
            Assert.Throws<AmbiguousUnitParseException>(() => Quantity.FromUnitAbbreviation(5, "%"));
        }

        [Fact]
        public void TryFromUnitAbbreviation_AmbiguousAbbreviation_ReturnsFalse()
        {
            // MassFraction.Percent
            // Ratio.Percent
            // VolumeConcentration.Percent
            Assert.False(Quantity.TryFromUnitAbbreviation(5, "%", out IQuantity? q));
            Assert.Null(q);
        }

        private static Length ParseLength(string str)
        {
            return Length.Parse(str, CultureInfo.InvariantCulture);
        }
    }
}
