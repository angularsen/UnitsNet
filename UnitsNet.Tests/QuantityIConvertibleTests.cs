using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIConvertibleTests
    {
        private static Length length = Length.FromMeters(3.0);
        private static IConvertible lengthAsIConvertible = Length.FromMeters(3.0);

        [Fact]
        public void GetTypeCodeTest()
        {
            Assert.Equal(TypeCode.Object, lengthAsIConvertible.GetTypeCode());
            Assert.Equal(TypeCode.Object, Convert.GetTypeCode(length));
        }

        [Fact]
        public void ToBooleanTest()
        {
            Assert.Throws<InvalidCastException>(() => lengthAsIConvertible.ToBoolean(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(length, typeof(bool)));
        }

        [Fact]
        public void ToByteTest()
        {
            byte expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToByte(null));
            Assert.Equal(expected, Convert.ToByte(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(byte)));
        }

        [Fact]
        public void ToCharTest()
        {
            Assert.Throws<InvalidCastException>(() => lengthAsIConvertible.ToChar(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(length, typeof(char)));
        }

        [Fact]
        public void ToDateTimeTest()
        {
            Assert.Throws<InvalidCastException>(() => lengthAsIConvertible.ToDateTime(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(length, typeof(DateTime)));
        }

        [Fact]
        public void ToDecimalTest()
        {
            decimal expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToDecimal(null));
            Assert.Equal(expected, Convert.ToDecimal(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(decimal)));
        }

        [Fact]
        public void ToDoubleTest()
        {
            double expected = 3.0;
            Assert.Equal(expected, lengthAsIConvertible.ToDouble(null));
            Assert.Equal(expected, Convert.ToDouble(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(double)));
        }

        [Fact]
        public void ToInt16Test()
        {
            short expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToInt16(null));
            Assert.Equal(expected, Convert.ToInt16(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(short)));
        }

        [Fact]
        public void ToInt32Test()
        {
            int expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToInt32(null));
            Assert.Equal(expected, Convert.ToInt32(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(int)));
        }

        [Fact]
        public void ToInt64Test()
        {
            long expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToInt64(null));
            Assert.Equal(expected, Convert.ToInt64(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(long)));
        }

        [Fact]
        public void ToSByteTest()
        {
            sbyte expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToSByte(null));
            Assert.Equal(expected, Convert.ToSByte(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(sbyte)));
        }

        [Fact]
        public void ToSingleTest()
        {
            float expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToSingle(null));
            Assert.Equal(expected, Convert.ToSingle(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(float)));
        }

        [Fact]
        public void ToStringTest()
        {
            string expected = length.ToString(CultureInfo.CurrentUICulture);
            Assert.Equal(expected, lengthAsIConvertible.ToString(CultureInfo.CurrentUICulture));
            Assert.Equal(expected, Convert.ToString(length, CultureInfo.CurrentUICulture));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(string), CultureInfo.CurrentUICulture));
        }

        [Fact]
        public void ToTypeTest()
        {
            // Same quantity type
            Assert.Equal(length, lengthAsIConvertible.ToType(typeof(Length), null));
            Assert.Equal(length, Convert.ChangeType(length, typeof(Length)));

            // Same unit type
            Assert.Equal(length.Unit, lengthAsIConvertible.ToType(typeof(LengthUnit), null));
            Assert.Equal(length.Unit, Convert.ChangeType(length, typeof(LengthUnit)));

            // Different type
            Assert.Throws<InvalidCastException>(() => lengthAsIConvertible.ToType(typeof(Duration), null));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(length, typeof(Duration)));

            // Different unit type
            Assert.Throws<InvalidCastException>(() => lengthAsIConvertible.ToType(typeof(DurationUnit), null));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(length, typeof(DurationUnit)));

            // QuantityType
            Assert.Equal(Length.QuantityType, lengthAsIConvertible.ToType(typeof(QuantityType), null));
            Assert.Equal(Length.QuantityType, Convert.ChangeType(length, typeof(QuantityType)));

            // BaseDimensions
            Assert.Equal(Length.BaseDimensions, lengthAsIConvertible.ToType(typeof(BaseDimensions), null));
            Assert.Equal(Length.BaseDimensions, Convert.ChangeType(length, typeof(BaseDimensions)));
        }

        [Fact]
        public void ToUInt16Test()
        {
            ushort expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToUInt16(null));
            Assert.Equal(expected, Convert.ToUInt16(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(ushort)));
        }

        [Fact]
        public void ToUInt32Test()
        {
            uint expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToUInt32(null));
            Assert.Equal(expected, Convert.ToUInt32(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(uint)));
        }

        [Fact]
        public void ToUInt64Test()
        {
            ulong expected = 3;
            Assert.Equal(expected, lengthAsIConvertible.ToUInt64(null));
            Assert.Equal(expected, Convert.ToUInt64(length));
            Assert.Equal(expected, Convert.ChangeType(length, typeof(ulong)));
        }
    }
}
