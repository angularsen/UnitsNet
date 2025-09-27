// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Runtime.CompilerServices;

namespace UnitsNet;

/// <summary>
///     Represents the mapping-key used for converting between the units of the same quantity.
/// </summary>
internal readonly record struct UnitConversionKey
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitConversionKey" /> struct with the specified source unit key and
    ///     target unit value.
    /// </summary>
    /// <param name="FromUnitKey">The key representing the source unit for the conversion.</param>
    /// <param name="ToUnitValue">The integer value representing the target unit for the conversion.</param>
    public UnitConversionKey(UnitKey FromUnitKey, int ToUnitValue)
    {
        this.FromUnitKey = FromUnitKey;
        this.ToUnitValue = ToUnitValue;
    }

    /// <summary>
    ///     Gets a value indicating whether the conversion is to the same unit.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the conversion is to the same unit; otherwise, <c>false</c>.
    /// </value>
    public bool HasSameUnits
    {
        get => FromUnitKey.UnitEnumValue == ToUnitValue;
    }

    public UnitKey FromUnitKey { get; }
    public int ToUnitValue { get; }

    /// <summary>
    ///     Creates a new instance of <see cref="UnitConversionKey" /> using the specified units.
    /// </summary>
    /// <typeparam name="TUnit">The type of the units, which must be a struct and an enum.</typeparam>
    /// <param name="fromUnit">The unit of the quantity to convert from.</param>
    /// <param name="toUnit">The unit to convert to.</param>
    /// <returns>
    ///     A new <see cref="UnitConversionKey" /> representing the conversion from <paramref name="fromUnit" /> to
    ///     <paramref name="toUnit" />.
    /// </returns>
    public static UnitConversionKey Create<TUnit>(TUnit fromUnit, TUnit toUnit)
        where TUnit : struct, Enum
    {
        return new UnitConversionKey(UnitKey.ForUnit(fromUnit), Unsafe.As<TUnit, int>(ref toUnit));
    }

    /// <summary>
    ///     Creates a new instance of <see cref="UnitConversionKey" /> using the specified units.
    /// </summary>
    /// <param name="fromUnitKey">The unit of the quantity to convert from.</param>
    /// <param name="toUnitKey">The unit to convert to.</param>
    /// <returns>
    ///     A new <see cref="UnitConversionKey" /> representing the conversion from
    ///     <paramref name="fromUnitKey" /> to
    ///     <paramref name="toUnitKey" />.
    /// </returns>
    public static UnitConversionKey Create(UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        return new UnitConversionKey(fromUnitKey, toUnitKey.UnitEnumValue);
    }
}
