// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Greater-than operator
    /// </summary>
    public static bool operator >(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) > 0;
    }

    /// <summary>
    ///     Less-than operator
    /// </summary>
    public static bool operator <(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) < 0;
    }

    /// <summary>
    ///     Greater-than-or-equal operator
    /// </summary>
    public static bool operator >=(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) >= 0;
    }

    /// <summary>
    ///     Less-than-or-equal operator
    /// </summary>
    public static bool operator <=(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) <= 0;
    }

    /// <summary>
    ///     Compares this QuantityValue instance to another QuantityValue instance.
    /// </summary>
    /// <param name="other">The QuantityValue to compare with this instance.</param>
    /// <returns>
    ///     A value indicating the relative order of the QuantityValue instances being compared.
    ///     Less than zero: This instance is less than the other instance.
    ///     Zero: This instance is equal to the other instance.
    ///     Greater than zero: This instance is greater than the other instance.
    /// </returns>
    public int CompareTo(QuantityValue other)
    {
        return _fraction.CompareTo(other._fraction);
    }

    /// <summary>
    ///     Compares this QuantityValue instance to another object.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>
    ///     A value indicating the relative order of the QuantityValue instances being compared.
    ///     Less than zero: This instance is less than the other instance.
    ///     Zero: This instance is equal to the other instance.
    ///     Greater than zero: This instance is greater than the other instance.
    /// </returns>
    public int CompareTo(object? obj)
    {
        return obj switch
        {
            null => 1,
            QuantityValue other => CompareTo(other),
            _ => throw new ArgumentException($"Object must be of type {nameof(QuantityValue)}")
        };
    }
}
