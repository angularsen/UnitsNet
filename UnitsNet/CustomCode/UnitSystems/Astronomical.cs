using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     The astronomical system of units, formerly called the IAU System of Astronomical Constants, is a system of
    ///     measurement developed for use in astronomy. It was adopted by the International Astronomical Union in 1976 via
    ///     Resolution No. 1, and has been significantly updated in 1994 and 2009.
    /// </summary>
    public partial class Astronomical : UnitSystem
    {
        /// <summary>
        ///     Construct a new instance of the Astronomical unit system
        /// </summary>
        public Astronomical() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
