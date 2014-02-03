using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum TorqueUnit
    {
        Undefined = 0,

        // Metric

        [I18n("en-US", "Nm")]
        [I18n("ru-RU", "Н·м")]
        [Torque(1)]
        Newtonmeter,
    }
}