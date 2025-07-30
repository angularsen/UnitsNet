// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Serialization.JsonNet;

/// <summary>
///     Represents options for formatting quantity values during serialization and deserialization.
/// </summary>
public record struct QuantityValueFormatOptions(
    QuantityValueSerializationFormat SerializationFormat = QuantityValueSerializationFormat.DecimalPrecision,
    QuantityValueDeserializationFormat DeserializationFormat = QuantityValueDeserializationFormat.ExactNumber);

/// <summary>
///     Specifies the format used for serializing <see cref="QuantityValue" /> to JSON.
/// </summary>
public enum QuantityValueSerializationFormat
{
    /// <summary>
    ///     Represents the serialization format where the quantity value is serialized as a number with decimal precision.
    /// </summary>
    /// <remarks>
    ///     This number is represented with up to 29 significant digits. Numbers such as "1/3" would be represented as
    ///     "0.3333333333333333333333333333".
    /// </remarks>
    DecimalPrecision,

    /// <summary>
    ///     Represents the serialization format where the quantity value is serialized as a number with double precision.
    /// </summary>
    /// <remarks>
    ///     This number is represented with up to 17 significant digits. Numbers such as "1/3" would be represented as
    ///     "0.3333333333333333".
    /// </remarks>
    DoublePrecision,

    /// <summary>
    ///     Represents a serialization format that ensures the exact value of a quantity is preserved during serialization and
    ///     deserialization.
    ///     This format is particularly useful for scenarios where precision and round-trip accuracy are critical.
    /// </summary>
    /// <remarks>
    ///     This format dynamically switches between decimal and fractional notation
    ///     depending on the value being serialized. This ensures that the serialized representation is both precise and
    ///     compact.
    ///     For example:
    ///     - A value such as <c>1.23456789</c> will be serialized in decimal notation, including all significant digits.
    ///     - A value such as <c>1/3</c> will be serialized as a fraction (e.g., <c>"1/3"</c>).
    ///     This format is ideal for scenarios where the exact representation of a value is required for round-trip
    ///     serialization and deserialization.
    /// </remarks>
    RoundTripping,

    /// <summary>
    ///     Relies on the presence of a custom converter for the <see cref="QuantityValue" />.
    /// </summary>
    /// <remarks>
    ///     When this option is selected <c>JsonConvert</c> is used for the serialization.
    /// </remarks>
    Custom
}

/// <summary>
///     Specifies the format used for deserializing <see cref="QuantityValue" /> from JSON.
/// </summary>
public enum QuantityValueDeserializationFormat
{
    /// <summary>
    ///     Deserializes the quantity value as exact number in decimal notation.
    /// </summary>
    ExactNumber,
    
    /// <summary>
    ///     Deserializes the quantity value as a double precision number, which is then rounded to 15 significant digits.
    /// </summary>
    RoundedDouble,
    
    /// <summary>
    ///     Represents a serialization format that ensures the exact value of a quantity is preserved during serialization and
    ///     deserialization.
    ///     This format is particularly useful for scenarios where precision and round-trip accuracy are critical.
    /// </summary>
    /// <remarks>
    ///     This format dynamically switches between decimal and fractional notation
    ///     depending on the value being serialized. This ensures that the serialized representation is both precise and
    ///     compact.
    ///     For example:
    ///     - A value such as <c>1.23456789</c> will be serialized in decimal notation, including all significant digits.
    ///     - A value such as <c>1/3</c> will be serialized as a fraction (e.g., <c>"1/3"</c>).
    ///     This format is ideal for scenarios where the exact representation of a value is required for round-trip
    ///     serialization and deserialization.
    /// </remarks>
    RoundTripping,

    /// <summary>
    ///     Relies on the presence of a custom converter for the <see cref="QuantityValue" />.
    /// </summary>
    /// <remarks>
    ///     When this option is selected <c>JsonConvert</c> is used for the deserialization.
    /// </remarks>
    Custom
}
