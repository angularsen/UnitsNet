using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet.CustomCode.Units;
using UnitsNet.Units;

namespace UnitsNet.CustomCode.Wrappers
{
    /// <summary>
    ///     _pressure tied to a real-world reference, allowing conversion between references.
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
        /// </summary>
        /// <param name="pressure"></param>
        /// <param name="reference"></param>
        public ReferencePressure(Pressure pressure, PressureReference reference)
        {
            Reference = reference;
            _pressure = pressure;
        }

        /// <summary>
        ///     ctor using BaseReference of absolute to assign default _reference
        /// </summary>
        /// <param name="pressure"></param>
        public ReferencePressure(Pressure pressure)
        {
            Reference = BaseReference;
            _pressure = pressure;
        }

        /// <summary>
        ///     The public representation of the measured reference this quantity was constructed with.
        /// </summary>
        public PressureReference Reference { get; }

        /// <summary>
        ///     List property of reference options: Gauge, Absolute, and Vacuum
        /// </summary>
        public static List<PressureReference> References { get; } =
            Enum.GetValues(typeof(PressureReference)).Cast<PressureReference>().Except(new[] {PressureReference.Undefined}).ToList();

        /// <summary>
        ///     The base reference representation of this quantity for the numeric value stored internally. All conversions go via
        ///     this value.
        /// </summary>
        public const PressureReference BaseReference = PressureReference.Absolute;

        private readonly Pressure _pressure;

        /// <summary>
        ///     Get Gauge Pressure.
        ///     It refers pressure level above Reference _pressure.
        /// </summary>
        public Pressure Gauge => As(PressureReference.Gauge);

        /// <summary>
        ///     Get Absolute Pressure.
        ///     It is zero-referenced pressure to the perfect vacuum.
        /// </summary>
        public Pressure Absolute => As(PressureReference.Absolute);

        /// <summary>
        ///     Get Vacuum Pressure.
        ///     It is a negative Gauge _pressure when Absolute _pressure is below Reference _pressure.
        /// </summary>
        public Pressure Vacuum => As(PressureReference.Vacuum);


        private Pressure As(PressureReference reference)
        {
            var converted = AsBaseNumericType(reference);

            return new Pressure(converted, _pressure.Unit);
        }

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
                case PressureReference.Gauge: return baseReferenceValue - ReferencedPressure.ToUnit(_pressure.Unit).Value;
                case PressureReference.Vacuum: return ReferencedPressure.ToUnit(_pressure.Unit).Value - negatingValue * baseReferenceValue;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to {reference}.");
            }
        }

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
                    if (_pressure.Value * -1 > ReferencedPressure.ToUnit(_pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return ReferencedPressure.ToUnit(_pressure.Unit).Value + _pressure.Value;
                }
                case PressureReference.Vacuum:
                {
                    if (_pressure.Value > ReferencedPressure.ToUnit(_pressure.Unit).Value)
                    {
                        throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    }

                    return ReferencedPressure.ToUnit(_pressure.Unit).Value - _pressure.Value;
                }
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to base reference.");
            }
        }

        /// <summary>
        ///     Represents the pressure at which _pressure is referenced (1 atm default)
        /// </summary>
        public static Pressure ReferencedPressure { get; } = new Pressure(1, PressureUnit.Atmosphere);
    }
}
