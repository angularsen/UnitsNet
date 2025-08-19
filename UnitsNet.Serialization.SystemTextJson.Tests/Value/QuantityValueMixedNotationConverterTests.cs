// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Value;

[TestSubject(typeof(QuantityValueMixedNotationConverter))]
public class QuantityValueMixedNotationConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueMixedNotationConverter.Default);
        return options;
    }

    [Fact]
    public void Serialize_WholeNumber_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = "42";
        QuantityValue value = 42;
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WholeNumber_WithoutReduction_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = "42";
        var value = QuantityValue.FromTerms(420, 10);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_WholeNumber_AsString_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """
                            "42"
                            """;
        QuantityValue value = 42;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_VeryLargeWholeNumber_ReturnsTheExpectedResult()
    {
        // Arrange: 1e260 (written with all its zeros)
        var json = new string(Enumerable.Repeat('0', 512).Prepend('1').ToArray());
        QuantityValue value = BigInteger.Pow(10, 512);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_TerminatingDecimal_ReturnsTheValueInDecimalNotation()
    {
        // Arrange
        const string json = "4.25";
        QuantityValue value = 4.25m;
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_TerminatingDecimal_AsString_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """
                            "42.5"
                            """;
        QuantityValue value = 42.5m;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_NonTerminatingDecimal_ReturnsTheValueFraction()
    {
        // Arrange
        const string json = """
                            "1/3"
                            """;
        var value = QuantityValue.FromTerms(1, 3);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }
    
    [Theory]
    [InlineData(510)]
    [InlineData(511)]
    public void Serialize_VeryLargeDecimalNumber_ReturnsTheExpectedResult(int nbZeros)
    {
        // Arrange: 10000[...]4.2 (written as a decimal, with all its zeros)
        var json = $"1{new string(Enumerable.Repeat('0', nbZeros).ToArray())}4.2";
        var value = QuantityValue.FromTerms(42 + BigInteger.Pow(10, nbZeros + 2), 10);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serialize_VeryLargeDecimalNumber_AsString_ReturnsTheExpectedResult()
    {
        // Arrange: 4.2e-255 (written as a quoted decimal, with all its zeros)
        var json = $"""
                    "0.{new string(Enumerable.Repeat('0', 512).ToArray())}42"
                    """;
        var value = QuantityValue.FromPowerOfTen(42, -514);
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Theory]
    [InlineData(511)]
    [InlineData(512)]
    [InlineData(-510)]
    public void Serialize_FractionalWithLargeExponent_ReturnsTheExpectedResult(int exponent)
    {
        // Arrange: (1/3)e256 (written as a fraction, with all its zeros)
        var value = QuantityValue.FromPowerOfTen(1, 3, exponent);
        var (numerator, denominator) = QuantityValue.Reduce(value);
        var json = $"""
                    "{numerator}/{denominator}"
                    """;
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }
    
//     [Theory]
//     // [InlineData(250, 250)]
//     // [InlineData(40, 250)]
//     [InlineData(2, 1)]
//     // [InlineData(14, 6)]
//     // [InlineData(25, 3)]
//     public void Serialize_FractionalWithLargeTerms_ReturnsTheExpectedResult(int numeratorDigits, int denominatorDigits)
//     {
//         // Arrange: (1/3)e256 (written as a fraction, with all its zeros)
//         var value = QuantityValue.FromTerms(
//             BigInteger.Parse(new string(Enumerable.Repeat('2', numeratorDigits).ToArray())),
//             BigInteger.Parse("1234567" + new string(Enumerable.Repeat('3', denominatorDigits).ToArray())));
//         var (numerator, denominator) = QuantityValue.Reduce(value);
//         var json = $"""
//                     "{numerator}/{denominator}"
//                     """;
//         JsonSerializerOptions options = CreateOptions();
//
//         // Act
//         var result = JsonSerializer.Serialize(value, options);
//
//         // Assert
//         Assert.Equal(json, result);
//     }

    [Fact]
    public void Serializing_NaN_WithDefaultNumberHandling_ThrowsJsonException()
    {
        JsonSerializerOptions options = CreateOptions();
        Assert.Throws<JsonException>(() => JsonSerializer.Serialize(QuantityValue.NaN, options));
    }

    [Fact]
    public void Serializing_NaN_WithAllowNamedFloatingPointLiterals_ReturnsTheExpectedResult()
    {
        // Arrange
        const string expectedJson = """
                                    "NaN"
                                    """;
        QuantityValue value = QuantityValue.NaN;
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
        const string expectedJson = """
                                    "Infinity"
                                    """;
        QuantityValue value = QuantityValue.PositiveInfinity;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Serializing_NegativeInfinity_WithAllowNamedFloatingPointLiterals_ReturnsTheExpectedResult()
    {
        // Arrange
        const string expectedJson = """
                                    "-Infinity"
                                    """;
        QuantityValue value = QuantityValue.NegativeInfinity;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Deserialize_DecimalNumberString_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = "4.2";
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
        const string json = "3.3333333E-06";
        QuantityValue expected = 3.3333333E-06; // ~ 1/300_000
        JsonSerializerOptions options = CreateOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_FractionString_ReturnsTheExpectedValue()
    {
        // Arrange
        const string json = """
                            "1/3"
                            """;
        var expected = QuantityValue.FromTerms(1, 3);
        JsonSerializerOptions options = CreateOptions();

        // Act
        QuantityValue result = JsonSerializer.Deserialize<QuantityValue>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("""
                "12345"
                """)]
    [InlineData("""
                "12345\u0034\u0035"
                """)]
    public void Deserializing_QuotedNumber_WithDefaultNumberHandling_ThrowsJsonException(string json)
    {
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithValidEscapedCharacters_ReturnsTheExpectedResult()
    {
        // Arrange 1234545 (using the unicode '4')
        const string json = """
                            "12345\u0034\u0035"
                            """;
        QuantityValue expectedValue = 1234545;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Equal(expectedValue, JsonSerializer.Deserialize<int>(json, options));
        Assert.Equal(expectedValue, JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Theory]
    [InlineData("""
                "123invalid456"
                """)]
    [InlineData("""
                "123/invalid456"
                """)]
    public void Deserializing_WithInvalidString_ThrowsFormatException(string json)
    {
        // Arrange
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithEmptyString_ThrowsFormatException()
    {
        // Arrange
        const string json = """
                            ""
                            """;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<double>(json, options));
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }

    [Fact]
    public void Deserializing_WithEmptyObjectString_ThrowsJsonException()
    {
        // Arrange
        const string json = "{}";
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<double>(json, options));
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<QuantityValue>(json, options));
    }
}
