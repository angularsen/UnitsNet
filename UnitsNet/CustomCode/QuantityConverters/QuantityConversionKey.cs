// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     Represents the mapping-key used for converting between the units of two different quantities.
/// </summary>
[DebuggerDisplay("{FromUnit.GetDebuggerDisplay(),nq} -> {ResultType.Name,nq}")]
internal readonly record struct QuantityConversionKey
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityConversionKey" /> struct.
    /// </summary>
    /// <param name="FromUnit">The unit key representing the source unit of the conversion.</param>
    /// <param name="ResultType">The type representing the target quantity of the conversion.</param>
    public QuantityConversionKey(UnitKey FromUnit, Type ResultType)
    {
        this.FromUnit = FromUnit;
        this.ResultType = ResultType;
    }

    public UnitKey FromUnit { get; }
    public Type ResultType { get; }

    /// <summary>
    ///     Creates a new instance of <see cref="QuantityConversionKey" /> using the specified source unit and target unit
    ///     type.
    /// </summary>
    /// <typeparam name="TSourceUnit">The type of the source units, which must be a struct and an enum.</typeparam>
    /// <typeparam name="TTargetUnit">The type of the target units, which must be a struct and an enum.</typeparam>
    /// <param name="fromUnit">The unit of the quantity to convert from.</param>
    /// <returns>
    ///     A new <see cref="QuantityConversionKey" /> representing the conversion from <paramref name="fromUnit" /> to the
    ///     type <typeparamref name="TTargetUnit" />.
    /// </returns>
    public static QuantityConversionKey Create<TSourceUnit, TTargetUnit>(TSourceUnit fromUnit)
        where TSourceUnit : struct, Enum
        where TTargetUnit : struct, Enum
    {
        return new QuantityConversionKey(UnitKey.ForUnit(fromUnit), typeof(TTargetUnit));
    }
}
