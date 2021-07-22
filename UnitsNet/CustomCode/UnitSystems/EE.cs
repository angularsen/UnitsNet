using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     Some fields of engineering in the United States use a system of measurement of physical quantities known as the
    ///     English Engineering units. The system is based on United States customary units of measure.
    /// </summary>
    public partial class EE : UnitSystem
    {
        /// <summary>
        ///     Construct a new instance of the English Engineering unit system
        /// </summary>
        public EE() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
