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
    public class SiUnitSystem
    {
        public static readonly SiUnit[] Masses;
        public static readonly SiUnit[] CookingUnits;
        public static readonly SiUnit[] Volumes;
        public static readonly SiUnit[] Forces;
        public static readonly SiUnit[] Distances;
        private static readonly Dictionary<CultureInfo, SiUnitSystem> CultureToInstance;

        #region Static

        /// <summary>
        ///     The culture of which this unit system is based on. Either passed in to constructor or the default culture.
        /// </summary>
        public readonly CultureInfo Culture;

        static SiUnitSystem()
        {
            CultureToInstance = new Dictionary<CultureInfo, SiUnitSystem>();
            Masses = new[] {SiUnit.Kilogram, SiUnit.Hectogram, SiUnit.Gram, SiUnit.Milligram};
            Forces = new[] {SiUnit.KiloNewton, SiUnit.Newton};
            Distances = new[] {SiUnit.Meter, SiUnit.Centimeter, SiUnit.Millimeter};
            Volumes = new[] {SiUnit.Liter, SiUnit.Centiliter, SiUnit.Deciliter, SiUnit.Milliliter};
            CookingUnits = new[]
                {
                    SiUnit.Tablespoon, SiUnit.Teaspoon, SiUnit.Piece, SiUnit.Kilogram, SiUnit.Hectogram, SiUnit.Gram,
                    SiUnit.Milligram, SiUnit.Liter, SiUnit.Centiliter, SiUnit.Deciliter, SiUnit.Centiliter,
                    SiUnit.Milliliter, SiUnit.Meter, SiUnit.Centimeter, SiUnit.Millimeter,
                };
        }

        /// <summary>
        ///     Create a SI system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        private SiUnitSystem(CultureInfo cultureInfo = null)
        {
            //_cultureInfo = cultureInfo;
            _unitToAbbrevs = new Dictionary<SiUnit, List<string>>();
            _abbrevsToUnit = new Dictionary<string, SiUnit>();

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
        public static SiUnitSystem Create(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                cultureInfo = CultureInfo.CurrentUICulture;

            if (!CultureToInstance.ContainsKey(cultureInfo))
                CultureToInstance[cultureInfo] = new SiUnitSystem(cultureInfo);

            return CultureToInstance[cultureInfo];
        }

        /// <summary>
        ///     A general method for converting a value in a given metric unit domain to the respective value in a compatible unit domain,
        ///     such as converting from milimeters to meters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <returns></returns>
        public static decimal ToUnit(decimal value, SiUnit fromUnit, SiUnit toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            if (!IsCompatible(fromUnit, toUnit))
                throw new Exception("Units not compatible: " + fromUnit + " and " + toUnit);


            // Earlier reflection was used here for more elegant code, but reflections is dead slow 
            // and the switch is not too much to maintain since the unit types don't change too often.
            // An exception is thrown if a new unit is added but not implemented and this method is called with the 
            // new type as argument.
            switch (toUnit)
            {
                case SiUnit.Kilogram:
                    return ToKilogram(value, fromUnit);

                case SiUnit.Hectogram:
                    return ToHectogram(value, fromUnit);

                case SiUnit.Gram:
                    return ToGram(value, fromUnit);

                case SiUnit.Milligram:
                    return ToMilligram(value, fromUnit);

                case SiUnit.Liter:
                    return ToLiter(value, fromUnit);

                case SiUnit.Deciliter:
                    return ToDeciliter(value, fromUnit);

                case SiUnit.Centiliter:
                    return ToCentiliter(value, fromUnit);

                case SiUnit.Milliliter:
                    return ToMilliliter(value, fromUnit);

                case SiUnit.Undefined:
                    throw new Exception("Can't convert to generic and undefined units.");

                default:
                    throw new ArgumentException("Could not find conversion method for " + toUnit +
                                                ", it may not be implemented yet.");
            }
        }

        /// <summary>
        ///     A general method for converting a value in a given metric unit domain to the respective value in a compatible unit domain,
        ///     such as converting from milimeters to meters.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <returns></returns>
        public static double ToUnit(double value, SiUnit fromUnit, SiUnit toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            if (!IsCompatible(fromUnit, toUnit))
                throw new Exception("Units not compatible: " + fromUnit + " and " + toUnit);


            // Earlier reflection was used here for more elegant code, but reflections is dead slow 
            // and the switch is not too much to maintain since the unit types don't change too often.
            // An exception is thrown if a new unit is added but not implemented and this method is called with the 
            // new type as argument.
            switch (toUnit)
            {
                case SiUnit.Kilogram:
                    return ToKilogram(value, fromUnit);

                case SiUnit.Hectogram:
                    return ToHectogram(value, fromUnit);

                case SiUnit.Gram:
                    return ToGram(value, fromUnit);

                case SiUnit.Milligram:
                    return ToMilligram(value, fromUnit);

                case SiUnit.Liter:
                    return ToLiter(value, fromUnit);

                case SiUnit.Deciliter:
                    return ToDeciliter(value, fromUnit);

                case SiUnit.Centiliter:
                    return ToCentiliter(value, fromUnit);

                case SiUnit.Milliliter:
                    return ToMilliliter(value, fromUnit);

                case SiUnit.Undefined:
                    throw new Exception("Can't convert to generic and undefined units.");

                default:
                    throw new ArgumentException("Could not find conversion method for " + toUnit +
                                                ", it may not be implemented yet.");
            }
        }

        private static double ToKilogram(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Kilogram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Hectogram)
                return value/10;
            if (fromUnit == SiUnit.Gram)
                return value/1000;
            if (fromUnit == SiUnit.Milligram)
                return value/1000000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToKilogram(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Kilogram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Hectogram)
                return value/10;
            if (fromUnit == SiUnit.Gram)
                return value/1000;
            if (fromUnit == SiUnit.Milligram)
                return value/1000000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToHectogram(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Hectogram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*10;
            if (fromUnit == SiUnit.Gram)
                return value/100;
            if (fromUnit == SiUnit.Milligram)
                return value/100000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToHectogram(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Hectogram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*10;
            if (fromUnit == SiUnit.Gram)
                return value/100;
            if (fromUnit == SiUnit.Milligram)
                return value/100000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToGram(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Gram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*1000;
            if (fromUnit == SiUnit.Hectogram)
                return value*100;
            if (fromUnit == SiUnit.Milligram)
                return value/1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToGram(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Gram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*1000;
            if (fromUnit == SiUnit.Hectogram)
                return value*100;
            if (fromUnit == SiUnit.Milligram)
                return value/1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToMilligram(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Milligram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*1000000;
            if (fromUnit == SiUnit.Hectogram)
                return value*100000;
            if (fromUnit == SiUnit.Gram)
                return value*1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToMilligram(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Milligram;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Kilogram)
                return value*1000000;
            if (fromUnit == SiUnit.Hectogram)
                return value*100000;
            if (fromUnit == SiUnit.Gram)
                return value*1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToLiter(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Liter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Deciliter)
                return value/10;
            if (fromUnit == SiUnit.Centiliter)
                return value/100;
            if (fromUnit == SiUnit.Milliliter)
                return value/1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToLiter(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Liter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Deciliter)
                return value/10;
            if (fromUnit == SiUnit.Centiliter)
                return value/100;
            if (fromUnit == SiUnit.Milliliter)
                return value/1000;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToDeciliter(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Deciliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*10;
            if (fromUnit == SiUnit.Centiliter)
                return value/10;
            if (fromUnit == SiUnit.Milliliter)
                return value/100;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToDeciliter(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Deciliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*10;
            if (fromUnit == SiUnit.Centiliter)
                return value/10;
            if (fromUnit == SiUnit.Milliliter)
                return value/100;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToCentiliter(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Centiliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*100;
            if (fromUnit == SiUnit.Deciliter)
                return value*10;
            if (fromUnit == SiUnit.Milliliter)
                return value/10;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToCentiliter(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Centiliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*100;
            if (fromUnit == SiUnit.Deciliter)
                return value*10;
            if (fromUnit == SiUnit.Milliliter)
                return value/10;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static double ToMilliliter(double value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Milliliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*1000;
            if (fromUnit == SiUnit.Deciliter)
                return value*100;
            if (fromUnit == SiUnit.Centiliter)
                return value*10;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        private static decimal ToMilliliter(decimal value, SiUnit fromUnit)
        {
            const SiUnit toUnit = SiUnit.Milliliter;
            if (fromUnit == toUnit)
                return value;
            if (fromUnit == SiUnit.Liter)
                return value*1000;
            if (fromUnit == SiUnit.Deciliter)
                return value*100;
            if (fromUnit == SiUnit.Centiliter)
                return value*10;

            throw new ArgumentException(String.Format("Incompatible: {0} and {1}.", fromUnit, toUnit));
        }

        public static bool IsCompatible(SiUnit a, SiUnit b)
        {
            if (a == b) return true;
            if (IsMass(a) && IsMass(b)) return true;
            if (IsVolume(a) && IsVolume(b)) return true;
            if (IsForce(a) && IsForce(b)) return true;
            if (IsDistance(a) && IsDistance(b)) return true;

            return false;
        }

        public static bool IsGreater(SiUnit left, SiUnit right)
        {
            if (!IsCompatible(left, right))
                throw new ArgumentException(string.Format("Incompatible units: {0} and {1}", left, right));

            // Note: Assumes units are declared in larger-to-smaller sizes.
            return ((int) left < (int) right);
        }

        public static bool IsMass(SiUnit unit)
        {
            return Masses.Contains(unit);
        }

        public static bool IsForce(SiUnit unit)
        {
            return Forces.Contains(unit);
        }

        public static bool IsDistance(SiUnit unit)
        {
            return Distances.Contains(unit);
        }

        public static bool IsVolume(SiUnit unit)
        {
            return Volumes.Contains(unit);
        }

        public static bool IsCookingUnit(SiUnit unit)
        {
            return CookingUnits.Contains(unit);
        }

        #endregion

        #region Public methods

        public static SiUnit Parse(string unitAbbreviation, CultureInfo culture)
        {
            return Create(culture).Parse(unitAbbreviation);
        }

        public SiUnit Parse(string unitAbbreviation)
        {
            SiUnit result;
            if (_abbrevsToUnit.TryGetValue(unitAbbreviation, out result))
                return result;

            return SiUnit.Undefined;
        }

        public static string GetDefaultAbbreviation(SiUnit unit, CultureInfo culture)
        {
            return Create(culture).GetDefaultAbbreviation(unit);
        }

        public string GetDefaultAbbreviation(SiUnit unit)
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
            MapUnitToAbbreviation(SiUnit.Tablespoon, "T", "T.", "tbsp", "tbsp.", "tbs", "tbs.");
            // For units with multiple abbreviations, the first one denotes the most common one
            MapUnitToAbbreviation(SiUnit.Teaspoon, "tsp", "tsp.", "t", "t.");
            MapUnitToAbbreviation(SiUnit.Piece, "pcs", "pcs.", "pc", "pc.", "pce", "pce.");
        }

        private void CreateNorwegianBokmaal()
        {
            CreateCultureInvariants();

            // Cooking units
            MapUnitToAbbreviation(SiUnit.Tablespoon, "ss", "ss.");
            MapUnitToAbbreviation(SiUnit.Teaspoon, "ts", "ts.");
            MapUnitToAbbreviation(SiUnit.Piece, "stk", "stk.");
        }

        private void CreateCultureInvariants()
        {
            // For correct abbreviations, see: http://lamar.colostate.edu/~hillger/correct.htm
            // Note: For units with multiple abbreviations, the first one is used in GetDefaultAbbreviation().
            MapUnitToAbbreviation(SiUnit.Undefined, "(no unit)");

            // Masses
            MapUnitToAbbreviation(SiUnit.Kilogram, "kg");
            MapUnitToAbbreviation(SiUnit.Hectogram, "hg");
            MapUnitToAbbreviation(SiUnit.Gram, "g");
            MapUnitToAbbreviation(SiUnit.Milligram, "mg");

            // Forces
            MapUnitToAbbreviation(SiUnit.KiloNewton, "kN");
            MapUnitToAbbreviation(SiUnit.Newton, "N");

            // Torque
            MapUnitToAbbreviation(SiUnit.Newtonmeter, "Nm");

            // Distances
            MapUnitToAbbreviation(SiUnit.Meter, "m");
            MapUnitToAbbreviation(SiUnit.Centimeter, "cm");
            MapUnitToAbbreviation(SiUnit.Millimeter, "mm");

            // Volumes
            MapUnitToAbbreviation(SiUnit.Liter, "l", "L");
            MapUnitToAbbreviation(SiUnit.Deciliter, "dl", "dL");
            MapUnitToAbbreviation(SiUnit.Centiliter, "cl", "cL");
            MapUnitToAbbreviation(SiUnit.Milliliter, "ml", "mL");

            // Other units
            MapUnitToAbbreviation(SiUnit.Volt, "V");
            MapUnitToAbbreviation(SiUnit.Percent, "%");
            MapUnitToAbbreviation(SiUnit.Second, "s");
        }

        private void MapUnitToAbbreviation(SiUnit unit, params string[] abbreviations)
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

        private readonly Dictionary<string, SiUnit> _abbrevsToUnit;
        private readonly Dictionary<SiUnit, List<string>> _unitToAbbrevs;

        public bool TryParse(string unitAbbreviation, out SiUnit unit)
        {
            return _abbrevsToUnit.TryGetValue(unitAbbreviation, out unit);
        }

        public string[] GetAllAbbreviations(SiUnit unit)
        {
            return _unitToAbbrevs[unit].ToArray();
        }
    }
}