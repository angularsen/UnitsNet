using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum DurationUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        /// <summary>
        ///     Do not use for accurate calculations. Does not take calendar into account and simply represents a year of 365 days.
        /// </summary>

        [I18n("en-US", "year", "years")]
        [I18n("ru-RU", "год")]
        [Duration(365*24*3600)]
        Year365Days,

        /// <summary>
        ///     Do not use for accurate calculations. Does not take calendar into account and simply represents a month of 30 days.
        /// </summary>
        [I18n("en-US", "month", "months")]
        [I18n("ru-RU", "месяц")]
        [Duration(30*24*3600)]
        Month30Days,

        [I18n("en-US", "wk", "week", "weeks")]
        [I18n("ru-RU", "мин")]
        [Duration(7*24*3600)]
        Week,

        [I18n("en-US", "day", "days")]
        [I18n("ru-RU", "д")]
        [Duration(24*3600)]
        Day,

        [I18n("en-US", "h", "hr", "hrs", "hour", "hours")]
        [I18n("ru-RU", "ч")]
        [Duration(3600)]
        Hour,

        [I18n("en-US", "m", "min", "minute", "minutes")]
        [I18n("ru-RU", "мин")]
        [Duration(60)]
        Minute,

        [I18n("en-US", "s", "sec", "secs", "second", "seconds")]
        [I18n("ru-RU", "с")] 
        [Duration(1)]
        Second, // Base unit

        [I18n("en-US", "ms")]
        [I18n("ru-RU", "мс")]
        [Duration(1e-3)]
        Millisecond,

        [I18n("en-US", "µs")]
        [I18n("ru-RU", "мкс")]
        [Duration(1e-6)]
        Microsecond,

        [I18n("en-US", "ns")]
        [I18n("ru-RU", "нс")]
        [Duration(1e-9)]
        Nanosecond,
    }
}