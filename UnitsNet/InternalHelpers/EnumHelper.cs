// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if !NET7_0_OR_GREATER
using System.Linq;
#endif

namespace UnitsNet.InternalHelpers;

/// <summary>
///     Helper methods for working with <see cref="Enum"/> types.
/// </summary>
internal static class EnumHelper
{
    /// <summary>Retrieves an array of the values of the constants in a specified enumeration type.</summary>
    /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
    /// <returns>An array that contains the values of the constants in <typeparamref name="TEnum"/>.</returns>
    public static TEnum[] GetValues<TEnum>() where TEnum : struct, Enum
    {
#if NET7_0_OR_GREATER
        return Enum.GetValues<TEnum>();
#else
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
#endif
    }
}
