using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum TemperatureUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        [I18n("en-US", "°C")]
        [I18n("ru-RU", "°C")]
        [Temperature(slope: 1, offset: 273.15, pluralName: "DegreesCelsius")]
        DegreeCelsius,

        [I18n("en-US", "°De")]
        [I18n("ru-RU", "°De")]
        [Temperature(slope: -2d / 3, offset: 373.15, pluralName: "DegreesDelisle")]
        DegreeDelisle,

        [I18n("en-US", "°F")]
        [I18n("ru-RU", "°F")]
        [Temperature(slope: 5d / 9, offset: 459.67 * 5d / 9, pluralName: "DegreesFahrenheit")]
        DegreeFahrenheit,

        [I18n("en-US", "K")]
        [I18n("ru-RU", "K")]
        [Temperature(1)]
        Kelvin, // Base unit

        [I18n("en-US", "°N")]
        [I18n("ru-RU", "°N")]
        [Temperature(slope: 100d / 33, offset: 273.15, pluralName: "DegreesNewton")]
        DegreeNewton,

        [I18n("en-US", "°R")]
        [I18n("ru-RU", "°R")]
        [Temperature(slope: 5d / 9, offset: 0, pluralName: "DegreesRankine")]
        DegreeRankine,

        [I18n("en-US", "°Ré")]
        [I18n("ru-RU", "°Ré")]
        [Temperature(slope: 5d / 4, offset: 273.15, pluralName: "DegreesReaumur")]
        DegreeReaumur,

        [I18n("en-US", "°Rø")]
        [I18n("ru-RU", "°Rø")]
        [Temperature(slope: 40d / 21, offset: 273.15 - 7.5 * 40d / 21, pluralName: "DegreesRoemer")]
        DegreeRoemer,
    }
}