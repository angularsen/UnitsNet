using Xunit;

namespace UnitsNet.Tests
{
    public class CompiledLambdasTests
    {
        [Theory]
        [InlineData(3.0, 2.0, 6.0)]
        public void MultiplyReturnsExpectedValues<TLeft, TRight, TResult>(TLeft left, TRight right, TResult expected)
        {
            Assert.Equal(expected, CompiledLambdas.Multiply<TLeft, TRight, TResult>(left, right));
        }

        [Theory]
        [InlineData(6.0, 2.0, 3.0)]
        public void DivideReturnsExpectedValues<TLeft, TRight, TResult>(TLeft left, TRight right, TResult expected)
        {
            Assert.Equal(expected, CompiledLambdas.Divide<TLeft, TRight, TResult>(left, right));
        }

        [Theory]
        [InlineData(3.0, 2.0, 5.0)]
        public void AddReturnsExpectedValues<TLeft, TRight, TResult>(TLeft left, TRight right, TResult expected)
        {
            Assert.Equal(expected, CompiledLambdas.Add<TLeft, TRight, TResult>(left, right));
        }

        [Theory]
        [InlineData(3.0, 2.0, 1.0)]
        public void SubtractReturnsExpectedValues<TLeft, TRight, TResult>(TLeft left, TRight right, TResult expected)
        {
            Assert.Equal(expected, CompiledLambdas.Subtract<TLeft, TRight, TResult>(left, right));
        }

        [Theory]
        [InlineData(3.0, 2.0, 1.0)]
        public void ModuloReturnsExpectedValues<TLeft, TRight, TResult>(TLeft left, TRight right, TResult expected)
        {
            Assert.Equal(expected, CompiledLambdas.Modulo<TLeft, TRight, TResult>(left, right));
        }

        [Theory]
        [InlineData(3.0, 3.0, true)]
        [InlineData(3.0, 2.0, false)]
        public void EqualReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.Equal(left, right));
        }

        [Theory]
        [InlineData(3.0, 3.0, false)]
        [InlineData(3.0, 2.0, true)]
        public void NotEqualReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.NotEqual(left, right));
        }

        [Theory]
        [InlineData(2.0, 3.0, true)]
        [InlineData(2.0, 2.0, false)]
        [InlineData(3.0, 2.0, false)]
        public void LessThanReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.LessThan(left, right));
        }

        [Theory]
        [InlineData(2.0, 3.0, true)]
        [InlineData(2.0, 2.0, true)]
        [InlineData(3.0, 2.0, false)]
        public void LessThanOrEqualReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.LessThanOrEqual(left, right));
        }

        [Theory]
        [InlineData(3.0, 2.0, true)]
        [InlineData(3.0, 3.0, false)]
        [InlineData(3.0, 4.0, false)]
        public void GreaterThanReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.GreaterThan(left, right));
        }

        [Theory]
        [InlineData(3.0, 2.0, true)]
        [InlineData(3.0, 3.0, true)]
        [InlineData(3.0, 4.0, false)]
        public void GreaterThanOrEqualReturnsExpectedValues<TLeft, TRight>(TLeft left, TRight right, bool expected)
        {
            Assert.Equal(expected, CompiledLambdas.GreaterThanOrEqual(left, right));
        }
    }
}
