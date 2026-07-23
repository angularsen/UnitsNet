// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.Serialization;

namespace UnitsNet.Serialization;

/// <summary>
///     Provides serialization and deserialization functionality for <see cref="QuantityValueSurrogate" /> objects.
/// </summary>
public sealed class QuantityValueSurrogateSerializationProvider : ISerializationSurrogateProvider
{
    /// <summary>
    ///     Gets the singleton instance of the <see cref="QuantityValueSurrogateSerializationProvider" />.
    /// </summary>
    public static readonly ISerializationSurrogateProvider Instance = new QuantityValueSurrogateSerializationProvider();

    private QuantityValueSurrogateSerializationProvider()
    {
    }

    /// <summary>
    ///     Deserializes an object of type <see cref="QuantityValueSurrogate" /> into a <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="obj">The object to deserialize, expected to be of type <see cref="QuantityValueSurrogate" />.</param>
    /// <param name="targetType">The target type for deserialization, expected to be <see cref="QuantityValue" />.</param>
    /// <returns>
    ///     A deserialized <see cref="QuantityValue" /> object if the input object is of type
    ///     <see cref="QuantityValueSurrogate" />;
    ///     otherwise, returns the input object.
    /// </returns>
    /// <exception cref="FormatException">
    ///     Thrown when the numerator or denominator in the <see cref="QuantityValueSurrogate" /> cannot be parsed into a
    ///     <see cref="BigInteger" />.
    /// </exception>
    public object GetDeserializedObject(object obj, Type targetType)
    {
        if (obj is not QuantityValueSurrogate quantityValueSurrogate)
        {
            return obj;
        }

        BigInteger numerator = quantityValueSurrogate.Numerator == null
            ? BigInteger.Zero
            : BigInteger.Parse(quantityValueSurrogate.Numerator, CultureInfo.InvariantCulture);
        BigInteger denominator = quantityValueSurrogate.Denominator == null
            ? BigInteger.One
            : BigInteger.Parse(quantityValueSurrogate.Denominator, CultureInfo.InvariantCulture);
        return new QuantityValue(numerator, denominator);
    }

    /// <summary>
    ///     Converts a <see cref="QuantityValue" /> object to a <see cref="QuantityValueSurrogate" /> object for serialization
    ///     purposes.
    /// </summary>
    /// <param name="obj">The object to be serialized, expected to be of type <see cref="QuantityValue" />.</param>
    /// <param name="targetType">The type of the target object, which is ignored in this implementation.</param>
    /// <returns>
    ///     A <see cref="QuantityValueSurrogate" /> object containing the serialized data of the <see cref="QuantityValue" />
    ///     object.
    ///     If the input object is not of type <see cref="QuantityValue" />, the original object is returned.
    /// </returns>
    public object GetObjectToSerialize(object obj, Type targetType)
    {
        if (obj is not QuantityValue quantityValue)
        {
            return obj;
        }

        (BigInteger numerator, BigInteger denominator) = quantityValue;
        return new QuantityValueSurrogate
        {
            Numerator = numerator.IsZero ? null : numerator.ToString(CultureInfo.InvariantCulture),
            Denominator = denominator.IsOne ? null : denominator.ToString(CultureInfo.InvariantCulture)
        };
    }

    /// <summary>
    ///     Retrieves the surrogate type for the specified type.
    /// </summary>
    /// <param name="type">The type for which to get the surrogate type.</param>
    /// <returns>
    ///     The surrogate type if the specified type is <see cref="QuantityValue" />; otherwise, the original type.
    /// </returns>
    public Type GetSurrogateType(Type type)
    {
        return type == typeof(QuantityValue) ? typeof(QuantityValueSurrogate) : type;
    }
}
