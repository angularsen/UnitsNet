using System;
using System.IO;
using System.Runtime.Serialization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Serialization.Xml
{
    /// <summary>
    ///     These tests demonstrate the behavior of the DataContractSerializer (the default WCF serializer) when dealing with
    ///     quantities
    /// </summary>
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
            return (T)(serializer.ReadObject(stream) ?? throw new InvalidOperationException("Read 'null' from stream."));
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
        public void InterfaceObject_IncludesTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Information(1.20m, InformationUnit.Exabyte) };

            var quantityNamespace = "xmlns:a=\"http://schemas.datacontract.org/2004/07/UnitsNet\""; // there is an extra 'a' compared to Namespace
            var expectedQuantityXml = $"<Quantity i:type=\"a:Information\" {quantityNamespace}><a:Value>1.20</a:Value><a:Unit>Exabyte</a:Unit></Quantity>";
            var expectedXml = $"<TestInterfaceObject xmlns=\"http://schemas.datacontract.org/2004/07/UnitsNet.Tests.Serialization\" {XmlSchema}>{expectedQuantityXml}</TestInterfaceObject>";

            var xml = SerializeObject(testObject);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void InterfaceObject_WithMissingKnownTypeInformation_ThrowsSerializationException()
        {
            var testObject = new TestInterfaceObject { Quantity = new Volume(1.2, VolumeUnit.Microliter) };

            Assert.Throws<SerializationException>(() => SerializeObject(testObject));
        }
    }
}
