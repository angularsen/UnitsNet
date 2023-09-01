// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public sealed class UnitsNetBaseJsonConverterTest
    {
        private readonly TestConverter _sut;

        public UnitsNetBaseJsonConverterTest()
        {
            _sut = new TestConverter();
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertIQuantity_works_with_double_type()
        {
            var result = _sut.Test_ConvertDoubleIQuantity(Length.FromMeters(10.2365));

            Assert.Equal("LengthUnit.Meter", result.Unit);
            Assert.Equal(10.2365, result.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertIQuantity_works_with_decimal_type()
        {
            var result = _sut.Test_ConvertDecimalIQuantity(Power.FromWatts(10.2365m));

            Assert.Equal("PowerUnit.Watt", result.Unit);
            Assert.Equal(10.2365m, result.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertIQuantity_throws_ArgumentNullException_when_quantity_is_NULL()
        {
            var result = Assert.Throws<ArgumentNullException>(() => _sut.Test_ConvertDoubleIQuantity(null));

            Assert.Equal("Value cannot be null. (Parameter 'quantity')", result.Message);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_works_as_expected()
        {
            var result = _sut.Test_ConvertDecimalValueUnit("PowerUnit.Watt", 10.2365m);

            Assert.NotNull(result);
            Assert.IsType<Power>(result);
            Assert.True(Power.FromWatts(10.2365m).Equals((Power)result, 1E-5m, ComparisonType.Absolute));

        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_throws_UnitsNetException_when_unit_does_not_exist()
        {
            var result = Assert.Throws<UnitsNetException>(() => _sut.Test_ConvertDoubleValueUnit("SomeImaginaryUnit.Watt", 10.2365D));

            Assert.Equal("Unable to find enum type.", result.Message);
            Assert.True(result.Data.Contains("type"));
            Assert.Equal("UnitsNet.Units.SomeImaginaryUnit,UnitsNet", result.Data["type"]);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ConvertValueUnit_throws_UnitsNetException_when_unit_is_in_unexpected_format()
        {
            var result = Assert.Throws<UnitsNetException>(() => _sut.Test_ConvertDecimalValueUnit("PowerUnit Watt", 10.2365m));

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
        public void UnitsNetBaseJsonConverter_ReadValueUnit_works_with_double_quantity()
        {
            var token = new JObject {{"Unit", "LengthUnit.Meter"}, {"Value", 10.2365}};

            var result = _sut.Test_ReadDoubleValueUnit(token);

            Assert.NotNull(result);
            Assert.Equal("LengthUnit.Meter", result?.Unit);
            Assert.Equal(10.2365, result?.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_works_with_decimal_quantity()
        {
            var token = new JObject {{"Unit", "PowerUnit.Watt"}, {"Value", 10.2365m}, {"ValueString", "10.2365"}, {"ValueType", "decimal"}};

            var result = _sut.Test_ReadDecimalValueUnit(token);

            Assert.NotNull(result);
            Assert.Equal("PowerUnit.Watt", result?.Unit);
            Assert.Equal(10.2365m, result?.Value);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_returns_null_when_value_is_a_string()
        {
            var token = new JObject {{"Unit", "PowerUnit.Watt"}, {"Value", "10.2365"}};

            var result = _sut.Test_ReadDecimalValueUnit(token);

            Assert.Null(result);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_returns_null_when_value_type_is_not_a_string()
        {
            var token = new JObject {{"Unit", "PowerUnit.Watt"}, {"Value", 10.2365}, {"ValueType", 123}};

            var result = _sut.Test_ReadDecimalValueUnit(token);

            Assert.Null(result);
        }

        [Fact]
        public void UnitsNetBaseJsonConverter_ReadDoubleValueUnit_works_with_empty_token()
        {
            var token = new JObject();

            var result = _sut.Test_ReadDoubleValueUnit(token);

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
                token.Add("Value", 10.2365m);
            }

            var result = _sut.Test_ReadDecimalValueUnit(token);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("Unit", "Value", "ValueString", "ValueType")]
        [InlineData("unit", "Value", "ValueString", "ValueType")]
        [InlineData("Unit", "value", "valueString", "valueType")]
        [InlineData("unit", "value", "valueString", "valueType")]
        [InlineData("unIT", "vAlUe", "vAlUeString", "vAlUeType")]
        public void UnitsNetBaseJsonConverter_ReadValueUnit_works_case_insensitive(
            string unitPropertyName,
            string valuePropertyName,
            string valueStringPropertyName,
            string valueTypePropertyName)
        {
            var token = new JObject
            {
                {unitPropertyName, "PowerUnit.Watt"},
                {valuePropertyName, 10.2365m},
                {valueStringPropertyName, 10.2365m.ToString(CultureInfo.InvariantCulture)},
                {valueTypePropertyName, "decimal"}
            };

            var result = _sut.Test_ReadDecimalValueUnit(token);

            Assert.NotNull(result);
            Assert.Equal("PowerUnit.Watt", result?.Unit);
            Assert.Equal(10.2365m, result?.Value);
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

            public (string Unit, double Value) Test_ConvertDoubleIQuantity(IQuantity value)
            {
                var result = ConvertIQuantity(value);
                return (result.Unit, result.Value);
            }

            public (string Unit, decimal Value) Test_ConvertDecimalIQuantity(IQuantity value)
            {
                var result = ConvertIQuantity(value);
                if (result is ExtendedValueUnit {ValueType: "decimal"} decimalResult)
                {
                    return (result.Unit, decimal.Parse(decimalResult.ValueString, CultureInfo.InvariantCulture));
                }

                throw new ArgumentException("The quantity does not have a decimal value", nameof(value));
            }

            public IQuantity Test_ConvertDoubleValueUnit(string unit, double value) => Test_ConvertValueUnit(new ValueUnit {Unit = unit, Value = value});

            public IQuantity Test_ConvertDecimalValueUnit(string unit, decimal value) => Test_ConvertValueUnit(new ExtendedValueUnit
            {
                Unit = unit, Value = (double) value, ValueString = value.ToString(CultureInfo.InvariantCulture), ValueType = "decimal"
            });

            private IQuantity Test_ConvertValueUnit(ValueUnit valueUnit) => ConvertValueUnit(valueUnit);

            public JsonSerializer Test_CreateLocalSerializer(JsonSerializer serializer) => CreateLocalSerializer(serializer, this);

            public (string Unit, double Value)? Test_ReadDoubleValueUnit(JToken jsonToken)
            {
                var result = ReadValueUnit(jsonToken);
                if (result == null)
                {
                    return null;
                }

                return (result.Unit, result.Value);
            }

            public (string Unit, decimal Value)? Test_ReadDecimalValueUnit(JToken jsonToken)
            {
                var result = ReadValueUnit(jsonToken);

                if (result is ExtendedValueUnit {ValueType: "decimal"} decimalResult)
                {
                    return (result.Unit, decimal.Parse(decimalResult.ValueString, CultureInfo.InvariantCulture));
                }

                return null;
            }

        }
    }
}
