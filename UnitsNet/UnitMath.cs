namespace UnitsNet;

/// <summary>
///     Extension methods for common math operations.
/// </summary>
public static class UnitMath
{
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

    /// <summary>
    ///     Clamps the specified <paramref name="value" /> to the inclusive range defined by <paramref name="min" /> and
    ///     <paramref name="max" />.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity, which must implement <see cref="IQuantityOfType{TQuantity}" /> and
    ///     <see cref="IComparable{TQuantity}" />.
    /// </typeparam>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The minimum allowable value.</param>
    /// <param name="max">The maximum allowable value.</param>
    /// <returns>
    ///     The clamped value:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 <paramref name="value" /> if it lies within the range [<paramref name="min" />,
    ///                 <paramref name="max" />].
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <paramref name="min" /> (converted to value.Unit) if <paramref name="value" /> is less than
    ///                 <paramref name="min" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <paramref name="max" /> (converted to value.Unit) if <paramref name="value" /> is greater than
    ///                 <paramref name="max" />.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="min" /> is greater than <paramref name="max" />.
    /// </exception>
    public static TQuantity Clamp<TQuantity>(TQuantity value, TQuantity min, TQuantity max)
        where TQuantity : IQuantityOfType<TQuantity>, IComparable<TQuantity>
    {
        UnitKey unitKey = value.UnitKey;
#if NET
        TQuantity minValue = TQuantity.Create(min.As(unitKey), unitKey);
        TQuantity maxValue = TQuantity.Create(max.As(unitKey), unitKey);
#else
        TQuantity minValue = value.QuantityInfo.Create(min.As(unitKey), unitKey);
        TQuantity maxValue = value.QuantityInfo.Create(max.As(unitKey), unitKey);
#endif

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
