// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using System.Text;

namespace UnitsNet
{
    /// <summary>
    ///     Represents the base dimensions of a quantity.
    /// </summary>
    public sealed class BaseDimensions : IEquatable<BaseDimensions>
    {
        private readonly int
            _length,             // L
            _mass,               // M
            _time,               // T
            _current,            // I
            _temperature,        // Θ
            _amount,             // N
            _luminousIntensity;  // J

        public BaseDimensions(int length, int mass, int time, int current, int temperature, int amount, int luminousIntensity)
        {
            _length = length;
            _mass = mass;
            _time = time;
            _current = current;
            _temperature = temperature;
            _amount = amount;
            _luminousIntensity = luminousIntensity;
        }

        public override bool Equals(object obj)
        {
            return obj is BaseDimensions && Equals((BaseDimensions)obj);
        }

        public bool Equals(BaseDimensions other)
        {
            return Length == other.Length &&
                Mass == other.Mass &&
                Time == other.Time &&
                Current == other.Current &&
                Temperature == other.Temperature &&
                Amount == other.Amount &&
                LuminousIntensity == other.LuminousIntensity;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Length;
            hash = hash * 23 + Mass;
            hash = hash * 23 + Time;
            hash = hash * 23 + Current;
            hash = hash * 23 + Temperature;
            hash = hash * 23 + Amount;
            hash = hash * 23 + LuminousIntensity;
            return hash;
        }

        public BaseDimensions Multiply(BaseDimensions right)
        {
            return new BaseDimensions(
                Length + right.Length,
                Mass + right.Mass,
                Time + right.Time,
                Current + right.Current,
                Temperature + right.Temperature,
                Amount + right.Amount,
                LuminousIntensity + right.LuminousIntensity);
        }

        public BaseDimensions Divide(BaseDimensions right)
        {
            return new BaseDimensions(
                Length - right.Length,
                Mass - right.Mass,
                Time - right.Time,
                Current - right.Current,
                Temperature - right.Temperature,
                Amount - right.Amount,
                LuminousIntensity - right.LuminousIntensity);
        }

#if !WINDOWS_UWP
        public static bool operator ==(BaseDimensions left, BaseDimensions right)
        {
            return left.Equals(right);
        }
    
        public static bool operator !=(BaseDimensions left, BaseDimensions right)
        {
            return !( left == right );
        }

        public static BaseDimensions operator *(BaseDimensions left, BaseDimensions right)
        {
            return left.Multiply(right);
        }

        public static BaseDimensions operator /(BaseDimensions left, BaseDimensions right)
        {
            return left.Divide(right);
        }
#endif

        public override string ToString()
        {
            var sb = new StringBuilder();

            AppendDimensionString(sb, "Length", Length);
            AppendDimensionString(sb, "Mass", Mass);
            AppendDimensionString(sb, "Time", Time);
            AppendDimensionString(sb, "Current", Current);
            AppendDimensionString(sb, "Temperature", Temperature);
            AppendDimensionString(sb, "Amount", Amount);
            AppendDimensionString(sb, "LuminousIntensity", LuminousIntensity);

            return sb.ToString();
        }

        private static void AppendDimensionString( StringBuilder sb, string name, int value )
        {
            var absoluteValue = Math.Abs( value );

            if( absoluteValue > 0 )
            {
                sb.AppendFormat( "[{0}]", name );

                if( absoluteValue > 1 )
                    sb.AppendFormat( "^{0}", value );
            }
        }

        public int Length { get { return _length; } }

        public int Mass{ get{ return _mass; } }

        public int Time{ get{ return _time; } }

        public int Current{ get{ return _current; } }

        public int Temperature{ get{ return _temperature; } }

        public int Amount{ get{ return _amount; } }

        public int LuminousIntensity{ get{ return _luminousIntensity; } }
    }
}
