// Copyright(c) 2007 Andreas Gullberg Larsen
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

namespace UnitsNet
{
#if WINDOWS_UWP
    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;
    }
#else
    public struct Vector3 : IEquatable<Vector3>
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Equality

        public Vector3(double xyz) : this()
        {
            X = xyz;
            Y = xyz;
            Z = xyz;
        }

        private static IEqualityComparer<Vector3> XyzComparer { get; } = new XyzEqualityComparer();

        public bool Equals(Vector3 other)
        {
            return XyzComparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3 && Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        private sealed class XyzEqualityComparer : IEqualityComparer<Vector3>
        {
            public bool Equals(Vector3 x, Vector3 y)
            {
                return x.X.Equals(y.X) && x.Y.Equals(y.Y) && x.Z.Equals(y.Z);
            }

            public int GetHashCode(Vector3 obj)
            {
                unchecked
                {
                    int hashCode = obj.X.GetHashCode();
                    hashCode = (hashCode*397) ^ obj.Y.GetHashCode();
                    hashCode = (hashCode*397) ^ obj.Z.GetHashCode();
                    return hashCode;
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return $"[{X:0.####}, {Y:0.####}, {Z:0.####}]";
        }
    }
#endif
}