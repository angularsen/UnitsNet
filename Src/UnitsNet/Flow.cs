using System;
using System.Globalization;

namespace UnitsNet
{
	/// <summary>
	///     A class for representing flow.
	/// </summary>
	public struct Flow : IComparable, IComparable<Flow>
	{
		public readonly double CubicMeterPerSecond;

		private Flow(double cubicMeterPerSecond)
			: this()
		{
			CubicMeterPerSecond = cubicMeterPerSecond;
		}

		public double CubicMeterPerHour
		{
			get { return CubicMeterPerSecond / 3600; }
		}

		#region Static

		public static Flow Zero
		{
			get { return new Flow(); }
		}

		public static Flow FromCubicMeterPerHour(double cmph)
		{
			return new Flow(cmph * 3600);
		}

		public static Flow FromCubicMeterPerSecond(double cubicMeterPerSecond)
		{
			return new Flow(cubicMeterPerSecond);
		}

		#endregion

		#region Equality / IComparable

		public int CompareTo(object obj)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (!(obj is Flow)) throw new ArgumentException("Expected type Flow.", "obj");
			return CompareTo((Flow)obj);
		}

		public int CompareTo(Flow other)
		{
			return CubicMeterPerSecond.CompareTo(other.CubicMeterPerSecond);
		}

		public static bool operator <=(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond <= right.CubicMeterPerSecond;
		}

		public static bool operator >=(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond >= right.CubicMeterPerSecond;
		}

		public static bool operator <(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond < right.CubicMeterPerSecond;
		}

		public static bool operator >(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond > right.CubicMeterPerSecond;
		}

		public static bool operator ==(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond == right.CubicMeterPerSecond;
		}

		public static bool operator !=(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond != right.CubicMeterPerSecond;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			return CubicMeterPerSecond.Equals(((Flow)obj).CubicMeterPerSecond);
		}

		public override int GetHashCode()
		{
			return CubicMeterPerSecond.GetHashCode();
		}
		#endregion

		#region Arithmetic operators

		public static Flow operator -(Flow right)
		{
			return new Flow(-right.CubicMeterPerSecond);
		}

		public static Flow operator +(Flow left, Flow right)
		{
			return new Flow(left.CubicMeterPerSecond + right.CubicMeterPerSecond);
		}

		public static Flow operator -(Flow left, Flow right)
		{
			return new Flow(left.CubicMeterPerSecond - right.CubicMeterPerSecond);
		}

		public static Flow operator *(double left, Flow right)
		{
			return new Flow(left * right.CubicMeterPerSecond);
		}

		public static Flow operator *(Flow left, double right)
		{
			return new Flow(left.CubicMeterPerSecond * right);
		}

		public static Flow operator /(Flow left, double right)
		{
			return new Flow(left.CubicMeterPerSecond / right);
		}

		public static double operator /(Flow left, Flow right)
		{
			return left.CubicMeterPerSecond / right.CubicMeterPerSecond;
		}

		#endregion

		public override string ToString()
		{
			return CubicMeterPerSecond + " " + UnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.CubicMeterPerSecond);
		}
	}
}