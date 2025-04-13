// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization;
using UnitsNet.Serialization;
using UnitsNet.Units;

namespace UnitsNet.Tests.Serialization.Xml;

/// <summary>
///     These tests demonstrate the behavior of the DataContractSerializer (the default WCF serializer) + QuantityValueSurrogateSerializationProvider, when dealing with
///     quantities.
/// </summary>
/// <remarks>Unlike the default serializer, here we store the BigInteger types as strings instead of "sign + bytes."</remarks>
public class DataContractSerializerWithSurrogateProviderTests : SerializationTestsBase<string>
{
    private const string XmlSchema = "xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"";
    private const string Namespace = "xmlns=\"http://schemas.datacontract.org/2004/07/UnitsNet\"";

    protected override string SerializeObject(object obj)
    {
        var serializer = new DataContractSerializer(obj.GetType());
        serializer.SetSerializationSurrogateProvider(QuantityValueSurrogateSerializationProvider.Instance);
        using var stream = new MemoryStream();
        serializer.WriteObject(stream, obj);
        stream.Position = 0;
        using var streamReader = new StreamReader(stream);
        return streamReader.ReadToEnd();
    }

    protected override T DeserializeObject<T>(string xml)
    {
        var serializer = new DataContractSerializer(typeof(T));
        serializer.SetSerializationSurrogateProvider(QuantityValueSurrogateSerializationProvider.Instance);
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
        var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value><N>12</N><D>10</D></Value><Unit>Milligram</Unit></Mass>";

        var xml = SerializeObject(quantity);

        Assert.Equal(expectedXml, xml);
    }

    [Fact]
    public void IntegerQuantity_SerializedWithNumeratorOnlyValueAndMemberName()
    {
        var quantity = new Mass(42, MassUnit.Milligram);
        var expectedXml = $"<Mass {Namespace} {XmlSchema}><Value><N>42</N></Value><Unit>Milligram</Unit></Mass>";

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
        var expectedQuantityXml = $"<Quantity i:type=\"a:Information\" {quantityNamespace}><a:Value><a:N>12</a:N><a:D>10</a:D></a:Value><a:Unit>Exabyte</a:Unit></Quantity>";
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
