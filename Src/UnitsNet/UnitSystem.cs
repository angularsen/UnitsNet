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
			else if (cultureInfo.Name == "ru-RU")
				CreateRussian();
            else
                throw new ArgumentException("Expected only Russian, Norwegian Bokmål, US English and invariant cultures.");
        }

        /// <summary>
        /// Create a unit system for parsing and presenting numbers, units and abbreviations.
        /// </summary>
        /// <param name="cultureInfo">Culture to use. If null then <see cref="CultureInfo.CurrentUICulture" /> will be used.</param>
        /// <returns></returns>
        public static UnitSystem Create(CultureInfo cultureInfo = null)
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

		private void CreateRussian()
		{
			// Note: For units with multiple abbreviations, the first one is used in GetDefaultAbbreviation().
			MapUnitToAbbreviation(Unit.Undefined, "(нет ед.изм.)");

			// Length
			MapUnitToAbbreviation(Unit.Kilometer, "км");
			MapUnitToAbbreviation(Unit.Meter, "м");
			MapUnitToAbbreviation(Unit.Decimeter, "дм");
			MapUnitToAbbreviation(Unit.Centimeter, "см");
			MapUnitToAbbreviation(Unit.Millimeter, "мм");
			MapUnitToAbbreviation(Unit.Micrometer, "мкм");
			MapUnitToAbbreviation(Unit.Nanometer, "нм");

			// Masses
			MapUnitToAbbreviation(Unit.Megatonne, "Мт");
			MapUnitToAbbreviation(Unit.Kilotonne, "кт");
			MapUnitToAbbreviation(Unit.Tonne, "т");
			MapUnitToAbbreviation(Unit.Kilogram, "кг");
			MapUnitToAbbreviation(Unit.Hectogram, "гг");
			MapUnitToAbbreviation(Unit.Decagram, "даг");
			MapUnitToAbbreviation(Unit.Gram, "г");
			MapUnitToAbbreviation(Unit.Decigram, "дг");
			MapUnitToAbbreviation(Unit.Centigram, "сг");
			MapUnitToAbbreviation(Unit.Milligram, "мг");

			// Pressures
			MapUnitToAbbreviation(Unit.Pascal, "Па");
			MapUnitToAbbreviation(Unit.KiloPascal, "кПа");
			MapUnitToAbbreviation(Unit.MegaPascal, "МПа");
			MapUnitToAbbreviation(Unit.KilogramForcePerSquareCentimeter, "кгс/см²");
			MapUnitToAbbreviation(Unit.Psi, "psi");
			MapUnitToAbbreviation(Unit.NewtonPerSquareCentimeter, "Н/см²");
			MapUnitToAbbreviation(Unit.NewtonPerSquareMillimeter, "Н/мм²");
			MapUnitToAbbreviation(Unit.NewtonPerSquareMeter, "Н/м²");
			MapUnitToAbbreviation(Unit.Bar, "бар");
			MapUnitToAbbreviation(Unit.TechnicalAtmosphere, "ат");
			MapUnitToAbbreviation(Unit.Atmosphere, "атм");
			MapUnitToAbbreviation(Unit.Torr, "торр");

			// Forces
			MapUnitToAbbreviation(Unit.Kilonewton, "кН");
			MapUnitToAbbreviation(Unit.Newton, "Н");
			MapUnitToAbbreviation(Unit.KilogramForce, "кгс");
			MapUnitToAbbreviation(Unit.Dyn, "дин");

			// Area
			MapUnitToAbbreviation(Unit.SquareKilometer, "км²");
			MapUnitToAbbreviation(Unit.SquareMeter, "м²");
			MapUnitToAbbreviation(Unit.SquareDecimeter, "дм²");
			MapUnitToAbbreviation(Unit.SquareCentimeter, "см²");
			MapUnitToAbbreviation(Unit.SquareMillimeter, "мм²");

			// Angle
			MapUnitToAbbreviation(Unit.Degree, "°");
			MapUnitToAbbreviation(Unit.Radian, "рад");
			MapUnitToAbbreviation(Unit.Gradian, "g");

			// Volumes
			MapUnitToAbbreviation(Unit.CubicKilometer, "км³");
			MapUnitToAbbreviation(Unit.CubicMeter, "м³");
			MapUnitToAbbreviation(Unit.CubicDecimeter, "дм³");
			MapUnitToAbbreviation(Unit.CubicCentimeter, "см³");
			MapUnitToAbbreviation(Unit.CubicMillimeter, "мм³");
			MapUnitToAbbreviation(Unit.Hectoliter, "гл");
			MapUnitToAbbreviation(Unit.Liter, "л");
			MapUnitToAbbreviation(Unit.Deciliter, "дл");
			MapUnitToAbbreviation(Unit.Centiliter, "сл");
			MapUnitToAbbreviation(Unit.Milliliter, "мл");

			// Torque
			MapUnitToAbbreviation(Unit.Newtonmeter, "Н·м");

			// Generic / Other
			MapUnitToAbbreviation(Unit.Piece, "штук");
			MapUnitToAbbreviation(Unit.Percent, "%");

			// Electric potential
			MapUnitToAbbreviation(Unit.Volt, "В");

			// Times
			MapUnitToAbbreviation(Unit.Nanosecond, "нс");
			MapUnitToAbbreviation(Unit.Microsecond, "мкс");
			MapUnitToAbbreviation(Unit.Millisecond, "мс");
			MapUnitToAbbreviation(Unit.Second, "с");
			MapUnitToAbbreviation(Unit.Minute, "мин");
			MapUnitToAbbreviation(Unit.Hour, "ч");
			MapUnitToAbbreviation(Unit.Day, "д");

			// Cooking units
			MapUnitToAbbreviation(Unit.Tablespoon, "столовая ложка");
			MapUnitToAbbreviation(Unit.Teaspoon, "чайная ложка");
				
			// Flow
			MapUnitToAbbreviation(Unit.CubicMeterPerSecond, "м³/с");
			MapUnitToAbbreviation(Unit.CubicMeterPerHour, "м³/ч");

			// Revolution
			MapUnitToAbbreviation(Unit.RevolutionsPerSecond, "об/с");
			MapUnitToAbbreviation(Unit.RevolutionsPerMinute, "об/мин");
		}

        private void CreateCultureInvariants()
        {
            // For correct abbreviations, see: http://lamar.colostate.edu/~hillger/correct.htm
            // Note: For units with multiple abbreviations, the first one is used in GetDefaultAbbreviation().
            MapUnitToAbbreviation(Unit.Undefined, "(no unit)");

			// Length
			MapUnitToAbbreviation(Unit.Kilometer, "km");
			MapUnitToAbbreviation(Unit.Meter, "m");
			MapUnitToAbbreviation(Unit.Decimeter, "dm");
			MapUnitToAbbreviation(Unit.Centimeter, "cm");
			MapUnitToAbbreviation(Unit.Millimeter, "mm");
			MapUnitToAbbreviation(Unit.Micrometer, "μm");
			MapUnitToAbbreviation(Unit.Nanometer, "nm");

			// Masses
			MapUnitToAbbreviation(Unit.Megatonne, "Mt");
			MapUnitToAbbreviation(Unit.Kilotonne, "kt");
			MapUnitToAbbreviation(Unit.Tonne, "t");
			MapUnitToAbbreviation(Unit.Kilogram, "kg");
			MapUnitToAbbreviation(Unit.Hectogram, "hg");
			MapUnitToAbbreviation(Unit.Decagram, "dag");
			MapUnitToAbbreviation(Unit.Gram, "g");
			MapUnitToAbbreviation(Unit.Decigram, "dg");
			MapUnitToAbbreviation(Unit.Centigram, "cg");
			MapUnitToAbbreviation(Unit.Milligram, "mg");

			// Pressures
			MapUnitToAbbreviation(Unit.Pascal, "Pa");
			MapUnitToAbbreviation(Unit.KiloPascal, "kPa");
			MapUnitToAbbreviation(Unit.MegaPascal, "MPa");
			MapUnitToAbbreviation(Unit.KilogramForcePerSquareCentimeter, "kgf/cm²");
			MapUnitToAbbreviation(Unit.Psi, "psi");
			MapUnitToAbbreviation(Unit.NewtonPerSquareCentimeter, "N/cm²");
			MapUnitToAbbreviation(Unit.NewtonPerSquareMillimeter, "N/mm²");
			MapUnitToAbbreviation(Unit.NewtonPerSquareMeter, "N/m²");
			MapUnitToAbbreviation(Unit.Bar, "bar");
			MapUnitToAbbreviation(Unit.TechnicalAtmosphere, "at");
			MapUnitToAbbreviation(Unit.Atmosphere, "atm");
			MapUnitToAbbreviation(Unit.Torr, "Torr");

			// Forces
			MapUnitToAbbreviation(Unit.Kilonewton, "kN");
			MapUnitToAbbreviation(Unit.Newton, "N");
			MapUnitToAbbreviation(Unit.KilogramForce, "kgf");
			MapUnitToAbbreviation(Unit.Dyn, "dyn");

			// Area
			MapUnitToAbbreviation(Unit.SquareKilometer, "km²");
			MapUnitToAbbreviation(Unit.SquareMeter, "m²");
			MapUnitToAbbreviation(Unit.SquareDecimeter, "dm²");
			MapUnitToAbbreviation(Unit.SquareCentimeter, "cm²");
			MapUnitToAbbreviation(Unit.SquareMillimeter, "mm²");

			// Angle
			MapUnitToAbbreviation(Unit.Degree, "°");
			MapUnitToAbbreviation(Unit.Radian, "rad");
			MapUnitToAbbreviation(Unit.Gradian, "g");

			// Volumes
			MapUnitToAbbreviation(Unit.CubicKilometer, "km³");
			MapUnitToAbbreviation(Unit.CubicMeter, "m³");
			MapUnitToAbbreviation(Unit.CubicDecimeter, "dm³");
			MapUnitToAbbreviation(Unit.CubicCentimeter, "cm³");
			MapUnitToAbbreviation(Unit.CubicMillimeter, "mm³");
			MapUnitToAbbreviation(Unit.Hectoliter, "hl");
			MapUnitToAbbreviation(Unit.Liter, "l");
			MapUnitToAbbreviation(Unit.Deciliter, "dl");
			MapUnitToAbbreviation(Unit.Centiliter, "cl");
			MapUnitToAbbreviation(Unit.Milliliter, "ml");

			// Torque
			MapUnitToAbbreviation(Unit.Newtonmeter, "N·m");

			// Generic / Other
			MapUnitToAbbreviation(Unit.Piece, "piece");
			MapUnitToAbbreviation(Unit.Percent, "%");

			// Electric potential
			MapUnitToAbbreviation(Unit.Volt, "V");

			// Times
			MapUnitToAbbreviation(Unit.Nanosecond, "ns");
			MapUnitToAbbreviation(Unit.Microsecond, "μs");
			MapUnitToAbbreviation(Unit.Millisecond, "ms");
			MapUnitToAbbreviation(Unit.Second, "s");
			MapUnitToAbbreviation(Unit.Minute, "min");
			MapUnitToAbbreviation(Unit.Hour, "h");
			MapUnitToAbbreviation(Unit.Day, "d");
			MapUnitToAbbreviation(Unit.Week, "week");
			
			// Cooking units
			MapUnitToAbbreviation(Unit.Tablespoon, "tbsp.");
			MapUnitToAbbreviation(Unit.Teaspoon, "tsp.");

			// Flow
			MapUnitToAbbreviation(Unit.CubicMeterPerSecond, "m³/s");
			MapUnitToAbbreviation(Unit.CubicMeterPerHour, "m³/h");

			// Revolution
			MapUnitToAbbreviation(Unit.RevolutionsPerSecond, "r/s");
			MapUnitToAbbreviation(Unit.RevolutionsPerMinute, "r/min");
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