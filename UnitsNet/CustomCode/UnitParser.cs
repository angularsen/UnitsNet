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
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public sealed class UnitParser
    {
        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;

        public static UnitParser Default { get; }

        public UnitParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
        }

        static UnitParser()
        {
            Default = new UnitParser(UnitAbbreviationsCache.Default);
        }

        /// <summary>
        /// Parses a unit abbreviation for a given unit enumeration type.
        /// Example: Parse&lt;LengthUnit&gt;("km") => LengthUnit.Kilometer
        /// </summary>
        /// <param name="unitAbbreviation"></param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <typeparam name="TUnitType"></typeparam>
        /// <returns></returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
            TUnitType Parse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return (TUnitType)Parse(unitAbbreviation, typeof(TUnitType));
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
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        object Parse([NotNull] string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider = null)
        {
            if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
            unitAbbreviation = unitAbbreviation.Trim();

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                throw new UnitNotFoundException($"No abbreviations defined for unit type [{unitType}] for culture [{formatProvider}].");

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation);

            switch (unitIntValues.Count)
            {
                case 1:
                    return unitIntValues[0];
                case 0:
                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{unitType}].");
                default:
                    string unitsCsv = string.Join(", ", unitIntValues.Select(x => Enum.GetName(unitType, x)).ToArray());
                    throw new AmbiguousUnitParseException(
                        $"Cannot parse \"{unitAbbreviation}\" since it could be either of these: {unitsCsv}");
            }
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            bool TryParse<TUnitType>(string unitAbbreviation, out TUnitType unit) where TUnitType : Enum
        {
            return TryParse(unitAbbreviation, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            bool TryParse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider, out TUnitType unit) where TUnitType : Enum
        {
            unit = default;

            if(!TryParse(unitAbbreviation, typeof(TUnitType), formatProvider, out var unitObj))
                return false;

            unit = (TUnitType)unitObj;
            return true;
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        public bool TryParse(string unitAbbreviation, Type unitType, out object unit)
        {
            return TryParse(unitAbbreviation, unitType, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        [PublicAPI]
#if WINDOWS_UWP
        internal
#else
        public
#endif
        bool TryParse(string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider, out object unit)
        {
            if (unitAbbreviation == null)
            {
                unit = default;
                return false;
            }

            unitAbbreviation = unitAbbreviation.Trim();
            unit = GetDefault(unitType);

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                return false;

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation);
            if(unitIntValues.Count != 1)
                return false;

            unit = unitIntValues[0];
            return true;
        }

        /// <summary>
        ///     Get default(Type) of
        ///     <param name="type"></param>
        ///     .
        ///     Null for reference types, 0 for numeric types and default constructor for the rest.
        /// </summary>
        private static object GetDefault(Type type)
        {
            return type.IsValueType() ? Activator.CreateInstance(type): null;
        }
    }
}
