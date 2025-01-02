// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Helpers.PrefixBuilder;

/// <summary>
///     Provides functionality for building the prefixed units of a <see cref="Quantity" />.
/// </summary>
/// <remarks>
///     This class is responsible for generating prefixed units by applying defined prefixes to existing units.
///     It utilizes the <see cref="BaseUnitPrefixes" /> to handle prefix configurations and conversions.
/// </remarks>
internal class UnitPrefixBuilder
{
    private readonly BaseUnitPrefixes _prefixes;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitPrefixBuilder" /> class with the specified base unit prefixes.
    /// </summary>
    /// <param name="prefixes">
    ///     The <see cref="BaseUnitPrefixes" /> instance containing the base unit prefixes to be used.
    ///     This parameter must not be <c>null</c>.
    /// </param>
    public UnitPrefixBuilder(BaseUnitPrefixes prefixes)
    {
        _prefixes = prefixes;
    }

    /// <summary>
    ///     Generates a list of prefixed units for the specified <see cref="Quantity" /> by applying all defined prefixes
    ///     to its existing units.
    /// </summary>
    /// <param name="quantity">
    ///     The <see cref="Quantity" /> for which prefixed units will be generated. This parameter must not be <c>null</c>.
    /// </param>
    /// <returns>
    ///     A list of newly created <see cref="Unit" /> objects that represent the prefixed units.
    /// </returns>
    /// <exception cref="System.Exception">
    ///     Thrown when an error occurs while processing a prefix for a unit, such as an invalid prefix or unit configuration.
    /// </exception>
    /// <remarks>
    ///     This method iterates through the existing units of the specified <see cref="Quantity" /> and applies each defined
    ///     prefix to generate new prefixed units. It ensures that the singular and plural names, conversion functions,
    ///     localization, and other properties are appropriately updated for the newly created units.
    /// </remarks>
    public List<Unit> GeneratePrefixUnits(Quantity quantity)
    {
        var unitsToAdd = new List<Unit>();
        foreach (Unit unit in quantity.Units)
        foreach (Prefix prefix in unit.Prefixes)
        {
            try
            {
                PrefixInfo prefixInfo = PrefixInfo.Entries[prefix];

                unitsToAdd.Add(new Unit
                {
                    SingularName = $"{prefix}{unit.SingularName.ToCamelCase()}", // "Kilo" + "NewtonPerMeter" => "KilonewtonPerMeter"
                    PluralName = $"{prefix}{unit.PluralName.ToCamelCase()}", // "Kilo" + "NewtonsPerMeter" => "KilonewtonsPerMeter"
                    BaseUnits = GetPrefixedBaseUnits(quantity.BaseDimensions, unit.BaseUnits, prefixInfo),
                    FromBaseToUnitFunc = $"({unit.FromBaseToUnitFunc}) / {prefixInfo.Factor}",
                    FromUnitToBaseFunc = $"({unit.FromUnitToBaseFunc}) * {prefixInfo.Factor}",
                    Localization = GetLocalizationForPrefixUnit(unit.Localization, prefixInfo),
                    ObsoleteText = unit.ObsoleteText,
                    SkipConversionGeneration = unit.SkipConversionGeneration,
                    AllowAbbreviationLookup = unit.AllowAbbreviationLookup
                });
            }
            catch (Exception e)
            {
                throw new Exception($"Error parsing prefix {prefix} for unit {quantity.Name}.{unit.SingularName}.", e);
            }
        }

        return unitsToAdd;
    }

