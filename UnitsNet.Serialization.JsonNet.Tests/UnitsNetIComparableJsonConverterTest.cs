// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Newtonsoft.Json;
using UnitsNet.Serialization.JsonNet.Tests.Infrastructure;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetIComparableJsonConverterTest
    {
        private readonly UnitsNetIComparableJsonConverter _sut;

        public UnitsNetIComparableJsonConverterTest()
        {
            _sut = new UnitsNetIComparableJsonConverter();
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_CanWrite_returns_false()
        {
            Assert.False(_sut.CanWrite);
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void UnitsNetIComparableJsonConverter_WriteJson_throws_NotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _sut.WriteJson(null, null, null));
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_CanRead_returns_true()
        {
            Assert.True(_sut.CanRead);
        }

        public static IEnumerable<object[]> ReadJson_NullArguments => new[]
        {
            new object[] { null, JsonSerializer.CreateDefault(), "reader" },
            new object[] { new JsonTextReader(new StringReader("")), null, "serializer" }
        };

        [Theory]
        [MemberData(nameof(ReadJson_NullArguments))]
        public void UnitsNetIComparableJsonConverter_ReadJson_throws_ArgumentNullException_when_arguments_are_null(JsonReader reader, JsonSerializer serializer, string paramName)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.ReadJson(reader, typeof(IQuantity), null, false, serializer));

            Assert.Equal($"Value cannot be null. (Parameter '{paramName}')", exception.Message);
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_ReadJson_handles_NULL_values_correctly()
        {
            var json = "null";

            using(var stringReader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                var result = _sut.ReadJson(jsonReader, typeof(IQuantity), null, false, JsonSerializer.CreateDefault());

                Assert.Null(result);
            }
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_ReadJson_deserializes_as_concrete_type_when_objectType_not_IComparable()
        {
            string json = "{ \"value\": 12345 }";

            IComparable result;

            using (var stringReader = new StringReader(json))
                using(var jsonReader = new JsonTextReader(stringReader))
                {
                    result = _sut.ReadJson(jsonReader, typeof(TestObjectWithValueAsIComparable), null, false, JsonSerializer.CreateDefault());
                }

            Assert.NotNull(result);
            Assert.IsType<TestObjectWithValueAsIComparable>(result);
            Assert.Equal(12345, ((TestObjectWithValueAsIComparable)result).Value);
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_ReadJson_falls_back_to_default_IComparable_deserialization_when_unable_to_deserialize_as_ValueUnit()
        {
            string json = "{ \"$type\": \"UnitsNet.Serialization.JsonNet.Tests.Infrastructure.TestObjectWithValueAsIComparable, UnitsNet.Serialization.JsonNet.Tests\", \"value\": 120 }";
            IComparable result;

            using (var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var serializer = JsonSerializer.Create(new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.Auto});
                result = _sut.ReadJson(jsonReader, typeof(IComparable), null, false, serializer);
            }

            Assert.NotNull(result);
            Assert.IsType<TestObjectWithValueAsIComparable>(result);
            Assert.Equal(120, ((TestObjectWithValueAsIComparable)result).Value);
        }

        [Fact]
        public void UnitsNetIComparableJsonConverter_ReadJson_works_as_expected()
        {
            string json = "{ \"value\": 120, \"unit\": \"PowerUnit.Watt\" }";
            IComparable result;

            using (var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var serializer = JsonSerializer.Create(new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.Auto});
                result = _sut.ReadJson(jsonReader, typeof(IComparable), null, false, serializer);
            }

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.Equal(120M, ((Power)result).Watts);
        }
    }
}
