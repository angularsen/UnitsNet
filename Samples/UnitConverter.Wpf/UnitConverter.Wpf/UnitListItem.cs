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
        public UnitListItem(object val)
        {
            UnitEnumValue = val;
            UnitEnumValueInt = (int) val;
            UnitEnumType = val.GetType();
            Abbreviation = UnitSystem.Default.GetDefaultAbbreviation(UnitEnumType, UnitEnumValueInt);

            Text = $"{val} [{Abbreviation}]";
        }

        public string Text { get; }
        public object UnitEnumValue { get; }
        public int UnitEnumValueInt { get; }
        public Type UnitEnumType { get; }
        public string Abbreviation { get; }
    }
}