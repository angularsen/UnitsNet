// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Text;
using System.Text.Json;
using Xunit;

namespace UnitsNet.Serialization.SystemTextJson.Tests
{
    public sealed class UnitsNetIQuantityJsonConverterTest
    {
        private readonly UnitsNetIQuantityJsonConverter<IQuantity> _sut;

        public UnitsNetIQuantityJsonConverterTest()
        {
            _sut = new UnitsNetIQuantityJsonConverter<IQuantity>();
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_NULL_value()
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);

            _sut.Write(writer, null, new JsonSerializerOptions());

            var result = Encoding.UTF8.GetString(stream.ToArray());
            Assert.Equal("", result);
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_double_quantity()
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);

            _sut.Write(writer, Length.FromMeters(10.2365D), new JsonSerializerOptions());

            var result = Encoding.UTF8.GetString(stream.ToArray());
            Assert.Equal("{\"Unit\":\"LengthUnit.Meter\",\"Value\":10.2365}", result);
        }

        [Theory]
        [InlineData(10.2365, 10.2365, "10.2365")]
        [InlineData(10, 10, "10")]
        public void UnitsNetIQuantityJsonConverter_WriteJson_works_with_decimal_quantity(decimal value, double expectedValue, string expectedValueString)
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);

            var powerValue = Power.FromWatts(value);
            _sut.Write(writer, powerValue, new JsonSerializerOptions());

            var result = Encoding.UTF8.GetString(stream.ToArray());

            var resultElem = JsonDocument.Parse(result).RootElement;
            Assert.Equal("PowerUnit.Watt", resultElem.GetProperty("Unit").GetString());
            Assert.Equal(expectedValue, resultElem.GetProperty("Value").GetDouble());
            Assert.Equal(expectedValueString, resultElem.GetProperty("ValueString").GetString());
            Assert.Equal("decimal", resultElem.GetProperty("ValueType").GetString());
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_ReadJson_handles_NULL_values_correctly()
        {
            var json = "null";

            var jsonData = Encoding.UTF8.GetBytes(json);
            var jsonReader = new Utf8JsonReader(jsonData);
            var result = _sut.Read(ref jsonReader, typeof(IQuantity), new JsonSerializerOptions());

            Assert.Null(result);
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_Read_works_as_expected()
        {
            var json = "{ \"Unit\": \"PowerUnit.Watt\", \"Value\": 10.3654}";

            var jsonData = Encoding.UTF8.GetBytes(json);
            var jsonReader = new Utf8JsonReader(jsonData);
            var result = _sut.Read(ref jsonReader, typeof(IQuantity), new JsonSerializerOptions());

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.Equal(10.3654D, ((Power)result).Watts);
        }

        [Fact]
        public void UnitsNetIQuantityJsonConverter_Read_extended_works_as_expected()
        {
            var json = "{\"ValueString\": \"10.2365\",\"ValueType\": \"decimal\",\"Unit\": \"PowerUnit.Watt\",\"Value\": 10.237}";

            var jsonData = Encoding.UTF8.GetBytes(json);
            var jsonReader = new Utf8JsonReader(jsonData);
            var result = _sut.Read(ref jsonReader, typeof(IQuantity), new JsonSerializerOptions());

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.Equal(10.2365M, ((Power)result).Value);
        }
    }
}
