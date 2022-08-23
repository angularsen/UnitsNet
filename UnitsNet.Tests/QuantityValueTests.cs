using System;
using Xunit;

namespace UnitsNet.Tests;

public class QuantityValueTests
{
    [Fact]
    public void QuantityValue_FromDouble_ContainsDouble()
    {
        QuantityValue value = 1.0;

        Assert.False(value.IsDecimal);
        Assert.Equal(1.0, (double)value);
    }

    [Fact]
    public void QuantityValue_FromDecimal_ContainsDecimal()
    {
        QuantityValue value = 1.0m;

        Assert.True(value.IsDecimal);
        Assert.Equal(1.0m, (decimal)value);
    }

    [Fact]
    public void QuantityValue_FromInteger_ContainsDecimal()
    {
        QuantityValue value = 1;

        Assert.True(value.IsDecimal);
        Assert.Equal(1m, (decimal)value);
    }

    [Fact]
    public void QuantityValue_FromNaN_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => (QuantityValue)double.NaN);
    }

    [Fact]
    public void QuantityValue_FromInfinity_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => (QuantityValue)double.PositiveInfinity);
        Assert.Throws<ArgumentException>(() => (QuantityValue)double.NegativeInfinity);
    }
    
    [Fact]
    public void Operations_WithDoubles_ReturnDoubles()
    {
        QuantityValue two = 2.0;

        QuantityValue twoPlusTwo = two + two;
        QuantityValue twoMinusTwo = two - two;
        QuantityValue twoTimesTwo = two * two;
        QuantityValue twoDividedByTwo = two / two;

        Assert.False(twoPlusTwo.IsDecimal);
        Assert.False(twoMinusTwo.IsDecimal);
        Assert.False(twoTimesTwo.IsDecimal);
        Assert.False(twoDividedByTwo.IsDecimal);

        Assert.Equal(4.0, (double)twoPlusTwo);
        Assert.Equal(0.0, (double)twoMinusTwo);
        Assert.Equal(4.0, (double)twoTimesTwo);
        Assert.Equal(1.0, (double)twoDividedByTwo);
    }

    [Fact]
    public void Operations_WithDecimal_ReturnDecimals()
    {
        QuantityValue two = 2.0m;

        QuantityValue twoPlusTwo = two + two;
        QuantityValue twoMinusTwo = two - two;
        QuantityValue twoTimesTwo = two * two;
        QuantityValue twoDividedByTwo = two / two;

        Assert.True(twoPlusTwo.IsDecimal);
        Assert.True(twoMinusTwo.IsDecimal);
        Assert.True(twoTimesTwo.IsDecimal);
        Assert.True(twoDividedByTwo.IsDecimal);

        Assert.Equal(4.0m, (decimal)twoPlusTwo);
        Assert.Equal(0.0m, (decimal)twoMinusTwo);
        Assert.Equal(4.0m, (decimal)twoTimesTwo);
        Assert.Equal(1.0m, (decimal)twoDividedByTwo);
    }

    [Fact]
    public void Operations_WithDoubleAndDecimal_ReturnDecimals()
    {
        QuantityValue twoFromDouble = 2.0;
        QuantityValue twoFromDecimal = 2.0m;

        QuantityValue twoPlusTwo = twoFromDouble + twoFromDecimal;
        QuantityValue twoMinusTwo = twoFromDouble - twoFromDecimal;
        QuantityValue twoTimesTwo = twoFromDouble * twoFromDecimal;
        QuantityValue twoDividedByTwo = twoFromDouble / twoFromDecimal;

        Assert.True(twoPlusTwo.IsDecimal);
        Assert.True(twoMinusTwo.IsDecimal);
        Assert.True(twoTimesTwo.IsDecimal);
        Assert.True(twoDividedByTwo.IsDecimal);

        Assert.Equal(4.0m, (decimal)twoPlusTwo);
        Assert.Equal(0.0m, (decimal)twoMinusTwo);
        Assert.Equal(4.0m, (decimal)twoTimesTwo);
        Assert.Equal(1.0m, (decimal)twoDividedByTwo);
    }

    [Fact]
    public void OverflowingOperations_WithDecimal_ReturnDoubles()
    {
        // TODO see about exposing a QuantityValue.MaxDecimal constant
        const decimal maxDecimalValue =  decimal.MaxValue * 1E-6m; // the clamping value is actual smaller than the decimal.MaxValue (ensuring the minimal conversion precision)
        QuantityValue maxDecimal = maxDecimalValue;

        QuantityValue twoTimesMax = maxDecimal + maxDecimal;
        QuantityValue twoTimesMin = -maxDecimal - maxDecimal;
        QuantityValue maxSquared = maxDecimal * maxDecimal;
        QuantityValue oneOverMax = 0.1 / maxDecimal;

        Assert.True(maxDecimal.IsDecimal);
        Assert.False(twoTimesMax.IsDecimal);
        Assert.False(twoTimesMin.IsDecimal);
        Assert.False(maxSquared.IsDecimal);
        Assert.False(oneOverMax.IsDecimal);

        const double max = (double)maxDecimalValue;
        Assert.Equal(max + max, (double)twoTimesMax);
        Assert.Equal(-max - max, (double)twoTimesMin);
        Assert.Equal(max * max, (double)maxSquared);
        Assert.Equal(0.1 / max, (double)oneOverMax);
    }

    [Fact]
    public void OverflowingOperations_WithDouble_ThrowArgumentException()
    {
        // TODO see about supporting Positive/Negative infinity
        QuantityValue maxDouble = double.MaxValue; 

        Assert.Throws<ArgumentException>(() => maxDouble + maxDouble);
        Assert.Throws<ArgumentException>(() => -maxDouble - maxDouble);
        Assert.Throws<ArgumentException>(() => maxDouble * maxDouble);
        Assert.Throws<ArgumentException>(() => maxDouble / 0);
    }

    // TODO add tests for IEquatable / IComparable (decimal comparison when both values are in the decimal range)
}
