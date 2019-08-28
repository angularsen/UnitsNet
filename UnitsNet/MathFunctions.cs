using System;
using System.Linq.Expressions;

namespace UnitsNet
{
    /// <summary>
    /// Compiled lambda math functions.
    /// </summary>
    /// <typeparam name="TLeft">The type of the left hand side of the binary expression.</typeparam>
    /// <typeparam name="TRight">The type of the right hand side of the binary expression.</typeparam>
    /// <typeparam name="TResult">The type of the result of the binary expression.</typeparam>
    internal static class MathFunctions<TLeft, TRight, TResult>
    {
        static MathFunctions()
        {
            Multiply = CreateBinaryFunction(Expression.Multiply);
            Divide = CreateBinaryFunction(Expression.Divide);
            Add = CreateBinaryFunction(Expression.Add);
            Subtract = CreateBinaryFunction(Expression.Subtract);
        }

        /// <summary>
        /// A function to multiply two numbers.
        /// </summary>
        internal static Func<TLeft, TRight, TResult> Multiply { get; }

        /// <summary>
        /// A function to divide two numbers.
        /// </summary>
        internal static Func<TLeft, TRight, TResult> Divide { get; }

        /// <summary>
        /// A function to add two numbers.
        /// </summary>
        internal static Func<TLeft, TRight, TResult> Add { get; }

        /// <summary>
        /// A function to subtract two numbers.
        /// </summary>
        internal static Func<TLeft, TRight, TResult> Subtract { get; }

        /// <summary>
        /// Creates a binary function using the given creator.
        /// </summary>
        /// <param name="expressionCreationFunction">The binary expression creation function.</param>
        /// <returns>The binary function.</returns>
        private static Func<TLeft, TRight, TResult> CreateBinaryFunction(Func<Expression, Expression, BinaryExpression> expressionCreationFunction)
        {
            var leftParameter = Expression.Parameter(typeof(TLeft), "left");
            var rightParameter = Expression.Parameter(typeof(TRight), "right");

            var binaryExpression = expressionCreationFunction(leftParameter, rightParameter);
            var lambda = Expression.Lambda<Func<TLeft, TRight, TResult>>(binaryExpression, leftParameter, rightParameter);

            return lambda.Compile();
        }
    }
}
