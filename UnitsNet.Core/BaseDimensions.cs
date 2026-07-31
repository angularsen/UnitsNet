// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Modular;

/// <summary>Describes a quantity in terms of the seven SI base dimensions.</summary>
public sealed record BaseDimensions(
    int Length,
    int Mass,
    int Time,
    int Current,
    int Temperature,
    int Amount,
    int LuminousIntensity)
{
    /// <summary>Gets dimensionless dimensions.</summary>
    public static BaseDimensions Dimensionless { get; } = new(0, 0, 0, 0, 0, 0, 0);

    /// <summary>Returns whether exactly one base dimension has exponent one.</summary>
    public bool IsBaseQuantity()
    {
        int count = 0;
        ReadOnlySpan<int> exponents =
            [Length, Mass, Time, Current, Temperature, Amount, LuminousIntensity];
        foreach (int exponent in exponents)
        {
            if (exponent is not (0 or 1))
            {
                return false;
            }

            count += exponent;
        }

        return count == 1;
    }

    /// <summary>Returns whether all base-dimension exponents are zero.</summary>
    public bool IsDimensionless() => this == Dimensionless;

    /// <summary>Returns whether these dimensions represent a derived quantity.</summary>
    public bool IsDerivedQuantity() => !IsBaseQuantity() && !IsDimensionless();

    /// <summary>Combines dimensions for multiplication.</summary>
    public BaseDimensions Multiply(BaseDimensions right)
    {
        ArgumentNullException.ThrowIfNull(right);
        return new BaseDimensions(
            Length + right.Length,
            Mass + right.Mass,
            Time + right.Time,
            Current + right.Current,
            Temperature + right.Temperature,
            Amount + right.Amount,
            LuminousIntensity + right.LuminousIntensity);
    }

    /// <summary>Combines dimensions for division.</summary>
    public BaseDimensions Divide(BaseDimensions right)
    {
        ArgumentNullException.ThrowIfNull(right);
        return new BaseDimensions(
            Length - right.Length,
            Mass - right.Mass,
            Time - right.Time,
            Current - right.Current,
            Temperature - right.Temperature,
            Amount - right.Amount,
            LuminousIntensity - right.LuminousIntensity);
    }

    /// <summary>Combines dimensions for multiplication.</summary>
    public static BaseDimensions operator *(BaseDimensions left, BaseDimensions right) => left.Multiply(right);

    /// <summary>Combines dimensions for division.</summary>
    public static BaseDimensions operator /(BaseDimensions left, BaseDimensions right) => left.Divide(right);
}
