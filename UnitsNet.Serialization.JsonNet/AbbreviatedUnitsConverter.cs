using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;
using UnitsNet.Units;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    ///     JSON.net converter for all <see cref="IQuantity" /> types (e.g. all units in UnitsNet)
    ///     Use this converter to serialize and deserialize UnitsNet types to and from JSON using the unit abbreviation schema.
    /// </summary>
    /// <example>
    /// <code>
    /// {
    ///     "Value": 1.20,
    ///     "Unit": "mg",
    ///     "Type": "Mass"
    /// }
    /// </code>
    /// </example>
    /// <inheritdoc />
    public class AbbreviatedUnitsConverter : JsonConverter<IQuantity>
    {
        private const string ValueProperty = "Value";
        private const string UnitProperty = "Unit";
        private const string TypeProperty = "Type";

        private readonly UnitAbbreviationsCache _abbreviations;
        private readonly IEqualityComparer<string?> _propertyComparer;
        private readonly IDictionary<string, QuantityInfo> _quantities;
        private readonly UnitParser _unitParser;

        /// <summary>
        ///     Construct a converter using the default list of quantities (case insensitive) and unit abbreviation provider
        /// </summary>
        public AbbreviatedUnitsConverter()
            : this(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        ///     Construct a converter using the default list of quantities and unit abbreviation provider
        /// </summary>
        /// <param name="comparer">The comparer used to compare the property/quantity names (e.g. StringComparer.OrdinalIgnoreCase) </param>
        public AbbreviatedUnitsConverter(IEqualityComparer<string?> comparer)
            : this(new Dictionary<string, QuantityInfo>(Quantity.ByName, comparer), UnitsNetSetup.Default.UnitAbbreviations, comparer)
        {
        }

        /// <summary>
        ///     Construct a converter using the provided map of {name : quantity}
        /// </summary>
        /// <param name="quantities">The dictionary of quantity names</param>
        /// <param name="abbreviations">The unit abbreviations used for the serialization </param>
        /// <param name="propertyComparer">The comparer used to compare the property names (e.g. StringComparer.OrdinalIgnoreCase) </param>
        public AbbreviatedUnitsConverter(IDictionary<string, QuantityInfo> quantities, UnitAbbreviationsCache abbreviations, IEqualityComparer<string?> propertyComparer)
        {
            _quantities = quantities;
            _abbreviations = abbreviations;
            _propertyComparer = propertyComparer;
            _unitParser = new UnitParser(abbreviations);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, IQuantity? quantity, JsonSerializer serializer)
        {
            if (quantity is null)
            {
                writer.WriteNull();
                return;
            }

            var unit = GetUnitAbbreviation(quantity.Unit); // by default this should be equal to quantity.ToString("a", CultureInfo.InvariantCulture);
            var quantityType = GetQuantityType(quantity); // by default this should be equal to quantity.QuantityInfo.Name

            writer.WriteStartObject();

            // write the 'Value' using the actual type
            writer.WritePropertyName(ValueProperty);
            if (quantity is IValueQuantity<decimal> decimalQuantity)
            {
                // cannot use `writer.WriteValue(decimalQuantity.Value)`: there is a hidden EnsureDecimalPlace(..) method call inside it that converts '123' to '123.0'
                writer.WriteRawValue(decimalQuantity.Value.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteValue((double)quantity.Value);
            }

            //  write the 'Unit' abbreviation
            writer.WritePropertyName(UnitProperty);
            writer.WriteValue(unit);

            // write the quantity 'Type'
            writer.WritePropertyName(TypeProperty);
            writer.WriteValue(quantityType);

            writer.WriteEndObject();
        }

        /// <summary>
        ///     Get the string representation associated with the given quantity
        /// </summary>
        /// <param name="quantity">The quantity that is being serialized</param>
        /// <returns>The string representation associated with the given quantity</returns>
        protected string GetQuantityType(IQuantity quantity)
        {
            return _quantities[quantity.QuantityInfo.Name].Name;
        }

        /// <inheritdoc />
        public override IQuantity? ReadJson(JsonReader reader, Type objectType, IQuantity? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            QuantityInfo? quantityInfo;
            if (reader.TokenType == JsonToken.Null)
            {
                return TryGetQuantity(objectType.Name, out quantityInfo) ? quantityInfo.Zero : default;
            }

            string? valueToken = null;
            string? unitAbbreviation = null, quantityName = null;
            if (reader.TokenType == JsonToken.StartObject)
            {
                while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = reader.Value as string;
                        if (_propertyComparer.Equals(propertyName, ValueProperty))
                        {
                            valueToken = reader.ReadAsString();
                        }
                        else if (_propertyComparer.Equals(propertyName, UnitProperty))
                        {
                            unitAbbreviation = reader.ReadAsString();
                        }
                        else if (_propertyComparer.Equals(propertyName, TypeProperty))
                        {
                            quantityName = reader.ReadAsString();
                        }
                        else
                        {
                            reader.Skip();
                        }
                    }
                }
            }


            Enum unit;
            if (quantityName is null)
            {
                if (TryGetQuantity(objectType.Name, out quantityInfo))
                {
                    unit = GetUnitOrDefault(unitAbbreviation, quantityInfo);
                }
                else if (unitAbbreviation != null) // the objectType doesn't match any concrete quantity type (likely it is an IQuantity)
                {
                    // failing back to an exhaustive search (it is possible that this converter was created with a short-list of non-ambiguous quantities
                    unit = FindUnit(unitAbbreviation, out quantityInfo);
                }
                else
                {
                    throw new FormatException("No unit abbreviation found in JSON.");
                }
            }
            else
            {
                quantityInfo = GetQuantityInfo(quantityName);
                unit = GetUnitOrDefault(unitAbbreviation, quantityInfo);
            }

            QuantityValue value;
            if (valueToken is null)
            {
                value = default;
            }
            else if (quantityInfo.Zero is IValueQuantity<decimal>)
            {
                value = decimal.Parse(valueToken, CultureInfo.InvariantCulture);
            }
            else
            {
                value = double.Parse(valueToken, CultureInfo.InvariantCulture);
            }

            return Quantity.From(value, unit);
        }

        /// <summary>
        ///     Attempt to find an a unique (non-ambiguous) unit matching the provided abbreviation.
        ///     <remarks>
        ///         An exhaustive search using all quantities is very likely to fail with an
        ///         <exception cref="AmbiguousUnitParseException" />, so make sure you're using the minimum set of supported quantities.
        ///     </remarks>
        /// </summary>
        /// <param name="unitAbbreviation">The unit abbreviation </param>
        /// <param name="quantityInfo">The quantity type where the resulting unit was found </param>
        /// <returns>The unit associated with the given <paramref name="unitAbbreviation" /></returns>
        /// <exception cref="AmbiguousUnitParseException"></exception>
        /// <exception cref="UnitNotFoundException"></exception>
        protected virtual Enum FindUnit(string unitAbbreviation, out QuantityInfo quantityInfo)
        {
            if (unitAbbreviation is null) // we could assume string.Empty instead
            {
                throw new UnitNotFoundException("The unit abbreviation and quantity type cannot both be null");
            }

            Enum? unit = null;
            QuantityInfo? tempQuantityInfo = default;
            foreach (var targetQuantity in _quantities.Values)
            {
                if (!TryParse(unitAbbreviation, targetQuantity, out var unitMatched))
                {
                    continue;
                }

                if (unit != null &&
                    !(targetQuantity == tempQuantityInfo && Equals(unit, unitMatched))) // it is possible to have "synonyms": e.g. "Mass" and "Weight"
                {
                    throw new AmbiguousUnitParseException($"Multiple quantities found matching the provided abbreviation: {unit}, {unitMatched}");
                }

                tempQuantityInfo = targetQuantity;
                unit = unitMatched;
            }

            if (unit is null || tempQuantityInfo is null)
            {
                throw new UnitNotFoundException($"No quantity found with abbreviation [{unitAbbreviation}].");
            }

            quantityInfo = tempQuantityInfo;
            return unit;
        }


        /// <summary>
        ///     Get the unit abbreviation associated with the given unit
        /// </summary>
        /// <param name="unit">Unit enum value, such as <see cref="MassUnit.Kilogram" />.</param>
        /// <returns>The default abbreviation as provided by the associated <see cref="UnitAbbreviationsCache" /></returns>
        protected string GetUnitAbbreviation(Enum unit)
        {
            return _abbreviations.GetDefaultAbbreviation(unit.GetType(), Convert.ToInt32(unit), CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     If the unit abbreviation is unspecified: returns the default (BaseUnit) unit for the
        ///     <paramref name="quantityInfo" />, otherwise attempts to <see cref="Parse" /> the
        ///     <paramref name="unitAbbreviation" />
        /// </summary>
        /// <param name="unitAbbreviation">
        ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
        ///     <see cref="LengthUnit.Meter" /> respectively.
        /// </param>
        /// <param name="quantityInfo">The associated quantity info</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        protected virtual Enum GetUnitOrDefault(string? unitAbbreviation, QuantityInfo quantityInfo)
        {
            return unitAbbreviation == null
                ? quantityInfo.BaseUnitInfo.Value
                : _unitParser.Parse(unitAbbreviation, quantityInfo.UnitType, CultureInfo.InvariantCulture);
        }

        /// <param name="unitAbbreviation">
        ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
        ///     <see cref="LengthUnit.Meter" /> respectively.
        /// </param>
        /// <param name="quantityInfo">The associated quantity info</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        protected Enum Parse(string? unitAbbreviation, QuantityInfo quantityInfo)
        {
            return _unitParser.Parse(unitAbbreviation, quantityInfo.UnitType, CultureInfo.InvariantCulture);
        }

        /// <param name="unitAbbreviation">
        ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
        ///     <see cref="LengthUnit.Meter" /> respectively.
        /// </param>
        /// <param name="quantityInfo">The associated quantity info</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        protected bool TryParse(string? unitAbbreviation, QuantityInfo quantityInfo, [NotNullWhen(true)] out Enum? unit)
        {
            return _unitParser.TryParse(unitAbbreviation, quantityInfo.UnitType, CultureInfo.InvariantCulture, out unit);
        }

        /// <summary>
        ///     Try to get the quantity info associated with a given quantity name
        /// </summary>
        /// <param name="quantityName">The name of the quantity: i.e. <see cref="QuantityInfo.Name" /></param>
        /// <param name="quantityInfo">The quantity information associated with the given quantity name</param>
        /// <returns>
        ///     <value>true</value>
        ///     if a matching quantity is found or
        ///     <value>false</value>
        ///     otherwise
        /// </returns>
        protected bool TryGetQuantity(string quantityName, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
        {
            return _quantities.TryGetValue(quantityName, out quantityInfo);
        }

        /// <summary>
        ///     Get the quantity info associated with a given quantity name
        /// </summary>
        /// <param name="quantityName">The name of the quantity: i.e. <see cref="QuantityInfo.Name" /></param>
        /// <returns>
        ///     <value>true</value>
        ///     if a matching quantity is found or
        ///     <value>false</value>
        ///     otherwise
        /// </returns>
        /// <exception cref="UnitsNetException">Quantity not found exception is thrown if no match found</exception>
        protected QuantityInfo GetQuantityInfo(string quantityName)
        {
            if (!TryGetQuantity(quantityName, out var quantityInfo))
            {
                throw new UnitsNetException($"Failed to find the quantity type: {quantityName}.") { Data = { ["type"] = quantityName } };
            }

            return quantityInfo;
        }
    }
}
