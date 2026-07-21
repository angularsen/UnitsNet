// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>Identifies a quantity independently of its concrete generated CLR type.</summary>
public readonly struct QuantityId : IEquatable<QuantityId>
{
    private readonly string? _value;

    /// <summary>Initializes a semantic quantity identifier.</summary>
    public QuantityId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A quantity identifier cannot be empty.", nameof(value));
        }

        _value = value;
    }

    /// <summary>Gets the stable textual identifier.</summary>
    public string Value => _value ?? string.Empty;

    /// <inheritdoc />
    public bool Equals(QuantityId other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is QuantityId other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);

    /// <inheritdoc />
    public override string ToString() => Value;

    /// <summary>Determines whether two quantity identifiers are equal.</summary>
    public static bool operator ==(QuantityId left, QuantityId right) => left.Equals(right);

    /// <summary>Determines whether two quantity identifiers are different.</summary>
    public static bool operator !=(QuantityId left, QuantityId right) => !left.Equals(right);
}
