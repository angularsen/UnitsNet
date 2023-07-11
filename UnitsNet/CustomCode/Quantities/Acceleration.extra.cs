// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Acceleration
    {
        /// <summary>
        /// Multiply <see cref="Acceleration"/> and <see cref="Density"/> to get <see cref="SpecificWeight"/>.
        /// </summary>
        public static SpecificWeight operator *(Acceleration acceleration, Density density)
        {
            return new SpecificWeight(acceleration.MetersPerSecondSquared * density.KilogramsPerCubicMeter, UnitsNet.Units.SpecificWeightUnit.NewtonPerCubicMeter);
        }

        /// <summary>
        /// Multiply <see cref="Acceleration"/> and <see cref="Duration"/> to get <see cref="Speed"/>.
        /// </summary>
        public static Speed operator *(Acceleration acceleration, Duration duration)
        {
            return new Speed(acceleration.MetersPerSecondSquared * duration.Seconds, UnitsNet.Units.SpeedUnit.MeterPerSecond);
        }

        /// <summary>
        /// Divide  <see cref="Acceleration"/> by <see cref="Duration"/> to get <see cref="Jerk"/>.
        /// </summary>
        public static Jerk operator /(Acceleration acceleration, Duration duration)
        {
            return new Jerk(acceleration.MetersPerSecondSquared / duration.Seconds, UnitsNet.Units.JerkUnit.MeterPerSecondCubed);
        }
    }
}
