// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;

using UnitsNet.CustomCode.Units;
using UnitsNet.Units;

namespace UnitsNet.Wrappers
{
    /// <summary>
    ///     The fundamental difference between alternating current (AC) and direct current (DC) is the direction of flow over time.
    ///     “A simple way to visualize the difference is that, when graphed, a DC current looks like a flat line, whereas the flow of AC on a graph makes a sinusoid or wave-like pattern.”
    ///     - Karl K. Berggren, professor of electrical engineering at MIT
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Alternating current changes over time in an oscillating repetition — the up curve indicates the current flowing in a positive direction and the down curve signifies the alternate cycle where the current moves in a negative direction. This back and forth is what gives AC its name.</description>
    ///         </item>
    ///         <item>
    ///             <description>Direct current is constant and moves in one direction.</description>
    ///         </item>
    ///     </list>
    /// </summary>
    /// <remarks>
    ///     <a href="https://engineering.mit.edu/engage/ask-an-engineer/whats-the-difference-between-ac-and-dc/">MIT School of Engineering | What’s the difference between AC and DC?</a>
    /// </remarks>
    public struct ElectricCurrentFlow
    {
        /// <summary>
        ///     Represents the frequency at which _current is referenced (0 Hz default)
        /// </summary>
        public Frequency Frequency { get; set; }

        private static readonly Frequency DefaultFrequency = Frequency.Zero;

        /// <summary>
        ///     Gets a list of <see cref="ElectricCurrentFlowReference" /> options: <see cref="ElectricCurrentFlowReference.DirectOrRms" />,
        ///     <see cref="ElectricCurrentFlowReference.AlternatingPeak" />, and <see cref="ElectricCurrentFlowReference.AlternatingPeakToPeak" />
        /// </summary>
        public static ElectricCurrentFlowReference[] Directions { get; } =
            Enum.GetValues(typeof(ElectricCurrentFlowReference)).Cast<ElectricCurrentFlowReference>().ToArray();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ElectricCurrentFlow" /> struct requiring measured
        ///     <see cref="UnitsNet.ElectricCurrent" />
        ///     parameter. Assumes the <see cref="ElectricCurrentFlowReference" /> to <see cref="ElectricCurrentFlowReference.DirectOrRms" />, with 0 Hz as
        ///     the <see cref="UnitsNet.Frequency" />.
        /// </summary>
        /// <param name="current">The measured absolute <see cref="UnitsNet.Pressure" /></param>
        public ElectricCurrentFlow(ElectricCurrent current) : this(current, BaseReference)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ElectricCurrentFlow" /> struct requiring
        ///     measured <see cref="UnitsNet.ElectricCurrent" /> and <see cref="ElectricCurrentFlowReference" /> parameters. Assumes 0 Hz as the
        ///     <see cref="UnitsNet.Frequency" />.
        /// </summary>
        /// <param name="current">The measured <see cref="UnitsNet.ElectricCurrent" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="ElectricCurrentFlowReference" /> for the measured <see cref="UnitsNet.ElectricCurrent" />
        /// </param>
        public ElectricCurrentFlow(ElectricCurrent current, ElectricCurrentFlowReference reference) : this(current, reference, DefaultFrequency)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ElectricCurrentFlow" /> struct requiring
        ///     measured <see cref="UnitsNet.ElectricCurrent" />, <see cref="ElectricCurrentFlowReference" />, and <see cref="UnitsNet.Frequency" />
        ///     parameters
        /// </summary>
        /// <param name="current">The measured <see cref="UnitsNet.ElectricCurrent" /></param>
        /// <param name="reference">
        ///     The referenced <see cref="ElectricCurrentFlowReference" /> for the measured <see cref="UnitsNet.ElectricCurrent" />
        /// </param>
        /// <param name="frequency">The <see cref="UnitsNet.Frequency" /> of the measurement taken.</param>
        public ElectricCurrentFlow(ElectricCurrent current, ElectricCurrentFlowReference reference, Frequency frequency)
        {
            Current = current;
            Reference = reference;
            Frequency = frequency;
        }

        /// <summary>
        ///     Gets the <see cref="ElectricCurrentFlowReference" /> of the <see cref="ElectricCurrentFlow" />
        /// </summary>
        public ElectricCurrentFlowReference Reference { get; }

        /// <summary>
        ///     The base reference representation of <see cref="ElectricCurrentFlow" /> for the numeric value stored internally. All
        ///     conversions go via this value.
        /// </summary>
        public const ElectricCurrentFlowReference BaseReference = ElectricCurrentFlowReference.DirectOrRms;

