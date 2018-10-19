// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using UnitsNet.Quantities;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.CompatibilityTests
{
    public class UnitsNetJsonConverterTests
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected UnitsNetJsonConverterTests()
        {
            _jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            _jsonSerializerSettings.Converters.Add( new UnitsNetJsonConverter() );
        }

        private T DeserializeObject<T>( string json )
        {
            return JsonConvert.DeserializeObject<T>( json, _jsonSerializerSettings );
        }

        public class Deserialize : UnitsNetJsonConverterTests
        {
            [Fact]
            public void Information_CanDeserializeVeryLargeValues()
            {
                var json = "{\n  \"Unit\": \"InformationUnit.Exabyte\",\n  \"Value\": 1000000000.0\n}";
                var deserialized = DeserializeObject<Information>( json );

                Assert.Equal( Information.FromExabytes( 1E+9 ), deserialized );
            }

            [Fact]
            public void Mass_ExpectJsonCorrectlyDeserialized()
            {
                var json = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 33.33\n}";
                var deserializedMass = DeserializeObject<Mass>( json );

                Assert.Equal( Mass.FromKilograms( 33.33 ), deserializedMass );
            }

            [Fact]
            public void NonNullNullableValue_ExpectValueDeserializedCorrectly()
            {
                Mass? nullableMass = Mass.FromKilograms( 10 );
                var json = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 10.0\n}";
                var deserializedNullableMass = DeserializeObject<Mass?>( json );

                Assert.Equal( nullableMass.Value, deserializedNullableMass );
            }

            [Fact]
            public void NonNullNullableValueNestedInObject_ExpectValueDeserializedCorrectly()
            {
                var json = "{\n  \"NullableFrequency\": {\n    \"Unit\": \"FrequencyUnit.Hertz\",\n    \"Value\": 10.0\n  },\n  \"NonNullableFrequency\": {\n    \"Unit\": \"FrequencyUnit.Hertz\",\n    \"Value\": 10.0\n  }\n}";
                var deserializedTestObj = DeserializeObject<TestObj>( json );

                var testObj = new TestObj
                {
                    NullableFrequency = Frequency.FromHertz( 10 ),
                    NonNullableFrequency = Frequency.FromHertz( 10 )
                };

                Assert.Equal( testObj.NullableFrequency, deserializedTestObj.NullableFrequency );
            }

            [Fact]
            public void NullValue_ExpectNullReturned()
            {
                var json = "null";
                var deserializedNullMass = DeserializeObject<Mass?>( json );

                Assert.Null( deserializedNullMass );
            }

            [Fact]
            public void NullValueNestedInObject_ExpectValueDeserializedToNullCorrectly()
            {
                var json = "{\n  \"NullableFrequency\": null,\n  \"NonNullableFrequency\": {\n    \"Unit\": \"FrequencyUnit.Hertz\",\n    \"Value\": 10.0\n  }\n}";
                var deserializedTestObj = DeserializeObject<TestObj>( json );

                Assert.Null( deserializedTestObj.NullableFrequency );
            }

            [Fact]
            public void UnitEnumChangedAfterSerialization_ExpectUnitCorrectlyDeserialized()
            {
                var json = "{\n  \"Unit\": \"MassUnit.Kilogram\",\n  \"Value\": 33.33\n}";

                // Someone manually changed the serialized JSON string to 1000 grams.
                json = json.Replace( "33.33", "1000" );
                json = json.Replace( "MassUnit.Kilogram", "MassUnit.Gram" );

                var deserializedMass = DeserializeObject<Mass>( json );

                // The original value serialized was 33.33 kg, but someone edited the JSON to be 1000 g. We expect the JSON is
                //  still deserializable, and the correct value of 1000 g is obtained.
                Assert.Equal( 1000, deserializedMass.Grams );
            }

            [Fact]
            public void UnitInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                var jsonSerializerSettings = CreateJsonSerializerSettings();
                var json = "{\r\n  \"Value\": {\r\n    \"Unit\": \"PowerUnit.Watt\",\r\n    \"Value\": 10.0\r\n  }\r\n}";

                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>( json, jsonSerializerSettings );

                Assert.Equal( typeof( Power ), deserializedTestObject.Value.GetType() );
                Assert.Equal( Power.FromWatts( 10 ), (Power)deserializedTestObject.Value );
            }

            [Fact]
            public void DoubleInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = "{\r\n  \"Value\": 10.0\r\n}";
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>( json, jsonSerializerSettings );

                Assert.Equal( typeof( double ), deserializedTestObject.Value.GetType() );
                Assert.Equal( 10d, (double)deserializedTestObject.Value );
            }

            [Fact]
            public void ClassInIComparable_ExpectUnitCorrectlyDeserialized()
            {
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = "{\r\n  \"Value\": {\r\n    \"$type\": \"UnitsNet.Serialization.JsonNet.CompatibilityTests.UnitsNetJsonConverterTests+ComparableClass, UnitsNet.Serialization.JsonNet.CompatibilityTests\",\r\n    \"Value\": 10\r\n  }\r\n}";
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithIComparable>( json, jsonSerializerSettings );

                Assert.Equal( typeof( ComparableClass ), deserializedTestObject.Value.GetType() );
                Assert.Equal( 10d, ( (ComparableClass)deserializedTestObject.Value ).Value );
            }

            [Fact]
            public void OtherObjectWithUnitAndValue_ExpectCorrectResturnValues()
            {
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = "{\r\n  \"Value\": 5.0,\r\n  \"Unit\": \"Test\"\r\n}";
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithValueAndUnit>( json, jsonSerializerSettings );

                Assert.Equal( typeof( double ), deserializedTestObject.Value.GetType() );
                Assert.Equal( 5d, deserializedTestObject.Value );
                Assert.Equal( "Test", deserializedTestObject.Unit );
            }

            [Fact]
            public void ThreeObjectsInIComparableWithDifferentValues_ExpectAllCorrectlyDeserialized()
            {
                var jsonSerializerSettings = CreateJsonSerializerSettings();

                var json = "{\r\n  \"Value1\": 10.0,\r\n  \"Value2\": {\r\n    \"Unit\": \"PowerUnit.Watt\",\r\n    \"Value\": 19.0\r\n  },\r\n  \"Value3\": {\r\n    \"$type\": \"UnitsNet.Serialization.JsonNet.CompatibilityTests.UnitsNetJsonConverterTests+ComparableClass, UnitsNet.Serialization.JsonNet.CompatibilityTests\",\r\n    \"Value\": 10\r\n  }\r\n}";
                var deserializedTestObject = JsonConvert.DeserializeObject<TestObjWithThreeIComparable>( json, jsonSerializerSettings );

                Assert.Equal( typeof( double ), deserializedTestObject.Value1.GetType() );
                Assert.Equal( 10d, deserializedTestObject.Value1 );
                Assert.Equal( typeof( Power ), deserializedTestObject.Value2.GetType() );
                Assert.Equal( Power.FromWatts( 19 ), deserializedTestObject.Value2 );
                Assert.Equal( typeof( ComparableClass ), deserializedTestObject.Value3.GetType() );

                var testObjWithIComparable = new TestObjWithThreeIComparable()
                {
                    Value1 = 10.0,
                    Value2 = Power.FromWatts( 19 ),
                    Value3 = new ComparableClass() { Value = 10 },
                };

                Assert.Equal( testObjWithIComparable.Value3, deserializedTestObject.Value3 );
            }

            private static JsonSerializerSettings CreateJsonSerializerSettings()
            {
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto
                };

                jsonSerializerSettings.Converters.Add( new UnitsNetJsonConverter() );
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

            public int CompareTo( object obj )
            {
                return ( (IComparable)Value ).CompareTo( obj );
            }
        }

        private class ComparableClass : IComparable
        {
            public int Value { get; set; }
            public int CompareTo( object obj )
            {
                return ( (IComparable)Value ).CompareTo( obj );
            }

            // Needed for virfying that the deserialized object is the same, should not affect the serilization code
            public override bool Equals( object obj )
            {
                if( obj == null || GetType() != obj.GetType() )
                {
                    return false;
                }
                return Value.Equals( ( (ComparableClass)obj ).Value );
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
