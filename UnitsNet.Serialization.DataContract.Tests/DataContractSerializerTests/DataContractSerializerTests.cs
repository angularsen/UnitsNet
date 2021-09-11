using System.IO;
using System.Runtime.Serialization;
using UnitsNet.Serialization.Contracts;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractSerializerTests
{
    public class DataContractSerializerTests : SerializationTestsBase<string>
    {
        private const string XmlSchema = "xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"";
        private const string Namespace = "xmlns=\"http://schemas.datacontract.org/2004/07/UnitsNet\"";

        protected override string SerializeObject(object obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected override T DeserializeObject<T>(string xml)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;
            return (T)serializer.ReadObject(stream);
        }

        [Fact]
        public void DoubleQuantity_SerializedWithValueAndMemberName()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value>1.2</Value><Unit>Milligram</Unit></Mass>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void DecimalQuantity_SerializedWithValueAndMemberName()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedXml = $"<Information {Namespace} {XmlSchema}><Value>1.20</Value><Unit>Exabyte</Unit></Information>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void DoubleQuantity_InScientificNotation_SerializedWithExpandedValueAndMemberName()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);
            var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value>1000000000</Value><Unit>Milligram</Unit></Mass>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndMemberName()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedXml = $"<Information {Namespace} {XmlSchema}><Value>1000000000</Value><Unit>Exabyte</Unit></Information>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void QuantityValueContract_SerializationRoundTrips()
        {
            var quantityValue = new QuantityValueContract<decimal, InformationUnit>(123.456m, Information.BaseUnit);

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<QuantityValueContract<decimal, InformationUnit>>(payload);

            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
        }

        [Fact]
        public void ExtendedQuantityValueContract_SerializationRoundTrips()
        {
            var quantityValue = new ExtendedQuantityValueContract<decimal, string>(123.456, "units", "123.456", 123.456m);

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<ExtendedQuantityValueContract<decimal, string>>(payload);

            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
            Assert.Equal(quantityValue.ValueString, result.ValueString);
            Assert.Equal(quantityValue.ValueType, result.ValueType);
        }

        [Fact]
        public void QuantityWithAbbreviationContract_SerializationRoundTrips()
        {
            var quantityValue = new QuantityWithAbbreviationContract<double, string>(123.456, "Mass", "kg");

            var payload = SerializeObject(quantityValue);
            var result = DeserializeObject<QuantityWithAbbreviationContract<double, string>>(payload);

            Assert.Equal(quantityValue.Unit, result.Unit);
            Assert.Equal(quantityValue.Value, result.Value);
            Assert.Equal(quantityValue.QuantityType, result.QuantityType);
        }
    }
}
