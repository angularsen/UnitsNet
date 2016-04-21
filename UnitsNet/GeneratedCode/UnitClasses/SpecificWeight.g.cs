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
    ///     The SpecificWeight, or more precisely, the volumetric weight density, of a substance is its weight per unit volume.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class SpecificWeight
#else
    public partial struct SpecificWeight : IComparable, IComparable<SpecificWeight>
#endif
    {
        /// <summary>
        ///     Base unit of SpecificWeight.
        /// </summary>
        private readonly double _newtonsPerCubicMeter;

#if WINDOWS_UWP
        public SpecificWeight() : this(0)
        {
        }
#endif

        public SpecificWeight(double newtonspercubicmeter)
        {
            _newtonsPerCubicMeter = Convert.ToDouble(newtonspercubicmeter);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        SpecificWeight(long newtonspercubicmeter)
        {
            _newtonsPerCubicMeter = Convert.ToDouble(newtonspercubicmeter);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        SpecificWeight(decimal newtonspercubicmeter)
        {
            _newtonsPerCubicMeter = Convert.ToDouble(newtonspercubicmeter);
        }

        #region Properties

        public static SpecificWeightUnit BaseUnit
        {
            get { return SpecificWeightUnit.NewtonPerCubicMeter; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilogramsForcePerCubicCentimeter.
        /// </summary>
        public double KilogramsForcePerCubicCentimeter
        {
            get { return _newtonsPerCubicMeter*1.01971619222242E-07; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilogramsForcePerCubicMeter.
        /// </summary>
        public double KilogramsForcePerCubicMeter
        {
            get { return _newtonsPerCubicMeter*0.101971619222242; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilogramsForcePerCubicMillimeter.
        /// </summary>
        public double KilogramsForcePerCubicMillimeter
        {
            get { return _newtonsPerCubicMeter*1.01971619222242E-10; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilonewtonsPerCubicCentimeter.
        /// </summary>
        public double KilonewtonsPerCubicCentimeter
        {
            get { return (_newtonsPerCubicMeter*0.000001) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilonewtonsPerCubicMeter.
        /// </summary>
        public double KilonewtonsPerCubicMeter
        {
            get { return (_newtonsPerCubicMeter) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilonewtonsPerCubicMillimeter.
        /// </summary>
        public double KilonewtonsPerCubicMillimeter
        {
            get { return (_newtonsPerCubicMeter*0.000000001) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilopoundsForcePerCubicFoot.
        /// </summary>
        public double KilopoundsForcePerCubicFoot
        {
            get { return (_newtonsPerCubicMeter*0.00636587980366089) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificWeight in KilopoundsForcePerCubicInch.
        /// </summary>
        public double KilopoundsForcePerCubicInch
        {
            get { return (_newtonsPerCubicMeter*3.68395821971116E-06) / 1e3d; }
        }

        /// <summary>
        ///     Get SpecificWeight in NewtonsPerCubicCentimeter.
        /// </summary>
        public double NewtonsPerCubicCentimeter
        {
            get { return _newtonsPerCubicMeter*0.000001; }
        }

        /// <summary>
        ///     Get SpecificWeight in NewtonsPerCubicMeter.
        /// </summary>
        public double NewtonsPerCubicMeter
        {
            get { return _newtonsPerCubicMeter; }
        }

        /// <summary>
        ///     Get SpecificWeight in NewtonsPerCubicMillimeter.
        /// </summary>
        public double NewtonsPerCubicMillimeter
        {
            get { return _newtonsPerCubicMeter*0.000000001; }
        }

        /// <summary>
        ///     Get SpecificWeight in PoundsForcePerCubicFoot.
        /// </summary>
        public double PoundsForcePerCubicFoot
        {
            get { return _newtonsPerCubicMeter*0.00636587980366089; }
        }

        /// <summary>
        ///     Get SpecificWeight in PoundsForcePerCubicInch.
        /// </summary>
        public double PoundsForcePerCubicInch
        {
            get { return _newtonsPerCubicMeter*3.68395821971116E-06; }
        }

        /// <summary>
        ///     Get SpecificWeight in TonnesForcePerCubicCentimeter.
        /// </summary>
        public double TonnesForcePerCubicCentimeter
        {
            get { return _newtonsPerCubicMeter*1.01971619222242E-10; }
        }

        /// <summary>
        ///     Get SpecificWeight in TonnesForcePerCubicMeter.
        /// </summary>
        public double TonnesForcePerCubicMeter
        {
            get { return _newtonsPerCubicMeter*0.000101971619222242; }
        }

        /// <summary>
        ///     Get SpecificWeight in TonnesForcePerCubicMillimeter.
        /// </summary>
        public double TonnesForcePerCubicMillimeter
        {
            get { return _newtonsPerCubicMeter*1.01971619222242E-13; }
        }

        #endregion

        #region Static

        public static SpecificWeight Zero
        {
            get { return new SpecificWeight(); }
        }

        /// <summary>
        ///     Get SpecificWeight from KilogramsForcePerCubicCentimeter.
        /// </summary>
        public static SpecificWeight FromKilogramsForcePerCubicCentimeter(double kilogramsforcepercubiccentimeter)
        {
            return new SpecificWeight(kilogramsforcepercubiccentimeter*9806650.19960652);
        }

        /// <summary>
        ///     Get SpecificWeight from KilogramsForcePerCubicMeter.
        /// </summary>
        public static SpecificWeight FromKilogramsForcePerCubicMeter(double kilogramsforcepercubicmeter)
        {
            return new SpecificWeight(kilogramsforcepercubicmeter*9.80665019960652);
        }

        /// <summary>
        ///     Get SpecificWeight from KilogramsForcePerCubicMillimeter.
        /// </summary>
        public static SpecificWeight FromKilogramsForcePerCubicMillimeter(double kilogramsforcepercubicmillimeter)
        {
            return new SpecificWeight(kilogramsforcepercubicmillimeter*9806650199.60653);
        }

        /// <summary>
        ///     Get SpecificWeight from KilonewtonsPerCubicCentimeter.
        /// </summary>
        public static SpecificWeight FromKilonewtonsPerCubicCentimeter(double kilonewtonspercubiccentimeter)
        {
            return new SpecificWeight((kilonewtonspercubiccentimeter*1000000) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificWeight from KilonewtonsPerCubicMeter.
        /// </summary>
        public static SpecificWeight FromKilonewtonsPerCubicMeter(double kilonewtonspercubicmeter)
        {
            return new SpecificWeight((kilonewtonspercubicmeter) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificWeight from KilonewtonsPerCubicMillimeter.
        /// </summary>
        public static SpecificWeight FromKilonewtonsPerCubicMillimeter(double kilonewtonspercubicmillimeter)
        {
            return new SpecificWeight((kilonewtonspercubicmillimeter*1000000000) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificWeight from KilopoundsForcePerCubicFoot.
        /// </summary>
        public static SpecificWeight FromKilopoundsForcePerCubicFoot(double kilopoundsforcepercubicfoot)
        {
            return new SpecificWeight((kilopoundsforcepercubicfoot*157.087477433193) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificWeight from KilopoundsForcePerCubicInch.
        /// </summary>
        public static SpecificWeight FromKilopoundsForcePerCubicInch(double kilopoundsforcepercubicinch)
        {
            return new SpecificWeight((kilopoundsforcepercubicinch*271447.161004558) * 1e3d);
        }

        /// <summary>
        ///     Get SpecificWeight from NewtonsPerCubicCentimeter.
        /// </summary>
        public static SpecificWeight FromNewtonsPerCubicCentimeter(double newtonspercubiccentimeter)
        {
            return new SpecificWeight(newtonspercubiccentimeter*1000000);
        }

        /// <summary>
        ///     Get SpecificWeight from NewtonsPerCubicMeter.
        /// </summary>
        public static SpecificWeight FromNewtonsPerCubicMeter(double newtonspercubicmeter)
        {
            return new SpecificWeight(newtonspercubicmeter);
        }

        /// <summary>
        ///     Get SpecificWeight from NewtonsPerCubicMillimeter.
        /// </summary>
        public static SpecificWeight FromNewtonsPerCubicMillimeter(double newtonspercubicmillimeter)
        {
            return new SpecificWeight(newtonspercubicmillimeter*1000000000);
        }

        /// <summary>
        ///     Get SpecificWeight from PoundsForcePerCubicFoot.
        /// </summary>
        public static SpecificWeight FromPoundsForcePerCubicFoot(double poundsforcepercubicfoot)
        {
            return new SpecificWeight(poundsforcepercubicfoot*157.087477433193);
        }

        /// <summary>
        ///     Get SpecificWeight from PoundsForcePerCubicInch.
        /// </summary>
        public static SpecificWeight FromPoundsForcePerCubicInch(double poundsforcepercubicinch)
        {
            return new SpecificWeight(poundsforcepercubicinch*271447.161004558);
        }

        /// <summary>
        ///     Get SpecificWeight from TonnesForcePerCubicCentimeter.
        /// </summary>
        public static SpecificWeight FromTonnesForcePerCubicCentimeter(double tonnesforcepercubiccentimeter)
        {
            return new SpecificWeight(tonnesforcepercubiccentimeter*9806650199.60653);
        }

        /// <summary>
        ///     Get SpecificWeight from TonnesForcePerCubicMeter.
        /// </summary>
        public static SpecificWeight FromTonnesForcePerCubicMeter(double tonnesforcepercubicmeter)
        {
            return new SpecificWeight(tonnesforcepercubicmeter*9806.65019960653);
        }

        /// <summary>
        ///     Get SpecificWeight from TonnesForcePerCubicMillimeter.
        /// </summary>
        public static SpecificWeight FromTonnesForcePerCubicMillimeter(double tonnesforcepercubicmillimeter)
        {
            return new SpecificWeight(tonnesforcepercubicmillimeter*9806650199606.53);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilogramsForcePerCubicCentimeter.
        /// </summary>
        public static SpecificWeight? FromKilogramsForcePerCubicCentimeter(double? kilogramsforcepercubiccentimeter)
        {
            if (kilogramsforcepercubiccentimeter.HasValue)
            {
                return FromKilogramsForcePerCubicCentimeter(kilogramsforcepercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilogramsForcePerCubicMeter.
        /// </summary>
        public static SpecificWeight? FromKilogramsForcePerCubicMeter(double? kilogramsforcepercubicmeter)
        {
            if (kilogramsforcepercubicmeter.HasValue)
            {
                return FromKilogramsForcePerCubicMeter(kilogramsforcepercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilogramsForcePerCubicMillimeter.
        /// </summary>
        public static SpecificWeight? FromKilogramsForcePerCubicMillimeter(double? kilogramsforcepercubicmillimeter)
        {
            if (kilogramsforcepercubicmillimeter.HasValue)
            {
                return FromKilogramsForcePerCubicMillimeter(kilogramsforcepercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilonewtonsPerCubicCentimeter.
        /// </summary>
        public static SpecificWeight? FromKilonewtonsPerCubicCentimeter(double? kilonewtonspercubiccentimeter)
        {
            if (kilonewtonspercubiccentimeter.HasValue)
            {
                return FromKilonewtonsPerCubicCentimeter(kilonewtonspercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilonewtonsPerCubicMeter.
        /// </summary>
        public static SpecificWeight? FromKilonewtonsPerCubicMeter(double? kilonewtonspercubicmeter)
        {
            if (kilonewtonspercubicmeter.HasValue)
            {
                return FromKilonewtonsPerCubicMeter(kilonewtonspercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilonewtonsPerCubicMillimeter.
        /// </summary>
        public static SpecificWeight? FromKilonewtonsPerCubicMillimeter(double? kilonewtonspercubicmillimeter)
        {
            if (kilonewtonspercubicmillimeter.HasValue)
            {
                return FromKilonewtonsPerCubicMillimeter(kilonewtonspercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilopoundsForcePerCubicFoot.
        /// </summary>
        public static SpecificWeight? FromKilopoundsForcePerCubicFoot(double? kilopoundsforcepercubicfoot)
        {
            if (kilopoundsforcepercubicfoot.HasValue)
            {
                return FromKilopoundsForcePerCubicFoot(kilopoundsforcepercubicfoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable KilopoundsForcePerCubicInch.
        /// </summary>
        public static SpecificWeight? FromKilopoundsForcePerCubicInch(double? kilopoundsforcepercubicinch)
        {
            if (kilopoundsforcepercubicinch.HasValue)
            {
                return FromKilopoundsForcePerCubicInch(kilopoundsforcepercubicinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable NewtonsPerCubicCentimeter.
        /// </summary>
        public static SpecificWeight? FromNewtonsPerCubicCentimeter(double? newtonspercubiccentimeter)
        {
            if (newtonspercubiccentimeter.HasValue)
            {
                return FromNewtonsPerCubicCentimeter(newtonspercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable NewtonsPerCubicMeter.
        /// </summary>
        public static SpecificWeight? FromNewtonsPerCubicMeter(double? newtonspercubicmeter)
        {
            if (newtonspercubicmeter.HasValue)
            {
                return FromNewtonsPerCubicMeter(newtonspercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable NewtonsPerCubicMillimeter.
        /// </summary>
        public static SpecificWeight? FromNewtonsPerCubicMillimeter(double? newtonspercubicmillimeter)
        {
            if (newtonspercubicmillimeter.HasValue)
            {
                return FromNewtonsPerCubicMillimeter(newtonspercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable PoundsForcePerCubicFoot.
        /// </summary>
        public static SpecificWeight? FromPoundsForcePerCubicFoot(double? poundsforcepercubicfoot)
        {
            if (poundsforcepercubicfoot.HasValue)
            {
                return FromPoundsForcePerCubicFoot(poundsforcepercubicfoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable PoundsForcePerCubicInch.
        /// </summary>
        public static SpecificWeight? FromPoundsForcePerCubicInch(double? poundsforcepercubicinch)
        {
            if (poundsforcepercubicinch.HasValue)
            {
                return FromPoundsForcePerCubicInch(poundsforcepercubicinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable TonnesForcePerCubicCentimeter.
        /// </summary>
        public static SpecificWeight? FromTonnesForcePerCubicCentimeter(double? tonnesforcepercubiccentimeter)
        {
            if (tonnesforcepercubiccentimeter.HasValue)
            {
                return FromTonnesForcePerCubicCentimeter(tonnesforcepercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable TonnesForcePerCubicMeter.
        /// </summary>
        public static SpecificWeight? FromTonnesForcePerCubicMeter(double? tonnesforcepercubicmeter)
        {
            if (tonnesforcepercubicmeter.HasValue)
            {
                return FromTonnesForcePerCubicMeter(tonnesforcepercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable SpecificWeight from nullable TonnesForcePerCubicMillimeter.
        /// </summary>
        public static SpecificWeight? FromTonnesForcePerCubicMillimeter(double? tonnesforcepercubicmillimeter)
        {
            if (tonnesforcepercubicmillimeter.HasValue)
            {
                return FromTonnesForcePerCubicMillimeter(tonnesforcepercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificWeightUnit" /> to <see cref="SpecificWeight" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificWeight unit value.</returns>
        public static SpecificWeight From(double val, SpecificWeightUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpecificWeightUnit.KilogramForcePerCubicCentimeter:
                    return FromKilogramsForcePerCubicCentimeter(val);
                case SpecificWeightUnit.KilogramForcePerCubicMeter:
                    return FromKilogramsForcePerCubicMeter(val);
                case SpecificWeightUnit.KilogramForcePerCubicMillimeter:
                    return FromKilogramsForcePerCubicMillimeter(val);
                case SpecificWeightUnit.KilonewtonPerCubicCentimeter:
                    return FromKilonewtonsPerCubicCentimeter(val);
                case SpecificWeightUnit.KilonewtonPerCubicMeter:
                    return FromKilonewtonsPerCubicMeter(val);
                case SpecificWeightUnit.KilonewtonPerCubicMillimeter:
                    return FromKilonewtonsPerCubicMillimeter(val);
                case SpecificWeightUnit.KilopoundForcePerCubicFoot:
                    return FromKilopoundsForcePerCubicFoot(val);
                case SpecificWeightUnit.KilopoundForcePerCubicInch:
                    return FromKilopoundsForcePerCubicInch(val);
                case SpecificWeightUnit.NewtonPerCubicCentimeter:
                    return FromNewtonsPerCubicCentimeter(val);
                case SpecificWeightUnit.NewtonPerCubicMeter:
                    return FromNewtonsPerCubicMeter(val);
                case SpecificWeightUnit.NewtonPerCubicMillimeter:
                    return FromNewtonsPerCubicMillimeter(val);
                case SpecificWeightUnit.PoundForcePerCubicFoot:
                    return FromPoundsForcePerCubicFoot(val);
                case SpecificWeightUnit.PoundForcePerCubicInch:
                    return FromPoundsForcePerCubicInch(val);
                case SpecificWeightUnit.TonneForcePerCubicCentimeter:
                    return FromTonnesForcePerCubicCentimeter(val);
                case SpecificWeightUnit.TonneForcePerCubicMeter:
                    return FromTonnesForcePerCubicMeter(val);
                case SpecificWeightUnit.TonneForcePerCubicMillimeter:
                    return FromTonnesForcePerCubicMillimeter(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificWeightUnit" /> to <see cref="SpecificWeight" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificWeight unit value.</returns>
        public static SpecificWeight? From(double? value, SpecificWeightUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case SpecificWeightUnit.KilogramForcePerCubicCentimeter:
                    return FromKilogramsForcePerCubicCentimeter(value.Value);
                case SpecificWeightUnit.KilogramForcePerCubicMeter:
                    return FromKilogramsForcePerCubicMeter(value.Value);
                case SpecificWeightUnit.KilogramForcePerCubicMillimeter:
                    return FromKilogramsForcePerCubicMillimeter(value.Value);
                case SpecificWeightUnit.KilonewtonPerCubicCentimeter:
                    return FromKilonewtonsPerCubicCentimeter(value.Value);
                case SpecificWeightUnit.KilonewtonPerCubicMeter:
                    return FromKilonewtonsPerCubicMeter(value.Value);
                case SpecificWeightUnit.KilonewtonPerCubicMillimeter:
                    return FromKilonewtonsPerCubicMillimeter(value.Value);
                case SpecificWeightUnit.KilopoundForcePerCubicFoot:
                    return FromKilopoundsForcePerCubicFoot(value.Value);
                case SpecificWeightUnit.KilopoundForcePerCubicInch:
                    return FromKilopoundsForcePerCubicInch(value.Value);
                case SpecificWeightUnit.NewtonPerCubicCentimeter:
                    return FromNewtonsPerCubicCentimeter(value.Value);
                case SpecificWeightUnit.NewtonPerCubicMeter:
                    return FromNewtonsPerCubicMeter(value.Value);
                case SpecificWeightUnit.NewtonPerCubicMillimeter:
                    return FromNewtonsPerCubicMillimeter(value.Value);
                case SpecificWeightUnit.PoundForcePerCubicFoot:
                    return FromPoundsForcePerCubicFoot(value.Value);
                case SpecificWeightUnit.PoundForcePerCubicInch:
                    return FromPoundsForcePerCubicInch(value.Value);
                case SpecificWeightUnit.TonneForcePerCubicCentimeter:
                    return FromTonnesForcePerCubicCentimeter(value.Value);
                case SpecificWeightUnit.TonneForcePerCubicMeter:
                    return FromTonnesForcePerCubicMeter(value.Value);
                case SpecificWeightUnit.TonneForcePerCubicMillimeter:
                    return FromTonnesForcePerCubicMillimeter(value.Value);

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
        public static string GetAbbreviation(SpecificWeightUnit unit)
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
        public static string GetAbbreviation(SpecificWeightUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static SpecificWeight operator -(SpecificWeight right)
        {
            return new SpecificWeight(-right._newtonsPerCubicMeter);
        }

        public static SpecificWeight operator +(SpecificWeight left, SpecificWeight right)
        {
            return new SpecificWeight(left._newtonsPerCubicMeter + right._newtonsPerCubicMeter);
        }

        public static SpecificWeight operator -(SpecificWeight left, SpecificWeight right)
        {
            return new SpecificWeight(left._newtonsPerCubicMeter - right._newtonsPerCubicMeter);
        }

        public static SpecificWeight operator *(double left, SpecificWeight right)
        {
            return new SpecificWeight(left*right._newtonsPerCubicMeter);
        }

        public static SpecificWeight operator *(SpecificWeight left, double right)
        {
            return new SpecificWeight(left._newtonsPerCubicMeter*(double)right);
        }

        public static SpecificWeight operator /(SpecificWeight left, double right)
        {
            return new SpecificWeight(left._newtonsPerCubicMeter/(double)right);
        }

        public static double operator /(SpecificWeight left, SpecificWeight right)
        {
            return Convert.ToDouble(left._newtonsPerCubicMeter/right._newtonsPerCubicMeter);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SpecificWeight)) throw new ArgumentException("Expected type SpecificWeight.", "obj");
            return CompareTo((SpecificWeight) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(SpecificWeight other)
        {
            return _newtonsPerCubicMeter.CompareTo(other._newtonsPerCubicMeter);
        }

#if !WINDOWS_UWP
        public static bool operator <=(SpecificWeight left, SpecificWeight right)
        {
            return left._newtonsPerCubicMeter <= right._newtonsPerCubicMeter;
        }

        public static bool operator >=(SpecificWeight left, SpecificWeight right)
        {
            return left._newtonsPerCubicMeter >= right._newtonsPerCubicMeter;
        }

        public static bool operator <(SpecificWeight left, SpecificWeight right)
        {
            return left._newtonsPerCubicMeter < right._newtonsPerCubicMeter;
        }

        public static bool operator >(SpecificWeight left, SpecificWeight right)
        {
            return left._newtonsPerCubicMeter > right._newtonsPerCubicMeter;
        }

        public static bool operator ==(SpecificWeight left, SpecificWeight right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerCubicMeter == right._newtonsPerCubicMeter;
        }

        public static bool operator !=(SpecificWeight left, SpecificWeight right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._newtonsPerCubicMeter != right._newtonsPerCubicMeter;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _newtonsPerCubicMeter.Equals(((SpecificWeight) obj)._newtonsPerCubicMeter);
        }

        public override int GetHashCode()
        {
            return _newtonsPerCubicMeter.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(SpecificWeightUnit unit)
        {
            switch (unit)
            {
                case SpecificWeightUnit.KilogramForcePerCubicCentimeter:
                    return KilogramsForcePerCubicCentimeter;
                case SpecificWeightUnit.KilogramForcePerCubicMeter:
                    return KilogramsForcePerCubicMeter;
                case SpecificWeightUnit.KilogramForcePerCubicMillimeter:
                    return KilogramsForcePerCubicMillimeter;
                case SpecificWeightUnit.KilonewtonPerCubicCentimeter:
                    return KilonewtonsPerCubicCentimeter;
                case SpecificWeightUnit.KilonewtonPerCubicMeter:
                    return KilonewtonsPerCubicMeter;
                case SpecificWeightUnit.KilonewtonPerCubicMillimeter:
                    return KilonewtonsPerCubicMillimeter;
                case SpecificWeightUnit.KilopoundForcePerCubicFoot:
                    return KilopoundsForcePerCubicFoot;
                case SpecificWeightUnit.KilopoundForcePerCubicInch:
                    return KilopoundsForcePerCubicInch;
                case SpecificWeightUnit.NewtonPerCubicCentimeter:
                    return NewtonsPerCubicCentimeter;
                case SpecificWeightUnit.NewtonPerCubicMeter:
                    return NewtonsPerCubicMeter;
                case SpecificWeightUnit.NewtonPerCubicMillimeter:
                    return NewtonsPerCubicMillimeter;
                case SpecificWeightUnit.PoundForcePerCubicFoot:
                    return PoundsForcePerCubicFoot;
                case SpecificWeightUnit.PoundForcePerCubicInch:
                    return PoundsForcePerCubicInch;
                case SpecificWeightUnit.TonneForcePerCubicCentimeter:
                    return TonnesForcePerCubicCentimeter;
                case SpecificWeightUnit.TonneForcePerCubicMeter:
                    return TonnesForcePerCubicMeter;
                case SpecificWeightUnit.TonneForcePerCubicMillimeter:
                    return TonnesForcePerCubicMillimeter;

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
        public static SpecificWeight Parse(string str)
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
        public static SpecificWeight Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => SpecificWeight.FromNewtonsPerCubicMeter(x.NewtonsPerCubicMeter + y.NewtonsPerCubicMeter));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<SpecificWeight> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<SpecificWeight>();

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
                    SpecificWeightUnit unit = ParseUnit(unitString, formatProvider);
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
        public static SpecificWeightUnit ParseUnit(string str)
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
        public static SpecificWeightUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static SpecificWeightUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<SpecificWeightUnit>(str.Trim());

            if (unit == SpecificWeightUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized SpecificWeightUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is NewtonPerCubicMeter
        /// </summary>
        public static SpecificWeightUnit ToStringDefaultUnit { get; set; } = SpecificWeightUnit.NewtonPerCubicMeter;

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
        public string ToString(SpecificWeightUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpecificWeightUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(SpecificWeightUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(SpecificWeightUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of SpecificWeight
        /// </summary>
        public static SpecificWeight MaxValue
        {
            get
            {
                return new SpecificWeight(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of SpecificWeight
        /// </summary>
        public static SpecificWeight MinValue
        {
            get
            {
                return new SpecificWeight(double.MinValue);
            }
        }
    }
}
