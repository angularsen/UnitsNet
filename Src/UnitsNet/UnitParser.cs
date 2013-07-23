using System;
using System.Globalization;

namespace UnitsNet
{
    public static class UnitParser
    {
        /// <summary>
        ///     Returns a Unit based on the string representation for that unit.
        ///     Example: Parse("kg"); or Parse("Kilogram");
        /// </summary>
        /// <returns>true if parse was successful</returns>
        public static bool TryParse(string unitText, out Unit result, Unit fallback, CultureInfo culture = null)
        {
            if (String.IsNullOrEmpty(unitText))
                throw new ArgumentException(
                    "Invalid unit description. Should for instance be kg or Kilogram to represent Unit.Kilogram type.");

            const StringComparison invariantIgnoreCase = StringComparison.OrdinalIgnoreCase;


            // Iterate over all the unit types and look for matching names or abbreviations
            foreach (Unit unitType in EnumUtils.GetEnumValues<Unit>())
            {
                if (
                    unitText.Equals(UnitSystem.Create(culture).GetDefaultAbbreviation(unitType), invariantIgnoreCase) ||
                    unitText.Equals(unitType.ToString(), invariantIgnoreCase))
                {
                    result = unitType;
                    return true;
                }
            }

            result = fallback;
            return false;
        }
    }
}