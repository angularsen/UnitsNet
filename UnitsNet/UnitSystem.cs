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
using UnitsNet.Units;

namespace UnitsNet
{
#if !WINDOWS_UWP
    public sealed partial class UnitSystem : IEquatable<UnitSystem> { }
#endif

    public sealed partial class UnitSystem
    {
        /// <summary>
        /// Creates an instance of a unit system with the specified base units.
        /// </summary>
        /// <param name="baseUnits">The base units for the unit system.</param>
        public UnitSystem(BaseUnits baseUnits)
        {
            if(baseUnits is null)
                throw new ArgumentNullException(nameof(baseUnits));

            if(baseUnits.Length == LengthUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Mass == MassUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Time == DurationUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Current == ElectricCurrentUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Temperature == TemperatureUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Amount == AmountOfSubstanceUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.LuminousIntensity == LuminousIntensityUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));

            BaseUnits = baseUnits;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is UnitSystem))
                return false;

            return Equals((UnitSystem)obj);
        }

#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
#endif
        public bool Equals(UnitSystem other)
        {
            if(other is null)
                return false;

            return BaseUnits.Equals(other.BaseUnits);
        }

#if !WINDOWS_UWP

        /// <summary>
        /// Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(UnitSystem)"/>
        public static bool operator ==(UnitSystem left, UnitSystem right)
        {
            return left is null ? right is null : left.Equals(right);
        }

        /// <summary>
        /// Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(UnitSystem)"/>
        public static bool operator !=(UnitSystem left, UnitSystem right)
        {
            return !(left == right);
        }

#endif

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {BaseUnits}.GetHashCode();
        }

        public BaseUnits BaseUnits{ get; }

        private static readonly BaseUnits SIBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
            ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        /// <summary>
        /// Gets the SI unit system.
        /// </summary>
        public static UnitSystem SI{ get; } = new UnitSystem(SIBaseUnits);
    }
}
