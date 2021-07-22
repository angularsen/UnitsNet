using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     The centimetre–gram–second system of units (abbreviated CGS or cgs) is a variant of the metric system based on the
    ///     centimetre as the unit of length, the gram as the unit of mass, and the second as the unit of time. All CGS
    ///     mechanical units are unambiguously derived from these three base units, but there are several different ways of
    ///     extending the CGS system to cover electromagnetism.[1][2][3]
    ///     The CGS system has been largely supplanted by the MKS system based on the metre, kilogram, and second, which was in
    ///     turn extended and replaced by the International System of Units(SI). In many fields of science and engineering, SI
    ///     is the only system of units in use but there remain certain subfields where CGS is prevalent.
    /// </summary>
    public partial class CGS : UnitSystem
    {
        /// <summary>
        /// Construct a new instance of the CGS unit system
        /// </summary>
        public CGS() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
