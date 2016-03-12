// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
using JetBrains.Annotations;
using UnitsNet.I18n;

#if WINDOWS_UWP
using System.Reflection;
#endif

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    [PublicAPI]
    public sealed partial class UnitSystem
    {
        private static readonly Dictionary<IFormatProvider, UnitSystem> CultureToInstance;

        /// <summary>
        ///     Fallback culture used by <see cref="GetAllAbbreviations{TUnit}" /> and
        ///     <see cref="GetDefaultAbbreviation{TUnit}(TUnit,CultureInfo)" />
        ///     if no abbreviations are found with current <see cref="Culture" />.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="Parse{TUnit}(string,CultureInfo)" /> or <see cref="object.ToString" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        private static readonly CultureInfo FallbackCulture = new CultureInfo("en-US");

        private static readonly object LockUnitSystemCache = new object();

        /// <summary>
        ///     Per-unit-type dictionary of enum values by abbreviation. This is the inverse of
        ///     <see cref="_unitTypeToUnitValueToAbbrevs" />.
        /// </summary>
        private readonly Dictionary<Type, AbbreviationMap> _unitTypeToAbbrevToUnitValue;

        /// <summary>
        ///     Per-unit-type dictionary of abbreviations by enum value. This is the inverse of
        ///     <see cref="_unitTypeToAbbrevToUnitValue" />.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<int, List<string>>> _unitTypeToUnitValueToAbbrevs;

        /// <summary>
        ///     The culture of which this unit system is based on. Either passed in to constructor or the default culture.
        /// </summary>
        [NotNull] [PublicAPI] internal readonly IFormatProvider Culture;

        static UnitSystem()
        {
            CultureToInstance = new Dictionary<IFormatProvider, UnitSystem>();
        }

        /// <summary>
        ///     Create unit system for parsing and generating strings with the English US culture.
        /// </summary>
        public UnitSystem() : this(DefaultCulture)
        {
        }

        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        public UnitSystem([CanBeNull] string cultureInfo) : this(cultureInfo != null ? new CultureInfo(cultureInfo) : DefaultCulture)
        {
        }

        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
#if WINDOWS_UWP
        internal
#else
        public 
#endif
            UnitSystem([CanBeNull] IFormatProvider cultureInfo)
        {
            if (cultureInfo == null)
                cultureInfo = DefaultCulture;

            Culture = cultureInfo;
            _unitTypeToUnitValueToAbbrevs = new Dictionary<Type, Dictionary<int, List<string>>>();
            _unitTypeToAbbrevToUnitValue = new Dictionary<Type, AbbreviationMap>();

            LoadDefaultAbbreviatons(cultureInfo);
        }

        /// <summary>
        ///     Default culture if none is specified in constructor or <see cref="GetCached()" /> is always
        ///     <see cref="CultureInfo.CurrentUICulture" />.
        /// </summary>
        private static IFormatProvider DefaultCulture => CultureInfo.CurrentUICulture;

        public bool IsFallbackCulture => Culture.Equals(FallbackCulture);

        [PublicAPI]
        public static void ClearCache()
        {
            lock (LockUnitSystemCache)
            {
                CultureToInstance.Clear();
            }
        }

        /// <summary>
        ///     Get or create a unit system for parsing and presenting numbers, units and abbreviations.
        ///     Creating can be a little expensive, so it will use a static cache.
        ///     To always create, use the constructor.
        /// </summary>
        /// <returns></returns>
        [PublicAPI]
        public static UnitSystem GetCached()
        {
            return GetCached((CultureInfo)null);
        }

        /// <summary>
        ///     Get or create a unit system for parsing and presenting numbers, units and abbreviations.
        ///     Creating can be a little expensive, so it will use a static cache.
        ///     To always create, use the constructor.
        /// </summary>
        /// <param name="cultureName">Culture to use. If null then <see cref="CultureInfo.CurrentUICulture" /> will be used.</param>
        /// <returns></returns>
        [PublicAPI]
        public static UnitSystem GetCached([CanBeNull] string cultureName)
        {
            var cultureInfo = cultureName == null ? DefaultCulture : new CultureInfo(cultureName);
            return GetCached(cultureInfo);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
            static UnitSystem GetCached([CanBeNull] IFormatProvider cultureInfo)
        {
            if (cultureInfo == null)
                cultureInfo = DefaultCulture;

            lock (LockUnitSystemCache)
            {
                if (CultureToInstance.ContainsKey(cultureInfo))
                    return CultureToInstance[cultureInfo];

                CultureToInstance[cultureInfo] = new UnitSystem(cultureInfo);
                return CultureToInstance[cultureInfo];
            }
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static TUnit Parse<TUnit>(string unitAbbreviation, CultureInfo culture)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).Parse<TUnit>(unitAbbreviation);
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        TUnit Parse<TUnit>(string unitAbbreviation)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return (TUnit) Parse(unitAbbreviation, typeof (TUnit));
        }

        [PublicAPI]
        public object Parse(string unitAbbreviation, Type unitType)
        {
            AbbreviationMap abbrevToUnitValue;
            if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue))
                throw new NotImplementedException(
                    $"No abbreviations defined for unit type [{unitType}] for culture [{Culture}].");

            List<int> unitIntValues;
            List<object> unitValues = abbrevToUnitValue.TryGetValue(unitAbbreviation, out unitIntValues)
                ? unitIntValues.Distinct().Cast<object>().ToList()
                : new List<object>();

            switch (unitValues.Count)
            {
                case 1:
                    return unitValues[0];
                case 0:
                    return 0;
                default:
                    var unitsCsv = string.Join(", ", unitValues.Select(x => x.ToString()).ToArray());
                    throw new AmbiguousUnitParseException(
                        $"Cannot parse '{unitAbbreviation}' since it could be either of these: {unitsCsv}");
            }
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static string GetDefaultAbbreviation<TUnit>(TUnit unit, CultureInfo culture)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).GetDefaultAbbreviation(unit);
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        string GetDefaultAbbreviation<TUnit>(TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetAllAbbreviations(unit).First();
        }

        [PublicAPI]
        public string GetDefaultAbbreviation(Type unitType, int unitValue)
        {
            return GetAllAbbreviations(unitType, unitValue).First();
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        void MapUnitToAbbreviation<TUnit>(TUnit unit, params string[] abbreviations)
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
#if WINDOWS_UWP
        internal
#else
        public
#endif
        void MapUnitToAbbreviation(Type unitType, int unitValue, [NotNull] params string[] abbreviations)
        {
#if WINDOWS_UWP
            if (!unitType.GetTypeInfo().IsEnum)
#else
            if (!unitType.IsEnum)
#endif
                throw new ArgumentException("Must be an enum type.", nameof(unitType));

            if (abbreviations == null)
                throw new ArgumentNullException(nameof(abbreviations));

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
                AbbreviationMap abbrevToUnitValue;
                if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue))
                {
                    abbrevToUnitValue = _unitTypeToAbbrevToUnitValue[unitType] = new AbbreviationMap();
                }

                if (!abbrevToUnitValue.ContainsKey(abbreviation))
                {
                    abbrevToUnitValue[abbreviation] = new List<int>();
                }
                abbrevToUnitValue[abbreviation].Add(unitValue);
            }
        }

        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        bool TryParse<TUnit>(string unitAbbreviation, out TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            try
            {
                unit = (TUnit)Parse(unitAbbreviation, typeof (TUnit));
                return true;
            }
            catch
            {
                unit = default(TUnit);
                return false;
            }
        }

        [PublicAPI]
        public bool TryParse(string unitAbbreviation, Type unitType, out object unit)
        {
            try
            {
                unit = Parse(unitAbbreviation, unitType);
                return true;
            }
            catch
            {
                unit = GetDefault(unitType);
                return false;
            }
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnit">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        string[] GetAllAbbreviations<TUnit>(TUnit unit)
            where TUnit : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            Dictionary<int, List<string>> unitValueToAbbrevs;
            List<string> abbrevs;

            if (_unitTypeToUnitValueToAbbrevs.TryGetValue(typeof(TUnit), out unitValueToAbbrevs) &&
                unitValueToAbbrevs.TryGetValue((int)(object)unit, out abbrevs))
            {
                return abbrevs.ToArray();
            }

            return IsFallbackCulture
                ? new[] {$"(no abbreviation for {typeof(TUnit).Name}.{unit})"}
                : GetCached(FallbackCulture).GetAllAbbreviations(unit);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllAbbreviations(Type unitType, int unitValue)
        {
            Dictionary<int, List<string>> unitValueToAbbrevs;
            List<string> abbrevs;

            if (_unitTypeToUnitValueToAbbrevs.TryGetValue(unitType, out unitValueToAbbrevs) &&
                unitValueToAbbrevs.TryGetValue(unitValue, out abbrevs))
            {
                return abbrevs.ToArray();
            }

            // Fall back to default culture
            return IsFallbackCulture
                ? new[] {$"(no abbreviation for {unitType.Name} with numeric value {unitValue})"}
                : GetCached(FallbackCulture).GetAllAbbreviations(unitType, unitValue);
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
        
        /// <summary>
        /// Avoids having too many nested generics for code clarity
        /// </summary>
        private class AbbreviationMap : Dictionary<string, List<int>>
        {

        }

        /// <summary>
        ///     Get default(Type) of <param name="type"></param>.
        ///     Null for reference types, 0 for numeric types and default constructor for the rest.
        /// </summary>
        private static object GetDefault(Type type)
        {
            return type
#if WINDOWS_UWP
                .GetTypeInfo()
#endif
                .IsValueType
                ? Activator.CreateInstance(type)
                : null;
        }
    }
}