using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum FlowUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0, 

        [I18n("en-US", "m³/s")]
        [I18n("ru-RU", "м³/с")]
        [Flow(1, "CubicMetersPerSecond")]
        CubicMeterPerSecond,

        [I18n("en-US", "m³/h")]
        [I18n("ru-RU", "м³/ч")]
        [Flow(1.0 / 3600, "CubicMetersPerHour")]
        CubicMeterPerHour,
    }
}