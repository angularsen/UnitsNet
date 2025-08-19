// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Value;

[TestSubject(typeof(QuantityValueDecimalConverter))]
public class QuantityValueDecimalConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalConverter());
        return options;
    }
    
    [Fact]
    public void Serialize_ReturnsTheValueInDecimalNotation()
    {
        // Arrange
        var json = "4.2";
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
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
    }

    [Fact]
    public void Serialize_WithDefaultSettings_ReturnsTheValueFormattedAsG29()
    {
        // Arrange
        var json = "0.3333333333333333333333333333";
        var value = QuantityValue.FromTerms(1, 3);
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WithNumbersBeyondTheDecimalRange_ThrowsOverflowException()
    {
        // Arrange
        var value = QuantityValue.FromPowerOfTen(1, 40);
        JsonSerializerOptions options = CreateOptions();
        
        Assert.Throws<OverflowException>(() => JsonSerializer.Serialize(value, options));
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
    public void Deserializing_NaN_Without_AllowNamedFloatingPointLiterals_FormatException()
    {
        // Arrange
        var json = "\"NaN\"";
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        
        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithInvalidString_ThrowsFormatException()
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
