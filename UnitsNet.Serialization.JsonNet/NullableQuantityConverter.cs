// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet;

/// <summary>
///     An abstract base class for JSON serialization and deserialization of quantities that implement the <see cref="IQuantity"/> interface, 
///     including nullable quantities.
/// </summary>
/// <typeparam name="T">
///     The type of the quantity being serialized or deserialized. This type must implement the <see cref="IQuantity"/> interface.
/// </typeparam>
/// <remarks>
///     This class extends <see cref="JsonConverter"/> and provides functionality to handle both direct implementations of <see cref="IQuantity"/> 
///     and nullable types where the underlying type implements <see cref="IQuantity"/>.
/// </remarks>
public abstract class NullableQuantityConverter<T> : JsonConverter
{
    /// <summary>
    ///     Determines whether the specified type can be converted by this converter.
    /// </summary>
    /// <param name="objectType">The type of the object to check for conversion support.</param>
    /// <returns>
    ///     <see langword="true" /> if the specified type is either directly assignable to <typeparamref name="T" />
    ///     or is a nullable type with an underlying type assignable to <typeparamref name="T" />;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    /// <remarks>
    ///     This method checks if the provided type is compatible with the generic type parameter <typeparamref name="T" />,
    ///     including nullable types where the underlying type implements <see cref="IQuantity" />.
    /// </remarks>
    public override bool CanConvert(Type objectType)
    {
        // Check if the type directly implements TQuantity
        if (typeof(T).IsAssignableFrom(objectType))
        {
            return true;
        }

        // Check if the type is a Nullable<T> where T implements IQuantity
        Type? underlyingType = Nullable.GetUnderlyingType(objectType);
        return underlyingType != null && typeof(T).IsAssignableFrom(underlyingType);
    }

    /// <summary>
    ///     Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public sealed override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        switch (value)
        {
            case T quantity:
                WriteJson(writer, quantity, serializer);
                break;
            case null: // this case seems to be unreachable (unless calling the converter directly)
                WriteJson(writer, default, serializer);
                break;
            default: // should not be possible (unless calling the converter directly)
                throw new JsonException("Converter cannot write specified value to JSON. An IQuantity is required.");
        }
    }

    /// <summary>
    ///     Writes the JSON representation of the specified quantity.
    /// </summary>
    /// <param name="writer">The <see cref="JsonWriter" /> to write to.</param>
    /// <param name="quantity">The quantity to write.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <remarks>
    ///     This method is abstract and must be implemented by derived classes to define how a quantity is serialized to JSON.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="writer" />, <paramref name="quantity" />, or <paramref name="serializer" /> is
    ///     <see langword="null" />.
    /// </exception>
    public abstract void WriteJson(JsonWriter writer, T? quantity, JsonSerializer serializer);


    /// <summary>
    ///     Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public sealed override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return existingValue switch
        {
            T existingQuantity => ReadJson(reader, objectType, existingQuantity, true, serializer),
            null => ReadJson(reader, objectType, default, false, serializer),
            _ => throw new JsonException("Converter cannot read JSON with the specified existing value. An IQuantity is required.")
        };
    }
    
    /// <summary>
    /// Reads JSON to deserialize an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
    /// <param name="objectType">The type of the object to deserialize.</param>
    /// <param name="existingValue">The existing value of the object being deserialized, if any.</param>
    /// <param name="hasExistingValue">
    /// A boolean indicating whether an existing value is provided.
    /// If <c>true</c>, <paramref name="existingValue"/> contains the current value.
    /// </param>
    /// <param name="serializer">The <see cref="JsonSerializer"/> used for deserialization.</param>
    /// <returns>
    /// A deserialized instance of <typeparamref name="T"/> or <c>null</c> if the JSON represents a null value.
    /// </returns>
    /// <exception cref="JsonSerializationException">
    /// Thrown if the JSON cannot be deserialized into an object of type <typeparamref name="T"/>.
    /// </exception>
    public abstract T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue, JsonSerializer serializer);
}
