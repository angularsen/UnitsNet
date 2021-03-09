// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization.Json;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests.Surrogates
{
    /// <summary>
    /// This is a test-bed for any serializers that use the <i>standard</i> format of encoding the Unit & Value:
    /// https://github.com/angularsen/UnitsNet#serialization
    /// </summary>
    public abstract class StringUnitJsonDataContractSerializerTestsBase : DataContractJsonSerializerTestsBase
    {
        protected StringUnitJsonDataContractSerializerTestsBase(DataContractJsonSerializerSettings settings) : base(settings)
        {
        }

        [Fact]
        public void DoubleQuantity_SerializedWithDoubleValueAndUnitTypeName()
        {
            var quantity = new Mass(1.20, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1.2,\"Unit\":\"MassUnit.Milligram\"}";

            var result = SerializeObject(quantity);

            Assert.Equal(expectedJson, result);
        }

        [Fact]
        public void DoubleQuantity_InScientificNotation_SerializedWithExpandedValueAndUnitTypeName()
        {
            var quantity = new Mass(1E+9, MassUnit.Milligram);
            var expectedJson = "{\"Value\":1000000000,\"Unit\":\"MassUnit.Milligram\"}";

            var json = SerializeObject(quantity);

            Assert.Equal(expectedJson, json);
        }
    }
}
