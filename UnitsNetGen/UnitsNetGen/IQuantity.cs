// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>A strongly typed value paired with a unit enum.</summary>
public interface IQuantity<TUnit> : IFormattable
    where TUnit : struct, Enum
{
    double Value { get; }

    TUnit Unit { get; }

    double As(TUnit unit);
}
