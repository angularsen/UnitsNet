using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityValueTests
    {
        [Fact]
        public void ImplicitCreationFromByte()
        {
            QuantityValue quantityValue = (byte)3;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromShort()
        {
            QuantityValue quantityValue = (short)3;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromInt()
        {
            QuantityValue quantityValue = 3;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromLong()
        {
            QuantityValue quantityValue = (long)3.0;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromFloat()
        {
            QuantityValue quantityValue = 3.0f;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromDouble()
        {
            QuantityValue quantityValue = 3.0;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void ImplicitCreationFromDecimal()
        {
            QuantityValue quantityValue = 3.0m;

            Assert.Equal(3.0, (double)quantityValue);
            Assert.Equal(3.0m, (decimal)quantityValue);
        }

        [Fact]
        public void EqualsObject()
        {
            QuantityValue quantityValue = 3.0;

            Assert.True(quantityValue.Equals((object)3.0));
            Assert.True(quantityValue.Equals((object)3.0m));
            Assert.False(quantityValue.Equals("String"));

            QuantityValue quantityValue2 = 3.0;
            QuantityValue quantityValue3 = 5.0;

            Assert.True(quantityValue.Equals((object)quantityValue2));
            Assert.False(quantityValue.Equals((object)quantityValue3));
        }

        [Fact]
        public void EqualsDouble()
        {
            QuantityValue quantityValue = 3.0;
            Assert.True(quantityValue.Equals(3.0));
        }

        [Fact]
        public void EqualsDecimal()
        {
            QuantityValue quantityValue = 3.0;
            Assert.True(quantityValue.Equals(3.0m));
        }

        [Fact]
        public void EqualsQuantityValue()
        {
            QuantityValue doubleValue1 = 3.0;
            QuantityValue doubleValue2 = 3.0;
            QuantityValue doubleValue3 = 5.0;

            Assert.True(doubleValue1.Equals(doubleValue2));
            Assert.False(doubleValue1.Equals(doubleValue3));

            QuantityValue decimalValue1 = 3.0m;
            QuantityValue decimalValue2 = 3.0m;
            QuantityValue decimalValue3 = 5.0m;

            Assert.True(decimalValue1.Equals(decimalValue2));
            Assert.False(doubleValue1.Equals(decimalValue3));
        }

        [Fact]
        public void GetHashCodeEqualsValueGetHashCode()
        {
            QuantityValue doubleValue1 = 3.0;
            Assert.Equal((3.0).GetHashCode(), doubleValue1.GetHashCode());

            QuantityValue decimalValue1 = 3.0m;
            Assert.Equal((3.0m).GetHashCode(), decimalValue1.GetHashCode());
        }
    }
}
