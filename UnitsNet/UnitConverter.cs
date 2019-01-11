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
using System.Globalization;
using System.Linq;
using System.Reflection;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;
#if WINDOWS_UWP
using Culture = System.String;
using FromValue = System.Double;
#else
using Culture = System.IFormatProvider;
using FromValue = UnitsNet.QuantityValue;
#endif

namespace UnitsNet
{
    /// <summary>
    ///     Convert between units of a quantity, such as converting from meters to centimeters of a given length.
    /// </summary>
    public static class UnitConverter
    {
        private static readonly string QuantityNamespace = typeof(Length).Namespace;
        private static readonly string UnitTypeNamespace = typeof(LengthUnit).Namespace;
        private static readonly Assembly UnitsNetAssembly = typeof(Length).GetAssembly();

        /// <summary>
        ///     Convert between any two quantity units by their names, such as converting a "Length" of N "Meter" to "Centimeter".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="fromValue">
        ///     Input value, which together with <paramref name="fromUnit" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnit">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnit">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <example>double centimeters = ConvertByName(5, "Length", "Meter", "Centimeter"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnit" />.</returns>
        /// <exception cref="QuantityNotFoundException">No quantities were found that match <paramref name="quantityName" />.</exception>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbrevation.</exception>
        public static double ConvertByName(FromValue fromValue, string quantityName, string fromUnit, string toUnit)
        {
            if(!TryGetQuantityType(quantityName, out var quantityType))
                throw new QuantityNotFoundException($"The given quantity name was not found: {quantityName}");

            if(!TryGetUnitType(quantityName, out var unitType))
                throw new UnitNotFoundException($"The unit type for the given quantity was not found: {quantityName}");

            if(!TryParseUnit(unitType, fromUnit, out var fromUnitValue)) // ex: LengthUnit.Meter
            {
                var e = new UnitNotFoundException($"Unit not found [{fromUnit}].");
                e.Data["unitName"] = fromUnit;
                throw e;
            }

            if(!TryParseUnit(unitType, toUnit, out var toUnitValue)) // ex: LengthUnit.Centimeter
            {
                var e = new UnitNotFoundException($"Unit not found [{toUnit}].");
                e.Data["unitName"] = toUnit;
                throw e;
            }

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new[] {fromValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            return (double)asResult;
        }

        /// <summary>
        ///     Convert between any two quantity units by their names, such as converting a "Length" of N "Meter" to "Centimeter".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="inputValue">
        ///     Input value, which together with <paramref name="fromUnit" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnit">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnit">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>bool ok = TryConvertByName(5, "Length", "Meter", "Centimeter", out double centimeters); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByName(FromValue inputValue, string quantityName, string fromUnit, string toUnit, out double result)
        {
            result = 0d;

            if(!TryGetQuantityType(quantityName, out var quantityType))
                return false;

            if(!TryGetUnitType(quantityName, out var unitType))
                return false;

            if(!TryParseUnit(unitType, fromUnit, out var fromUnitValue)) // ex: LengthUnit.Meter
                return false;

            if(!TryParseUnit(unitType, toUnit, out var toUnitValue)) // ex: LengthUnit.Centimeter
                return false;

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new[] {inputValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            result = (double)asResult;
            return true;
        }

        /// <summary>
        ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="fromValue">
        ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
        public static double ConvertByAbbreviation(FromValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
        {
            // WindowsRuntimeComponent does not support default values on public methods
            // ReSharper disable once IntroduceOptionalParameters.Global
            return ConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, null);
        }

        /// <summary>
        ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="fromValue">
        ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="culture">Culture to parse abbreviations with.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
        /// <exception cref="QuantityNotFoundException">No quantity types match the <paramref name="quantityName"/>.</exception>
        /// <exception cref="UnitNotFoundException">No unit types match the prefix of <paramref name="quantityName"/> or no units are mapped to the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbrevation.</exception>
        public static double ConvertByAbbreviation(FromValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, string culture)
        {
            if(!TryGetQuantityType(quantityName, out var quantityType))
                throw new QuantityNotFoundException($"The given quantity name was not found: {quantityName}");

            if(!TryGetUnitType(quantityName, out var unitType))
                throw new UnitNotFoundException($"The unit type for the given quantity was not found: {quantityName}");

            var cultureInfo = string.IsNullOrWhiteSpace(culture)? GlobalConfiguration.DefaultCulture : new CultureInfo(culture);

            var fromUnitValue = UnitParser.Default.Parse(fromUnitAbbrev, unitType, cultureInfo); // ex: ("m", LengthUnit) => LengthUnit.Meter
            var toUnitValue = UnitParser.Default.Parse(toUnitAbbrev, unitType, cultureInfo); // ex:("cm", LengthUnit) => LengthUnit.Centimeter

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new[] {fromValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            return (double)asResult;
        }

        /// <summary>
        ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="fromValue">
        ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByAbbreviation(FromValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result)
        {
            return TryConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, out result, null);
        }

        /// <summary>
        ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
        ///     This is particularly useful for creating things like a generated unit conversion UI,
        ///     where you list some selectors:
        ///     a) Quantity: Length, Mass, Force etc.
        ///     b) From unit: Meter, Centimeter etc if Length is selected
        ///     c) To unit: Meter, Centimeter etc if Length is selected
        /// </summary>
        /// <param name="fromValue">
        ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">
        ///     Name of quantity, such as "Length" and "Mass". <see cref="QuantityType" /> for all
        ///     values.
        /// </param>
        /// <param name="fromUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="toUnitAbbrev">
        ///     Name of unit, such as "Meter" or "Centimeter" if "Length" was passed as
        ///     <paramref name="quantityName" />.
        /// </param>
        /// <param name="culture">Culture to parse abbreviations with.</param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByAbbreviation(FromValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result,
            string culture)
        {
            result = 0d;

            if(!TryGetQuantityType(quantityName, out var quantityType))
                return false;

            if(!TryGetUnitType(quantityName, out var unitType))
                return false;

            var cultureInfo = string.IsNullOrWhiteSpace(culture)? GlobalConfiguration.DefaultCulture : new CultureInfo(culture);

            if(!UnitParser.Default.TryParse(fromUnitAbbrev, unitType, cultureInfo, out var fromUnitValue)) // ex: ("m", LengthUnit) => LengthUnit.Meter
                return false;

            if(!UnitParser.Default.TryParse(toUnitAbbrev, unitType, cultureInfo, out var toUnitValue)) // ex:("cm", LengthUnit) => LengthUnit.Centimeter
                return false;

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new[] {fromValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            result = (double)asResult;
            return true;
        }

        private static MethodInfo GetAsMethod(Type quantityType, Type unitType)
        {
            // Only a single As() method as of this writing, but let's safe-guard a bit for future-proofing
            // ex: double result = quantity.As(LengthUnit outputUnit);
            return quantityType.GetDeclaredMethods()
                .Single(m => m.Name == "As" &&
                             !m.IsStatic &&
                             m.IsPublic &&
                             HasParameterTypes(m, unitType) &&
                             m.ReturnType == typeof(double));
        }

        private static MethodInfo GetStaticFromMethod(Type quantityType, Type unitType)
        {
            // Want to match: Length l = UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            // Do NOT match : Length? UnitsNet.Length.From(double? inputValue, LengthUnit inputUnit)
            return quantityType.GetDeclaredMethods()
                .Single(m => m.Name == "From" &&
                             m.IsStatic &&
                             m.IsPublic &&
                             HasParameterTypes(m, typeof(FromValue), unitType) &&
                             m.ReturnType == quantityType);
        }

        private static bool HasParameterTypes(MethodInfo methodInfo, params Type[] expectedTypes)
        {
            var parameters = methodInfo.GetParameters();
            if (parameters.Length != expectedTypes.Length)
                throw new ArgumentException($"The number of parameters {parameters.Length} did not match the number of types {expectedTypes.Length}.");

            for (var i = 0; i < parameters.Length; i++)
            {
                var p = parameters[i];
                var t = expectedTypes[i];
                if (p.ParameterType != t)
                    return false;
            }

            return true;
        }


        /// <summary>
        ///     Parse a unit by the unit enum type <paramref name="unitType" /> and a unit enum value <paramref name="unitName" />>
        /// </summary>
        /// <param name="unitType">Unit type, such as <see cref="LengthUnit" />.</param>
        /// <param name="unitName">Unit name, such as "Meter" corresponding to <see cref="LengthUnit.Meter" />.</param>
        /// <param name="unitValue">The return enum value, such as <see cref="LengthUnit.Meter" /> boxed as an object.</param>
        /// <returns>True if succeeded, otherwise false.</returns>
        /// <exception cref="UnitNotFoundException">No unit values match the <paramref name="unitName" />.</exception>
        private static bool TryParseUnit(Type unitType, string unitName, out object unitValue)
        {
            unitValue = null;

            if(!Enum.IsDefined(unitType, unitName))
                return false;

            unitValue = Enum.Parse(unitType, unitName);
            if(unitValue == null)
                return false;

            return true;
        }

        private static bool TryGetUnitType(string quantityName, out Type unitType)
        {
            string unitTypeName = $"{UnitTypeNamespace}.{quantityName}Unit";

            unitType = UnitsNetAssembly.GetType(unitTypeName); // ex: UnitsNet.Units.LengthUnit enum
            if(unitType == null)
                return false;

            return true;
        }

        private static bool TryGetQuantityType(string quantityName, out Type quantityType)
        {
            string quantityTypeName = $"{QuantityNamespace}.{quantityName}";

            quantityType = UnitsNetAssembly.GetType(quantityTypeName); // ex: UnitsNet.Length struct
            if(quantityType == null)
                return false;

            return true;
        }
    }
}
