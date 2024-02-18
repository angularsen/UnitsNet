// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     UnitsNet setup of quantities, units, unit abbreviations and conversion functions.<br />
///     <br />
///     For normal use, <see cref="Default" /> is used and can be manipulated to add new units or change default unit
///     abbreviations.<br />
///     Alternatively, a setup instance may be provided for most static methods, such as
///     <see cref="Quantity.Parse(System.Type,string)" /> and
///     <see cref="QuantityFormatter.Format{TUnitType}(UnitsNet.IQuantity{TUnitType},string)" />.
/// </summary>
public sealed class UnitsNetSetup
{
    static UnitsNetSetup()
    {
        var unitConverter = UnitConverter.CreateDefault();
        ICollection<QuantityInfo> quantityInfos = Quantity.ByName.Values;

        Default = new UnitsNetSetup(quantityInfos, unitConverter);
    }

    /// <summary>
    ///     Create a new UnitsNet setup with the given quantities, their units and unit conversion functions between units.
    /// </summary>
    /// <param name="quantityInfos">The quantities and their units to support for unit conversions, Parse() and ToString().</param>
    /// <param name="unitConverter">The unit converter instance.</param>
    public UnitsNetSetup(ICollection<QuantityInfo> quantityInfos, UnitConverter unitConverter)
    {
        var quantityInfoLookup = new QuantityInfoLookup(quantityInfos);
        var unitAbbreviations = new UnitAbbreviationsCache(quantityInfoLookup);

        UnitConverter = unitConverter;
        UnitAbbreviations = unitAbbreviations;
        UnitParser = new UnitParser(unitAbbreviations);
        QuantityParser = new QuantityParser(unitAbbreviations);
        QuantityInfoLookup = quantityInfoLookup;
    }

    /// <summary>
    ///     The global default UnitsNet setup of quantities, units, unit abbreviations and conversion functions.
    ///     This setup is used by default in static Parse and ToString methods of quantities unless a setup instance is
    ///     provided.
    /// </summary>
    /// <remarks>
    ///     Manipulating this instance, such as adding new units or changing default unit abbreviations, will affect most
    ///     usages of UnitsNet in the
    ///     current AppDomain since the typical use is via static members and not providing a setup instance.
    /// </remarks>
    public static UnitsNetSetup Default { get; }

    /// <summary>
    ///     Converts between units of a quantity, such as from meters to centimeters of a given length.
    /// </summary>
    public UnitConverter UnitConverter { get; }

    /// <summary>
    ///     Maps unit enums to unit abbreviation strings for one or more cultures, used by ToString() and Parse() methods of
    ///     quantities.
    /// </summary>
    public UnitAbbreviationsCache UnitAbbreviations { get; }

    /// <summary>
    ///     Parses units from strings, such as <see cref="LengthUnit.Centimeter" /> from "cm".
    /// </summary>
    public UnitParser UnitParser { get; }

    /// <summary>
    ///     Parses quantities from strings, such as parsing <see cref="Mass" /> from "1.2 kg".
    /// </summary>
    internal QuantityParser QuantityParser { get; }

    /// <summary>
    ///     The quantities and units that are loaded.
    /// </summary>
    /// <remarks>
    ///     Access type is <c>internal</c> until this class is matured and ready for external use.
    /// </remarks>
    internal QuantityInfoLookup QuantityInfoLookup { get; }
}
