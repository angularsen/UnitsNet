using System;
using System.Linq.Expressions;

namespace UnitsNet
{
    /// <summary>
    /// Compiled lambda expressions that can be invoked with generic run-time parameters. This is used for performance as
    /// it is far faster than reflection based alternatives.
    /// </summary>
    internal static class CompiledLambdas
    {
        /// <summary>
        /// Multiplies the given values.
        /// </summary>
        /// <typeparam name="T">The type of the operation (left hand side, right hand side, and result).</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The multiplied result.</returns>
        internal static T Multiply<T>(T left, T right) => MultiplyImplementation<T, T, T>.Invoke(left, right);

        /// <summary>
        /// Multiplies the given values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The multiplied result.</returns>
        internal static TResult Multiply<TLeft, TRight, TResult>(TLeft left, TRight right) =>
            MultiplyImplementation<TLeft, TRight, TResult>.Invoke(left, right);

        /// <summary>
        /// Divides the given values.
        /// </summary>
        /// <typeparam name="T">The type of the operation (left hand side, right hand side, and result).</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The divided result.</returns>
        internal static T Divide<T>(T left, T right) => DivideImplementation<T, T, T>.Invoke(left, right);

        /// <summary>
        /// Divides the given values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The divided result.</returns>
        internal static TResult Divide<TLeft, TRight, TResult>(TLeft left, TRight right) =>
            DivideImplementation<TLeft, TRight, TResult>.Invoke(left, right);

        /// <summary>
        /// Adds the given values.
        /// </summary>
        /// <typeparam name="T">The type of the operation (left hand side, right hand side, and result).</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The added result.</returns>
        internal static T Add<T>(T left, T right) => AddImplementation<T, T, T>.Invoke(left, right);

        /// <summary>
        /// Adds the given values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The added result.</returns>
        internal static TResult Add<TLeft, TRight, TResult>(TLeft left, TRight right) =>
            AddImplementation<TLeft, TRight, TResult>.Invoke(left, right);

        /// <summary>
        /// Subtracts the given values.
        /// </summary>
        /// <typeparam name="T">The type of the operation (left hand side, right hand side, and result).</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The subtracted result.</returns>
        internal static T Subtract<T>(T left, T right) => SubtractImplementation<T, T, T>.Invoke(left, right);

        /// <summary>
        /// Subtracts the given values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The subtracted result.</returns>
        internal static TResult Subtract<TLeft, TRight, TResult>(TLeft left, TRight right) =>
            SubtractImplementation<TLeft, TRight, TResult>.Invoke(left, right);

        /// <summary>
        /// Gets the modulus of the given values.
        /// </summary>
        /// <typeparam name="T">The type of the operation (left hand side, right hand side, and result).</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The modulus.</returns>
        internal static T Modulo<T>(T left, T right) => ModuloImplementation<T, T, T>.Invoke(left, right);

        /// <summary>
        /// Gets the modulus of the given values.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>The modulus.</returns>
        internal static TResult Modulo<TLeft, TRight, TResult>(TLeft left, TRight right) =>
            ModuloImplementation<TLeft, TRight, TResult>.Invoke(left, right);

        /// <summary>
        /// Checks if the left and right hand side are equal.
        /// </summary>
        /// <typeparam name="T">The type of both the left and right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if equal, otherwise false.</returns>
        internal static bool Equal<T>(T left, T right) => EqualImplementation<T, T>.Invoke(left, right);

        /// <summary>
        /// Checks if the left and right hand side are equal.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if equal, otherwise false.</returns>
        internal static bool Equal<TLeft, TRight>(TLeft left, TRight right) =>
            EqualImplementation<TLeft, TRight>.Invoke(left, right);

        /// <summary>
        /// Checks if the left and right hand side are not equal.
        /// </summary>
        /// <typeparam name="T">The type of both the left and right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if not equal, otherwise false.</returns>
        internal static bool NotEqual<T>(T left, T right) => NotEqualImplementation<T, T>.Invoke(left, right);

        /// <summary>
        /// Checks if the left and right hand side are not equal.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if not equal, otherwise false.</returns>
        internal static bool NotEqual<TLeft, TRight>(TLeft left, TRight right) =>
            NotEqualImplementation<TLeft, TRight>.Invoke(left, right);

