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
using System.Collections.Generic;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing distance in two dimensions,
    ///     according to the International System of Units (SI)
    /// </summary>
    public struct SiDistance2d
    {
        private const NumberStyles NumberStyle = NumberStyles.Float;
        private static readonly CultureInfo Culture = new CultureInfo("en-us");

        /// <summary>
        ///     Returns a point represented in meters.
        /// </summary>
        public readonly Vector2 Meters;

        /// <summary>
        ///     Creates an instance based on X and Y in implicitly defined SI units.
        /// </summary>
        public SiDistance2d(double xMeters, double yMeters)
        {
            Meters = new Vector2(xMeters, yMeters);
        }

        public SiDistance2d(Length x, Length y) : this(x.Meters, y.Meters)
        {
        }

        #region Static

        public static Length GetDistance(SiDistance2d a, SiDistance2d b)
        {
            Vector2 d = (a - b).Meters;
            return Length.FromMeters(Math.Sqrt(d.X*d.X + d.Y*d.Y));
        }

        #endregion

        #region Public properties

        public Length Distance
        {
            get
            {
                double x = Meters.X;
                double y = Meters.Y;
                return Length.FromMeters(Math.Sqrt(x*x + y*y));
            }
        }

        public Length X
        {
            get { return Length.FromMeters(Meters.X); }
        }

        public Length Y
        {
            get { return Length.FromMeters(Meters.Y); }
        }

        public Vector2 Miles
        {
            get { return new Vector2(X.Miles, Y.Miles); }
        } 

        public Vector2 Yards
        {
            get { return new Vector2(X.Yards, Y.Yards); }
        } 

        public Vector2 Feet
        {
            get { return new Vector2(X.Feet, Y.Feet); }
        }

        public Vector2 Inches
        {
            get { return new Vector2(X.Inches, Y.Inches); }
        }

        public Vector2 Kilometers
        {
            get { return new Vector2(X.Kilometers, Y.Kilometers); }
        } 

        public Vector2 Decimeters
        {
            get { return new Vector2(X.Decimeters, Y.Decimeters); }
        } 

        /// <summary>
        ///     Returns a point represented in centimeters.
        /// </summary>
        public Vector2 Centimeters
        {
            get { return new Vector2(Meters.X*1E2, Meters.Y*1E2); }
        }

        /// <summary>
        ///     Returns a point represented in millimeters.
        /// </summary>
        public Vector2 Millimeters
        {
            get { return new Vector2(Meters.X*1E3, Meters.Y*1E3); }
        }

        public Vector2 Micrometers
        {
            get { return new Vector2(X.Micrometers, Y.Micrometers); }
        } 

        public Vector2 Nanometers
        {
            get { return new Vector2(X.Nanometers, Y.Nanometers); }
        } 

        #endregion

        #region Static methods

        public static SiDistance2d Zero
        {
            get { return new SiDistance2d(); }
        }

        public static SiDistance2d FromMeters(double xMeters, double yMeters)
        {
            return new SiDistance2d(xMeters, yMeters);
        }

        public static SiDistance2d FromCentimeters(double xCentimeters, double yCentimeters)
        {
            return new SiDistance2d(xCentimeters*1E-2, yCentimeters*1E-2);
        }

        public static SiDistance2d FromMillimeters(double xMillimeters, double yMillimeters)
        {
            return new SiDistance2d(xMillimeters*1E-3, yMillimeters*1E-3);
        }

        #endregion

        #region Arithmetic operators

        public static SiDistance2d operator -(SiDistance2d right)
        {
            return FromMeters(-right.X.Meters, -right.Y.Meters);
        }

        public static SiDistance2d operator +(SiDistance2d left, SiDistance2d right)
        {
            double x = left.X.Meters + right.X.Meters;
            double y = left.Y.Meters + right.Y.Meters;
            return FromMeters(x, y);
        }

        public static SiDistance2d operator -(SiDistance2d left, SiDistance2d right)
        {
            double x = left.X.Meters - right.X.Meters;
            double y = left.Y.Meters - right.Y.Meters;
            return FromMeters(x, y);
        }

        public static SiDistance2d operator *(double left, SiDistance2d right)
        {
            double x = left*right.X.Meters;
            double y = left*right.Y.Meters;
            return FromMeters(x, y);
        }

        public static SiDistance2d operator *(SiDistance2d left, SiDistance2d right)
        {
            double x = left.X.Meters*right.X.Meters;
            double y = left.Y.Meters*right.Y.Meters;
            return FromMeters(x, y);
        }

        public static SiDistance2d operator /(SiDistance2d left, double right)
        {
            double x = left.X.Meters/right;
            double y = left.Y.Meters/right;
            return FromMeters(x, y);
        }

        public static SiDistance2d operator /(SiDistance2d left, SiDistance2d right)
        {
            double x = left.X.Meters/right.X.Meters;
            double y = left.Y.Meters/right.Y.Meters;
            return FromMeters(x, y);
        }

        #endregion

        #region Public methods

        public override string ToString()
        {
            return String.Format(Culture, "{0},{1}", X.Meters, Y.Meters);
        }

        public static SiDistance2d Parse(string text)
        {
            string[] values = text.Split(',');
            if (values.Length != 2) throw new ArgumentException();

            double xMeters = 0;
            double yMeters = 0;
            double.TryParse(values[0], NumberStyle, Culture, out xMeters);
            double.TryParse(values[1], NumberStyle, Culture, out yMeters);
            return new SiDistance2d(xMeters, yMeters);
        }

        public Length DistanceTo(SiDistance2d other)
        {
            double dx = X.Meters - other.X.Meters;
            double dy = Y.Meters - other.Y.Meters;
            double distance = Math.Sqrt(dx*dx + dy*dy);

            return Length.FromMeters(distance);
        }

        #endregion

        #region Equality

        private static readonly IEqualityComparer<SiDistance2d> MetersComparerInstance = new MetersEqualityComparer();

        public static IEqualityComparer<SiDistance2d> MetersComparer
        {
            get { return MetersComparerInstance; }
        }

        public bool Equals(SiDistance2d other)
        {
            return Meters.Equals(other.Meters);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SiDistance2d && Equals((SiDistance2d) obj);
        }

        public override int GetHashCode()
        {
            return Meters.GetHashCode();
        }

        public static bool operator !=(SiDistance2d left, SiDistance2d right)
        {
            return left.Meters != right.Meters;
        }

        public static bool operator ==(SiDistance2d left, SiDistance2d right)
        {
            return left.Meters == right.Meters;
        }

        private sealed class MetersEqualityComparer : IEqualityComparer<SiDistance2d>
        {
            public bool Equals(SiDistance2d x, SiDistance2d y)
            {
                return x.Meters.Equals(y.Meters);
            }

            public int GetHashCode(SiDistance2d obj)
            {
                return obj.Meters.GetHashCode();
            }
        }

        #endregion
    }
}