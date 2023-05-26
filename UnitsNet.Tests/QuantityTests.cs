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

        private static Length ParseLength(string str)
        {
            return Length.Parse(str, CultureInfo.InvariantCulture);
        }
    }
}
