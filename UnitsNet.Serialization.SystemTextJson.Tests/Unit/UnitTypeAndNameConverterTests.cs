// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Unit;

[TestSubject(typeof(UnitTypeAndNameConverter<>))]
public class UnitTypeAndNameConverterTests
{
    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter());
        return options;
    }

    [Fact]
    public void Serialize_ReturnsExpectedTypeAndEnumName()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "MassUnit.Gram"
                                    """;
        JsonSerializerOptions options = CreateOptions();

        // Act
        var json = JsonSerializer.Serialize(unit, options);

        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Serialize_WithConverterForType_ReturnsExpectedTypeAndEnumNameForTheSpecifiedType()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "MassUnit.Gram"
                                    """;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter<MassUnit>(Mass.Info));

        // Act
        var json = JsonSerializer.Serialize(unit, options);

        // Assert
        Assert.Equal(expectedJson, json);
        Assert.Equal("1", JsonSerializer.Serialize(VolumeUnit.AcreFoot, options));
    }

    [Fact]
    public void Serialize_WithCustomQuantities_ReturnsExpectedTypeAndEnumName()
    {
        // Arrange
        const MassUnit unit = MassUnit.Gram;
        const string expectedJson = """
                                    "MassUnit.Gram"
                                    """;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter(new QuantityInfoLookup([Mass.Info])));

        // Act
        var json = JsonSerializer.Serialize(unit, options);

        // Assert
        Assert.Equal(expectedJson, json);
        Assert.Equal("1", JsonSerializer.Serialize(VolumeUnit.AcreFoot, options));
    }

    [Fact]
    public void Serialize_WithCustomMassUnit_ReturnsExpectedTypeAndEnumName()
    {
        // Arrange
        const MassUnit unit = (MassUnit)(-1);
        var customMassInfo = Mass.MassInfo.CreateDefault(units => units.Append(new UnitDefinition<MassUnit>(unit, "Custom", "Customs", BaseUnits.Undefined)));
        const string expectedJson = """
                                    "MassUnit.Custom"
                                    """;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter(new QuantityInfoLookup([customMassInfo])));

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
        const string expectedJson = """{"MassUnit.Gram":"grams","MassUnit.Kilogram":"kilograms"}""";
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
                            "MassUnit.Gram"
                            """;
        const MassUnit expected = MassUnit.Gram;
        JsonSerializerOptions options = CreateOptions();

        // Act
        MassUnit result = JsonSerializer.Deserialize<MassUnit>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithLowercaseUnit_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """
                            "MassUnit.gram"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }

    [Fact]
    public void Deserialize_WithLowercaseUnit_AndCaseInsensitiveMatching_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """
                            "MassUnit.gram"
                            """;
        const MassUnit expected = MassUnit.Gram;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter(true));

        // Act
        MassUnit result = JsonSerializer.Deserialize<MassUnit>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_WithCustomUnit_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """
                            "MassUnit.Custom"
                            """;
        const MassUnit expected = (MassUnit)(-1);
        var customMassInfo = Mass.MassInfo.CreateDefault(units => units.Append(new UnitDefinition<MassUnit>(expected, "Custom", "Customs", BaseUnits.Undefined)));
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter(new QuantityInfoLookup([customMassInfo])));

        // Act
        MassUnit result = JsonSerializer.Deserialize<MassUnit>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deserialize_AsDictionaryKey_ReturnsTheExpectedResult()
    {
        // Arrange
        const string json = """{"MassUnit.Gram":"grams","MassUnit.Kilogram":"kilograms"}""";
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
    public void Deserialize_WithUnitValue_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """
                            "MassUnit.1"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }

    [Fact]
    public void Deserialize_WithEmptyString_ThrowsJsonException()
    {
        // Arrange
        const string json = """
                            ""
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }

    [Fact]
    public void Deserialize_WithInvalidStringFormat_ThrowsJsonException()
    {
        // Arrange
        const string json = """
                            "Gram"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }

    [Fact]
    public void Deserialize_WithInvalidUnitName_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """
                            "MassUnit.Invalid"
                            """;
        JsonSerializerOptions options = CreateOptions();

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }

    [Fact]
    public void Deserialize_WithInvalidUnitName_WhenUsingCaseInsensitiveMatching_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """
                            "MassUnit.Invalid"
                            """;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitTypeAndNameConverter(true));

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<MassUnit>(json, options));
    }
}
