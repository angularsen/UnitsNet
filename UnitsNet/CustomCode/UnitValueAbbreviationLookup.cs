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
        private readonly UnitToAbbreviationMap unitToAbbreviationMap = new UnitToAbbreviationMap();
        private readonly AbbreviationToUnitMap abbreviationToUnitMap = new AbbreviationToUnitMap();
        private readonly AbbreviationToUnitMap lowerCaseAbbreviationToUnitMap = new AbbreviationToUnitMap();

        internal string[] GetAllUnitAbbreviationsForQuantity()
        {
            return unitToAbbreviationMap.Values.SelectMany((abbreviations) =>
            {
                return abbreviations;
            } ).Distinct().ToArray();
        }

        internal List<string> GetAbbreviationsForUnit<UnitType>(UnitType unit) where UnitType : Enum
        {
            return GetAbbreviationsForUnit(Convert.ToInt32(unit));
        }

        internal List<string> GetAbbreviationsForUnit(int unit)
        {
            if(!unitToAbbreviationMap.TryGetValue(unit, out var abbreviations))
                unitToAbbreviationMap[unit] = abbreviations = new List<string>();

            return abbreviations.Distinct().ToList();
        }

        internal List<int> GetUnitsForAbbreviation(string abbreviation, bool ignoreCase)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();
            var key = ignoreCase ? lowerCaseAbbreviation : abbreviation;
            var map = ignoreCase ? lowerCaseAbbreviationToUnitMap : abbreviationToUnitMap;

            if(!map.TryGetValue(key, out List<int> units))
                map[key] = units = new List<int>();

            return units.Distinct().ToList();
        }

        internal void Add(int unit, string abbreviation, bool setAsDefault = false)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();

            if(!unitToAbbreviationMap.TryGetValue(unit, out var abbreviationsForUnit))
                abbreviationsForUnit = unitToAbbreviationMap[unit] = new List<string>();

            if(!abbreviationToUnitMap.TryGetValue(abbreviation, out var unitsForAbbreviation))
                abbreviationToUnitMap[abbreviation] = unitsForAbbreviation = new List<int>();

            if(!lowerCaseAbbreviationToUnitMap.TryGetValue(lowerCaseAbbreviation, out var unitsForLowerCaseAbbreviation))
                lowerCaseAbbreviationToUnitMap[lowerCaseAbbreviation] = unitsForLowerCaseAbbreviation = new List<int>();

            unitsForLowerCaseAbbreviation.Remove(unit);
            unitsForLowerCaseAbbreviation.Add(unit);

            unitsForAbbreviation.Remove(unit);
            unitsForAbbreviation.Add(unit);

            abbreviationsForUnit.Remove(abbreviation);
            if (setAsDefault)
                abbreviationsForUnit.Insert(0, abbreviation);
            else
                abbreviationsForUnit.Add(abbreviation);

        }
    }
}
