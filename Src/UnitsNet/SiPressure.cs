// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing force, according to the International System of Units (SI).
    /// </summary>
    public struct SiPressure : IComparable, IComparable<SiPressure>
    {
        private const double KpaToPaRatio = 1000;
        private const double NscToPaRatio = 0.0001;
        private const double BarToPaRatio = 1E-5;
        private const double TaToPaRatio = 10.197E-6;
        private const double AtmToPaRatio = 9.8692E-6;
        private const double TorrToPaRatio = 7.5006E-3;
        private const double PsiToPaRatio = 145.04E-6;

        /// <summary>
        ///     Returns a kilogram representation of the force instance.
        /// </summary>
        public readonly double Pascals;

        public SiPressure(double pascals) : this()
        {
            Pascals = pascals;
        }

        #region Unit Properties

        public double KiloPascals
        {
            get { return KpaToPaRatio*Pascals; }
            //set { Pascals = value / KpaToPaRatio; }
        }

        public double NewtonsPerSquareCentimeter
        {
            get { return NscToPaRatio*Pascals; }
            //set { Pascals = value / NscToPaRatio; }
        }

        public double Bars
        {
            get { return BarToPaRatio*Pascals; }
            //set { Pascals = value / BarToPaRatio; }
        }

        public double TechnicalAtmosphere
        {
            get { return TaToPaRatio*Pascals; }
            //set { Pascals = value / TaToPaRatio; }
        }

        public double Atmosphere
        {
            get { return AtmToPaRatio*Pascals; }
            //set { Pascals = value / AtmToPaRatio; }
        }

        public double Torr
        {
            get { return TorrToPaRatio*Pascals; }
            //set { Pascals = value / TorrToPaRatio; }
        }

        public double Psi
        {
            get { return PsiToPaRatio*Pascals; }
            //set { Pascals = value / PsiToPaRatio; }
        }

        #endregion

        #region Static 

        public static SiPressure Zero
        {
            get { return new SiPressure(0); }
        }

        public static SiPressure FromPascals(double pascals)
        {
            return new SiPressure(pascals);
        }

        public static SiPressure FromKiloPascals(double kpa)
        {
            return new SiPressure(KpaToPaRatio*kpa);
        }

        public static SiPressure FromNewtonsPerSquareCentimeter(double nsc)
        {
            return new SiPressure(NscToPaRatio*nsc);
        }

        public static SiPressure FromBars(double bars)
        {
            return new SiPressure(BarToPaRatio*bars);
        }

        public static SiPressure FromTechnicalAtmosphere(double ta)
        {
            return new SiPressure(TaToPaRatio*ta);
        }

        public static SiPressure FromAtmosphere(double atm)
        {
            return new SiPressure(AtmToPaRatio*atm);
        }

        public static SiPressure FromTorr(double torr)
        {
            return new SiPressure(TorrToPaRatio*torr);
        }

        public static SiPressure FromPsi(double psi)
        {
            return new SiPressure(PsiToPaRatio*psi);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SIPressure to negativize.</param>
        /// <returns></returns>
        public static SiPressure operator -(SiPressure right)
        {
            return new SiPressure(-right.Pascals);
        }

        public static SiPressure operator +(SiPressure left, SiPressure right)
        {
            return new SiPressure(left.Pascals + right.Pascals);
        }

        public static SiPressure operator -(SiPressure left, SiPressure right)
        {
            return new SiPressure(left.Pascals - right.Pascals);
        }

        public static SiPressure operator *(double left, SiPressure right)
        {
            return new SiPressure(left*right.Pascals);
        }

        public static SiPressure operator /(SiPressure left, double right)
        {
            return new SiPressure(left.Pascals/right);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiPressure)) throw new ArgumentException("Expected type SiPressure.", "obj");
            return CompareTo((SiPressure) obj);
        }

        public int CompareTo(SiPressure other)
        {
            return Pascals.CompareTo(other.Pascals);
        }

        public static bool operator <=(SiPressure left, SiPressure right)
        {
            return left.Pascals <= right.Pascals;
        }

        public static bool operator >=(SiPressure left, SiPressure right)
        {
            return left.Pascals >= right.Pascals;
        }

        public static bool operator <(SiPressure left, SiPressure right)
        {
            return left.Pascals < right.Pascals;
        }

        public static bool operator >(SiPressure left, SiPressure right)
        {
            return left.Pascals > right.Pascals;
        }

        #endregion

        public override string ToString()
        {
            return Pascals + " " + SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(SiUnit.Pascal);
        }
    }
}