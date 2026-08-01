// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Modular.SourceGen;

/// <summary>Serializes one generated quantity using its immutable module descriptor.</summary>
/// <remarks>
/// This type is public so generated code can reuse it across consumer assemblies. Applications
/// should configure serialization through the generated module API instead.
/// </remarks>
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class QuantityJsonConverter<TQuantity> : JsonConverter<TQuantity>
    where TQuantity : struct, IQuantity<double>
{
    private readonly IQuantityDescriptor _descriptor;

    /// <summary>Creates a converter for one generated concrete quantity type.</summary>
    public QuantityJsonConverter(IQuantityDescriptor descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);
        _descriptor = descriptor;
    }

    /// <inheritdoc />
    public override TQuantity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected a quantity object.");
        }

        double? value = null;
        string? unit = null;
        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected a quantity property.");
            }

            string propertyName = reader.GetString()!;
            if (!reader.Read())
            {
                throw new JsonException("Unexpected end of quantity object.");
            }

            if (propertyName.Equals("Value", StringComparison.OrdinalIgnoreCase))
            {
                value = reader.GetDouble();
            }
            else if (propertyName.Equals("Unit", StringComparison.OrdinalIgnoreCase))
            {
                unit = reader.GetString();
            }
            else
            {
                reader.Skip();
            }
        }

        if (value is null || unit is null)
        {
            throw new JsonException("A quantity requires Value and Unit properties.");
        }

        try
        {
            return (TQuantity)_descriptor.Create(value.Value, unit);
        }
        catch (ArgumentException exception)
        {
            throw new JsonException(exception.Message, exception);
        }
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        TQuantity value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber("Value", _descriptor.GetValue(value));
        writer.WriteString("Unit", _descriptor.GetUnitName(value));
        writer.WriteEndObject();
    }
}
