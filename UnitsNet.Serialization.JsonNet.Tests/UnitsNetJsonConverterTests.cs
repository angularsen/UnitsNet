// Copyright Initial Force AS.  All rights reserved.
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

using Newtonsoft.Json;
using NUnit.Framework;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public class UnitsNetJsonConverterTests
    {
        private JsonSerializerSettings _jsonSerializerSettings;

        [SetUp]
        public void Setup()
        {
            _jsonSerializerSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
        }

        [TestFixture]
        public class Serialize : UnitsNetJsonConverterTests
        {
            [Test]
            public void Mass_ExpectKilogramsUsedAsBaseValueAndUnit()
            {
                Mass mass = Mass.FromPounds(200);
                string expectedJson = "{\r\n  \"Unit\": \"MassUnit.Kilogram\",\r\n  \"Value\": 90.718474\r\n}";

                string json = SerializeObject(mass);

                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void Information_CanSerializeVeryLargeValues()
            {
                Information i = Information.FromExabytes(1E+9);
                string expectedJson = "{\r\n  \"Unit\": \"InformationUnit.Bit\",\r\n  \"Value\": 8E+27\r\n}";

                string json = SerializeObject(i);

                Assert.That(json, Is.EqualTo(expectedJson));
            }

            [Test]
            public void Ratio_ExpectDecimalFractionsUsedAsBaseValueAndUnit()
            {
                Ratio ratio = Ratio.FromPartsPerThousand(250);
                string expectedJson = "{\r\n  \"Unit\": \"RatioUnit.DecimalFraction\",\r\n  \"Value\": 0.25\r\n}";

                string json = SerializeObject(ratio);

                Assert.That(json, Is.EqualTo(expectedJson));
            }
        }

        [TestFixture]
        public class Deserialize : UnitsNetJsonConverterTests
        {
            [Test]
            public void Mass_ExpectJsonCorrectlyDeserialized()
            {
                Mass originalMass = Mass.FromKilograms(33.33);
                string json = SerializeObject(originalMass);

                Mass deserializedMass = DeserializeObject<Mass>(json);

                Assert.That(deserializedMass, Is.EqualTo(originalMass));
            }

            [Test]
            public void Information_CanDeserializeVeryLargeValues()
            {
                Information original = Information.FromExabytes(1E+9);
                string json = SerializeObject(original);
                Information deserialized = DeserializeObject<Information>(json);

                Assert.AreEqual(original, deserialized);
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
        }

        protected string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        protected T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }
    }
}
