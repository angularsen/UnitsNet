// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeGen.Exceptions;
using CodeGen.Helpers.PrefixBuilder;
using CodeGen.JsonTypes;
using Newtonsoft.Json;
using static CodeGen.Helpers.PrefixBuilder.BaseUnitPrefixes;

namespace CodeGen.Generators;

/// <summary>
///     Parses JSON files that define quantities and their units.
///     This will later be used to generate source code and can be reused for different targets such as .NET framework,
///     .NET Core, .NET nanoFramework and even other programming languages.
/// </summary>
internal static class QuantityJsonFilesParser
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        // Don't override the C# default assigned values if no value is set in JSON
        NullValueHandling = NullValueHandling.Ignore
    };

    private static readonly string[] BaseQuantityFileNames =
        ["Length", "Mass", "Duration", "ElectricCurrent", "Temperature", "AmountOfSubstance", "LuminousIntensity"];

    /// <summary>
    ///     Parses JSON files that define quantities and their units.
    /// </summary>
    /// <param name="rootDir">Repository root directory, where you cloned the repo to such as "c:\dev\UnitsNet".</param>
    /// <returns>The parsed quantities and their units.</returns>
    public static Quantity[] ParseQuantities(string rootDir)
    {
        var jsonDir = Path.Combine(rootDir, "Common/UnitDefinitions");
        var baseQuantityFiles = BaseQuantityFileNames.Select(baseQuantityName => Path.Combine(jsonDir, baseQuantityName + ".json")).ToArray();

        Quantity[] baseQuantities = ParseQuantities(baseQuantityFiles);
        Quantity[] derivedQuantities = ParseQuantities(Directory.GetFiles(jsonDir, "*.json").Except(baseQuantityFiles));

        return BuildQuantities(baseQuantities, derivedQuantities);
    }

    private static Quantity[] ParseQuantities(IEnumerable<string> jsonFiles)
    {
        return jsonFiles.Select(ParseQuantity).ToArray();
    }

    private static Quantity ParseQuantity(string jsonFileName)
    {
        try
        {
            return JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(jsonFileName), JsonSerializerSettings)
                   ?? throw new UnitsNetCodeGenException($"Unable to parse quantity from JSON file: {jsonFileName}");
        }
        catch (Exception e)
        {
            throw new Exception($"Error parsing quantity JSON file: {jsonFileName}", e);
        }
    }

    /// <summary>
    ///     Combines base quantities and derived quantities into a single collection,
    ///     while generating prefixed units for each quantity.
    /// </summary>
    /// <param name="baseQuantities">
    ///     The array of base quantities, each containing its respective units.
    /// </param>
    /// <param name="derivedQuantities">
    ///     The array of derived quantities, each containing its respective units.
    /// </param>
    /// <returns>
    ///     An ordered array of all quantities, including both base and derived quantities,
    ///     with prefixed units generated and added to their respective unit collections.
    /// </returns>
    /// <remarks>
    ///     This method utilizes the <see cref="UnitPrefixBuilder" /> to generate prefixed units
    ///     for each quantity. The resulting quantities are sorted alphabetically by their names.
    /// </remarks>
    private static Quantity[] BuildQuantities(Quantity[] baseQuantities, Quantity[] derivedQuantities)
    {
        var prefixBuilder = new UnitPrefixBuilder(FromBaseUnits(baseQuantities.SelectMany(x => x.Units)));
        return baseQuantities.Concat(derivedQuantities).Select(quantity =>
        {
            List<Unit> prefixedUnits = prefixBuilder.GeneratePrefixUnits(quantity);
            quantity.Units = quantity.Units.Concat(prefixedUnits).OrderBy(unit => unit.SingularName, StringComparer.OrdinalIgnoreCase).ToArray();
            return quantity;
        }).OrderBy(quantity => quantity.Name, StringComparer.InvariantCultureIgnoreCase).ToArray();
    }
}
