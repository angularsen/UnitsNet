using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum AreaUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        // Metric 
        /*
         * International Nautical Mile
         * "Beginning on July 1, 1954, the National Bureau of Standards will use
         * the international Nautical Mile in lieu of the U.S. Nautical Mil. This deciision, replacint the U.S. Nautical
         * Mile of 1,853.248 meters (6,080.20 feet) by the International Nautical Mile of 1,852 meters (6,076.10333... feet),
         * confirms an official agreement between the Secretart of Commerce and the Secretary of Defense to use the 
         * Inernational Nautical Mile within their respective departments." http://physics.nist.gov/Pubs/SP447/app4.pdf
        */
        [I18n("en-US", "nmi²")]
        [I18n("ru-RU", "нмиля²")]
        [Length(3429904)]
        SquareInternationalNauticalMile,

        [I18n("en-US", "km²")]
        [I18n("ru-RU", "км²")]
        [Area(1e6)]
        SquareKilometer, 

        [I18n("en-US", "m²")]
        [I18n("ru-RU", "м²")]
        [Area(1)]
        SquareMeter, // Base unit

        [I18n("en-US", "dm²")]
        [I18n("ru-RU", "дм²")]
        [Area(1e-2)]
        SquareDecimeter,

        [I18n("en-US", "cm²")]
        [I18n("ru-RU", "см²")]
        [Area(1e-4)]
        SquareCentimeter,

        [I18n("en-US", "mm²")]
        [I18n("ru-RU", "мм²")]
        [Area(1e-6)]
        SquareMillimeter,

        // US, imperial and other

        [I18n("en-US", "mi²")]
        [I18n("ru-RU", "миля²")]
        [Area(2.59 * 1e6)]
        SquareMile,

        [I18n("en-US", "yd²")]
        [I18n("ru-RU", "ярд²")]
        [Area(0.836127)]
        SquareYard,

        [I18n("en-US", "ft²")]
        [I18n("ru-RU", "фут²")]
        [Area(0.092903, "SquareFeet")]
        SquareFoot,

        [I18n("en-US", "in²")]
        [I18n("ru-RU", "дюйм²")]
        [Area(0.00064516, "SquareInches")]
        SquareInch,
    }
}