using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum ForceUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        // Metric

        [I18n("en-US", "dyn")]
        [I18n("ru-RU", "дин")]
        [Force(1e-5, "Dyne")]
        Dyn,

        [I18n("en-US", "kgf")]
        [I18n("ru-RU", "кгс")]
        [Force(Constants.Gravity, "KilogramsForce")]
        KilogramForce,

        // Metric
        [I18n("en-US", "kN")]
        [I18n("ru-RU", "кН")]
        [Force(1e3)]
        Kilonewton,

        [I18n("en-US", "N")]
        [I18n("ru-RU", "Н")]
        [Force(1)]
        Newton, // Base unit


        // US, imperial and other

        [I18n("en-US", "kp")]
        [I18n("ru-RU", "кгс")]
        [Force(Constants.Gravity)]
        KiloPond,

        [I18n("en-US", "pdl")]
        [I18n("ru-RU", "паундаль")]
        [Force(0.13825502798973041652092282466083)]
        Poundal,

        [I18n("en-US", "lbf")]
        [I18n("ru-RU", "фунт-сила")]
        [Force(4.4482216152605095551842641431421)]
        PoundForce,

    }
}