// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Value;

[TestSubject(typeof(QuantityValueFractionalNotationConverter))]
public class QuantityValueFractionalNotationConverterTests
{
    private static JsonSerializerOptions CreateDefaultOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        return options;
    }

    [Fact]
    public void Creating_WithNullBigIntegerConverter_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentNullException>(() => new QuantityValueFractionalNotationConverter(null!));
    }

    [Fact]
    public void Serialize_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"N":42,"D":10}""";
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WithReduction_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"N":21,"D":5}""";
        QuantityValue value = 4.2m;
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Reducing);
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WithLowerCaseProperties_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"n":42,"d":10}""";
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_Zero_WithDefaultSettings_ReturnsBothTerms()
    {
        // Arrange
        const string json = """{"N":0,"D":1}""";
        var value = QuantityValue.Zero;
        JsonSerializerOptions options = CreateDefaultOptions();
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_Zero_IgnoringDefaultValues_ReturnsAnEmptyObject()
    {
        // Arrange
        var json = "{}";
        var value = QuantityValue.Zero;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_IntegerNumber_WithIgnoreCondition_WhenWritingDefault_ReturnsTheNumerator()
    {
        // Arrange
        const string json = """{"N":5}""";
        QuantityValue value = 5;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_DecimalNumber_WithIgnoreCondition_WhenWritingDefault_ReturnsBothTerms()
    {
        // Arrange
        const string json = """{"N":42,"D":10}""";
        QuantityValue value = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        
        // Act
        var result = JsonSerializer.Serialize(value, options);
        
        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Deserialize_ValidJson_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """{"N":42,"D":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_ValidJson_WithLowercasePolicy_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """{"n":42,"d":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        
        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_ValidJson_WithCaseInsensitiveMatching_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """{"N":42,"d":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.PropertyNameCaseInsensitive = true;
        
        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_ValidJson_WithAdditionalProperties_WithCaseInsensitiveMatching_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """{"N":42,"something":2,"d":10}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.PropertyNameCaseInsensitive = true;
        
        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_JsonWithQuotedTerms_WithDefaultNumberHandling_ThrowsJsonException()
    {
        // Arrange
        const string json = """{"N":"42","D":"10"}""";
        JsonSerializerOptions options = CreateDefaultOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserialize_ValidJsonWithQuotedTerms_WithAllowReadingFromString_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """{"N":"42","D":"10"}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutDenominator_ReturnsTheExpectedIntegerValue()
    {
        // Arrange
        const string json = """{"N":42}""";
        QuantityValue expected = 42;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndDenominator_ReturnsZero()
    {
        // Arrange
        var json = "{}";
        QuantityValue expected = QuantityValue.Zero;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndNonZeroDenominator_ReturnsZero()
    {
        // Arrange
        const string json = """{"D":1}""";
        QuantityValue expected = QuantityValue.Zero;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutNumeratorAndZeroDenominator_ReturnsNaN()
    {
        // Arrange
        const string json = """{"D":0}""";
        QuantityValue expected = QuantityValue.NaN;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithoutPositiveNumeratorAndZeroDenominator_ReturnsPositiveInfinity()
    {
        // Arrange
        const string json = """{"N":1,"D":0}""";
        QuantityValue expected = QuantityValue.PositiveInfinity;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithNegativeNumeratorAndZeroDenominator_ReturnsNegativeInfinity()
    {
        // Arrange
        const string json = """{"N":-1,"D":0}""";
        QuantityValue expected = QuantityValue.NegativeInfinity;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithAdditionalProperties_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"N":42,"D":10,"C":1}""";
        QuantityValue expected = 4.2m;
        JsonSerializerOptions options = CreateDefaultOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Deserialize_WithAdditionalProperties_WhenUnmappedMemberHandlingIsDisallowed_ThrowsJsonException(bool caseInsensitive)
    {
        // Arrange
        const string invalidJson = """{"N":42,"D":10,"C":1}""";
        JsonSerializerOptions options = CreateDefaultOptions();
        options.PropertyNameCaseInsensitive = caseInsensitive;
        options.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(invalidJson, options));
    }

    [Fact]
    public void Deserializing_WithInvalidString_ThrowsFormatException()
    {
        // Arrange
        const string invalidJson = """{"N":"4invalid2","D":"10"}""";
        JsonSerializerOptions options = CreateDefaultOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<QuantityValue>(invalidJson, options));
    }

    [Theory]
    [InlineData("43")]
    [InlineData("""{"N":4""")]
    public void Deserializing_WithInvalidJsonString_ThrowsJsonException(string invalidJson)
    {
        // Arrange
        JsonSerializerOptions options = CreateDefaultOptions();
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(invalidJson, options));
    }
}
