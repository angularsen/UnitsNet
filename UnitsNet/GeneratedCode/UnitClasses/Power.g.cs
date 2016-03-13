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
    ///     In physics, power is the rate of doing work. It is equivalent to an amount of energy consumed per unit time.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Power
#else
    public partial struct Power : IComparable, IComparable<Power>
#endif
    {
        /// <summary>
        ///     Base unit of Power.
        /// </summary>
        private readonly decimal _watts;

#if WINDOWS_UWP
        public Power() : this(0)
        {
        }
#endif

        public Power(double watts)
        {
            _watts = Convert.ToDecimal(watts);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Power(long watts)
        {
            _watts = Convert.ToDecimal(watts);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Power(decimal watts)
        {
            _watts = Convert.ToDecimal(watts);
        }

        #region Properties

        public static PowerUnit BaseUnit
        {
            get { return PowerUnit.Watt; }
        }

        /// <summary>
        ///     Get Power in BoilerHorsepower.
        /// </summary>
        public double BoilerHorsepower
        {
            get { return Convert.ToDouble(_watts/9812.5m); }
        }

        /// <summary>
        ///     Get Power in ElectricalHorsepower.
        /// </summary>
        public double ElectricalHorsepower
        {
            get { return Convert.ToDouble(_watts/746m); }
        }

        /// <summary>
        ///     Get Power in Femtowatts.
        /// </summary>
        public double Femtowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-15m); }
        }

        /// <summary>
        ///     Get Power in Gigawatts.
        /// </summary>
        public double Gigawatts
        {
            get { return Convert.ToDouble((_watts) / 1e9m); }
        }

        /// <summary>
        ///     Get Power in HydraulicHorsepower.
        /// </summary>
        public double HydraulicHorsepower
        {
            get { return Convert.ToDouble(_watts/745.69988145m); }
        }

        /// <summary>
        ///     Get Power in Kilowatts.
        /// </summary>
        public double Kilowatts
        {
            get { return Convert.ToDouble((_watts) / 1e3m); }
        }

        /// <summary>
        ///     Get Power in MechanicalHorsepower.
        /// </summary>
        public double MechanicalHorsepower
        {
            get { return Convert.ToDouble(_watts/745.69m); }
        }

        /// <summary>
        ///     Get Power in Megawatts.
        /// </summary>
        public double Megawatts
        {
            get { return Convert.ToDouble((_watts) / 1e6m); }
        }

        /// <summary>
        ///     Get Power in MetricHorsepower.
        /// </summary>
        public double MetricHorsepower
        {
            get { return Convert.ToDouble(_watts/735.49875m); }
        }

        /// <summary>
        ///     Get Power in Microwatts.
        /// </summary>
        public double Microwatts
        {
            get { return Convert.ToDouble((_watts) / 1e-6m); }
        }

        /// <summary>
        ///     Get Power in Milliwatts.
        /// </summary>
        public double Milliwatts
        {
            get { return Convert.ToDouble((_watts) / 1e-3m); }
        }

        /// <summary>
        ///     Get Power in Nanowatts.
        /// </summary>
        public double Nanowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-9m); }
        }

        /// <summary>
        ///     Get Power in Petawatts.
        /// </summary>
        public double Petawatts
        {
            get { return Convert.ToDouble((_watts) / 1e15m); }
        }

        /// <summary>
        ///     Get Power in Picowatts.
        /// </summary>
        public double Picowatts
        {
            get { return Convert.ToDouble((_watts) / 1e-12m); }
        }

        /// <summary>
        ///     Get Power in Terawatts.
        /// </summary>
        public double Terawatts
        {
            get { return Convert.ToDouble((_watts) / 1e12m); }
        }

        /// <summary>
        ///     Get Power in Watts.
        /// </summary>
        public double Watts
        {
            get { return Convert.ToDouble(_watts); }
        }

        #endregion

        #region Static

        public static Power Zero
        {
            get { return new Power(); }
        }

        /// <summary>
        ///     Get Power from BoilerHorsepower.
        /// </summary>
        public static Power FromBoilerHorsepower(double boilerhorsepower)
        {
            return new Power(Convert.ToDecimal(boilerhorsepower*9812.5d));
        }

        /// <summary>
        ///     Get Power from ElectricalHorsepower.
        /// </summary>
        public static Power FromElectricalHorsepower(double electricalhorsepower)
        {
            return new Power(Convert.ToDecimal(electricalhorsepower*746d));
        }

        /// <summary>
        ///     Get Power from Femtowatts.
        /// </summary>
        public static Power FromFemtowatts(double femtowatts)
        {
            return new Power(Convert.ToDecimal((femtowatts) * 1e-15d));
        }

        /// <summary>
        ///     Get Power from Gigawatts.
        /// </summary>
        public static Power FromGigawatts(double gigawatts)
        {
            return new Power(Convert.ToDecimal((gigawatts) * 1e9d));
        }

        /// <summary>
        ///     Get Power from HydraulicHorsepower.
        /// </summary>
        public static Power FromHydraulicHorsepower(double hydraulichorsepower)
        {
            return new Power(Convert.ToDecimal(hydraulichorsepower*745.69988145d));
        }

        /// <summary>
        ///     Get Power from Kilowatts.
        /// </summary>
        public static Power FromKilowatts(double kilowatts)
        {
            return new Power(Convert.ToDecimal((kilowatts) * 1e3d));
        }

        /// <summary>
        ///     Get Power from MechanicalHorsepower.
        /// </summary>
        public static Power FromMechanicalHorsepower(double mechanicalhorsepower)
        {
            return new Power(Convert.ToDecimal(mechanicalhorsepower*745.69d));
        }

        /// <summary>
        ///     Get Power from Megawatts.
        /// </summary>
        public static Power FromMegawatts(double megawatts)
        {
            return new Power(Convert.ToDecimal((megawatts) * 1e6d));
        }

        /// <summary>
        ///     Get Power from MetricHorsepower.
        /// </summary>
        public static Power FromMetricHorsepower(double metrichorsepower)
        {
            return new Power(Convert.ToDecimal(metrichorsepower*735.49875d));
        }

        /// <summary>
        ///     Get Power from Microwatts.
        /// </summary>
        public static Power FromMicrowatts(double microwatts)
        {
            return new Power(Convert.ToDecimal((microwatts) * 1e-6d));
        }

        /// <summary>
        ///     Get Power from Milliwatts.
        /// </summary>
        public static Power FromMilliwatts(double milliwatts)
        {
            return new Power(Convert.ToDecimal((milliwatts) * 1e-3d));
        }

        /// <summary>
        ///     Get Power from Nanowatts.
        /// </summary>
        public static Power FromNanowatts(double nanowatts)
        {
            return new Power(Convert.ToDecimal((nanowatts) * 1e-9d));
        }

        /// <summary>
        ///     Get Power from Petawatts.
        /// </summary>
        public static Power FromPetawatts(double petawatts)
        {
            return new Power(Convert.ToDecimal((petawatts) * 1e15d));
        }

        /// <summary>
        ///     Get Power from Picowatts.
        /// </summary>
        public static Power FromPicowatts(double picowatts)
        {
            return new Power(Convert.ToDecimal((picowatts) * 1e-12d));
        }

        /// <summary>
        ///     Get Power from Terawatts.
        /// </summary>
        public static Power FromTerawatts(double terawatts)
        {
            return new Power(Convert.ToDecimal((terawatts) * 1e12d));
        }

        /// <summary>
        ///     Get Power from Watts.
        /// </summary>
        public static Power FromWatts(double watts)
        {
            return new Power(Convert.ToDecimal(watts));
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Power from nullable BoilerHorsepower.
        /// </summary>
        public static Power? FromBoilerHorsepower(double? boilerhorsepower)
        {
            if (boilerhorsepower.HasValue)
            {
                return FromBoilerHorsepower(boilerhorsepower.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable ElectricalHorsepower.
        /// </summary>
        public static Power? FromElectricalHorsepower(double? electricalhorsepower)
        {
            if (electricalhorsepower.HasValue)
            {
                return FromElectricalHorsepower(electricalhorsepower.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Femtowatts.
        /// </summary>
        public static Power? FromFemtowatts(double? femtowatts)
        {
            if (femtowatts.HasValue)
            {
                return FromFemtowatts(femtowatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Gigawatts.
        /// </summary>
        public static Power? FromGigawatts(double? gigawatts)
        {
            if (gigawatts.HasValue)
            {
                return FromGigawatts(gigawatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable HydraulicHorsepower.
        /// </summary>
        public static Power? FromHydraulicHorsepower(double? hydraulichorsepower)
        {
            if (hydraulichorsepower.HasValue)
            {
                return FromHydraulicHorsepower(hydraulichorsepower.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Kilowatts.
        /// </summary>
        public static Power? FromKilowatts(double? kilowatts)
        {
            if (kilowatts.HasValue)
            {
                return FromKilowatts(kilowatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable MechanicalHorsepower.
        /// </summary>
        public static Power? FromMechanicalHorsepower(double? mechanicalhorsepower)
        {
            if (mechanicalhorsepower.HasValue)
            {
                return FromMechanicalHorsepower(mechanicalhorsepower.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Megawatts.
        /// </summary>
        public static Power? FromMegawatts(double? megawatts)
        {
            if (megawatts.HasValue)
            {
                return FromMegawatts(megawatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable MetricHorsepower.
        /// </summary>
        public static Power? FromMetricHorsepower(double? metrichorsepower)
        {
            if (metrichorsepower.HasValue)
            {
                return FromMetricHorsepower(metrichorsepower.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Microwatts.
        /// </summary>
        public static Power? FromMicrowatts(double? microwatts)
        {
            if (microwatts.HasValue)
            {
                return FromMicrowatts(microwatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Milliwatts.
        /// </summary>
        public static Power? FromMilliwatts(double? milliwatts)
        {
            if (milliwatts.HasValue)
            {
                return FromMilliwatts(milliwatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Nanowatts.
        /// </summary>
        public static Power? FromNanowatts(double? nanowatts)
        {
            if (nanowatts.HasValue)
            {
                return FromNanowatts(nanowatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Petawatts.
        /// </summary>
        public static Power? FromPetawatts(double? petawatts)
        {
            if (petawatts.HasValue)
            {
                return FromPetawatts(petawatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Picowatts.
        /// </summary>
        public static Power? FromPicowatts(double? picowatts)
        {
            if (picowatts.HasValue)
            {
                return FromPicowatts(picowatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Terawatts.
        /// </summary>
        public static Power? FromTerawatts(double? terawatts)
        {
            if (terawatts.HasValue)
            {
                return FromTerawatts(terawatts.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Power from nullable Watts.
        /// </summary>
        public static Power? FromWatts(double? watts)
        {
            if (watts.HasValue)
            {
                return FromWatts(watts.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PowerUnit" /> to <see cref="Power" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Power unit value.</returns>
        public static Power From(double val, PowerUnit fromUnit)
        {
            switch (fromUnit)
            {
                case PowerUnit.BoilerHorsepower:
                    return FromBoilerHorsepower(val);
                case PowerUnit.ElectricalHorsepower:
                    return FromElectricalHorsepower(val);
                case PowerUnit.Femtowatt:
                    return FromFemtowatts(val);
                case PowerUnit.Gigawatt:
                    return FromGigawatts(val);
                case PowerUnit.HydraulicHorsepower:
                    return FromHydraulicHorsepower(val);
                case PowerUnit.Kilowatt:
                    return FromKilowatts(val);
                case PowerUnit.MechanicalHorsepower:
                    return FromMechanicalHorsepower(val);
                case PowerUnit.Megawatt:
                    return FromMegawatts(val);
                case PowerUnit.MetricHorsepower:
                    return FromMetricHorsepower(val);
                case PowerUnit.Microwatt:
                    return FromMicrowatts(val);
                case PowerUnit.Milliwatt:
                    return FromMilliwatts(val);
                case PowerUnit.Nanowatt:
                    return FromNanowatts(val);
                case PowerUnit.Petawatt:
                    return FromPetawatts(val);
                case PowerUnit.Picowatt:
                    return FromPicowatts(val);
                case PowerUnit.Terawatt:
                    return FromTerawatts(val);
                case PowerUnit.Watt:
                    return FromWatts(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="PowerUnit" /> to <see cref="Power" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Power unit value.</returns>
        public static Power? From(double? value, PowerUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case PowerUnit.BoilerHorsepower:
                    return FromBoilerHorsepower(value.Value);
                case PowerUnit.ElectricalHorsepower:
                    return FromElectricalHorsepower(value.Value);
                case PowerUnit.Femtowatt:
                    return FromFemtowatts(value.Value);
                case PowerUnit.Gigawatt:
                    return FromGigawatts(value.Value);
                case PowerUnit.HydraulicHorsepower:
                    return FromHydraulicHorsepower(value.Value);
                case PowerUnit.Kilowatt:
                    return FromKilowatts(value.Value);
                case PowerUnit.MechanicalHorsepower:
                    return FromMechanicalHorsepower(value.Value);
                case PowerUnit.Megawatt:
                    return FromMegawatts(value.Value);
                case PowerUnit.MetricHorsepower:
                    return FromMetricHorsepower(value.Value);
                case PowerUnit.Microwatt:
                    return FromMicrowatts(value.Value);
                case PowerUnit.Milliwatt:
                    return FromMilliwatts(value.Value);
                case PowerUnit.Nanowatt:
                    return FromNanowatts(value.Value);
                case PowerUnit.Petawatt:
                    return FromPetawatts(value.Value);
                case PowerUnit.Picowatt:
                    return FromPicowatts(value.Value);
                case PowerUnit.Terawatt:
                    return FromTerawatts(value.Value);
                case PowerUnit.Watt:
                    return FromWatts(value.Value);

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
        public static string GetAbbreviation(PowerUnit unit)
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
        public static string GetAbbreviation(PowerUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Power operator -(Power right)
        {
            return new Power(-right._watts);
        }

        public static Power operator +(Power left, Power right)
        {
            return new Power(left._watts + right._watts);
        }

        public static Power operator -(Power left, Power right)
        {
            return new Power(left._watts - right._watts);
        }

        public static Power operator *(decimal left, Power right)
        {
            return new Power(left*right._watts);
        }

        public static Power operator *(Power left, double right)
        {
            return new Power(left._watts*(decimal)right);
        }

        public static Power operator /(Power left, double right)
        {
            return new Power(left._watts/(decimal)right);
        }

        public static double operator /(Power left, Power right)
        {
            return Convert.ToDouble(left._watts/right._watts);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Power)) throw new ArgumentException("Expected type Power.", "obj");
            return CompareTo((Power) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Power other)
        {
            return _watts.CompareTo(other._watts);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Power left, Power right)
        {
            return left._watts <= right._watts;
        }

        public static bool operator >=(Power left, Power right)
        {
            return left._watts >= right._watts;
        }

        public static bool operator <(Power left, Power right)
        {
            return left._watts < right._watts;
        }

        public static bool operator >(Power left, Power right)
        {
            return left._watts > right._watts;
        }

        public static bool operator ==(Power left, Power right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._watts == right._watts;
        }

        public static bool operator !=(Power left, Power right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._watts != right._watts;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _watts.Equals(((Power) obj)._watts);
        }

        public override int GetHashCode()
        {
            return _watts.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(PowerUnit unit)
        {
            switch (unit)
            {
                case PowerUnit.BoilerHorsepower:
                    return BoilerHorsepower;
                case PowerUnit.ElectricalHorsepower:
                    return ElectricalHorsepower;
                case PowerUnit.Femtowatt:
                    return Femtowatts;
                case PowerUnit.Gigawatt:
                    return Gigawatts;
                case PowerUnit.HydraulicHorsepower:
                    return HydraulicHorsepower;
                case PowerUnit.Kilowatt:
                    return Kilowatts;
                case PowerUnit.MechanicalHorsepower:
                    return MechanicalHorsepower;
                case PowerUnit.Megawatt:
                    return Megawatts;
                case PowerUnit.MetricHorsepower:
                    return MetricHorsepower;
                case PowerUnit.Microwatt:
                    return Microwatts;
                case PowerUnit.Milliwatt:
                    return Milliwatts;
                case PowerUnit.Nanowatt:
                    return Nanowatts;
                case PowerUnit.Petawatt:
                    return Petawatts;
                case PowerUnit.Picowatt:
                    return Picowatts;
                case PowerUnit.Terawatt:
                    return Terawatts;
                case PowerUnit.Watt:
                    return Watts;

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
        public static Power Parse(string str)
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
        public static Power Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Power.FromWatts(x.Watts + y.Watts));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Power> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Power>();

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
                    PowerUnit unit = ParseUnit(unitString, formatProvider);
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
        public static PowerUnit ParseUnit(string str)
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
        public static PowerUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static PowerUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<PowerUnit>(str.Trim());

            if (unit == PowerUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized PowerUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Watt
        /// </summary>
        public static PowerUnit ToStringDefaultUnit { get; set; } = PowerUnit.Watt;

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
        public string ToString(PowerUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(PowerUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(PowerUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(PowerUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
    }
}
