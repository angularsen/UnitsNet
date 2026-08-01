// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet;

/// <summary>
/// An immutable caller-owned policy for selecting quantity units from constituent base units.
/// </summary>
public sealed record UnitSystem
{
    /// <summary>Creates a unit system from an explicit base-unit selection.</summary>
    public UnitSystem(BaseUnits baseUnits)
    {
        ArgumentNullException.ThrowIfNull(baseUnits);
        if (baseUnits.IsUndefined)
        {
            throw new ArgumentException("A unit system must define at least one base unit.", nameof(baseUnits));
        }

        BaseUnits = baseUnits;
    }

    /// <summary>Gets the unit system's selected base units.</summary>
    public BaseUnits BaseUnits { get; }

    /// <summary>Gets the International System of Units base-unit policy.</summary>
    public static UnitSystem SI { get; } = new(
        new BaseUnits(
            length: "Meter",
            mass: "Kilogram",
            time: "Second",
            current: "Ampere",
            temperature: "Kelvin",
            amount: "Mole",
            luminousIntensity: "Candela"));
}
