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
            return (TQuantity)value.QuantityInfo.From(Math.Abs(value.Value), value.UnitKey);
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
        public static TQuantity Clamp<TQuantity>(TQuantity value, TQuantity min, TQuantity max) where TQuantity : IComparable, IQuantity
        {
            var minValue = (TQuantity)min.ToUnit(value.Unit);
            var maxValue = (TQuantity)max.ToUnit(value.Unit);

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
