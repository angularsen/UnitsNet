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
        ///     Represents the pressure at which _pressure is referenced (1 atm default)
        /// </summary>
        public Pressure AtmosphericPressure { get; set; }

        private static readonly Pressure DefaultAtmosphericPressure = new Pressure(1, PressureUnit.Atmosphere);

        /// <summary>
        ///     Gets a list of <see cref="PressureReference" /> options: <see cref="PressureReference.Gauge" />,
        ///     <see cref="PressureReference.Absolute" />, and <see cref="PressureReference.Vacuum" />
        /// </summary>
        public static PressureReference[] References { get; } =
            Enum.GetValues(typeof(PressureReference)).Cast<PressureReference>().Except(new[] {PressureReference.Undefined}).ToArray();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring measured
        ///     <see cref="UnitsNet.Pressure" />
        ///     parameter. Assumes the <see cref="PressureReference" /> to <see cref="PressureReference.Absolute" />, with 1 atm as
        ///     the atmospheric <see cref="UnitsNet.Pressure" />.
        /// </summary>
        /// <param name="pressure">The measured absolute <see cref="UnitsNet.Pressure" /></param>
        public ReferencePressure(Pressure pressure) : this(pressure, BaseReference)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring
        ///     measured <see cref="UnitsNet.Pressure" /> and <see cref="PressureReference" /> parameters. Assumes 1 atm as the atmospheric
        ///     <see cref="UnitsNet.Pressure" />.
        /// </summary>
        /// <param name="pressure">The measured <see cref="UnitsNet.Pressure" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="PressureReference" /> for the measured <see cref="UnitsNet.Pressure" />
        /// </param>
        public ReferencePressure(Pressure pressure, PressureReference reference) : this(pressure, reference, DefaultAtmosphericPressure)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReferencePressure" /> struct requiring
        ///     measured <see cref="UnitsNet.Pressure" />, <see cref="PressureReference" />, and atmospheric <see cref="UnitsNet.Pressure" />
        ///     parameters
        /// </summary>
        /// <param name="pressure">The measured <see cref="UnitsNet.Pressure" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="PressureReference" /> for the measured <see cref="UnitsNet.Pressure" />
        /// </param>
        /// <param name="atmosphericPressure">The atmospheric <see cref="UnitsNet.Pressure" /> where the measurement was taken.</param>
        public ReferencePressure(Pressure pressure, PressureReference reference, Pressure atmosphericPressure)
        {
            Reference = reference;
            Pressure = pressure;
            AtmosphericPressure = atmosphericPressure;
        }

        /// <summary>
        ///     Gets the <see cref="PressureReference" /> of the <see cref="ReferencePressure" />
        /// </summary>
        public PressureReference Reference { get; }

        /// <summary>
        ///     The base reference representation of <see cref="ReferencePressure" /> for the numeric value stored internally. All
        ///     conversions go via this value.
        /// </summary>
        public const PressureReference BaseReference = PressureReference.Absolute;

        /// <summary>
        /// The <see cref="Pressure"/> at the given <see cref="PressureReference"/>.
        /// </summary>
        public Pressure Pressure { get; }

        /// <summary>
        ///     Get Gauge <see cref="UnitsNet.Pressure" />.
        ///     It references pressure level above Atmospheric pressure.
        /// </summary>
        public Pressure Gauge => As(PressureReference.Gauge);

        /// <summary>
        ///     Get Absolute <see cref="UnitsNet.Pressure" />.
        ///     It is zero-referenced pressure to the perfect vacuum.
        /// </summary>
        public Pressure Absolute => As(PressureReference.Absolute);

        /// <summary>
        ///     Get Vacuum <see cref="UnitsNet.Pressure" />.
        ///     It is a negative Gauge pressure when Absolute pressure is below Atmospheric pressure.
        /// </summary>
        public Pressure Vacuum => As(PressureReference.Vacuum);

        /// <summary>
        ///     Converts <see cref="ReferencePressure" /> to <see cref="UnitsNet.Pressure" /> at <see cref="PressureReference" />
        /// </summary>
        /// <param name="reference">The <see cref="PressureReference" /> to convert <see cref="ReferencePressure" /> to.</param>
        /// <returns>The <see cref="UnitsNet.Pressure" /> at the specified <see cref="PressureReference" /></returns>
        private Pressure As(PressureReference reference)
        {
            var converted = AsBaseNumericType(reference);

            return new Pressure(converted, Pressure.Unit);
        }

        /// <summary>
        ///     Converts <see cref="UnitsNet.Pressure.Value" /> to <see cref="double" /> at <see cref="PressureReference" />
        /// </summary>
        /// <param name="reference">The <see cref="PressureReference" /> to convert <see cref="ReferencePressure" /> to.</param>
        /// <returns>The value of pressure at <see cref="PressureReference" /></returns>
        private double AsBaseNumericType(PressureReference reference)
        {
            var baseReferenceValue = AsBaseReference();

            if (Reference == reference)
            {
                return Pressure.Value;
            }

            var negatingValue = Reference == PressureReference.Vacuum ? -1 : 1;

            switch (reference)
            {
                case PressureReference.Absolute: return baseReferenceValue;
                case PressureReference.Gauge: return baseReferenceValue - AtmosphericPressure.ToUnit(Pressure.Unit).Value;
                case PressureReference.Vacuum: return AtmosphericPressure.ToUnit(Pressure.Unit).Value - negatingValue * baseReferenceValue;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to {reference}.");
            }
        }

        /// <summary>
        ///     Converts <see cref="UnitsNet.Pressure.Value" /> at <see cref="Reference" /> to <see cref="double" /> at
        ///     <see cref="BaseReference" />
        /// </summary>
        /// <returns>The value of pressure at the <see cref="BaseReference" /></returns>
        private double AsBaseReference()
        {
            switch (Reference)
            {
                case PressureReference.Absolute:
                {
                    if (Pressure.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return Pressure.Value;
                }
                case PressureReference.Gauge:
                {
                    if (Pressure.Value * -1 > AtmosphericPressure.ToUnit(Pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return AtmosphericPressure.ToUnit(Pressure.Unit).Value + Pressure.Value;
                }
                case PressureReference.Vacuum:
                {
                    if (Pressure.Value > AtmosphericPressure.ToUnit(Pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return AtmosphericPressure.ToUnit(Pressure.Unit).Value - Pressure.Value;
                }
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to base reference.");
            }
        }
    }
}
