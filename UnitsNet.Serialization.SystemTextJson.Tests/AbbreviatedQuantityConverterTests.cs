// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests;

[TestSubject(typeof(AbbreviatedQuantityConverter))]
public class AbbreviatedQuantityConverterTests
{
    [Fact]
    public void Serializing_WithoutAConverter_UsesDefaultFractionalNotationConverter()
    {
        // Arrange
        var json = """{"Value":{"N":42,"D":10},"Unit":"g"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_WithDecimalNotationConverter()
    {
        // Arrange
        var json = """{"Value":4.2,"Unit":"g"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedQuantityConverter(new QuantityValueDecimalNotationConverter()));

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CreateConverter_InvalidType_ReturnsNull()
    {
        // Arrange
        var converter = new AbbreviatedQuantityConverter();
        var options = new JsonSerializerOptions();
        Type typeToConvert = typeof(string);

        // Act & Assert
        Assert.Null(converter.CreateConverter(typeToConvert, options));
    }
}
