using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace UnitsNet
{
    /// <summary>
    ///     A set of extension methods for some of the most common Math operations, such as Min, Max, Sum and Average
    /// </summary>
    public static class UnitMath
    {
        /// <summary>
        ///     Returns the absolute value of the specified quantity.
        /// </summary>
        /// <typeparam name="TQuantity">
        ///     The type of the quantity, which must implement <see cref="IQuantity" />.
        /// </typeparam>
        /// <param name="value">
        ///     The quantity whose absolute value is to be calculated.
        /// </param>
        /// <returns>
        ///     A quantity of type <typeparamref name="TQuantity" /> representing the absolute value of the input quantity.
        /// </returns>
        /// <exception cref="NullReferenceException">
        ///     Thrown if the input <paramref name="value" /> is <c>null</c>.
        /// </exception>
        public static TQuantity Abs<TQuantity>(this TQuantity value) where TQuantity : IQuantity
        {
            // TODO see about constraining to IQuantityInstance<TQuantity>
// #if NET
//             return TQuantity.Create(QuantityValue.Abs(value.Value), value.UnitKey);
// #else
//             return value.QuantityInfo.Create(QuantityValue.Abs(value.Value), value.UnitKey);
// #endif
            return QuantityValue.IsNegative(value.Value) ? (TQuantity)value.QuantityInfo.From(-value.Value, value.UnitKey) : value;
        }

        /// <summary>Returns the smaller of two <typeparamref name="TQuantity" /> values.</summary>
        /// <typeparam name="TQuantity">The type of quantities to compare.</typeparam>
        /// <param name="val1">The first of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <param name="val2">The second of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is smaller.</returns>
        public static TQuantity Min<TQuantity>(TQuantity val1, TQuantity val2)
            where TQuantity : IQuantity, IComparable<TQuantity>
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
        [Obsolete("Duplicate of System.Linq.Min")]
        public static TQuantity Min<TQuantity, TUnitType>(this IEnumerable<TQuantity> source, TUnitType unitType)
            where TUnitType : struct, Enum
            where TQuantity : IQuantity<TUnitType>
        {
            return (TQuantity) Quantity.From(source.Min(x => x.As(unitType)), UnitKey.ForUnit(unitType));
        }

        /// <summary>
        ///     Computes the min of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
        ///     transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate a min.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation.</typeparam>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The min of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        [Obsolete("Duplicate of System.Linq.Min")]
        public static TQuantity Min<TSource, TQuantity, TUnitType>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnitType unitType)
            where TQuantity : IQuantity<TUnitType>
            where TUnitType : struct, Enum
        {
            return source.Select(selector).Min(unitType);
        }

        /// <summary>Returns the larger of two <typeparamref name="TQuantity" /> values.</summary>
        /// <typeparam name="TQuantity">The type of quantities to compare.</typeparam>
        /// <param name="val1">The first of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <param name="val2">The second of two <typeparamref name="TQuantity" /> values to compare.</param>
        /// <returns>Parameter <paramref name="val1" /> or <paramref name="val2" />, whichever is larger.</returns>
        public static TQuantity Max<TQuantity>(TQuantity val1, TQuantity val2)
            where TQuantity : IQuantity, IComparable<TQuantity>
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
        [Obsolete("Duplicate of System.Linq.Max")]
        public static TQuantity Max<TQuantity, TUnitType>(this IEnumerable<TQuantity> source, TUnitType unitType)
            where TQuantity : IQuantity<TUnitType>
            where TUnitType : struct, Enum
        {
            return (TQuantity) Quantity.From(source.Max(x => x.As(unitType)), UnitKey.ForUnit(unitType));
        }

        /// <summary>
        ///     Computes the max of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
        ///     transform function on each element of the input sequence.
        /// </summary>
        /// <param name="source">A sequence of values that are used to calculate a max.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <param name="unitType">The desired unit type for the resulting quantity</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TQuantity">The type of quantity that is produced by this operation.</typeparam>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The max of the projected values, represented in the specified unit type.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source">source</paramref> or <paramref name="selector">selector</paramref> is null.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="source">source</paramref> contains no elements.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="source">source</paramref> contains quantity types different from <paramref name="unitType" />.
        /// </exception>
        [Obsolete("Duplicate of System.Linq.Max")]
        public static TQuantity Max<TSource, TQuantity, TUnitType>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnitType unitType)
            where TQuantity : IQuantity<TUnitType>
            where TUnitType : struct, Enum
        {
            return source.Select(selector).Max(unitType);
        }
        
        /// <summary>Returns <paramref name="value" /> clamped to the inclusive range of <paramref name="min" /> and <paramref name="max" />.</summary>
        /// <param name="value">The value to be clamped.</param>
        /// <param name="min">The lower bound of the result.</param>
        /// <param name="max">The upper bound of the result.</param>
        /// <returns>
        ///   <paramref name="value" /> if <paramref name="min" /> ≤ <paramref name="value" /> ≤ <paramref name="max" />.
        ///
        ///   -or-
        ///
        ///   <paramref name="min" /> (converted to value.Unit) if <paramref name="value" /> &lt; <paramref name="min" />.
        ///
        ///   -or-
        ///
        ///   <paramref name="max" /> (converted to value.Unit) if <paramref name="max" /> &lt; <paramref name="value" />.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="min" /> cannot be greater than <paramref name="max" />.
        /// </exception>
        public static TQuantity Clamp<TQuantity>(TQuantity value, TQuantity min, TQuantity max)
            where TQuantity : IQuantityOfType<TQuantity>, IComparable<TQuantity>
        {
            UnitKey targetUnit = value.UnitKey;
            TQuantity minValue = UnitConverter.Default.ConvertToUnit(min, targetUnit);
            TQuantity maxValue = UnitConverter.Default.ConvertToUnit(max, targetUnit);

            if (minValue.CompareTo(maxValue) > 0)
            {
                throw new ArgumentException($"min ({min}) cannot be greater than max ({max})", nameof(min));
            }

            if (value.CompareTo(minValue) < 0)
            {
                return minValue;
            }

            if (value.CompareTo(maxValue) > 0)
            {
                return maxValue;
            }

            return value;
        }
    }
}
