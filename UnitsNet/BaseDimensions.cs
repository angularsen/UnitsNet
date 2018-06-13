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

namespace UnitsNet
{
    /// <summary>
    ///     Represents the base dimensions of a quantity.
    /// </summary>
    public struct BaseDimensions
    {
        public readonly int
            Length,             // L
            Mass,               // M
            Time,               // T
            Current,            // I
            Temperature,        // Θ
            Amount,             // N
            LuminousIntensity;  // J

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

        public override bool Equals( object obj )
        {
            return obj is BaseDimensions && this == (BaseDimensions)obj;
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

        public static bool operator ==(BaseDimensions left, BaseDimensions right)
        {
            return left.Length == right.Length &&
                left.Mass == right.Mass &&
                left.Time == right.Time &&
                left.Current == right.Current &&
                left.Temperature == right.Temperature &&
                left.Amount == right.Amount &&
                left.LuminousIntensity == right.LuminousIntensity;
        }

        public static bool operator !=(BaseDimensions left, BaseDimensions right)
        {
            return !( left == right );
        }

        public static BaseDimensions operator *(BaseDimensions left, BaseDimensions right)
        {
            return new BaseDimensions(
                left.Length + right.Length,
                left.Mass + right.Mass,
                left.Time + right.Time,
                left.Current + right.Current,
                left.Temperature + right.Temperature,
                left.Amount + right.Amount,
                left.LuminousIntensity + right.LuminousIntensity );
        }

        public static BaseDimensions operator /(BaseDimensions left, BaseDimensions right)
        {
            return new BaseDimensions(
                left.Length - right.Length,
                left.Mass - right.Mass,
                left.Time - right.Time,
                left.Current - right.Current,
                left.Temperature - right.Temperature,
                left.Amount - right.Amount,
                left.LuminousIntensity - right.LuminousIntensity );
        }
    }
}