    /// <summary>
    ///     Applies a metric prefix to the specified base units based on the given dimensions and prefix information.
    /// </summary>
    /// <param name="dimensions">
    ///     The SI base unit dimensions of the quantity, such as L=1 for Length or T=-1 for Speed.
    /// </param>
    /// <param name="baseUnits">
    ///     The SI base units for a non-prefixed unit, for example, L=Meter for Length.Meter or L=Meter, T=Second for
    ///     Speed.MeterPerSecond.
    /// </param>
    /// <param name="prefixInfo">
    ///     The information about the metric prefix to apply, including its factor and symbol.
    /// </param>
    /// <returns>
    ///     A new instance of <paramref name="baseUnits" /> with the metric prefix applied, or <c>null</c> if no matching
    ///     prefixed base units could be determined.
    ///     Note that even if <paramref name="baseUnits" /> is not <c>null</c>, the result may still be <c>null</c> if no valid
    ///     prefixed base units are found.
    /// </returns>
    /// <remarks>
    ///     The algorithm attempts to find matching prefixed base units by iterating through the non-zero dimension exponents
    ///     of the provided <paramref name="dimensions" />. The exponents are processed in ascending order of their absolute
    ///     values, with positive exponents being prioritized over negative ones. This approach improves the likelihood of
    ///     finding a
    ///     match that does not deviate too much from the desired prefix.
    /// </remarks>
    /// <example>
    ///     <para>Examples of determining base units of prefix units:</para>
    ///     <list type="bullet">
    ///         <item>
    ///             <term>Example 1 - Pressure.Micropascal</term>
    ///             <description>
    ///                 <para>
    ///                     This highlights how UnitsNet chose Gram as the conversion base unit, while SI defines Kilogram as
    ///                     the base mass unit.
    ///                 </para>
    ///                 <code>
    ///                     Requested prefix: Micro (scale -6) for pressure unit Pascal
    ///                     SI base units of Pascal: L=Meter, M=Kilogram, T=Second
    ///                     SI base dimensions, ordered: M=1, L=-1, T=-2
    ///                     Trying first dimension M=1:
    ///                         SI base mass unit is Kilogram, but UnitsNet base mass unit is Gram so base prefix scale is 3
    ///                         Inferred prefix is Milli: base prefix scale 3 + requested prefix scale (-6) = -3
    ///                         ✅ Resulting base units: M=Milligram plus the original L=Meter, T=Second
    ///                 </code>
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Example 2 - Pressure.Millipascal</term>
    ///             <description>
    ///                 <para>
    ///                     Similar to example 1, but this time Length is used instead of Mass due to the base unit scale
    ///                     factor of mass canceling out the requested prefix.
    ///                 </para>
    ///                 <code>
    ///                     Requested prefix: Milli (scale -3) for pressure unit Pascal
    ///                     SI base units of Pascal: L=Meter, M=Kilogram, T=Second
    ///                     SI base dimensions, ordered: M=1, L=-1, T=-2
    ///                     Trying first dimension M=1:
    ///                         SI base unit in mass dimension is Kilogram, but configured base unit is Gram so base prefix scale is 3
    ///                         ❌ No inferred prefix: base prefix scale 3 + requested prefix scale (-3) = 0
    ///                     Trying second dimension L=-1:
    ///                         SI base unit in length dimension is Meter, same as configured base unit, so base prefix scale is 0
    ///                         Inferred prefix is Milli: base prefix scale 0 + requested prefix scale (-3) = -3
    ///                         ✅ Resulting base units: M=Millimeter plus the original M=Kilogram, T=Second
    ///                 </code>
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>Example 3 - ElectricApparentPower.Kilovoltampere</term>
    ///             <description>
    ///                 <para>
    ///                     This example demonstrates cases where determining the base units for certain prefixes is not
    ///                     possible or trivial.
    ///                 </para>
    ///                 <code>
    ///                     Requested prefix: Kilo (scale 3) for unit Voltampere
    ///                     SI base units of Voltampere: L=Meter, M=Kilogram, T=Second
    ///                     SI base dimensions, ordered: M=1, L=2, T=-3
    ///                     Trying first dimension M=1:
    ///                         SI base unit in mass dimension is Kilogram, same as configured base unit, so base prefix scale is 0
    ///                         Inferred prefix is Kilo: base prefix scale 0 + requested prefix scale (3) = 3
    ///                         ❌ Kilo prefix for Kilogram unit would be Megagram, but there is no unit Megagram, since Gram does not have this prefix (we could add it)
    ///                     Trying second dimension L=2:
    ///                         ❌ There is no metric prefix we can raise to the power of 2 and get Kilo, e.g., Deca*Deca = Hecto, Kilo*Kilo = Mega, etc.
    ///                     Trying third dimension T=-3:
    ///                         SI base unit in time dimension is Second, same as configured base unit, so base prefix scale is 0
    ///                         Inferred prefix is Deci: (base prefix scale 0 + requested prefix scale (-3)) / exponent -3 = -3 / -3 = 1
    ///                         ❌ There is no Duration unit Decasecond (we could add it)
    ///                 </code>
    ///             </description>
    ///         </item>
    ///     </list>
    /// </example>
    private BaseUnits? GetPrefixedBaseUnits(BaseDimensions dimensions, BaseUnits? baseUnits, PrefixInfo prefixInfo)
    {
        if (baseUnits is null) return null;

        // Iterate the non-zero dimension exponents in absolute-increasing order, positive first [1, -1, 2, -2...n, -n]
        foreach (var degree in dimensions.GetNonZeroExponents().OrderBy(int.Abs).ThenByDescending(x => x))
        {
            if (TryPrefixWithExponent(dimensions, baseUnits, prefixInfo.Prefix, degree, out BaseUnits? prefixedUnits))
            {
                return prefixedUnits;
            }
        }

        return null;
    }

