using System.Globalization;
using Newtonsoft.Json;
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
            var expectedJson = "{\"Value\":1.2,\"Unit\":\"mg\",\"Type\":\"Mass\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueAndAbbreviatedUnit()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.20,\"Unit\":\"EB\",\"Type\":\"Information\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_IncludesTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Information(1.20m, InformationUnit.Exabyte) };
            var expectedJson = "{\"Quantity\":{\"Value\":1.20,\"Unit\":\"EB\",\"Type\":\"Information\"}}";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void InterfaceObject_SerializesWithoutKnownTypeInformation()
        {
            var testObject = new TestInterfaceObject { Quantity = new Volume(1.2, VolumeUnit.Microliter) };

            var expectedJson = "{\"Quantity\":{\"Value\":1.2,\"Unit\":\"µl\",\"Type\":\"Volume\"}}";

            var json = SerializeObject(testObject);

            Assert.Equal(expectedJson, json);
        }

        #endregion

        #region Deserialization tests

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"mg\",\"Type\":\"Mass\"}";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"mg\"}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }
        
        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndNonAmbiguousAbbreviatedUnit_WithoutQuantityType()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"em\"}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.EarthMass, quantity.Unit);
        }

        [Fact]
        public void ThrowsAmbiguousUnitParseException_WhenDeserializingAmbiguousAbbreviation_WithoutQuantityType()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"mg\"}";

            Assert.Throws<AmbiguousUnitParseException>(() => DeserializeObject<IQuantity>(json));
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit_CaseInsensitive()
        {
            var json = "{\"value\":1.2,\"unit\":\"Mg\",\"type\":\"mass\"}";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromDoubleValueAndAbbreviatedUnit_CaseSensitiveUnits()
        {
            var json = "{\"value\":1.2,\"unit\":\"Mbar\",\"type\":\"pressure\"}";

            var megabar = DeserializeObject<IQuantity>(json);
            var millibar = DeserializeObject<IQuantity>(json.ToLower());

            Assert.Equal(1.2, megabar.Value);
            Assert.Equal(1.2, millibar.Value);
            Assert.Equal(PressureUnit.Megabar, megabar.Unit);
            Assert.Equal(PressureUnit.Millibar, millibar.Unit);
        }

        [Fact]
        public void UnitsNetExceptionThrown_WhenDeserializing_FromUnknownQuantityType()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"mg\",\"Type\":\"invalid\"}";

            Assert.Throws<UnitsNetException>(() => DeserializeObject<Mass>(json));
        }

        [Fact]
        public void UnitsNotFoundExceptionThrown_WhenDeserializing_FromUnknownUnit()
        {
            var json = "{\"Value\":1.2,\"Unit\":\"invalid\",\"Type\":\"Mass\"}";

            Assert.Throws<UnitNotFoundException>(() => DeserializeObject<Mass>(json));
        }

        [Fact]
        public void DoubleIQuantity_DeserializedFromQuotedDoubleValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":\"1.2\",\"Unit\":\"mg\",\"Type\":\"Mass\"}";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleQuantity_DeserializedFromQuotedDoubleValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":\"1.2\",\"Unit\":\"mg\"}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroIQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = "{\"Unit\":\"mg\",\"Type\":\"Mass\"}";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = "{\"Unit\":\"mg\"}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(MassUnit.Milligram, quantity.Unit);
        }

        [Fact]
        public void DoubleBaseUnitQuantity_DeserializedFromValueAndNoUnit()
        {
            var json = "{\"Value\":1.2,\"Type\":\"Mass\"}";

            var quantity = DeserializeObject<IQuantity>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DoubleBaseUnitIQuantity_DeserializedFromValueAndNoUnit()
        {
            var json = "{\"Value\":1.2}";

            var quantity = DeserializeObject<Mass>(json);

            Assert.Equal(1.2, quantity.Value);
            Assert.Equal(Mass.BaseUnit, quantity.Unit);
        }

        [Fact]
        public void DoubleZeroBaseIQuantity_DeserializedFromQuantityTypeOnly()
        {
            var json = "{\"Type\":\"Mass\"}";

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

        [Fact]
        public void DecimalIQuantity_DeserializedFromDecimalValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":1.200,\"Unit\":\"EB\",\"Type\":\"Information\"}";

            var quantity = (Information) DeserializeObject<IQuantity>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalQuantity_DeserializedFromDecimalValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":1.200,\"Unit\":\"EB\"}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalIQuantity_DeserializedFromQuotedDecimalValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":\"1.200\",\"Unit\":\"EB\",\"Type\":\"Information\"}";

            var quantity = (Information) DeserializeObject<IQuantity>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalQuantity_DeserializedFromQuotedDecimalValueAndAbbreviatedUnit()
        {
            var json = "{\"Value\":\"1.200\",\"Unit\":\"EB\"}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalZeroIQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = "{\"Unit\":\"EB\",\"Type\":\"Information\"}";

            var quantity = (Information)DeserializeObject<IQuantity>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalZeroQuantity_DeserializedFromAbbreviatedUnitAndNoValue()
        {
            var json = "{\"Unit\":\"EB\"}";

            var quantity = DeserializeObject<Information>(json);

            Assert.Equal(0, quantity.Value);
            Assert.Equal(InformationUnit.Exabyte, quantity.Unit);
        }

        [Fact]
        public void DecimalBaseUnitIQuantity_DeserializedFromDecimalValueAndNoUnit()
        {
            var json = "{\"Value\":1.200,\"Type\":\"Information\"}";

            var quantity = (Information)DeserializeObject<IQuantity>(json);

            Assert.Equal(1.200m, quantity.Value);
            Assert.Equal("1.200", quantity.Value.ToString(CultureInfo.InvariantCulture));
            Assert.Equal(Information.BaseUnit, quantity.Unit);
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
        public void DecimalZeroBaseIQuantity_DeserializedFromQuantityTypeOnly()
        {
            var json = "{\"Type\":\"Information\"}";

            var quantity = (Information)DeserializeObject<IQuantity>(json);

            Assert.Equal(0, quantity.Value);
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

        #endregion

        #region Compatibility

        [JsonObject]
        class PlainOldDoubleQuantity
        {
            public double Value { get; set; }
            public string Unit { get; set; }
        }

        [JsonObject]
        class PlainOldDecimalQuantity
        {
            public decimal Value { get; set; }
            public string Unit { get; set; }
        }

        [Fact]
        public void LargeDecimalQuantity_DeserializedTo_PlainOldDecimalQuantity()
        {
            var quantity = new Information(2m * long.MaxValue, InformationUnit.Exabyte);

            var json = SerializeObject(quantity);
            var plainOldQuantity = JsonConvert.DeserializeObject<PlainOldDecimalQuantity>(json);

            Assert.Equal(2m * long.MaxValue, plainOldQuantity.Value);
            Assert.Equal("EB", plainOldQuantity.Unit);
        }

        [Fact]
        public void LargeDecimalQuantity_DeserializedTo_PlainOldDoubleQuantity()
        {
            var quantity = Information.FromExabytes(2m * long.MaxValue);

            var json = SerializeObject(quantity);
            var plainOldQuantity = JsonConvert.DeserializeObject<PlainOldDoubleQuantity>(json);

            Assert.Equal(2.0 * long.MaxValue, plainOldQuantity.Value);
            Assert.Equal("EB", plainOldQuantity.Unit);
        }

        #endregion

    }
}
