using Newtonsoft.Json;
using UnitsNet.Tests.CustomQuantities;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests.CustomQuantities
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

        [Fact]
        public static void SerializeObjectWithNullQuantity()
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var quantityConverter = new UnitsNetIQuantityJsonConverter();
            quantityConverter.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverter);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);
            var objectToSerialize = new TestObject { NonNullableQuantity = quantity };

            var serializedQuantity = JsonConvert.SerializeObject(objectToSerialize, jsonSerializerSettings);
            TestObject deserializedQuantity = JsonConvert.DeserializeObject<TestObject>(serializedQuantity, jsonSerializerSettings);

            Assert.Equal(quantity, deserializedQuantity.NonNullableQuantity);
            Assert.Null(deserializedQuantity.NullableQuantity);
        }

        [Fact]
        public static void SerializeObjectWithNullableQuantity()
        {
            var jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            var quantityConverter = new UnitsNetIQuantityJsonConverter();
            quantityConverter.RegisterCustomType(typeof(HowMuch), typeof(HowMuchUnit));
            jsonSerializerSettings.Converters.Add(quantityConverter);

            var quantity = new HowMuch(12.34, HowMuchUnit.ATon);
            var objectToSerialize = new TestObject { NonNullableQuantity = quantity, NullableQuantity = quantity };

            var serializedQuantity = JsonConvert.SerializeObject(objectToSerialize, jsonSerializerSettings);
            TestObject deserializedQuantity = JsonConvert.DeserializeObject<TestObject>(serializedQuantity, jsonSerializerSettings); // exception here

            Assert.Equal(quantity, deserializedQuantity.NonNullableQuantity);
            Assert.Equal(quantity, deserializedQuantity.NullableQuantity);
        }

        public sealed class TestObject
        {
            public HowMuch? NullableQuantity { get; set; }
            public HowMuch NonNullableQuantity { get; set; }
        }
    }
}
