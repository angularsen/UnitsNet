// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Serialization.SystemTextJson.Value;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests;

public class QuantityConverterOptionsTest
{
    [Fact]
    public void Serializing_WithDecimalNotationConverterAndUnitTypeAndNameConverter_ReturnsExpectedMass()
    {
        // Arrange
        var json = """{"Value":4.2,"Unit":"MassUnit.Gram"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new UnitTypeAndNameConverter());
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_WithFractionalNotationConverterAndStringEnumConverter()
    {
        // Arrange
        var json = """{"Value":{"N":42,"D":10},"Unit":"Gram"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueFractionalNotationConverter(false));
        options.Converters.Add(new JsonStringEnumConverter());
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_OneKilogram_WithJsonQuantityConverter_IgnoringDefaultValues()
    {
        // Arrange
        var json = """{"Value":{"N":1}}""";
        var expected = new Mass(QuantityValue.One, MassUnit.Kilogram);
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_ArrayOfMasses_WithJsonQuantityConverter_IgnoringDefaultValues()
    {
        // Arrange
        var json = """[{"Value":{"N":42,"D":10},"Unit":6},{"Value":{"N":1}},{}]""";
        Mass[] masses = [new(4.2m, MassUnit.Gram), new(1, MassUnit.Kilogram), Mass.Zero];
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(masses, options);
        Mass[] result = JsonSerializer.Deserialize<Mass[]>(json, options)!;

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(masses, result);
    }


    [Fact]
    public void Serializing_WithFractionalNotationAndAbbreviation()
    {
        // Arrange
        var json = """{"Value":{"N":42,"D":10},"Unit":"g"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_ArrayOfMasses_WithJsonQuantityConverter()
    {
        // Arrange
        var json = """[{"Value":{"N":42,"D":10},"Unit":6},{"Value":{"N":1,"D":1},"Unit":8},{"Value":{"N":0,"D":1},"Unit":8}]""";
        Mass[] masses = [new(4.2m, MassUnit.Gram), new(1, MassUnit.Kilogram), Mass.Zero];
        var options = new JsonSerializerOptions();
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        options.Converters.Add(new JsonQuantityConverter());

        // Act
        var actualJson = JsonSerializer.Serialize(masses, options);
        Mass[] result = JsonSerializer.Deserialize<Mass[]>(json, options)!;

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(masses, result);
    }

    [Fact]
    public void Serializing_IQuantity_WithDecimalNotationAndAbbreviation()
    {
        // Arrange
        var json = """{"Value":4.2,"Unit":"g","Type":"Mass"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);
        IQuantity interfaceQuantity = expected;

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithAvailableValueConverter());
        options.Converters.Add(new JsonQuantityConverter());  // this one should not be called when serializing via the IQuantity interface
        options.Converters.Add(new UnitTypeAndNameConverter()); // this one should not be called when serializing via the IQuantity interface

        // Act
        var actualJson = JsonSerializer.Serialize(interfaceQuantity, options);
        IQuantity? result = JsonSerializer.Deserialize<IQuantity>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
        Assert.NotEqual(json, JsonSerializer.Serialize(expected, options)); // this should serialize using the UnitTypeAndNameConverter
    }
}
