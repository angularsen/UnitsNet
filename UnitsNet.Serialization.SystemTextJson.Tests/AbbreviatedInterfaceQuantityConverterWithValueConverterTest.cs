// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using UnitsNet.Serialization.SystemTextJson.Value;
using UnitsNet.Units;

namespace UnitsNet.Serialization.SystemTextJson.Tests;

[TestSubject(typeof(AbbreviatedInterfaceQuantityWithValueConverter))]
public class AbbreviatedInterfaceQuantityConverterWithValueConverterTest
{
    [Fact]
    public void Constructor_WithNullAbbreviations_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new AbbreviatedInterfaceQuantityWithValueConverter(null!));
        Assert.Throws<ArgumentNullException>(() => new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default, null!));
    }

    [Theory]
    [InlineData("""{"Value":10,"Unit":"m","Type":"Length"}""", typeof(Length), 10, LengthUnit.Meter)]
    [InlineData("""{"Value":5,"Unit":"g","Type":"Mass"}""", typeof(Mass), 5, MassUnit.Gram)]
    [InlineData("""{"Value":5,"Type":"Mass"}""", typeof(Mass), 5, MassUnit.Kilogram)]
    [InlineData("""{"Value":5,"Unit":"kg"}""", typeof(Mass), 5, MassUnit.Kilogram)]
    [InlineData("""{"Value":0,"Unit":"s","Type":"Duration"}""", typeof(Duration), 0, DurationUnit.Second)]
    public void Deserializing_WithDecimalNotation_ReturnsCorrectQuantity(string json, Type expectedType, decimal expectedValue, Enum expectedUnit)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
    
        // Act
        IQuantity result = JsonSerializer.Deserialize<IQuantity>(json, options)!;

        // Assert
        Assert.IsType(expectedType, result);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }
    
    [Theory]
    [InlineData("""{"value":10,"unit":"m","type":"Length"}""", typeof(Length), 10, LengthUnit.Meter)]
    [InlineData("""{"value":5,"unit":"g","type":"Mass"}""", typeof(Mass), 5, MassUnit.Gram)]
    [InlineData("""{"value":0,"unit":"s","type":"Duration"}""", typeof(Duration), 0, DurationUnit.Second)]
    public void Deserializing_WithDecimalNotation_And_CamelCasePropertyNamingPolicy_ReturnsCorrectQuantity(string json, Type expectedType, decimal expectedValue, Enum expectedUnit)
    {
        // Arrange
        var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
    
        // Act
        IQuantity result = JsonSerializer.Deserialize<IQuantity>(json, options)!;

        // Assert
        Assert.IsType(expectedType, result);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }
    

    [Theory]
    [InlineData("""{"Value":10,"Unit":"m","Type":"Length"}""", typeof(Length), 10, LengthUnit.Meter)]
    [InlineData("""{"value":5,"unit":"g","type":"Mass"}""", typeof(Mass), 5, MassUnit.Gram)]
    [InlineData("""{"VALUE":0,"uniT":"s","tYPe":"Duration"}""", typeof(Duration), 0, DurationUnit.Second)]
    public void Deserializing_WithDecimalNotation_IgnoringCase_ReturnsCorrectQuantity(string json, Type expectedType, decimal expectedValue, Enum expectedUnit)
    {
        // Arrange
        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        // Act
        IQuantity result = JsonSerializer.Deserialize<IQuantity>(json, options)!;

        // Assert
        Assert.IsType(expectedType, result);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Deserializing_WithDecimalNotation_WithExtraProperties(bool ignoreCasing)
    {
        // Arrange
        const string json = """{"UnknownProperty":"Something", "Value":5,"Unit":"g","Type":"Mass"}""";
        var expectedQuantity = Mass.FromGrams(5);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = ignoreCasing };
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
        
        // Act
        IQuantity result = JsonSerializer.Deserialize<IQuantity>(json, options)!;
        
        // Assert
        Assert.Equal(expectedQuantity, result);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Deserialize_WithAdditionalProperties_WhenUnmappedMemberHandlingIsDisallowed_ThrowsJsonException(bool ignoreCasing)
    {
        // Arrange
        const string json = """{"UnknownProperty":"Something", "Value":5,"Unit":"g","Type":"Mass"}""";
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = ignoreCasing, UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow};
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
        
        // Assert
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<IQuantity>(json, options));
    }

    [Fact]
    public void Deserializing_WithoutUnitAndType_ThrowsJsonException()
    {
        // Arrange
        const string json = """{"Value":5}""";
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        // Act
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<IQuantity>(json, options));

        // Assert
        Assert.Equal("Both the quantity name and unit abbreviation are missing from the JSON.", exception.Message);
    }

    [Fact]
    public void Deserializing_WithAmbiguousUnitAndNotType_ThrowsAmbiguousUnitParseException()
    {
        // Arrange
        const string json = """{"Value":10,"Unit":"m"}""";;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        // Act
        var exception = Assert.Throws<AmbiguousUnitParseException>(() => JsonSerializer.Deserialize<IQuantity>(json, options));

        // Assert
        Assert.Equal("""Cannot parse "m" since it matches multiple units: Meter ("m"), Minute ("m").""", exception.Message);
    }

    [Fact]
    public void Deserializing_WithNonAmbiguousUnitAndNoType_ReturnsTheExpectedQuantity()
    {
        // Arrange
        const string json = """{"Value":10,"Unit":"m"}""";;
        var expected = Length.FromMeters(10);
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default, new UnitParser([Length.Info])));

        // Act
        IQuantity result = JsonSerializer.Deserialize<IQuantity>(json, options)!;

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, "Meter", "Length", """{"Value":10,"Unit":"m","Type":"Length"}""")]
    [InlineData(5, "Kilogram", "Mass", """{"Value":5,"Unit":"kg","Type":"Mass"}""")]
    [InlineData(0, "Second", "Duration", """{"Value":0,"Unit":"s","Type":"Duration"}""")]
    public void Serializing_WithDecimalNotation_ReturnsTheExpectedJson(double value, string unit, string type, string expectedJson)
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        IQuantity quantity = Quantity.From(value, type, unit);
        
        // Act
        var actualJson = JsonSerializer.Serialize(quantity, options);
        
        // Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Fact]
    public void Deserializing_WithUnknownQuantity_ThrowsQuantityNotFoundException()
    {
        // Arrange
        const string json = """{"Value":10,"Unit":"m","Type":"Length"}""";;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default, new UnitParser([Mass.Info])));

        // Assert
        Assert.Throws<QuantityNotFoundException>(() => JsonSerializer.Deserialize<IQuantity>(json, options));
    }

    [Fact]
    public void Deserializing_WithUnknownUnit_ThrowsUnitNotFoundException()
    {
        // Arrange
        const string json = """{"Value":10,"Unit":"unknown","Type":"Length"}""";;
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Deserialize<IQuantity>(json, options));
    }
    
    [Theory]
    [InlineData(10, "Meter", "Length", """{"value":10,"unit":"m","type":"Length"}""")]
    [InlineData(5, "Kilogram", "Mass", """{"value":5,"unit":"kg","type":"Mass"}""")]
    [InlineData(0, "Second", "Duration", """{"value":0,"unit":"s","type":"Duration"}""")]
    public void Serializing_WithDecimalNotation_And_CamelCasePropertyNamingPolicy_ReturnsTheExpectedJson(double value, string unit, string type, string expectedJson)
    {
        // Arrange
        var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
        
        IQuantity quantity = Quantity.From(value, type, unit);
        
        // Act
        var actualJson = JsonSerializer.Serialize(quantity, options);
        
        // Assert
        Assert.Equal(expectedJson, actualJson);
    }
    
    [Theory]
    [InlineData(10, "Centimeter", "Length", """{"Value":10,"Unit":"cm","Type":"Length"}""")]
    [InlineData(5, "Kilogram", "Mass", """{"Value":5,"Type":"Mass"}""")]
    [InlineData(0, "Second", "Duration", """{"Type":"Duration"}""")]
    public void Serializing_WithDecimalNotation_IgnoringDefaultValues_ReturnsTheExpectedJson(double value, string unit, string quantityName, string expectedJson)
    {
        // Arrange
        var options = new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault};
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));
        
        IQuantity quantity = Quantity.From(value, quantityName, unit);
        
        // Act
        var actualJson = JsonSerializer.Serialize(quantity, options);
        
        // Assert
        Assert.Equal(expectedJson, actualJson);
    }

    [Fact]
    public void Serializing_NullQuantity_WritesNull()
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default));

        IQuantity quantity = null!;
        
        // Act
        var actualJson = JsonSerializer.Serialize(quantity, options);
        
        // Assert
        Assert.Equal("null", actualJson);
    }

    [Fact]
    public void Serializing_UnknownQuantity_ThrowsUnitNotFoundException()
    {
        // Arrange
        var options = new JsonSerializerOptions();
        options.Converters.Add(new AbbreviatedInterfaceQuantityWithValueConverter(QuantityValueMixedNotationConverter.Default, new UnitParser([Mass.Info])));
        
        IQuantity quantity = Length.Zero;

        // Assert
        Assert.Throws<UnitNotFoundException>(() => JsonSerializer.Serialize(quantity, options));
    }
}
