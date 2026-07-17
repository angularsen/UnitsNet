// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Metadata supplied by generated code to shared quantity operations.</summary>
public interface IQuantityMetadata<TUnit>
    where TUnit : struct, Enum
{
    string Name { get; }

    TUnit BaseUnit { get; }

    IReadOnlyList<UnitInfo<TUnit>> Units { get; }

    double ToBase(double value, TUnit unit);

    double FromBase(double value, TUnit unit);
}
