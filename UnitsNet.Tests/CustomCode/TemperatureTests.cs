// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

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

        protected override double SolarTemperaturesInOneKelvin => 1.73070266528210E-04;

        public static IEnumerable<object[]> DividedByTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature.FromDegreesCelsius(10), 1, Temperature.FromDegreesCelsius(10) },
                new object[] { Temperature.FromDegreesCelsius(10), 5, Temperature.FromDegreesCelsius(2) },
                new object[] { Temperature.FromDegreesCelsius(10), -10, Temperature.FromDegreesCelsius(-1) },
                new object[] { Temperature.FromDegreesFahrenheit(10), 1, Temperature.FromDegreesFahrenheit(10) },
                new object[] { Temperature.FromDegreesFahrenheit(10), 5, Temperature.FromDegreesFahrenheit(2) },
                new object[] { Temperature.FromDegreesFahrenheit(10), -10, Temperature.FromDegreesFahrenheit(-1) }
            };

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [MemberData(nameof(DividedByTemperatureDeltaEqualsTemperatureData))]
        public void DividedByTemperatureDeltaEqualsTemperature(Temperature temperature, int divisor, Temperature expected)
        {
            Temperature resultTemp = temperature.Divide(divisor, temperature.Unit);
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> MultiplyByTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature.FromDegreesCelsius(10), 0, Temperature.FromDegreesCelsius(0) },
                new object[] { Temperature.FromDegreesCelsius(10), 5, Temperature.FromDegreesCelsius(50) },
                new object[] { Temperature.FromDegreesCelsius(10), -5, Temperature.FromDegreesCelsius(-50) },
                new object[] { Temperature.FromDegreesFahrenheit(10), 0, Temperature.FromDegreesFahrenheit(0) },
                new object[] { Temperature.FromDegreesFahrenheit(10), 5, Temperature.FromDegreesFahrenheit(50) },
                new object[] { Temperature.FromDegreesFahrenheit(10), -5, Temperature.FromDegreesFahrenheit(-50) }
            };

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [MemberData(nameof(MultiplyByTemperatureDeltaEqualsTemperatureData))]
        public void MultiplyByTemperatureDeltaEqualsTemperature(Temperature temperature, int factor, Temperature expected)
        {
            Temperature resultTemp = temperature.Multiply(factor, temperature.Unit);
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperatureDeltaPlusTemperatureEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(0), Temperature.FromDegreesCelsius(-10) },
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(10), Temperature.FromDegreesCelsius(0) },
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(20), Temperature.FromDegreesCelsius(10) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(0), Temperature.FromDegreesFahrenheit(-10) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(10), Temperature.FromDegreesFahrenheit(0) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(20), Temperature.FromDegreesFahrenheit(10) }
            };

        [Theory]
        [MemberData(nameof(TemperatureDeltaPlusTemperatureEqualsTemperatureData))]
        public void TemperatureDeltaPlusTemperatureEqualsTemperature(Temperature temperature, TemperatureDelta delta, Temperature expected)
        {
            Temperature resultTemp = delta + temperature;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperatureMinusTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature.FromDegreesCelsius(20), TemperatureDelta.FromDegreesCelsius(10), Temperature.FromDegreesCelsius(10) },
                new object[] { Temperature.FromDegreesCelsius(20), TemperatureDelta.FromDegreesCelsius(20), Temperature.FromDegreesCelsius(0) },
                new object[] { Temperature.FromDegreesCelsius(20), TemperatureDelta.FromDegreesCelsius(30), Temperature.FromDegreesCelsius(-10) },
                new object[] { Temperature.FromDegreesFahrenheit(20), TemperatureDelta.FromDegreesFahrenheit(10), Temperature.FromDegreesFahrenheit(10) },
                new object[] { Temperature.FromDegreesFahrenheit(20), TemperatureDelta.FromDegreesFahrenheit(20), Temperature.FromDegreesFahrenheit(0) },
                new object[] { Temperature.FromDegreesFahrenheit(20), TemperatureDelta.FromDegreesFahrenheit(30), Temperature.FromDegreesFahrenheit(-10) }
            };

        [Theory]
        [MemberData(nameof(TemperatureMinusTemperatureDeltaEqualsTemperatureData))]
        public void TemperatureMinusTemperatureDeltaEqualsTemperature(Temperature temperature, TemperatureDelta delta, Temperature expected)
        {
            Temperature resultTemp = temperature - delta;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperaturePlusTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(0), Temperature.FromDegreesCelsius(-10) },
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(10), Temperature.FromDegreesCelsius(0) },
                new object[] { Temperature.FromDegreesCelsius(-10), TemperatureDelta.FromDegreesCelsius(20), Temperature.FromDegreesCelsius(10) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(0), Temperature.FromDegreesFahrenheit(-10) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(10), Temperature.FromDegreesFahrenheit(0) },
                new object[] { Temperature.FromDegreesFahrenheit(-10), TemperatureDelta.FromDegreesFahrenheit(20), Temperature.FromDegreesFahrenheit(10) }
            };



        [Theory]
        [MemberData(nameof(TemperaturePlusTemperatureDeltaEqualsTemperatureData))]
        public void TemperaturePlusTemperatureDeltaEqualsTemperature(Temperature temperature, TemperatureDelta delta, Temperature expected)
        {
            Temperature resultTemp = temperature + delta;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }
    }
}
