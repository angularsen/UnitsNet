using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsNet;

namespace UnitsNet.NumericExtensions
{
    public static partial class Acceleration
    {
        /// <summary>
        ///     Get Acceleration from MeterPerSecondSquared.
        /// </summary>
        /// <param name="_inputAcceleration"></param>
        /// <returns>Acceleration</returns>
        public static UnitsNet.Acceleration MetersPerSecondSquared(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration);
        }

        /// <summary>
        ///     Get Acceleration in Meters Per Second Squared based off Kilometers Per Second Squared
        /// </summary>
        /// <param name="_inputAcceleration"></param>
        /// <returns>Acceleration</returns>
        public static UnitsNet.Acceleration KilometersPerSecondSquared(this int _inputAcceleration)
        {
            return new UnitsNet.Acceleration(_inputAcceleration * 12960);
        }
    }
}
