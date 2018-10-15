// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitSystemTests
    {
        [Fact]
        public void Constructor()
        {
            var siBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            var unitSystem = new UnitSystem(siBaseUnits);

            Assert.Equal(unitSystem.BaseUnits, siBaseUnits);
        }

        [Fact]
        public void SIUnitSystemHasCorrectBaseUnits()
        {
            var siBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            Assert.Equal(LengthUnit.Meter, UnitSystem.SI.BaseUnits.Length);
            Assert.Equal(MassUnit.Kilogram, UnitSystem.SI.BaseUnits.Mass);
            Assert.Equal(DurationUnit.Second, UnitSystem.SI.BaseUnits.Time);
            Assert.Equal(ElectricCurrentUnit.Ampere, UnitSystem.SI.BaseUnits.Current);
            Assert.Equal(TemperatureUnit.Kelvin, UnitSystem.SI.BaseUnits.Temperature);
            Assert.Equal(AmountOfSubstanceUnit.Mole, UnitSystem.SI.BaseUnits.Amount);
            Assert.Equal(LuminousIntensityUnit.Candela, UnitSystem.SI.BaseUnits.LuminousIntensity);
        }
    }
}
