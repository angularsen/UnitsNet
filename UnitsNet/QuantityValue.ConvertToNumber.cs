// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="double" />.</summary>
    public static explicit operator double(QuantityValue value)
    {
        return (double)value._fraction;
    }

    /// <summary>
    ///     Returns the quantity as (rounded!) floating point value.
    /// </summary>
    /// <returns>A floating point value</returns>
    public double ToDouble()
    {
        return (double)_fraction;
    }


    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="decimal" />.</summary>
    public static explicit operator decimal(QuantityValue value)
    {
        return (decimal)value._fraction;
    }

    /// <summary>
    ///     Returns the quantity as (rounded!) floating point value.
    /// </summary>
    /// <returns>A floating point value</returns>
    public decimal ToDecimal()
    {
        return (decimal)_fraction;
    }
    
    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="float" />.</summary>
    public static explicit operator float(QuantityValue value)
    {
        return (float)(double)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="BigInteger" />.</summary>
    public static explicit operator BigInteger(QuantityValue value)
    {
        return (BigInteger)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="long" />.</summary>
    public static explicit operator long(QuantityValue value)
    {
        return (long)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="ulong" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator ulong(QuantityValue value)
    {
        return (ulong)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="int" />.</summary>
    public static explicit operator int(QuantityValue value)
    {
        return (int)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="uint" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator uint(QuantityValue value)
    {
        return (uint)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="short" />.</summary>
    public static explicit operator short(QuantityValue value)
    {
        return (short)value._fraction;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="ushort" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator ushort(QuantityValue value)
    {
        return (ushort)(short)value;
    }
    
    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="byte" />.</summary>
    public static explicit operator byte(QuantityValue value)
    {
        return (byte)(short)value;
    }
}
