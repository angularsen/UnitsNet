// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnitsNet.Units;
using Xunit;
using static System.Globalization.CultureInfo;

namespace UnitsNet.Tests
{
    public class QuantityTest
    {
        // Exclude Undefined value
        private static readonly int QuantityCount = Quantity.ByName.Count;

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void From_GivenNaNOrInfinity_ThrowsArgumentException(double value)
        {
            Assert.Throws<ArgumentException>(() => Quantity.From(value, LengthUnit.Centimeter));
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        public void TryFrom_GivenNaNOrInfinity_ReturnsFalseAndNullQuantity(double value)
        {
            Assert.False(Quantity.TryFrom(value, LengthUnit.Centimeter, out IQuantity? parsedLength));
            Assert.Null(parsedLength);
        }

        [Fact]
        public void From_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.Equal(Length.FromCentimeters(3), Quantity.From(3, LengthUnit.Centimeter));
            Assert.Equal(Mass.FromTonnes(3), Quantity.From(3, MassUnit.Tonne));
            Assert.Equal(Pressure.FromMegabars(3), Quantity.From(3, PressureUnit.Megabar));
        }

        [Fact]
        public void ByName_GivenLength_ReturnsQuantityInfoForLength()
        {
            QuantityInfo quantityInfo = Quantity.ByName["Length"];
            Assert.Equal("Length", quantityInfo.Name);
            Assert.Same(Length.Info, quantityInfo);
        }

        [Fact]
        public void ByName_GivenMass_ReturnsQuantityInfoForMass()
        {
            QuantityInfo quantityInfo = Quantity.ByName["Mass"];
            Assert.Equal("Mass", quantityInfo.Name);
            Assert.Same(Mass.Info, quantityInfo);
        }

        [Fact]
        public void Infos_ReturnsKnownQuantityInfoObjects()
        {
            QuantityInfo[] knownQuantityInfos = { Length.Info, Force.Info, Mass.Info };
            var infos = Quantity.Infos;

            Assert.Superset(knownQuantityInfos.ToHashSet(), infos.ToHashSet());
            Assert.Equal(QuantityCount, infos.Length);
        }

        [Fact]
        public void GetUnitInfo_ReturnsUnitInfoForUnitEnumValue()
        {
            var unitInfo = Quantity.GetUnitInfo(LengthUnit.Meter);
            Assert.Equal("Meter", unitInfo.Name);
            Assert.Equal("Meters", unitInfo.PluralName);
            Assert.Equal(LengthUnit.Meter, unitInfo.Value);
        }

        [Fact]
        public void TryGetUnitInfo_ReturnsUnitInfoForUnitEnumValue()
        {
            bool found = Quantity.TryGetUnitInfo(LengthUnit.Meter, out UnitInfo? unitInfo);
            Assert.True(found);
            Assert.Equal("Meter", unitInfo!.Name);
            Assert.Equal("Meters", unitInfo.PluralName);
            Assert.Equal(LengthUnit.Meter, unitInfo.Value);
        }

        [Fact]
        public void GetUnitInfo_ThrowsKeyNotFoundExceptionIfNotFound()
        {
            Assert.Throws<KeyNotFoundException>(() => Quantity.GetUnitInfo(ConsoleColor.Red));
        }

        [Fact]
        public void TryGetUnitInfo_ReturnsFalseIfNotFound()
        {
            bool found = Quantity.TryGetUnitInfo(ConsoleColor.Red, out _);
            Assert.False(found);
        }

        [Fact]
        public void Parse_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.Equal(Length.FromCentimeters(3), Quantity.Parse(InvariantCulture, typeof(Length), "3 cm"));
            Assert.Equal(Mass.FromTonnes(3), Quantity.Parse(InvariantCulture, typeof(Mass), "03t"));
            Assert.Equal(Pressure.FromMegabars(3), Quantity.Parse(InvariantCulture, typeof(Pressure), "3.0 Mbar"));
        }

        [Fact]
        public void QuantityNames_ReturnsKnownNames()
        {
            var knownNames = new[] {"Length", "Force", "Mass"};

            var names = Quantity.Names;

            Assert.Superset(knownNames.ToHashSet(), names.ToHashSet());
            Assert.Equal(QuantityCount, names.Length);
        }

        [Fact]
        public void TryFrom_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.True(Quantity.TryFrom(3, LengthUnit.Centimeter, out IQuantity? parsedLength));
            Assert.Equal(Length.FromCentimeters(3), parsedLength);

            Assert.True(Quantity.TryFrom(3, MassUnit.Tonne, out IQuantity? parsedMass));
            Assert.Equal(Mass.FromTonnes(3), parsedMass);

            Assert.True(Quantity.TryFrom(3, PressureUnit.Megabar, out IQuantity? parsedPressure));
            Assert.Equal(Pressure.FromMegabars(3), parsedPressure);
        }

        [Fact]
        public void TryParse_GivenInvalidQuantityType_ReturnsFalseAndNullQuantity()
        {
            Assert.False(Quantity.TryParse(InvariantCulture, typeof(DummyIQuantity), "3.0 cm", out IQuantity? parsedLength));
            Assert.Null(parsedLength);
        }

        [Fact]
        public void TryParse_GivenInvalidString_ReturnsFalseAndNullQuantity()
        {
            Assert.False(Quantity.TryParse(InvariantCulture, typeof(Length), "x cm", out IQuantity? parsedLength));
            Assert.Null(parsedLength);

            Assert.False(Quantity.TryParse(InvariantCulture, typeof(Mass), "xt", out IQuantity? parsedMass));
            Assert.Null(parsedMass);

            Assert.False(Quantity.TryParse(InvariantCulture, typeof(Pressure), "foo", out IQuantity? parsedPressure));
            Assert.Null(parsedPressure);
        }

        [Fact]
        public void TryParse_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.True(Quantity.TryParse(InvariantCulture, typeof(Length), "3 cm", out IQuantity? parsedLength));
            Assert.Equal(Length.FromCentimeters(3), parsedLength);

            Assert.True(Quantity.TryParse(InvariantCulture, typeof(Mass), "03t", out IQuantity? parsedMass));
            Assert.Equal(Mass.FromTonnes(3), parsedMass);

            Assert.True(Quantity.TryParse(NumberFormatInfo.InvariantInfo, typeof(Pressure), "3.0 Mbar", out IQuantity? parsedPressure));
            Assert.Equal(Pressure.FromMegabars(3), parsedPressure);
        }

        [Fact]
        public void Types_ReturnsKnownQuantityTypes()
        {
            var knownQuantities = new List<QuantityInfo> { Length.Info, Force.Info, Mass.Info };

            ICollection<QuantityInfo> types = Quantity.ByName.Values;

            Assert.Superset(knownQuantities.ToHashSet(), types.ToHashSet());
        }
    }
}
