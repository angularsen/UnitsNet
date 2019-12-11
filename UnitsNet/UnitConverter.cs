// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
    using ConversionFunctionLookupKey = ValueTuple<Type, Enum, Type, Enum>;

    /// <summary>
    ///
    /// </summary>
    /// <param name="inputValue"></param>
    /// <returns></returns>
    public delegate IQuantity ConversionFunction(IQuantity inputValue);

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TQuantity"></typeparam>
    /// <param name="inputValue"></param>
    /// <returns></returns>
    public delegate TQuantity ConversionFunction<TQuantity>(TQuantity inputValue)
        where TQuantity : IQuantity;

    /// <summary>
    ///     Convert between units of a quantity, such as converting from meters to centimeters of a given length.
    /// </summary>
    [PublicAPI]
    public sealed partial class UnitConverter
    {
        /// <summary>
        /// The static instance used by Units.NET to convert between units. Modify this to add/remove conversion functions at runtime, such
        /// as adding your own third-party units and quantities to convert between.
        /// </summary>
        public static UnitConverter Default { get; }

        private readonly Dictionary<ConversionFunctionLookupKey, ConversionFunction> _conversionFunctions = new Dictionary<ConversionFunctionLookupKey, ConversionFunction>();

        static UnitConverter()
        {
            Default = new UnitConverter();
            RegisterDefaultConversions(Default);
        }

        /// <summary>
        /// Sets the conversion function from two units of the same quantity type.
        /// </summary>
        /// <typeparam name="TQuantity">The type of quantity, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        public void SetConversionFunction<TQuantity>(Enum from, Enum to, ConversionFunction<TQuantity> conversionFunction)
            where TQuantity : IQuantity
        {
            var quantityType = typeof(TQuantity);
            var conversionLookup = new ConversionFunctionLookupKey(quantityType, from, quantityType, to);
            SetConversionFunction(conversionLookup, conversionFunction);
        }

        /// <summary>
        /// Sets the conversion function from two units of different quantity types.
        /// </summary>
        /// <typeparam name="TQuantityFrom">From quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <typeparam name="TQuantityTo">To quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        public void SetConversionFunction<TQuantityFrom, TQuantityTo>(Enum from, Enum to, ConversionFunction conversionFunction)
            where TQuantityFrom : IQuantity
            where TQuantityTo : IQuantity
        {
            SetConversionFunction(typeof(TQuantityFrom), from, typeof(TQuantityTo), to, conversionFunction);
        }

        /// <summary>
        /// Sets the conversion function from two units of different quantity types.
        /// </summary>
        /// <param name="fromType">From quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="toType">To quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        public void SetConversionFunction(Type fromType, Enum from, Type toType, Enum to, ConversionFunction conversionFunction)
        {
            var conversionLookup = new ConversionFunctionLookupKey(fromType, from, toType, to);
            SetConversionFunction(conversionLookup, conversionFunction);
        }

        /// <summary>
        /// Sets the conversion function for a particular conversion function lookup.
        /// </summary>
        /// <param name="lookupKey">The lookup key.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        internal void SetConversionFunction(ConversionFunctionLookupKey lookupKey, ConversionFunction conversionFunction)
        {
            _conversionFunctions[lookupKey] = conversionFunction;
        }

        /// <summary>
        /// Sets the conversion function for a particular conversion function lookup.
        /// </summary>
        /// <typeparam name="TQuantity">The quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="conversionLookup">The quantity conversion function lookup key.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        internal void SetConversionFunction<TQuantity>(ConversionFunctionLookupKey conversionLookup, ConversionFunction<TQuantity> conversionFunction)
            where TQuantity : IQuantity
        {
            IQuantity TypelessConversionFunction(IQuantity quantity) => conversionFunction((TQuantity) quantity);

            _conversionFunctions[conversionLookup] = TypelessConversionFunction;
        }

        /// <summary>
        /// Gets the conversion function from two units of the same quantity type.
        /// </summary>
        /// <typeparam name="TQuantity">The quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <returns></returns>
        public ConversionFunction GetConversionFunction<TQuantity>(Enum from, Enum to) where TQuantity : IQuantity
        {
            return GetConversionFunction(typeof(TQuantity), from, typeof(TQuantity), to);
        }

        /// <summary>
        /// Gets the conversion function from two units of different quantity types.
        /// </summary>
        /// <typeparam name="TQuantityFrom">From quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <typeparam name="TQuantityTo">To quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <returns></returns>
        public ConversionFunction GetConversionFunction<TQuantityFrom, TQuantityTo>(Enum from, Enum to)
            where TQuantityFrom : IQuantity
            where TQuantityTo : IQuantity
        {
            return GetConversionFunction(typeof(TQuantityFrom), from, typeof(TQuantityTo), to);
        }

        /// <summary>
        /// Gets the conversion function from two units of different quantity types.
        /// </summary>
        /// <param name="fromType">From quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="toType">To quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        public ConversionFunction GetConversionFunction(Type fromType, Enum from, Type toType, Enum to)
        {
            var conversionLookup = new ConversionFunctionLookupKey(fromType, from, toType, to);
            return GetConversionFunction(conversionLookup);
        }

        /// <summary>
        /// Gets the conversion function by its lookup key.
        /// </summary>
        /// <param name="lookupKey"></param>
        internal ConversionFunction GetConversionFunction(ConversionFunctionLookupKey lookupKey)
        {
            IQuantity EchoFunction(IQuantity fromQuantity) => fromQuantity;

            // If from/to units and to quantity types are equal, then return a function that echoes the input quantity
            // in order to not have to map conversion functions to "self".
            if (lookupKey.Item1 == lookupKey.Item3 && Equals(lookupKey.Item2, lookupKey.Item4))
                return EchoFunction;

            return _conversionFunctions[lookupKey];
        }

        /// <summary>
        /// Gets the conversion function for two units of the same quantity type.
        /// </summary>
        /// <typeparam name="TQuantity">The quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        /// <returns>true if set; otherwise, false.</returns>
        public bool TryGetConversionFunction<TQuantity>(Enum from, Enum to, out ConversionFunction conversionFunction) where TQuantity : IQuantity
        {
            return TryGetConversionFunction(typeof(TQuantity), from, typeof(TQuantity), to, out conversionFunction);
        }

        /// <summary>
        /// Gets the conversion function for two units of different quantity types.
        /// </summary>
        /// <typeparam name="TQuantityFrom">From quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <typeparam name="TQuantityTo">To quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        /// <returns>true if set; otherwise, false.</returns>
        public bool TryGetConversionFunction<TQuantityFrom, TQuantityTo>(Enum from, Enum to, out ConversionFunction conversionFunction)
            where TQuantityFrom : IQuantity
            where TQuantityTo : IQuantity
        {
            return TryGetConversionFunction(typeof(TQuantityFrom), from, typeof(TQuantityTo), to, out conversionFunction);
        }

        /// <summary>
        /// Try to get the conversion function for two units of the same quantity type.
        /// </summary>
        /// <param name="fromType">From quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="toType">To quantity type, must implement <see cref="IQuantity"/>.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        /// <returns>true if set; otherwise, false.</returns>
        public bool TryGetConversionFunction(Type fromType, Enum from, Type toType, Enum to, out ConversionFunction conversionFunction)
        {
            var conversionLookup = new ConversionFunctionLookupKey(fromType, from, toType, to);
            return TryGetConversionFunction(conversionLookup, out conversionFunction);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lookupKey"></param>
        /// <param name="conversionFunction"></param>
        /// <returns>true if set; otherwise, false.</returns>
        public bool TryGetConversionFunction(ConversionFunctionLookupKey lookupKey, out ConversionFunction conversionFunction)
        {
            return _conversionFunctions.TryGetValue(lookupKey, out conversionFunction);
        }

        /// <summary>
        ///     Convert between any two quantity units given a numeric value and two unit enum values.
        /// </summary>
        /// <param name="fromValue">Numeric value.</param>
        /// <param name="fromUnitValue">From unit enum value.</param>
        /// <param name="toUnitValue">To unit enum value, must be compatible with <paramref name="fromUnitValue" />.</param>
        /// <returns>The converted value in the new unit representation.</returns>
        public static double Convert(QuantityValue fromValue, Enum fromUnitValue, Enum toUnitValue)
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
        public static bool TryConvert(QuantityValue fromValue, Enum fromUnitValue, Enum toUnitValue, out double convertedValue)
        {
            convertedValue = 0;
            if (!Quantity.TryFrom(fromValue, fromUnitValue, out IQuantity fromQuantity)) return false;

            try
            {
                // We're not going to implement TryAs() in all quantities, so let's just try-catch here
                convertedValue = fromQuantity.As(toUnitValue);
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
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByName(QuantityValue fromValue, string quantityName, string fromUnit, string toUnit)
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
        public static bool TryConvertByName(QuantityValue inputValue, string quantityName, string fromUnit, string toUnit, out double result)
        {
            result = 0d;

            if (!TryGetUnitType(quantityName, out Type unitType))
                return false;

            if (!TryParseUnit(unitType, fromUnit, out Enum fromUnitValue)) // ex: LengthUnit.Meter
                return false;

            if (!TryParseUnit(unitType, toUnit, out Enum toUnitValue)) // ex: LengthUnit.Centimeter
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
        public static double ConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
        {
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
        /// <exception cref="UnitNotFoundException">
        ///     No unit types match the prefix of <paramref name="quantityName" /> or no units
        ///     are mapped to the abbreviation.
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, string culture)
        {
            if (!TryGetUnitType(quantityName, out Type unitType))
                throw new UnitNotFoundException($"The unit type for the given quantity was not found: {quantityName}");

            var cultureInfo = string.IsNullOrWhiteSpace(culture) ? CultureInfo.CurrentUICulture : new CultureInfo(culture);

            var fromUnit = UnitParser.Default.Parse(fromUnitAbbrev, unitType, cultureInfo); // ex: ("m", LengthUnit) => LengthUnit.Meter
            var fromQuantity = Quantity.From(fromValue, fromUnit);

            var toUnit = UnitParser.Default.Parse(toUnitAbbrev, unitType, cultureInfo); // ex:("cm", LengthUnit) => LengthUnit.Centimeter
            return fromQuantity.As(toUnit);
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
        public static bool TryConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result)
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
        public static bool TryConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result,
            string culture)
        {
            result = 0d;

            if (!TryGetUnitType(quantityName, out Type unitType))
                return false;

            var cultureInfo = string.IsNullOrWhiteSpace(culture) ? CultureInfo.CurrentUICulture : new CultureInfo(culture);

            if (!UnitParser.Default.TryParse(fromUnitAbbrev, unitType, cultureInfo, out Enum fromUnit)) // ex: ("m", LengthUnit) => LengthUnit.Meter
                return false;

            if (!UnitParser.Default.TryParse(toUnitAbbrev, unitType, cultureInfo, out Enum toUnit)) // ex:("cm", LengthUnit) => LengthUnit.Centimeter
                return false;

            var fromQuantity = Quantity.From(fromValue, fromUnit);
            result = fromQuantity.As(toUnit);

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
            var quantityInfo = Quantity.Infos.FirstOrDefault((info) => info.Name.Equals(quantityName, StringComparison.OrdinalIgnoreCase));

            unitType = quantityInfo?.UnitType;
            return quantityInfo != null;
        }
    }
}

