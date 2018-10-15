// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

using UnitToAbbreviationMap = System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>>;
using AbbreviationToUnitMap = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    internal class UnitValueAbbreviationLookup
    {
        private UnitToAbbreviationMap unitToAbbreviationMap = new UnitToAbbreviationMap();
        private AbbreviationToUnitMap abbreviationToUnitMap = new AbbreviationToUnitMap();

        internal UnitValueAbbreviationLookup()
        {
            unitToAbbreviationMap = new UnitToAbbreviationMap();
            abbreviationToUnitMap = new AbbreviationToUnitMap();
        }

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

        internal List<int> GetUnitsForAbbreviation(string abbreviation)
        {
            if(!abbreviationToUnitMap.TryGetValue(abbreviation, out var units))
                abbreviationToUnitMap[abbreviation] = units = new List<int>();

            return units.Distinct().ToList();
        }

        internal void Add(int unit, string abbreviation)
        {
            if(!unitToAbbreviationMap.TryGetValue(unit, out var abbreviationsForUnit))
                abbreviationsForUnit = unitToAbbreviationMap[unit] = new List<string>();

            if(!abbreviationToUnitMap.TryGetValue(abbreviation, out var unitsForAbbreviation))
                abbreviationToUnitMap[abbreviation] = unitsForAbbreviation = new List<int>();

            abbreviationsForUnit.Add(abbreviation);
            unitsForAbbreviation.Add(unit);
        }
    }
}
