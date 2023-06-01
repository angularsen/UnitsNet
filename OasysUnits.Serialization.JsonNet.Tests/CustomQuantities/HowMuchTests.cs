using Newtonsoft.Json;
using OasysUnits.Tests.CustomQuantities;
using Xunit;

namespace OasysUnits.Serialization.JsonNet.Tests.CustomQuantities
{
    public class HowMuchTests
    {
        [Fact]
        public static void SerializeAndDeserializeCreatesSameObjectForIQuantity()
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var quantityConverter = new OasysUnitsIQuantityJsonConverter();
            quantityConverter.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverter);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);

            var serializedQuantity = JsonConvert.SerializeObject(quantity, jsonSerializerSettings);

            var deserializedQuantity = JsonConvert.DeserializeObject<HowMuch>(serializedQuantity, jsonSerializerSettings);
            Assert.Equal(quantity, deserializedQuantity);
        }
    }
}
