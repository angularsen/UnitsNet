// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
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

        protected override double MillidegreesCelsiusInOneKelvin => -272150;

        protected override double SolarTemperaturesInOneKelvin => 1.73070266528210E-04;
        
        [Fact]
        public void AllBaseQuantityUnitsAreBaseUnits()
        {
            Assert.All(Temperature.Info.UnitInfos, unitInfo => Assert.Equal(new BaseUnits(temperature: unitInfo.Value), unitInfo.BaseUnits));
        }

        public static IEnumerable<object[]> DividedByTemperatureDeltaEqualsTemperatureData { get; } = new[]
        {
            new object[] { (10m, TemperatureUnit.DegreeCelsius), 1, (10m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeCelsius), 5, (2m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeCelsius), -10, (-1m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), 1, (10m, TemperatureUnit.DegreeFahrenheit) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), 5, (2m, TemperatureUnit.DegreeFahrenheit) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), -10, (-1m, TemperatureUnit.DegreeFahrenheit) }
        };

        [Theory]
        [MemberData(nameof(DividedByTemperatureDeltaEqualsTemperatureData))]
        public void DividedByTemperatureDeltaEqualsTemperature((decimal Value, TemperatureUnit Unit) temperature, decimal divisor,
            (decimal Value, TemperatureUnit Unit) expected)
        {
            var temp = new Temperature(temperature.Value, temperature.Unit);
            Temperature result = temp.Divide(divisor, temperature.Unit);
            Assert.Equal(expected.Value, result.Value);
            Assert.Equal(expected.Unit, result.Unit);
        }

        public static IEnumerable<object[]> MultiplyByTemperatureDeltaEqualsTemperatureData { get; } = new[]
        {
            new object[] { (10m, TemperatureUnit.DegreeCelsius), 0, (0m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeCelsius), 5, (50m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeCelsius), -5, (-50m, TemperatureUnit.DegreeCelsius) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), 0, (0m, TemperatureUnit.DegreeFahrenheit) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), 5, (50m, TemperatureUnit.DegreeFahrenheit) },
            new object[] { (10m, TemperatureUnit.DegreeFahrenheit), -5, (-50m, TemperatureUnit.DegreeFahrenheit) }
        };

        [Theory]
        [MemberData(nameof(MultiplyByTemperatureDeltaEqualsTemperatureData))]
        public void MultiplyByTemperatureDeltaEqualsTemperature((decimal Value, TemperatureUnit Unit) temperature, decimal factor,
            (decimal Value, TemperatureUnit Unit) expected)
        {
            var temp = new Temperature(temperature.Value, temperature.Unit);
            var result = temp.Multiply(factor, temperature.Unit);;
            Assert.Equal(expected.Value, result.Value);
            Assert.Equal(expected.Unit, result.Unit);
        }

        public static IEnumerable<object[]> TemperatureDeltaPlusTemperatureEqualsTemperatureData { get; } = new[]
        {
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 0m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 0m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit }
        };

        [Theory]
        [MemberData(nameof(TemperatureDeltaPlusTemperatureEqualsTemperatureData))]
        public void TemperatureDeltaPlusTemperatureEqualsTemperature(decimal temperatureValue, TemperatureUnit temperatureUnit, decimal deltaValue,
            TemperatureDeltaUnit deltaUnit, decimal expectedValue, TemperatureUnit expectedUnit)
        {
            var temperature = new Temperature(temperatureValue, temperatureUnit);
            var temperatureDelta = new TemperatureDelta(deltaValue, deltaUnit);
            var expectedTemperature = new Temperature(expectedValue, expectedUnit);
            
            Temperature result = temperature + temperatureDelta;
            
            Assert.Equal(expectedTemperature, result);
        }

        public static IEnumerable<object[]> TemperatureMinusTemperatureDeltaEqualsTemperatureData { get; } = new[]
        {
            new object[] { 20m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius },
            new object[] { 20m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius },
            new object[] { 20m, TemperatureUnit.DegreeCelsius, 30m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius },
            new object[] { 20m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit },
            new object[] { 20m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit },
            new object[] { 20m, TemperatureUnit.DegreeFahrenheit, 30m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit }
        };

        [Theory]
        [MemberData(nameof(TemperatureMinusTemperatureDeltaEqualsTemperatureData))]
        public void TemperatureMinusTemperatureDeltaEqualsTemperature(decimal temperatureValue, TemperatureUnit temperatureUnit, decimal deltaValue,
            TemperatureDeltaUnit deltaUnit, decimal expectedValue, TemperatureUnit expectedUnit)
        {
            var temp = new Temperature(temperatureValue, temperatureUnit);
            var delta = new TemperatureDelta(deltaValue, deltaUnit);
            var expectedTemperature = new Temperature(expectedValue, expectedUnit);
            
            Temperature result = temp - delta;
            
            Assert.Equal(expectedTemperature, result);
        }

        public static IEnumerable<object[]> TemperaturePlusTemperatureDeltaEqualsTemperatureData { get; } = new[]
        {
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 0m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 0m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit },
            new object[] { -10m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit }
        };

        [Theory]
        [MemberData(nameof(TemperaturePlusTemperatureDeltaEqualsTemperatureData))]
        public void TemperaturePlusTemperatureDeltaEqualsTemperature(decimal temperatureValue, TemperatureUnit temperatureUnit, decimal deltaValue,
            TemperatureDeltaUnit deltaUnit, decimal expectedValue, TemperatureUnit expectedUnit)
        {
            var temp = new Temperature(temperatureValue, temperatureUnit);
            var delta = new TemperatureDelta(deltaValue, deltaUnit);
            var expectedTemperature = new Temperature(expectedValue, expectedUnit);
            
            Temperature result = temp + delta;
            
            Assert.Equal(expectedTemperature, result);
        }
    }
}
