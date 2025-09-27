// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     Represents an implicit conversion between two quantity types, represented by their unique
///     <see cref="QuantityInfo.QuantityType" />.
/// </summary>
/// <remarks>
///     This record is used to define implicit conversions between different quantity types in the UnitsNet library.
///     The conversion is considered commutative, meaning that a conversion from type A to type B is equivalent to a
///     conversion from type B to type A.
/// </remarks>
[DebuggerDisplay("{FirstQuantityType.Name,nq} <-> {SecondQuantityType.Name,nq}")]
internal readonly record struct QuantityConversionMapping
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityConversionMapping" /> struct, representing an implicit
    ///     conversion
    ///     between two quantity types.
    /// </summary>
    /// <param name="firstQuantityType">The type of the first quantity involved in the conversion.</param>
    /// <param name="secondQuantityType">The type of the second quantity involved in the conversion.</param>
    internal QuantityConversionMapping(Type firstQuantityType, Type secondQuantityType)
    {
        FirstQuantityType = firstQuantityType;
        SecondQuantityType = secondQuantityType;
    }

    public Type FirstQuantityType { get; }
    public Type SecondQuantityType { get; }

    /// <summary>
    ///     Creates an implicit conversion between two quantity types.
    /// </summary>
    /// <typeparam name="TFirstQuantity">The type of the first quantity.</typeparam>
    /// <typeparam name="TSecondQuantity">The type of the second quantity.</typeparam>
    /// <returns>
    ///     An <see cref="QuantityConversionMapping" /> instance representing the conversion between the specified quantity
    ///     types.
    /// </returns>
    public static QuantityConversionMapping Create<TFirstQuantity, TSecondQuantity>()
        where TFirstQuantity : IQuantity
        where TSecondQuantity : IQuantity
    {
        return new QuantityConversionMapping(typeof(TFirstQuantity), typeof(TSecondQuantity));
    }

    public bool Equals(QuantityConversionMapping other)
    {
        return (FirstQuantityType == other.FirstQuantityType && SecondQuantityType == other.SecondQuantityType) ||
               (FirstQuantityType == other.SecondQuantityType && SecondQuantityType == other.FirstQuantityType);
    }

    public override int GetHashCode()
    {
        var hash1 = FirstQuantityType.GetHashCode();
        var hash2 = SecondQuantityType.GetHashCode();
        // Use a commutative hash code combination to ensure (X1, X2) and (X2, X1) produce the same hash code
        return hash1 ^ hash2;
    }
}
