// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization.Json;
using UnitsNet.Serialization.Surrogates;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests.Surrogates
{
    public class GenericDataContractJsonSerializerTests : StringUnitJsonDataContractSerializerTestsBase
    {
        public GenericDataContractJsonSerializerTests()
            : base(new DataContractJsonSerializerSettings {DataContractSurrogate = new GenericQuantityDataContractSurrogate()})
        {
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueValueAndUnitTypeName()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.20,\"Unit\":\"InformationUnit.Exabyte\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }


        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndMemberName()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":\"InformationUnit.Exabyte\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
    }
}
