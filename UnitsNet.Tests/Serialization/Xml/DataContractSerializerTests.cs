using System.Runtime.Serialization;
using UnitsNet.Units;

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
        private const string NumericsNamespace = "\"http://schemas.datacontract.org/2004/07/System.Numerics\"";
        private const string ArraysNamespace = "\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"";

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
        public void Quantity_SerializedWithValueAndMemberName()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var numeratorFormat = $"<N xmlns:a={NumericsNamespace}><a:_bits i:nil=\"true\" xmlns:b={ArraysNamespace}/><a:_sign>12</a:_sign></N>";
            var denominatorFormat = $"<D xmlns:a={NumericsNamespace}><a:_bits i:nil=\"true\" xmlns:b={ArraysNamespace}/><a:_sign>10</a:_sign></D>";
            var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value>{numeratorFormat}{denominatorFormat}</Value><Unit>Milligram</Unit></Mass>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void IntegerQuantity_SerializedWithBothNumeratorAndDenominatorValueAndMemberName()
        {
            var quantity = new Mass(42, MassUnit.Milligram);
            var numeratorFormat = $"<N xmlns:a={NumericsNamespace}><a:_bits i:nil=\"true\" xmlns:b={ArraysNamespace}/><a:_sign>42</a:_sign></N>";
            var denominatorFormat = $"<D xmlns:a={NumericsNamespace}><a:_bits i:nil=\"true\" xmlns:b={ArraysNamespace}/><a:_sign>1</a:_sign></D>";
            var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value>{numeratorFormat}{denominatorFormat}</Value><Unit>Milligram</Unit></Mass>";
            
            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void ZeroQuantity_WithNonBaseUnit_SerializedMemberNameAndNoValue()
        {
            var quantity = new Mass(0, MassUnit.Milligram);
            var expectedXml = $"<Mass {Namespace} {XmlSchema}><Unit>Milligram</Unit></Mass>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void DefaultQuantity_SerializedWithoutAnyFields()
        {
            var quantity = default(Mass);
            var expectedXml = $"<Mass {Namespace} {XmlSchema}/>";

            var xml = SerializeObject(quantity);

            Assert.Equal(expectedXml, xml);
        }

        [Fact]
        public void InterfaceObject_IncludesTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Information(1.20, InformationUnit.Exabyte) };

            var quantityNamespace = "xmlns:a=\"http://schemas.datacontract.org/2004/07/UnitsNet\""; // there is an extra 'a' compared to Namespace
            
            var numeratorFormat = "<a:N xmlns:b=\"http://schemas.datacontract.org/2004/07/System.Numerics\"><b:_bits i:nil=\"true\" xmlns:c=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"/><b:_sign>12</b:_sign></a:N>";
            var denominatorFormat = "<a:D xmlns:b=\"http://schemas.datacontract.org/2004/07/System.Numerics\"><b:_bits i:nil=\"true\" xmlns:c=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"/><b:_sign>10</b:_sign></a:D>";
            
            var expectedQuantityXml = $"<Quantity i:type=\"a:Information\" {quantityNamespace}><a:Value>{numeratorFormat}{denominatorFormat}</a:Value><a:Unit>Exabyte</a:Unit></Quantity>";
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
