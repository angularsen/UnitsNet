// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.
#if NETFRAMEWORK
using System.Runtime.Serialization.Json;
using UnitsNet.Serialization.Surrogates;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Serialization.DataContractJsonSerializerTests.Surrogates
{
    public class ExtendedDataContractJsonSerializerTests : StringUnitJsonDataContractSerializerTestsBase
    {
        public ExtendedDataContractJsonSerializerTests()
            : base(new DataContractJsonSerializerSettings {DataContractSurrogate = new ExtendedQuantityDataContractSurrogate()})
        {
        }

        [Fact]
        public void DecimalQuantity_SerializedWithDecimalValueValueAndUnitTypeName()
        {
            var quantity = new Information(1.20m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1.2,\"Unit\":\"InformationUnit.Exabyte\",\"ValueString\":\"1.20\",\"ValueType\":\"decimal\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void DecimalQuantity_InScientificNotation_SerializedWithExpandedValueAndUnitTypeName()
        {
            var quantity = new Information(1E+9m, InformationUnit.Exabyte);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":\"InformationUnit.Exabyte\",\"ValueString\":\"1000000000\",\"ValueType\":\"decimal\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
    }
}
#endif
