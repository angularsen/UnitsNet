// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>Reusable algorithms for quantities with affine conversion semantics.</summary>
public static class AffineQuantityMath
{
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
