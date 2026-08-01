// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet;

/// <summary>Reusable algorithms for quantities with affine conversion semantics.</summary>
public static class AffineQuantityMath
{
    /// <summary>Calculates the arithmetic average of affine quantities in the first value's unit.</summary>
    public static TQuantity Average<TQuantity, TUnit>(IEnumerable<TQuantity> quantities)
        where TQuantity : IQuantity<TQuantity, TUnit, double>, IAffineQuantity<TQuantity>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no quantities.");
        }

        TQuantity first = enumerator.Current;
        TUnit unit = first.Unit;
        double result = first.Value;
        var count = 1;
        while (enumerator.MoveNext())
        {
            TQuantity quantity = enumerator.Current;
            result += TQuantity.Convert(quantity.Value, quantity.Unit, unit);
            count++;
        }

        return TQuantity.From(result / count, unit);
    }

    /// <summary>Calculates the arithmetic average of affine quantities in the requested unit.</summary>
    public static TQuantity Average<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit, double>, IAffineQuantity<TQuantity>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);

        double result = 0;
        var count = 0;
        foreach (TQuantity quantity in quantities)
        {
            result += TQuantity.Convert(quantity.Value, quantity.Unit, unit);
            count++;
        }

        return count == 0
            ? throw new InvalidOperationException("Sequence contains no quantities.")
            : TQuantity.From(result / count, unit);
    }
}
