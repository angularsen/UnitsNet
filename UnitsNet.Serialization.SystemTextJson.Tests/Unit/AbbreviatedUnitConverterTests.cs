// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text.Json;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Unit;

[TestSubject(typeof(AbbreviatedUnitConverter))]
public class AbbreviatedUnitConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedUnitConverter());
        return options;
    }

    [Fact]
    public void Serialize_ReturnsExpectedAbbreviation()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "g"
                                    """;
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var json = JsonSerializer.Serialize(unit, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }
    
    [Fact]
    public void Serialize_WithConverterForType_ReturnsExpectedAbbreviationForTheSpecifiedType()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "g"
                                    """;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedUnitConverter<MassUnit>());
        
        // Act
        var json = JsonSerializer.Serialize(unit, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
        Assert.Equal("1", JsonSerializer.Serialize(VolumeUnit.AcreFoot, options));
    }

    [Fact]
    public void Serialize_WithCustomAbbreviations_ReturnsExpectedAbbreviation()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "g (custom)"
                                    """;
        var abbreviations = new UnitAbbreviationsCache([Mass.Info]);
        abbreviations.MapUnitToDefaultAbbreviation(MassUnit.Gram, "g (custom)");
        
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedUnitConverter(new UnitParser(abbreviations)));
        
        // Act
        var json = JsonSerializer.Serialize(unit, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
        Assert.Equal("1", JsonSerializer.Serialize(VolumeUnit.AcreFoot, options));
    }

    [Fact]
    public void Serialize_WithCustomCulture_ReturnsExpectedAbbreviation()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "\u0433"
                                    """; // "г"
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedUnitConverter<MassUnit>(UnitParser.Default, CultureInfo.GetCultureInfo("ru-RU")));
        
        // Act
        var json = JsonSerializer.Serialize(unit, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Serialize_AsDictionaryKey_ReturnsTheExpectedResult()
    {
        // Arrange
        var dictionary = new Dictionary<MassUnit, string>
        {
            {MassUnit.Gram, "grams"},
            {MassUnit.Kilogram, "kilograms"}
        };
        const string expectedJson = """{"g":"grams","kg":"kilograms"}""";
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        var json = JsonSerializer.Serialize(dictionary, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Deserialize_ReturnsExpectedMassUnit()
    {
        // Arrange
        const string json = """
                            "g"
                            """;
        const MassUnit expected = MassUnit.Gram;
        JsonSerializerOptions options = CreateOptions();

        // Act
        MassUnit result = JsonSerializer.Deserialize<MassUnit>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithCustomCulture_ReturnsExpectedMassUnit()
    {
        // Arrange
        var json = """
                   "\u0433"
                   """; // "г"
        MassUnit expected = MassUnit.Gram;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedUnitConverter(UnitParser.Default, CultureInfo.GetCultureInfo("ru-RU")));

        // Act
        MassUnit result = JsonSerializer.Deserialize<MassUnit>(json, options);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_AsDictionaryKey_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"g":"grams","kg":"kilograms"}""";
        var expectedDictionary = new Dictionary<MassUnit, string>
        {
            {MassUnit.Gram, "grams"},
            {MassUnit.Kilogram, "kilograms"}
        };
        JsonSerializerOptions options = CreateOptions();
        
        // Act
        Dictionary<MassUnit, string>? dictionary = JsonSerializer.Deserialize<Dictionary<MassUnit, string>>(json, options);
        
        // Assert
        Assert.Equal(expectedDictionary, dictionary);
    }

    [Fact]
    public void Deserialize_WithInvalidAbbreviation_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """
                            "invalid"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }
}
