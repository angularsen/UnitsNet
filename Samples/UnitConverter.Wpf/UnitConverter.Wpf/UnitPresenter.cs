using System;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    public class UnitPresenter
    {
        public string Text { get; }
        public object UnitEnumValue { get; }
        public int UnitEnumValueInt { get; }
        public Type UnitEnumType { get; }
        public string Abbreviation { get; }

        public UnitPresenter(object val)
        {
            UnitEnumValue = val;
            UnitEnumValueInt = (int)val;
            UnitEnumType = val.GetType();
            Abbreviation = UnitSystem.Default.GetDefaultAbbreviation(UnitEnumType, UnitEnumValueInt);

            Text = $"{val} [{Abbreviation}]";
        }

    }
}