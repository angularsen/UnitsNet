using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum RotationalSpeedUnit
    {
        Undefined = 0, 

        [I18n("en-US", "r/s")]
        [I18n("ru-RU", "об/с")]
        [RotationalSpeed(1, "RevolutionsPerSecond")]
        RevolutionPerSecond,

        [I18n("en-US", "rpm", "r/min")]
        [I18n("ru-RU", "об/мин")]
        [RotationalSpeed(1.0 / 60, "RevolutionsPerMinute")]
        RevolutionPerMinute,
    }
}