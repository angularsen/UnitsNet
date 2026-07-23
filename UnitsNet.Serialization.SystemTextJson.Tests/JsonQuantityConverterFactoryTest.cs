// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests;

[TestSubject(typeof(JsonQuantityConverter))]
public class JsonQuantityConverterFactoryTest
{
    [Theory]
    [InlineData(typeof(int), false)]
    [InlineData(typeof(double), false)]
    [InlineData(typeof(string), false)]
    [InlineData(typeof(Length), true)]
    public void CanConvert_ReturnsExpectedResult(Type typeToConvert, bool expectedResult)
    {
        // Arrange
        var converter = new JsonQuantityConverter();

        // Act
        var result = converter.CanConvert(typeToConvert);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void CreateConverter_ValidType_ReturnsExpectedConverter()
    {
        // Arrange
        var converter = new JsonQuantityConverter();
        var options = new JsonSerializerOptions();
        Type typeToConvert = typeof(Length);

        // Act
        JsonConverter? result = converter.CreateConverter(typeToConvert, options);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<JsonQuantityConverter<Length, LengthUnit>>(result);
    }

    [Fact]
    public void CreateConverter_InvalidType_ReturnsNull()
    {
        // Arrange
        var converter = new JsonQuantityConverter();
        var options = new JsonSerializerOptions();
        Type typeToConvert = typeof(string);

        // Act & Assert
        Assert.Null(converter.CreateConverter(typeToConvert, options));
    }
}
