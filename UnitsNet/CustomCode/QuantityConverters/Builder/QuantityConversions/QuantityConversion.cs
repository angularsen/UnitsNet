// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     Represents an implicit conversion between two quantity types.
/// </summary>
/// <remarks>
///     This record is used to define implicit conversions between different quantity types in the UnitsNet library.
///     The conversion is considered commutative, meaning that a conversion from type A to type B is equivalent to a
///     conversion from type B to type A.
/// </remarks>
[DebuggerDisplay("{LeftQuantity.Name,nq} <-> {RightQuantity.Name,nq}")]
internal readonly record struct QuantityConversion
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityConversion" /> struct.
    /// </summary>
    /// <param name="leftQuantity">The quantity information for first quantity in the conversion.</param>
    /// <param name="rightQuantity">The quantity information for the second quantity of the conversion.</param>
    /// <remarks>
    ///     This constructor sets up the implicit conversion between two quantity types,
    ///     ensuring that the conversion is commutative.
    /// </remarks>
    public QuantityConversion(QuantityInfo leftQuantity, QuantityInfo rightQuantity)
    {
        LeftQuantity = leftQuantity;
        RightQuantity = rightQuantity;
    }

    public QuantityInfo LeftQuantity { get; }
    public QuantityInfo RightQuantity { get; }

    public bool Equals(QuantityConversion other)
    {
        return (LeftQuantity.Equals(other.LeftQuantity) && RightQuantity.Equals(other.RightQuantity)) ||
               (LeftQuantity.Equals(other.RightQuantity) && RightQuantity.Equals(other.LeftQuantity));
    }

    public override int GetHashCode()
    {
        var hash1 = LeftQuantity.GetHashCode();
        var hash2 = RightQuantity.GetHashCode();
        // Use a commutative hash code combination to ensure (X1, X2) and (X2, X1) produce the same hash code
        return hash1 ^ hash2;
    }

    public void Deconstruct(out QuantityInfo leftQuantity, out QuantityInfo rightQuantity)
    {
        leftQuantity = LeftQuantity;
        rightQuantity = RightQuantity;
    }
}
