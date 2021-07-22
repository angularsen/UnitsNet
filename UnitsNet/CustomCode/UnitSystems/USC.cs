using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     United States customary units are a system of measurements commonly used in the United States. The United States
    ///     customary system (USCS or USC) developed from English units which were in use in the British Empire before the U.S.
    ///     became an independent country. However, the United Kingdom's system of measures was overhauled in 1824 to create
    ///     the imperial system, changing the definitions of some units. Therefore, while many U.S. units are essentially
    ///     similar to their Imperial counterparts, there are significant differences between the systems.
    /// </summary>
    public partial class USC : UnitSystem
    {
        /// <summary>
        ///     Construct a new instance of the UCS unit system
        /// </summary>
        public USC() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
