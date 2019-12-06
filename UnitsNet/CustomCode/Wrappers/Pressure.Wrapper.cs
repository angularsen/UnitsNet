using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet.Units;
using UnitsNet.CustomCode.Units;

namespace UnitsNet.CustomCode.Wrappers
{
    /// <summary>
    /// From gratestas in #422
    /// Pressure is a state function, for its measurement depends on environmental factors such as ambient pressure, elevation above sea level and local weather conditions. For two persons located in the different environment to speak of the same pressure, one must relate it to a reference. There are three basis reference: absolute, gauge, vacuum
    ///    Absolute is zero-referenced to the total vacuum.
    ///    Gauge refers to a level of the local atmospheric pressure.
    ///    Vacuum is the negative of the gauge.
    ///Therefore, to obtain consistent and qualitative data, the reference measurement is crucial.
    /// </summary>
    public struct ReferencePressure
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pressure"></param>
        /// <param name="reference"></param>
        public ReferencePressure(Pressure pressure, PressureReference reference)
        {
            _reference = reference;
            Pressure = pressure;
        }

        /// <summary>
        /// ctor using BaseReference of absolute to assign default _reference
        /// </summary>
        /// <param name="pressure"></param>
        public ReferencePressure(Pressure pressure)
        {
            _reference = BaseReference;
            Pressure = pressure;
        }

        /// <summary>
        ///     The public repersentation of the measured reference this quantity was constructed with.
        /// </summary>
        public PressureReference Reference => _reference.GetValueOrDefault(BaseReference);

        /// <summary>
        ///     The measured reference this quantity was constructed with.
        /// </summary>
        private readonly PressureReference? _reference;

        /// <summary>
        /// List property of reference options: Gauge, Absolute, and Vacuum
        /// </summary>
        public static List<PressureReference> References { get; } = Enum.GetValues(typeof(PressureReference)).Cast<PressureReference>().Except(new[] { PressureReference.Undefined }).ToList();

        /// <summary>
        ///     The base reference representation of this quantity for the numeric value stored internally. All conversions go via this value.
        /// </summary>
        public static PressureReference BaseReference { get; } = PressureReference.Absolute;

        private Pressure Pressure { get; }

        /// <summary>
        ///     Get Gauge Pressure.
        ///     It refers pressure level above Reference Pressure.
        /// </summary>
        public Pressure Gauge => As(PressureReference.Gauge);

        /// <summary>
        ///     Get Absolute Pressure.
        ///     It is zero-referenced pressure to the perfect vacuum.
        /// </summary>
        public Pressure Absolute => As(PressureReference.Absolute);

        /// <summary>
        ///     Get Vacuum Pressure.
        ///     It is a negative Gauge Pressure when Absolute Pressure is below Reference Pressure.
        /// </summary>
        public Pressure Vacuum => As(PressureReference.Vacuum);


        private Pressure As(PressureReference reference)
        {
            var converted = AsBaseNumericType(reference);

            return new Pressure(converted, Pressure.Unit);
        }

        private double AsBaseNumericType(PressureReference reference)
        {
            var baseReferenceValue = AsBaseReference();

            if (Reference == reference)
                return Pressure.Value;

            var negatingValue = Reference == PressureReference.Vacuum ? -1 : 1;

            switch (reference)
            {
                case PressureReference.Absolute: return baseReferenceValue;
                case PressureReference.Gauge: return baseReferenceValue - ReferencedPressure.ToUnit(Pressure.Unit).Value;
                case PressureReference.Vacuum: return ReferencedPressure.ToUnit(Pressure.Unit).Value - negatingValue * baseReferenceValue;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to {reference}.");
            }
        }

        private double AsBaseReference()
        {
            switch (Reference)
            {
                case PressureReference.Absolute:
                    if (Pressure.Value < 0) throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    else return Pressure.Value;
                case PressureReference.Gauge:
                    if (Pressure.Value * -1 > ReferencedPressure.ToUnit(Pressure.Unit).Value) throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    else return ReferencedPressure.ToUnit(Pressure.Unit).Value + Pressure.Value;
                case PressureReference.Vacuum:
                    if (Pressure.Value > ReferencedPressure.ToUnit(Pressure.Unit).Value) throw new ArgumentOutOfRangeException("Absolute pressure cannot be less than zero.");
                    else return ReferencedPressure.ToUnit(Pressure.Unit).Value - Pressure.Value;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to base reference.");
            }
        }
        /// <summary>
        /// Represents the pressure at which Pressure is referenced (1 atm default)
        /// </summary>
        public static Pressure ReferencedPressure { get; } = new Pressure(1, PressureUnit.Atmosphere);
    }
}