        /// <summary>
        /// Checks if the left hand side is less than the right hand side.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if the left hand side is less than the right hand side, otherwise false.</returns>
        internal static bool LessThan<TLeft, TRight>(TLeft left, TRight right) =>
            LessThanImplementation<TLeft, TRight>.Invoke(left, right);

        /// <summary>
        /// Checks if the left hand side is less than or equal to the right hand side.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if the left hand side is less than or equal to the right hand side, otherwise false.</returns>
        internal static bool LessThanOrEqual<TLeft, TRight>(TLeft left, TRight right) =>
            LessThanOrEqualImplementation<TLeft, TRight>.Invoke(left, right);

        /// <summary>
        /// Checks if the left hand side is greater than the right hand side.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if the left hand side is greater than the right hand side, otherwise false.</returns>
        internal static bool GreaterThan<TLeft, TRight>(TLeft left, TRight right) =>
            GreaterThanImplementation<TLeft, TRight>.Invoke(left, right);

        /// <summary>
        /// Checks if the left hand side is greater than or equal to the right hand side.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side.</typeparam>
        /// <param name="left">The left hand side parameter.</param>
        /// <param name="right">The right hand side parameter.</param>
        /// <returns>True if the left hand side is greater than or equal to the right hand side, otherwise false.</returns>
        internal static bool GreaterThanOrEqual<TLeft, TRight>(TLeft left, TRight right) =>
            GreaterThanOrEqualImplementation<TLeft, TRight>.Invoke(left, right);

        #region Implementation Classes

        private static class MultiplyImplementation<TLeft, TRight, TResult>
        {
            private readonly static Func<TLeft, TRight, TResult> Function =
                CreateBinaryFunction<TLeft, TRight, TResult>(Expression.Multiply);

            internal static TResult Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class DivideImplementation<TLeft, TRight, TResult>
        {
            private readonly static Func<TLeft, TRight, TResult> Function =
                CreateBinaryFunction<TLeft, TRight, TResult>(Expression.Divide);

            internal static TResult Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class AddImplementation<TLeft, TRight, TResult>
        {
            private readonly static Func<TLeft, TRight, TResult> Function =
                CreateBinaryFunction<TLeft, TRight, TResult>(Expression.Add);

            internal static TResult Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class SubtractImplementation<TLeft, TRight, TResult>
        {
            private readonly static Func<TLeft, TRight, TResult> Function =
                CreateBinaryFunction<TLeft, TRight, TResult>(Expression.Subtract);

            internal static TResult Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class ModuloImplementation<TLeft, TRight, TResult>
        {
            private readonly static Func<TLeft, TRight, TResult> Function =
                CreateBinaryFunction<TLeft, TRight, TResult>(Expression.Modulo);

            internal static TResult Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class EqualImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.Equal);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class NotEqualImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.NotEqual);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class LessThanImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.LessThan);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class LessThanOrEqualImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.LessThanOrEqual);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class GreaterThanImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.GreaterThan);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        private static class GreaterThanOrEqualImplementation<TLeft, TRight>
        {
            private readonly static Func<TLeft, TRight, bool> Function =
                CreateBinaryFunction<TLeft, TRight, bool>(Expression.GreaterThanOrEqual);

            internal static bool Invoke(TLeft left, TRight right) => Function(left, right);
        }

        #endregion

        /// <summary>
        /// Creates a compiled lambda for the given <see cref="Func{Expression, Expression, BinaryExpression}"/>.
        /// </summary>
        /// <typeparam name="TLeft">The type of the left hand side of the binary operation.</typeparam>
        /// <typeparam name="TRight">The type of the right hand side of the binary operation.</typeparam>
        /// <typeparam name="TResult">The type of the result of the binary operation.</typeparam>
        /// <param name="expressionCreationFunction">The function that creates a binary expression to compile.</param>
        /// <returns>The compiled binary expression.</returns>
        private static Func<TLeft, TRight, TResult> CreateBinaryFunction<TLeft, TRight, TResult>(Func<Expression, Expression, BinaryExpression> expressionCreationFunction)
        {
            var leftParameter = Expression.Parameter(typeof(TLeft), "left");
            var rightParameter = Expression.Parameter(typeof(TRight), "right");

            var binaryExpression = expressionCreationFunction(leftParameter, rightParameter);
            var lambda = Expression.Lambda<Func<TLeft, TRight, TResult>>(binaryExpression, leftParameter, rightParameter);

            return lambda.Compile();
        }
    }
}
