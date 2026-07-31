// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet;
using UnitsNet.Core;

namespace UnitsNet.Modular;

/// <summary>Non-generic metadata and operations for one quantity in a generated module.</summary>
/// <remarks>
/// This type-erased contract supports registry workflows where the concrete generated quantity is
/// not known statically. Strongly typed code should prefer the quantity type and its static
/// <c>Info</c> property.
/// </remarks>
public interface IQuantityDescriptor
{
    /// <summary>Gets the stable semantic quantity identity.</summary>
    QuantityId Id { get; }

    /// <summary>Gets the quantity's source definition name.</summary>
    string Name { get; }

    /// <summary>Gets the generated quantity CLR type.</summary>
    Type QuantityType { get; }

    /// <summary>Gets the generated unit-enum CLR type.</summary>
    Type UnitType { get; }

    /// <summary>Gets the generated base unit name.</summary>
    string BaseUnitName { get; }

    /// <summary>Gets the quantity's SI base dimensions.</summary>
    BaseDimensions BaseDimensions { get; }

    /// <summary>Gets immutable metadata for the selected units.</summary>
    IReadOnlyList<UnitDescriptor> Units { get; }

    /// <summary>Gets the selected unit for an immutable unit-system policy.</summary>
    UnitDescriptor GetUnit(UnitSystem unitSystem);

    /// <summary>Attempts to get the selected unit for an immutable unit-system policy.</summary>
    bool TryGetUnit(UnitSystem? unitSystem, out UnitDescriptor? unit);

    /// <summary>Creates the generated quantity from a numeric value and unit name.</summary>
    IQuantity<double> Create(double value, string unitName);

    /// <summary>Creates the generated quantity using an immutable unit-system policy.</summary>
    IQuantity<double> Create(double value, UnitSystem unitSystem);

    /// <summary>Attempts to create the generated quantity from a numeric value and unit name.</summary>
    bool TryCreate(
        double value,
        string unitName,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Attempts to create the generated quantity using an immutable unit-system policy.</summary>
    bool TryCreate(
        double value,
        UnitSystem? unitSystem,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Converts a numeric value between two selected unit names.</summary>
    double Convert(double value, string fromUnitName, string toUnitName);

    /// <summary>Attempts to convert a numeric value between two selected unit names.</summary>
    bool TryConvert(double value, string fromUnitName, string toUnitName, out double convertedValue);

    /// <summary>Converts a numeric value from a selected unit into an immutable unit system.</summary>
    double Convert(double value, string fromUnitName, UnitSystem unitSystem);

    /// <summary>Attempts to convert a numeric value from a selected unit into an immutable unit system.</summary>
    bool TryConvert(
        double value,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue);

    /// <summary>Parses a generated quantity.</summary>
    IQuantity<double> Parse(string text, IFormatProvider? formatProvider = null);

    /// <summary>Attempts to parse a generated quantity.</summary>
    bool TryParse(
        string? text,
        IFormatProvider? formatProvider,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Gets the stored numeric value from a generated quantity.</summary>
    double GetValue(IQuantity<double> quantity);

    /// <summary>Gets the stored unit name from a generated quantity.</summary>
    string GetUnitName(IQuantity<double> quantity);

    /// <summary>Formats a generated quantity after validating its concrete type.</summary>
    string Format(
        IQuantity<double> quantity,
        string? format = null,
        IFormatProvider? formatProvider = null);
}

/// <summary>Type-erased immutable metadata for one selected unit.</summary>
public sealed record UnitDescriptor(
    string Name,
    int Value,
    string SingularName,
    string PluralName,
    BaseUnits BaseUnits,
    IReadOnlyList<UnitLocalization> Localizations);
