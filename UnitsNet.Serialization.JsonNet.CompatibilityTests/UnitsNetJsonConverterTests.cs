// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.CompatibilityTests
{
    public class UnitsNetJsonConverterTests
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected UnitsNetJsonConverterTests()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
        }

        private string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        private T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public class Serialize : UnitsNetJsonConverterTests
        {
            [Fact(Skip = "Not supported in older versions of serialization")]
            public void ArrayValue_ExpectJsonArray()
            {
                Frequency[] testObj = {Frequency.FromHertz(10), Frequency.FromHertz(10)};

                var expectedJson = "[\n" +
                                   "  {\n" +
                                   "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                   "    \"Value\": 10.0\n" +
                                   "  },\n" +
                                   "  {\n" +
                                   "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                   "    \"Value\": 10.0\n" +
                                   "  }\n" +
                                   "]";

                var json = SerializeObject(testObj);

                Assert.Equal(expectedJson, json);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void EmptyArrayValue_ExpectJsonArray()
            {
                var testObj = new Frequency[0];

                var expectedJson = "[]";

                var json = SerializeObject(testObj);
                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void Information_CanSerializeVeryLargeValues()
            {
                var i = Information.FromExabytes(1E+9);
                var expectedJson = "{\n  \"Unit\": \"InformationUnit.Exabyte\",\n  \"Value\": 1000000000.0\n}";

                var json = SerializeObject(i);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void Information_ExpectConstructedValueAndUnit()
            {
                var quantity = Information.FromKilobytes(54);
                var expectedJson = "{\n  \"Unit\": \"InformationUnit.Kilobyte\",\n  \"Value\": 54.0\n}";

                var json = SerializeObject(quantity);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void Mass_ExpectConstructedValueAndUnit()
            {
                var mass = Mass.FromPounds(200);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Pound\",\n  \"Value\": 200.0\n}";

                var json = SerializeObject(mass);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NonNullNullableValue_ExpectJsonUnaffected()
            {
                Mass? nullableMass = Mass.FromKilograms(10);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 10.0\n}";

                var json = SerializeObject(nullableMass);

                // There shouldn't be any change in the JSON for the non-null nullable value.
                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NonNullNullableValueNestedInObject_ExpectJsonUnaffected()
            {
                var testObj = new TestObj {NullableFrequency = Frequency.FromHertz(10), NonNullableFrequency = Frequency.FromHertz(10)};
                // Ugly manually formatted JSON string is used because string literals with newlines are rendered differently
                //  on the build server (i.e. the build server uses '\r' instead of '\n')
                var expectedJson = "{\n" +
                                   "  \"NullableFrequency\": {\n" +
                                   "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                   "    \"Value\": 10.0\n" +
                                   "  },\n" +
                                   "  \"NonNullableFrequency\": {\n" +
                                   "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                   "    \"Value\": 10.0\n" +
                                   "  }\n" +
                                   "}";

                var json = SerializeObject(testObj);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NullValue_ExpectJsonContainsNullString()
            {
                var json = SerializeObject(null);
                Assert.Equal("null", json);
            }

            [Fact]
            public void Ratio_ExpectDecimalFractionsUsedAsBaseValueAndUnit()
            {
                var ratio = Ratio.FromPartsPerThousand(250);
                var expectedJson = "{\n  \"Unit\": \"RatioUnit.PartPerThousand\",\n  \"Value\": 250.0\n}";

                var json = SerializeObject(ratio);

                Assert.Equal(expectedJson, json);
            }
        }

        public class Deserialize : UnitsNetJsonConverterTests
        {
            private static JsonSerializerSettings CreateJsonSerializerSettings()
            {
                var jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto};
                jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
                return jsonSerializerSettings;
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void ArrayOfUnits_ExpectCorrectlyDeserialized()
            {
                Frequency[] expected = {Frequency.FromHertz(10), Frequency.FromHertz(10)};

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
            public void ClassInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                var testObjWithIComparable = new TestObjWithIComparable {Value = new ComparableClass {Value = 10}};
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(ComparableClass), deserializedTestObject.Value.GetType());
                Assert.Equal(10d, ((ComparableClass) deserializedTestObject.Value).Value);
            }

            [Fact]
            public void DoubleInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                var testObjWithIComparable = new TestObjWithIComparable {Value = 10.0};
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value.GetType());
                Assert.Equal(10d, (double) deserializedTestObject.Value);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void EmptyArray_ExpectCorrectlyDeserialized()
            {
                var json = "[]";

                var result = DeserializeObject<Frequency[]>(json);

                Assert.Empty(result);
            }

            [Fact]
            public void Information_CanDeserializeVeryLargeValues()
            {
                var original = Information.FromExabytes(1E+9);
                var json = SerializeObject(original);
                var deserialized = DeserializeObject<Information>(json);

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
                var testObj = new TestObj {NullableFrequency = Frequency.FromHertz(10), NonNullableFrequency = Frequency.FromHertz(10)};
                var json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

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
            public void NullValueNestedInObject_ExpectValueDeserializedToNullCorrectly()
            {
                var testObj = new TestObj {NullableFrequency = null, NonNullableFrequency = Frequency.FromHertz(10)};
                var json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

                Assert.Null(deserializedTestObj.NullableFrequency);
            }

            [Fact]
            public void OtherObjectWithUnitAndValue_ExpectCorrectResturnValues()
            {
                var testObjWithValueAndUnit = new TestObjWithValueAndUnit {Value = 5, Unit = "Test"};
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = JsonConvert.SerializeObject(testObjWithValueAndUnit, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithValueAndUnit>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value.GetType());
                Assert.Equal(5d, deserializedTestObject.Value);
                Assert.Equal("Test", deserializedTestObject.Unit);
            }

            [Fact]
            public void ThreeObjectsInIComparableWithDifferentValues_ExpectAllCorrectlyDeserialized()
            {
                var testObjWithIComparable = new TestObjWithThreeIComparable
                {
                    Value1 = 10.0, Value2 = Power.FromWatts(19), Value3 = new ComparableClass {Value = 10}
                };
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithThreeIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value1.GetType());
                Assert.Equal(10d, deserializedTestObject.Value1);
                Assert.Equal(typeof(Power), deserializedTestObject.Value2.GetType());
                Assert.Equal(Power.FromWatts(19), deserializedTestObject.Value2);
                Assert.Equal(typeof(ComparableClass), deserializedTestObject.Value3.GetType());
                Assert.Equal(testObjWithIComparable.Value3, deserializedTestObject.Value3);
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
                var testObjWithIComparable = new TestObjWithIComparable {Value = Power.FromWatts(10)};
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(Power), deserializedTestObject.Value.GetType());
                Assert.Equal(Power.FromWatts(10), (Power) deserializedTestObject.Value);
            }
        }

        private class TestObj
        {
            public Frequency? NullableFrequency { get; set; }
            public Frequency NonNullableFrequency { get; set; }
        }

        private class TestObjWithValueAndUnit : IComparable
        {
            public double Value { get; set; }
            public string Unit { get; set; }

            public int CompareTo(object obj)
            {
                return ((IComparable) Value).CompareTo(obj);
            }
        }

        private class ComparableClass : IComparable
        {
            public int Value { get; set; }

            public int CompareTo(object obj)
            {
                return ((IComparable) Value).CompareTo(obj);
            }

            // Needed for virfying that the deserialized object is the same, should not affect the serilization code
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                return Value.Equals(((ComparableClass) obj).Value);
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }

        private class TestObjWithIComparable
        {
            public IComparable Value { get; set; }
        }

        private class TestObjWithThreeIComparable
        {
            public IComparable Value1 { get; set; }

            public IComparable Value2 { get; set; }

            public IComparable Value3 { get; set; }
        }
    }
}
