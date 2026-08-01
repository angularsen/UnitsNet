// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Value;

[TestSubject(typeof(QuantityValueDoubleConverter))]
public class QuantityValueDoubleConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDoubleConverter());
        return options;
    }

    [Fact]
    public void Constructor_GivenAnInvalidNumberOfSignificantDigits_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new QuantityValueDoubleConverter(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new QuantityValueDoubleConverter(18));
    }
    
    [Fact]
    public void Serialize_ReturnsTheValueInDecimalNotation()
    {
        // Arrange
        #if NET
        var json = "4.2";
        #else
        var json = "4.2000000000000002";
        #endif
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
        Assert.Equal(json, JsonSerializer.Serialize(4.2, options)); // same as serializing the double
    }

    [Fact]
    public void Serialize_WithJsonNumberHandling_WriteAsString_ReturnsTheValueInDecimalNotation()
    {
        // Arrange
        var json = "\"4.2\"";
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
#if NET
        Assert.Equal(json, JsonSerializer.Serialize(4.2, options)); // same as serializing the double
 #else
        Assert.Equal("\"4.2000000000000002\"", JsonSerializer.Serialize(4.2, options)); // not sure why this is different...
#endif
    }

    [Fact]
    public void Serialize_WithDefaultSettings_ReturnsTheValueFormattedAsG17()
    {
        // Arrange
#if NET
        var json = "0.3333333333333333";
#else
        var json = "0.33333333333333331";
#endif
        var value = QuantityValue.FromTerms(1, 3);
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
        Assert.Equal(json, JsonSerializer.Serialize(1 / 3.0, options)); // same as serializing the double
    }

    [Fact]
    public void Serializing_NaN_or_Infinity_WithStrictNumberHandling_ThrowsJsonException()
    {
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.Strict;

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(QuantityValue.NaN, options));
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(QuantityValue.PositiveInfinity, options));
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(QuantityValue.NegativeInfinity, options));
    }

    [Fact]
    public void Serializing_NaN_WithAllowNamedFloatingPointLiterals_ReturnsTheExpectedResult()
    {
        // Arrange
        var expectedJson = "\"NaN\"";
        var value = QuantityValue.NaN;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_PositiveInfinity_WithAllowNamedFloatingPointLiterals_ReturnsTheExpectedResult()
    {
        // Arrange
        var expectedJson = "\"Infinity\"";
        var value = QuantityValue.PositiveInfinity;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Deserialize_ValidNumberString_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "4.2";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_NumberStringInScientificNotation_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "3.3333333E-06";
        QuantityValue expected = 3.3333333E-06; // ~ 1/300_000
        JsonSerializerOptions options = CreateOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Deserialize_QuotedNumber_With_AllowReadingFromString_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "\"4.2\"";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_PositiveInfinity_With_AllowNamedFloatingPointLiterals_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "\"Infinity\"";
        QuantityValue expected = QuantityValue.PositiveInfinity;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_NegativeInfinity_With_AllowNamedFloatingPointLiterals_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "\"-Infinity\"";
        QuantityValue expected = QuantityValue.NegativeInfinity;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_NaN_With_AllowNamedFloatingPointLiterals_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = "\"NaN\"";
        QuantityValue expected = QuantityValue.NaN;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserializing_NaN_Without_AllowNamedFloatingPointLiterals_ThrowsJsonException()
    {
        // Arrange
        var json = "\"NaN\"";
        JsonSerializerOptions options = CreateOptions();
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithInvalidString_ThrowsJsonException()
    {
        // Arrange
        var json = "\"123invalid456\"";
        JsonSerializerOptions options = CreateOptions();
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithEmptyObjectString_ThrowsJsonException()
    {
        // Arrange
        var json = "{}";
        JsonSerializerOptions options = CreateOptions();
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }
}
