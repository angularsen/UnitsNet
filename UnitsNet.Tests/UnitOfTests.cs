// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using System.Reflection;
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
    public void BuiltInUnit_HasTheNamesOfTheUnit()
    {
        Assert.Equal("Foot", LengthUnits.Foot.Name);
        Assert.Equal("Feet", LengthUnits.Foot.PluralName);
    }

    [Fact]
    public void BuiltInUnit_IsTheSameInstanceEveryTime()
    {
        Assert.Same(LengthUnits.Foot, LengthUnits.Foot);
    }

    [Fact]
    public void As_BuiltInUnit_ReturnsSameValueAsUnitEnum()
    {
        Length length = Length.FromMeters(3);

        Assert.Equal(length.Feet, length.As(LengthUnits.Foot));
    }

    [Fact]
    public void As_BuiltInAffineUnit_ReturnsSameValueAsUnitEnum()
    {
        Temperature temperature = Temperature.FromDegreesCelsius(37);

        Assert.Equal(temperature.DegreesFahrenheit, temperature.As(TemperatureUnits.DegreeFahrenheit));
    }

    [Fact]
    public void From_BuiltInUnit_ReturnsQuantityInThatUnit()
    {
        Length length = Length.Info.From(2, LengthUnits.Foot);

        Assert.Equal(Length.FromFeet(2), length);
        Assert.Equal(LengthUnit.Foot, length.Unit);
    }

    [Fact]
    public void BuiltInUnits_MatchTheUnitEnumOfEveryQuantity()
    {
        Assert.All(Quantity.Infos, quantityInfo =>
        {
            Type unitsType = typeof(LengthUnits).Assembly.GetType($"UnitsNet.Units.{quantityInfo.Name}Units", throwOnError: true)!;
            FieldInfo[] fields = unitsType.GetFields(BindingFlags.Public | BindingFlags.Static);

            Assert.Equal(quantityInfo.UnitInfos.Select(unitInfo => unitInfo.Name).OrderBy(name => name),
                fields.Select(field => field.Name).OrderBy(name => name));
            Assert.All(quantityInfo.UnitInfos, unitInfo =>
            {
                object unit = fields.Single(field => field.Name == unitInfo.Name).GetValue(null)!;
                Assert.Equal(typeof(UnitOf<>).MakeGenericType(quantityInfo.QuantityType), unit.GetType());

                var definition = (IUnitDefinition)unit;
                Assert.Equal(unitInfo.Name, definition.Name);
                Assert.Equal(unitInfo.PluralName, definition.PluralName);
                Assert.Equal(unitInfo.BaseUnits, definition.BaseUnits);
                Assert.Equal(unitInfo.ConversionFromBase.Evaluate(QuantityValue.One), definition.ConversionFromBase.Evaluate(QuantityValue.One));
            });
        });
    }

    [Fact]
    public void From_NullUnit_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Length.Info.From(1, (UnitOf<Length>)null!));
    }
}
