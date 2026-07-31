// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Modular;

/// <summary>
/// Identifies the invariant unit names chosen for the seven SI base dimensions.
/// </summary>
public sealed record BaseUnits
{
    /// <summary>Gets an instance with no base units defined.</summary>
    public static BaseUnits Undefined { get; } = new();

    /// <summary>Creates an immutable base-unit selection.</summary>
    public BaseUnits(
        string? length = null,
        string? mass = null,
        string? time = null,
        string? current = null,
        string? temperature = null,
        string? amount = null,
        string? luminousIntensity = null)
    {
        Length = Validate(length, nameof(length));
        Mass = Validate(mass, nameof(mass));
        Time = Validate(time, nameof(time));
        Current = Validate(current, nameof(current));
        Temperature = Validate(temperature, nameof(temperature));
        Amount = Validate(amount, nameof(amount));
        LuminousIntensity = Validate(luminousIntensity, nameof(luminousIntensity));
    }

    /// <summary>Gets the selected length unit name.</summary>
    public string? Length { get; }

    /// <summary>Gets the selected mass unit name.</summary>
    public string? Mass { get; }

    /// <summary>Gets the selected time unit name.</summary>
    public string? Time { get; }

    /// <summary>Gets the selected electric-current unit name.</summary>
    public string? Current { get; }

    /// <summary>Gets the selected temperature unit name.</summary>
    public string? Temperature { get; }

    /// <summary>Gets the selected amount-of-substance unit name.</summary>
    public string? Amount { get; }

    /// <summary>Gets the selected luminous-intensity unit name.</summary>
    public string? LuminousIntensity { get; }

    /// <summary>Gets whether all seven base units are defined.</summary>
    public bool IsFullyDefined =>
        Length is not null &&
        Mass is not null &&
        Time is not null &&
        Current is not null &&
        Temperature is not null &&
        Amount is not null &&
        LuminousIntensity is not null;

    /// <summary>Gets whether no base units are defined.</summary>
    public bool IsUndefined =>
        Length is null &&
        Mass is null &&
        Time is null &&
        Current is null &&
        Temperature is null &&
        Amount is null &&
        LuminousIntensity is null;

    /// <summary>
    /// Returns whether every unit defined by this instance matches the corresponding unit in
    /// <paramref name="other"/>.
    /// </summary>
    public bool IsSubsetOf(BaseUnits other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (IsUndefined)
        {
            return other.IsUndefined;
        }

        return Matches(Length, other.Length) &&
               Matches(Mass, other.Mass) &&
               Matches(Time, other.Time) &&
               Matches(Current, other.Current) &&
               Matches(Temperature, other.Temperature) &&
               Matches(Amount, other.Amount) &&
               Matches(LuminousIntensity, other.LuminousIntensity);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        if (IsUndefined)
        {
            return "Undefined";
        }

        var units = new List<string>(7);
        Add(units, "L", Length);
        Add(units, "M", Mass);
        Add(units, "T", Time);
        Add(units, "I", Current);
        Add(units, "Θ", Temperature);
        Add(units, "N", Amount);
        Add(units, "J", LuminousIntensity);
        return string.Join(", ", units);
    }

    private static string? Validate(string? value, string parameterName)
    {
        if (value is not null && string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A defined base-unit name cannot be empty.", parameterName);
        }

        return value;
    }

    private static bool Matches(string? required, string? selected) =>
        required is null || string.Equals(required, selected, StringComparison.Ordinal);

    private static void Add(ICollection<string> target, string symbol, string? value)
    {
        if (value is not null)
        {
            target.Add($"{symbol}={value}");
        }
    }
}
