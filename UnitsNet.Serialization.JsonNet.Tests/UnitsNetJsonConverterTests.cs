// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public class UnitsNetJsonConverterTests
    {
        private JsonSerializerSettings _jsonSerializerSettings;

        [SetUp]
        public void Setup()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
        }

        protected string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        protected T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        [TestFixture]
        public class Serialize : UnitsNetJsonConverterTests
        {
            [Test]
            public void Information_CanSerializeVeryLargeValues()
            {
                Information i = Information.FromExabytes(1E+9);
                var expectedJson = "{\n  \"Unit\": \"InformationUnit.Bit\",\n  \"Value\": 8E+27\n}";

                string json = SerializeObject(i);

                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void Mass_ExpectKilogramsUsedAsBaseValueAndUnit()
            {
                Mass mass = Mass.FromPounds(200);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 90.718474\n}";

                string json = SerializeObject(mass);

                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void NonNullNullableValue_ExpectJsonUnaffected()
            {
                Mass? nullableMass = Mass.FromKilograms(10);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 10.0\n}";

                string json = SerializeObject(nullableMass);
//                Console.WriteLine(json);

                // There shouldn't be any change in the JSON for the non-null nullable value.
                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void NonNullNullableValueNestedInObject_ExpectJsonUnaffected()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = Frequency.FromHertz(10),
                    NonNullableFrequency = Frequency.FromHertz(10)
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
//                Console.WriteLine(json);

                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void NullValue_ExpectJsonContainsNullString()
            {
                Mass? nullMass = null;
                var expectedJson = "null";

                string json = SerializeObject(nullMass);
//                Console.WriteLine(json);

                Assert.That(expectedJson, Is.EqualTo(json));
            }

            [Test]
            public void Ratio_ExpectDecimalFractionsUsedAsBaseValueAndUnit()
            {
                Ratio ratio = Ratio.FromPartsPerThousand(250);
                var expectedJson = "{\n  \"Unit\": \"RatioUnit.DecimalFraction\",\n  \"Value\": 0.25\n}";

                string json = SerializeObject(ratio);

                Assert.That(json, Is.EqualTo(expectedJson));
            }
        }

        [TestFixture]
        public class Deserialize : UnitsNetJsonConverterTests
        {
            [Test]
            public void Information_CanDeserializeVeryLargeValues()
            {
                Information original = Information.FromExabytes(1E+9);
                string json = SerializeObject(original);
                var deserialized = DeserializeObject<Information>(json);

                Assert.AreEqual(original, deserialized);
            }

            [Test]
            public void Mass_ExpectJsonCorrectlyDeserialized()
            {
                Mass originalMass = Mass.FromKilograms(33.33);
                string json = SerializeObject(originalMass);

                var deserializedMass = DeserializeObject<Mass>(json);

                Assert.That(deserializedMass, Is.EqualTo(originalMass));
            }

            [Test]
            public void NonNullNullableValue_ExpectValueDeserializedCorrectly()
            {
                Mass? nullableMass = Mass.FromKilograms(10);
                string json = SerializeObject(nullableMass);

                var deserializedNullableMass = DeserializeObject<Mass?>(json);

                Assert.That(deserializedNullableMass.Value, Is.EqualTo(nullableMass.Value));
            }

            [Test]
            public void NonNullNullableValueNestedInObject_ExpectValueDeserializedCorrectly()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = Frequency.FromHertz(10),
                    NonNullableFrequency = Frequency.FromHertz(10)
                };
                string json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

                Assert.That(deserializedTestObj.NullableFrequency, Is.EqualTo(testObj.NullableFrequency));
            }

            [Test]
            public void NullValue_ExpectNullReturned()
            {
                Mass? nullMass = null;
                string json = SerializeObject(nullMass);

                var deserializedNullMass = DeserializeObject<Mass?>(json);

                Assert.That(deserializedNullMass, Is.Null);
            }

            [Test]
            public void NullValueNestedInObject_ExpectValueDeserializedToNullCorrectly()
            {
                var testObj = new TestObj
                {
                    NullableFrequency = null,
                    NonNullableFrequency = Frequency.FromHertz(10)
                };
                string json = SerializeObject(testObj);

                var deserializedTestObj = DeserializeObject<TestObj>(json);

                Assert.That(deserializedTestObj.NullableFrequency, Is.Null);
            }

            [Test]
            public void UnitEnumChangedAfterSerialization_ExpectUnitCorrectlyDeserialized()
            {
                Mass originalMass = Mass.FromKilograms(33.33);
                string json = SerializeObject(originalMass);
                // Someone manually changed the serialized JSON string to 1000 grams.
                json = json.Replace("33.33", "1000");
                json = json.Replace("MassUnit.Kilogram", "MassUnit.Gram");

                var deserializedMass = DeserializeObject<Mass>(json);

                // The original value serialized was 33.33 kg, but someone edited the JSON to be 1000 g. We expect the JSON is
                //  still deserializable, and the correct value of 1000 g is obtained.
                Assert.That(deserializedMass.Grams, Is.EqualTo(1000));
            }

            [Test]
            public void UnitInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = Power.FromWatts(10)
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json,jsonSerializerSettings);
               
                Assert.That(deserializedTestObject.Value.GetType(), Is.EqualTo(typeof(Power)));
                Assert.That((Power)deserializedTestObject.Value, Is.EqualTo(Power.FromWatts(10)));
            }

            [Test]
            public void DoubleInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = 10.0
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.That(deserializedTestObject.Value.GetType(), Is.EqualTo(typeof(double)));
                Assert.That((double)deserializedTestObject.Value, Is.EqualTo(10.0));
            }

            [Test]
            public void ClassInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                TestObjWithIComparable testObjWithIComparable = new TestObjWithIComparable()
                {
                    Value = new ComparableClass() { Value = 10 }
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>(json, jsonSerializerSettings);

                Assert.That(deserializedTestObject.Value.GetType(), Is.EqualTo(typeof(ComparableClass)));
                Assert.That(((ComparableClass)(deserializedTestObject.Value)).Value, Is.EqualTo(10.0));
            }

            [Test]
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

                Assert.That(deserializedTestObject.Value.GetType(), Is.EqualTo(typeof(double)));
                Assert.That(deserializedTestObject.Value, Is.EqualTo(5.0));
                Assert.That(deserializedTestObject.Unit, Is.EqualTo("Test"));
            }

            [Test]
            public void ThreeObjectsInIComparableWithDifferentValues_ExpectAllCorrectlyDeserialized()
            {
                TestObjWithThreeIComparable testObjWithIComparable = new TestObjWithThreeIComparable()
                {
                    Value1 = 10.0,
                    Value2 = Power.FromWatts(19),
                    Value3 = new ComparableClass() { Value = 10 },
                };
                JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings();

                string json = JsonConvert.SerializeObject(testObjWithIComparable, jsonSerializerSettings);
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithThreeIComparable>(json, jsonSerializerSettings);

                Assert.That(deserializedTestObject.Value1.GetType(), Is.EqualTo(typeof(double)));
                Assert.That((deserializedTestObject.Value1), Is.EqualTo(10.0));
                Assert.That(deserializedTestObject.Value2.GetType(), Is.EqualTo(typeof(Power)));
                Assert.That((deserializedTestObject.Value2), Is.EqualTo(Power.FromWatts(19)));
                Assert.That(deserializedTestObject.Value3.GetType(), Is.EqualTo(typeof(ComparableClass)));
                Assert.That((deserializedTestObject.Value3), Is.EqualTo(testObjWithIComparable.Value3));
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
            public Frequency? NullableFrequency { get; set; }
            public Frequency NonNullableFrequency { get; set; }
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