// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
// https://github.com/anjdreas/UnitsNet
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

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using NUnit.Framework;
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

        [TestCase(TemperatureUnit.DegreeCelsius, -10, 0, ExpectedResult = "-10 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, -10, 10, ExpectedResult = "0 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, -10, 20, ExpectedResult = "10 °C")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 0, ExpectedResult = "-10 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 10, ExpectedResult = "0 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 20, ExpectedResult = "10 °F")]
        public string TemperatureDeltaPlusTemperatureEqualsTemperature(TemperatureUnit unit, int deltaVal, int temperatureVal)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit) unit);

            // Act
            Temperature resultTemp = delta + temperature;

            return resultTemp.ToString(unit, CultureInfo.InvariantCulture, "{0:0} {1}");
        }

        [TestCase(TemperatureUnit.DegreeCelsius, 20, 10, ExpectedResult = "10 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, 20, 20, ExpectedResult = "0 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, 20, 30, ExpectedResult = "-10 °C")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, 20, 10, ExpectedResult = "10 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, 20, 20, ExpectedResult = "0 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, 20, 30, ExpectedResult = "-10 °F")]
        public string TemperatureMinusTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int deltaVal)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit) unit);

            // Act
            Temperature resultTemp = temperature - delta;

            return resultTemp.ToString(unit, CultureInfo.InvariantCulture, "{0:0} {1}");
        }

        [TestCase(TemperatureUnit.DegreeCelsius, -10, 0, ExpectedResult = "-10 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, -10, 10, ExpectedResult = "0 °C")]
        [TestCase(TemperatureUnit.DegreeCelsius, -10, 20, ExpectedResult = "10 °C")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 0, ExpectedResult = "-10 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 10, ExpectedResult = "0 °F")]
        [TestCase(TemperatureUnit.DegreeFahrenheit, -10, 20, ExpectedResult = "10 °F")]
        public string TemperaturePlusTemperatureDeltaEqualsTemperature(TemperatureUnit unit, int temperatureVal, int deltaVal)
        {
            Temperature temperature = Temperature.From(temperatureVal, unit);
            TemperatureDelta delta = TemperatureDelta.From(deltaVal, (TemperatureDeltaUnit) unit);

            // Act
            Temperature resultTemp = temperature + delta;

            return resultTemp.ToString(unit, CultureInfo.InvariantCulture, "{0:0} {1}");
        }
    }
}