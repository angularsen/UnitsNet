using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitsNet.NumericExtensions
{
    public static partial class Area
    {
        // Metric
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Meters Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area MetersSquared(this double _inputArea)
        {
            return new UnitsNet.Area(_inputArea);
        }
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Kilometers Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area KilometersSquared(this double _inputArea)
        {
            return UnitsNet.Area.FromSquareKilometers(_inputArea);
        }
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Centimeter Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area CentimeterSquared(this double _inputArea)
        {
            return UnitsNet.Area.FromSquareCentimeters(_inputArea);
        }
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Millimeter Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area MillimeterSquared(this double _inputArea)
        {
            return UnitsNet.Area.FromSquareMillimeters(_inputArea);
        }
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Miles Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area MilesSquared(this double _inputArea)
        {
            return UnitsNet.Area.FromSquareMiles(_inputArea);
        }
        /// <summary>
        /// Returns Area in Meters Squared
        /// </summary>
        /// <param name="_inputArea">Yards Squared</param>
        /// <returns></returns>
        public static UnitsNet.Area YardsSquared(this double _inputArea)
        {
            return UnitsNet.Area.FromSquareYards(_inputArea);
        }
    }
}
