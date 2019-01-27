using System;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     Represents an item in the from/to unit listboxes.
    ///     Provides a formatted <see cref="Text" /> property as well as holding on to the original unit enum value, in order
    ///     to perform the unit conversion.
    /// </summary>
    public sealed class UnitListItem
    {
        public UnitListItem(Enum val)
        {
            UnitEnumValue = val;
            UnitEnumValueInt = Convert.ToInt32(val);
            UnitEnumType = val.GetType();
            Abbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(UnitEnumType, UnitEnumValueInt);

            Text = $"{val} [{Abbreviation}]";
        }

        public string Text { get; }
        public Enum UnitEnumValue { get; }
        public int UnitEnumValueInt { get; }
        public Type UnitEnumType { get; }
        public string Abbreviation { get; }
    }
}
