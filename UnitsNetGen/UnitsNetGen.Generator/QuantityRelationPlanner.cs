// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNetGen.Generator;

internal static class QuantityRelationPlanner
{
    public static IReadOnlyDictionary<string, IReadOnlyList<EmittedQuantityRelation>> Plan(
        IReadOnlyList<QuantitySelection> selections,
        IReadOnlyList<QuantityRelation> relations,
        out IReadOnlyList<string> errors)
    {
        var planned = new Dictionary<string, List<EmittedQuantityRelation>>(StringComparer.Ordinal);
        var planningErrors = new List<string>();

        foreach (IGrouping<string, QuantitySelection> namespaceGroup in selections.GroupBy(
                     selection => selection.Definition.TargetNamespace,
                     StringComparer.Ordinal))
        {
            Dictionary<string, QuantitySelection> quantities = namespaceGroup.ToDictionary(
                selection => selection.Definition.Name,
                StringComparer.Ordinal);
            var applicable = new List<EmittedQuantityRelation>();
            foreach (QuantityRelation relation in relations)
            {
                if (!TryResolve(relation.Left, quantities, out QuantitySelection? left, out UnitDefinition? leftUnit) ||
                    !TryResolve(relation.Right, quantities, out QuantitySelection? right, out UnitDefinition? rightUnit))
                {
                    continue;
                }

                QuantitySelection? result = null;
                UnitDefinition? resultUnit = null;
                if (relation.Result.Quantity != "1" &&
                    !TryResolve(relation.Result, quantities, out result, out resultUnit))
                {
                    continue;
                }

                if (relation.Result.Quantity == "double" ||
                    relation.Left.Quantity == "double" ||
                    relation.Right.Quantity == "double")
                {
                    continue;
                }

                applicable.Add(new EmittedQuantityRelation(
                    relation.Operator,
                    result,
                    resultUnit,
                    left!,
                    leftUnit!,
                    right!,
                    rightUnit!,
                    relation.Source));
            }

            foreach (IGrouping<string, EmittedQuantityRelation> duplicate in applicable.GroupBy(
                         relation => relation.Key,
                         StringComparer.Ordinal))
            {
                if (duplicate.Count() > 1)
                {
                    planningErrors.Add(
                        $"Duplicate relation '{duplicate.Key}' in namespace '{namespaceGroup.Key}'.");
                }
            }

            foreach (IGrouping<string, EmittedQuantityRelation> ambiguous in applicable.GroupBy(
                         relation => relation.Left.Definition.Name + " " + relation.Operator + " " + relation.Right.Definition.Name,
                         StringComparer.Ordinal))
            {
                if (ambiguous.Select(relation => relation.Key).Distinct(StringComparer.Ordinal).Count() > 1)
                {
                    planningErrors.Add(
                        $"Ambiguous relation '{ambiguous.Key}' in namespace '{namespaceGroup.Key}'.");
                }
            }

            foreach (EmittedQuantityRelation relation in applicable
                         .GroupBy(item => item.Key, StringComparer.Ordinal)
                         .Select(group => group.First())
                         .OrderBy(item => item.Key, StringComparer.Ordinal))
            {
                string ownerKey = namespaceGroup.Key + "." + relation.Left.Definition.Name;
                if (!planned.TryGetValue(ownerKey, out List<EmittedQuantityRelation>? ownedRelations))
                {
                    ownedRelations = new List<EmittedQuantityRelation>();
                    planned.Add(ownerKey, ownedRelations);
                }

                ownedRelations.Add(relation);
            }
        }

        errors = planningErrors;
        return planned.ToDictionary(
            item => item.Key,
            item => (IReadOnlyList<EmittedQuantityRelation>)item.Value,
            StringComparer.Ordinal);
    }

    private static bool TryResolve(
        RelationEndpoint endpoint,
        IReadOnlyDictionary<string, QuantitySelection> quantities,
        out QuantitySelection? selection,
        out UnitDefinition? unit)
    {
        selection = null;
        unit = null;
        if (endpoint.Quantity is "1" or "double")
        {
            return true;
        }

        if (!quantities.TryGetValue(endpoint.Quantity, out selection))
        {
            return false;
        }

        unit = selection.Units.FirstOrDefault(candidate => candidate.SingularName == endpoint.Unit);
        return unit is not null;
    }
}
