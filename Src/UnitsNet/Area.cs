using System;

namespace UnitsNet
{
    public struct Area : IComparable, IComparable<Area>
    {
        private const double SquareKilometersToSquareMetersRatio = 1E6;
        private const double SquareDecimetersToSquareMetersRatio = 1E-2;
        private const double SquareCentimetersToSquareMetersRatio = 1E-4;
        private const double SquareMillimetersToSquareMetersRatio = 1E-6;
        private const double SquareMilesToSquareMetersRatio = 2.59*1E+6;
        private const double SquareYardsToSquareMetersRatio = 0.836127;
        private const double SquareFeetToSquareMetersRatio = 0.092903;
        private const double SquareInchesToSquareMetersRatio = 0.00064516;

        public readonly double SquareMeters;

        public Area(double squareMeters)
        {
            SquareMeters = squareMeters;
        }

        #region Unit Properties

        public double SquareKilometers
        {
            get { return SquareMeters / SquareKilometersToSquareMetersRatio; }
        }

        public double SquareDecimeters
        {
            get { return SquareMeters / SquareDecimetersToSquareMetersRatio; }
        }

        public double SquareCentimeters
        {
            get { return SquareMeters / SquareCentimetersToSquareMetersRatio; }
        }

        public double SquareMillimeters
        {
            get { return SquareMeters / SquareMillimetersToSquareMetersRatio; }
        }

        public double SquareMiles
        {
            get { return SquareMeters / SquareMilesToSquareMetersRatio; }
        }

        public double SquareYards
        {
            get { return SquareMeters / SquareYardsToSquareMetersRatio; }
        }

        public double SquareFeet
        {
            get { return SquareMeters / SquareFeetToSquareMetersRatio; }
        }

        public double SquareInches
        {
            get { return SquareMeters / SquareInchesToSquareMetersRatio; }
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
            return new Area(squareKilometers * SquareKilometersToSquareMetersRatio);
        }

        public static Area FromSquareMeters(double squareMeters)
        {
            return new Area(squareMeters);
        }

        public static Area FromSquareDecimeters(double squareDecimeters)
        {
            return new Area(squareDecimeters * SquareDecimetersToSquareMetersRatio);
        }

        public static Area FromSquareCentimeters(double squareCentimeters)
        {
            return new Area(squareCentimeters * SquareCentimetersToSquareMetersRatio);
        }

        public static Area FromSquareMillimeters(double squareMillimeters)
        {
            return new Area(squareMillimeters * SquareMillimetersToSquareMetersRatio);
        }

        public static Area FromSquareMiles(double sqmi)
        {
            return new Area(sqmi * SquareMilesToSquareMetersRatio);
        }

        public static Area FromSquareYards(double yds)
        {
            return new Area(yds * SquareYardsToSquareMetersRatio);
        }

        public static Area FromSquareFeet(double ft)
        {
            return new Area(ft * SquareFeetToSquareMetersRatio);
        }

        public static Area FromSquareInches(double inches)
        {
            return new Area(inches * SquareInchesToSquareMetersRatio);
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
            return FromSquareMeters(left * right.SquareMeters);
        }

        public static Area operator *(Area left, double right)
        {
            return FromSquareMeters(left.SquareMeters * right);
        }

        public static Area operator /(Area left, double right)
        {
            return FromSquareMeters(left.SquareMeters / right);
        }

        public static double operator /(Area left, Area right)
        {
            return left.SquareMeters / right.SquareMeters;
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
            return CompareTo((Area)obj);
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

            return SquareMeters.CompareTo(((Area)obj).SquareMeters) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", SquareMeters, UnitSystem.Create().GetDefaultAbbreviation(Unit.SquareMeter));
        }
    }
}