// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Serialization.SystemTextJson.Value;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests;
public sealed class TestObject
{
    public Mass? NullableMass { get; set; }
    public Mass NonNullableMass { get; set; }
}

[TestSubject(typeof(JsonQuantityConverter<,>))]
public class JsonQuantityConverterTest
{
    [Fact]
    public void Serializing_WithDecimalNotationAndAbbreviatedUnit()
    {
        // Arrange
        var json = """{"Value":4.2,"Unit":"g"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>());

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Serializing_WithDecimalNotationAndAbbreviatedUnit_WithCamelCase()
    {
        // Arrange
        var json = """{"value":4.2,"unit":"g"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Serializing_OneKilogram_WithGenericQuantityConverter_IgnoringDefaultValues()
    {
        // Arrange
        var json = """{"Value":{"N":1}}""";
        var expected = new Mass(QuantityValue.One, MassUnit.Kilogram);
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        options.Converters.Add(QuantityValueFractionalNotationConverter.Default);
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_ZeroGrams_WithGenericQuantityConverter_IgnoringDefaultValues()
    {
        // Arrange
        var json = """{"Unit":6}""";
        var expected = new Mass(QuantityValue.Zero, MassUnit.Gram);
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_ZeroMass_WithGenericQuantityConverter_IgnoringDefaultValues()
    {
        // Arrange
        var json = "{}";
        Mass expected = Mass.Zero;
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var actualJson = JsonSerializer.Serialize(expected, options);
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(json, actualJson);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Serializing_MassAsNullable()
    {
        // Arrange
        var testObject = new TestObject { NullableMass = Mass.FromGrams(5), NonNullableMass = Mass.FromMilligrams(10) };
        var expectedJson = """{"NullableMass":{"Value":5,"Unit":"g"},"NonNullableMass":{"Value":10,"Unit":"mg"}}""";

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Serializing_NullMass_AsNullable()
    {
        // Arrange
        var testObject = new TestObject { NonNullableMass = Mass.FromMilligrams(10) };
        var expectedJson = """{"NullableMass":null,"NonNullableMass":{"Value":10,"Unit":"mg"}}""";

        var options = new JsonSerializerOptions();
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Serializing_NullMass_AsNullable_IgnoringNullValues()
    {
        // Arrange
        var testObject = new TestObject();
        var expectedJson = """{"NonNullableMass":{"Value":0,"Unit":"kg"}}""";

        var options = new JsonSerializerOptions{DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Serializing_NullMass_AsNullable_IgnoringNullAndDefaultValues()
    {
        // Arrange
        var testObject = new TestObject();
        var expectedJson = "{}";

        var options = new JsonSerializerOptions{DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault};
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        var json = JsonSerializer.Serialize(testObject, options);
        
        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void Deserializing_WithDecimalNotationAndAbbreviatedUnit_IgnoringCase()
    {
        // Arrange
        var json = """{"VALUE":4.2,"uNit":"G"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Deserializing_WithDecimalNotationAndAbbreviatedUnit_WithExtraProperties(bool caseInsensitive)
    {
        // Arrange
        var json = """{"Value":4.2,"Unit":"g", "Something":"else"}""";
        var expected = new Mass(4.2m, MassUnit.Gram);

        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = caseInsensitive};
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));

        // Act
        Mass result = JsonSerializer.Deserialize<Mass>(json, options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void Deserialize_WithAdditionalProperties_WhenUnmappedMemberHandlingIsDisallowed_ThrowsJsonException(bool caseInsensitive)
    {
        // Arrange
        var invalidJson = """{"Value":4.2,"Unit":"g", "Something":"else"}""";
        var options = new JsonSerializerOptions { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow, PropertyNameCaseInsensitive = caseInsensitive };
        options.Converters.Add(new QuantityValueDecimalNotationConverter());
        options.Converters.Add(new AbbreviatedUnitConverter());
        options.Converters.Add(new JsonQuantityConverter<Mass, MassUnit>(Mass.Info));
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Mass>(invalidJson, options));
    }

    [Fact]
    public void Constructor_DefaultQuantityInfo_Success()
    {
        var converter = new JsonQuantityConverter<Length, LengthUnit>(Length.Info);
        Assert.NotNull(converter);
    }

    [Fact]
    public void Constructor_CustomQuantityInfo_Success()
    {
        QuantityInfo<Length, LengthUnit> quantityInfo = Length.Info;
        var converter = new JsonQuantityConverter<Length, LengthUnit>(quantityInfo);
        Assert.NotNull(converter);
    }

    [Fact]
    public void Read_InvalidJson_ThrowsJsonException()
    {
        var options = new JsonSerializerOptions { Converters = { new JsonQuantityConverter<Length, LengthUnit>(Length.Info) } };
#pragma warning disable JSON001
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Length>("InvalidJson", options));
#pragma warning restore JSON001
    }
}
