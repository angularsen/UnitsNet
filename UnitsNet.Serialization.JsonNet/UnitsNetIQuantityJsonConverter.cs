// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitsNet.Serialization.JsonNet
{
    /// <inheritdoc />
    /// <summary>
    /// JSON.net converter for IQuantity types (e.g. all units in UnitsNet)
    /// Use this converter to serialize and deserialize UnitsNet types to and from JSON
    /// </summary>
    public sealed class UnitsNetIQuantityJsonConverter : UnitsNetBaseJsonConverter<IQuantity?>
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, IQuantity? value, JsonSerializer serializer)
        {
            writer = writer ?? throw new ArgumentNullException(nameof(writer));
            serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));

            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var valueUnit = ConvertIQuantity(value);

            serializer.Serialize(writer, valueUnit);
        }

        private static bool IsEmptyJson(string source) => Regex.IsMatch(source, @"^\s*{\s*}\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="hasExistingValue">Indicates if an existing value has been provided</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <exception cref="UnitsNetException">Unable to parse value and unit from JSON.</exception>
        public override IQuantity? ReadJson(JsonReader reader, Type objectType, IQuantity? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));

            var token = JToken.Load(reader);

            if (token.Type is JTokenType.Null)
            {
                return existingValue;
            }

            // Try to read value and unit from JSON, otherwise return existing value.
            ValueUnit? valueUnit = ReadValueUnit(token);

            return valueUnit != null
                ? ConvertValueUnit(valueUnit)
                : hasExistingValue
                    ? existingValue
                    : throw new JsonSerializationException(
                        "Failed to deserialize IQuantity, expected a numeric Value property and a string Unit property.");
        }
    }
}
