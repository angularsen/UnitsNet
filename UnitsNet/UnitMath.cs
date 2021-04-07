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
        /// <summary>Returns the absolute value of a <typeparamref name="TQuantity" />.</summary>
        /// <param name="value">
        ///     A quantity with a value that is greater than or equal to <see cref="F:System.Double.MinValue" />,
        ///     but less than or equal to <see cref="F:System.Double.MaxValue" />.
        /// </param>
        /// <returns>A quantity with a value, such that 0 ≤ value ≤ <see cref="F:System.Double.MaxValue" />.</returns>
        public static TQuantity Abs<TQuantity>(this TQuantity value) where TQuantity : IQuantity
        {
            return value.Value >= 0 ? value : (TQuantity) Quantity.From(-value.Value, value.Unit);
        }

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
        public static TQuantity Sum<TQuantity>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From(source.Sum(x => x.As(unitType)), unitType);
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
        /// <returns>The sum of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Sum<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Sum(unitType);
        }

        /// <summary>Returns the smaller of two <typeparamref name="TQuantity" /> values.</summary>
        /// <typeparam name="TQuantity">The type of quantities to compare.</typeparam>
        /// <param name="val1">The first of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <param name="val2">The second of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is smaller.</returns>
        public static TQuantity Min<TQuantity>(TQuantity val1, TQuantity val2) where TQuantity : IComparable, IQuantity
        {
            return val1.CompareTo(val2) == 1 ? val2 : val1;
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
        public static TQuantity Min<TQuantity>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From(source.Min(x => x.As(unitType)), unitType);
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
        /// <returns>The min of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Min<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Min(unitType);
        }

        /// <summary>Returns the larger of two <typeparamref name="TQuantity" /> values.</summary>
        /// <typeparam name="TQuantity">The type of quantities to compare.</typeparam>
        /// <param name="val1">The first of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <param name="val2">The second of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is larger.</returns>
        public static TQuantity Max<TQuantity>(TQuantity val1, TQuantity val2) where TQuantity : IComparable, IQuantity
        {
            return val1.CompareTo(val2) == -1 ? val2 : val1;
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
        public static TQuantity Max<TQuantity>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From(source.Max(x => x.As(unitType)), unitType);
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
        /// <returns>The max of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Max<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Max(unitType);
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
        public static TQuantity Average<TQuantity>(this IEnumerable<TQuantity> source, Enum unitType)
            where TQuantity : IQuantity
        {
            return (TQuantity) Quantity.From(source.Average(x => x.As(unitType)), unitType);
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
        /// <returns>The average of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        public static TQuantity Average<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, Enum unitType)
            where TQuantity : IQuantity
        {
            return source.Select(selector).Average(unitType);
        }
    }
}
