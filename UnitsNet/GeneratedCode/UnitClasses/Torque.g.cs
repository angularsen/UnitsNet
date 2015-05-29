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
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Torque, moment or moment of force (see the terminology below), is the tendency of a force to rotate an object about an axis,[1] fulcrum, or pivot. Just as a force is a push or a pull, a torque can be thought of as a twist to an object. Mathematically, torque is defined as the cross product of the lever-arm distance and force, which tends to produce rotation. Loosely speaking, torque is a measure of the turning force on an object such as a bolt or a flywheel. For example, pushing or pulling the handle of a wrench connected to a nut or bolt produces a torque (turning force) that loosens or tightens the nut or bolt.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Torque : IQuantity, IComparable<Torque>
    {
        /// <summary>
        ///     Base unit of Torque.
        /// </summary>
        private readonly double _newtonMeters;

        public Torque(double newtonmeters) : this()
        {
            _newtonMeters = newtonmeters;
        }

        #region Properties

        /// <summary>
        ///     Get Torque in KilogramForceCentimeters.
        /// </summary>
        public double KilogramForceCentimeters
        {
            get { return _newtonMeters*10.1971619222242; }
        }

        /// <summary>
        ///     Get Torque in KilogramForceMeters.
        /// </summary>
        public double KilogramForceMeters
        {
            get { return _newtonMeters*0.101971619222242; }
        }

        /// <summary>
        ///     Get Torque in KilogramForceMillimeters.
        /// </summary>
        public double KilogramForceMillimeters
        {
            get { return _newtonMeters*101.971619222242; }
        }

        /// <summary>
        ///     Get Torque in KilonewtonCentimeters.
        /// </summary>
        public double KilonewtonCentimeters
        {
            get { return (_newtonMeters*100) / 1e3d; }
        }

        /// <summary>
        ///     Get Torque in KilonewtonMeters.
        /// </summary>
        public double KilonewtonMeters
        {
            get { return (_newtonMeters) / 1e3d; }
        }

        /// <summary>
        ///     Get Torque in KilonewtonMillimeters.
        /// </summary>
        public double KilonewtonMillimeters
        {
            get { return (_newtonMeters*1000) / 1e3d; }
        }

        /// <summary>
        ///     Get Torque in KilopoundForceFeet.
        /// </summary>
        public double KilopoundForceFeet
        {
            get { return (_newtonMeters*0.737562085483396) / 1e3d; }
        }

        /// <summary>
        ///     Get Torque in KilopoundForceInches.
        /// </summary>
        public double KilopoundForceInches
        {
            get { return (_newtonMeters*8.85074502580075) / 1e3d; }
        }

        /// <summary>
        ///     Get Torque in NewtonCentimeters.
        /// </summary>
        public double NewtonCentimeters
        {
            get { return _newtonMeters*100; }
        }

        /// <summary>
        ///     Get Torque in NewtonMeters.
        /// </summary>
        public double NewtonMeters
        {
            get { return _newtonMeters; }
        }

        /// <summary>
        ///     Get Torque in NewtonMillimeters.
        /// </summary>
        public double NewtonMillimeters
        {
            get { return _newtonMeters*1000; }
        }

        /// <summary>
        ///     Get Torque in PoundForceFeet.
        /// </summary>
        public double PoundForceFeet
        {
            get { return _newtonMeters*0.737562085483396; }
        }

        /// <summary>
        ///     Get Torque in PoundForceInches.
        /// </summary>
        public double PoundForceInches
        {
            get { return _newtonMeters*8.85074502580075; }
        }

        /// <summary>
        ///     Get Torque in TonneForceCentimeters.
        /// </summary>
        public double TonneForceCentimeters
        {
            get { return _newtonMeters*0.0101971619222242; }
        }

        /// <summary>
        ///     Get Torque in TonneForceMeters.
        /// </summary>
        public double TonneForceMeters
        {
            get { return _newtonMeters*0.000101971619222242; }
        }

        /// <summary>
        ///     Get Torque in TonneForceMillimeters.
        /// </summary>
        public double TonneForceMillimeters
        {
            get { return _newtonMeters*0.101971619222242; }
        }

        #endregion

        #region Static 

        public static Torque Zero
        {
            get { return new Torque(); }
        }

        /// <summary>
        ///     Get Torque from KilogramForceCentimeters.
        /// </summary>
        public static Torque FromKilogramForceCentimeters(double kilogramforcecentimeters)
        {
            return new Torque(kilogramforcecentimeters*0.0980665019960652);
        }

        /// <summary>
        ///     Get Torque from KilogramForceMeters.
        /// </summary>
        public static Torque FromKilogramForceMeters(double kilogramforcemeters)
        {
            return new Torque(kilogramforcemeters*9.80665019960652);
        }

        /// <summary>
        ///     Get Torque from KilogramForceMillimeters.
        /// </summary>
        public static Torque FromKilogramForceMillimeters(double kilogramforcemillimeters)
        {
            return new Torque(kilogramforcemillimeters*0.00980665019960652);
        }

        /// <summary>
        ///     Get Torque from KilonewtonCentimeters.
        /// </summary>
        public static Torque FromKilonewtonCentimeters(double kilonewtoncentimeters)
        {
            return new Torque((kilonewtoncentimeters*0.01) * 1e3d);
        }

        /// <summary>
        ///     Get Torque from KilonewtonMeters.
        /// </summary>
        public static Torque FromKilonewtonMeters(double kilonewtonmeters)
        {
            return new Torque((kilonewtonmeters) * 1e3d);
        }

        /// <summary>
        ///     Get Torque from KilonewtonMillimeters.
        /// </summary>
        public static Torque FromKilonewtonMillimeters(double kilonewtonmillimeters)
        {
            return new Torque((kilonewtonmillimeters*0.001) * 1e3d);
        }

        /// <summary>
        ///     Get Torque from KilopoundForceFeet.
        /// </summary>
        public static Torque FromKilopoundForceFeet(double kilopoundforcefeet)
        {
            return new Torque((kilopoundforcefeet*1.3558180656) * 1e3d);
        }

        /// <summary>
        ///     Get Torque from KilopoundForceInches.
        /// </summary>
        public static Torque FromKilopoundForceInches(double kilopoundforceinches)
        {
            return new Torque((kilopoundforceinches*0.1129848388) * 1e3d);
        }

        /// <summary>
        ///     Get Torque from NewtonCentimeters.
        /// </summary>
        public static Torque FromNewtonCentimeters(double newtoncentimeters)
        {
            return new Torque(newtoncentimeters*0.01);
        }

        /// <summary>
        ///     Get Torque from NewtonMeters.
        /// </summary>
        public static Torque FromNewtonMeters(double newtonmeters)
        {
            return new Torque(newtonmeters);
        }

        /// <summary>
        ///     Get Torque from NewtonMillimeters.
        /// </summary>
        public static Torque FromNewtonMillimeters(double newtonmillimeters)
        {
            return new Torque(newtonmillimeters*0.001);
        }

        /// <summary>
        ///     Get Torque from PoundForceFeet.
        /// </summary>
        public static Torque FromPoundForceFeet(double poundforcefeet)
        {
            return new Torque(poundforcefeet*1.3558180656);
        }

        /// <summary>
        ///     Get Torque from PoundForceInches.
        /// </summary>
        public static Torque FromPoundForceInches(double poundforceinches)
        {
            return new Torque(poundforceinches*0.1129848388);
        }

        /// <summary>
        ///     Get Torque from TonneForceCentimeters.
        /// </summary>
        public static Torque FromTonneForceCentimeters(double tonneforcecentimeters)
        {
            return new Torque(tonneforcecentimeters*98.0665019960652);
        }

        /// <summary>
        ///     Get Torque from TonneForceMeters.
        /// </summary>
        public static Torque FromTonneForceMeters(double tonneforcemeters)
        {
            return new Torque(tonneforcemeters*9806.65019960653);
        }

        /// <summary>
        ///     Get Torque from TonneForceMillimeters.
        /// </summary>
        public static Torque FromTonneForceMillimeters(double tonneforcemillimeters)
        {
            return new Torque(tonneforcemillimeters*9.80665019960652);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TorqueUnit" /> to <see cref="Torque" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Torque unit value.</returns>
        public static Torque From(double value, TorqueUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TorqueUnit.KilogramForceCentimeter:
                    return FromKilogramForceCentimeters(value);
                case TorqueUnit.KilogramForceMeter:
                    return FromKilogramForceMeters(value);
                case TorqueUnit.KilogramForceMillimeter:
                    return FromKilogramForceMillimeters(value);
                case TorqueUnit.KilonewtonCentimeter:
                    return FromKilonewtonCentimeters(value);
                case TorqueUnit.KilonewtonMeter:
                    return FromKilonewtonMeters(value);
                case TorqueUnit.KilonewtonMillimeter:
                    return FromKilonewtonMillimeters(value);
                case TorqueUnit.KilopoundForceFoot:
                    return FromKilopoundForceFeet(value);
                case TorqueUnit.KilopoundForceInch:
                    return FromKilopoundForceInches(value);
                case TorqueUnit.NewtonCentimeter:
                    return FromNewtonCentimeters(value);
                case TorqueUnit.NewtonMeter:
                    return FromNewtonMeters(value);
                case TorqueUnit.NewtonMillimeter:
                    return FromNewtonMillimeters(value);
                case TorqueUnit.PoundForceFoot:
                    return FromPoundForceFeet(value);
                case TorqueUnit.PoundForceInch:
                    return FromPoundForceInches(value);
                case TorqueUnit.TonneForceCentimeter:
                    return FromTonneForceCentimeters(value);
                case TorqueUnit.TonneForceMeter:
                    return FromTonneForceMeters(value);
                case TorqueUnit.TonneForceMillimeter:
                    return FromTonneForceMillimeters(value);

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
        public static string GetAbbreviation(TorqueUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Torque operator -(Torque right)
        {
            return new Torque(-right._newtonMeters);
        }

        public static Torque operator +(Torque left, Torque right)
        {
            return new Torque(left._newtonMeters + right._newtonMeters);
        }

        public static Torque operator -(Torque left, Torque right)
        {
            return new Torque(left._newtonMeters - right._newtonMeters);
        }

        public static Torque operator *(double left, Torque right)
        {
            return new Torque(left*right._newtonMeters);
        }

        public static Torque operator *(Torque left, double right)
        {
            return new Torque(left._newtonMeters*(double)right);
        }

        public static Torque operator /(Torque left, double right)
        {
            return new Torque(left._newtonMeters/(double)right);
        }

        public static double operator /(Torque left, Torque right)
        {
            return Convert.ToDouble(left._newtonMeters/right._newtonMeters);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Torque)) throw new ArgumentException("Expected type Torque.", "obj");
            return CompareTo((Torque) obj);
        }

        public int CompareTo(Torque other)
        {
            return _newtonMeters.CompareTo(other._newtonMeters);
        }

        public static bool operator <=(Torque left, Torque right)
        {
            return left._newtonMeters <= right._newtonMeters;
        }

        public static bool operator >=(Torque left, Torque right)
        {
            return left._newtonMeters >= right._newtonMeters;
        }

        public static bool operator <(Torque left, Torque right)
        {
            return left._newtonMeters < right._newtonMeters;
        }

        public static bool operator >(Torque left, Torque right)
        {
            return left._newtonMeters > right._newtonMeters;
        }

        public static bool operator ==(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonMeters == right._newtonMeters;
        }

        public static bool operator !=(Torque left, Torque right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonMeters != right._newtonMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonMeters.Equals(((Torque) obj)._newtonMeters);
        }

        public override int GetHashCode()
        {
            return _newtonMeters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TorqueUnit unit)
        {
            switch (unit)
            {
                case TorqueUnit.KilogramForceCentimeter:
                    return KilogramForceCentimeters;
                case TorqueUnit.KilogramForceMeter:
                    return KilogramForceMeters;
                case TorqueUnit.KilogramForceMillimeter:
                    return KilogramForceMillimeters;
                case TorqueUnit.KilonewtonCentimeter:
                    return KilonewtonCentimeters;
                case TorqueUnit.KilonewtonMeter:
                    return KilonewtonMeters;
                case TorqueUnit.KilonewtonMillimeter:
                    return KilonewtonMillimeters;
                case TorqueUnit.KilopoundForceFoot:
                    return KilopoundForceFeet;
                case TorqueUnit.KilopoundForceInch:
                    return KilopoundForceInches;
                case TorqueUnit.NewtonCentimeter:
                    return NewtonCentimeters;
                case TorqueUnit.NewtonMeter:
                    return NewtonMeters;
                case TorqueUnit.NewtonMillimeter:
                    return NewtonMillimeters;
                case TorqueUnit.PoundForceFoot:
                    return PoundForceFeet;
                case TorqueUnit.PoundForceInch:
                    return PoundForceInches;
                case TorqueUnit.TonneForceCentimeter:
                    return TonneForceCentimeters;
                case TorqueUnit.TonneForceMeter:
                    return TonneForceMeters;
                case TorqueUnit.TonneForceMillimeter:
                    return TonneForceMillimeters;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected 2 words. Input string needs to be in the format "&lt;quantity&gt; &lt;unit
        ///     &gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Torque Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format("(?<value>[-+]?{0}{1}{2}{3}",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>\S+)");      // capture Unit (non-whitespace) input

            var regex = new Regex(regexString);
            GroupCollection groups = regex.Match(str.Trim()).Groups;

            var valueString = groups["value"].Value;
            var unitString = groups["unit"].Value;

            if (valueString == "" || unitString == "")
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to be in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                TorqueUnit unit = ParseUnit(unitString, formatProvider);
                double value = double.Parse(valueString, formatProvider);

                return From(value, unit);
            }
            catch (Exception e)
            {
                var newEx = new UnitsNetException("Error parsing string.", e);
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static TorqueUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<TorqueUnit>(str.Trim());

            if (unit == TorqueUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TorqueUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(TorqueUnit.NewtonMeter);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(TorqueUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(TorqueUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
