// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Numerics;

namespace UnitsNet.GenericMath;

/// <summary>
///     Provides generic math operations using the generic math interfaces implemented in .NET7 for UnitsNet.
/// </summary>
public static class GenericMathExtensions
{
    /// <summary>
    ///     Returns the sum of a sequence of vector quantities, such as Mass and Length.
    /// </summary>
    /// <param name="source">The values.</param>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <returns>The sum of the quantities, using the unit of the first element in the sequence.</returns>
    /// <remarks>
    ///     Unless
    ///     <typeparamref name="TQuantity" />
    ///     requires a custom implementation for the <see cref="IAdditionOperators{TSelf,TOther,TResult}" /> interface, you
    ///     should consider switching to one of the more performant versions of this extension, found in the
    ///     <see cref="LinearQuantityExtensions" />, <see cref="LogarithmicQuantityExtensions" /> and
    ///     <see cref="AffineQuantityExtensions" />.
    ///     <para>
    ///         Note that the generic math LINQ support is still missing in the BCL, but is being worked on:
    ///         <a href="https://github.com/dotnet/runtime/issues/64031">
    ///             API Proposal: Generic LINQ Numeric Operators · Issue
    ///             #64031 · dotnet/runtime
    ///         </a>
    ///     </para>
    /// </remarks>
    public static TQuantity Sum<TQuantity>(this IEnumerable<TQuantity> source)
        where TQuantity : IQuantity, IAdditionOperators<TQuantity, TQuantity, TQuantity>, IAdditiveIdentity<TQuantity, TQuantity>
    {
        using IEnumerator<TQuantity> e = source.GetEnumerator();
        if (!e.MoveNext())
        {
            return TQuantity.AdditiveIdentity;
        }

        TQuantity result = e.Current;
        while (e.MoveNext())
        {
            result += e.Current;
        }

        return result;
    }

    /// <summary>
    ///     Calculates the arithmetic average of a sequence of vector quantities, such as Mass and Length.
    /// </summary>
    /// <param name="source">The values.</param>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <returns>The average of the quantities, using the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     Unless
    ///     <typeparamref name="TQuantity" />
    ///     requires a custom implementation for the <see cref="IAdditionOperators{TSelf,TOther,TResult}" /> interface, you
    ///     should consider switching to one of the more performant versions of this extension, found in the
    ///     <see cref="LinearQuantityExtensions" />, <see cref="LogarithmicQuantityExtensions" /> and
    ///     <see cref="AffineQuantityExtensions" />.
    ///     <para>
    ///         Note that the generic math LINQ support is still missing in the BCL, but is being worked on:
    ///         <a href="https://github.com/dotnet/runtime/issues/64031">
    ///             API Proposal: Generic LINQ Numeric Operators · Issue
    ///             #64031 · dotnet/runtime
    ///         </a>
    ///     </para>
    /// </remarks>
    public static TQuantity Average<TQuantity>(this IEnumerable<TQuantity> source)
        where TQuantity : IQuantity, IAdditionOperators<TQuantity, TQuantity, TQuantity>, IAdditiveIdentity<TQuantity, TQuantity>,
        IDivisionOperators<TQuantity, QuantityValue, TQuantity>
    {
        using IEnumerator<TQuantity> e = source.GetEnumerator();
        if (!e.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        TQuantity result = e.Current;
        var nbQuantities = 1;
        while (e.MoveNext())
        {
            result += e.Current;
            nbQuantities++;
        }

        return result / nbQuantities;
    }
}
#endif
