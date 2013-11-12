using System;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing revolution.
    /// </summary>
    public struct Revolution : IComparable, IComparable<Revolution>
    {
        private const double MinuteToSecondRatio = 0.0166666666666667;
        private const double SecondToMinuteRatio = 60;

        public readonly double RevolutionsPerSecond;

        private Revolution(double revolutionsPerSecond)
            : this()
        {
            RevolutionsPerSecond = revolutionsPerSecond;
        }

        public double RevolutionsPerMinute
        {
            get { return RevolutionsPerSecond * SecondToMinuteRatio; }
        }

        #region Static

        public static Revolution Zero
        {
            get { return new Revolution(); }
        }

        public static Revolution FromRevolutionsPerMinute(double revolutionsPerMinute)
        {
            return new Revolution(revolutionsPerMinute * MinuteToSecondRatio);
        }

        public static Revolution FromRevolutionsPerSecond(double revolutionsPerSecond)
        {
            return new Revolution(revolutionsPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Revolution)) throw new ArgumentException("Expected type Revolution.", "obj");
            return CompareTo((Revolution)obj);
        }

        public int CompareTo(Revolution other)
        {
            return RevolutionsPerSecond.CompareTo(other.RevolutionsPerSecond);
        }

        public static bool operator <=(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond <= right.RevolutionsPerSecond;
        }

        public static bool operator >=(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond >= right.RevolutionsPerSecond;
        }

        public static bool operator <(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond < right.RevolutionsPerSecond;
        }

        public static bool operator >(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond > right.RevolutionsPerSecond;
        }

        public static bool operator ==(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond == right.RevolutionsPerSecond;
        }

        public static bool operator !=(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond != right.RevolutionsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return RevolutionsPerSecond.Equals(((Revolution)obj).RevolutionsPerSecond);
        }

        public override int GetHashCode()
        {
            return RevolutionsPerSecond.GetHashCode();
        }
        #endregion

        #region Arithmetic operators

        public static Revolution operator -(Revolution right)
        {
            return new Revolution(-right.RevolutionsPerSecond);
        }

        public static Revolution operator +(Revolution left, Revolution right)
        {
            return new Revolution(left.RevolutionsPerSecond + right.RevolutionsPerSecond);
        }

        public static Revolution operator -(Revolution left, Revolution right)
        {
            return new Revolution(left.RevolutionsPerSecond - right.RevolutionsPerSecond);
        }

        public static Revolution operator *(double left, Revolution right)
        {
            return new Revolution(left * right.RevolutionsPerSecond);
        }

        public static Revolution operator *(Revolution left, double right)
        {
            return new Revolution(left.RevolutionsPerSecond * right);
        }

        public static Revolution operator /(Revolution left, double right)
        {
            return new Revolution(left.RevolutionsPerSecond / right);
        }

        public static double operator /(Revolution left, Revolution right)
        {
            return left.RevolutionsPerSecond / right.RevolutionsPerSecond;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("≈{0:0.##} {1}", RevolutionsPerSecond, UnitSystem.Create().GetDefaultAbbreviation(Unit.RevolutionsPerSecond));
        }
    }
}
