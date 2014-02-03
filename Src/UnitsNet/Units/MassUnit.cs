using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum MassUnit
    {
        Undefined = 0,

        // Metric
        [I18n("en-US", "Mt")]
        [I18n("ru-RU", "Мт")]
        [Mass(1e9)]
        Megatonne,

        [I18n("en-US", "kt")]
        [I18n("ru-RU", "кт")]
        [Mass(1e6)]
        Kilotonne,

        [I18n("en-US", "t")]
        [I18n("ru-RU", "т")]
        [Mass(1e3)]
        Tonne,

        [I18n("en-US", "kg")]
        [I18n("ru-RU", "кг")]
        [Mass(1)]
        Kilogram, // Base unit

        [I18n("en-US", "hg")]
        [I18n("ru-RU", "гг")]
        [Mass(1e-1)]
        Hectogram,

        [I18n("en-US", "dag")]
        [I18n("ru-RU", "даг")]
        [Mass(1e-2)]
        Decagram,

        [I18n("en-US", "g")]
        [I18n("ru-RU", "г")]
        [Mass(1e-3)]
        Gram,

        [I18n("en-US", "dg")]
        [I18n("ru-RU", "дг")]
        [Mass(1e-4)]
        Decigram,

        [I18n("en-US", "cg")]
        [I18n("ru-RU", "сг")]
        [Mass(1e-5)]
        Centigram,

        [I18n("en-US", "mg")]
        [I18n("ru-RU", "мг")]
        [Mass(1e-6)]
        Milligram,

        [I18n("en-US", "µg")]
        [I18n("ru-RU", "мкг")]
        [Mass(1e-9)]
        Microgram,

        [I18n("en-US", "ng")]
        [I18n("ru-RU", "нг")]
        [Mass(1e-12)]
        Nanogram,

        // US, imperial and other
        /// <summary>
        ///     The short ton is a unit of mass equal to 2,000 pounds (907.18474 kg), that is most commonly used in the United States – known there simply as the ton.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Short_ton</remarks>
        [I18n("en-US", "short tn")]
        [I18n("ru-RU", "тонна малая")]
        [Mass(907.18474)]
        ShortTon,

        /// <summary>
        ///     The pound or pound-mass (abbreviations: lb, lbm) is a unit of mass used in the imperial, United States customary and other systems of measurement. A number of different definitions have been used, the most common today being the international avoirdupois pound which is legally defined as exactly 0.45359237 kilograms, and which is divided into 16 avoirdupois ounces.
        /// </summary>
        [I18n("en-US", "lb")]
        //[I18n("ru-RU", "TODO")]
        [Mass(0.45359237)]
        Pound,

        /// <summary>
        ///     Long ton (weight ton or Imperial ton) is a unit of mass equal to 2,240 pounds (1,016 kg) and is the name for the unit called the "ton" in the avoirdupois or Imperial system of measurements that was used in the United Kingdom and several other Commonwealth countries before metrication.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Long_ton</remarks>
        [I18n("en-US", "long tn")]
        [I18n("ru-RU", "тонна большая")]
        [Mass(1016.0469088)]
        LongTon,    
    }
}