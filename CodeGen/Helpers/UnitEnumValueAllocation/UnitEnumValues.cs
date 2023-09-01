// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CodeGen.Helpers.UnitEnumValueAllocation
{
    /// <summary>
    ///     Data structure to map unit enum names to allocated unit enum values.
    ///     <br/><br/>
    ///     Updating transitive UnitsNet dependency cause wrong unit · Issue #1068 · angularsen/UnitsNet
    ///     https://github.com/angularsen/UnitsNet/issues/1068
    /// </summary>
    internal class UnitEnumNameToValue : Dictionary<string, int>
    {
        private readonly Queue<int> _nextRandomAvailableValues = new();
        private static readonly Random Random = new();

        public int AssignUniqueValue(string unitName)
        {
            UpdateNextAvailableValues();

            var nextValue = _nextRandomAvailableValues.Dequeue();
            this[unitName] = nextValue;

            return nextValue;
        }

        private void UpdateNextAvailableValues()
        {
            if (_nextRandomAvailableValues.Count != 0) return;

            List<int> newAvailableValues = new();

            int candidateValue = 1;

            // Try to fill holes left by previous updates, since we pick a random value from the next 10 available values to
            // avoid conflicts with multiple merged pull requests.
            var orderedValues = Values.ToImmutableSortedSet();
            for (var existingValueIdx = 0; existingValueIdx < orderedValues.Count && newAvailableValues.Count < 10; existingValueIdx++)
            {
                int val = orderedValues[existingValueIdx];

                while (candidateValue < val && newAvailableValues.Count < 10)
                {
                    newAvailableValues.Add(candidateValue);
                    candidateValue++;
                }

                candidateValue++;
            }

            // At this point there are no more holes to fill and candidateValue is greater than the previously max allocated value.
            // If we still need more candidates, pick from the increasing sequence of values until filled.
            while (newAvailableValues.Count < 10)
            {
                newAvailableValues.Add(candidateValue);
                candidateValue++;
            }

            // Randomize the candidates.
            foreach (var availableValue in newAvailableValues.OrderBy(_ => Random.Next()))
            {
                _nextRandomAvailableValues.Enqueue(availableValue);
            }
        }
    }
}
