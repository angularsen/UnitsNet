using System.Globalization;
using System.Numerics;
using JetBrains.Annotations;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    [TestSubject(typeof(QuantityValueTypeConverter))]
    public class TypeConverterTests
    {
        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(int), true)]
        [InlineData(typeof(long), true)]
        [InlineData(typeof(decimal), true)]
        [InlineData(typeof(double), true)]
        [InlineData(typeof(QuantityValue), true)]
        [InlineData(typeof(BigInteger), true)]
        [InlineData(typeof(object), false)]
        public void CanConvertTo_ReturnsExpectedResult(Type destinationType, bool expected)
        {
            var converter = new QuantityValueTypeConverter();
            Assert.Equal(expected, converter.CanConvertTo(null, destinationType));
        }

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(int), true)]
        [InlineData(typeof(long), true)]
        [InlineData(typeof(decimal), true)]
        [InlineData(typeof(double), true)]
        [InlineData(typeof(QuantityValue), true)]
        [InlineData(typeof(BigInteger), true)]
        [InlineData(typeof(object), false)]
        public void CanConvertFrom_ReturnsExpectedResult(Type sourceType, bool expected)
        {
            var converter = new QuantityValueTypeConverter();
            Assert.Equal(expected, converter.CanConvertFrom(null, sourceType));
        }

        [Fact]
        public void ConvertTo_String()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(string));
            // Assert
            Assert.Equal("123.45", result);
        }

        [Fact]
        public void ConvertTo_Int()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(int));
            // Assert
            Assert.Equal(123, result);
        }

        [Fact]
        public void ConvertTo_Long()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123L);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(long));
            // Assert
            Assert.Equal(123L, result);
        }

        [Fact]
        public void ConvertTo_Decimal()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(decimal));
            // Assert
            Assert.Equal(123.45m, result);
        }

        [Fact]
        public void ConvertTo_Double()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(double));
            // Assert
            Assert.Equal(123.45, result);
        }

        [Fact]
        public void ConvertTo_BigInteger()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(BigInteger));
            // Assert
            Assert.Equal(new BigInteger(123), result);
        }

        [Fact]
        public void ConvertTo_QuantityValue()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(QuantityValue));
            // Assert
            Assert.Equal(quantityValue, result);
        }

        [Fact]
        public void ConvertFrom_Null()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, null);
            // Assert
            Assert.Equal(QuantityValue.Zero, result);
        }

        [Fact]
        public void ConvertFrom_String()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var expectedValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, "123.45");
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_Int()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var expectedValue = new QuantityValue(123);
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, 123);
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_Long()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var expectedValue = new QuantityValue(123);
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, 123L);
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_Decimal()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            var expectedValue = new QuantityValue(123.45m);
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, 123.45m);
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_Double()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            QuantityValue expectedValue = 123.45;
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, 123.45);
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_BigInteger()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            QuantityValue expectedValue = 123;
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, new BigInteger(123));
            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ConvertFrom_QuantityValue()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            QuantityValue inputValue = 123;
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, inputValue);
            // Assert
            Assert.Equal(inputValue, result);
        }

        [Fact]
        public void ConvertFrom_Null_Returns_Zero()
        {
            // Arrange
            var converter = new QuantityValueTypeConverter();
            // Act
            var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, null);
            // Assert
            Assert.Equal(QuantityValue.Zero, result);
        }

        [Fact]
        public void ConvertTo_InvalidConversions_ThrowsException()
        {
            var converter = new QuantityValueTypeConverter();
            var quantityValue = new QuantityValue(123.45m);
            Assert.Throws<NotSupportedException>(() => converter.ConvertTo(null, CultureInfo.InvariantCulture, quantityValue, typeof(DateTime)));
        }

        [Fact]
        public void ConvertTo_WithNull_ThrowsException()
        {
            var converter = new QuantityValueTypeConverter();
            Assert.Throws<NotSupportedException>(() => converter.ConvertTo(null, CultureInfo.InvariantCulture, null, typeof(decimal)));
        }

        [Fact]
        public void ConvertFrom_InvalidConversions_ThrowsException()
        {
            var converter = new QuantityValueTypeConverter();
            Assert.Throws<NotSupportedException>(() => converter.ConvertFrom(null, CultureInfo.InvariantCulture, DateTime.MinValue));
        }
    }
}