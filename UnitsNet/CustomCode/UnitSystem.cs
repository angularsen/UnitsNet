// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using System.Reflection;
using JetBrains.Annotations;
using UnitsNet.I18n;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    [PublicAPI]
    public partial class UnitSystem
    {
        private static readonly Dictionary<IFormatProvider, UnitSystem> CultureToInstance;
        private static readonly CultureInfo DefaultCulture = new CultureInfo("en-US");
        private static readonly object LockUnitSystemCache = new object();

        /// <summary>
        ///     Per-unit-type dictionary of enum values by abbreviation. This is the inverse of
        ///     <see cref="_unitTypeToUnitValueToAbbrevs" />.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<string, int>> _unitTypeToAbbrevToUnitValue;

        /// <summary>
        ///     Per-unit-type dictionary of abbreviations by enum value. This is the inverse of
        ///     <see cref="_unitTypeToAbbrevToUnitValue" />.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<int, List<string>>> _unitTypeToUnitValueToAbbrevs;

        /// <summary>
        ///     The culture of which this unit system is based on. Either passed in to constructor or the default culture.
        /// </summary>
        [NotNull] [PublicAPI] public readonly IFormatProvider Culture;

        static UnitSystem()
        {
            CultureToInstance = new Dictionary<IFormatProvider, UnitSystem>();
        }

        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        public UnitSystem([CanBeNull] IFormatProvider cultureInfo = null)
        {
            if (cultureInfo == null)
                cultureInfo = new CultureInfo(DefaultCulture.Name);

            Culture = cultureInfo;
            _unitTypeToUnitValueToAbbrevs = new Dictionary<Type, Dictionary<int, List<string>>>();
            _unitTypeToAbbrevToUnitValue = new Dictionary<Type, Dictionary<string, int>>();

            LoadDefaultAbbreviatons(cultureInfo);
        }

        public bool IsDefaultCulture
        {
            get { return Culture.Equals(DefaultCulture); }
        }

        [PublicAPI]
        public static void ClearCache()
        {
            CultureToInstance.Clear();
        }

        /// <summary>
        ///     Get or create a unit system for parsing and presenting numbers, units and abbreviations.
        ///     Creating can be a little expensive, so it will use a static cache.
        ///     To always create, use the constructor.
        /// </summary>
        /// <param name="cultureInfo">Culture to use. If null then <see cref="CultureInfo.CurrentUICulture" /> will be used.</param>
        /// <returns></returns>
        [PublicAPI]
        public static UnitSystem GetCached(IFormatProvider cultureInfo = null)
        {
            if (cultureInfo == null)
                cultureInfo = CultureInfo.CurrentUICulture;

            lock(LockUnitSystemCache)
            {
                if ( CultureToInstance.ContainsKey(cultureInfo) )
                    return CultureToInstance[cultureInfo];

                CultureToInstance[cultureInfo] = new UnitSystem(cultureInfo);
                return CultureToInstance[cultureInfo];
            }
        }

        [PublicAPI]
        public static TUnit Parse<TUnit>(string unitAbbreviation, CultureInfo culture)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).Parse<TUnit>(unitAbbreviation);
        }

        [PublicAPI]
        public TUnit Parse<TUnit>(string unitAbbreviation)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            Type unitType = typeof (TUnit);
            Dictionary<string, int> abbrevToUnitValue;
            if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue))
                throw new NotImplementedException(
                    string.Format("No abbreviations defined for unit type [{0}] for culture [{1}].", unitType, Culture));

            int unitValue;
            TUnit result = abbrevToUnitValue.TryGetValue(unitAbbreviation, out unitValue)
                ? (TUnit) (object) unitValue
                : default(TUnit);

            return result;
        }

        [PublicAPI]
        public static string GetDefaultAbbreviation<TUnit>(TUnit unit, CultureInfo culture)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).GetDefaultAbbreviation(unit);
        }

        [PublicAPI]
        public string GetDefaultAbbreviation<TUnit>(TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetAllAbbreviations(unit).First();
        }

        [PublicAPI]
        public void MapUnitToAbbreviation<TUnit>(TUnit unit, params string[] abbreviations)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            // Assuming TUnit is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            int unitValue = Convert.ToInt32(unit);
            Type unitType = typeof (TUnit);
            MapUnitToAbbreviation(unitType, unitValue, abbreviations);
        }

        [PublicAPI]
        public void MapUnitToAbbreviation(Type unitType, int unitValue, [NotNull] params string[] abbreviations)
        {
#if PORTABLE45
            if (!unitType.GetTypeInfo().IsEnum)
                throw new ArgumentException("Must be an enum type.", "unitType");
#else
            if (!unitType.IsEnum)
                throw new ArgumentException("Must be an enum type.", "unitType");
#endif
            if (abbreviations == null)
                throw new ArgumentNullException("abbreviations");

            Dictionary<int, List<string>> unitValueToAbbrev;
            if (!_unitTypeToUnitValueToAbbrevs.TryGetValue(unitType, out unitValueToAbbrev))
            {
                unitValueToAbbrev = _unitTypeToUnitValueToAbbrevs[unitType] = new Dictionary<int, List<string>>();
            }

            List<string> existingAbbreviations;
            if (!unitValueToAbbrev.TryGetValue(unitValue, out existingAbbreviations))
            {
                existingAbbreviations = unitValueToAbbrev[unitValue] = new List<string>();
            }

            // Append new abbreviations to any existing abbreviations so that we don't
            // change the result of GetDefaultAbbreviation() if already defined.
            unitValueToAbbrev[unitValue] = existingAbbreviations.Concat(abbreviations).Distinct().ToList();
            foreach (string abbreviation in abbreviations)
            {
                Dictionary<string, int> abbrevToUnitValue;
                if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue))
                {
                    abbrevToUnitValue = _unitTypeToAbbrevToUnitValue[unitType] =
                        new Dictionary<string, int>();
                }

                if (!abbrevToUnitValue.ContainsKey(abbreviation))
                    abbrevToUnitValue[abbreviation] = unitValue;
            }
        }

        [PublicAPI]
        public bool TryParse<TUnit>(string unitAbbreviation, out TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            Type unitType = typeof (TUnit);

            Dictionary<string, int> abbrevToUnitValue;
            int unitValue;

            if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue) ||
                !abbrevToUnitValue.TryGetValue(unitAbbreviation, out unitValue))
            {
                if (IsDefaultCulture)
                {
                    unit = default(TUnit);
                    return false;
                }

                // Fall back to default culture
                return GetCached(DefaultCulture).TryParse(unitAbbreviation, out unit);
            }

            unit = (TUnit) (object) unitValue;
            return true;
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnit">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllAbbreviations<TUnit>(TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            Type unitType = typeof (TUnit);
            int unitValue = Convert.ToInt32(unit);

            Dictionary<int, List<string>> unitValueToAbbrevs;
            List<string> abbrevs;

            if (!_unitTypeToUnitValueToAbbrevs.TryGetValue(unitType, out unitValueToAbbrevs) ||
                !unitValueToAbbrevs.TryGetValue(unitValue, out abbrevs))
            {
                if (IsDefaultCulture)
                {
                    return new[] {string.Format("(no abbreviation for {0}.{1})", unitType.Name, unit)};
                }

                // Fall back to default culture
                return GetCached(DefaultCulture).GetAllAbbreviations(unit);
            }

            return abbrevs.ToArray();
        }

        private void LoadDefaultAbbreviatons([NotNull] IFormatProvider culture)
        {
            foreach (UnitLocalization localization in DefaultLocalizations)
            {
                Type unitEnumType = localization.UnitEnumType;

                foreach (CulturesForEnumValue ev in localization.EnumValues)
                {
                    int unitEnumValue = ev.Value;
                    var usCulture = new CultureInfo("en-US");

                    // Fall back to US English if localization not found
                    AbbreviationsForCulture matchingCulture =
                        ev.Cultures.FirstOrDefault(a => a.Cult.Equals(culture)) ??
                        ev.Cultures.FirstOrDefault(a => a.Cult.Equals(usCulture));

                    if (matchingCulture == null)
                        continue;

                    MapUnitToAbbreviation(unitEnumType, unitEnumValue, matchingCulture.Abbreviations.ToArray());
                }
            }
        }
    }
}