// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitsNet.Serialization.JsonNet
{
    /// <inheritdoc />
    /// <summary>
    /// JSON.Net converter for IComparable properties that are actually UnitsNet units.
    /// Use with caution, as this might interfere with any other converters for IComparable.
    /// Must be registered in the <see cref="JsonSerializerSettings.Converters"/> collection -after- <see cref="UnitsNetIQuantityJsonConverter"/>
    /// Should only be used when UnitsNet types are assigned to properties of type IComparable.
    /// Requires TypeNameHandling on <see cref="JsonSerializerSettings"/> to be set to something other than <see cref="TypeNameHandling.None"/> so that it outputs $type when serializing.
    /// </summary>
    public sealed class UnitsNetIComparableJsonConverter : UnitsNetBaseJsonConverter<IComparable?>
    {
        /// <summary>
        /// Indicates if this JsonConverter is capable of writing JSON
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Serialize an IComparable to JSON.
        /// Not implemented. Instead <see cref="UnitsNetIQuantityJsonConverter.WriteJson(JsonWriter, IQuantity, JsonSerializer)"/> is always used to serialize an IComparable when it is a UnitsNet quantity.
        /// </summary>
        /// <param name="writer">The writer to use</param>
        /// <param name="value">The value to serialize</param>
        /// <param name="serializer">The serializer to use</param>
        /// <remarks>
        /// Because this converter should only be used in combination with the <see cref="UnitsNetIQuantityJsonConverter"/>, the WriteJson method of that converter will always be used
        /// to serialize an IComparable in the context of UnitsNet.
        /// JsonNet is capable of serializing any IComparable implementation.</remarks>
        public override void WriteJson(JsonWriter writer, IComparable? value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Serialization of IComparable is handled by default serialization");
        }

        /// <summary>
        /// Attempts to deserialize a JSON string as UnitsNet type, assigned to property of type IComparable
        /// </summary>
        /// <param name="reader">The JsonReader to access the JSON data to read</param>
        /// <param name="objectType">The type of object to deserialize</param>
        /// <param name="existingValue">An existing value, if any (which is ignored)</param>
        /// <param name="hasExistingValue">Indicates if there is an existing value that should be updated (which is ignored)</param>
        /// <param name="serializer">The JsonSerializer to use for deserialization</param>
        /// <returns>A deserialized IComparable</returns>
        public override IComparable? ReadJson(JsonReader reader, Type objectType, IComparable? existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));

            var token = JToken.Load(reader);

            if (token.Type is JTokenType.Null)
            {
                return existingValue;
            }

            // If objectType is not IComparable but a type that implements IComparable, deserialize directly as this type instead.
            if (objectType != typeof(IComparable))
            {
                // Remove the current converter from the list of converters to avoid infinite recursion.
                JsonSerializer localSerializer = CreateLocalSerializer(serializer, this);
                return (IComparable)token.ToObject(objectType, localSerializer)!;
            }

            ValueUnit? valueUnit = ReadValueUnit(token);

            if (valueUnit == null)
            {
                // Remove the current converter from the list of converters to avoid infinite recursion.
                JsonSerializer localSerializer = CreateLocalSerializer(serializer, this);
                return token.ToObject<IComparable>(localSerializer);
            }

            return (IComparable)ConvertValueUnit(valueUnit);
        }
    }
}
