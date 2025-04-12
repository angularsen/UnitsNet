// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using UnitsNet.InternalHelpers;
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
    public sealed class UnitConverter
    {
        /// <summary>
        ///     The default singleton instance for converting values from one unit to another.<br />
        ///     Modify this to add/remove conversion functions at runtime, such as adding your own third-party units and quantities to convert between.
        /// </summary>
        /// <remarks>
        ///     Convenience shortcut for <see cref="UnitsNetSetup"/>.<see cref="UnitsNetSetup.Default"/>.<see cref="UnitsNetSetup.UnitConverter"/>.
        /// </remarks>
        public static UnitConverter Default => UnitsNetSetup.Default.UnitConverter;

        /// <summary>
        /// Creates a new <see cref="UnitConverter"/> instance.
        /// </summary>
        public UnitConverter()
        {
            ConversionFunctions = new ConcurrentDictionary<ConversionFunctionLookupKey, ConversionFunction>();
        }

        /// <summary>
        /// Creates a new <see cref="UnitConverter"/> instance with the <see cref="ConversionFunction"/> copied from <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The <see cref="UnitConverter"/> to copy from.</param>
        public UnitConverter(UnitConverter other)
        {
            ConversionFunctions = new ConcurrentDictionary<ConversionFunctionLookupKey, ConversionFunction>(other.ConversionFunctions);
        }

        /// <summary>
        ///     Create an instance of the unit converter with all the built-in unit conversions defined in the library.
        /// </summary>
        /// <returns>The unit converter.</returns>
        public static UnitConverter CreateDefault()
        {
            var unitConverter = new UnitConverter();
            RegisterDefaultConversions(unitConverter);

            return unitConverter;
        }

        private ConcurrentDictionary<ConversionFunctionLookupKey, ConversionFunction> ConversionFunctions
        {
            get;
        }

        /// <summary>
        /// Registers the default conversion functions in the given <see cref="UnitConverter"/> instance.
        /// </summary>
        /// <param name="unitConverter">The <see cref="UnitConverter"/> to register the default conversion functions in.</param>
        public static void RegisterDefaultConversions(UnitConverter unitConverter)
        {
            if (unitConverter is null)
                throw new ArgumentNullException(nameof(unitConverter));

            foreach(var quantity in Quantity.GetQuantityTypes())
            {
                var registerMethod = quantity.GetMethod(nameof(Length.RegisterDefaultConversions), BindingFlags.NonPublic | BindingFlags.Static);
                registerMethod?.Invoke(null, new object[]{unitConverter});
            }
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
            ConversionFunctions[lookupKey] = conversionFunction;
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

            ConversionFunctions[conversionLookup] = TypelessConversionFunction;
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

            return ConversionFunctions[lookupKey];
        }

        /// <summary>
        /// Gets the conversion function for two units of the same quantity type.
        /// </summary>
        /// <typeparam name="TQuantity">The quantity type, must implement <see cref="IQuantity"/>.</typeparam>
        /// <param name="from">From unit enum value, such as <see cref="LengthUnit.Kilometer" />.</param>
        /// <param name="to">To unit enum value, such as <see cref="LengthUnit.Centimeter"/>.</param>
        /// <param name="conversionFunction">The quantity conversion function.</param>
        /// <returns>true if set; otherwise, false.</returns>
        public bool TryGetConversionFunction<TQuantity>(Enum from, Enum to, [NotNullWhen(true)] out ConversionFunction? conversionFunction) where TQuantity : IQuantity
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
        public bool TryGetConversionFunction<TQuantityFrom, TQuantityTo>(Enum from, Enum to, [NotNullWhen(true)] out ConversionFunction? conversionFunction)
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
        public bool TryGetConversionFunction(Type fromType, Enum from, Type toType, Enum to, [NotNullWhen(true)] out ConversionFunction? conversionFunction)
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
        public bool TryGetConversionFunction(ConversionFunctionLookupKey lookupKey, [NotNullWhen(true)] out ConversionFunction? conversionFunction)
        {
            return ConversionFunctions.TryGetValue(lookupKey, out conversionFunction);
        }

        /// <summary>
        ///     Convert between any two quantity units given a numeric value and two unit enum values.
        /// </summary>
        /// <param name="fromValue">Numeric value.</param>
        /// <param name="fromUnitValue">From unit enum value.</param>
        /// <param name="toUnitValue">To unit enum value, must be compatible with <paramref name="fromUnitValue" />.</param>
        /// <returns>The converted value in the new unit representation.</returns>
        public static double Convert(double fromValue, Enum fromUnitValue, Enum toUnitValue)
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
        public static bool TryConvert(double fromValue, Enum fromUnitValue, Enum toUnitValue, out double convertedValue)
        {
            convertedValue = 0;
            if (!Quantity.TryFrom(fromValue, fromUnitValue, out IQuantity? fromQuantity))
                return false;

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
        ///     Input value, which together with <paramref name="fromUnitName" /> represents the quantity to
        ///     convert from.
        /// </param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <param name="toUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "Meter", "Centimeter"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitName" />.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">No units match the provided unit name.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByName(double fromValue, string quantityName, string fromUnitName, string toUnitName)
        {
            QuantityInfoLookup quantities = UnitsNetSetup.Default.QuantityInfoLookup;
            UnitInfo fromUnit = quantities.GetUnitByName(quantityName, fromUnitName);
            UnitInfo toUnit = quantities.GetUnitByName(quantityName, toUnitName);
            return Quantity.From(fromValue, fromUnit.Value).As(toUnit.Value);
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnit">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <param name="toUnit">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>bool ok = TryConvertByName(5, "Length", "Meter", "Centimeter", out double centimeters); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByName(double inputValue, string quantityName, string fromUnit, string toUnit, out double result)
        {
            QuantityInfoLookup quantities = UnitsNetSetup.Default.QuantityInfoLookup;
            if (quantities.TryGetUnitByName(quantityName, fromUnit, out UnitInfo? fromUnitInfo) &&
                quantities.TryGetUnitByName(quantityName, toUnit, out UnitInfo? toUnitInfo) &&
                Quantity.TryFrom(inputValue, fromUnitInfo.Value, out IQuantity? quantity))
            {
                result = quantity.As(toUnitInfo.Value);
                return true;
            }
            
            result = 0d;
            return false;
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
        {
            return ConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, (CultureInfo?)null);
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="culture">Culture to parse abbreviations with.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        [Obsolete("Methods accepting a culture name are deprecated in favor of using an instance of the IFormatProvider.")]
        public static double ConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, string? culture)
        {
            return ConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, CultureHelper.GetCultureOrInvariant(culture));
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="culture">The unit localization culture. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public static double ConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, CultureInfo? culture)
        {
            QuantityInfoLookup quantities = UnitsNetSetup.Default.QuantityInfoLookup;
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;
            QuantityInfo quantityInfo = quantities.GetQuantityByName(quantityName);
            Enum fromUnit = unitParser.Parse(fromUnitAbbrev, quantityInfo.UnitType, culture); // ex: ("m", LengthUnit) => LengthUnit.Meter
            Enum toUnit = unitParser.Parse(toUnitAbbrev, quantityInfo.UnitType, culture); // ex:("cm", LengthUnit) => LengthUnit.Centimeter
            return Quantity.From(fromValue, fromUnit).As(toUnit);
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result)
        {
            return TryConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, out result, (CultureInfo?)null);
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="culture">Culture to parse abbreviations with.</param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        [Obsolete("Methods accepting a culture name are deprecated in favor of using an instance of the IFormatProvider.")]
        public static bool TryConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result,
            string? culture)
        {
            return TryConvertByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, out result, CultureHelper.GetCultureOrInvariant(culture));
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
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
        /// <param name="culture">The unit localization culture. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="result">Result if conversion was successful, 0 if not.</param>
        /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
        /// <returns>True if conversion was successful.</returns>
        public static bool TryConvertByAbbreviation(double fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out double result,
            CultureInfo? culture)
        {
            QuantityInfoLookup quantities = UnitsNetSetup.Default.QuantityInfoLookup;
            UnitParser unitParser = UnitsNetSetup.Default.UnitParser;
            if (!quantities.TryGetQuantityByName(quantityName, out QuantityInfo? quantityInfo) )
            {
                result = 0;
                return false;
            }

            if (!unitParser.TryParse(fromUnitAbbrev, quantityInfo.UnitType, culture, out Enum? fromUnit) ||
                !unitParser.TryParse(toUnitAbbrev, quantityInfo.UnitType, culture, out Enum? toUnit))
            {
                result = 0;
                return false;
            }

            result = Quantity.From(fromValue, fromUnit).As(toUnit);
            return true;

        }
    }
}

