// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using Fractions;

namespace UnitsNet;

/// <summary>
/// </summary>
public class QuantityValueTypeConverter : TypeConverter
{
    // TODO see about maybe implementing these without the lookup
    private static readonly HashSet<Type> Supported_Types =
    [
        typeof(string),
        typeof(int),
        typeof(long),
        typeof(decimal),
        typeof(double),
        typeof(QuantityValue),
        typeof(Fraction),
        typeof(BigInteger)
    ];

    private static readonly Dictionary<Type, Func<object, CultureInfo?, object>> Convert_To_Dictionary =
        new()
        {
            { typeof(string), (o, info) => ((QuantityValue)o).ToString(info) },
            { typeof(int), (o, _) => (int)(QuantityValue)o },
            { typeof(long), (o, _) => (long)(QuantityValue)o },
            { typeof(decimal), (o, _) => ((QuantityValue)o).ToDecimal() },
            { typeof(double), (o, _) => ((QuantityValue)o).ToDouble() },
            {
                typeof(Fraction), (o, _) =>
                {
                    (BigInteger numerator, BigInteger denominator) = (QuantityValue)o;
                    return new Fraction(numerator, denominator);
                }
            },
            { typeof(BigInteger), (o, _) => (BigInteger)(QuantityValue)o },
            { typeof(QuantityValue), (o, _) => (QuantityValue)o }
        };

    private static readonly Dictionary<Type, Func<object, CultureInfo?, QuantityValue>> Convert_From_Dictionary =
        new()
        {
            { typeof(string), (o, info) => QuantityValue.Parse((string)o, info) },
            { typeof(int), (o, _) => new QuantityValue((int)o, 1) },
            { typeof(long), (o, _) => new QuantityValue((long)o, 1) },
            { typeof(decimal), (o, _) => QuantityValue.FromDecimal((decimal)o) },
            { typeof(double), (o, _) => QuantityValue.FromDoubleRounded((double)o) },
            {
                typeof(Fraction), (o, _) =>
                {
                    var fraction = (Fraction)o;
                    return new QuantityValue(fraction.Numerator, fraction.Denominator);
                }
            },
            { typeof(BigInteger), (o, _) => new QuantityValue((BigInteger)o, 1) },
            { typeof(QuantityValue), (o, _) => (QuantityValue)o }
        };

    /// <summary>
    ///     Returns whether the type converter can convert an object to the specified type.
    /// </summary>
    /// <param name="context">An object that provides a format context.</param>
    /// <param name="destinationType">The type you want to convert to.</param>
    /// <returns><c>true</c> if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType != null && Supported_Types.Contains(destinationType);
    }

    /// <summary>
    ///     Returns whether this converter can convert an object of the given type to the type of this converter, using the
    ///     specified context.
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext " />that provides a format context. </param>
    /// <param name="sourceType">A <see cref="Type" /> that represents the type you want to convert from. </param>
    /// <returns><c>true</c>if this converter can perform the conversion; otherwise, <c>false</c>.</returns>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return Supported_Types.Contains(sourceType);
    }

    /// <summary>
    ///     Converts the given value object to the specified type, using the specified context and culture information.
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="culture">A CultureInfo. If <c>null</c> is passed, the current culture is assumed.</param>
    /// <param name="value">The <see cref="Object" /> to convert.</param>
    /// <param name="destinationType">The <see cref="Type" />  to convert the value parameter to.</param>
    /// <returns>An <see cref="Object" /> that represents the converted value.</returns>
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
        Type destinationType)
    {
        if (value is not null && Convert_To_Dictionary.TryGetValue(destinationType, out Func<object, CultureInfo?, object>? func))
        {
            return func(value, culture);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>
    ///     Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="culture">The <see cref="CultureInfo" /> to use as the current culture.</param>
    /// <param name="value">The <see cref="Object" /> to convert.</param>
    /// <returns>An <see cref="Object" /> that represents the converted value.</returns>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object? value)
    {
        if (value is null)
        {
            return QuantityValue.Zero;
        }

        if (Convert_From_Dictionary.TryGetValue(value.GetType(), out Func<object, CultureInfo?, QuantityValue>? func))
        {
            return func(value, culture);
        }

        if (context is null || culture is null)
        {
            return ConvertFrom(value);
        }

        return base.ConvertFrom(context, culture, value);
    }
}
