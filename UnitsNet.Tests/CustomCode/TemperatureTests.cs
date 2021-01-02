// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class TemperatureTests : TemperatureTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
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

        public static IEnumerable<object[]> DividedByTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature<double>.FromDegreesCelsius(10), 1, Temperature<double>.FromDegreesCelsius(10) },
                new object[] { Temperature<double>.FromDegreesCelsius(10), 5, Temperature<double>.FromDegreesCelsius(2) },
                new object[] { Temperature<double>.FromDegreesCelsius(10), -10, Temperature<double>.FromDegreesCelsius(-1) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), 1, Temperature<double>.FromDegreesFahrenheit(10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), 5, Temperature<double>.FromDegreesFahrenheit(2) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), -10, Temperature<double>.FromDegreesFahrenheit(-1) }
            };

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [MemberData(nameof(DividedByTemperatureDeltaEqualsTemperatureData))]
        public void DividedByTemperatureDeltaEqualsTemperature(Temperature<double> temperature, int divisor, Temperature<double> expected )
        {
            Temperature<double> resultTemp = temperature.Divide(divisor, temperature.Unit);
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> MultiplyByTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature<double>.FromDegreesCelsius(10), 0, Temperature<double>.FromDegreesCelsius(0) },
                new object[] { Temperature<double>.FromDegreesCelsius(10), 5, Temperature<double>.FromDegreesCelsius(50) },
                new object[] { Temperature<double>.FromDegreesCelsius(10), -5, Temperature<double>.FromDegreesCelsius(-50) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), 0, Temperature<double>.FromDegreesFahrenheit(0) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), 5, Temperature<double>.FromDegreesFahrenheit(50) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(10), -5, Temperature<double>.FromDegreesFahrenheit(-50) }
            };

        [SuppressMessage("ReSharper", "ImpureMethodCallOnReadonlyValueField",
            Justification = "R# incorrectly identifies method as impure, due to internal method calls.")]
        [Theory]
        [MemberData(nameof(MultiplyByTemperatureDeltaEqualsTemperatureData))]
        public void MultiplyByTemperatureDeltaEqualsTemperature(Temperature<double> temperature, int factor, Temperature<double> expected )
        {
            Temperature<double> resultTemp = temperature.Multiply(factor, temperature.Unit);
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperatureDeltaPlusTemperatureEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(0), Temperature<double>.FromDegreesCelsius(-10) },
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(10), Temperature<double>.FromDegreesCelsius(0) },
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(20), Temperature<double>.FromDegreesCelsius(10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(0), Temperature<double>.FromDegreesFahrenheit(-10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(10), Temperature<double>.FromDegreesFahrenheit(0) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(20), Temperature<double>.FromDegreesFahrenheit(10) }
            };

        [Theory]
        [MemberData(nameof(TemperatureDeltaPlusTemperatureEqualsTemperatureData))]
        public void TemperatureDeltaPlusTemperatureEqualsTemperature(Temperature<double> temperature, TemperatureDelta<double> delta, Temperature<double> expected )
        {
            var resultTemp = delta + temperature;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperatureMinusTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature<double>.FromDegreesCelsius(20), TemperatureDelta<double>.FromDegreesCelsius(10), Temperature<double>.FromDegreesCelsius(10) },
                new object[] { Temperature<double>.FromDegreesCelsius(20), TemperatureDelta<double>.FromDegreesCelsius(20), Temperature<double>.FromDegreesCelsius(0) },
                new object[] { Temperature<double>.FromDegreesCelsius(20), TemperatureDelta<double>.FromDegreesCelsius(30), Temperature<double>.FromDegreesCelsius(-10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(20), TemperatureDelta<double>.FromDegreesFahrenheit(10), Temperature<double>.FromDegreesFahrenheit(10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(20), TemperatureDelta<double>.FromDegreesFahrenheit(20), Temperature<double>.FromDegreesFahrenheit(0) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(20), TemperatureDelta<double>.FromDegreesFahrenheit(30), Temperature<double>.FromDegreesFahrenheit(-10) }
            };

        [Theory]
        [MemberData(nameof(TemperatureMinusTemperatureDeltaEqualsTemperatureData))]
        public void TemperatureMinusTemperatureDeltaEqualsTemperature(Temperature<double> temperature, TemperatureDelta<double> delta, Temperature<double> expected )
        {
            var resultTemp = temperature - delta;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }

        public static IEnumerable<object[]> TemperaturePlusTemperatureDeltaEqualsTemperatureData { get; } =
            new List<object[]>
            {
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(0), Temperature<double>.FromDegreesCelsius(-10) },
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(10), Temperature<double>.FromDegreesCelsius(0) },
                new object[] { Temperature<double>.FromDegreesCelsius(-10), TemperatureDelta<double>.FromDegreesCelsius(20), Temperature<double>.FromDegreesCelsius(10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(0), Temperature<double>.FromDegreesFahrenheit(-10) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(10), Temperature<double>.FromDegreesFahrenheit(0) },
                new object[] { Temperature<double>.FromDegreesFahrenheit(-10), TemperatureDelta<double>.FromDegreesFahrenheit(20), Temperature<double>.FromDegreesFahrenheit(10) }
            };



        [Theory]
        [MemberData(nameof(TemperaturePlusTemperatureDeltaEqualsTemperatureData))]
        public void TemperaturePlusTemperatureDeltaEqualsTemperature(Temperature<double> temperature, TemperatureDelta<double> delta, Temperature<double> expected )
        {
            var resultTemp = temperature + delta;
            Assert.True(expected.Equals(resultTemp, 1e-5, ComparisonType.Absolute));
        }
    }
}
