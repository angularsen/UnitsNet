using Newtonsoft.Json;
using UnitsNet.Serialization.JsonNet;
using Xunit;

namespace UnitsNet.Tests.CustomQuantities
{
    public class HowMuchTests
    {
        [Fact]
        public static void SerializeAndDeserializeCreatesSameObjectForIQuantity()
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var quantityConverter = new UnitsNetIQuantityJsonConverter();
            quantityConverter.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverter);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);

            var serializedQuantity = JsonConvert.SerializeObject(quantity, jsonSerializerSettings);

            var deserializedQuantity = JsonConvert.DeserializeObject<HowMuch>(serializedQuantity, jsonSerializerSettings);
            Assert.Equal(quantity, deserializedQuantity);
        }
    }
}