    /// <summary>
    ///     Attempts to apply a specified prefix to a base unit based on a given exponent.
    /// </summary>
    /// <param name="dimensions">
    ///     The base dimensions containing the exponents for each dimension (e.g., length, mass, time).
    /// </param>
    /// <param name="baseUnits">
    ///     The base units to which the prefix will be applied.
    /// </param>
    /// <param name="prefix">
    ///     The prefix to be applied (e.g., Kilo, Milli, Micro).
    /// </param>
    /// <param name="exponent">
    ///     The exponent of the dimension to which the prefix should be applied.
    /// </param>
    /// <param name="prefixedBaseUnits">
    ///     When this method returns, contains the prefixed base units if the operation was successful; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the prefix was successfully applied to the base unit; otherwise, <c>false</c>.
    /// </returns>
    private bool TryPrefixWithExponent(BaseDimensions dimensions, BaseUnits baseUnits, Prefix prefix, int exponent,
        [NotNullWhen(true)] out BaseUnits? prefixedBaseUnits)
    {
        prefixedBaseUnits = baseUnits.Clone();

        // look for a dimension that is part of the non-zero exponents
        if (baseUnits.N is { } baseAmountUnit && dimensions.N == exponent)
        {
            if (TryPrefixUnit(baseAmountUnit, exponent, prefix, out var newAmount))
            {
                prefixedBaseUnits.N = newAmount;
                return true;
            }
        }

        if (baseUnits.I is { } baseCurrentUnit && dimensions.I == exponent)
        {
            if (TryPrefixUnit(baseCurrentUnit, exponent, prefix, out var newCurrent))
            {
                prefixedBaseUnits.I = newCurrent;
                return true;
            }
        }

        if (baseUnits.L is { } baseLengthUnit && dimensions.L == exponent)
        {
            if (TryPrefixUnit(baseLengthUnit, exponent, prefix, out var newLength))
            {
                prefixedBaseUnits.L = newLength;
                return true;
            }
        }

        if (baseUnits.J is { } baseLuminosityUnit && dimensions.J == exponent)
        {
            if (TryPrefixUnit(baseLuminosityUnit, exponent, prefix, out var newLuminosity))
            {
                prefixedBaseUnits.J = newLuminosity;
                return true;
            }
        }

        if (baseUnits.M is { } baseMassUnit && dimensions.M == exponent)
        {
            if (TryPrefixUnit(baseMassUnit, exponent, prefix, out var newMass))
            {
                prefixedBaseUnits.M = newMass;
                return true;
            }
        }

        if (baseUnits.Θ is { } baseTemperatureUnit && dimensions.Θ == exponent)
        {
            if (TryPrefixUnit(baseTemperatureUnit, exponent, prefix, out var newTemperature))
            {
                prefixedBaseUnits.Θ = newTemperature;
                return true;
            }
        }

        if (baseUnits.T is { } baseDurationUnit && dimensions.T == exponent)
        {
            if (TryPrefixUnit(baseDurationUnit, exponent, prefix, out var newTime))
            {
                prefixedBaseUnits.T = newTime;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Attempts to apply a specified prefix to a unit name based on the given exponent and prefix.
    /// </summary>
    /// <param name="unitName">The name of the unit to which the prefix should be applied.</param>
    /// <param name="exponent">The exponent associated with the unit, used to determine compatibility with the prefix.</param>
    /// <param name="prefix">The <see cref="Prefix" /> to be applied to the unit.</param>
    /// <param name="prefixedUnitName">
    ///     When this method returns, contains the prefixed unit name if the operation was successful; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if a matching prefix was found; otherwise, <c>false</c>.
    /// </returns>
    private bool TryPrefixUnit(string unitName, int exponent, Prefix prefix, [NotNullWhen(true)] out string? prefixedUnitName)
    {
        if (_prefixes.TryGetMatchingPrefix(unitName, exponent, prefix, out BaseUnitPrefix unitPrefix) &&
            _prefixes.TryGetPrefixForUnit(unitPrefix, out prefixedUnitName))
        {
            return true;
        }

        prefixedUnitName = null;
        return false;
    }

    /// <summary>
    ///     Create unit abbreviations for a prefix unit, given a unit and the prefix.
    ///     The unit abbreviations are either prefixed with the SI prefix or an explicitly configured abbreviation via
    ///     <see cref="Localization.AbbreviationsForPrefixes" />.
    /// </summary>
    private static Localization[] GetLocalizationForPrefixUnit(IEnumerable<Localization> localizations, PrefixInfo prefixInfo)
    {
        return localizations.Select(loc =>
        {
            if (loc.TryGetAbbreviationsForPrefix(prefixInfo.Prefix, out var unitAbbreviationsForPrefix))
            {
                return new Localization { Culture = loc.Culture, Abbreviations = unitAbbreviationsForPrefix };
            }

            // No prefix unit abbreviations are specified, so fall back to prepending the default SI prefix to each unit abbreviation:
            // kilo ("k") + meter ("m") => kilometer ("km")
            var prefix = prefixInfo.GetPrefixForCultureOrSiPrefix(loc.Culture);
            unitAbbreviationsForPrefix = loc.Abbreviations.Select(unitAbbreviation => $"{prefix}{unitAbbreviation}").ToArray();

            return new Localization { Culture = loc.Culture, Abbreviations = unitAbbreviationsForPrefix };
        }).ToArray();
    }
}
