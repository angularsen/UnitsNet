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
        var bySemanticId = selections.ToDictionary(
            selection => selection.Definition.SemanticId,
            StringComparer.Ordinal);
        IReadOnlyDictionary<string, QuantitySelection[]> byName = selections
            .GroupBy(selection => selection.Definition.Name, StringComparer.Ordinal)
            .ToDictionary(group => group.Key, group => group.ToArray(), StringComparer.Ordinal);
        var applicable = new List<EmittedQuantityRelation>();
        var planningErrors = new List<string>();

        foreach (QuantityRelation relation in relations)
        {
            bool hasLeft = TryResolve(
                relation.Left,
                bySemanticId,
                byName,
                out QuantitySelection? left,
                out UnitDefinition? leftUnit,
                out string? leftError);
            bool hasRight = TryResolve(
                relation.Right,
                bySemanticId,
                byName,
                out QuantitySelection? right,
                out UnitDefinition? rightUnit,
                out string? rightError);
            if (!hasLeft || !hasRight)
            {
                AddError(planningErrors, relation, leftError ?? rightError);
                continue;
            }

            QuantitySelection? result = null;
            UnitDefinition? resultUnit = null;
            if (relation.Result.Quantity != "1" &&
                !TryResolve(
                    relation.Result,
                    bySemanticId,
                    byName,
                    out result,
                    out resultUnit,
                    out string? resultError))
            {
                AddError(planningErrors, relation, resultError);
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

        var rejectedKeys = new HashSet<string>(StringComparer.Ordinal);
        foreach (IGrouping<string, EmittedQuantityRelation> duplicate in applicable.GroupBy(
                     relation => relation.Key,
                     StringComparer.Ordinal))
        {
            if (duplicate.Count() > 1)
            {
                planningErrors.Add($"Duplicate relation '{duplicate.Key}'.");
            }
        }

        foreach (IGrouping<string, EmittedQuantityRelation> ambiguous in applicable.GroupBy(
                     OperatorSignature,
                     StringComparer.Ordinal))
        {
            if (ambiguous.Select(relation => relation.Key).Distinct(StringComparer.Ordinal).Count() > 1)
            {
                planningErrors.Add($"Ambiguous relation operator '{ambiguous.Key}'.");
                rejectedKeys.UnionWith(ambiguous.Select(relation => relation.Key));
            }
        }

        foreach (IGrouping<string, EmittedQuantityRelation> inverseMembers in applicable
                     .Where(relation => relation.Operator == "inverse")
                     .GroupBy(relation => relation.Left.Definition.SemanticId, StringComparer.Ordinal))
        {
            if (inverseMembers.Select(relation => relation.Right.Definition.SemanticId)
                .Distinct(StringComparer.Ordinal)
                .Count() > 1)
            {
                planningErrors.Add(
                    $"Quantity '{inverseMembers.Key}' has more than one relation that would generate Inverse().");
                rejectedKeys.UnionWith(inverseMembers.Select(relation => relation.Key));
            }
        }

        var planned = new Dictionary<string, List<EmittedQuantityRelation>>(StringComparer.Ordinal);
        foreach (EmittedQuantityRelation relation in applicable
                     .Where(relation => !rejectedKeys.Contains(relation.Key))
                     .GroupBy(relation => relation.Key, StringComparer.Ordinal)
                     .Select(group => group.First())
                     .OrderBy(relation => relation.Key, StringComparer.Ordinal))
        {
            string ownerKey = TargetKey(relation.Left.Definition);
            if (!planned.TryGetValue(ownerKey, out List<EmittedQuantityRelation>? ownedRelations))
            {
                ownedRelations = new List<EmittedQuantityRelation>();
                planned.Add(ownerKey, ownedRelations);
            }

            ownedRelations.Add(relation);
        }

        errors = planningErrors;
        return planned.ToDictionary(
            item => item.Key,
            item => (IReadOnlyList<EmittedQuantityRelation>)item.Value,
            StringComparer.Ordinal);
    }

    private static bool TryResolve(
        RelationEndpoint endpoint,
        IReadOnlyDictionary<string, QuantitySelection> bySemanticId,
        IReadOnlyDictionary<string, QuantitySelection[]> byName,
        out QuantitySelection? selection,
        out UnitDefinition? unit,
        out string? error)
    {
        selection = null;
        unit = null;
        error = null;
        if (endpoint.Quantity is "1" or "double")
        {
            return true;
        }

        if (endpoint.Quantity.Contains('.'))
        {
            if (!bySemanticId.TryGetValue(endpoint.Quantity, out selection))
            {
                return false;
            }
        }
        else
        {
            if (!byName.TryGetValue(endpoint.Quantity, out QuantitySelection[]? matches))
            {
                return false;
            }

            if (matches.Length != 1)
            {
                error = $"Quantity name '{endpoint.Quantity}' is ambiguous; use its semantic ID.";
                return false;
            }

            selection = matches[0];
        }

        unit = selection.Definition.Units.FirstOrDefault(candidate => candidate.SingularName == endpoint.Unit);
        if (unit is null)
        {
            error = $"Quantity '{selection.Definition.SemanticId}' has no relation unit '{endpoint.Unit}'.";
            return false;
        }

        return true;
    }

    private static void AddError(
        ICollection<string> errors,
        QuantityRelation relation,
        string? error)
    {
        if (error is not null)
        {
            errors.Add($"Relation '{relation.Source}' is invalid: {error}");
        }
    }

    private static string OperatorSignature(EmittedQuantityRelation relation) =>
        relation.Left.Definition.SemanticId + " " + relation.Operator + " " +
        relation.Right.Definition.SemanticId;

    private static string TargetKey(QuantityDefinition definition) =>
        definition.TargetNamespace + "." + definition.Name;
}
