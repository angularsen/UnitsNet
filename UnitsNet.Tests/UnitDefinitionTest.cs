// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests;

public class UnitDefinitionTest
{
    [Theory]
    [InlineData(LengthUnit.Meter, "Meters")]
    [InlineData(LengthUnit.Centimeter, "Centimeters")]
    [InlineData(LengthUnit.Millimeter, "Millimeters")]
    public void Constructor_BaseUnit_InitializesWithoutConversionOrSingularName(LengthUnit value, string pluralName)
    {
        var baseUnits = new BaseUnits(value);
        var unitDefinition = new UnitDefinition<LengthUnit>(value, pluralName, baseUnits);

        Assert.Equal(value, unitDefinition.Value);
        Assert.Equal(value.ToString(), unitDefinition.Name);
        Assert.Equal(pluralName, unitDefinition.PluralName);
        Assert.Equal(baseUnits, unitDefinition.BaseUnits);
        Assert.Equal(QuantityValue.One, unitDefinition.ConversionFromBase.Evaluate(1));
        Assert.Equal(QuantityValue.One, unitDefinition.ConversionToBase.Evaluate(1));
    }

    [Theory]
    [InlineData(LengthUnit.Meter, "Meter", "Meters")]
    [InlineData(LengthUnit.Centimeter, "Centimeter", "Centimeters")]
    [InlineData(LengthUnit.Millimeter, "Millimeter", "Millimeters")]
    public void Constructor_BaseUnit_InitializesWithoutConversion(LengthUnit value, string singularName, string pluralName)
    {
        var baseUnits = new BaseUnits(value);
        var unitDefinition = new UnitDefinition<LengthUnit>(value, singularName, pluralName, baseUnits);

        Assert.Equal(value, unitDefinition.Value);
        Assert.Equal(singularName, unitDefinition.Name);
        Assert.Equal(pluralName, unitDefinition.PluralName);
        Assert.Equal(baseUnits, unitDefinition.BaseUnits);
        Assert.Equal(QuantityValue.One, unitDefinition.ConversionFromBase.Evaluate(1));
        Assert.Equal(QuantityValue.One, unitDefinition.ConversionToBase.Evaluate(1));
    }

    [Theory]
    [InlineData(LengthUnit.Meter, "Meters", 1.0, 1.0)]
    [InlineData(LengthUnit.Centimeter, "Centimeters", 0.01, 100.0)]
    [InlineData(LengthUnit.Millimeter, "Millimeters", 0.001, 1000.0)]
    public void Constructor_WithConversionValues_InitializesCorrectly(LengthUnit value, string pluralName, double conversionCoefficientFromBase,
        double conversionCoefficientToBase)
    {
        var baseUnits = new BaseUnits();
        QuantityValue conversionFromBase = conversionCoefficientFromBase;
        QuantityValue conversionToBase = conversionCoefficientToBase;

        var unitDefinition = new UnitDefinition<LengthUnit>(value, pluralName, baseUnits, conversionFromBase, conversionToBase);

        Assert.Equal(value, unitDefinition.Value);
        Assert.Equal(value.ToString(), unitDefinition.Name);
        Assert.Equal(pluralName, unitDefinition.PluralName);
        Assert.Equal(baseUnits, unitDefinition.BaseUnits);
        Assert.Equal(conversionFromBase, unitDefinition.ConversionFromBase.Evaluate(QuantityValue.One));
        Assert.Equal(conversionToBase, unitDefinition.ConversionToBase.Evaluate(QuantityValue.One));
    }


    [Theory]
    [InlineData(LengthUnit.Meter, "Meter", "Meters", 1.0, 1.0)]
    [InlineData(LengthUnit.Centimeter, "Centimeter", "Centimeters", 0.01, 100.0)]
    [InlineData(LengthUnit.Millimeter, "Millimeter", "Millimeters", 0.001, 1000.0)]
    public void Constructor_WithSingularNameAndConversionValues_InitializesCorrectly(LengthUnit value, string singularName, string pluralName,
        double conversionCoefficientFromBase,
        double conversionCoefficientToBase)
    {
        var baseUnits = new BaseUnits();
        QuantityValue conversionFromBase = conversionCoefficientFromBase;
        QuantityValue conversionToBase = conversionCoefficientToBase;

        var unitDefinition = new UnitDefinition<LengthUnit>(value, singularName, pluralName, baseUnits, conversionFromBase, conversionToBase);

        Assert.Equal(value, unitDefinition.Value);
        Assert.Equal(singularName, unitDefinition.Name);
        Assert.Equal(pluralName, unitDefinition.PluralName);
        Assert.Equal(baseUnits, unitDefinition.BaseUnits);
        Assert.Equal(conversionFromBase, unitDefinition.ConversionFromBase.Evaluate(QuantityValue.One));
        Assert.Equal(conversionToBase, unitDefinition.ConversionToBase.Evaluate(QuantityValue.One));
    }

    [Fact]
    public void Constructor_WithNullSingularName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new UnitDefinition<LengthUnit>(LengthUnit.Meter, null!, "Meters", BaseUnits.Undefined));
    }

    [Fact]
    public void Constructor_WithNullPluralName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new UnitDefinition<LengthUnit>(LengthUnit.Meter, "Meter", null!, BaseUnits.Undefined));
    }

    [Fact]
    public void Constructor_WithNullBaseUnits_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new UnitDefinition<LengthUnit>(LengthUnit.Meter, "Meter", "Meters", null!));
    }
}
