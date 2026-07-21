// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Metadata supplied by generated code to shared quantity operations.</summary>
public interface IQuantityMetadata<TUnit>
    where TUnit : struct, Enum
{
    /// <summary>Gets the logical quantity name.</summary>
    string Name { get; }

    /// <summary>Gets the unit through which conversions are performed.</summary>
    TUnit BaseUnit { get; }

    /// <summary>Gets the units generated for this quantity.</summary>
    IReadOnlyList<UnitInfo<TUnit>> Units { get; }

    /// <summary>Converts a value from the specified unit to the base unit.</summary>
    double ToBase(double value, TUnit unit);

    /// <summary>Converts a value from the base unit to the specified unit.</summary>
    double FromBase(double value, TUnit unit);
}
