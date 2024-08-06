// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json;
using UnitsNet.Serialization.JsonNet.Tests.Infrastructure;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetJsonDeserializationTests : UnitsNetJsonBaseTest
    {
        [Fact]
        public void Information_CanDeserializeLargeValue()
        {
            var original = new Information(decimal.MaxValue, InformationUnit.Exbibyte);
            var json = SerializeObject(original);
            var deserialized = DeserializeObject<Information>(json);

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void Information_CanDeserializeSmallValue()
        {
            decimal decimalEpsilon = (decimal)(1 / Math.Pow(10, 28));
            var original = new Information(decimalEpsilon, InformationUnit.Bit);
            var json = SerializeObject(original);
            var deserialized = DeserializeObject<Information>(json);

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void Length_CanDeserializeLargeValue()
        {
            var original = new Length(double.MaxValue, LengthUnit.MegalightYear);
            var json = SerializeObject(original);
            var deserialized = DeserializeObject<Length>(json);

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void Length_CanDeserializeSmallValue()
        {
            var original = new Length(double.Epsilon, LengthUnit.Nanometer);
            var json = SerializeObject(original);
            var deserialized = DeserializeObject<Length>(json);

            Assert.Equal(original, deserialized);
        }

        [Fact]
        public void Mass_ExpectJsonCorrectlyDeserialized()
        {
            var originalMass = Mass.FromKilograms(33.33);
            var json = SerializeObject(originalMass);

            var deserializedMass = DeserializeObject<Mass>(json);

            Assert.Equal(originalMass, deserializedMass);
        }

        [Fact]
        public void NonNullNullableValue_ExpectValueDeserializedCorrectly()
        {
            Mass? nullableMass = Mass.FromKilograms(10);
            var json = SerializeObject(nullableMass);

            var deserializedNullableMass = DeserializeObject<Mass?>(json);

            Assert.Equal(nullableMass.Value, deserializedNullableMass);
        }

        [Fact]
        public void NonNullNullableValueNestedInObject_ExpectValueDeserializedCorrectly()
        {
            var testObj = new TestObject()
            {
                NullableFrequency = Frequency.FromHertz(10),
                NonNullableFrequency = Frequency.FromHertz(10)
            };
            var json = SerializeObject(testObj);

            var deserializedTestObj = DeserializeObject<TestObject>(json);

            Assert.Equal(testObj.NullableFrequency, deserializedTestObj.NullableFrequency);
        }

        [Fact]
        public void NullValue_ExpectNullReturned()
        {
            var json = SerializeObject(null);
            var deserializedNullMass = DeserializeObject<Mass?>(json);

            Assert.Null(deserializedNullMass);
        }

        [Fact]
        public void EmptyJsonValue_NullableType_ExpectJsonSerializationException()
        {
            var ex = Assert.Throws<JsonSerializationException>(() => DeserializeObject<Mass?>("{}"));
            Assert.Equal("Failed to deserialize IQuantity for target type System.Nullable`1[UnitsNet.Mass] from JSON '{}', expected properties Unit and Value.", ex.Message);
            Assert.Equal("https://github.com/angularsen/UnitsNet/wiki/Serializing-to-JSON,-XML-and-more#unitsnetserializationjsonnet-with-jsonnet-newtonsoft", ex.HelpLink);
            Assert.Equal("{}", ex.Data["JsonToken"]);
        }

        [Fact]
        public void EmptyJsonValue_NonNullableType_ExpectJsonSerializationException()
        {
            var ex = Assert.Throws<JsonSerializationException>(() => DeserializeObject<Mass>("{}"));
            Assert.Equal("Failed to deserialize IQuantity for target type UnitsNet.Mass from JSON '{}', expected properties Unit and Value.", ex.Message);
            Assert.Equal("https://github.com/angularsen/UnitsNet/wiki/Serializing-to-JSON,-XML-and-more#unitsnetserializationjsonnet-with-jsonnet-newtonsoft", ex.HelpLink);
            Assert.Equal("{}", ex.Data["JsonToken"]);
        }

        [Fact]
        public void NullValueNestedInObject_ExpectValueDeserializedToNullCorrectly()
        {
            var testObj = new TestObject()
            {
                NullableFrequency = null,
                NonNullableFrequency = Frequency.FromHertz(10)
            };
            var json = SerializeObject(testObj);

            var deserializedTestObj = DeserializeObject<TestObject>(json);

            Assert.Null(deserializedTestObj.NullableFrequency);
        }

        [Fact]
        public void UnitEnumChangedAfterSerialization_ExpectUnitCorrectlyDeserialized()
        {
            var originalMass = Mass.FromKilograms(33.33);
            var json = SerializeObject(originalMass);

            // Someone manually changed the serialized JSON string to 1000 grams.
            json = json.Replace("33.33", "1000");
            json = json.Replace("MassUnit.Kilogram", "MassUnit.Gram");

            var deserializedMass = DeserializeObject<Mass>(json);

            // The original value serialized was 33.33 kg, but someone edited the JSON to be 1000 g. We expect the JSON is
            //  still deserializable, and the correct value of 1000 g is obtained.
            Assert.Equal(1000, deserializedMass.Grams);
        }

        [Fact]
        public void UnitInIComparable_ExpectUnitCorrectlyDeserialized()
        {
            var testObjWithIComparable = new TestObjectWithIComparable()
            {
                Value = Power.FromWatts(10)
            };

            var json = SerializeObject(testObjWithIComparable);

            var deserializedTestObject = DeserializeObject<TestObjectWithIComparable>(json);

            Assert.IsType<Power>(deserializedTestObject.Value);
            Assert.Equal(Power.FromWatts(10), (Power)deserializedTestObject.Value);
        }

        [Fact]
        public void DoubleInIComparable_ExpectUnitCorrectlyDeserialized()
        {
            var testObjWithIComparable = new TestObjectWithIComparable()
            {
                Value = 10.0
            };

            var json = SerializeObject(testObjWithIComparable);
            var deserializedTestObject = DeserializeObject<TestObjectWithIComparable>(json);

            Assert.IsType<double>(deserializedTestObject.Value);
            Assert.Equal(10d, (double)deserializedTestObject.Value);
        }

        [Fact]
        public void ClassInIComparable_ExpectUnitCorrectlyDeserialized()
        {
            var testObjWithIComparable = new TestObjectWithIComparable()
            {
                Value = new TestObjectWithValueAsIComparable() { Value = 10 }
            };

            var json = SerializeObject(testObjWithIComparable, TypeNameHandling.Auto);
            var deserializedTestObject = DeserializeObject<TestObjectWithIComparable>(json, TypeNameHandling.Auto);

            Assert.IsType<TestObjectWithValueAsIComparable>(deserializedTestObject.Value);
            Assert.Equal(10d, ((TestObjectWithValueAsIComparable)deserializedTestObject.Value).Value);
        }

        [Fact]
        public void OtherObjectWithUnitAndValue_ExpectCorrectReturnValues()
        {
            var testObjWithValueAndUnit = new TestObjectWithValueAndUnitAsIComparable()
            {
                Value = 5,
                Unit = "Test",
            };

            var json = SerializeObject(testObjWithValueAndUnit);
            var deserializedTestObject = DeserializeObject<TestObjectWithValueAndUnitAsIComparable>(json);

            Assert.IsType<double>(deserializedTestObject.Value);
            Assert.Equal(5d, deserializedTestObject.Value);
            Assert.Equal("Test", deserializedTestObject.Unit);
        }

        [Fact]
        public void ThreeObjectsInIComparableWithDifferentValues_ExpectAllCorrectlyDeserialized()
        {
            var testObjWithIComparable = new TestObjectWithThreeIComparable()
            {
                Value1 = 10.0,
                Value2 = Power.FromWatts(19),
                Value3 = new TestObjectWithValueAsIComparable() { Value = 10 },
            };
            var json = SerializeObject(testObjWithIComparable, TypeNameHandling.Auto);
            var deserializedTestObject = DeserializeObject<TestObjectWithThreeIComparable>(json, TypeNameHandling.Auto);

            Assert.IsType<double>(deserializedTestObject.Value1);
            Assert.Equal(10d, deserializedTestObject.Value1);

            Assert.IsType<Power>(deserializedTestObject.Value2);
            Assert.Equal(Power.FromWatts(19), deserializedTestObject.Value2);

            Assert.IsType<TestObjectWithValueAsIComparable>(deserializedTestObject.Value3);
            Assert.Equal(testObjWithIComparable.Value3, deserializedTestObject.Value3);
        }

        [Fact]
        public void ArrayOfUnits_ExpectCorrectlyDeserialized()
        {
            Frequency[] expected = { Frequency.FromHertz(10), Frequency.FromHertz(10) };

            var json = "[\n" +
                       "  {\n" +
                       "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "    \"Value\": 10.0\n" +
                       "  },\n" +
                       "  {\n" +
                       "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "    \"Value\": 10.0\n" +
                       "  }\n" +
                       "]";

            var result = DeserializeObject<Frequency[]>(json);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiDimArrayOfUnits_ExpectCorrectlyDeserialized()
        {
            Frequency[,] expected = { { Frequency.FromHertz(10), Frequency.FromHertz(10) }, { Frequency.FromHertz(10), Frequency.FromHertz(10) } };

            var json = "[\n" +
                       "  [\n" +
                       "    {\n" +
                       "      \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "      \"Value\": 10.0\n" +
                       "    },\n" +
                       "    {\n" +
                       "      \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "      \"Value\": 10.0\n" +
                       "    }\n" +
                       "  ],\n" +
                       "  [\n" +
                       "    {\n" +
                       "      \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "      \"Value\": 10.0\n" +
                       "    },\n" +
                       "    {\n" +
                       "      \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                       "      \"Value\": 10.0\n" +
                       "    }\n" +
                       "  ]\n" +
                       "]";

            var result = DeserializeObject<Frequency[,]>(json);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void EmptyArray_ExpectCorrectlyDeserialized()
        {
            var json = "[]";

            var result = DeserializeObject<Frequency[]>(json);

            Assert.Empty(result);
        }
    }
}
