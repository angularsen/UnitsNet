using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet
{
    /// <summary>
    ///     A set of extension methods for some of the most common Math operations, such as Min, Max, Sum and Average
    /// </summary>
    public static class UnitMath
    {
        /// <summary>Computes the sum of a sequence of <typeparamref name="TQuantity" /> values.</summary>
        /// <param name="source">A sequence of <typeparamref name="TQuantity" /> values to calculate the sum of.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <returns>The sum of the values in the sequence, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Sum<TQuantity, T>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From<T>( source.Sum(x => x.As(unitType)), unitType);
        }

        /// <summary>
        ///     Computes the sum of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
        ///     transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate a sum.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation</typeparam>
        /// <typeparam name="T">The type of the quantity value (float, double, decimal, etc.)</typeparam>
        /// <returns>The sum of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Sum<TSource, TQuantity, T>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Sum<TQuantity, T>(unitType);
        }

        /// <summary>Computes the min of a sequence of <typeparamref name="TQuantity" /> values.</summary>
        /// <param name="source">A sequence of <typeparamref name="TQuantity" /> values to calculate the min of.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <returns>The min of the values in the sequence, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Min<TQuantity, T>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From<T>( source.Min(x => x.As(unitType)), unitType);
        }

        /// <summary>
        ///     Computes the min of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
        ///     transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate a min.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation</typeparam>
        /// <typeparam name="T">The type of the quantity value (float, double, decimal, etc.)</typeparam>
        /// <returns>The min of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Min<TSource, TQuantity, T>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Min<TQuantity,T>(unitType);
        }

        /// <summary>Computes the max of a sequence of <typeparamref name="TQuantity" /> values.</summary>
        /// <param name="source">A sequence of <typeparamref name="TQuantity" /> values to calculate the max of.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <returns>The max of the values in the sequence, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Max<TQuantity, T>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From<T>( source.Max(x => x.As(unitType)), unitType);
        }

        /// <summary>
        ///     Computes the max of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
        ///     transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate a max.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation</typeparam>
        /// <typeparam name="T">The type of the quantity value (float, double, decimal, etc.)</typeparam>
        /// <returns>The max of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Max<TSource, TQuantity, T>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Max<TQuantity,T>(unitType);
        }

        /// <summary>Computes the average of a sequence of <typeparamref name="TQuantity" /> values.</summary>
        /// <param name="source">A sequence of <typeparamref name="TQuantity" /> values to calculate the average of.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <returns>The average of the values in the sequence, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Average<TQuantity, T>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From<T>( source.Average(x => x.As(unitType)), unitType);
        }

        /// <summary>
        ///     Computes the average of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking
        ///     a transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate an average.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation</typeparam>
        /// <typeparam name="T">The type of the quantity value (float, double, decimal, etc.)</typeparam>
        /// <returns>The average of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Average<TSource, TQuantity, T>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Average<TQuantity, T>( unitType);
        }
    }
}
