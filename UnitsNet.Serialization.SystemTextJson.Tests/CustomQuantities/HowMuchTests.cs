using System.Text.Json;
using UnitsNet.Serialization.SystemTextJson.Tests.Infrastructure;
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
            var quantityConverterFactory = new UnitsNetIQuantityJsonConverterFactory();
            quantityConverterFactory.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverterFactory);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);

            var serializedQuantity = JsonSerializer.Serialize(quantity, jsonSerializerSettings);

            var deserializedQuantity = JsonSerializer.Deserialize<HowMuch>(serializedQuantity, jsonSerializerSettings);
            Assert.Equal(quantity, deserializedQuantity);
        }
    }
}
