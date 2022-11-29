// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetIQuantityJsonConverterTest
    {
        private readonly UnitsNetIQuantityJsonConverter _sut;

        public UnitsNetIQuantityJsonConverterTest()
        {
            _sut = new UnitsNetIQuantityJsonConverter();
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_CanWrite_returns_true()
        {
            Assert.True(_sut.CanWrite);
        }

        public static IEnumerable<object[]> WriteJson_NullArguments => new []
            {
                new object[] { null, new JsonSerializer(), "writer"},
                new object[] { new JsonTextWriter(new StringWriter()), null, "serializer"},
            };

        [Theory]
        [MemberData(nameof(WriteJson_NullArguments))]
        public void
            UnitsNetIQuantityJsonConverter_WriteJson_throws_ArgumentNullException_when_arguments_are_null(JsonWriter writer, JsonSerializer serializer, string parameterName)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.WriteJson(writer, Power.FromWatts(10D), serializer));

            Assert.Equal($"Value cannot be null. (Parameter '{parameterName}')", exception.Message);
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_NULL_value()
        {
            var result = new StringBuilder();
            using(var stringWriter = new StringWriter(result))
            using (var writer = new JsonTextWriter(stringWriter))
            {
                _sut.WriteJson(writer, null, JsonSerializer.CreateDefault());
            }

            Assert.Equal("null", result.ToString());
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_double_quantity()
        {
            var result = new StringBuilder();

            using (var stringWriter = new StringWriter(result))
            using(var writer = new JsonTextWriter(stringWriter))
            {
                _sut.WriteJson(writer, Length.FromMeters(10.2365D), JsonSerializer.CreateDefault());
            }

            Assert.Equal("{\"Unit\":\"LengthUnit.Meter\",\"Value\":10.2365}", result.ToString());
        }

        [Theory]
        [InlineData(10.2365, "10.2365", "10.2365")]
        [InlineData(10, "10.0", "10")] // Json.NET adds .0
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_decimal_quantity(decimal value, string expectedValue, string expectedValueString)
        {
            var result = new StringBuilder();

            using (var stringWriter = new StringWriter(result))
                using(var writer = new JsonTextWriter(stringWriter))
            {
                _sut.WriteJson(writer, Power.FromWatts(value), JsonSerializer.CreateDefault());
            }

            Assert.Equal($"{{\"Unit\":\"PowerUnit.Watt\",\"Value\":{expectedValue},\"ValueString\":\"{expectedValueString}\",\"ValueType\":\"decimal\"}}",
                result.ToString());
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_CanRead_returns_true()
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
        public void UnitsNetIQuantityJsonConverter_ReadJson_throws_ArgumentNullException_when_arguments_are_null(JsonReader reader, JsonSerializer serializer, string paramName)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.ReadJson(reader, typeof(IQuantity), null, false, serializer));

            Assert.Equal($"Value cannot be null. (Parameter '{paramName}')", exception.Message);
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_ReadJson_handles_NULL_values_correctly()
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
        public void UnitsNetIQuantityJsonConverter_ReadJson_works_as_expected()
        {
            var json = "{ \"unit\": \"PowerUnit.Watt\", \"Value\": 10.3654}";

            IQuantity result;

            using(var stringReader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                result = _sut.ReadJson(jsonReader, typeof(IQuantity), null, false, JsonSerializer.CreateDefault());
            }

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.Equal(10.3654M, ((Power)result).Watts);
        }
    }
}
