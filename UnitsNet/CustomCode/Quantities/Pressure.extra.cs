using System;
using UnitsNet.Units;

namespace UnitsNet;

public partial struct Pressure
{
    /// <summary>
    ///     Calculates the pressure at a given elevation.
    /// </summary>
    /// <param name="elevation">The elevation for which to calculate the pressure.</param>
    /// <returns>A Pressure struct representing the pressure at the given elevation.</returns>
    /// <remarks>
    ///     The calculation is based on the formula for pressure altitude from Wikipedia:
    ///     https://en.wikipedia.org/wiki/Pressure_altitude
    /// </remarks>
    public static Pressure FromElevation(Length elevation)
    {
        // Millibars = 1013.25 * (1 - (Length (Feet) / 145366.45)) ^ (1 / 0.190284)
        return new Pressure(1013.25 * Math.Pow(1 - elevation.Feet / 145366.45, 1 / 0.190284), PressureUnit.Millibar);
    }

    /// <summary>
    ///     Converts the pressure to an equivalent elevation or altitude.
    /// </summary>
    /// <returns>A <see cref="Length" /> object representing the equivalent elevation or altitude.</returns>
    /// <remarks>
    ///     The conversion is based on the formula for pressure altitude as described on Wikipedia
    ///     (https://en.wikipedia.org/wiki/Pressure_altitude).
    /// </remarks>
    public Length ToElevation()
    {
        // Length (Feet) = 145366.45 * (1 - (Millibars / 1013.25) ^ 0.190284)
        return new Length(145366.45 * (1 - Math.Pow(Millibars / 1013.25, 0.190284)), LengthUnit.Foot);
    }
}
