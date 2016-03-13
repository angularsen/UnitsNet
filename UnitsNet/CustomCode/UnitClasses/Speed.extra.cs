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

// Operator overloads not supported in Universal Windows Platform (WinRT Components)
#if !WINDOWS_UWP
using System;

namespace UnitsNet
{
    public partial struct Speed
    {
        public static Acceleration operator /(Speed speed, TimeSpan timeSpan)
        {
            return Acceleration.FromMeterPerSecondSquared(speed.MetersPerSecond/timeSpan.TotalSeconds);
        }

        public static Length operator *(Speed speed, TimeSpan timeSpan)
        {
            return Length.FromMeters(speed.MetersPerSecond*timeSpan.TotalSeconds);
        }

        public static Length operator *(TimeSpan timeSpan, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond*timeSpan.TotalSeconds);
        }

        public static Acceleration operator /(Speed speed, Duration duration)
        {
            return Acceleration.FromMeterPerSecondSquared(speed.MetersPerSecond/duration.Seconds);
        }

        public static Length operator *(Speed speed, Duration duration)
        {
            return Length.FromMeters(speed.MetersPerSecond*duration.Seconds);
        }

        public static Length operator *(Duration duration, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond*duration.Seconds);
        }

        public static KinematicViscosity operator *(Speed speed, Length length)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters * speed.MetersPerSecond);
        }

        public static SpecificEnergy operator *(Speed left, Speed right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.MetersPerSecond * right.MetersPerSecond);
        }
    }
}
#endif
