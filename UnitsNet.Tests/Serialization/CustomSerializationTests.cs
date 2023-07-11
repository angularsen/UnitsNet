// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Serialization;

public class CustomSerializationTests
{
#if NET7_0_OR_GREATER
    private record QuantityDto(double Value, string QuantityName, string UnitName);

    /// <summary>
    ///     This showcases how to serialize and deserialize a quantity to and from JSON using a custom DTO, as described in the wiki:<br />
    ///     https://github.com/angularsen/UnitsNet/wiki/Serializing-to-JSON,-XML-and-more#-recommended-map-to-your-own-custom-dto-types
    /// </summary>
    [Fact]
    public void CanMapToJsonAndBackViaCustomDto()
    {
        // The original quantity.
        IQuantity q = Length.FromCentimeters(5);

        // Map to DTO.
        QuantityDto dto = new(
            Value: (double)q.Value,
            QuantityName: q.QuantityInfo.Name,
            UnitName: q.Unit.ToString());

        /* Serialize to JSON:
        {
            "Value": 5,
            "QuantityName": "Length",
            "UnitName": "Centimeter"
        }
        */
        string json = System.Text.Json.JsonSerializer.Serialize(dto);

        // Deserialize from JSON.
        QuantityDto deserialized = System.Text.Json.JsonSerializer.Deserialize<QuantityDto>(json)!;

        // Map to IQuantity.
        bool tryFromResult = Quantity.TryFrom(deserialized.Value, deserialized.QuantityName, deserialized.UnitName, out IQuantity? deserializedQuantity);

        // Assert
        Assert.True(tryFromResult);
        Assert.NotNull(deserializedQuantity);
        Assert.Equal(5, deserializedQuantity!.Value);
        Assert.Equal(LengthUnit.Centimeter, deserializedQuantity.Unit);
    }
#endif
}
