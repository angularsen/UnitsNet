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
        private UnitToAbbreviationMap UnitToAbbreviationMap { get; } = new UnitToAbbreviationMap();
        private AbbreviationToUnitMap AbbreviationToUnitMap { get; } = new AbbreviationToUnitMap();
        private AbbreviationToUnitMap LowerCaseAbbreviationToUnitMap { get; } = new AbbreviationToUnitMap();

        internal string[] GetAllUnitAbbreviationsForQuantity()
        {
            return UnitToAbbreviationMap.Values.SelectMany((abbreviations) =>
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
            if(!UnitToAbbreviationMap.TryGetValue(unit, out var abbreviations))
                UnitToAbbreviationMap[unit] = abbreviations = new List<string>();

            return abbreviations.Distinct().ToList();
        }

        internal List<int> GetUnitsForAbbreviation(string abbreviation, bool ignoreCase)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();
            var key = ignoreCase ? lowerCaseAbbreviation : abbreviation;
            var map = ignoreCase ? LowerCaseAbbreviationToUnitMap : AbbreviationToUnitMap;

            if(!map.TryGetValue(key, out List<int> units))
                map[key] = units = new List<int>();

            return units.Distinct().ToList();
        }

        internal void Add(int unit, string abbreviation, bool setAsDefault = false)
        {
            var lowerCaseAbbreviation = abbreviation.ToLower();

            if(!UnitToAbbreviationMap.TryGetValue(unit, out var abbreviationsForUnit))
                abbreviationsForUnit = UnitToAbbreviationMap[unit] = new List<string>();

            if(!AbbreviationToUnitMap.TryGetValue(abbreviation, out var unitsForAbbreviation))
                AbbreviationToUnitMap[abbreviation] = unitsForAbbreviation = new List<int>();

            if(!LowerCaseAbbreviationToUnitMap.TryGetValue(lowerCaseAbbreviation, out var unitsForLowerCaseAbbreviation))
                LowerCaseAbbreviationToUnitMap[lowerCaseAbbreviation] = unitsForLowerCaseAbbreviation = new List<int>();

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
