// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.ComponentModel;

namespace UnitsNet.Modular.SourceGen;

/// <summary>Metadata supplied by generated code to shared quantity operations.</summary>
/// <remarks>
/// This contract is public so emitted code can call the runtime from a consumer assembly. It is
/// source-generator infrastructure and is not intended to be implemented or consumed directly by
/// applications.
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

/// <summary>Generated parsing operations supplied to immutable quantity metadata.</summary>
/// <remarks>
/// This contract is public so emitted code can call the runtime from a consumer assembly. It is
/// source-generator infrastructure and is not intended for direct application use.
/// </remarks>
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IQuantityMetadata<TQuantity, TUnit> : IQuantityMetadata<TUnit>
    where TUnit : struct, Enum
{
    /// <summary>Parses a generated quantity.</summary>
    TQuantity Parse(string text, IFormatProvider? formatProvider);

    /// <summary>Attempts to parse a generated quantity.</summary>
    bool TryParse(string? text, IFormatProvider? formatProvider, out TQuantity quantity);
}
