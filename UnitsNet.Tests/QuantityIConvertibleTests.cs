using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIConvertibleTests
    {
        private static Length _length = Length.FromMeters(3.0);
        private static readonly IConvertible LengthAsIConvertible = Length.FromMeters(3.0);

        [Fact]
        public void GetTypeCodeTest()
        {
            Assert.Equal(TypeCode.Object, LengthAsIConvertible.GetTypeCode());
            Assert.Equal(TypeCode.Object, Convert.GetTypeCode(_length));
        }

        [Fact]
        public void ToBooleanTest()
        {
            Assert.Throws<InvalidCastException>(() => LengthAsIConvertible.ToBoolean(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(_length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(_length, typeof(bool)));
        }

        [Fact]
        public void ToByteTest()
        {
            byte expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToByte(null));
            Assert.Equal(expected, Convert.ToByte(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(byte)));
        }

        [Fact]
        public void ToCharTest()
        {
            Assert.Throws<InvalidCastException>(() => LengthAsIConvertible.ToChar(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(_length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(_length, typeof(char)));
        }

        [Fact]
        public void ToDateTimeTest()
        {
            Assert.Throws<InvalidCastException>(() => LengthAsIConvertible.ToDateTime(null));
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(_length));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(_length, typeof(DateTime)));
        }

        [Fact]
        public void ToDecimalTest()
        {
            decimal expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToDecimal(null));
            Assert.Equal(expected, Convert.ToDecimal(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(decimal)));
        }

        [Fact]
        public void ToDoubleTest()
        {
            double expected = 3.0;
            Assert.Equal(expected, LengthAsIConvertible.ToDouble(null));
            Assert.Equal(expected, Convert.ToDouble(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(double)));
        }

        [Fact]
        public void ToInt16Test()
        {
            short expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToInt16(null));
            Assert.Equal(expected, Convert.ToInt16(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(short)));
        }

        [Fact]
        public void ToInt32Test()
        {
            int expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToInt32(null));
            Assert.Equal(expected, Convert.ToInt32(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(int)));
        }

        [Fact]
        public void ToInt64Test()
        {
            long expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToInt64(null));
            Assert.Equal(expected, Convert.ToInt64(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(long)));
        }

        [Fact]
        public void ToSByteTest()
        {
            sbyte expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToSByte(null));
            Assert.Equal(expected, Convert.ToSByte(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(sbyte)));
        }

        [Fact]
        public void ToSingleTest()
        {
            float expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToSingle(null));
            Assert.Equal(expected, Convert.ToSingle(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(float)));
        }

        [Fact]
        public void ToStringTest()
        {
            string expected = _length.ToString(CultureInfo.CurrentCulture);
            Assert.Equal(expected, LengthAsIConvertible.ToString(CultureInfo.CurrentCulture));
            Assert.Equal(expected, Convert.ToString(_length, CultureInfo.CurrentCulture));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(string), CultureInfo.CurrentCulture));
        }

        [Fact]
        public void ToTypeTest()
        {
            // Same quantity type
            Assert.Equal(_length, LengthAsIConvertible.ToType(typeof(Length), null));
            Assert.Equal(_length, Convert.ChangeType(_length, typeof(Length)));

            // Same unit type
            Assert.Equal(_length.Unit, LengthAsIConvertible.ToType(typeof(LengthUnit), null));
            Assert.Equal(_length.Unit, Convert.ChangeType(_length, typeof(LengthUnit)));

            // Different type
            Assert.Throws<InvalidCastException>(() => LengthAsIConvertible.ToType(typeof(Duration), null));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(_length, typeof(Duration)));

            // Different unit type
            Assert.Throws<InvalidCastException>(() => LengthAsIConvertible.ToType(typeof(DurationUnit), null));
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(_length, typeof(DurationUnit)));

            // QuantityInfo
            Assert.Equal(Length.Info, LengthAsIConvertible.ToType(typeof(QuantityInfo), null));
            Assert.Equal(Length.Info, Convert.ChangeType(_length, typeof(QuantityInfo)));

            // BaseDimensions
            Assert.Equal(Length.BaseDimensions, LengthAsIConvertible.ToType(typeof(BaseDimensions), null));
            Assert.Equal(Length.BaseDimensions, Convert.ChangeType(_length, typeof(BaseDimensions)));
        }

        [Fact]
        public void ToUInt16Test()
        {
            ushort expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToUInt16(null));
            Assert.Equal(expected, Convert.ToUInt16(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(ushort)));
        }

        [Fact]
        public void ToUInt32Test()
        {
            uint expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToUInt32(null));
            Assert.Equal(expected, Convert.ToUInt32(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(uint)));
        }

        [Fact]
        public void ToUInt64Test()
        {
            ulong expected = 3;
            Assert.Equal(expected, LengthAsIConvertible.ToUInt64(null));
            Assert.Equal(expected, Convert.ToUInt64(_length));
            Assert.Equal(expected, Convert.ChangeType(_length, typeof(ulong)));
        }
    }
}
