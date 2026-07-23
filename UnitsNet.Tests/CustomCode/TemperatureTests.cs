// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests;

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

    public static IEnumerable<object[]> TemperatureDeltaPlusTemperatureEqualsTemperatureData { get; } =
    [
        [-10m, TemperatureUnit.DegreeCelsius, 0m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeFahrenheit, 0m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit],
        [-10m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit],
        [-10m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit]
    ];

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

    public static IEnumerable<object[]> TemperatureMinusTemperatureDeltaEqualsTemperatureData { get; } =
    [
        [20m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius],
        [20m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius],
        [20m, TemperatureUnit.DegreeCelsius, 30m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius],
        [20m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit],
        [20m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit],
        [20m, TemperatureUnit.DegreeFahrenheit, 30m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit]
    ];

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

    public static IEnumerable<object[]> TemperaturePlusTemperatureDeltaEqualsTemperatureData { get; } =
    [
        [-10m, TemperatureUnit.DegreeCelsius, 0m, TemperatureDeltaUnit.DegreeCelsius, -10m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeCelsius, 10m, TemperatureDeltaUnit.DegreeCelsius, 0m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeCelsius, 20m, TemperatureDeltaUnit.DegreeCelsius, 10m, TemperatureUnit.DegreeCelsius],
        [-10m, TemperatureUnit.DegreeFahrenheit, 0m, TemperatureDeltaUnit.DegreeFahrenheit, -10m, TemperatureUnit.DegreeFahrenheit],
        [-10m, TemperatureUnit.DegreeFahrenheit, 10m, TemperatureDeltaUnit.DegreeFahrenheit, 0m, TemperatureUnit.DegreeFahrenheit],
        [-10m, TemperatureUnit.DegreeFahrenheit, 20m, TemperatureDeltaUnit.DegreeFahrenheit, 10m, TemperatureUnit.DegreeFahrenheit]
    ];

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
