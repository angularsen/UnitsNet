// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

using UnitToStringMap = System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>>;
using StringToUnitMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>;

namespace UnitsNet
{
    /// <summary>
    /// Class to have a full duplex mapping between a unit value and a string represention of this unit value.
    /// Typical strings are an abbreviation, a singular name or a plural name that represent a unit value
    /// </summary>
    internal class UnitValueToStringLookup

    {
        private readonly UnitToStringMap unitToStringMap = new();
        private readonly StringToUnitMap stringToUnitMap = new();
        private readonly StringToUnitMap lowerCaseStringToUnitMap = new();

        internal string[] GetAllUnitStringsForQuantity() =>
            unitToStringMap.Values.SelectMany(str => str).Distinct().ToArray();

        internal List<string> GetStringsForUnit<UnitType>(UnitType unit) where UnitType : Enum =>
            GetStringsForUnit(Convert.ToInt32(unit));

        internal List<string> GetStringsForUnit(int unit)
        {
            if (!unitToStringMap.TryGetValue(unit, out var strings))
                unitToStringMap[unit] = strings = new List<string>();

            return strings.Distinct().ToList();
        }

        internal List<int> GetUnitsForString(string str, bool ignoreCase)
        {
            var lowerCaseString = str.ToLower();
            var key = ignoreCase ? lowerCaseString : str;
            var map = ignoreCase ? lowerCaseStringToUnitMap : stringToUnitMap;

            if (!map.TryGetValue(key, out List<int> units))
                map[key] = units = new List<int>();

            return units.Distinct().ToList();
        }

        internal void Add(int unit, string str, bool setAsDefault = false)
        {
            var lowerCaseString = str.ToLower();

            if (!unitToStringMap.TryGetValue(unit, out var stringsForUnit))
                stringsForUnit = unitToStringMap[unit] = new List<string>();

            if (!stringToUnitMap.TryGetValue(str, out var unitsForString))
                stringToUnitMap[str] = unitsForString = new List<int>();

            if (!lowerCaseStringToUnitMap.TryGetValue(lowerCaseString, out var unitsForLowerCaseAbbreviation))
                lowerCaseStringToUnitMap[lowerCaseString] = unitsForLowerCaseAbbreviation = new List<int>();

            unitsForLowerCaseAbbreviation.Remove(unit);
            unitsForLowerCaseAbbreviation.Add(unit);

            unitsForString.Remove(unit);
            unitsForString.Add(unit);

            stringsForUnit.Remove(str);
            if (setAsDefault)
                stringsForUnit.Insert(0, str);
            else
                stringsForUnit.Add(str);

        }
    }
}
