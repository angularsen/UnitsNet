// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

using UnitToAbbreviationMap = System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>>;
using AbbreviationToUnitMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>;

namespace UnitsNet
{
    internal class UnitValueAbbreviationLookup
    {
        private readonly UnitToAbbreviationMap _unitToAbbreviationMap = new();
        private readonly AbbreviationToUnitMap _abbreviationToUnitMap = new();
        private readonly AbbreviationToUnitMap _lowerCaseAbbreviationToUnitMap = new();

        internal string[] GetAllUnitAbbreviationsForQuantity()
        {
            return _unitToAbbreviationMap.Values.SelectMany(abbreviations => abbreviations).Distinct().ToArray();
        }

        internal List<string> GetAbbreviationsForUnit<TUnitType>(TUnitType unit) where TUnitType : Enum
        {
            return GetAbbreviationsForUnit(Convert.ToInt32(unit));
        }

        internal List<string> GetAbbreviationsForUnit(int unit)
        {
            if (!_unitToAbbreviationMap.TryGetValue(unit, out var abbreviations))
                _unitToAbbreviationMap[unit] = abbreviations = new List<string>();

            return abbreviations.Distinct().ToList();
        }

        internal List<int> GetUnitsForAbbreviation(string abbreviation, bool ignoreCase)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();
            var key = ignoreCase ? lowerCaseAbbreviation : abbreviation;
            var map = ignoreCase ? _lowerCaseAbbreviationToUnitMap : _abbreviationToUnitMap;

            if (!map.TryGetValue(key, out List<int> units))
                map[key] = units = new List<int>();

            return units.Distinct().ToList();
        }

        internal void Add(int unit, string abbreviation, bool setAsDefault = false, bool allowAbbreviationLookup = true)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();

            if (!_unitToAbbreviationMap.TryGetValue(unit, out var abbreviationsForUnit))
                abbreviationsForUnit = _unitToAbbreviationMap[unit] = new List<string>();

            if (allowAbbreviationLookup)
            {
                if (!_abbreviationToUnitMap.TryGetValue(abbreviation, out var unitsForAbbreviation))
                    _abbreviationToUnitMap[abbreviation] = unitsForAbbreviation = new List<int>();

                if (!_lowerCaseAbbreviationToUnitMap.TryGetValue(lowerCaseAbbreviation, out var unitsForLowerCaseAbbreviation))
                    _lowerCaseAbbreviationToUnitMap[lowerCaseAbbreviation] = unitsForLowerCaseAbbreviation = new List<int>();

                unitsForLowerCaseAbbreviation.Remove(unit);
                unitsForLowerCaseAbbreviation.Add(unit);

                unitsForAbbreviation.Remove(unit);
                unitsForAbbreviation.Add(unit);
            }

            abbreviationsForUnit.Remove(abbreviation);

            if (setAsDefault)
                abbreviationsForUnit.Insert(0, abbreviation);
            else
                abbreviationsForUnit.Add(abbreviation);
        }
    }
}
