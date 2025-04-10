// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;

namespace UnitsNet.InternalHelpers;

internal static class EnumHelpers
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
