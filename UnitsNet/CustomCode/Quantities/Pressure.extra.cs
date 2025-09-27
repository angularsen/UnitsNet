using UnitsNet.Units;

namespace UnitsNet;

public partial struct Pressure
{
    /// <summary>
    ///     Calculates the pressure at a given elevation.
    /// </summary>
    /// <param name="elevation">The elevation for which to calculate the pressure.</param>
    /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 13.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///     Thrown when the number of significant digits is less than 1 or greater than 17.
    /// </exception>
    /// <returns>A Pressure struct representing the pressure at the given elevation.</returns>
    /// <remarks>
    ///     The calculation is based on the formula for pressure altitude from Wikipedia:
    ///     https://en.wikipedia.org/wiki/Pressure_altitude
    /// </remarks>
    public static Pressure FromElevation(Length elevation, byte significantDigits = 13)
    {
        // Millibars = 1013.25 * (1 - (Length (Feet) / 145366.45)) ^ (1 / 0.190284)
        return new Pressure(QuantityValue.FromDoubleRounded(1013.25 * Math.Pow(1 - elevation.Feet.ToDouble() / 145366.45, 1 / 0.190284), significantDigits),
            PressureUnit.Millibar);
    }

    /// <summary>
    ///     Converts the pressure to an equivalent elevation or altitude.
    /// </summary>
    /// <param name="significantDigits">The number of significant digits to round the result to. Default is 15.</param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///     Thrown when the number of significant digits is less than 1 or greater than 17.
    /// </exception>
    /// <returns>A <see cref="Length" /> object representing the equivalent elevation or altitude.</returns>
    /// <remarks>
    ///     The conversion is based on the formula for pressure altitude as described on Wikipedia
    ///     (https://en.wikipedia.org/wiki/Pressure_altitude).
    /// </remarks>
    public Length ToElevation(byte significantDigits = 15)
    {
        // Length (Feet) = 145366.45 * (1 - (Millibars / 1013.25) ^ 0.190284)
        return new Length(QuantityValue.FromDoubleRounded(145366.45 * (1 - Math.Pow(Millibars.ToDouble() / 1013.25, 0.190284)), significantDigits),
            LengthUnit.Foot);
    }
}
