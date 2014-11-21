function GenerateUnitClassSourceCode($unitClass)
{
    $className = $unitClass.Name;
    $units = $unitClass.Units;
    $baseType = $unitClass.BaseType;    
    $baseUnit = $units | where { $_.SingularName -eq $unitClass.BaseUnit }
    $baseUnitSingularName = $baseUnit.SingularName
    $baseUnitPluralName = $baseUnit.PluralName
    $baseUnitPluralNameLower = $baseUnitPluralName.ToLowerInvariant()    
    $unitEnumName = "$className" + "Unit";
    $baseUnitFieldName = "_"+[Char]::ToLowerInvariant($baseUnitPluralName[0]) + $baseUnitPluralName.Substring(1);

@"
// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     $($unitClass.XmlDoc)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct $className : IComparable, IComparable<$className>
    {
        /// <summary>
        ///     Base unit of $className.
        /// </summary>
        private readonly $baseType $baseUnitFieldName;

        public $className($baseType $baseUnitPluralNameLower) : this()
        {
            $baseUnitFieldName = $baseUnitPluralNameLower;
        }

        #region Properties
"@; foreach ($unit in $units) {
        $propertyName = $unit.PluralName;
        $fromBaseToUnitFunc = $unit.FromBaseToUnitFunc.Replace("x", $baseUnitFieldName);@"

        /// <summary>
        ///     Get $className in $propertyName.
        /// </summary>
        public double $propertyName
        {
            get { return $fromBaseToUnitFunc; }
        }
"@; }@"

        #endregion

        #region Static 

        public static $className Zero
        {
            get { return new $className(); }
        }

"@; foreach ($unit in $units) {
    $valueParamName = $unit.PluralName.ToLowerInvariant();
        $func = $unit.FromUnitToBaseFunc.Replace("x", $valueParamName);@"
        /// <summary>
        ///     Get $className from $($unit.PluralName).
        /// </summary>
        public static $className From$($unit.PluralName)(double $valueParamName)
        {
            return new $className($func);
        }

"@; }@"

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="$unitEnumName" /> to <see cref="$className" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>$className unit value.</returns>
        public static $className From(double value, $unitEnumName fromUnit)
        {
            switch (fromUnit)
            {
"@; foreach ($unit in $units) {@"
                case $unitEnumName.$($unit.SingularName):
                    return From$($unit.PluralName)(value);
"@; }@"

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation($unitEnumName unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion
"@; if ($unitClass.Logarithmic -eq $true) {
        # Dot into the script to load its functions into the global scope so we can access them.
        . .\Include-GenerateLogarithmicCode.ps1; 
        # Call another script function to generate logarithm-specific arithmetic operator code.
        GenerateUnitClassSourceCode -className $className -baseUnitFieldName $baseUnitFieldName -baseType $baseType -scalingFactor $unitClass.LogarithmicScalingFactor
    }
    else {@"

        #region Arithmetic Operators

        public static $className operator -($className right)
        {
            return new $className(-right.$baseUnitFieldName);
        }

        public static $className operator +($className left, $className right)
        {
            return new $className(left.$baseUnitFieldName + right.$baseUnitFieldName);
        }

        public static $className operator -($className left, $className right)
        {
            return new $className(left.$baseUnitFieldName - right.$baseUnitFieldName);
        }

        public static $className operator *($baseType left, $className right)
        {
            return new $className(left*right.$baseUnitFieldName);
        }

        public static $className operator *($className left, double right)
        {
            return new $className(left.$baseUnitFieldName*($baseType)right);
        }

        public static $className operator /($className left, double right)
        {
            return new $className(left.$baseUnitFieldName/($baseType)right);
        }

        public static double operator /($className left, $className right)
        {
            return Convert.ToDouble(left.$baseUnitFieldName/right.$baseUnitFieldName);
        }

        #endregion
"@; }@"

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is $className)) throw new ArgumentException("Expected type $className.", "obj");
            return CompareTo(($className) obj);
        }

        public int CompareTo($className other)
        {
            return $baseUnitFieldName.CompareTo(other.$baseUnitFieldName);
        }

        public static bool operator <=($className left, $className right)
        {
            return left.$baseUnitFieldName <= right.$baseUnitFieldName;
        }

        public static bool operator >=($className left, $className right)
        {
            return left.$baseUnitFieldName >= right.$baseUnitFieldName;
        }

        public static bool operator <($className left, $className right)
        {
            return left.$baseUnitFieldName < right.$baseUnitFieldName;
        }

        public static bool operator >($className left, $className right)
        {
            return left.$baseUnitFieldName > right.$baseUnitFieldName;
        }

        public static bool operator ==($className left, $className right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.$baseUnitFieldName == right.$baseUnitFieldName;
        }

        public static bool operator !=($className left, $className right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.$baseUnitFieldName != right.$baseUnitFieldName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return $baseUnitFieldName.Equals((($className) obj).$baseUnitFieldName);
        }

        public override int GetHashCode()
        {
            return $baseUnitFieldName.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As($unitEnumName unit)
        {
            switch (unit)
            {
"@; foreach ($unit in $units) {@"
                case $unitEnumName.$($unit.SingularName):
                    return $($unit.PluralName);
"@; }@"

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString($unitEnumName.$baseUnitSingularName);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
		/// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString($unitEnumName unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString($unitEnumName unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
"@;
}