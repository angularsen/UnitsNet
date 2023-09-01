// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Serialization.JsonNet.Tests.Infrastructure;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetJsonSerializationTests : UnitsNetJsonBaseTest
    {
        [Fact]
        public void Information_CanSerializeVeryLargeValues()
        {
            Information i = Information.FromExabytes(1E+9);
            var expectedJson = "{\n  \"Unit\": \"InformationUnit.Exabyte\",\n  \"Value\": 1000000000.0,\n  \"ValueString\": \"1000000000\",\n  \"ValueType\": \"decimal\"\n}";

            string json = SerializeObject(i);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Mass_ExpectConstructedValueAndUnit()
        {
            Mass mass = Mass.FromPounds(200);
            var expectedJson = "{\n  \"Unit\": \"MassUnit.Pound\",\n  \"Value\": 200.0\n}";

            string json = SerializeObject(mass);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Information_ExpectConstructedValueAndUnit()
        {
            Information quantity = Information.FromKilobytes(54);
            var expectedJson = "{\n  \"Unit\": \"InformationUnit.Kilobyte\",\n  \"Value\": 54.0,\n  \"ValueString\": \"54\",\n  \"ValueType\": \"decimal\"\n}";

            string json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void NonNullNullableValue_ExpectJsonUnaffected()
        {
            Mass? nullableMass = Mass.FromKilograms(10);
            var expectedJson = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 10.0\n}";

            string json = SerializeObject(nullableMass);

            // There shouldn't be any change in the JSON for the non-null nullable value.
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
            Ratio ratio = Ratio.FromPartsPerThousand(250);
            var expectedJson = "{\n  \"Unit\": \"RatioUnit.PartPerThousand\",\n  \"Value\": 250.0\n}";

            string json = SerializeObject(ratio);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void ArrayValue_ExpectJsonArray()
        {
            Frequency[] testObj = { Frequency.FromHertz(10), Frequency.FromHertz(10) };

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

        [Fact]
        public void MultiDimArrayValue_ExpectJsonArray()
        {
            Frequency[,] testObj = { { Frequency.FromHertz(10), Frequency.FromHertz(10) }, { Frequency.FromHertz(10), Frequency.FromHertz(10) } };

            string expectedJson = "[\n" +
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

            string json = SerializeObject(testObj);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void EmptyArrayValue_ExpectJsonArray()
        {
            Frequency[] testObj = { };

            string expectedJson = "[]";

            string json = SerializeObject(testObj);
            Assert.Equal(expectedJson, json);
        }
    }
}
