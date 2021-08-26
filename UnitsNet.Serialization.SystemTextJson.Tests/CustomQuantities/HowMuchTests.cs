using System.Text.Json;

using UnitsNet.Tests.CustomQuantities;
using Xunit;

namespace UnitsNet.Serialization.SystemTextJson.Tests.CustomQuantities
{
    public class HowMuchTests
    {
        [Fact]
        public static void SerializeAndDeserializeCreatesSameObjectForIQuantity()
        {
            var jsonSerializerSettings = new JsonSerializerOptions() { WriteIndented = true };
            var quantityConverter = new UnitsNetIQuantityJsonConverter();
            quantityConverter.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverter);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);

            var serializedQuantity = JsonSerializer.Serialize(quantity, jsonSerializerSettings);

            var deserializedQuantity = JsonSerializer.Deserialize<HowMuch>(serializedQuantity, jsonSerializerSettings);
            Assert.Equal(quantity, deserializedQuantity);
        }
    }
}
