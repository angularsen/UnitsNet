// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.NumberExtensions.NumberToMass;
using Xunit;

namespace UnitsNet.NumberExtensions.Tests;

public class ConvertibleExtensionsTest
{
    [Fact]
    public void FromDecimal_ToQuantityValue_ConvertsChecked()
    {
        QuantityValue quantityValue = 4.2m;
        Assert.Equal(quantityValue, 4.2m.Grams().Value);
    }

    [Fact]
    public void FromDouble_ConvertsSaturating()
    {
        QuantityValue quantityValue = 4.2;
        Assert.Equal(quantityValue, 4.2.Grams().Value);
    }

    [Fact]
    public void FromSingle_ConvertsSaturating()
    {
        QuantityValue quantityValue = 4.2f;
        Assert.Equal(quantityValue, 4.2f.Grams().Value);
    }

    [Fact]
    public void FromInt64_ConvertsChecked()
    {
        QuantityValue quantityValue = 4L;
        Assert.Equal(quantityValue, 4L.Grams().Value);
    }

    [Fact]
    public void FromUInt64_ConvertsChecked()
    {
        QuantityValue quantityValue = 4ul;
        Assert.Equal(quantityValue, 4ul.Grams().Value);
    }

    [Fact]
    public void FromInt32_ConvertsChecked()
    {
        QuantityValue quantityValue = 4;
        Assert.Equal(quantityValue, 4.Grams().Value);
    }

    [Fact]
    public void FromUInt32_ConvertsChecked()
    {
        QuantityValue quantityValue = 4u;
        Assert.Equal(quantityValue, 4u.Grams().Value);
    }

    [Fact]
    public void FromUInt16_ConvertsChecked()
    {
        const ushort valueToTest = 4;
        QuantityValue quantityValue = valueToTest;
        Assert.Equal(quantityValue, valueToTest.Grams().Value);
    }

    [Fact]
    public void FromInt16_ConvertsChecked()
    {
        const ushort valueToTest = 4;
        QuantityValue quantityValue = valueToTest;
        Assert.Equal(quantityValue, valueToTest.Grams().Value);
    }

    [Fact]
    public void FromByte_ConvertsChecked()
    {
        const byte valueToTest = 4;
        QuantityValue quantityValue = valueToTest;
        Assert.Equal(quantityValue, valueToTest.Grams().Value);
    }

    [Fact]
    public void FromSByte_ConvertsChecked()
    {
        const sbyte valueToTest = 4;
        QuantityValue quantityValue = valueToTest;
        Assert.Equal(quantityValue, valueToTest.Grams().Value);
    }

    [Fact]
    public void FromBoolean_ReturnsZeroOrOne()
    {
        Assert.Equal(QuantityValue.One, true.Grams().Value);
        Assert.Equal(QuantityValue.Zero, false.Grams().Value);
    }

    [Fact]
    public void FromChar_ThrowsInvalidCastException()
    {
        Assert.Throws<InvalidCastException>(() => 'z'.Grams().Value);
    }

    [Fact]
    public void FromDateTime_ThrowsInvalidCastException()
    {
        Assert.Throws<InvalidCastException>(() => DateTime.MinValue.Grams().Value);
    }

    [Fact]
    public void FromString_ReturnsTheParsedValue()
    {
        QuantityValue expectedValue = 42;
        Assert.Equal(expectedValue, "42".Grams().Value);
    }
}
