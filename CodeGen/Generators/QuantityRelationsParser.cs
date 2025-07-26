﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeGen.Exceptions;
using CodeGen.JsonTypes;
using Newtonsoft.Json;

namespace CodeGen.Generators
{
    /// <summary>
    ///     Parses the JSON file that defines the relationships (operators) between quantities
    ///     and applies them to the parsed quantity objects.
    /// </summary>
    internal static class QuantityRelationsParser
    {
        /// <summary>
        ///     Parse and apply relations to quantities.
        ///
        ///     The relations are defined in UnitRelations.json
        ///     Each defined relation can be applied multiple times to one or two quantities depending on the operator and the operands.
        ///
        ///     The format of a relation definition is "Quantity.Unit operator Quantity.Unit = Quantity.Unit" (See examples below).
        ///     "double" can be used as a unitless operand.
        ///     "1" can be used as the result operand to define inverse relations.
        ///
        ///     Division relations are inferred from multiplication relations,
        ///     but this can be skipped if the string ends with "NoInferredDivision".
        /// </summary>
        /// <example>
        /// [
        ///   "double = Length.Meter * ReciprocalLength.InverseMeter -- Inverse"
        ///   "Power.Watt = ElectricPotential.Volt * ElectricCurrent.Ampere",
        ///   "Mass.Kilogram = MassConcentration.KilogramPerCubicMeter * Volume.CubicMeter -- NoInferredDivision",
        /// ]
        /// </example>
        /// <param name="rootDir">Repository root directory.</param>
        /// <param name="quantities">List of previously parsed Quantity objects.</param>
        public static void ParseAndApplyRelations(string rootDir, Quantity[] quantities)
        {
            var quantityDictionary = quantities.ToDictionary(q => q.Name, q => q);

            // Add double and 1 as pseudo-quantities to validate relations that use them.
            var pseudoQuantity = new Quantity { Name = null!, Units = [new Unit { SingularName = null! }] };
            quantityDictionary["double"] = pseudoQuantity with { Name = "double" };

            var relations = ParseRelations(rootDir, quantityDictionary);

            // Because multiplication is commutative, we can infer the other operand order.
            relations.AddRange(relations
                .Where(r => r.Operator is "*" && r.LeftQuantity != r.RightQuantity)
                .Select(r => r with
                {
                    LeftQuantity = r.RightQuantity,
                    LeftUnit = r.RightUnit,
                    RightQuantity = r.LeftQuantity,
                    RightUnit = r.LeftUnit,
                    IsDerived = true,
                    // IsInverse is propagated, to also generate Inverse() method for the right hand quantity.
                })
                .ToList());

            // We can infer division relations from multiplication relations.
            relations.AddRange(relations
                .Where(r => r is { Operator: "*", NoInferredDivision: false })
                .Select(r => r with
                {
                    Operator = "/",
                    LeftQuantity = r.ResultQuantity,
                    LeftUnit = r.ResultUnit,
                    ResultQuantity = r.LeftQuantity,
                    ResultUnit = r.LeftUnit,
                    IsDerived = true,
                    IsInverse = false, // Don't propagate for inferred division relations, Inverse() methods should only be generated the left and right hand quantities in the original definition.
                })
                // Skip division between equal quantities because the ratio is already generated as part of the Arithmetic Operators.
                .Where(r => r.LeftQuantity != r.RightQuantity)
                .ToList());

            // Sort all relations to keep generated operators in a consistent order.
            relations.Sort();

            var duplicates = relations
                .GroupBy(r => r.SortString)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicates.Any())
            {
                var list = string.Join("\n  ", duplicates);
                throw new UnitsNetCodeGenException($"Duplicate inferred relations:\n  {list}");
            }

            var ambiguous = relations
                .GroupBy(r => $"{r.LeftQuantity.Name} {r.Operator} {r.RightQuantity.Name}")
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (ambiguous.Any())
            {
                var list = string.Join("\n  ", ambiguous);
                throw new UnitsNetCodeGenException($"Ambiguous inferred relations:\n  {list}\n\nHint: you could use NoInferredDivision in the definition file.");
            }

            foreach (var quantity in quantities)
            {
                var quantityRelations = new List<QuantityRelation>();

                foreach (var relation in relations)
                {
                    if (relation.LeftQuantity == quantity)
                    {
                        // The left operand of a relation is responsible for generating the operator.
                        quantityRelations.Add(relation);
                    }
                    else if (relation.RightQuantity == quantity && relation.LeftQuantity.Name is "double")
                    {
                        // Because we cannot add operators to double we make the right operand responsible in this case.
                        quantityRelations.Add(relation);
                    }
                }

                quantity.Relations = quantityRelations.ToArray();
            }
        }

        private static List<QuantityRelation> ParseRelations(string rootDir, IReadOnlyDictionary<string, Quantity> quantities)
        {
            var relationsFileName = Path.Combine(rootDir, "Common/UnitRelations.json");

            try
            {
                var text = File.ReadAllText(relationsFileName);
                var relationStrings = JsonConvert.DeserializeObject<SortedSet<string>>(text) ?? [];

                var parsedRelations = relationStrings.Select(relationString => ParseRelation(relationString, quantities)).ToList();

                // File parsed successfully, save it back to disk in the sorted state.
                File.WriteAllText(relationsFileName, JsonConvert.SerializeObject(relationStrings, Formatting.Indented));

                return parsedRelations;
            }
            catch (Exception e)
            {
                throw new UnitsNetCodeGenException($"Error parsing relations file: {relationsFileName}", e);
            }
        }

        private static QuantityRelation ParseRelation(string relationString, IReadOnlyDictionary<string, Quantity> quantities)
        {
            var segments = relationString.Split(' ');

            if (segments is not [_, "=", _, "*", _, ..])
            {
                throw new Exception($"Invalid relation string: {relationString}");
            }

            var @operator = segments[3];
            var left = segments[2].Split('.');
            var right = segments[4].Split('.');
            var result = segments[0].Split('.');

            var leftQuantity = GetQuantity(left[0]);
            var rightQuantity = GetQuantity(right[0]);
            var resultQuantity = GetQuantity(result[0]);

            var leftUnit = GetUnit(leftQuantity, left.ElementAtOrDefault(1));
            var rightUnit = GetUnit(rightQuantity, right.ElementAtOrDefault(1));
            var resultUnit = GetUnit(resultQuantity, result.ElementAtOrDefault(1));

            // Configuration segments are the parts after the "--" in the relation string.
            // Example: "double = Length.Meter * ReciprocalLength.InverseMeter -- Inverse" => ["Inverse"]
            var configurationSegments = relationString.Split("--").Last().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return new QuantityRelation
            {
                NoInferredDivision = configurationSegments.Contains("NoInferredDivision"),
                IsInverse = configurationSegments.Contains("Inverse"),
                Operator = @operator,
                LeftQuantity = leftQuantity,
                LeftUnit = leftUnit,
                RightQuantity = rightQuantity,
                RightUnit = rightUnit,
                ResultQuantity = resultQuantity,
                ResultUnit = resultUnit
            };

            Quantity GetQuantity(string quantityName)
            {
                if (!quantities.TryGetValue(quantityName, out var quantity))
                {
                    throw new Exception($"Undefined quantity {quantityName} in relation string: {relationString}");
                }

                return quantity;
            }

            Unit GetUnit(Quantity quantity, string? unitName)
            {
                try
                {
                    return quantity.Units.First(u => u.SingularName == unitName);
                }
                catch (InvalidOperationException)
                {
                    throw new Exception($"Undefined unit {unitName} in relation string: {relationString}");
                }
            }
        }
    }
}
