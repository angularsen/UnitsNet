// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet
{
    internal class UnitToAbbreviationMap : ConcurrentDictionary<int, IReadOnlyList<string>> { }
    internal class AbbreviationToUnitMap : ConcurrentDictionary<string, IReadOnlyList<int>> { }

    internal class UnitValueAbbreviationLookup
    {
        private readonly UnitToAbbreviationMap _unitToAbbreviationMap = new();
        private readonly AbbreviationToUnitMap _abbreviationToUnitMap = new();
        private readonly AbbreviationToUnitMap _lowerCaseAbbreviationToUnitMap = new();
        private Lazy<string[]> _allUnitAbbreviationsLazy;
        private readonly object _syncRoot = new();

        public UnitValueAbbreviationLookup()
        {
            _allUnitAbbreviationsLazy = new Lazy<string[]>(ComputeAllUnitAbbreviationsValue);
        }

        internal IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity()
        {
            return _allUnitAbbreviationsLazy.Value;
        }

        internal IReadOnlyList<string> GetAbbreviationsForUnit<TUnitType>(TUnitType unit) where TUnitType : Enum
        {
            return GetAbbreviationsForUnit(Convert.ToInt32(unit));
        }

        internal IReadOnlyList<string> GetAbbreviationsForUnit(int unit)
        {
            if (!_unitToAbbreviationMap.TryGetValue(unit, out var abbreviations))
                return new List<string>(0);

            return abbreviations.ToList();
        }

        internal IReadOnlyList<int> GetUnitsForAbbreviation(string abbreviation, bool ignoreCase)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();
            var key = ignoreCase ? lowerCaseAbbreviation : abbreviation;
            var map = ignoreCase ? _lowerCaseAbbreviationToUnitMap : _abbreviationToUnitMap;

            if (!map.TryGetValue(key, out IReadOnlyList<int> units))
                return new List<int>(0);

            return units.ToList();
        }

        internal void Add(int unit, string abbreviation, bool setAsDefault = false, bool allowAbbreviationLookup = true)
        {
            // Restrict concurrency on writes.
            // By using ConcurrencyDictionary and immutable IReadOnlyList instances, we don't need to lock on reads.
            lock (_syncRoot)
            {
                var lowerCaseAbbreviation = abbreviation.ToLower();

                if (allowAbbreviationLookup)
                {
                    _abbreviationToUnitMap.AddOrUpdate(abbreviation,
                        addValueFactory: _ => new List<int> { unit },
                        updateValueFactory: (_, existing) => existing.Append(unit).Distinct().ToList());

                    _lowerCaseAbbreviationToUnitMap.AddOrUpdate(lowerCaseAbbreviation,
                        addValueFactory: _ => new List<int> { unit },
                        updateValueFactory: (_, existing) => existing.Append(unit).Distinct().ToList());
                }

                _unitToAbbreviationMap.AddOrUpdate(unit,
                    addValueFactory: _ => new List<string> { abbreviation },
                    updateValueFactory: (_, existing) =>
                    {
                        return setAsDefault
                            ? existing.Where(x => x != abbreviation).Prepend(abbreviation).ToList()
                            : existing.Where(x => x != abbreviation).Append(abbreviation).ToList();
                    });

                _allUnitAbbreviationsLazy = new Lazy<string[]>(ComputeAllUnitAbbreviationsValue);
            }
        }

        private string[] ComputeAllUnitAbbreviationsValue()
        {
            return _unitToAbbreviationMap.Values.SelectMany(abbreviations => abbreviations).Distinct().ToArray();
        }
    }
}
