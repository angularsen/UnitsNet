// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests;

public class UnitOfTests
{
    // 1 furlong = 201.168 m
    private static readonly UnitOf<Length> Furlong = new("Furlong", "Furlongs", 201.168);

    // Same conversions as TemperatureUnit.DegreeFahrenheit, to compare against.
    private static readonly UnitOf<Temperature> Fahrenheit = new("Fahrenheit", "Fahrenheits",
        new ConversionExpression(coefficient: 1.8, constantTerm: -459.67),
        new ConversionExpression(coefficient: QuantityValue.FromTerms(5, 9), constantTerm: QuantityValue.FromTerms(45967, 180)));

    [Fact]
    public void Constructor_WithValueInBaseUnit_DerivesTheConversionFromBase()
    {
        Assert.Equal("Furlong", Furlong.Name);
        Assert.Equal("Furlongs", Furlong.PluralName);
        Assert.Equal<QuantityValue>(201.168m, Furlong.ConversionToBase.Evaluate(QuantityValue.One));
        Assert.Equal(QuantityValue.FromTerms(1000, 201168), Furlong.ConversionFromBase.Evaluate(QuantityValue.One));
    }

    [Fact]
    public void Constructor_WithNullArguments_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>(null!, "Furlongs", 1));
        Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>("Furlong", null!, 1));
        Assert.Throws<ArgumentNullException>(() => new UnitOf<Length>("Furlong", "Furlongs", (BaseUnits)null!, 1));
    }

    [Fact]
    public void BaseUnits_WhenNotGiven_IsUndefined()
    {
        Assert.Equal(BaseUnits.Undefined, Furlong.BaseUnits);
    }

    [Fact]
    public void Constructor_WithBaseUnits_KeepsThem()
    {
        var baseUnits = new BaseUnits(length: LengthUnit.Foot, time: DurationUnit.Day);
        var footPerDay = new UnitOf<Speed>("FootPerDay", "FeetPerDay", baseUnits, (Length.FromFeet(1) / Duration.FromDays(1)).MetersPerSecond);

        Assert.Equal(baseUnits, footPerDay.BaseUnits);
        Assert.Equal(baseUnits, ((IUnitDefinition)footPerDay).BaseUnits);
        Assert.Equal(new QuantityValue(86400), Speed.FromFeetPerSecond(1).As(footPerDay));
    }

    [Fact]
    public void ToString_ReturnsName()
    {
        Assert.Equal("Furlong", Furlong.ToString());
    }

    [Fact]
    public void As_ReturnsValueInThatUnit()
    {
        Assert.Equal(QuantityValue.One, Length.FromFeet(660).As(Furlong));
        Assert.Equal(new QuantityValue(8), Length.FromMiles(1).As(Furlong));
    }

    [Fact]
    public void As_AffineUnit_ReturnsValueInThatUnit()
    {
        Temperature temperature = Temperature.FromDegreesCelsius(37);

        Assert.Equal(temperature.DegreesFahrenheit, temperature.As(Fahrenheit));
    }

    [Fact]
    public void As_NullUnit_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Length.FromMeters(1).As((UnitOf<Length>)null!));
    }

    [Fact]
    public void From_ReturnsQuantityInBaseUnit()
    {
        Length length = Length.Info.From(2, Furlong);

        Assert.Equal(LengthUnit.Meter, length.Unit);
        Assert.Equal<QuantityValue>(402.336m, length.Value);
    }

    [Fact]
    public void From_AffineUnit_ReturnsQuantityInBaseUnit()
    {
        Temperature temperature = Temperature.Info.From(98.6, Fahrenheit);

        Assert.Equal(Temperature.BaseUnit, temperature.Unit);
        Assert.Equal(Temperature.FromDegreesFahrenheit(98.6).Kelvins, temperature.Value);
    }

    [Fact]
    public void From_RoundTripsWithAs()
    {
        Assert.Equal(new QuantityValue(42), Length.Info.From(42, Furlong).As(Furlong));
    }

    [Fact]
    public void From_NullUnit_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Length.Info.From(1, (UnitOf<Length>)null!));
    }
}
