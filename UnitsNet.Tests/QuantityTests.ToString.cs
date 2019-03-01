// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    [Collection(nameof(UnitAbbreviationsCacheFixture))]
    public partial class QuantityTests
    {
        public class ToStringTests
        {
            [Fact]
            public void CreatedByDefaultCtor_ReturnsValueInBaseUnit()
            {
                // double types
                Assert.Equal("0 kg", new Mass().ToString());

                // decimal types
                Assert.Equal("0 b", new Information().ToString());

                // logarithmic types
                Assert.Equal("0 dB", new Level().ToString());
            }

            [Fact]
            public void CreatedByCtorWithValue_ReturnsValueInBaseUnit()
            {
#pragma warning disable 618
                // double types
                Assert.Equal("5 kg", new Mass(5L, MassUnit.Kilogram).ToString());
                Assert.Equal("5 kg", new Mass(5d, MassUnit.Kilogram).ToString());

                // decimal types
                Assert.Equal("5 b", new Information(5L, InformationUnit.Bit).ToString());
                Assert.Equal("5 b", new Information(5m, InformationUnit.Bit).ToString());

                // logarithmic types
                Assert.Equal("5 dB", new Level(5L, LevelUnit.Decibel).ToString());
                Assert.Equal("5 dB", new Level(5d, LevelUnit.Decibel).ToString());
#pragma warning restore 618
            }

            [Fact]
            public void CreatedByCtorWithValueAndUnit_ReturnsValueAndUnit()
            {
#pragma warning disable 618
                // double types
                Assert.Equal("5 hg", new Mass(5, MassUnit.Hectogram).ToString());

                // decimal types
                Assert.Equal("8 B", new Information(8, InformationUnit.Byte).ToString());

                // logarithmic types
                Assert.Equal("5 Np", new Level(5, LevelUnit.Neper).ToString());
#pragma warning restore 618
            }

            [Fact]
            public void ReturnsTheOriginalValueAndUnit()
            {
                var oldCulture = CultureInfo.CurrentUICulture;
                try
                {
                    CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                    Assert.Equal("5 kg", Mass.FromKilograms(5).ToString());
                    Assert.Equal("5,000 g", Mass.FromGrams(5000).ToString());
                    Assert.Equal("1e-04 long tn", Mass.FromLongTons(1e-4).ToString());
                    Assert.Equal("3.46e-04 dN/m", ForcePerLength.FromDecinewtonsPerMeter(0.00034567).ToString());
                    Assert.Equal("0.0069 dB", Level.FromDecibels(0.0069).ToString());
                    Assert.Equal("0.011 kWh/kg", SpecificEnergy.FromKilowattHoursPerKilogram(0.011).ToString());
                    //                Assert.Equal("0.1 MJ/kg·C", SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(0.1).ToString());
                    Assert.Equal("0.1 MJ/kg.C", SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(0.1).ToString());
                    Assert.Equal("5 cm", Length.FromCentimeters(5).ToString());
                }
                finally
                {
                    CultureInfo.CurrentUICulture = oldCulture;
                }
            }

            [Fact]
            public void ConvertsToTheGivenUnit()
            {
                var oldCulture = CultureInfo.CurrentUICulture;
                try
                {
                    CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                    Assert.Equal("5,000 g", Mass.FromKilograms(5).ToUnit(MassUnit.Gram).ToString());
                    Assert.Equal("5 kg", Mass.FromGrams(5000).ToUnit(MassUnit.Kilogram).ToString());
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToUnit(LengthUnit.Meter).ToString());
                    Assert.Equal("1.97 in", Length.FromCentimeters(5).ToUnit(LengthUnit.Inch).ToString());
                }
                finally
                {
                    CultureInfo.CurrentUICulture = oldCulture;
                }
            }

            [Fact]
            public void FormatsNumberUsingGivenCulture()
            {
                var oldCulture = CultureInfo.CurrentUICulture;
                try
                {
                    CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToUnit(LengthUnit.Meter).ToString((IFormatProvider)null));
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToUnit(LengthUnit.Meter).ToString(CultureInfo.InvariantCulture));
                    Assert.Equal("0,05 m", Length.FromCentimeters(5).ToUnit(LengthUnit.Meter).ToString(new CultureInfo("nb-NO")));
                }
                finally
                {
                    CultureInfo.CurrentUICulture = oldCulture;
                }
            }

            [Fact]
            public void FormatsNumberUsingGivenDigitsAfterRadix()
            {
                var oldCulture = CultureInfo.CurrentUICulture;
                try
                {
                    CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToUnit(LengthUnit.Meter).ToString("s4"));
                    Assert.Equal("1.97 in", Length.FromCentimeters(5).ToUnit(LengthUnit.Inch).ToString("s2"));
                    Assert.Equal("1.9685 in", Length.FromCentimeters(5).ToUnit(LengthUnit.Inch).ToString("s4"));
                }
                finally
                {
                    CultureInfo.CurrentUICulture = oldCulture;
                }
            }
        }
    }
}
