// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.ComponentModel;
using UnitsNet;

namespace UnitsNet.Modular;

/// <summary>Metadata supplied by generated code to shared quantity operations.</summary>
/// <remarks>
/// This contract is public so generated code can call into <c>UnitsNet.Modular</c> from a
/// consumer assembly. It is generator infrastructure and is not intended to be implemented or
/// consumed directly by applications.
/// </remarks>
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IQuantityMetadata<TUnit>
    where TUnit : struct, Enum
{
    /// <summary>Gets the logical quantity name.</summary>
    string Name { get; }

    /// <summary>Gets the unit through which conversions are performed.</summary>
    TUnit BaseUnit { get; }

    /// <summary>Gets the units generated for this quantity.</summary>
    IReadOnlyList<UnitInfo<TUnit>> Units { get; }

    /// <summary>Gets the quantity's SI base dimensions.</summary>
    BaseDimensions BaseDimensions { get; }

    /// <summary>Converts a value from the specified unit to the base unit.</summary>
    double ToBase(double value, TUnit unit);

    /// <summary>Converts a value from the base unit to the specified unit.</summary>
    double FromBase(double value, TUnit unit);
}
