using System.Globalization;

namespace UnitsNet
{
    public static partial class Quantity
    {
        private static QuantityInfoLookup Quantities => UnitsNetSetup.Default.QuantityInfoLookup;
        private static QuantityParser QuantityParser => UnitsNetSetup.Default.QuantityParser;
        private static UnitParser UnitParser => UnitsNetSetup.Default.UnitParser;

        /// <summary>
        /// All quantity names, such as "Length" and "Mass", that are present in the <see cref="UnitsNetSetup.Default"/> configuration.
        /// </summary>
        public static IReadOnlyCollection<string> Names => Quantities.Names;

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>, that are present in the <see cref="UnitsNetSetup.Default"/> configuration.
        /// </summary>
        public static IReadOnlyList<QuantityInfo> Infos => Quantities.Infos;
        
        /// <summary>
        /// All QuantityInfo instances mapped by quantity name that are present in the <see cref="UnitsNetSetup.Default"/> configuration.
        /// </summary>
        public static IReadOnlyDictionary<string, QuantityInfo> ByName => Quantities.ByName;

        /// <summary>
        /// Get <see cref="UnitInfo{TQuantity,TUnit}"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(UnitKey unitEnum) => Quantities.GetUnitInfo(unitEnum);

        /// <summary>
        /// Try to get <see cref="UnitInfo{TQuantity,TUnit}"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(UnitKey unitEnum, [NotNullWhen(true)] out UnitInfo? unitInfo)
        {
            return Quantities.TryGetUnitInfo(unitEnum, out unitInfo);
        }
        
        /// <summary>
        ///     Dynamically constructs a quantity from a numeric value and a unit enum value.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit value is not a known unit enum type.</exception>
        public static IQuantity From(double value, UnitKey unit)
        {
            return Quantities.From(value, unit);
        }

        /// <summary>
        ///     Dynamically construct a quantity from a value, the quantity name and the unit name.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="unitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when no quantity information is found for the specified quantity name.
        /// </exception>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when no unit is found for the specified quantity name and unit name.
        /// </exception>
        public static IQuantity From(double value, string quantityName, string unitName)
        {
            return Quantities.GetUnitByName(quantityName, unitName).From(value);
        }

        /// <summary>
        ///     Dynamically constructs a quantity of the given <see cref="QuantityInfo" /> with the value in the quantity's base
        ///     units.
        /// </summary>
        /// <param name="quantityInfo">The <see cref="QuantityInfo" /> of the quantity to create.</param>
        /// <param name="value">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
        /// <remarks>
        ///     This is the equivalent to:
        ///     <code>quantityInfo.From(value, quantityInfo.BaseUnitInfo.Value)</code>
        ///     or
        ///     <code>quantityInfo.BaseUnitInfo.From(value)</code>
        /// </remarks>
        [Obsolete("Consider using: quantityInfo.BaseUnitInfo.From(value)")]
        public static IQuantity FromQuantityInfo(QuantityInfo quantityInfo, double value)
        {
            return quantityInfo.BaseUnitInfo.From(value);
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,UnitKey)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(double value, string unitAbbreviation) => FromUnitAbbreviation(null, value, unitAbbreviation);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,UnitKey)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="UnitNotFoundException">Unit abbreviation is not known.</exception>
        /// <exception cref="AmbiguousUnitParseException">Multiple units found matching the given unit abbreviation.</exception>
        public static IQuantity FromUnitAbbreviation(IFormatProvider? formatProvider, double value, string unitAbbreviation)
        {
            return UnitParser.FromUnitAbbreviation(value, unitAbbreviation, formatProvider);
        }

        /// <summary>
        ///     Try to dynamically construct a quantity from a value, the quantity name and the unit name.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
        /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
        /// <param name="quantity">The constructed quantity, if successful, otherwise null.</param>
        /// <returns><c>True</c> if successful with <paramref name="quantity"/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(double value, string quantityName, string unitName, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (!Quantities.TryGetUnitByName(quantityName, unitName, out UnitInfo? unitInfo))
            {
                quantity = null;
                return false;
            }

            quantity = unitInfo.From(value);
            return true;
        }

        /// <summary>
        ///     Attempts to create a quantity from the specified value and unit.
        /// </summary>
        /// <param name="value">The value of the quantity.</param>
        /// <param name="unit">The unit of the quantity, represented as an <see cref="Enum" />.</param>
        /// <param name="quantity">
        ///     When this method returns, contains the created quantity if the conversion succeeded,
        ///     or <c>null</c> if the conversion failed. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the quantity was successfully created; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryFrom(double value, Enum? unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            return Quantities.TryFrom(value, unit, out quantity);
        }

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation using <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,UnitKey)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(double value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity) =>
            TryFromUnitAbbreviation(null, value, unitAbbreviation, out quantity);

        /// <summary>
        ///     Dynamically construct a quantity from a numeric value and a unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations each time.<br/>
        ///     Unit abbreviation matching is case-insensitive.<br/>
        ///     <br/>
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br/>
        ///     Prefer <see cref="From(double,UnitKey)"/> or <see cref="From(double,string,string)"/> instead.
        /// </remarks>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="value">Numeric value.</param>
        /// <param name="unitAbbreviation">Unit abbreviation, such as "kg" for <see cref="MassUnit.Kilogram"/>.</param>
        /// <param name="quantity">The quantity if successful, otherwise null.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentException">Unit value is not a known unit enum type.</exception>
        public static bool TryFromUnitAbbreviation(IFormatProvider? formatProvider, double value, string unitAbbreviation, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (UnitParser.TryGetUnitFromAbbreviation(unitAbbreviation, formatProvider, out UnitInfo? unitInfo))
            {
                quantity = unitInfo.From(value);
                return true;
            }

            quantity = null;
            return false;
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the <paramref name="quantityType" /> is not of type <see cref="IQuantity" />.
        /// </exception>
        /// <exception cref="QuantityNotFoundException">
        ///     Thrown when the specified quantity type is not registered in the current configuration.
        /// </exception>
        /// <exception cref="FormatException">Thrown when the <paramref name="quantityString"/> is not in the expected format.</exception>
        public static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            QuantityInfo quantityInfo = Quantities.GetQuantityInfo(quantityType);
            return QuantityParser.Parse(quantityString, formatProvider, quantityInfo);
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            return TryParse(null, quantityType, quantityString, out quantity);
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (Quantities.TryGetQuantityInfo(quantityType, out QuantityInfo? quantityInfo))
            {
                return QuantityParser.TryParse(quantityString, formatProvider, quantityInfo, out quantity);
            }

            quantity = null;
            return false;
        }

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return Infos.GetQuantitiesWithBaseDimensions(baseDimensions);
        }
    }
}
