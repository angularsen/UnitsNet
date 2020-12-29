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
            [Fact]
            public void Information_CanSerializeVeryLargeValues()
            {
                Information<double> i = Information<double>.FromExabytes(1E+9);
                var expectedJson = "{\n  \"Unit\": \"InformationUnit.Exabyte\",\n  \"Value\": 1000000000.0\n}";

                string json = SerializeObject(i);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void Mass_ExpectConstructedValueAndUnit()
            {
                Mass<double> mass = Mass<double>.FromPounds(200);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Pound\",\n  \"Value\": 200.0\n}";

                string json = SerializeObject(mass);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void Information_ExpectConstructedValueAndUnit()
            {
                Information<double> quantity = Information<double>.FromKilobytes(54);
                var expectedJson = "{\n  \"Unit\": \"InformationUnit.Kilobyte\",\n  \"Value\": 54.0\n}";

                string json = SerializeObject(quantity);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NonNullNullableValue_ExpectJsonUnaffected()
            {
                Mass<double>? nullableMass = Mass<double>.FromKilograms(10);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 10.0\n}";

                string json = SerializeObject(nullableMass);

                // There shouldn't be any change in the JSON for the non-null nullable value.
                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NonNullNullableValueNestedInObject_ExpectJsonUnaffected()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = Frequency<double>.FromHertz(10),
                    NonNullableFrequency = Frequency<double>.FromHertz(10)
                };
                // Ugly manually formatted JSON string is used because string literals with newlines are rendered differently
                //  on the build server (i.e. the build server uses '\r' instead of '\n')
                string expectedJson = "{\n" +
                                      "  \"NullableFrequency\": {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  },\n" +
                                      "  \"NonNullableFrequency\": {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  }\n" +
                                      "}";

                string json = SerializeObject(testObj);

                Assert.Equal(expectedJson, json);
            }

            [Fact]
            public void NullValue_ExpectJsonContainsNullString()
            {
                string json = SerializeObject(null);
                Assert.Equal("null", json);
            }

            [Fact]
            public void Ratio_ExpectDecimalFractionsUsedAsBaseValueAndUnit()
            {
                Ratio<double> ratio = Ratio<double>.FromPartsPerThousand(250);
                var expectedJson = "{\n  \"Unit\": \"RatioUnit.PartPerThousand\",\n  \"Value\": 250.0\n}";

                string json = SerializeObject(ratio);

                Assert.Equal(expectedJson, json);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void ArrayValue_ExpectJsonArray()
            {
                Frequency[] testObj = new Frequency[] { Frequency.FromHertz(10), Frequency.FromHertz(10) };

                string expectedJson = "[\n" +
                                      "  {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  },\n" +
                                      "  {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  }\n" +
                                      "]";

                string json = SerializeObject(testObj);

                Assert.Equal(expectedJson, json);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void EmptyArrayValue_ExpectJsonArray()
            {
                Frequency[] testObj = new Frequency[0];

                string expectedJson = "[]";

                string json = SerializeObject(testObj);
                Assert.Equal(expectedJson, json);
            }
        }

        public class Deserialize : UnitsNetJsonConverterTests
        {
            [Fact]
            public void Information_CanDeserializeVeryLargeValues()
            {
                Information<double> original = Information<double>.FromExabytes(1E+9);
                string json = SerializeObject(original);
                var deserialized = DeserializeObject<Information<double>>(json);

                Assert.Equal(original, deserialized);
            }

            [Fact]
            public void Mass_ExpectJsonCorrectlyDeserialized()
            {
                Mass<double> originalMass = Mass<double>.FromKilograms(33.33);
                string json = SerializeObject(originalMass);

                var deserializedMass = DeserializeObject<Mass<double>>(json);

                Assert.Equal(originalMass, deserializedMass);
            }

            [Fact]
            public void NonNullNullableValue_ExpectValueDeserializedCorrectly()
            {
                Mass<double>? nullableMass = Mass<double>.FromKilograms(10);
                string json = SerializeObject(nullableMass);

                Mass<double>? deserializedNullableMass = DeserializeObject<Mass<double>?>(json);

                Assert.Equal(nullableMass.Value, deserializedNullableMass);
            }

            [Fact]
            public void NonNullNullableValueNestedInObject_ExpectValueDeserializedCorrectly()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = Frequency<double>.FromHertz(10),
                    NonNullableFrequency = Frequency<double>.FromHertz(10)
                };
                string json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

                Assert.Equal(testObj.NullableFrequency, deserializedTestObj.NullableFrequency);
            }

            [Fact]
            public void NullValue_ExpectNullReturned()
            {
                string json = SerializeObject(null);
                var deserializedNullMass = DeserializeObject<Mass<double>?>(json);

                Assert.Null(deserializedNullMass);
            }

            [Fact]
            public void NullValueNestedInObject_ExpectValueDeserializedToNullCorrectly()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = null,
                    NonNullableFrequency = Frequency<double>.FromHertz(10)
                };
                string json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

                Assert.Null(deserializedTestObj.NullableFrequency);
            }

            [Fact]
            public void UnitEnumChangedAfterSerialization_ExpectUnitCorrectlyDeserialized()
            {
                Mass<double> originalMass = Mass<double>.FromKilograms(33.33);
                string json = SerializeObject(originalMass);
                // Someone manually changed the serialized JSON string to 1000 grams.
                json = json.Replace("33.33", "1000");
                json = json.Replace("MassUnit.Kilogram", "MassUnit.Gram");

                var deserializedMass = DeserializeObject<Mass<double>>(json);

                // The original value serialized was 33.33 kg, but someone edited the JSON to be 1000 g. We expect the JSON is
                //  still deserializable, and the correct value of 1000 g is obtained.
                Assert.Equal(1000, deserializedMass.Grams);
            }

            [Fact]
            public void UnitInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = Power<double>.FromWatts(10)
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json,jsonSerializerSettings);

                Assert.Equal(typeof(Power<double>), deserializedTestObject.Value.GetType());
                Assert.Equal(Power<double>.FromWatts(10), (Power<double>)deserializedTestObject.Value);
            }

            [Fact]
            public void DoubleInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = 10.0
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value.GetType());
                Assert.Equal(10d, (double)deserializedTestObject.Value);
            }

            [Fact]
            public void ClassInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = new ComparableClass() { Value = 10 }
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(ComparableClass), deserializedTestObject.Value.GetType());
                Assert.Equal(10d, ((ComparableClass) deserializedTestObject.Value).Value);
            }

            [Fact]
            public void OtherObjectWithUnitAndValue_ExpectCorrectResturnValues()
            {
                TestObjWithValueAndUnit testObjWithValueAndUnit = new TestObjWithValueAndUnit()
                {
                   Value = 5,
                   Unit = "Test",
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithValueAndUnit, jsonSerializerSettings);
                TestObjWithValueAndUnit deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithValueAndUnit>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value.GetType());
                Assert.Equal(5d, deserializedTestObject.Value);
                Assert.Equal("Test", deserializedTestObject.Unit);
            }

            [Fact]
            public void ThreeObjectsInIComparableWithDifferentValues_ExpectAllCorrectlyDeserialized()
            {
                TestObjWithThreeIComparable testObjWithIComparable = new TestObjWithThreeIComparable()
                {
                    Value1 = 10.0,
                    Value2 = Power<double>.FromWatts(19),
                    Value3 = new ComparableClass() { Value = 10 },
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithThreeIComparable>(json, jsonSerializerSettings);

                Assert.Equal(typeof(double), deserializedTestObject.Value1.GetType());
                Assert.Equal(10d, deserializedTestObject.Value1);
                Assert.Equal(typeof(Power<double>), deserializedTestObject.Value2.GetType());
                Assert.Equal(Power<double>.FromWatts(19), deserializedTestObject.Value2);
                Assert.Equal(typeof(ComparableClass), deserializedTestObject.Value3.GetType());
                Assert.Equal(testObjWithIComparable.Value3, deserializedTestObject.Value3);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void ArrayOfUnits_ExpectCorrectlyDeserialized()
            {
                Frequency[] expected = new Frequency[] { Frequency.FromHertz(10), Frequency.FromHertz(10) };

                string json = "[\n" +
                                      "  {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  },\n" +
                                      "  {\n" +
                                      "    \"Unit\": \"FrequencyUnit.Hertz\",\n" +
                                      "    \"Value\": 10.0\n" +
                                      "  }\n" +
                                      "]";

                Frequency[] result  = DeserializeObject<Frequency[]>(json);

                Assert.Equal(expected, result);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void MultiDimArrayOfUnits_ExpectCorrectlyDeserialized()
            {
                Frequency[,] expected = { { Frequency.FromHertz(10), Frequency.FromHertz(10) }, { Frequency.FromHertz(10), Frequency.FromHertz(10) } };

                string json = "[\n" +
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

                Frequency[,] result = DeserializeObject<Frequency[,]>(json);

                Assert.Equal(expected, result);
            }

            [Fact(Skip = "Not supported in older versions of serialization")]
            public void EmptyArray_ExpectCorrectlyDeserialized()
            {
                string json = "[]";

                Frequency[] result = DeserializeObject<Frequency[]>(json);

                Assert.Empty(result);
            }

            private static JsonSerializerSettings CreateJsonSerializerSettings()
            {
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto
                };
                jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
                return jsonSerializerSettings;
            }
        }

        private class TestObj
        {
            public Frequency<double>? NullableFrequency { get; set; }
            public Frequency<double> NonNullableFrequency { get; set; }
        }

        private class TestObjWithValueAndUnit : IComparable
        {
            public double Value { get; set; }
            public string Unit { get; set; }

            public int CompareTo(object obj)
            {
                return ((IComparable)Value).CompareTo(obj);
            }
        }

        private class ComparableClass : IComparable
        {
            public int Value { get; set; }
            public int CompareTo(object obj)
            {
                return ((IComparable)Value).CompareTo(obj);
            }

            // Needed for virfying that the deserialized object is the same, should not affect the serilization code
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                return Value.Equals(((ComparableClass)obj).Value);
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
