// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.ComponentModel;
using System.Globalization;
using System.Numerics;

namespace UnitsNet;

/// <summary>
///     Provides a type converter to convert object data types to and from various other data types for QuantityValue.
/// </summary>
/// <remarks>
///     This class inherits from the <see cref="TypeConverter" /> class and provides methods to
///     convert
///     objects of one type to another type within the context of QuantityValue. It is used for type conversions required
///     for
///     property values, data binding, and other services.
/// </remarks>
public class QuantityValueTypeConverter : TypeConverter
{
    /// <inheritdoc />
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType switch
        {
            _ when destinationType == typeof(string) => true,
            _ when destinationType == typeof(int) => true,
            _ when destinationType == typeof(long) => true,
            _ when destinationType == typeof(decimal) => true,
            _ when destinationType == typeof(double) => true,
            _ when destinationType == typeof(QuantityValue) => true,
            _ when destinationType == typeof(BigInteger) => true,
            _ => false
        };
    }

    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType switch
        {
            _ when sourceType == typeof(string) => true,
            _ when sourceType == typeof(int) => true,
            _ when sourceType == typeof(long) => true,
            _ when sourceType == typeof(decimal) => true,
            _ when sourceType == typeof(double) => true,
            _ when sourceType == typeof(QuantityValue) => true,
            _ when sourceType == typeof(BigInteger) => true,
            _ => false
        };
    }

    /// <inheritdoc />
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is QuantityValue quantityValue)
        {
            return destinationType switch
            {
                _ when destinationType == typeof(string) => quantityValue.ToString(culture),
                _ when destinationType == typeof(int) => (int)quantityValue,
                _ when destinationType == typeof(long) => (long)quantityValue,
                _ when destinationType == typeof(decimal) => quantityValue.ToDecimal(),
                _ when destinationType == typeof(double) => quantityValue.ToDouble(),
                _ when destinationType == typeof(BigInteger) => (BigInteger)quantityValue,
                _ when destinationType == typeof(QuantityValue) => quantityValue,
                _ => base.ConvertTo(context, culture, value, destinationType)
            };
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <inheritdoc />
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
    {
        if (value is null)
        {
            return QuantityValue.Zero;
        }

        return value switch
        {
            string s => QuantityValue.Parse(s, culture),
            int i => new QuantityValue(i),
            long l => new QuantityValue(l),
            decimal d => new QuantityValue(d),
            double dbl => QuantityValue.FromDoubleRounded(dbl),
            BigInteger bigInteger => new QuantityValue(bigInteger),
            QuantityValue quantityValue => quantityValue,
            _ => base.ConvertFrom(context, culture, value)
        };
    }
}