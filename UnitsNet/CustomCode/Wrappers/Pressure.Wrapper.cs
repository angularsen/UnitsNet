// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet.CustomCode.Units;
using UnitsNet.Units;

namespace UnitsNet.CustomCode.Wrappers
{
    /// <summary>
    ///     Pressure tied to a real-world reference, allowing conversion between references.
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Absolute is referenced to true vacuum.</description>
    ///         </item>
    ///         <item>
    ///             <description>Gauge references the local atmospheric pressure.</description>
    ///         </item>
    ///         <item>
    ///             <description>Vacuum is the negative of the gauge.</description>
    ///         </item>
    ///     </list>
    /// </summary>
    public struct ReferencePressure
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring measured
        ///     <see cref="Pressure" />
        ///     parameter. Assumes the <see cref="PressureReference" /> to <see cref="PressureReference.Absolute" />, with 1 atm as
        ///     the atmospheric <see cref="Pressure" />.
        /// </summary>
        /// <param name="pressure">The measured absolute <see cref="Pressure" /></param>
        public ReferencePressure(Pressure pressure) : this(pressure, BaseReference)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring
        ///     measured <see cref="Pressure" /> and <see cref="PressureReference" /> parameters. Assumes 1 atm as the atmospheric
        ///     <see cref="Pressure" />.
        /// </summary>
        /// <param name="pressure">The measured <see cref="Pressure" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="PressureReference" /> for the measured <see cref="Pressure" />
        /// </param>
        public ReferencePressure(Pressure pressure, PressureReference reference) : this(pressure, reference, _defaultAtmosphericPressure)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring
        ///     measured <see cref="Pressure" />, <see cref="PressureReference" />, and atmospheric <see cref="Pressure" />
        ///     parameters
        /// </summary>
        /// <param name="pressure">The measured <see cref="Pressure" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="PressureReference" /> for the measured <see cref="Pressure" />
        /// </param>
        /// <param name="atmosphericPressure">The atmospheric <see cref="Pressure" /> where the measurement was taken.</param>
        public ReferencePressure(Pressure pressure, PressureReference reference, Pressure atmosphericPressure)
        {
            Reference = reference;
            _pressure = pressure;
            AtmosphericPressure = atmosphericPressure;
        }

        /// <summary>
        ///     Gets the <see cref="PressureReference" /> of the <see cref="ReferencePressure" />
        /// </summary>
        public PressureReference Reference { get; }

        /// <summary>
        ///     Gets a list of <see cref="PressureReference" /> options: <see cref="PressureReference.Gauge" />,
        ///     <see cref="PressureReference.Absolute" />, and <see cref="PressureReference.Vacuum" />
        /// </summary>
        public static List<PressureReference> References { get; } =
            Enum.GetValues(typeof(PressureReference)).Cast<PressureReference>().Except(new[] {PressureReference.Undefined}).ToList();

        /// <summary>
        ///     The base reference representation of <see cref="ReferencePressure" /> for the numeric value stored internally. All
        ///     conversions go via
        ///     this value.
        /// </summary>
        public const PressureReference BaseReference = PressureReference.Absolute;

        private readonly Pressure _pressure;

        /// <summary>
        ///     Get Gauge <see cref="Pressure" />.
        ///     It refers pressure level above Reference pressure.
        /// </summary>
        public Pressure Gauge => As(PressureReference.Gauge);

        /// <summary>
        ///     Get Absolute <see cref="Pressure" />.
        ///     It is zero-referenced pressure to the perfect vacuum.
        /// </summary>
        public Pressure Absolute => As(PressureReference.Absolute);

        /// <summary>
        ///     Get Vacuum <see cref="Pressure" />.
        ///     It is a negative Gauge pressure when Absolute pressure is below Reference pressure.
        /// </summary>
        public Pressure Vacuum => As(PressureReference.Vacuum);

        /// <summary>
        ///     Converts <see cref="ReferencePressure" /> to <see cref="Pressure" /> at <see cref="PressureReference" />
        /// </summary>
        /// <param name="reference">The <see cref="PressureReference" /> to convert <see cref="ReferencePressure" /> to.</param>
        /// <returns>The <see cref="Pressure" /> at the specified <see cref="PressureReference" /></returns>
        private Pressure As(PressureReference reference)
        {
            var converted = AsBaseNumericType(reference);

            return new Pressure(converted, _pressure.Unit);
        }

        /// <summary>
        ///     Converts <see cref="Pressure.Value" /> to <see cref="double" /> at <see cref="PressureReference" />
        /// </summary>
        /// <param name="reference">The <see cref="PressureReference" /> to convert <see cref="ReferencePressure" /> to.</param>
        /// <returns>The value of pressure at <see cref="PressureReference" /></returns>
        private double AsBaseNumericType(PressureReference reference)
        {
            var baseReferenceValue = AsBaseReference();

            if (Reference == reference)
            {
                return _pressure.Value;
            }

            var negatingValue = Reference == PressureReference.Vacuum ? -1 : 1;

            switch (reference)
            {
                case PressureReference.Absolute: return baseReferenceValue;
                case PressureReference.Gauge: return baseReferenceValue - AtmosphericPressure.ToUnit(_pressure.Unit).Value;
                case PressureReference.Vacuum: return AtmosphericPressure.ToUnit(_pressure.Unit).Value - negatingValue * baseReferenceValue;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to {reference}.");
            }
        }

        /// <summary>
        ///     Converts <see cref="Pressure.Value" /> at <see cref="Reference" /> to <see cref="double" /> at
        ///     <see cref="BaseReference" />
        /// </summary>
        /// <returns>The value of pressure at the <see cref="BaseReference" /></returns>
        private double AsBaseReference()
        {
            switch (Reference)
            {
                case PressureReference.Absolute:
                {
                    if (_pressure.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return _pressure.Value;
                }
                case PressureReference.Gauge:
                {
                    if (_pressure.Value * -1 > AtmosphericPressure.ToUnit(_pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return AtmosphericPressure.ToUnit(_pressure.Unit).Value + _pressure.Value;
                }
                case PressureReference.Vacuum:
                {
                    if (_pressure.Value > AtmosphericPressure.ToUnit(_pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return AtmosphericPressure.ToUnit(_pressure.Unit).Value - _pressure.Value;
                }
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to base reference.");
            }
        }

        /// <summary>
        ///     Represents the pressure at which _pressure is referenced (1 atm default)
        /// </summary>
        public static Pressure AtmosphericPressure { get; set; }

        private static readonly Pressure _defaultAtmosphericPressure = new Pressure(1, PressureUnit.Atmosphere);
    }
}
