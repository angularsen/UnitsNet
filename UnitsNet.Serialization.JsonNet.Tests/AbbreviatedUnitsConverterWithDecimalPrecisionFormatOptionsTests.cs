// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using Newtonsoft.Json;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests;

public class AbbreviatedUnitsConverterWithDecimalPrecisionFormatOptionsTests : JsonNetSerializationTestsBase
{
    public AbbreviatedUnitsConverterWithDecimalPrecisionFormatOptionsTests()
        : base(new AbbreviatedUnitsConverter(new QuantityValueFormatOptions
        {
            // all values should be serialized as G29
            SerializationFormat = QuantityValueSerializationFormat.DecimalPrecision,
            // all values should be converted from their exact decimal representation (any number of digits)
            DeserializationFormat = QuantityValueDeserializationFormat.ExactNumber
        }))
    {
    }

    [Fact]
    public void LargeQuantity_SerializedWithHighPrecisionAndAbbreviatedUnit()
    {
        // Arrange
        var value = Mass.FromMilligrams(QuantityValue.Parse("12345678901234567890.1234567890123456789", CultureInfo.InvariantCulture));
        const string expectedJson = """{"Value":12345678901234567890.123456789,"Unit":"mg","Type":"Mass"}""";

        // Act
        var result = SerializeObject(value);

        //Assert
        Assert.Equal(expectedJson, result);
    }

    [Fact]
    public void Quantity_DeserializedFromVeryPreciseValueAndAbbreviatedUnit()
    {
        // Arrange
        const string json = """{"Value":12345678901234567890.1234567890123456789,"Unit":"mg","Type":"Mass"}""";
        var expectedValue = QuantityValue.Parse("12345678901234567890.1234567890123456789", CultureInfo.InvariantCulture);

        // Act
        Mass quantity = DeserializeObject<Mass>(json);

        //Assert
        Assert.Equal(expectedValue, quantity.Value);
        Assert.Equal(MassUnit.Milligram, quantity.Unit);
    }

    [Fact]
    public void Deserializing_WithNullValue_ThrowsJsonSerializationException()
    {
        const string json = """{"Value":null,"Unit":"mg","Type":"Mass"}""";

        Assert.Throws<JsonSerializationException>(() => DeserializeObject<Mass>(json));
    }

    [Fact]
    public void Deserializing_WithEmptyValue_ThrowsJsonSerializationException()
    {
        const string json = """{"Value":"","Unit":"mg","Type":"Mass"}""";

        Assert.Throws<FormatException>(() => DeserializeObject<Mass>(json));
    }
}