        /// <summary>
        /// The <see cref="ElectricCurrent"/> at the given <see cref="ElectricCurrentFlowReference"/>.
        /// </summary>
        /// <remarks>
        /// If the waveform is a pure sine wave, the relationships between amplitudes (peak-to-peak, peak) and RMS are fixed and known, as they are for any continuous periodic wave.
        /// </remarks>
        public ElectricCurrent Current { get; }

        /// <summary>
        ///     Get Direct or RMS <see cref="UnitsNet.ElectricCurrent" />.
        ///     For alternating electric current, RMS is equal to the value of the constant direct current that would produce the same power dissipation in a resistive load.
        /// </summary>
        public ElectricCurrent DirectOrRms => As(ElectricCurrentFlowReference.DirectOrRms);

        /// <summary>
        ///     Get Alternating Peak <see cref="UnitsNet.ElectricCurrent" />.
        ///     It is zero-referenced pressure to the perfect vacuum.
        /// </summary>
        public ElectricCurrent AlternatingPeak => As(ElectricCurrentFlowReference.AlternatingPeak);

        /// <summary>
        ///     Get Alternating Peak To Peak <see cref="UnitsNet.ElectricCurrent" />.
        ///     It is a negative Gauge pressure when Absolute pressure is below Atmospheric pressure.
        /// </summary>
        public ElectricCurrent AlternatingPeakToPeak => As(ElectricCurrentFlowReference.AlternatingPeakToPeak);

        /// <summary>
        ///     Converts <see cref="ElectricCurrentFlow" /> to <see cref="UnitsNet.ElectricCurrent" /> at <see cref="ElectricCurrentFlowReference" />
        /// </summary>
        /// <param name="reference">The <see cref="ElectricCurrentFlowReference" /> to convert <see cref="ElectricCurrentFlow" /> to.</param>
        /// <returns>The <see cref="UnitsNet.ElectricCurrent" /> at the specified <see cref="ElectricCurrentFlowReference" /></returns>
        private ElectricCurrent As(ElectricCurrentFlowReference reference)
        {
            var converted = AsBaseNumericType(reference);

            return new ElectricCurrent(converted, Current.Unit);
        }

        /// <summary>
        ///     Converts <see cref="UnitsNet.Pressure.Value" /> to <see cref="double" /> at <see cref="ElectricCurrentFlowReference" />
        /// </summary>
        /// <param name="reference">The <see cref="ElectricCurrentFlowReference" /> to convert <see cref="ElectricCurrentFlow" /> to.</param>
        /// <returns>The value of pressure at <see cref="ElectricCurrentFlowReference" /></returns>
        private double AsBaseNumericType(ElectricCurrentFlowReference reference)
        {
            var baseReferenceValue = AsBaseReference();

            if (Reference == reference)
            {
                return Current.Value;
            }

            switch (reference)
            {
                case ElectricCurrentFlowReference.DirectOrRms: return baseReferenceValue;
                //   Vp = Vrms * sqrt(2)
                case ElectricCurrentFlowReference.AlternatingPeak: return baseReferenceValue * 1.4142135623730950488016887242097;
                // Vp-p = Vrms * (2 * sqrt(2))
                case ElectricCurrentFlowReference.AlternatingPeakToPeak: return baseReferenceValue * 2.8284271247461900976033774484194;
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to {reference}.");
            }
        }

        /// <summary>
        ///     Converts <see cref="UnitsNet.ElectricCurrent.Value" /> at <see cref="Reference" /> to <see cref="double" /> at
        ///     <see cref="BaseReference" />
        /// </summary>
        /// <returns>The value of current at the <see cref="BaseReference" /></returns>
        private double AsBaseReference()
        {
            switch (Reference)
            {
                case ElectricCurrentFlowReference.DirectOrRms:
                {
                    if (Current.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Current), "Direct or RMS current cannot be less than zero.");
                    }

                    return Current.Value;
                }
                case ElectricCurrentFlowReference.AlternatingPeak:
                {
                    if (Current.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Current), "Alternating peak current cannot be less than zero.");
                    }

                    // Vrms = (1 / sqrt(2)) * Vp
                    return Current.Value * 0.70710678118654752440084436210485;
                }
                case ElectricCurrentFlowReference.AlternatingPeakToPeak:
                {
                    if (Current.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Current), "Alternating peak-to-peak current cannot be less than zero.");
                    }

                    // Vrms = (1 / (2 * sqrt(2))) * Vp-p
                    return Current.Value * 0.35355339059327376220042218105242;
                }
                default:
                    throw new NotImplementedException($"Can not convert {Reference} to base reference.");
            }
        }
    }
}
