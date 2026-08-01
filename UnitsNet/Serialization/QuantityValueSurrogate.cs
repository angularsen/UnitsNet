using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace UnitsNet;

/// <summary>
///     Represents a surrogate for serializing and deserializing quantity values.
/// </summary>
[DataContract]
internal class QuantityValueSurrogate
{
    /// <summary>
    ///     Gets or sets the numerator part of the quantity value.
    /// </summary>
    /// <value>
    ///     A string representing the numerator of the quantity value.
    /// </value>
    /// <remarks>When omitted, the value is assumed to be "0".</remarks>
    [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false, Name = "N")]
    public string? Numerator { get; set; }

    /// <summary>
    ///     Gets or sets the denominator part of the quantity value.
    /// </summary>
    /// <value>
    ///     The denominator as a string.
    /// </value>
    /// <remarks>When omitted, the value is assumed to be "1".</remarks>
    [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false, Name = "D")]
    public string? Denominator { get; set; }
}
