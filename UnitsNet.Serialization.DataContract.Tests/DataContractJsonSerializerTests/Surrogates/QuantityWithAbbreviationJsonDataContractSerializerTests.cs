// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization.Json;
using UnitsNet.Serialization.Surrogates;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests.Surrogates
{
    public class QuantityWithAbbreviationJsonDataContractSerializerTests : DataContractJsonSerializerTestsBase
    {
        public QuantityWithAbbreviationJsonDataContractSerializerTests()
            : base(new DataContractJsonSerializerSettings {DataContractSurrogate = new QuantityWithAbbreviationContractSurrogate()})
        {
        }

        [Fact]
        public void DoubleQuantity_SerializedWithDoubleValueAndQuantityName()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1.2,\"Unit\":\"mg\",\"QuantityType\":\"Mass\"}";

            var result = SerializeObject(quantity);

            Assert.Equal(expectedJson, result);
        }

        [Fact]
        public void DoubleQuantity_InScientificNotation_SerializedWithExpandedValueAndQuantityName()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":\"mg\",\"QuantityType\":\"Mass\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueValueAndQuantityName()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.20,\"Unit\":\"EB\",\"QuantityType\":\"Information\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }


        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndQuantityName()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":\"EB\",\"QuantityType\":\"Information\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
    }
}
