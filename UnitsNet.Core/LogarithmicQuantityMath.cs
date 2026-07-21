// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>Reusable algorithms for quantities with logarithmic arithmetic semantics.</summary>
public static class LogarithmicQuantityMath
{
    /// <summary>Sums logarithmic quantities in linear space and preserves the first value's unit.</summary>
    public static TQuantity Sum<TQuantity, TUnit>(IEnumerable<TQuantity> quantities)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no quantities.");
        }

        TQuantity first = enumerator.Current;
        TUnit unit = first.Unit;
        double scalingFactor = TQuantity.LogarithmicScalingFactor;
        double sum = ToLinear(first.Value, scalingFactor);
        while (enumerator.MoveNext())
        {
            TQuantity quantity = enumerator.Current;
            sum += ToLinear(TQuantity.Convert(quantity.Value, quantity.Unit, unit), scalingFactor);
        }

        return TQuantity.From(ToLogarithmic(sum, scalingFactor), unit);
    }

    /// <summary>Sums logarithmic quantities in linear space and expresses the result in a target unit.</summary>
    public static TQuantity Sum<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        var hasValue = false;
        var sum = 0d;
        foreach (TQuantity quantity in quantities)
        {
            sum += ToLinear(TQuantity.Convert(quantity.Value, quantity.Unit, unit), TQuantity.LogarithmicScalingFactor);
            hasValue = true;
        }

        return hasValue
            ? TQuantity.From(ToLogarithmic(sum, TQuantity.LogarithmicScalingFactor), unit)
            : throw new InvalidOperationException("Sequence contains no quantities.");
    }

    /// <summary>Calculates the arithmetic mean in linear space and preserves the first value's unit.</summary>
    public static TQuantity ArithmeticMean<TQuantity, TUnit>(IEnumerable<TQuantity> quantities)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no quantities.");
        }

        TQuantity first = enumerator.Current;
        TUnit unit = first.Unit;
        double scalingFactor = TQuantity.LogarithmicScalingFactor;
        double sum = ToLinear(first.Value, scalingFactor);
        var count = 1;
        while (enumerator.MoveNext())
        {
            TQuantity quantity = enumerator.Current;
            sum += ToLinear(TQuantity.Convert(quantity.Value, quantity.Unit, unit), scalingFactor);
            count++;
        }

        return TQuantity.From(ToLogarithmic(sum / count, scalingFactor), unit);
    }

    /// <summary>Calculates the arithmetic mean in linear space in a target unit.</summary>
    public static TQuantity ArithmeticMean<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        var count = 0;
        var sum = 0d;
        foreach (TQuantity quantity in quantities)
        {
            sum += ToLinear(TQuantity.Convert(quantity.Value, quantity.Unit, unit), TQuantity.LogarithmicScalingFactor);
            count++;
        }

        return count == 0
            ? throw new InvalidOperationException("Sequence contains no quantities.")
            : TQuantity.From(ToLogarithmic(sum / count, TQuantity.LogarithmicScalingFactor), unit);
    }

    /// <summary>Calculates UnitsNet-compatible geometric mean semantics in the first value's unit.</summary>
    public static TQuantity GeometricMean<TQuantity, TUnit>(IEnumerable<TQuantity> quantities)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no quantities.");
        }

        TQuantity first = enumerator.Current;
        TUnit unit = first.Unit;
        double sum = first.Value;
        var count = 1;
        while (enumerator.MoveNext())
        {
            TQuantity quantity = enumerator.Current;
            sum += TQuantity.Convert(quantity.Value, quantity.Unit, unit);
            count++;
        }

        return TQuantity.From(double.RootN(sum, count), unit);
    }

    /// <summary>Calculates UnitsNet-compatible geometric mean semantics in a target unit.</summary>
    public static TQuantity GeometricMean<TQuantity, TUnit>(IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(quantities);
        var count = 0;
        var sum = 0d;
        foreach (TQuantity quantity in quantities)
        {
            sum += TQuantity.Convert(quantity.Value, quantity.Unit, unit);
            count++;
        }

        return count == 0
            ? throw new InvalidOperationException("Sequence contains no quantities.")
            : TQuantity.From(double.RootN(sum, count), unit);
    }

    /// <summary>Compares logarithmic quantities with a logarithmic absolute tolerance.</summary>
    public static bool Equals<TQuantity, TUnit>(
        TQuantity quantity,
        TQuantity other,
        TQuantity tolerance)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        double scalingFactor = TQuantity.LogarithmicScalingFactor;
        double value = ToLinear(quantity.Value, scalingFactor);
        double otherValue = ToLinear(TQuantity.Convert(other.Value, other.Unit, quantity.Unit), scalingFactor);
        double toleranceValue = Math.Abs(
            ToLinear(TQuantity.Convert(tolerance.Value, tolerance.Unit, quantity.Unit), scalingFactor));
        return Math.Abs(value - otherValue) <= toleranceValue;
    }

    private static double ToLinear(double value, double scalingFactor) => Math.Pow(10, value / scalingFactor);

    private static double ToLogarithmic(double value, double scalingFactor) =>
        scalingFactor * Math.Log10(value);
}
