using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum SpeedUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        // Sources: http://en.wikipedia.org/wiki/Speed 

        [I18n("en-US", "ft/s")]
        //[I18n("ru-RU", "")]
        [Speed(0.3048, "FeetPerSecond")]
        FootPerSecond,

        [I18n("en-US", "km/h")]
        //[I18n("ru-RU", "")]
        [Speed(1d / 3.6, "KilometersPerHour")]
        KilometerPerHour,

        [I18n("en-US", "kt", "kn", "knot", "knots")]
        //[I18n("ru-RU", "")]
        [Speed(0.514444)]
        Knot,

        [I18n("en-US", "m/s")]
        //[I18n("ru-RU", "")]
        [Speed(1, "MetersPerSecond")]
        MeterPerSecond, // Base unit.

        [I18n("en-US", "mph")]
        //[I18n("ru-RU", "")]
        [Speed(0.44704, "MilesPerHour")]
        MilePerHour,
    }
}