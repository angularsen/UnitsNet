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
    public struct Vector2
    {
        public double X;
        public double Y;
    }
#else
    public struct Vector2 : IEquatable<Vector2>
    {
        public readonly double X;
        public readonly double Y;

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(double xy) : this()
        {
            X = xy;
            Y = xy;
        }

#region Equality

        private static IEqualityComparer<Vector2> XyComparer { get; } = new XyEqualityComparer();

        public bool Equals(Vector2 other)
        {
            return XyComparer.Equals(this, other);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !XyComparer.Equals(left, right);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return XyComparer.Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector2 && Equals((Vector2) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        private sealed class XyEqualityComparer : IEqualityComparer<Vector2>
        {
            public bool Equals(Vector2 x, Vector2 y)
            {
                return x.X.Equals(y.X) && x.Y.Equals(y.Y);
            }

            public int GetHashCode(Vector2 obj)
            {
                unchecked
                {
                    return (obj.X.GetHashCode()*397) ^ obj.Y.GetHashCode();
                }
            }
        }

#endregion

        public override string ToString()
        {
            return $"[{X:0.####}, {Y:0.####}]";
        }
    }
#endif
}