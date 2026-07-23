// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>Reusable algorithms over quantities that advertise compatible arithmetic semantics.</summary>
public static class QuantityMath
{
    /// <summary>
    /// Sums linear quantities, returning zero in the base unit for an empty sequence and otherwise
    /// preserving the first value's unit.
    /// </summary>
    public static TQuantity Sum<TQuantity>(IEnumerable<TQuantity> quantities)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        ArgumentNullException.ThrowIfNull(quantities);

        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return TQuantity.Zero;
        }

        TQuantity result = enumerator.Current;
        while (enumerator.MoveNext())
        {
            result += enumerator.Current;
        }

        return result;
    }

    /// <summary>Sums linear quantities and expresses the result in the requested unit.</summary>
    public static TQuantity Sum<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);

        double result = 0;
        foreach (TQuantity quantity in quantities)
        {
            result += quantity.As(unit);
        }

        return TQuantity.From(result, unit);
    }

    /// <summary>Calculates the arithmetic average of linear quantities in the first value's unit.</summary>
    public static TQuantity Average<TQuantity>(IEnumerable<TQuantity> quantities)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        ArgumentNullException.ThrowIfNull(quantities);

        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no quantities.");
        }

        TQuantity result = enumerator.Current;
        var count = 1;
        while (enumerator.MoveNext())
        {
            result += enumerator.Current;
            count++;
        }

        return result / count;
    }

    /// <summary>Calculates the arithmetic average of linear quantities in the requested unit.</summary>
    public static TQuantity Average<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILinearQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);

        double result = 0;
        var count = 0;
        foreach (TQuantity quantity in quantities)
        {
            result += quantity.As(unit);
            count++;
        }

        return count == 0
            ? throw new InvalidOperationException("Sequence contains no quantities.")
            : TQuantity.From(result / count, unit);
    }
}
