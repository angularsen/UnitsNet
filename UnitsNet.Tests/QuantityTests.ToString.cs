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

using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public partial class QuantityTests
    {
        public class ToString
        {
            [Fact]
            public void ReturnsTheOriginalValueAndUnit()
            {
                var oldCulture = UnitSystem.DefaultCulture;
                try
                {
                    UnitSystem.DefaultCulture = CultureInfo.InvariantCulture;
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
                    UnitSystem.DefaultCulture = oldCulture;
                }
            }

            [Fact]
            public void ConvertsToTheGivenUnit()
            {
                var oldCulture = UnitSystem.DefaultCulture;
                try
                {
                    UnitSystem.DefaultCulture = CultureInfo.InvariantCulture;
                    Assert.Equal("5,000 g", Mass.FromKilograms(5).ToString(MassUnit.Gram));
                    Assert.Equal("5 kg", Mass.FromGrams(5000).ToString(MassUnit.Kilogram));
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToString(LengthUnit.Meter));
                    Assert.Equal("1.97 in", Length.FromCentimeters(5).ToString(LengthUnit.Inch));
                }
                finally
                {
                    UnitSystem.DefaultCulture = oldCulture;
                }
            }

            [Fact]
            public void FormatsNumberUsingGivenCulture()
            {
                var oldCulture = UnitSystem.DefaultCulture;
                try
                {
                    UnitSystem.DefaultCulture = CultureInfo.InvariantCulture;
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToString(LengthUnit.Meter, null));
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToString(LengthUnit.Meter, CultureInfo.InvariantCulture));
                    Assert.Equal("0,05 m", Length.FromCentimeters(5).ToString(LengthUnit.Meter, new CultureInfo("nb-NO")));
                }
                finally
                {
                    UnitSystem.DefaultCulture = oldCulture;
                }
            }

            [Fact]
            public void FormatsNumberUsingGivenDigitsAfterRadix()
            {
                var oldCulture = UnitSystem.DefaultCulture;
                try
                {
                    UnitSystem.DefaultCulture = CultureInfo.InvariantCulture;
                    Assert.Equal("0.05 m", Length.FromCentimeters(5).ToString(LengthUnit.Meter, null, 4));
                    Assert.Equal("1.97 in", Length.FromCentimeters(5).ToString(LengthUnit.Inch, null, 2));
                    Assert.Equal("1.9685 in", Length.FromCentimeters(5).ToString(LengthUnit.Inch, null, 4));
                }
                finally
                {
                    UnitSystem.DefaultCulture = oldCulture;
                }
            }
        }
    }
}
