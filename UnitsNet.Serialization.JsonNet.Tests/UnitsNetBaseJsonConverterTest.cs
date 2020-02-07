// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetBaseJsonConverterTest
    {
        private TestConverter _sut;

        public UnitsNetBaseJsonConverterTest()
        {
            _sut = new TestConverter();
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertIQuantity_works_as_expected()
        {
            var result = _sut.Test_ConvertIQuantity(Power.FromWatts(10.2365D));

            Assert.Equal("PowerUnit.Watt", result.Unit);
            Assert.Equal(10.2365D, result.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertIQuantity_throws_ArgumentNullException_when_quantity_is_NULL()
        {
            var result = Assert.Throws<ArgumentNullException>(() => _sut.Test_ConvertIQuantity(null));

            Assert.Equal("Value cannot be null.\r\nParameter name: quantity", result.Message);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_works_as_expected()
        {
            var result = _sut.Test_ConvertValueUnit("PowerUnit.Watt", 10.2365D);

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.True(Power.FromWatts(10.2365D).Equals((Power)result, 1E-5, ComparisonType.Absolute));

        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_works_with_NULL_value()
        {
            var result = _sut.Test_ConvertValueUnit();

            Assert.Null(result);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_throws_UnitsNetException_when_unit_does_not_exist()
        {
            var result = Assert.Throws<UnitsNetException>(() => _sut.Test_ConvertValueUnit("SomeImaginaryUnit.Watt", 10.2365D));

            Assert.Equal("Unable to find enum type.", result.Message);
            Assert.True(result.Data.Contains("type"));
            Assert.Equal("UnitsNet.Units.SomeImaginaryUnit,UnitsNet", result.Data["type"]);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_throws_UnitsNetException_when_unit_is_in_unexpected_format()
        {
            var result = Assert.Throws<UnitsNetException>(() => _sut.Test_ConvertValueUnit("PowerUnit Watt", 10.2365D));

            Assert.Equal("\"PowerUnit Watt\" is not a valid unit.", result.Message);
            Assert.True(result.Data.Contains("type"));
            Assert.Equal("PowerUnit Watt", result.Data["type"]);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_CreateLocalSerializer_works_as_expected()
        {
            //Possible improvement: Set all possible settings and test each one. But the main goal of CreateLocalSerializer is that the current serializer is left out.
            var serializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Arrays,
                Converters = new List<JsonConverter>()
                {
                    
                    new BinaryConverter(),
                    _sut,
                    new DataTableConverter()
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var result = _sut.Test_CreateLocalSerializer(serializer);

            Assert.Equal(TypeNameHandling.Arrays, result.TypeNameHandling);
            Assert.Equal(2, result.Converters.Count);
            Assert.Collection(result.Converters,
                (converter) => Assert.IsType<BinaryConverter>(converter),
                (converter) => Assert.IsType<DataTableConverter>(converter));
            Assert.IsType<CamelCasePropertyNamesContractResolver>(result.ContractResolver);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_work_as_expected()
        {
            var token = new JObject();

            token.Add("Unit", "PowerUnit.Watt");
            token.Add("Value", 10.2365D);

            var result = _sut.Test_ReadValueUnit(token);

            Assert.NotNull(result);
            Assert.Equal("PowerUnit.Watt", result?.Unit);
            Assert.Equal(10.2365D, result?.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_works_with_empty_token()
        {
            var token = new JObject();

            var result = _sut.Test_ReadValueUnit(token);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_returns_null_when_unit_or_value_is_missing(bool withUnit, bool withValue)
        {
            var token = new JObject();

            if (withUnit)
            {
                token.Add("Unit", "PowerUnit.Watt");
            }

            if (withValue)
            {
                token.Add("Value", 10.2365D);
            }

            var result = _sut.Test_ReadValueUnit(token);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("Unit", "Value")]
        [InlineData("unit", "Value")]
        [InlineData("Unit", "value")]
        [InlineData("unit", "value")]
        [InlineData("unIT", "vAlUe")]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_works_case_insensitive(string unitPropertyName, string valuePropertyName)
        {
            var token = new JObject();

            token.Add(unitPropertyName, "PowerUnit.Watt");
            token.Add(valuePropertyName, 10.2365D);

            var result = _sut.Test_ReadValueUnit(token);

            Assert.NotNull(result);
            Assert.Equal("PowerUnit.Watt", result?.Unit);
            Assert.Equal(10.2365D, result?.Value);
        }

        /// <summary>
        /// Dummy converter, used to access protected methods on abstract UnitsNetBaseJsonConverter{T}
        /// </summary>
        private class TestConverter : UnitsNetBaseJsonConverter<string>
        {
            public override bool CanRead => false;
            public override bool CanWrite => false;
            public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer) =>  throw new NotImplementedException();
            public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();

            public (string Unit, double Value) Test_ConvertIQuantity(IQuantity value)
            {
                var result = ConvertIQuantity(value);

                return (result.Unit, result.Value);
            }

            public IQuantity Test_ConvertValueUnit(string unit, double value) => Test_ConvertValueUnit(new ValueUnit() {Unit = unit, Value = value});
            public IQuantity Test_ConvertValueUnit() => Test_ConvertValueUnit(null);
            private IQuantity Test_ConvertValueUnit(ValueUnit valueUnit) => ConvertValueUnit(valueUnit);

            public JsonSerializer Test_CreateLocalSerializer(JsonSerializer serializer) => CreateLocalSerializer(serializer, this);

            public (string Unit, double Value)? Test_ReadValueUnit(JToken jsonToken)
            {
                var result = ReadValueUnit(jsonToken);

                if (result == null)
                {
                    return null;
                }

                return (result.Unit, result.Value);
            }
        }
    }
}
