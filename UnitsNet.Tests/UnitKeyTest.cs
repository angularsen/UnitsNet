﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Reflection;
using Xunit;

namespace UnitsNet.Tests;

public class UnitKeyTest
{
    public enum TestUnit
    {
        Unit1 = 1,
        Unit2 = 2,
        Unit3 = 3
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Constructor_ShouldCreateUnitKey(int unitValue)
    {
        var unitKey = new UnitKey(typeof(TestUnit), unitValue);
        Assert.Equal(typeof(TestUnit), unitKey.UnitEnumType);
        Assert.Equal(unitValue, unitKey.UnitEnumValue);
    }

    [Fact]
    public void Constructor_WithNullType_ShouldNotThrow()
    {
        var unitKey = new UnitKey(null!, 0);
        Assert.Null(unitKey.UnitEnumType);
        Assert.Equal(0, unitKey.UnitEnumValue);
    }

    [Theory]
    [InlineData(TestUnit.Unit1)]
    [InlineData(TestUnit.Unit2)]
    [InlineData(TestUnit.Unit3)]
    public void ForUnit_ShouldCreateUnitKey(TestUnit unit)
    {
        var unitKey = UnitKey.ForUnit(unit);
        Assert.Equal(typeof(TestUnit), unitKey.UnitEnumType);
        Assert.Equal((int)unit, unitKey.UnitEnumValue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Create_ShouldCreateUnitKey(int unitValue)
    {
        var unitKey = UnitKey.Create<TestUnit>(unitValue);
        Assert.Equal(typeof(TestUnit), unitKey.UnitEnumType);
        Assert.Equal(unitValue, unitKey.UnitEnumValue);
    }

    [Theory]
    [InlineData(typeof(TestUnit), 1)]
    [InlineData(typeof(TestUnit), 2)]
    [InlineData(typeof(TestUnit), 3)]
    public void Create_WithUnitTypeAndUnitValue_ShouldCreateUnitKey(Type unitType, int unitValue)
    {
        var unitKey = UnitKey.Create(unitType, unitValue);
        Assert.Equal(unitType, unitKey.UnitEnumType);
        Assert.Equal(unitValue, unitKey.UnitEnumValue);
    }

    [Fact]
    public void Create_WithNullUnitType_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => UnitKey.Create(null!, 0));
    }

    [Fact]
    public void Create_WithNonEnumType_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => UnitKey.Create(typeof(int), 1));
    }

    [Theory]
    [InlineData(TestUnit.Unit1)]
    [InlineData(TestUnit.Unit2)]
    [InlineData(TestUnit.Unit3)]
    public void ImplicitConversion_ShouldCreateUnitKey(TestUnit unit)
    {
        UnitKey unitKey = unit;
        Assert.Equal(typeof(TestUnit), unitKey.UnitEnumType);
        Assert.Equal((int)unit, unitKey.UnitEnumValue);
    }

    [Theory]
    [InlineData(TestUnit.Unit1)]
    [InlineData(TestUnit.Unit2)]
    [InlineData(TestUnit.Unit3)]
    public void ExplicitConversion_ShouldReturnEnum(TestUnit unit)
    {
        var unitKey = UnitKey.ForUnit(unit);
        var result = (TestUnit)(Enum)unitKey;
        Assert.Equal(unit, result);
    }

    [Theory]
    [InlineData(TestUnit.Unit1)]
    [InlineData(TestUnit.Unit2)]
    [InlineData(TestUnit.Unit3)]
    public void ToUnit_ShouldReturnEnum(TestUnit unit)
    {
        var unitKey = UnitKey.ForUnit(unit);
        TestUnit result = unitKey.ToUnit<TestUnit>();
        Assert.Equal(unit, result);
    }

    [Fact]
    public void Default_InitializesWithoutAType()
    {
        var defaultUnitKey = default(UnitKey);
        Assert.Null(defaultUnitKey.UnitEnumType);
        Assert.Equal(0, defaultUnitKey.UnitEnumValue);
    }

    [Fact]
    public void Default_Equals_UnitKeyForUnit_ReturnsFalse()
    {
        var defaultUnitKey = default(UnitKey);
        var unitKey = UnitKey.ForUnit(TestUnit.Unit1);
        Assert.NotEqual(unitKey, defaultUnitKey);
    }

    [Fact]
    public void Default_GetHashCode_ReturnsZero()
    {
        var defaultUnitKey = default(UnitKey);
        Assert.Equal(0, defaultUnitKey.GetHashCode());
    }

    [Fact]
    public void ToUnit_ShouldThrowInvalidOperationExceptionForMismatchedType()
    {
        var unitKey = UnitKey.ForUnit(TestUnit.Unit1);
        Assert.Throws<InvalidOperationException>(() => unitKey.ToUnit<DayOfWeek>());
    }

    [Fact]
    public void DefaultToUnit_ShouldThrowInvalidOperationExceptionForMismatchedType()
    {
        var defaultUnitKey = default(UnitKey);
        Assert.Throws<InvalidOperationException>(() => defaultUnitKey.ToUnit<TestUnit>());
    }

    [Fact]
    public void Deconstruct_ShouldReturnTheUnitTypeAndUnitValue()
    {
        (Type unitType, var unitValue) = UnitKey.ForUnit(TestUnit.Unit1);
        Assert.Equal(typeof(TestUnit), unitType);
        Assert.Equal(1, unitValue);
    }

    [Theory]
    [InlineData(TestUnit.Unit1, "TestUnit.Unit1")]
    [InlineData(TestUnit.Unit2, "TestUnit.Unit2")]
    [InlineData(TestUnit.Unit3, "TestUnit.Unit3")]
    [InlineData((TestUnit)(-1), "UnitEnumType: UnitsNet.Tests.UnitKeyTest+TestUnit, UnitEnumValue = -1")]
    public void GetDebuggerDisplay_ShouldReturnCorrectString(TestUnit unit, string expectedDisplay)
    {
        var unitKey = UnitKey.ForUnit(unit);
        var display = unitKey.GetType().GetMethod("GetDebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance)!
            .Invoke(unitKey, null);
        Assert.Equal(expectedDisplay, display);
    }

    [Fact]
    public void GetDebuggerDisplayWithDefault_ShouldReturnCorrectString()
    {
        var defaultUnitKey = default(UnitKey);
        var display = defaultUnitKey.GetType().GetMethod("GetDebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance)!
            .Invoke(defaultUnitKey, null);
        Assert.Equal("UnitEnumType: , UnitEnumValue = 0", display);
    }
}
