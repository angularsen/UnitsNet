using System;

namespace UnitsNet;

internal static class ConvertibleExtensions
{
    internal static QuantityValue ToQuantityValue<TNumber>(this TNumber number) where TNumber : IConvertible
    {
        return number.GetTypeCode() switch
        {
            TypeCode.SByte => number.ToSByte(null),
            TypeCode.Byte => number.ToByte(null),
            TypeCode.Int16 => number.ToInt16(null),
            TypeCode.UInt16 => number.ToUInt16(null),
            TypeCode.Int32 => number.ToInt32(null),
            TypeCode.UInt32 => number.ToUInt32(null),
            TypeCode.Int64 => number.ToInt64(null),
            TypeCode.UInt64 => number.ToUInt64(null),
            TypeCode.Single => number.ToSingle(null),
            TypeCode.Decimal => number.ToDecimal(null),
            TypeCode.String => QuantityValue.Parse(number.ToString(null), null),
            _ => number.ToDouble(null)
        };
    }
}
