// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        ///     Each defined relation can be applied multiple times to one or two quantities depending on the operator and the operands.
        ///
        ///     The format of a relation definition is "Quantity.Unit operator Quantity.Unit = Quantity.Unit".
        ///     "double" can be used as a unitless operand.
        ///     "1" can be used as the left operand to define inverse relations.
        /// </summary>
        /// <param name="rootDir">Repository root directory.</param>
        /// <param name="quantities">List of previously parsed Quantity objects.</param>
        public static void ParseAndApplyRelations(string rootDir, Quantity[] quantities)
        {
            var quantityDictionary = quantities.ToDictionary(q => q.Name, q => q);

            // Add double and 1 as pseudo-quantities to validate relations that use them.
            var pseudoQuantity = new Quantity { Name = null!, Units = [new Unit { SingularName = null! }] };
            quantityDictionary["double"] = pseudoQuantity with { Name = "double" };
            quantityDictionary["1"] = pseudoQuantity with { Name = "1" };

            var relations = ParseRelations(rootDir, quantityDictionary);

            // Because multiplication is commutative, we can infer the other operand order.
            relations.AddRange(relations
                .Where(r => r.Operator is "*" or "inverse" && r.LeftQuantity != r.RightQuantity)
                .Select(r => r with
                {
                    LeftQuantity = r.RightQuantity,
                    LeftUnit = r.RightUnit,
                    RightQuantity = r.LeftQuantity,
                    RightUnit = r.LeftUnit,
                })
                .ToList());

            // We can infer TimeSpan relations from Duration relations.
            var timeSpanQuantity = pseudoQuantity with { Name = "TimeSpan" };
            relations.AddRange(relations
                .Where(r => r.LeftQuantity.Name is "Duration")
                .Select(r => r with { LeftQuantity = timeSpanQuantity })
                .ToList());
            relations.AddRange(relations
                .Where(r => r.RightQuantity.Name is "Duration")
                .Select(r => r with { RightQuantity = timeSpanQuantity })
                .ToList());

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
                    else if (relation.RightQuantity == quantity && relation.LeftQuantity.Name is "double" or "TimeSpan")
                    {
                        // Because we cannot add generated operators to double or TimeSpan, we make the right operand responsible in this case.
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
                var relationStrings = JsonConvert.DeserializeObject<List<string>>(text) ?? [];
                relationStrings.Sort();

                var parsedRelations = relationStrings.Select(relationString => ParseRelation(relationString, quantities)).ToList();

                // File parsed successfully, save it back to disk in the sorted state.
                File.WriteAllText(relationsFileName, JsonConvert.SerializeObject(relationStrings, Formatting.Indented));

                return parsedRelations;
            }
            catch (Exception e)
            {
                throw new Exception($"Error parsing relations file: {relationsFileName}", e);
            }
        }

        private static QuantityRelation ParseRelation(string relationString, IReadOnlyDictionary<string, Quantity> quantities)
        {
            var segments = relationString.Split(' ');

            if (segments is not [_, "=", _, "*" or "/", _])
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

            if (leftQuantity.Name == "1")
            {
                @operator = "inverse";
                leftQuantity = resultQuantity;
                leftUnit = resultUnit;
            }

            return new QuantityRelation
            {
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