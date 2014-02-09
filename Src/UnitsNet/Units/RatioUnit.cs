using System;
using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum RatioUnit
    {
        [I18n("en-US", "undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,
        
        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1)]
        DecimalFraction, // Base unit

        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1e-2, "Percent")]
        Percent,

        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1e-3)]
        PartsPerThousand,

        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1e-6)]
        PartsPerMillion,

        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1e-9)]
        PartsPerBillion,

        [I18n("en-US", "")]
        [I18n("ru-RU", "")]
        [Ratio(1e-12)]
        PartsPerTrillion,
    }
}