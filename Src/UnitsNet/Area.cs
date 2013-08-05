using System;

namespace UnitsNet
{
    public struct Area
    {
        private const double SquareKilometersToSquareMetersRatio = 1E6;
        private const double SquareDecimetersToSquareMetersRatio = 1E-2;
        private const double SquareCentimetersToSquareMetersRatio = 1E-4;
        private const double SquareMillimetersToSquareMetersRatio = 1E-6;

        public readonly double SquareMeters;

        public Area(double squareMeters)
        {
            SquareMeters = squareMeters;
        }

        #region Unit Properties

        public double SquareKilometers
        {
            get { return SquareMeters/SquareKilometersToSquareMetersRatio; }
        }

        public double SquareDecimeters
        {
            get { return SquareMeters/SquareDecimetersToSquareMetersRatio; }
        }

        public double SquareCentimeters
        {
            get { return SquareMeters/SquareCentimetersToSquareMetersRatio; }
        }

        public double SquareMillimeters
        {
            get { return SquareMeters/SquareMillimetersToSquareMetersRatio; }
        }

        #endregion

        #region Static

        /// <summary>
        ///     The maximum representable area in square meters.
        /// </summary>
        public static Area Max
        {
            get { return new Area(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable area in square meters.
        /// </summary>
        public static Area Min
        {
            get { return new Area(double.MinValue); }
        }

        public static Area Zero
        {
            get { return new Area(); }
        }

        public static Area FromSquareKilometers(double squareKilometers)
        {
            return new Area(squareKilometers*SquareKilometersToSquareMetersRatio);
        }

        public static Area FromSquareMeters(double squareMeters)
        {
            return new Area(squareMeters);
        }

        public static Area FromSquareDecimeters(double squareDecimeters)
        {
            return new Area(squareDecimeters*SquareDecimetersToSquareMetersRatio);
        }

        public static Area FromSquareCentimeters(double squareCentimeters)
        {
            return new Area(squareCentimeters*SquareCentimetersToSquareMetersRatio);
        }

        public static Area FromSquareMillimeters(double squareMillimeters)
        {
            return new Area(squareMillimeters*SquareMillimetersToSquareMetersRatio);
        }

        #endregion

        #region Arithmetic operators

        public static Area operator -(Area right)
        {
            return FromSquareMeters(-right.SquareMeters);
        }

        public static Area operator +(Area left, Area right)
        {
            return FromSquareMeters(left.SquareMeters + right.SquareMeters);
        }

        public static Area operator -(Area left, Area right)
        {
            return FromSquareMeters(left.SquareMeters - right.SquareMeters);
        }

        public static Area operator *(double left, Area right)
        {
            return FromSquareMeters(left*right.SquareMeters);
        }

        public static Area operator *(Area left, double right)
        {
            return FromSquareMeters(left.SquareMeters*right);
        }

        public static Area operator /(Area left, double right)
        {
            return FromSquareMeters(left.SquareMeters/right);
        }

        public static double operator /(Area left, Area right)
        {
            return left.SquareMeters/right.SquareMeters;
        }

        #endregion

        #region Comparable operators

        public static bool operator <=(Area left, Area right)
        {
            return left.SquareMeters <= right.SquareMeters;
        }

        public static bool operator >=(Area left, Area right)
        {
            return left.SquareMeters >= right.SquareMeters;
        }

        public static bool operator <(Area left, Area right)
        {
            return left.SquareMeters < right.SquareMeters;
        }

        public static bool operator >(Area left, Area right)
        {
            return left.SquareMeters > right.SquareMeters;
        }

        public static bool operator ==(Area left, Area right)
        {
            return left.SquareMeters == right.SquareMeters;
        }

        public static bool operator !=(Area left, Area right)
        {
            return !(left.SquareMeters == right.SquareMeters);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Area)) throw new ArgumentException("Expected type Area.", "obj");
            return CompareTo((Area) obj);
        }

        public int CompareTo(Area other)
        {
            return SquareMeters.CompareTo(other.SquareMeters);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Area))
            {
                return false;
            }

            return SquareMeters.CompareTo(((Area) obj).SquareMeters) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return SquareMeters + " m²";
        }
    }
}