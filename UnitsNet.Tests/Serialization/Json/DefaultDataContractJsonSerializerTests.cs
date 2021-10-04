using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Serialization.Json
{
    /// <summary>
    ///     These tests demonstrate the default behavior of the DataContractJsonSerializer when dealing with quantities
    ///     <remarks>
    ///         <para>Note that the produced schema is different from the one generated using the UnitsNet.Json package</para>
    ///         <para>
    ///             The default schema can easily be modified using a converter, a.k.a. DataContractSurrogate (.NET Framework)
    ///         </para>
    ///     </remarks>
    /// </summary>
    public class DefaultDataContractJsonSerializerTests : SerializationTestsBase<string>
    {
        protected override string SerializeObject(object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType());
            using var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected override T DeserializeObject<T>(string xml)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;
            return (T)serializer.ReadObject(stream);
        }

        [Fact]
        public void DoubleQuantity_SerializedWithDoubleValueAndIntegerUnit()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1.2,\"Unit\":16}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueValueAndIntegerUnit()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.20,\"Unit\":4}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DoubleQuantity_InScientificNotation_SerializedWithExpandedValueAndIntegerUnit()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":16}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndIntegerUnit()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":4}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
        
        [Fact]
        public void DoubleQuantity_DeserializedFromDoubleValueAndIntegerUnit()
        {
            var json = "{\"Value\":1.2,\"Unit\":16}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleQuantity_DeserializedFromQuotedDoubleValueAndIntegerUnit()
        {
            var json = "{\"Value\":\"1.2\",\"Unit\":16}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroQuantity_DeserializedFromIntegerUnitAndNoValue()
        {
            var json = "{\"Unit\":16}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleBaseUnitQuantity_DeserializedFromValueAndNoUnit()
        {
            var json = "{\"Value\":1.2}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroBaseQuantity_DeserializedFromEmptyInput()
        {
            var json = "{}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }
        
        [Fact]
        public void DecimalQuantity_DeserializedFromDecimalValueAndIntegerUnit()
        {
            var json = "{\"Value\":1.200,\"Unit\":4}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalQuantity_DeserializedFromQuotedDecimalValueAndIntegerUnit()
        {
            var json = "{\"Value\":\"1.200\",\"Unit\":4}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalZeroQuantity_DeserializedFromIntegerUnitAndNoValue()
        {
            var json = "{\"Unit\":4}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalBaseUnitQuantity_DeserializedFromDecimalValueAndNoUnit()
        {
            var json = "{\"Value\":1.200}";

            var quantity = DeserializeObject<Information>(json);
            
            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(Information.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DecimalZeroBaseQuantity_DeserializedFromEmptyInput()
        {
            var json = "{}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(Information.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void InterfaceObject_IncludesTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Information(1.20m, InformationUnit.Exabyte) };
            var expectedJson = "{\"Quantity\":{\"__type\":\"Information:#UnitsNet\",\"Value\":1.20,\"Unit\":4}}";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_WithMissingKnownTypeInformation_ThrowsSerializationException()
        {
            var testObject = new TestInterfaceObject { Quantity = new Volume(1.2, VolumeUnit.Microliter) };

            Assert.Throws<SerializationException>(() => SerializeObject(testObject));
        }
    }
}
