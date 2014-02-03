using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum ElectricPotentialUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0, 

        [I18n("en-US", "V")]
        [I18n("ru-RU", "В")]
        [ElectricPotential(1)]
        Volt,
    }
}