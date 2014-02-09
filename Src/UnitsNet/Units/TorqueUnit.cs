using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum TorqueUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        // Metric

        [I18n("en-US", "Nm")]
        [I18n("ru-RU", "Н·м")]
        [Torque(1)]
        Newtonmeter,
    }
}