// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Convert between units of a quantity, such as converting from meters to centimeters of a given length.
    /// </summary>
    [PublicAPI]
    public static class UnitConverter
    {
        private static readonly string UnitTypeNamespace = typeof(LengthUnit).Namespace;
        private static readonly Assembly UnitsNetAssembly = typeof(Length).Wrap().Assembly;

        private static readonly Type[] QuantityTypes = UnitsNetAssembly.GetTypes()
            .Where(typeof(IQuantity).Wrap().IsAssignableFrom)
            .Where(x => x.Wrap().IsClass || x.Wrap().IsValueType) // Future-proofing: we are discussing changing quantities from struct to class
            .ToArray();

        private static readonly Type[] UnitTypes = UnitsNetAssembly.GetTypes()
            .Where(x => x.Namespace == UnitTypeNamespace && x.Wrap().IsEnum && x.Name.EndsWith("Unit"))
            .ToArray();

        /// <summary>
        ///     Convert between any two quantity units given a numeric value and two unit enum values.
        /// </summary>
        /// <param name="fromValue">Numeric value.</param>
        /// <param name="fromUnitValue">From unit enum value.</param>
        /// <param name="toUnitValue">To unit enum value, must be compatible with <paramref name="fromUnitValue" />.</param>
        /// <returns>The converted value in the new unit representation.</returns>
        internal static double Convert(double fromValue, Enum fromUnitValue, Enum toUnitValue)
        {
            return Quantity
                .From(fromValue, fromUnitValue)
                .As(toUnitValue);
        }

        /// <summary>
        ///     Try to convert between any two quantity units given a numeric value and two unit enum values.
        /// </summary>
        /// <param name="fromValue">Numeric value.</param>
        /// <param name="fromUnitValue">From unit enum value.</param>
        /// <param name="toUnitValue">To unit enum value, must be compatible with <paramref name="fromUnitValue" />.</param>
        /// <param name="convertedValue">The converted value, if successful. Otherwise default.</param>
        /// <returns>True if successful.</returns>
        internal static bool TryConvert(double fromValue, Enum fromUnitValue, Enum toUnitValue, out double convertedValue)
        {
            convertedValue = 0;
            if (!Quantity.TryFrom(fromValue, fromUnitValue, out IQuantity from)) return false;

            try
            {
                // We're not going to implement TryAs() in all quantities, so let's just try-catch here
                convertedValue = from.As(toUnitValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

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
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByName(double fromValue, string quantityName, string fromUnit, string toUnit)
        {
            if (!TryGetUnitType(quantityName, out Type unitType))
                throw new UnitNotFoundException($"The unit type for the given quantity was not found: {quantityName}");

            if (!TryParseUnit(unitType, fromUnit, out Enum fromUnitValue)) // ex: LengthUnit.Meter
            {
                var e = new UnitNotFoundException($"Unit not found [{fromUnit}].");
                e.Data["unitName"] = fromUnit;
                throw e;
            }

            if (!TryParseUnit(unitType, toUnit, out Enum toUnitValue)) // ex: LengthUnit.Centimeter
            {
                var e = new UnitNotFoundException($"Unit not found [{toUnit}].");
                e.Data["unitName"] = toUnit;
                throw e;
            }

            return Convert(fromValue, fromUnitValue, toUnitValue);
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
        public static bool TryConvertByName(double inputValue, string quantityName, string fromUnit, string toUnit, out double result)
        {
            result = 0d;

            if (!TryGetUnitType(quantityName, out var unitType))
                return false;

            if (!TryParseUnit(unitType, fromUnit, out var fromUnitValue)) // ex: LengthUnit.Meter
                return false;

            if (!TryParseUnit(unitType, toUnit, out var toUnitValue)) // ex: LengthUnit.Centimeter
                return false;

            result = Convert(inputValue, fromUnitValue, toUnitValue);
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
        public static double ConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
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
        /// <exception cref="QuantityNotFoundException">No quantity types match the <paramref name="quantityName" />.</exception>
        /// <exception cref="UnitNotFoundException">
        ///     No unit types match the prefix of <paramref name="quantityName" /> or no units
        ///     are mapped to the abbreviation.
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, string culture)
        {
            if (!TryGetQuantityType(quantityName, out var quantityType))
                throw new QuantityNotFoundException($"The given quantity name was not found: {quantityName}");

            if (!TryGetUnitType(quantityName, out var unitType))
                throw new UnitNotFoundException($"The unit type for the given quantity was not found: {quantityName}");

            var cultureInfo = string.IsNullOrWhiteSpace(culture) ? GlobalConfiguration.DefaultCulture : new CultureInfo(culture);

            var fromUnitValue = UnitParser.Default.Parse(fromUnitAbbrev, unitType, cultureInfo); // ex: ("m", LengthUnit) => LengthUnit.Meter
            var toUnitValue = UnitParser.Default.Parse(toUnitAbbrev, unitType, cultureInfo); // ex:("cm", LengthUnit) => LengthUnit.Centimeter

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new object[] {fromValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new object[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            return (double) asResult;
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
        public static bool TryConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result)
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
        public static bool TryConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result,
            string culture)
        {
            result = 0d;

            if (!TryGetQuantityType(quantityName, out var quantityType))
                return false;

            if (!TryGetUnitType(quantityName, out var unitType))
                return false;

            var cultureInfo = string.IsNullOrWhiteSpace(culture) ? GlobalConfiguration.DefaultCulture : new CultureInfo(culture);

            if (!UnitParser.Default.TryParse(fromUnitAbbrev, unitType, cultureInfo, out var fromUnitValue)) // ex: ("m", LengthUnit) => LengthUnit.Meter
                return false;

            if (!UnitParser.Default.TryParse(toUnitAbbrev, unitType, cultureInfo, out var toUnitValue)) // ex:("cm", LengthUnit) => LengthUnit.Centimeter
                return false;

            var fromMethod = GetStaticFromMethod(quantityType, unitType); // ex: UnitsNet.Length.From(double inputValue, LengthUnit inputUnit)
            var fromResult = fromMethod.Invoke(null, new object[] {fromValue, fromUnitValue}); // ex: Length quantity = UnitsNet.Length.From(5, LengthUnit.Meter)

            var asMethod = GetAsMethod(quantityType, unitType); // ex: quantity.As(LengthUnit outputUnit)
            var asResult = asMethod.Invoke(fromResult, new object[] {toUnitValue}); // ex: double outputValue = quantity.As(LengthUnit.Centimeter)

            result = (double) asResult;
            return true;
        }

        private static MethodInfo GetAsMethod(Type quantityType, Type unitType)
        {
            // Only a single As() method as of this writing, but let's safe-guard a bit for future-proofing
            // ex: double result = quantity.As(LengthUnit outputUnit);
            return quantityType.Wrap().GetDeclaredMethods()
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
            return quantityType.Wrap().GetDeclaredMethods()
                .Single(m => m.Name == "From" &&
                             m.IsStatic &&
                             m.IsPublic &&
                             HasParameterTypes(m, typeof(double), unitType) &&
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
        private static bool TryParseUnit(Type unitType, string unitName, out Enum unitValue)
        {
            unitValue = null;
            var eNames = Enum.GetNames(unitType);
            unitName = eNames.FirstOrDefault(x => x.Equals(unitName, StringComparison.OrdinalIgnoreCase));
            if (unitName == null)
                return false;

            unitValue = (Enum) Enum.Parse(unitType, unitName);
            return true;
        }

        private static bool TryGetUnitType(string quantityName, out Type unitType)
        {
            var unitTypeName = quantityName + "Unit"; // ex. LengthUnit

            unitType = UnitTypes.FirstOrDefault(x =>
                x.Name.Equals(unitTypeName, StringComparison.OrdinalIgnoreCase));

            return unitType != null;
        }

        private static bool TryGetQuantityType(string quantityName, out Type quantityType)
        {
            quantityType = QuantityTypes.FirstOrDefault(x => x.Name.Equals(quantityName, StringComparison.OrdinalIgnoreCase));

            return quantityType != null;
        }
    }
}
