// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER

using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace UnitsNet.GenericMath;

/// <summary>
///     Provides generic math operations to test out the new generic math interfaces implemented in .NET7 for UnitsNet
///     quantities using <see cref="decimal" /> as the internal value type, such as <see cref="Power" />, <see cref="BitRate" /> and
///     <see cref="Information" />.
/// </summary>
/// <remarks>
///     See <see cref="GenericMathExtensions" /> for quantities using <see cref="double" /> as the internal value type.
/// </remarks>
public static class DecimalGenericMathExtensions
{
    /// <summary>
    ///     Returns the average of values.
    /// </summary>
    /// <remarks>
    ///     This method is experimental and intended to test out the new generic math interfaces implemented in .NET7 for
    ///     UnitsNet quantities.<br />
    ///     Generic math interfaces might replace <see cref="UnitMath" />.<br />
    ///     Generic math LINQ support is still missing in the BCL, but is being worked on:
    ///     <a href="https://github.com/dotnet/runtime/issues/64031">
    ///         API Proposal: Generic LINQ Numeric Operators · Issue
    ///         #64031 · dotnet/runtime
    ///     </a>
    /// </remarks>
    /// <param name="source">The values.</param>
    /// <typeparam name="T">The value type.</typeparam>
    /// <returns>The average.</returns>
    public static T Average<T>(this IEnumerable<T> source)
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>, IDivisionOperators<T, decimal, T>
    {
        // Put accumulator on right hand side of the addition operator to construct quantities with the same unit as the values.
        // The addition operator implementation picks the unit from the left hand side, and the additive identity (e.g. Length.Zero) is always the base unit.
        (T value, int count) result = source.Aggregate(
            (value: T.AdditiveIdentity, count: 0),
            (acc, item) => (value: item + acc.value, count: acc.count + 1));

        return result.value / result.count;
    }
}
#endif
