// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet
{
    public partial struct BitRate
    {
        /// <summary>Get <see cref="Information"/> from <see cref="BitRate"/> times <see cref="Duration"/>.</summary>
        public static Information operator *(BitRate bitRate, Duration duration)
        {
            return Information.FromBits(bitRate.BitsPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Information"/> from <see cref="Duration"/> times <see cref="BitRate"/>.</summary>
        public static Information operator *(Duration duration, BitRate bitRate)
        {
            return Information.FromBits(bitRate.BitsPerSecond * duration.Seconds);
        }
    }
}
