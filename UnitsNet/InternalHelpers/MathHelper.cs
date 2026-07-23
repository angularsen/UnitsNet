// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.InternalHelpers;

/// <summary>
///     Fallback math operations required by the netstandard2.0 assembly when it runs on .NET Framework 4.8.
/// </summary>
internal static class MathHelper
{
    /// <summary>
    ///     Calculates the specified root without <c>double.RootN</c>, which is unavailable when compiling the
    ///     netstandard2.0 assembly used by .NET Framework 4.8.
    /// </summary>
    public static double RootN(double number, int n)
    {
        bool isNegative = BitConverter.DoubleToInt64Bits(number) < 0;
        if (isNegative && n % 2 == 0)
        {
            return double.NaN;
        }

        double root = Math.Pow(Math.Abs(number), 1.0 / n);
        return isNegative ? -root : root;
    }
}
