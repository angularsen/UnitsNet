// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Determines whether this QuantityValue instance is equal to another QuantityValue instance.
    /// </summary>
    /// <param name="other">The QuantityValue to compare with this instance.</param>
    /// <returns>True if the two QuantityValue instances are equal, false otherwise.</returns>
    public bool Equals(QuantityValue other)
    {
        return _fraction.Equals(other._fraction);
    }

    /// <summary>
    ///     Determines whether this QuantityValue instance is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>True if the object is a QuantityValue instance and is equal to this instance, false otherwise.</returns>
    public override bool Equals(object? obj)
    {
        return obj is QuantityValue other && Equals(other);
    }

    /// <summary>
    ///     Returns the hash code for this QuantityValue instance.
    /// </summary>
    /// <returns>The hash code.</returns>
    public override int GetHashCode()
    {
        return _fraction.GetHashCode();
    }

    /// <summary>
    ///     Compares two QuantityValue instances for equality.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>True if the two QuantityValue instances are equal, false otherwise.</returns>
    public static bool operator ==(QuantityValue a, QuantityValue b)
    {
        return a._fraction == b._fraction;
    }

    /// <summary>
    ///     Compares two QuantityValue instances for inequality.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>True if the two QuantityValue instances are not equal, false otherwise.</returns>
    public static bool operator !=(QuantityValue a, QuantityValue b)
    {
        return a._fraction != b._fraction;
    }
}
