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

    switch ($baseType) {
        long {
            $convertToBaseType = "Convert.ToInt64"
            break
        }
        double {
            $convertToBaseType = "Convert.ToDouble"
            break
        }
        decimal {
            $convertToBaseType = "Convert.ToDecimal"
            break
        }
        default {
            throw "Base type not supported: $baseType"
        }
    }
@"
// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
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
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

#if WINDOWS_UWP
using Culture = System.String;
#else
using Culture = System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     $($unitClass.XmlDoc)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class $className
#else
    public partial struct $className : IComparable, IComparable<$className>
#endif
    {
        /// <summary>
        ///     Base unit of $className.
        /// </summary>
        private readonly $baseType $baseUnitFieldName;

#if WINDOWS_UWP
        public $className() : this(0)
        {
        }
#endif

        public $className(double $baseUnitPluralNameLower)
        {
            $baseUnitFieldName = $convertToBaseType($baseUnitPluralNameLower);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        $className(long $baseUnitPluralNameLower)
        {
            $baseUnitFieldName = $convertToBaseType($baseUnitPluralNameLower);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        $className(decimal $baseUnitPluralNameLower)
        {
            $baseUnitFieldName = $convertToBaseType($baseUnitPluralNameLower);
        }

        #region Properties

        public static $unitEnumName BaseUnit
        {
            get { return $unitEnumName.$baseUnitSingularName; }
        }
"@; foreach ($unit in $units) {
        $propertyName = $unit.PluralName;
        $obsoleteAttribute = GetObsoleteAttribute($unit);
        if ($obsoleteAttribute)
        {
            $obsoleteAttribute = "`r`n        " + $obsoleteAttribute; # apply padding to conformance with code format in this page
        }

        $fromBaseToUnitFunc = $unit.FromBaseToUnitFunc.Replace("x", $baseUnitFieldName);@"

        /// <summary>
        ///     Get $className in $propertyName.
        /// </summary>$($obsoleteAttribute)
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
#if !WINDOWS_UWP
"@; foreach ($unit in $units) {
    $valueParamName = $unit.PluralName.ToLowerInvariant();
        $func = $unit.FromUnitToBaseFunc.Replace("x", "$($valueParamName).Value");@"
        /// <summary>
        ///     Get nullable $className from nullable $($unit.PluralName).
        /// </summary>
        public static $($className)? From$($unit.PluralName)(double? $valueParamName)
        {
            if ($($valueParamName).HasValue)
            {
                return From$($unit.PluralName)($($valueParamName).Value);
            }
            else
            {
                return null;
            }
        }

"@; }@"
#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="$unitEnumName" /> to <see cref="$className" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>$className unit value.</returns>
        public static $className From(double val, $unitEnumName fromUnit)
        {
            switch (fromUnit)
            {
"@; foreach ($unit in $units) {@"
                case $unitEnumName.$($unit.SingularName):
                    return From$($unit.PluralName)(val);
"@; }@"

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="$unitEnumName" /> to <see cref="$className" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>$className unit value.</returns>
        public static $($className)? From(double? value, $unitEnumName fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
"@; foreach ($unit in $units) {@"
                case $unitEnumName.$($unit.SingularName):
                    return From$($unit.PluralName)(value.Value);
"@; }@"

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
#endif

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation($unitEnumName unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation($unitEnumName unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion
"@; if ($unitClass.Logarithmic -eq $true) {
        # Call another script function to generate logarithm-specific arithmetic operator code.
        GenerateLogarithmicArithmeticOperators -className $className -baseUnitFieldName $baseUnitFieldName -baseType $baseType -scalingFactor $unitClass.LogarithmicScalingFactor
    }
    else {@"

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion
"@; }@"

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is $className)) throw new ArgumentException("Expected type $className.", "obj");
            return CompareTo(($className) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo($className other)
        {
            return $baseUnitFieldName.CompareTo(other.$baseUnitFieldName);
        }

#if !WINDOWS_UWP
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
#endif

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

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static $className Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static $className Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var exponentialRegex = @"(?:[eE][-+]?\d+)?)";
            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                            numRegex,                // capture base (integral) Quantity value
                            exponentialRegex,        // capture exponential (if any), end of Quantity capturing
                            @"\s?",                  // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d,]+)",   // capture Unit (non-whitespace) input
                            @"(and)?,?",             // allow "and" & "," separators between quantities
                            @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }
            return quantities.Aggregate((x, y) => $className.From$baseUnitPluralName(x.$baseUnitPluralName + y.$baseUnitPluralName));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<$className> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<$className>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != "")
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
                if (valueString == "" && unitString == "") continue;

                try
                {
                    $unitEnumName unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }
            return converted;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static $unitEnumName ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static $unitEnumName ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static $unitEnumName ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<$unitEnumName>(str.Trim());

            if (unit == $unitEnumName.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized $unitEnumName.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is $baseUnitSingularName
        /// </summary>
        public static $unitEnumName ToStringDefaultUnit { get; set; } = $unitEnumName.$baseUnitSingularName;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString($unitEnumName unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString($unitEnumName unit, [CanBeNull] Culture culture)
        {
            return ToString(unit, culture, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString($unitEnumName unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, culture, format);
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
        public string ToString($unitEnumName unit, [CanBeNull] Culture culture, [NotNull] string format,
            [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, formatProvider, args);
            return string.Format(formatProvider, format, formatArgs);
        }

        /// <summary>
        /// Represents the largest possible value of $className
        /// </summary>
        public static $className MaxValue
        {
            get
            {
                return new $className($baseType.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of $className
        /// </summary>
        public static $className MinValue
        {
            get
            {
                return new $className($baseType.MinValue);
            }
        }
    }
}
"@;
}