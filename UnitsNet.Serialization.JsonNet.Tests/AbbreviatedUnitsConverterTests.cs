using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnitsNet.Serialization.JsonNet.Tests.Infrastructure;
using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Tests.Serialization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public class AbbreviatedUnitsConverterTests : JsonNetSerializationTestsBase
    {
        public AbbreviatedUnitsConverterTests() : base(new AbbreviatedUnitsConverter())
        {
        }

        #region Serialization tests
        
        [Fact]
        public void DoubleQuantity_SerializedWithDoubleValueAndAbbreviatedUnit()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedJson = """{"Value":1.2,"Unit":"mg","Type":"Mass"}""";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_IncludesTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Information(1.2, InformationUnit.Exabyte) };
            var expectedJson = """{"Quantity":{"Value":1.2,"Unit":"EB","Type":"Information"}}""";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_SerializesWithoutKnownTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Volume(1.2, VolumeUnit.Microliter) };

            var expectedJson = """{"Quantity":{"Value":1.2,"Unit":"µl","Type":"Volume"}}""";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_WithNullValueSerializesAsNull()
        {
            var testObject = new TestInterfaceObject { Quantity = null! };
            var expectedJson =  """{"Quantity":null}""";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }
          
        [Fact]
        public void NonNullNullableValueNestedInObject_ExpectJsonUnaffected()
        {
            var testObj = new TestObject()
            {
                NullableFrequency = Frequency.FromHertz(10),
                NonNullableFrequency = Frequency.FromHertz(10)
            };

            string expectedJson = """{"NullableFrequency":{"Value":10.0,"Unit":"Hz","Type":"Frequency"},"NonNullableFrequency":{"Value":10.0,"Unit":"Hz","Type":"Frequency"}}""";

            string json = SerializeObject(testObj);

            Assert.Equal(expectedJson, json);
        }
          
        [Fact]
        public void NullQuantityNestedInObject_SerializesAsNull()
        {
            var testObj = new TestObject()
            {
                NonNullableFrequency = Frequency.FromHertz(10)
            };

            string expectedJson = """{"NullableFrequency":null,"NonNullableFrequency":{"Value":10.0,"Unit":"Hz","Type":"Frequency"}}""";

            string json = SerializeObject(testObj);

            Assert.Equal(expectedJson, json);
        }
        
        [Fact]
        public void NullObject_SerializesAsNull()
        {
            var abbreviatedUnitsConverter = new AbbreviatedUnitsConverter();
            var result = new StringBuilder();
            using(var stringWriter = new StringWriter(result))
            using (var writer = new JsonTextWriter(stringWriter))
            {
                abbreviatedUnitsConverter.WriteJson(writer, (object)null, JsonSerializer.CreateDefault());
            }

            Assert.Equal("null", result.ToString());
        }

        [Fact]
        public void WriteJson_GivenAnotherType_ThrowsJsonSerializationException()
        {
            var abbreviatedUnitsConverter = new AbbreviatedUnitsConverter();
            using var stringWriter = new StringWriter();
            using var writer = new JsonTextWriter(stringWriter);
            Assert.Throws<JsonException>(() => abbreviatedUnitsConverter.WriteJson(writer, DateTime.MinValue, JsonSerializer.CreateDefault()));
        }

        [Fact]
        public void Serializing_UnknownQuantity_ThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => SerializeObject(HowMuch.From(1, HowMuchUnit.Some)));
        }

        #endregion

        #region Deserialization tests

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit()
        {
            var json = """{"Value":1.2,"Unit":"mg","Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);
            
            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit()
        {
            var json = """{"Value":1.2,"Unit":"mg"}""";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndNonAmbiguousAbbreviatedUnit_WithoutQuantityType()
        {
            var json = """{"Value":1.2,"Unit":"em"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.EarthMass, quantity.Unit);
        }

        [Fact]
        public void ThrowsAmbiguousUnitParseException_WhenDeserializingAmbiguousAbbreviation_WithoutQuantityType()
        {
            var json = """{"Value":1.2,"Unit":"mg"}""";

            Assert.Throws<AmbiguousUnitParseException>(() => DeserializeObject<IQuantity>(json));
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit_CaseInsensitive()
        {
            var json = """{"value":1.2,"unit":"Mg","type":"mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit_CaseSensitiveUnits()
        {
            var json = """{"value":1.2,"unit":"Mbar","type":"pressure"}""";

            var megabar = DeserializeObject<IQuantity>(json);
            var millibar = DeserializeObject<IQuantity>(json.ToLower());

            Assert.Equal(1.2, megabar.Value);
            Assert.Equal(1.2, millibar.Value);
            Assert.Equal(PressureUnit.Megabar, megabar.Unit);
            Assert.Equal(PressureUnit.Millibar, millibar.Unit);
        }
        
        [Fact]
        public void Converter_IgnoresUnknownProperties()
        {
            var json = """{"Value":1.2,"Something":"Else","Unit":"mg","Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void Deserializing_FromUnknownUnitForTargetQuantity_ThrowsUnitsNotFoundException()
        {
            var json = """{"Value":1.2,"Unit":"invalid","Type":"Mass"}""";

            Assert.Throws<UnitNotFoundException>(() => DeserializeObject<Mass>(json));
        }

        [Fact]
        public void DeserializingIQuantity_FromAmbiguousAbbreviationAndNoQuantityType_ThrowsAmbiguousUnitParseException()
        {
            var json = """{"Value":1.2,"Unit":"mg"}""";

            Assert.Throws<AmbiguousUnitParseException>(() => DeserializeObject<IQuantity>(json));
        }

        [Fact]
        public void DeserializingIQuantity_FromUnknownUnitAndNoQuantityType_ThrowsUnitsNotFoundException()
        {
            var json = """{"Value":1.2,"Unit":"invalid"}""";

            Assert.Throws<UnitNotFoundException>(() => DeserializeObject<IQuantity>(json));
        }

        [Fact]
        public void DeserializingIQuantity_FromNoUnitAndNoQuantityType_ThrowsFormatException()
        {
            var json = """{"Value":1.2}""";

            Assert.Throws<FormatException>(() => DeserializeObject<IQuantity>(json));
        }

        [Fact]
        public void ReadJson_GivenAnotherType_ThrowsJsonSerializationException()
        {
            var abbreviatedUnitsConverter = new AbbreviatedUnitsConverter();
            using var stringWriter = new StringReader("something");
            using var reader = new JsonTextReader(stringWriter);
            Assert.Throws<JsonException>(() => abbreviatedUnitsConverter.ReadJson(reader, typeof(IQuantity), DateTime.MinValue, JsonSerializer.CreateDefault()));
        }


        [Fact]
        public void DoubleIQuantity_DeserializedFromQuotedDoubleValueAndAbbreviatedUnit()
        {
            var json = """{"Value":"1.2","Unit":"mg","Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleQuantity_DeserializedFromQuotedDoubleValueAndAbbreviatedUnit()
        {
            var json = """{"Value":"1.2","Unit":"mg"}""";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroIQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = """{"Unit":"mg","Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = """{"Unit":"mg"}""";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleBaseUnitQuantity_DeserializedFromValueAndNoUnit()
        {
            var json = """{"Value":1.2,"Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DoubleBaseUnitIQuantity_DeserializedFromValueAndNoUnit()
        {
            var json = """{"Value":1.2}""";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroBaseIQuantity_DeserializedFromQuantityTypeOnly()
        {
            var json = """{"Type":"Mass"}""";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(0, quantity.Value);
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
        
        #endregion
    }
}
