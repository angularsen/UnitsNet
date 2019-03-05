// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityTest
    {
        // Exclude Undefined value
        private static readonly int QuantityCount = Enum.GetValues(typeof(QuantityType)).Length - 1;

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
            Assert.False(Quantity.TryFrom(value, LengthUnit.Centimeter, out IQuantity parsedLength));
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
        public void GetInfo_GivenLength_ReturnsQuantityInfoForLength()
        {
            var knownLengthUnits = new Enum[] {LengthUnit.Meter, LengthUnit.Centimeter, LengthUnit.Kilometer};
            var knownLengthUnitNames = new[] {"Meter", "Centimeter", "Kilometer"};
            var lengthUnitCount = Enum.GetValues(typeof(LengthUnit)).Length - 1; // Exclude LengthUnit.Undefined

            QuantityInfo quantityInfo = Quantity.GetInfo(QuantityType.Length);

            Assert.Equal("Length", quantityInfo.Name);
            Assert.Equal(QuantityType.Length, quantityInfo.QuantityType);
            // Obsolete members
#pragma warning disable 618
            Assert.Superset(knownLengthUnitNames.ToHashSet(), quantityInfo.UnitNames.ToHashSet());
            Assert.Superset(knownLengthUnits.ToHashSet(), quantityInfo.Units.ToHashSet());
            Assert.Equal(lengthUnitCount, quantityInfo.UnitNames.Length);
            Assert.Equal(lengthUnitCount, quantityInfo.Units.Length);
#pragma warning restore 618
            Assert.Equal(typeof(LengthUnit), quantityInfo.UnitType);
            Assert.Equal(typeof(Length), quantityInfo.ValueType);
            Assert.Equal(Length.Zero, quantityInfo.Zero);
        }

        [Fact]
        public void GetInfo_GivenMass_ReturnsQuantityInfoForMass()
        {
            var knownMassUnits = new Enum[] {MassUnit.Kilogram, MassUnit.Gram, MassUnit.Tonne};
            var knownMassUnitNames = new[] {"Kilogram", "Gram", "Tonne"};
            var massUnitCount = Enum.GetValues(typeof(MassUnit)).Length - 1; // Exclude MassUnit.Undefined

            QuantityInfo quantityInfo = Quantity.GetInfo(QuantityType.Mass);

            Assert.Equal("Mass", quantityInfo.Name);
            Assert.Equal(QuantityType.Mass, quantityInfo.QuantityType);
            // Obsolete members
#pragma warning disable 618
            Assert.Superset(knownMassUnitNames.ToHashSet(), quantityInfo.UnitNames.ToHashSet());
            Assert.Superset(knownMassUnits.ToHashSet(), quantityInfo.Units.ToHashSet());
            Assert.Equal(massUnitCount, quantityInfo.UnitNames.Length);
            Assert.Equal(massUnitCount, quantityInfo.Units.Length);
#pragma warning restore 618
            Assert.Equal(typeof(MassUnit), quantityInfo.UnitType);
            Assert.Equal(typeof(Mass), quantityInfo.ValueType);
            Assert.Equal(Mass.Zero, quantityInfo.Zero);
        }

        [Fact]
        public void Infos_ReturnsKnownQuantityInfoObjects()
        {
            var knownQuantityInfos = new[]
            {
                Quantity.GetInfo(QuantityType.Length),
                Quantity.GetInfo(QuantityType.Force),
                Quantity.GetInfo(QuantityType.Mass)
            };

            var infos = Quantity.Infos;

            Assert.Superset(knownQuantityInfos.ToHashSet(), infos.ToHashSet());
            Assert.Equal(QuantityCount, infos.Length);
        }

        [Fact]
        public void Parse_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.Equal(Length.FromCentimeters(3), Quantity.Parse(CultureInfo.InvariantCulture, typeof(Length), "3 cm"));
            Assert.Equal(Mass.FromTonnes(3), Quantity.Parse(CultureInfo.InvariantCulture, typeof(Mass), "03t"));
            Assert.Equal(Pressure.FromMegabars(3), Quantity.Parse(CultureInfo.InvariantCulture, typeof(Pressure), "3.0 Mbar"));
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
            Assert.True(Quantity.TryFrom(3, LengthUnit.Centimeter, out IQuantity parsedLength));
            Assert.Equal(Length.FromCentimeters(3), parsedLength);

            Assert.True(Quantity.TryFrom(3, MassUnit.Tonne, out IQuantity parsedMass));
            Assert.Equal(Mass.FromTonnes(3), parsedMass);

            Assert.True(Quantity.TryFrom(3, PressureUnit.Megabar, out IQuantity parsedPressure));
            Assert.Equal(Pressure.FromMegabars(3), parsedPressure);
        }

        [Fact]
        public void TryParse_GivenInvalidQuantityType_ReturnsFalseAndNullQuantity()
        {
            Assert.False(Quantity.TryParse(typeof(DummyIQuantity), "3.0 cm", out IQuantity parsedLength));
            Assert.Null(parsedLength);
        }

        [Fact]
        public void TryParse_GivenInvalidString_ReturnsFalseAndNullQuantity()
        {
            Assert.False(Quantity.TryParse(typeof(Length), "x cm", out IQuantity parsedLength));
            Assert.Null(parsedLength);

            Assert.False(Quantity.TryParse(typeof(Mass), "xt", out IQuantity parsedMass));
            Assert.Null(parsedMass);

            Assert.False(Quantity.TryParse(typeof(Pressure), "foo", out IQuantity parsedPressure));
            Assert.Null(parsedPressure);
        }

        [Fact]
        public void TryParse_GivenValueAndUnit_ReturnsQuantity()
        {
            Assert.True(Quantity.TryParse(typeof(Length), "3 cm", out IQuantity parsedLength));
            Assert.Equal(Length.FromCentimeters(3), parsedLength);

            Assert.True(Quantity.TryParse(typeof(Mass), "03t", out IQuantity parsedMass));
            Assert.Equal(Mass.FromTonnes(3), parsedMass);

            Assert.True(Quantity.TryParse(typeof(Pressure), "3.0 Mbar", out IQuantity parsedPressure));
            Assert.Equal(Pressure.FromMegabars(3), parsedPressure);
        }

        [Fact]
        public void Types_ReturnsKnownQuantityTypes()
        {
            var knownQuantities = new[] {QuantityType.Length, QuantityType.Force, QuantityType.Mass};

            var types = Quantity.Types;

            Assert.Superset(knownQuantities.ToHashSet(), types.ToHashSet());
            Assert.Equal(QuantityCount, types.Length);
        }

        [Fact]
        public void FromQuantityType_GivenUndefinedQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Quantity.FromQuantityType(QuantityType.Undefined, 0.0));
        }

        [Fact]
        public void FromQuantityType_GivenInvalidQuantityType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Quantity.FromQuantityType((QuantityType)(-1), 0.0));
        }

        [Fact]
        public void FromQuantityType_GivenLengthQuantityType_ReturnsLengthQuantity()
        {
            var fromQuantity = Quantity.FromQuantityType(QuantityType.Length, 0.0);

            Assert.Equal(0.0, fromQuantity.Value);
            Assert.Equal(QuantityType.Length, fromQuantity.Type);
            Assert.Equal(Length.BaseUnit, fromQuantity.Unit);
        }
    }
}
