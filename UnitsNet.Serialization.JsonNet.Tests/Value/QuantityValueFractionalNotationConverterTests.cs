// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnitsNet.Serialization.JsonNet.Value;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests.Value;

[TestSubject(typeof(QuantityValueFractionalNotationConverter))]
public class QuantityValueFractionalNotationConverterTests
{
    private static JsonSerializerSettings CreateDefaultOptions()
    {
        var options = new JsonSerializerSettings();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        return options;
    }

    [Fact]
    public void Serialize_ReturnsTheExpectedResult()
    {
        // Arrange
        var json = """{"N":42,"D":10}""";
        QuantityValue value = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WithReduction_ReturnsTheExpectedResult()
    {
        // Arrange
        var json = """{"N":21,"D":5}""";
        QuantityValue value = 4.2m;
        var options = new JsonSerializerSettings();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Reducing);
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_Zero_WithDefaultSettings_ReturnsBothTerms()
    {
        // Arrange
        var json = """{"N":0,"D":1}""";
        var value = QuantityValue.Zero;
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_Zero_IgnoringDefaultValues_ReturnsAnEmptyObject()
    {
        // Arrange
        var json = "{}";
        var value = QuantityValue.Zero;
        JsonSerializerSettings options = CreateDefaultOptions();
        options.DefaultValueHandling = DefaultValueHandling.Ignore;
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_IntegerNumber_WithIgnoreCondition_WhenWritingDefault_ReturnsTheNumerator()
    {
        // Arrange
        var json = """{"N":5}""";
        QuantityValue value = 5;
        JsonSerializerSettings options = CreateDefaultOptions();
        options.DefaultValueHandling = DefaultValueHandling.Ignore;
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_DecimalNumber_WithIgnoreCondition_WhenWritingDefault_ReturnsBothTerms()
    {
        // Arrange
        var json = """{"N":42,"D":10}""";
        QuantityValue value = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();
        options.DefaultValueHandling = DefaultValueHandling.Ignore;
        
        // Act
        var result = JsonConvert.SerializeObject(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Deserialize_ValidJson_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = """{"N":42,"D":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_ValidJson_WithCaseInsensitiveMatching_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = """{"N":42,"d":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_ValidJson_WithAdditionalProperties_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = """{"N":42,"something":2,"D":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_Json_WithAdditionalProperties_AndMissingMemberHandlingAsError_ThrowsJsonException()
    {
        // Arrange
        var json = """{"N":42,"something":2,"D":10}""";
        JsonSerializerSettings options = CreateDefaultOptions();
        options.MissingMemberHandling = MissingMemberHandling.Error;
        
        // Assert
        Assert.Throws<JsonException>(() => JsonConvert.DeserializeObject<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserialize_ValidJsonWithQuotedTerms_ReturnsTheExpectedValue()
    {
        // Arrange
        var json = """{"N":"42","D":"10"}""";
        QuantityValue expected = 4.2m;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutDenominator_ReturnsTheExpectedIntegerValue()
    {
        // Arrange
        var json = """{"N":42}""";
        QuantityValue expected = 42;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndDenominator_ReturnsZero()
    {
        // Arrange
        var json = "{}";
        QuantityValue expected = QuantityValue.Zero;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndNonZeroDenominator_ReturnsZero()
    {
        // Arrange
        var json = """{"D":1}""";
        QuantityValue expected = QuantityValue.Zero;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndZeroDenominator_ReturnsNaN()
    {
        // Arrange
        var json = """{"D":0}""";
        QuantityValue expected = QuantityValue.NaN;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutPositiveNumeratorAndZeroDenominator_ReturnsPositiveInfinity()
    {
        // Arrange
        var json = """{"N":1,"D":0}""";
        QuantityValue expected = QuantityValue.PositiveInfinity;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithNegativeNumeratorAndZeroDenominator_ReturnsNegativeInfinity()
    {
        // Arrange
        var json = """{"N":-1,"D":0}""";
        QuantityValue expected = QuantityValue.NegativeInfinity;
        JsonSerializerSettings options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonConvert.DeserializeObject<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserializing_WithInvalidString_ThrowsFormatException()
    {
        // Arrange
        var json = """{"N":"4invalid2","D":"10"}""";
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Assert
        Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<QuantityValue>(json, options));
    }

    [Theory]
    [InlineData("43")]
    public void Deserializing_WithInvalidJsonString_ThrowsJsonException(string invalidJson)
    {
        // Arrange
        JsonSerializerSettings options = CreateDefaultOptions();
        
        // Assert
        Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<QuantityValue>(invalidJson, options));
    }
}
