using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum ElectricPotentialUnit
    {
        Undefined = 0, 

        [I18n("en-US", "V")]
        [I18n("ru-RU", "В")]
        [ElectricPotential(1)]
        Volt,
    }
}