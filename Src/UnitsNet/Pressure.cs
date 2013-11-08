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

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing force.
    /// </summary>
    public struct Pressure : IComparable, IComparable<Pressure>
    {
        private const double KpaToPaRatio = 1000;
        private const double Nm2ToPaRatio = 1;
        private const double Ncm2ToPaRatio = 1E+4;
        private const double Nmm2ToPaRatio = 1E+6;
        private const double BarToPaRatio = 1E+5;
        private const double TaToPaRatio = 9.80680592331*1E4;
        private const double AtmToPaRatio = 101325;
        private const double TorrToPaRatio = 1.3332266752*1E2;
        private const double PsiToPaRatio = 6.89464975179*1E3;

        /// <summary>
        ///     Pressure in pascal.
        /// </summary>
        public readonly double Pascals;

        public Pressure(double pascals) : this()
        {
            Pascals = pascals;
        }

        #region Unit Properties

        public double KiloPascals
        {
            get { return Pascals/KpaToPaRatio; }
        }

        public double NewtonsPerSquareMeter
        {
            get { return Pascals/Nm2ToPaRatio; }
        }

        public double NewtonsPerSquareCentimeter
        {
            get { return Pascals/Ncm2ToPaRatio; }
        }

        public double NewtonsPerSquareMillimeter
        {
            get { return Pascals/Nmm2ToPaRatio; }
        }

        public double Bars
        {
            get { return Pascals/BarToPaRatio; }
        }

        public double TechnicalAtmosphere
        {
            get { return Pascals/TaToPaRatio; }
        }

        public double Atmosphere
        {
            get { return Pascals/AtmToPaRatio; }
        }

        public double Torr
        {
            get { return Pascals/TorrToPaRatio; }
        }

        public double Psi
        {
            get { return Pascals/PsiToPaRatio; }
        }

        #endregion

        #region Static 

        /// <summary>
        ///     The maximum representable distance in pascals.
        /// </summary>
        public static Pressure Max
        {
            get { return new Pressure(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable distance in pascals.
        /// </summary>
        public static Pressure Min
        {
            get { return new Pressure(double.MinValue); }
        }

        public static Pressure Zero
        {
            get { return new Pressure(0); }
        }

        public static Pressure FromPascals(double pascals)
        {
            return new Pressure(pascals);
        }

        public static Pressure FromKiloPascals(double kpa)
        {
            return new Pressure(KpaToPaRatio*kpa);
        }

        public static Pressure FromNewtonsPerSquareCentimeter(double nsc)
        {
            return new Pressure(Ncm2ToPaRatio*nsc);
        }

        public static Pressure FromNewtonsPerSquareMeter(double nm2)
        {
            return new Pressure(Nm2ToPaRatio*nm2);
        }

        public static Pressure FromNewtonsPerSquareMillimeter(double nmm2)
        {
            return new Pressure(Nmm2ToPaRatio*nmm2);
        }

        public static Pressure FromBars(double bars)
        {
            return new Pressure(BarToPaRatio*bars);
        }

        public static Pressure FromTechnicalAtmosphere(double ta)
        {
            return new Pressure(TaToPaRatio*ta);
        }

        public static Pressure FromAtmosphere(double atm)
        {
            return new Pressure(AtmToPaRatio*atm);
        }

        public static Pressure FromTorr(double torr)
        {
            return new Pressure(TorrToPaRatio*torr);
        }

        public static Pressure FromPsi(double psi)
        {
            return new Pressure(PsiToPaRatio*psi);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SIPressure to negativize.</param>
        /// <returns></returns>
        public static Pressure operator -(Pressure right)
        {
            return new Pressure(-right.Pascals);
        }

        public static Pressure operator +(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals + right.Pascals);
        }

        public static Pressure operator -(Pressure left, Pressure right)
        {
            return new Pressure(left.Pascals - right.Pascals);
        }

        public static Pressure operator *(Pressure left, double right)
        {
            return new Pressure(left.Pascals*right);
        }

        public static Pressure operator *(double left, Pressure right)
        {
            return new Pressure(left*right.Pascals);
        }

        public static Pressure operator /(Pressure left, double right)
        {
            return new Pressure(left.Pascals/right);
        }

        public static double operator /(Pressure left, Pressure right)
        {
            return left.Pascals/right.Pascals;
        }

        #endregion

        #region Comparison / Equality Operators

        public static bool operator <=(Pressure left, Pressure right)
        {
            return left.Pascals <= right.Pascals;
        }

        public static bool operator >=(Pressure left, Pressure right)
        {
            return left.Pascals >= right.Pascals;
        }

        public static bool operator <(Pressure left, Pressure right)
        {
            return left.Pascals < right.Pascals;
        }

        public static bool operator >(Pressure left, Pressure right)
        {
            return left.Pascals > right.Pascals;
        }

        public static bool operator !=(Pressure left, Pressure right)
        {
            return left.Pascals != right.Pascals;
        }

        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Pascals == right.Pascals;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Pressure)) throw new ArgumentException("Expected type Pressure.", "obj");
            return CompareTo((Pressure) obj);
        }

        public int CompareTo(Pressure other)
        {
            return Pascals.CompareTo(other.Pascals);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Pressure && ((Pressure) obj).Pascals.Equals(Pascals);
        }

        public bool Equals(Pressure other)
        {
            return other.Pascals == Pascals;
        }

        public override int GetHashCode()
        {
            return Pascals.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("≈{0:0.##} {1}", Pascals, UnitSystem.Create().GetDefaultAbbreviation(Unit.Pascal));
        }
    }
}