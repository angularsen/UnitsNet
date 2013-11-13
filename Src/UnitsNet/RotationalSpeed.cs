using System;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
	///     A class for representing rotational speed.
    /// </summary>
    public struct RotationalSpeed : IComparable, IComparable<RotationalSpeed>
    {
        private const double MinuteToSecondRatio = 0.0166666666666667;
        private const double SecondToMinuteRatio = 60;

        public readonly double RevolutionsPerSecond;

        private RotationalSpeed(double revolutionsPerSecond)
            : this()
        {
            RevolutionsPerSecond = revolutionsPerSecond;
        }

        public double RevolutionsPerMinute
        {
            get { return RevolutionsPerSecond * SecondToMinuteRatio; }
        }

        #region Static

        public static RotationalSpeed Zero
        {
            get { return new RotationalSpeed(); }
        }

        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsPerMinute)
        {
            return new RotationalSpeed(revolutionsPerMinute * MinuteToSecondRatio);
        }

        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionsPerSecond)
        {
            return new RotationalSpeed(revolutionsPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is RotationalSpeed)) throw new ArgumentException("Expected type RotationalSpeed.", "obj");
            return CompareTo((RotationalSpeed)obj);
        }

        public int CompareTo(RotationalSpeed other)
        {
            return RevolutionsPerSecond.CompareTo(other.RevolutionsPerSecond);
        }

        public static bool operator <=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond <= right.RevolutionsPerSecond;
        }

        public static bool operator >=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond >= right.RevolutionsPerSecond;
        }

        public static bool operator <(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond < right.RevolutionsPerSecond;
        }

        public static bool operator >(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond > right.RevolutionsPerSecond;
        }

        public static bool operator ==(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond == right.RevolutionsPerSecond;
        }

        public static bool operator !=(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond != right.RevolutionsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return RevolutionsPerSecond.Equals(((RotationalSpeed)obj).RevolutionsPerSecond);
        }

        public override int GetHashCode()
        {
            return RevolutionsPerSecond.GetHashCode();
        }
        #endregion

        #region Arithmetic operators

        public static RotationalSpeed operator -(RotationalSpeed right)
        {
            return new RotationalSpeed(-right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator +(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond + right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator -(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond - right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator *(double left, RotationalSpeed right)
        {
            return new RotationalSpeed(left * right.RevolutionsPerSecond);
        }

        public static RotationalSpeed operator *(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond * right);
        }

        public static RotationalSpeed operator /(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left.RevolutionsPerSecond / right);
        }

        public static double operator /(RotationalSpeed left, RotationalSpeed right)
        {
            return left.RevolutionsPerSecond / right.RevolutionsPerSecond;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", RevolutionsPerSecond, UnitSystem.Create().GetDefaultAbbreviation(Unit.RevolutionsPerSecond));
        }
    }
}
