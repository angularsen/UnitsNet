// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

public partial struct QuantityValue
{
    #region Implementation of IConvertible

    TypeCode IConvertible.GetTypeCode()
    {
        return TypeCode.Object;
    }

    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        throw ExceptionHelper.CreateInvalidCastException<QuantityValue, char>();
    }

    byte IConvertible.ToByte(IFormatProvider? provider)
    {
        return (byte)this;
    }

    char IConvertible.ToChar(IFormatProvider? provider)
    {
        throw ExceptionHelper.CreateInvalidCastException<QuantityValue, char>();
    }

    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        throw ExceptionHelper.CreateInvalidCastException<QuantityValue, DateTime>();
    }

    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        return ToDecimal();
    }

    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        return ToDouble();
    }

    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        return (short)this;
    }

    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        return (int)this;
    }

    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        return (long)this;
    }

    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        return (sbyte)this;
    }

    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        return (float)this;
    }

    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        return (ushort)this;
    }

    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        return (uint)this;
    }

    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        return (ulong)this;
    }

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
    {
        if (conversionType == null)
        {
            throw new ArgumentNullException(nameof(conversionType));
        }

        if (conversionType == typeof(string))
        {
            return ToString(provider);
        }

        if (conversionType == typeof(double))
        {
            return ToDouble();
        }

        if (conversionType == typeof(decimal))
        {
            return ToDecimal();
        }

        if (conversionType == typeof(float))
        {
            return (float)this;
        }

        if (conversionType == typeof(long))
        {
            return (long)this;
        }

        if (conversionType == typeof(ulong))
        {
            return (ulong)this;
        }

        if (conversionType == typeof(int))
        {
            return (int)this;
        }

        if (conversionType == typeof(uint))
        {
            return (uint)this;
        }

        if (conversionType == typeof(short))
        {
            return (short)this;
        }

        if (conversionType == typeof(ushort))
        {
            return (ushort)this;
        }

        if (conversionType == typeof(byte))
        {
            return (byte)this;
        }

        if (conversionType == typeof(sbyte))
        {
            return (sbyte)this;
        }

        throw ExceptionHelper.CreateInvalidCastException<QuantityValue>(conversionType);
    }

    #endregion
}
