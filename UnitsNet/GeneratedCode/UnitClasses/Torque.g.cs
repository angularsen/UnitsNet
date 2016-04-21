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
    ///     Torque, moment or moment of force (see the terminology below), is the tendency of a force to rotate an object about an axis,[1] fulcrum, or pivot. Just as a force is a push or a pull, a torque can be thought of as a twist to an object. Mathematically, torque is defined as the cross product of the lever-arm distance and force, which tends to produce rotation. Loosely speaking, torque is a measure of the turning force on an object such as a bolt or a flywheel. For example, pushing or pulling the handle of a wrench connected to a nut or bolt produces a torque (turning force) that loosens or tightens the nut or bolt.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Torque
#else
    public partial struct Torque : IComparable, IComparable<Torque>
#endif
    {
        /// <summary>
        ///     Base unit of Torque.
        /// </summary>
        private readonly double _newtonMeters;

#if WINDOWS_UWP
        public Torque() : this(0)
        {
        }
#endif

        public Torque(double newtonmeters)
        {
            _newtonMeters = Convert.ToDouble(newtonmeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Torque(long newtonmeters)
        {
            _newtonMeters = Convert.ToDouble(newtonmeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Torque(decimal newtonmeters)
        {
            _newtonMeters = Convert.ToDouble(newtonmeters);
        }

        #region Properties

        public static TorqueUnit BaseUnit
        {
            get { return TorqueUnit.NewtonMeter; }
        }

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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Torque from nullable KilogramForceCentimeters.
        /// </summary>
        public static Torque? FromKilogramForceCentimeters(double? kilogramforcecentimeters)
        {
            if (kilogramforcecentimeters.HasValue)
            {
                return FromKilogramForceCentimeters(kilogramforcecentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilogramForceMeters.
        /// </summary>
        public static Torque? FromKilogramForceMeters(double? kilogramforcemeters)
        {
            if (kilogramforcemeters.HasValue)
            {
                return FromKilogramForceMeters(kilogramforcemeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilogramForceMillimeters.
        /// </summary>
        public static Torque? FromKilogramForceMillimeters(double? kilogramforcemillimeters)
        {
            if (kilogramforcemillimeters.HasValue)
            {
                return FromKilogramForceMillimeters(kilogramforcemillimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilonewtonCentimeters.
        /// </summary>
        public static Torque? FromKilonewtonCentimeters(double? kilonewtoncentimeters)
        {
            if (kilonewtoncentimeters.HasValue)
            {
                return FromKilonewtonCentimeters(kilonewtoncentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilonewtonMeters.
        /// </summary>
        public static Torque? FromKilonewtonMeters(double? kilonewtonmeters)
        {
            if (kilonewtonmeters.HasValue)
            {
                return FromKilonewtonMeters(kilonewtonmeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilonewtonMillimeters.
        /// </summary>
        public static Torque? FromKilonewtonMillimeters(double? kilonewtonmillimeters)
        {
            if (kilonewtonmillimeters.HasValue)
            {
                return FromKilonewtonMillimeters(kilonewtonmillimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilopoundForceFeet.
        /// </summary>
        public static Torque? FromKilopoundForceFeet(double? kilopoundforcefeet)
        {
            if (kilopoundforcefeet.HasValue)
            {
                return FromKilopoundForceFeet(kilopoundforcefeet.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable KilopoundForceInches.
        /// </summary>
        public static Torque? FromKilopoundForceInches(double? kilopoundforceinches)
        {
            if (kilopoundforceinches.HasValue)
            {
                return FromKilopoundForceInches(kilopoundforceinches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable NewtonCentimeters.
        /// </summary>
        public static Torque? FromNewtonCentimeters(double? newtoncentimeters)
        {
            if (newtoncentimeters.HasValue)
            {
                return FromNewtonCentimeters(newtoncentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable NewtonMeters.
        /// </summary>
        public static Torque? FromNewtonMeters(double? newtonmeters)
        {
            if (newtonmeters.HasValue)
            {
                return FromNewtonMeters(newtonmeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable NewtonMillimeters.
        /// </summary>
        public static Torque? FromNewtonMillimeters(double? newtonmillimeters)
        {
            if (newtonmillimeters.HasValue)
            {
                return FromNewtonMillimeters(newtonmillimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable PoundForceFeet.
        /// </summary>
        public static Torque? FromPoundForceFeet(double? poundforcefeet)
        {
            if (poundforcefeet.HasValue)
            {
                return FromPoundForceFeet(poundforcefeet.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable PoundForceInches.
        /// </summary>
        public static Torque? FromPoundForceInches(double? poundforceinches)
        {
            if (poundforceinches.HasValue)
            {
                return FromPoundForceInches(poundforceinches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable TonneForceCentimeters.
        /// </summary>
        public static Torque? FromTonneForceCentimeters(double? tonneforcecentimeters)
        {
            if (tonneforcecentimeters.HasValue)
            {
                return FromTonneForceCentimeters(tonneforcecentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable TonneForceMeters.
        /// </summary>
        public static Torque? FromTonneForceMeters(double? tonneforcemeters)
        {
            if (tonneforcemeters.HasValue)
            {
                return FromTonneForceMeters(tonneforcemeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Torque from nullable TonneForceMillimeters.
        /// </summary>
        public static Torque? FromTonneForceMillimeters(double? tonneforcemillimeters)
        {
            if (tonneforcemillimeters.HasValue)
            {
                return FromTonneForceMillimeters(tonneforcemillimeters.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TorqueUnit" /> to <see cref="Torque" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Torque unit value.</returns>
        public static Torque From(double val, TorqueUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TorqueUnit.KilogramForceCentimeter:
                    return FromKilogramForceCentimeters(val);
                case TorqueUnit.KilogramForceMeter:
                    return FromKilogramForceMeters(val);
                case TorqueUnit.KilogramForceMillimeter:
                    return FromKilogramForceMillimeters(val);
                case TorqueUnit.KilonewtonCentimeter:
                    return FromKilonewtonCentimeters(val);
                case TorqueUnit.KilonewtonMeter:
                    return FromKilonewtonMeters(val);
                case TorqueUnit.KilonewtonMillimeter:
                    return FromKilonewtonMillimeters(val);
                case TorqueUnit.KilopoundForceFoot:
                    return FromKilopoundForceFeet(val);
                case TorqueUnit.KilopoundForceInch:
                    return FromKilopoundForceInches(val);
                case TorqueUnit.NewtonCentimeter:
                    return FromNewtonCentimeters(val);
                case TorqueUnit.NewtonMeter:
                    return FromNewtonMeters(val);
                case TorqueUnit.NewtonMillimeter:
                    return FromNewtonMillimeters(val);
                case TorqueUnit.PoundForceFoot:
                    return FromPoundForceFeet(val);
                case TorqueUnit.PoundForceInch:
                    return FromPoundForceInches(val);
                case TorqueUnit.TonneForceCentimeter:
                    return FromTonneForceCentimeters(val);
                case TorqueUnit.TonneForceMeter:
                    return FromTonneForceMeters(val);
                case TorqueUnit.TonneForceMillimeter:
                    return FromTonneForceMillimeters(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TorqueUnit" /> to <see cref="Torque" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Torque unit value.</returns>
        public static Torque? From(double? value, TorqueUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case TorqueUnit.KilogramForceCentimeter:
                    return FromKilogramForceCentimeters(value.Value);
                case TorqueUnit.KilogramForceMeter:
                    return FromKilogramForceMeters(value.Value);
                case TorqueUnit.KilogramForceMillimeter:
                    return FromKilogramForceMillimeters(value.Value);
                case TorqueUnit.KilonewtonCentimeter:
                    return FromKilonewtonCentimeters(value.Value);
                case TorqueUnit.KilonewtonMeter:
                    return FromKilonewtonMeters(value.Value);
                case TorqueUnit.KilonewtonMillimeter:
                    return FromKilonewtonMillimeters(value.Value);
                case TorqueUnit.KilopoundForceFoot:
                    return FromKilopoundForceFeet(value.Value);
                case TorqueUnit.KilopoundForceInch:
                    return FromKilopoundForceInches(value.Value);
                case TorqueUnit.NewtonCentimeter:
                    return FromNewtonCentimeters(value.Value);
                case TorqueUnit.NewtonMeter:
                    return FromNewtonMeters(value.Value);
                case TorqueUnit.NewtonMillimeter:
                    return FromNewtonMillimeters(value.Value);
                case TorqueUnit.PoundForceFoot:
                    return FromPoundForceFeet(value.Value);
                case TorqueUnit.PoundForceInch:
                    return FromPoundForceInches(value.Value);
                case TorqueUnit.TonneForceCentimeter:
                    return FromTonneForceCentimeters(value.Value);
                case TorqueUnit.TonneForceMeter:
                    return FromTonneForceMeters(value.Value);
                case TorqueUnit.TonneForceMillimeter:
                    return FromTonneForceMillimeters(value.Value);

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
        public static string GetAbbreviation(TorqueUnit unit)
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
        public static string GetAbbreviation(TorqueUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Torque)) throw new ArgumentException("Expected type Torque.", "obj");
            return CompareTo((Torque) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Torque other)
        {
            return _newtonMeters.CompareTo(other._newtonMeters);
        }

#if !WINDOWS_UWP
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
#endif

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
        public static Torque Parse(string str)
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
        public static Torque Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Torque.FromNewtonMeters(x.NewtonMeters + y.NewtonMeters));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Torque> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Torque>();

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
                    TorqueUnit unit = ParseUnit(unitString, formatProvider);
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
        public static TorqueUnit ParseUnit(string str)
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
        public static TorqueUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static TorqueUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<TorqueUnit>(str.Trim());

            if (unit == TorqueUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TorqueUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is NewtonMeter
        /// </summary>
        public static TorqueUnit ToStringDefaultUnit { get; set; } = TorqueUnit.NewtonMeter;

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
        public string ToString(TorqueUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(TorqueUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(TorqueUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(TorqueUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of Torque
        /// </summary>
        public static Torque MaxValue
        {
            get
            {
                return new Torque(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of Torque
        /// </summary>
        public static Torque MinValue
        {
            get
            {
                return new Torque(double.MinValue);
            }
        }
    }
}
