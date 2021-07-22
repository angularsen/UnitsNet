using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     The system of imperial units or the imperial system (also known as British Imperial[1] or Exchequer Standards of
    ///     1825) is the system of units first defined in the British Weights and Measures Act of 1824, which was later refined
    ///     and reduced. The imperial units replaced the Winchester Standards, which were in effect from 1588 to 1825.[2] The
    ///     system came into official use across the British Empire. By the late 20th century, most nations of the former
    ///     empire had officially adopted the metric system as their main system of measurement and imperial units are still
    ///     used in the United Kingdom, Canada and other countries formerly part of the British Empire. As part of the UK's
    ///     metrication programme, most of these imperial units are no longer statute measures. The imperial system developed
    ///     from what were first known as English units, as did the related system of United States customary units.
    /// </summary>
    public partial class BI : UnitSystem
    {
        /// <summary>
        /// Construct a new instance of the BI unit system
        /// </summary>
        public BI() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
