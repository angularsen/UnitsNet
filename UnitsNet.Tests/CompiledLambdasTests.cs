using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class CompiledLambdasTests
    {
        [Theory]
        [InlineData( 3.0, 2.0, 6.0 )]
        public void MultiplyReturnsExpectedValues<TLeft, TRight, TResult>( TLeft left, TRight right, TResult result )
        {
            Assert.Equal( result, CompiledLambdas.Multiply<TLeft, TRight, TResult>( left, right ) );
        }

        [Theory]
        [InlineData( 6.0, 2.0, 3.0 )]
        public void DivideReturnsExpectedValues<TLeft, TRight, TResult>( TLeft left, TRight right, TResult result )
        {
            Assert.Equal( result, CompiledLambdas.Divide<TLeft, TRight, TResult>( left, right ) );
        }

        [Theory]
        [InlineData( 3.0, 2.0, 5.0 )]
        public void AddReturnsExpectedValues<TLeft, TRight, TResult>( TLeft left, TRight right, TResult result )
        {
            Assert.Equal( result, CompiledLambdas.Add<TLeft, TRight, TResult>( left, right ) );
        }

        [Theory]
        [InlineData( 3.0, 2.0, 1.0 )]
        public void SubtractReturnsExpectedValues<TLeft, TRight, TResult>( TLeft left, TRight right, TResult result )
        {
            Assert.Equal( result, CompiledLambdas.Subtract<TLeft, TRight, TResult>( left, right ) );
        }
    }
}
