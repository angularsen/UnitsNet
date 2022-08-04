// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using CodeGen.Exceptions;
using CodeGen.JsonTypes;
using Serilog;

namespace CodeGen.Helpers.UnitEnumValueAllocation
{
    /// <summary>
    ///     Allocates unique enum values per quantity and persists the mapping to a JSON file to ensure the values do not
    ///     change when adding new units.
    ///     <br/><br/>
    ///     Updating transitive UnitsNet dependency cause wrong unit · Issue #1068 · angularsen/UnitsNet
    ///     https://github.com/angularsen/UnitsNet/issues/1068
    /// </summary>
    internal class UnitEnumValueAllocator
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip, WriteIndented = true
        };

        private readonly string _jsonFile;
        private readonly QuantityNameToUnitEnumValues _quantityNameToUnitEnumValues;

        /// <summary>
        ///     Creates an instance for the given JSON file path.
        /// </summary>
        /// <param name="jsonFile">Path to the JSON file that describes the currently allocated enum values.</param>
        private UnitEnumValueAllocator(string jsonFile)
        {
            _jsonFile = jsonFile;
            _quantityNameToUnitEnumValues = ReadFromFile(jsonFile);
        }

        /// <summary>
        ///     Ensure that all units have a unique unit enum value per quantity.
        ///     The values are persisted to a JSON file to ensure the values do not change as new units are added later.
        /// </summary>
        /// <remarks>
        ///     If the same value is found for two or more units, then an exception is thrown that effectively breaks the build
        ///     with instructions on how
        ///     to manually resolve the conflict by assigning unique values. This typically happens by merging two pull requests
        ///     that both add units to the same
        ///     quantity, which competes for the next available unit enum value.
        /// </remarks>
        /// <param name="jsonFile">The JSON file for storing the enum value allocations.</param>
        /// <param name="quantities">The list of quantities to ensure have unique unit enum values per quantity.</param>
        /// <returns></returns>
        internal static QuantityNameToUnitEnumValues AllocateNewUnitEnumValues(string jsonFile, Quantity[] quantities)
        {
            var unitEnumValueAllocator = new UnitEnumValueAllocator(jsonFile);

            foreach (Quantity quantity in quantities)
            {
                unitEnumValueAllocator.AllocateNewUnitEnumValues(quantity);
            }

            unitEnumValueAllocator.EnsureUniqueUnitEnumValuesPerQuantity();
            unitEnumValueAllocator.SaveToFile();

            return unitEnumValueAllocator._quantityNameToUnitEnumValues;
        }

        private void EnsureUniqueUnitEnumValuesPerQuantity()
        {
            List<string> duplicateErrorMessages = new();
            foreach ((var quantityName, UnitEnumNameToValue? unitEnumValues) in _quantityNameToUnitEnumValues)
            {
                // Minor optimization for the common case where there are no duplicates, to skip the more heavy LINQ of grouping and filtering.
                if (unitEnumValues.Values.Count != unitEnumValues.Values.ToHashSet().Count)
                {
                    duplicateErrorMessages.AddRange(unitEnumValues
                        .GroupBy(x => x.Value, x => x.Key) // Group unit names on enum value.
                        .Where(g => g.Count() > 1) // More than one unit name is mapped to the same enum value.
                        .Select(unitNames => $"{quantityName} has duplicate unit enum value {unitNames.Key} for units {string.Join(", ", unitNames)}."));
                }
            }

            if (duplicateErrorMessages.Any())
            {
                throw new UnitsNetCodeGenException(
                    @$"One or more units have the same unit enum value. This typically happens when merging multiple pull requests adding units to the same quantity.
Resolve this by manually editing the JSON file to assign unique unit enum values per quantity.

JSON file:
{_jsonFile}

Conflicts:
{string.Join("\n", duplicateErrorMessages)}");
            }
        }

        /// <summary>
        ///     Allocates a unique enum value for all units of the given quantity that don't already have one stored in the JSON
        ///     file.
        /// </summary>
        /// <param name="quantity">The quantity info.</param>
        private void AllocateNewUnitEnumValues(Quantity quantity)
        {
            foreach (Unit unit in quantity.Units)
            {
                EnsureUnitEnumValueIsAllocated(quantity, unit);
            }
        }

        /// <summary>
        ///     Allocates a unique enum value for the given unit, if not already allocated.
        /// </summary>
        /// <param name="quantity">The quantity info.</param>
        /// <param name="unit">The unit info.</param>
        private void EnsureUnitEnumValueIsAllocated(Quantity quantity, Unit unit)
        {
            // Get or create new list of enum values for quantity.
            if (!_quantityNameToUnitEnumValues.TryGetValue(quantity.Name, out UnitEnumNameToValue? enumValues))
            {
                enumValues = _quantityNameToUnitEnumValues[quantity.Name] = new UnitEnumNameToValue();
            }

            // Already allocated enum value for this unit?
            if (enumValues.ContainsKey(unit.SingularName))
            {
                return;
            }

            int value = enumValues.AssignUniqueValue(unit.SingularName);

            Log.Information("Allocated new value {Value} for {Quantity}.{Unit}", value, quantity.Name, unit.SingularName);
        }

        private void SaveToFile()
        {
            var fileContentStringBuilder = new StringBuilder();
            fileContentStringBuilder.Append(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This file is updated by \generate-code.bat and represents the unique unit enum values allocated when adding new units.
//     Do not modify this file manually unless you know what you are doing, as it may cause breaking changes for consumers relying on consistent enum values.
// </auto-generated>
//------------------------------------------------------------------------------
//
// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.
");

            fileContentStringBuilder.AppendLine(JsonSerializer.Serialize(_quantityNameToUnitEnumValues, JsonOptions));
            File.WriteAllText(_jsonFile, fileContentStringBuilder.ToString());
        }

        /// <summary>
        ///     Loads the stored allocations from the JSON file.
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <exception cref="InvalidOperationException">Failed to deserialize.</exception>
        private static QuantityNameToUnitEnumValues ReadFromFile(string jsonFile)
        {
            if (File.Exists(jsonFile))
            {
                return JsonSerializer.Deserialize<QuantityNameToUnitEnumValues>(File.ReadAllText(jsonFile), JsonOptions)
                       ?? throw new InvalidOperationException($"Failed to deserialize file: {jsonFile}");
            }

            return new QuantityNameToUnitEnumValues();
        }
    }
}
