// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     Represents the mapping-key used for converting between the units of two different quantities.
/// </summary>
[DebuggerDisplay("{FromUnitKey,nq} -> {ToUnitKey,nq}")]
internal readonly record struct UnitConversionMapping
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitConversionMapping" /> struct with the specified source and target
    ///     unit keys.
    /// </summary>
    /// <param name="FromUnitKey">The key representing the source unit for the conversion.</param>
    /// <param name="ToUnitKey">The key representing the target unit for the conversion.</param>
    public UnitConversionMapping(UnitKey FromUnitKey, UnitKey ToUnitKey)
    {
        this.FromUnitKey = FromUnitKey;
        this.ToUnitKey = ToUnitKey;
    }

    public UnitKey FromUnitKey { get; }
    public UnitKey ToUnitKey { get; }

    /// <summary>
    ///     Creates a new instance of <see cref="UnitConversionKey" /> using the specified units.
    /// </summary>
    /// <typeparam name="TSourceUnit">The type of the source units, which must be a struct and an enum</typeparam>
    /// <typeparam name="TTargetUnit">The type of the target units, which must be a struct and an enum.</typeparam>
    /// <param name="fromUnit">The unit of the quantity to convert from.</param>
    /// <param name="toUnit">The unit to convert to.</param>
    /// <returns>
    ///     A new <see cref="UnitConversionMapping" /> representing the conversion from <paramref name="fromUnit" /> to
    ///     <paramref name="toUnit" />.
    /// </returns>
    public static UnitConversionMapping Create<TSourceUnit, TTargetUnit>(TSourceUnit fromUnit, TTargetUnit toUnit)
        where TSourceUnit : struct, Enum
        where TTargetUnit : struct, Enum
    {
        return new UnitConversionMapping(UnitKey.ForUnit(fromUnit), UnitKey.ForUnit(toUnit));
    }
}
