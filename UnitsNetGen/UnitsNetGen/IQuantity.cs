// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>A strongly typed value paired with a unit enum.</summary>
public interface IQuantity<TUnit> : IFormattable
    where TUnit : struct, Enum
{
    /// <summary>Gets the numeric value expressed in <see cref="Unit" />.</summary>
    double Value { get; }

    /// <summary>Gets the unit in which <see cref="Value" /> is expressed.</summary>
    TUnit Unit { get; }

    /// <summary>Converts this quantity's value to the specified unit.</summary>
    double As(TUnit unit);
}
