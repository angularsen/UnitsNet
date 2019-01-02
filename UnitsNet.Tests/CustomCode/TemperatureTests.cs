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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Xunit;
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomCode
{
    public class TemperatureTests : TemperatureTestsBase
    {
        protected override double DegreesCelsiusInOneKelvin => -272.15;

        protected override double DegreesDelisleInOneKelvin => 558.2249999999999;

        protected override double DegreesFahrenheitInOneKelvin => -457.87;

        protected override double DegreesNewtonInOneKelvin => -89.8095;

        protected override double DegreesRankineInOneKelvin => 1.8;

        protected override double DegreesReaumurInOneKelvin => -217.72;

        protected override double DegreesRoemerInOneKelvin => -135.378750000;

        protected override double KelvinsInOneKelvin => 1;

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, 1, "10 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, 5, "2 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, -10, "-1 °C")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, 1, "10 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, 5, "2 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, -10, "-1 °F")]
        public void DividedByTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int divisor, string expected)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);

            // Act
            Temperature resultTemp = temperature.Divide(divisor, unit);

            string actual = resultTemp.ToUnit(unit).ToString(CultureInfo.InvariantCulture, "{0:0} {1}");
            Assert.Equal(expected, actual);
        }

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, 0, "0 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, 5, "50 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 10, -5, "-50 °C")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, 0, "0 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, 5, "50 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 10, -5, "-50 °F")]
        public void MultiplyByTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int factor, string expected)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);

            // Act
            Temperature resultTemp = temperature.Multiply(factor, unit);

            string actual = resultTemp.ToUnit(unit).ToString(CultureInfo.InvariantCulture, "{0:0} {1}");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 0, "-10 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 10, "0 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 20, "10 °C")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 0, "-10 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 10, "0 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 20, "10 °F")]
        public void TemperatureDeltaPlusTemperatureEqualsTemperature(TemperatureUnit unit, int deltaVal, int temperatureVal, string expected)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit)Enum.Parse(typeof(TemperatureDeltaUnit), unit.ToString()));

            // Act
            Temperature resultTemp = delta + temperature;

            string actual = resultTemp.ToUnit(unit).ToString(CultureInfo.InvariantCulture, "{0:0} {1}");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(TemperatureUnit.DegreeCelsius, 20, 10, "10 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 20, 20, "0 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, 20, 30, "-10 °C")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 20, 10, "10 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 20, 20, "0 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, 20, 30, "-10 °F")]
        public void TemperatureMinusTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int deltaVal, string expected)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit)Enum.Parse(typeof(TemperatureDeltaUnit), unit.ToString()));

            // Act
            Temperature resultTemp = temperature - delta;

            string actual = resultTemp.ToUnit(unit).ToString(CultureInfo.InvariantCulture, "{0:0} {1}");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 0, "-10 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 10, "0 °C")]
        [InlineData(TemperatureUnit.DegreeCelsius, -10, 20, "10 °C")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 0, "-10 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 10, "0 °F")]
        [InlineData(TemperatureUnit.DegreeFahrenheit, -10, 20, "10 °F")]
        public void TemperaturePlusTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int deltaVal, string expected)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit)Enum.Parse(typeof(TemperatureDeltaUnit), unit.ToString()));

            // Act
            Temperature resultTemp = temperature + delta;

            string actual = resultTemp.ToUnit(unit).ToString(CultureInfo.InvariantCulture, "{0:0} {1}");
            Assert.Equal(expected, actual);
        }
    }
}
