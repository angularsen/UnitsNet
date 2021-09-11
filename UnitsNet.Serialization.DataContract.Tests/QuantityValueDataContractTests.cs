// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Serialization.Contracts;
using Xunit;

namespace UnitsNet.Serialization.DataContract.Tests
{
    public class QuantityValueDataContractTests
    {
        [Fact]
        public void QuantityValueContract_Constructor_AssignsAllProperties()
        {
            var unit = "unit";
            var value = 42.0;

            var quantityValue = new QuantityValueContract<double, string>(value, unit);

            Assert.Equal(unit, quantityValue.Unit);
            Assert.Equal(value, quantityValue.Value);
        }

        [Fact]
        public void ExtendedQuantityValueContract_Constructor_AssignsAllProperties()
        {
            var unit = "unit";
            var value = 123.456;
            var actualValue = 123.456m;
            var valueString = "1234.456";

            var quantityValue = new ExtendedQuantityValueContract<decimal, string>(value, unit, valueString, actualValue);

            Assert.Equal(unit, quantityValue.Unit);
            Assert.Equal(value, quantityValue.Value);
            Assert.Equal(valueString, quantityValue.ValueString);
            Assert.Equal(actualValue, quantityValue.ValueType);
        }

        [Fact]
        public void QuantityWithAbbreviationContract_Constructor_AssignsAllProperties()
        {
            var value = 123.456m;
            var unit = "kg";
            var quantityType = "Mass";

            var quantityValue = new QuantityWithAbbreviationContract<decimal, string>(value, quantityType, unit);

            Assert.Equal(unit, quantityValue.Unit);
            Assert.Equal(value, quantityValue.Value);
            Assert.Equal(quantityType, quantityValue.QuantityType);
        }
    }
}
