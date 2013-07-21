// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
using System.Globalization;
using System.Linq;

namespace UnitsNet
{
    public class UnitSystem
    {
        private static readonly Dictionary<CultureInfo, UnitSystem> CultureToInstance;

        #region Static

        /// <summary>
        ///     The culture of which this unit system is based on. Either passed in to constructor or the default culture.
        /// </summary>
        public readonly CultureInfo Culture;

        static UnitSystem()
        {
            CultureToInstance = new Dictionary<CultureInfo, UnitSystem>();
        }

        /// <summary>
        ///     Create a SI system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        private UnitSystem(CultureInfo cultureInfo = null)
        {
            //_cultureInfo = cultureInfo;
            _unitToAbbrevs = new Dictionary<Unit, List<string>>();
            _abbrevsToUnit = new Dictionary<string, Unit>();

            if (cultureInfo == null)
                cultureInfo = new CultureInfo("en-US");

            Culture = cultureInfo;

            if (cultureInfo.Name == "en-US" || Equals(cultureInfo, CultureInfo.InvariantCulture))
                CreateUsEnglish();
            else if (cultureInfo.Name == "nb-NO")
                CreateNorwegianBokmaal();
            else
                throw new ArgumentException("Expected only Norwegian Bokmål, US English and invariant cultures.");
        }

        /// <summary>
        ///     Create a unit system for parsing and presenting numbers, units and abbreviations.
        ///     If null is passed then <see cref="CultureInfo.CurrentUICulture" /> will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static UnitSystem Create(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                cultureInfo = CultureInfo.CurrentUICulture;

            if (!CultureToInstance.ContainsKey(cultureInfo))
                CultureToInstance[cultureInfo] = new UnitSystem(cultureInfo);

            return CultureToInstance[cultureInfo];
        }

        #endregion

        #region Public methods

        public static Unit Parse(string unitAbbreviation, CultureInfo culture)
        {
            return Create(culture).Parse(unitAbbreviation);
        }

        public Unit Parse(string unitAbbreviation)
        {
            Unit result;
            if (_abbrevsToUnit.TryGetValue(unitAbbreviation, out result))
                return result;

            return Unit.Undefined;
        }

        public static string GetDefaultAbbreviation(Unit unit, CultureInfo culture)
        {
            return Create(culture).GetDefaultAbbreviation(unit);
        }

        public string GetDefaultAbbreviation(Unit unit)
        {
            // Return the first (most commonly used) abbreviation for this unit)
            return _unitToAbbrevs[unit].First();
        }

        #endregion

        #region Private helpers

        private void CreateUsEnglish()
        {
            CreateCultureInvariants();

            // Cooking units
            MapUnitToAbbreviation(Unit.Tablespoon, "T", "T.", "tbsp", "tbsp.", "tbs", "tbs.");
            // For units with multiple abbreviations, the first one denotes the most common one
            MapUnitToAbbreviation(Unit.Teaspoon, "tsp", "tsp.", "t", "t.");
            MapUnitToAbbreviation(Unit.Piece, "pcs", "pcs.", "pc", "pc.", "pce", "pce.");
        }

        private void CreateNorwegianBokmaal()
        {
            CreateCultureInvariants();

            // Cooking units
            MapUnitToAbbreviation(Unit.Tablespoon, "ss", "ss.");
            MapUnitToAbbreviation(Unit.Teaspoon, "ts", "ts.");
            MapUnitToAbbreviation(Unit.Piece, "stk", "stk.");
        }

        private void CreateCultureInvariants()
        {
            // For correct abbreviations, see: http://lamar.colostate.edu/~hillger/correct.htm
            // Note: For units with multiple abbreviations, the first one is used in GetDefaultAbbreviation().
            MapUnitToAbbreviation(Unit.Undefined, "(no unit)");

            // Masses
            MapUnitToAbbreviation(Unit.Kilogram, "kg");
            MapUnitToAbbreviation(Unit.Hectogram, "hg");
            MapUnitToAbbreviation(Unit.Gram, "g");
            MapUnitToAbbreviation(Unit.Milligram, "mg");

            // Forces
            MapUnitToAbbreviation(Unit.Kilonewton, "kN");
            MapUnitToAbbreviation(Unit.Newton, "N");

            // Torque
            MapUnitToAbbreviation(Unit.Newtonmeter, "Nm");

            // Distances
            MapUnitToAbbreviation(Unit.Meter, "m");
            MapUnitToAbbreviation(Unit.Centimeter, "cm");
            MapUnitToAbbreviation(Unit.Millimeter, "mm");

            // Volumes
            MapUnitToAbbreviation(Unit.Liter, "l", "L");
            MapUnitToAbbreviation(Unit.Deciliter, "dl", "dL");
            MapUnitToAbbreviation(Unit.Centiliter, "cl", "cL");
            MapUnitToAbbreviation(Unit.Milliliter, "ml", "mL");

            // Other units
            MapUnitToAbbreviation(Unit.Volt, "V");
            MapUnitToAbbreviation(Unit.Percent, "%");
            MapUnitToAbbreviation(Unit.Second, "s");
        }

        private void MapUnitToAbbreviation(Unit unit, params string[] abbreviations)
        {
            if (abbreviations == null)
                throw new ArgumentNullException("abbreviations");

            List<string> existingAbbreviations;
            if (!_unitToAbbrevs.TryGetValue(unit, out existingAbbreviations))
            {
                existingAbbreviations = _unitToAbbrevs[unit] = new List<string>();
            }

            foreach (string abbreviation in abbreviations)
            {
                if (existingAbbreviations.Contains(abbreviation))
                    continue;

                existingAbbreviations.Add(abbreviation);
                _abbrevsToUnit[abbreviation] = unit;
            }
        }

        #endregion

        private readonly Dictionary<string, Unit> _abbrevsToUnit;
        private readonly Dictionary<Unit, List<string>> _unitToAbbrevs;

        public bool TryParse(string unitAbbreviation, out Unit unit)
        {
            return _abbrevsToUnit.TryGetValue(unitAbbreviation, out unit);
        }

        public string[] GetAllAbbreviations(Unit unit)
        {
            return _unitToAbbrevs[unit].ToArray();
        }
    }
}