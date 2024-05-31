using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct LevelToCarrier
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LevelToCarrier" /> struct.
        /// </summary>
        /// <param name="signal">The signal power.</param>
        /// <param name="reference">The reference value that <paramref name="signal" /> is compared to.</param>
        public LevelToCarrier(Power signal, Power reference)
            : this()
        {
            string errorMessage = $"The base-10 logarithm of a number ≤ 0 is undefined ({signal}/{reference}).";

            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (signal.Value == 0 || signal.Value < 0 && reference.Value > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(signal), errorMessage);
            }

            if (reference.Value == 0 || signal.Value > 0 && reference.Value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(reference), errorMessage);
            }
            // ReSharper restore CompareOfFloatsByEqualityOperator

            var quotient = signal / reference;

            _value = 10 * Math.Log10((double)quotient);
            _unit = LevelToCarrierUnit.DecibelCarrier;
        }
    }
}
