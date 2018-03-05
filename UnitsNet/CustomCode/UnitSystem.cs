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
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.I18n;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    [PublicAPI]
    public sealed partial class UnitSystem
    {
        private static readonly Dictionary<IFormatProvider, UnitSystem> CultureToInstance;

        /// <summary>
        ///     Fallback culture used by <see cref="GetAllAbbreviations{TUnitType}" /> and
        ///     <see cref="GetDefaultAbbreviation{TUnitType}(TUnitType,CultureInfo)" />
        ///     if no abbreviations are found with current <see cref="Culture" />.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="Parse{TUnitType}(string,CultureInfo)" /> or <see cref="object.ToString" /> with Russian
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
            Default = GetCached((CultureInfo) null);
        }

        /// <summary>
        ///     Create unit system for parsing and generating strings with the English US culture.
        /// </summary>
        public UnitSystem() : this(DefaultCulture)
        {

        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        public UnitSystem([CanBeNull] string cultureInfo) : this(cultureInfo != null ? new CultureInfo(cultureInfo) : DefaultCulture)
        {
        }
#else
        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="loadDefaultAbbreviations">
        ///     If <c>true</c> (default), loads abbreviations per unit defined in
        ///     /UnitsNet/UnitDefinitions/*.json files. Otherwise, creates an empty instance.
        /// </param>
        public UnitSystem([CanBeNull] string cultureInfo, bool loadDefaultAbbreviations = true) : this(cultureInfo != null ? new CultureInfo(cultureInfo) : DefaultCulture)
        {
        }
#endif

        /// <summary>
        ///     Create unit system for parsing and generating strings of the specified culture.
        ///     If null is specified, the default English US culture will be used.
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="loadDefaultAbbreviations">
        ///     If <c>true</c> (default), loads abbreviations per unit defined in
        ///     /UnitsNet/UnitDefinitions/*.json files. Otherwise, creates an empty instance.
        /// </param>

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            UnitSystem([CanBeNull] IFormatProvider cultureInfo, bool loadDefaultAbbreviations = true)
        {
            if (cultureInfo == null)
                cultureInfo = DefaultCulture;

            Culture = cultureInfo;
            _unitTypeToUnitValueToAbbrevs = new Dictionary<Type, Dictionary<int, List<string>>>();
            _unitTypeToAbbrevToUnitValue = new Dictionary<Type, AbbreviationMap>();

            if (loadDefaultAbbreviations)
                LoadDefaultAbbreviations(cultureInfo);
        }

        /// <summary>
        ///     Defaults to <see cref="CultureInfo.CurrentUICulture" /> when creating an instance with no culture provided.
        ///     Can be overridden, but note that this is static and will affect all subsequent usages.
        /// </summary>
#if WINDOWS_UWP
        // Windows Runtime Component does not support exposing the IFormatProvider type in public API
        internal
#else
        public
#endif
            static IFormatProvider DefaultCulture { get; set; } = CultureInfo.CurrentUICulture;

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
        ///     The default singleton instance based on the system default UI culture <see cref="CultureInfo.CurrentUICulture" />.
        ///     This instance is used internally for all parsing and string formatting where culture is not explicitly specified,
        ///     so use this if you want extend with new units via <see cref="MapUnitToAbbreviation{TUnitType}" />
        ///     and make the new units available to methods like <see cref="Length.Parse(string)" />; when culture is not
        ///     explicitly
        ///     specified.
        ///     If you do explicitly specify culture when parsing and calling ToString(), then just make sure to call
        ///     <see cref="GetCached(IFormatProvider)" /> with the same culture.
        /// </summary>
        public static UnitSystem Default { get; }

        /// <summary>
        ///     Get or create a unit system for parsing and presenting numbers, units and abbreviations.
        ///     Creating can be a little expensive, so it will use a static cache.
        ///     To always create, use the constructor.
        /// </summary>
        /// <returns></returns>
        [PublicAPI]
        [Obsolete("Use Default property instead. This will be removed in the future.")]
        public static UnitSystem GetCached()
        {
            return GetCached((CultureInfo) null);
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
            IFormatProvider cultureInfo = cultureName == null ? DefaultCulture : new CultureInfo(cultureName);
            return GetCached(cultureInfo);
        }

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
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
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static TUnitType Parse<TUnitType>(string unitAbbreviation, IFormatProvider culture)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).Parse<TUnitType>(unitAbbreviation);
        }

        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            TUnitType Parse<TUnitType>(string unitAbbreviation)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return (TUnitType) Parse(unitAbbreviation, typeof(TUnitType));
        }

        /// <summary>
        ///     Parse a unit abbreviation, such as "kg" or "m", to the unit enum value of the enum type
        ///     <paramref name="unitType" />.
        /// </summary>
        /// <param name="unitAbbreviation">
        ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
        ///     <see cref="LengthUnit.Meter" /> respectively.
        /// </param>
        /// <param name="unitType">Unit enum type, such as <see cref="MassUnit" /> and <see cref="LengthUnit" />.</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbrevation.</exception>
        [PublicAPI]
        public object Parse(string unitAbbreviation, Type unitType)
        {
            AbbreviationMap abbrevToUnitValue;
            if (!_unitTypeToAbbrevToUnitValue.TryGetValue(unitType, out abbrevToUnitValue))
                throw new UnitNotFoundException($"No abbreviations defined for unit type [{unitType}] for culture [{Culture}].");

            List<int> unitIntValues;
            List<object> unitValues = abbrevToUnitValue.TryGetValue(unitAbbreviation, out unitIntValues)
                ? unitIntValues.Distinct().Cast<object>().ToList()
                : new List<object>();

            switch (unitValues.Count)
            {
                case 1:
                    return unitValues[0];
                case 0:
                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{unitType}].");
                default:
                    string unitsCsv = string.Join(", ", unitValues.Select(x => x.ToString()).ToArray());
                    throw new AmbiguousUnitParseException(
                        $"Cannot parse '{unitAbbreviation}' since it could be either of these: {unitsCsv}");
            }
        }

        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            static string GetDefaultAbbreviation<TUnitType>(TUnitType unit, CultureInfo culture)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetCached(culture).GetDefaultAbbreviation(unit);
        }

        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            string GetDefaultAbbreviation<TUnitType>(TUnitType unit)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            return GetAllAbbreviations(unit).First();
        }

        [PublicAPI]
        public string GetDefaultAbbreviation(Type unitType, int unitValue)
        {
            return GetAllAbbreviations(unitType, unitValue).First();
        }

        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            int unitValue = Convert.ToInt32(unit);
            Type unitType = typeof(TUnitType);
            MapUnitToAbbreviation(unitType, unitValue, abbreviations);
        }

        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            void MapUnitToAbbreviation(Type unitType, int unitValue, [NotNull] params string[] abbreviations)
        {
            if (!unitType.IsEnum())
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
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            bool TryParse<TUnitType>(string unitAbbreviation, out TUnitType unit)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            try
            {
                unit = (TUnitType) Parse(unitAbbreviation, typeof(TUnitType));
                return true;
            }
            catch
            {
                unit = default(TUnitType);
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
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            string[] GetAllAbbreviations<TUnitType>(TUnitType unit)
            where TUnitType : /*Enum constraint hack*/ struct, IComparable, IFormattable
        {
            Dictionary<int, List<string>> unitValueToAbbrevs;
            List<string> abbrevs;

            if (_unitTypeToUnitValueToAbbrevs.TryGetValue(typeof(TUnitType), out unitValueToAbbrevs) &&
                unitValueToAbbrevs.TryGetValue((int) (object) unit, out abbrevs))
            {
                return abbrevs.ToArray();
            }

            return IsFallbackCulture
                ? new[] {$"(no abbreviation for {typeof(TUnitType).Name}.{unit})"}
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

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllAbbreviations(Type unitType)
        {
            Dictionary<int, List<string>> unitValueToAbbrevs;
            if (_unitTypeToUnitValueToAbbrevs.TryGetValue(unitType, out unitValueToAbbrevs))
            {
                return unitValueToAbbrevs.Values.SelectMany(x => x).ToArray();
            }

            // Fall back to default culture
            return IsFallbackCulture
                ? new[] {$"(no abbreviations for {unitType.Name})"}
                : GetCached(FallbackCulture).GetAllAbbreviations(unitType);
        }

        private void LoadDefaultAbbreviations([NotNull] IFormatProvider culture)
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
        ///     Avoids having too many nested generics for code clarity
        /// </summary>
        private class AbbreviationMap : Dictionary<string, List<int>>
        {
        }

        /// <summary>
        ///     Get default(Type) of
        ///     <param name="type"></param>
        ///     .
        ///     Null for reference types, 0 for numeric types and default constructor for the rest.
        /// </summary>
        private static object GetDefault(Type type)
        {
            return type
                .IsValueType()
                ? Activator.CreateInstance(type)
                : null;
        }
    }
}
