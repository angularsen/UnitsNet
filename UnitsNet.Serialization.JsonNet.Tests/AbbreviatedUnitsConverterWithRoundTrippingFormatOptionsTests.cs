// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Newtonsoft.Json;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests;

public class AbbreviatedUnitsConverterWithRoundTrippingFormatOptionsTests : JsonNetSerializationTestsBase
{
    public AbbreviatedUnitsConverterWithRoundTrippingFormatOptionsTests()
        : base(new AbbreviatedUnitsConverter(
            new QuantityValueFormatOptions(QuantityValueSerializationFormat.RoundTripping, QuantityValueDeserializationFormat.RoundTripping)))
    {
    }

    [Fact]
    public void Serializing_Quantity_WithDecimalNotationAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(4.25m);
        const string expectedJson = """{"Value":4.25,"Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_LargeQuantity_WithHighPrecisionAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.Parse("12345678901234567890.1234567890123456789", CultureInfo.InvariantCulture));
        const string expectedJson = """{"Value":12345678901234567890.1234567890123456789,"Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_Quantity_WithFractionalFormatAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.FromTerms(1, 3));
        const string expectedJson = """{"Value":"1/3","Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Theory]
    [InlineData(510)]
    [InlineData(511)]
    public void Serialize_VeryLargeDecimalNumber_ReturnsTheExpectedResult(int nbZeros)
    {
        // Arrange: 10000[...]4.2 (written as a decimal, with all its zeros)
        var valueString = $"1{new string(Enumerable.Repeat('0', nbZeros).ToArray())}4.2";
        var value = Mass.FromMilligrams(QuantityValue.FromTerms(42 + BigInteger.Pow(10, nbZeros + 2), 10));
        var expectedJson = $$"""{"Value":{{valueString}},"Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serialize_VeryPreciseDecimalNumber_ReturnsTheExpectedResult()
    {
        // Arrange: 4.2e-255 (written as a decimal, with all its zeros)
        var valueString = "0." + new string(Enumerable.Repeat('0', 512).ToArray()) + "42";
        var expectedJson = $$"""{"Value":{{valueString}},"Unit":"mg","Type":"Mass"}""";
        var value = Mass.FromMilligrams(QuantityValue.FromPowerOfTen(42, -514));

        // Act
        var result = SerializeObject(value);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serialize_VeryLargeFractionalNumber_ReturnsTheExpectedResult()
    {
        // Arrange: (1/3)e256 (written as a fraction, with all its zeros)
        var numeratorString = new string(Enumerable.Repeat('0', 255).Prepend('1').ToArray());
        var expectedJson = $$"""{"Value":"{{numeratorString}}/3","Unit":"mg","Type":"Mass"}""";
        var value = Mass.FromMilligrams(QuantityValue.FromPowerOfTen(1, 3, 255));

        // Act
        var result = SerializeObject(value);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_NaN_WithSymbolAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.NaN);
        const string expectedJson = """{"Value":"NaN","Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_PositiveInfinity_WithSymbolAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.PositiveInfinity);
        const string expectedJson = """{"Value":"Infinity","Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_NegativeInfinity_WithSymbolAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.NegativeInfinity);
        const string expectedJson = """{"Value":"-Infinity","Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Deserializing_Quantity_FromVeryPreciseValueAndAbbreviatedUnit()
    {
        // Arrange
        const string json = """{"Value":12345678901234567890.1234567890123456789,"Unit":"mg","Type":"Mass"}""";
        var expectedValue = QuantityValue.Parse("12345678901234567890.1234567890123456789", CultureInfo.InvariantCulture);

        // Act
        Mass quantity = DeserializeObject<Mass>(json);

        //Assert
        Assert.Equal(expectedValue, quantity.Value);
        Assert.Equal(MassUnit.Milligram, quantity.Unit);
    }

    [Fact]
    public void Deserializing_Quantity_WithFractionalFormatAndAbbreviatedUnit()
    {
        // Arrange
        const string json = """{"Value":"1/3","Unit":"mg","Type":"Mass"}""";
        var expectedValue = QuantityValue.FromTerms(1, 3);

        // Act
        Mass quantity = DeserializeObject<Mass>(json);

        //Assert
        Assert.Equal(expectedValue, quantity.Value);
        Assert.Equal(MassUnit.Milligram, quantity.Unit);
    }

    [Fact]
    public void Deserializing_NullValue_ThrowsJsonSerializationException()
    {
        const string json = """{"Value":null,"Unit":"mg","Type":"Mass"}""";
        Assert.Throws<JsonSerializationException>(() => DeserializeObject<Mass>(json));
    }

    [Fact]
    public void Deserializing_EmptyValue_ThrowsJsonSerializationException()
    {
        const string json = """{"Value":"","Unit":"mg","Type":"Mass"}""";
        Assert.Throws<FormatException>(() => DeserializeObject<Mass>(json));
    }

    [Fact]
    public void Deserializing_InvalidFractionFormat_ThrowsFormatException()
    {
        const string json = """{"Value":"1/3invalid","Unit":"mg","Type":"Mass"}""";
        Assert.Throws<FormatException>(() => DeserializeObject<Mass>(json));
    }
}
