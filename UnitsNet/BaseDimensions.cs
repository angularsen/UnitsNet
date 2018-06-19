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
    public sealed class BaseDimensions
    {
        public BaseDimensions(int length, int mass, int time, int current, int temperature, int amount, int luminousIntensity)
        {
            Length = length;
            Mass = mass;
            Time = time;
            Current = current;
            Temperature = temperature;
            Amount = amount;
            LuminousIntensity = luminousIntensity;
        }

        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is BaseDimensions))
                return false;

            var baseDimensionsObj = (BaseDimensions)obj;

            return Length == baseDimensionsObj.Length &&
                Mass == baseDimensionsObj.Mass &&
                Time == baseDimensionsObj.Time &&
                Current == baseDimensionsObj.Current &&
                Temperature == baseDimensionsObj.Temperature &&
                Amount == baseDimensionsObj.Amount &&
                LuminousIntensity == baseDimensionsObj.LuminousIntensity;
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

        /// <summary>
        /// Gets the length dimensions (L).
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Gets the mass dimensions (M).
        /// </summary>
        public int Mass{ get; }

        /// <summary>
        /// Gets the time dimensions (T).
        /// </summary>
        public int Time{ get; }

        /// <summary>
        /// Gets the electric current dimensions (I).
        /// </summary>
        public int Current{ get; }

        /// <summary>
        /// Gets the temperature dimensions (Θ).
        /// </summary>
        public int Temperature{ get; }

        /// <summary>
        /// Gets the amount of substance dimensions (N).
        /// </summary>
        public int Amount{ get; }

        /// <summary>
        /// Gets the luminous intensity dimensions (J).
        /// </summary>
        public int LuminousIntensity{ get; }
    }
}
