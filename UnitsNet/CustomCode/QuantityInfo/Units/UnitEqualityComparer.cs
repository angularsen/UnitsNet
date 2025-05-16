#if NETSTANDARD2_0
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnitsNet;

/// <summary>
///     Provides a custom equality comparer for enumerations that represent units.
/// </summary>
/// <typeparam name="TUnit">The enumeration type representing the unit.</typeparam>
/// <remarks>
///     This comparer uses the <see cref="Unsafe" /> class to convert the enumeration to an
///     integer,
///     which is faster than the default equality comparer on .NET Framework. On .NET 8, the performance is comparable.
/// </remarks>
internal class UnitEqualityComparer<TUnit> : IEqualityComparer<TUnit>
    where TUnit : struct, Enum
{
    // Singleton instance of the comparer
    public static readonly UnitEqualityComparer<TUnit> Default = new();

    private UnitEqualityComparer()
    {
    }

    public bool Equals(TUnit x, TUnit y)
    {
        // Use Unsafe.As to convert enums to integers for comparison
        var xInt = Unsafe.As<TUnit, int>(ref x);
        var yInt = Unsafe.As<TUnit, int>(ref y);
        return xInt == yInt;
    }

    public int GetHashCode(TUnit obj)
    {
        // Use Unsafe.As to convert enum to integer for hash code calculation
        var objInt = Unsafe.As<TUnit, int>(ref obj);
        return objInt.GetHashCode();
    }
}
#endif
