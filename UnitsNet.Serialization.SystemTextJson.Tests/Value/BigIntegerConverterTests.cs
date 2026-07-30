using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Value;

[TestSubject(typeof(BigIntegerConverter))]
public class BigIntegerConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new BigIntegerConverter());
        return options;
    }

    [Fact]
    public void Serializing_ReturnsBigIntegerAsNumber()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = "123456789012345678901234567890";
        var value = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serializing_VeryLargeNumbers_ReturnsTheExpectedResult()
    {
        // Arrange: A JSON string representing the string '10...' with 520 zeros
        var json = new string(Enumerable.Repeat('0', 520).Prepend('1').ToArray());
        var value = BigInteger.Pow(10, 520);
        JsonSerializerOptions options = CreateOptions();

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serializing_AsString_ReturnsBigIntegerAsNumber()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = """
                            "123456789012345678901234567890"
                            """;
        var value = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Serializing_VeryLargeNumbers_AsString_ReturnsTheExpectedResult()
    {
        // Arrange: A JSON string representing the string "10..." with 520 zeros
        var json = new string(Enumerable.Repeat('0', 520).Prepend('1').Prepend('"').Append('"').ToArray());
        var value = BigInteger.Pow(10, 520);
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.WriteAsString;

        // Act
        var result = JsonSerializer.Serialize(value, options);

        // Assert
        Assert.Equal(json, result);
    }

    [Fact]
    public void Deserializing_NumberString_ReturnsExpectedBigInteger()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = "123456789012345678901234567890";
        var expected = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);

        // Act
        BigInteger result = JsonSerializer.Deserialize<BigInteger>(json, CreateOptions());

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserializing_QuotedNumber_WithDefaultNumberHandling_ThrowsJsonException()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = """
                            "123456789012345678901234567890"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<BigInteger>(json, options));
    }

    [Fact]
    public void Deserializing_QuotedNumber_WithAllowReadingFromString_ReturnsExpectedBigInteger()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = """
                            "123456789012345678901234567890"
                            """;
        var expected = BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture);
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Act
        BigInteger result = JsonSerializer.Deserialize<BigInteger>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserializing_VeryLongNumbers_ReturnsTheExpectedResult()
    {
        // Arrange: A very long number string ('10...' with 520 zeros)
        var json = new string(Enumerable.Repeat('0', 520).Prepend('1').ToArray());
        var expected = BigInteger.Pow(10, 520);
        JsonSerializerOptions options = CreateOptions();

        // Act
        BigInteger result = JsonSerializer.Deserialize<BigInteger>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_EscapedString_WithAllowReadingFromString_ReturnsExpectedBigInteger()
    {
        // Arrange: A JSON string with Unicode escape sequences.
        // The JSON literal "12345\u0034\u0035" should be interpreted as "1234545".
        var json = """
                   "12345\u0034\u0035"
                   """;
        var expected = BigInteger.Parse("1234545", CultureInfo.InvariantCulture);
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Act
        BigInteger result = JsonSerializer.Deserialize<BigInteger>(json, options);
    
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserializing_InvalidNumberString_ThrowsFormatException()
    {
        // Arrange: A JSON string without any escape sequences.
#pragma warning disable JSON001
        const string json = """
                            "12345678901234567890123456789invalid0"
                            """;
#pragma warning restore JSON001
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<BigInteger>(json, options));
    }
    
    [Fact]
    public void Deserializing_EmptyString_ThrowsJsonException()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = """
                            ""
                            """;
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<FormatException>(() => JsonSerializer.Deserialize<BigInteger>(json, options));
    }

    [Fact]
    public void Deserializing_EmptyObjectString_ThrowsJsonException()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = "{}";
        JsonSerializerOptions options = CreateOptions();
        options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<BigInteger>(json, options));
    }

    [Fact]
    public void Deserializing_NullObject_ThrowsJsonException()
    {
        // Arrange: A JSON string without any escape sequences.
        const string json = "null";
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<BigInteger>(json, options));
    }
}
