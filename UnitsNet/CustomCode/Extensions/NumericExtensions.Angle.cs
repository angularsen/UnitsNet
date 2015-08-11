using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static class Angle
    {
        /// <summary>
        ///     Returns Angle in Degrees
        /// </summary>
        /// <param name="_inputAngle">Degrees</param>
        /// <returns></returns>
        public static UnitsNet.Angle Degrees(this double _inputAngle)
        {
            return new UnitsNet.Angle(_inputAngle);
        }

        /// <summary>
        ///     Returns Angle in Degrees
        /// </summary>
        /// <param name="_inputAngle">Radians</param>
        /// <returns></returns>
        public static UnitsNet.Angle Radians(this double _inputAngle)
        {
            return UnitsNet.Angle.FromRadians(_inputAngle);
        }

        /// <summary>
        ///     Returns Angle in Degrees
        /// </summary>
        /// <param name="_inputAngle">Grads</param>
        /// <returns></returns>
        public static UnitsNet.Angle Grads(this double _inputAngle)
        {
            return UnitsNet.Angle.FromGradians(_inputAngle)
        }
    }
}
