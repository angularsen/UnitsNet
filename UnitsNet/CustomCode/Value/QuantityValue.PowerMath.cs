using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    internal static readonly BigInteger[] PowersOfTen = [
        BigInteger.One, // 10^0 = 1
        new(10), // 10^1 = 10
        new(100), // 10^2 = 100
        new(1000), // 10^3 = 1,000
        new(10000), // 10^4 = 10,000
        new(100000), // 10^5 = 100,000
        new(1000000), // 10^6 = 1,000,000
        new(10000000), // 10^7 = 10,000,000
        new(100000000), // 10^8 = 100,000,000
        new(1000000000), // 10^9 = 1,000,000,000
        new(10000000000), // 10^10 = 10,000,000,000
        new(100000000000), // 10^11 = 100,000,000,000
        new(1000000000000), // 10^12 = 1,000,000,000,000
        new(10000000000000), // 10^13 = 10,000,000,000,000
        new(100000000000000), // 10^14 = 100,000,000,000,000
        new(1000000000000000), // 10^15 = 1,000,000,000,000,000
        new(10000000000000000), // 10^16 = 10,000,000,000,000,000
        new(100000000000000000), // 10^17 = 100,000,000,000,000,000
        new(1000000000000000000) // 10^18 = 1,000,000,000,000,000,000
    ];

    /// <summary>
    ///     Computes the power of ten for a given exponent.
    /// </summary>
    /// <param name="exponent">The exponent to which ten is raised.</param>
    /// <returns>
    ///     A <see cref="BigInteger" /> representing 10 raised to the power of <paramref name="exponent" />.
    /// </returns>
    /// <remarks>
    ///     If the <paramref name="exponent" /> is within the precomputed range, the result is retrieved from a cached array
    ///     for better performance. Otherwise, <see cref="BigInteger.Pow(BigInteger, int)" /> is used to calculate the result.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static BigInteger PowerOfTen(int exponent)
    {
        if (exponent < PowersOfTen.Length)
        {
            return PowersOfTen[exponent];
        }

        var maxExponent = PowersOfTen.Length - 1;
        if (exponent > 3 * maxExponent)
        {
            return BigInteger.Pow(Ten, exponent); // the exponent is > 54
        }

        var maxPowerOfTen = PowersOfTen[maxExponent];
        var result = maxPowerOfTen;
        exponent -= maxExponent; // the exponent no more than 2 * maxExponent (36)
        if (exponent > maxExponent)
        {
            result *= maxPowerOfTen;
            exponent -= maxExponent; // the exponent is no more than maxExponent (18)
        }

        if (exponent == maxExponent)
        {
            return result * maxPowerOfTen;
        }

        return result * PowersOfTen[exponent];
    }
    
    /// <summary>
    ///     Raises a QuantityValue to the specified power.
    /// </summary>
    /// <param name="x">The QuantityValue to raise to the power.</param>
    /// <param name="power">The power to raise the QuantityValue to.</param>
    /// <returns>The QuantityValue raised to the specified power.</returns>
    public static QuantityValue Pow(QuantityValue x, int power)
    {
        BigInteger numerator, denominator;
        switch (power)
        {
            case > 0:
                (numerator, denominator) = x;
                break;
            case < 0 when IsZero(x):
                return PositiveInfinity;
            case < 0:
                power = -power;
                (numerator, denominator) = Inverse(x);
                break;
            default:
                // x^0 == 1
                return One;
        }

        return new QuantityValue(
            BigInteger.Pow(numerator, power),
            BigInteger.Pow(denominator, power));
    }

    /// <summary>
    ///     Calculates the square root of a given QuantityValue.
    /// </summary>
    /// <param name="x">The QuantityValue for which to calculate the square root.</param>
    /// <param name="accuracy">The number of significant digits of accuracy for the square root calculation. Default is 30.</param>
    /// <returns>A new QuantityValue that is the square root of the input QuantityValue.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the accuracy is less than or equal to zero.</exception>
    /// <remarks>
    ///     The implementation is based on the work by
    ///     <see href="https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root">SunsetQuest</see>.
    ///     <para>
    ///         It uses the Babylonian method of computing square roots, making sure that the relative difference with the true
    ///         value is smaller than 1/10^accuracy.
    ///     </para>
    ///     <para>
    ///         Note: the resulting value is not rounded and may contain additional digits (up to 20%), which have a relatively
    ///         high likelihood of being correct, however no strong guarantees can be made.
    ///     </para>
    /// </remarks>
    public static QuantityValue Sqrt(QuantityValue x, int accuracy = 30)
    {
        if (accuracy <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(accuracy), "The accuracy must be a positive integer.");
        }

        if (IsNaN(x) || IsNegative(x))
        {
            return NaN;
        }

        if (x.Numerator.IsZero || x.Denominator.IsZero) // IsZero || IsInfinity)
        {
            return x;
        }

        if (x.Numerator == x.Denominator)
        {
            return One;
        }

        // BigInteger square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root
        return GetSqrtWithPrecision(Reduce(x), accuracy * 4);

        static QuantityValue GetSqrtWithPrecision(QuantityValue fraction, int precisionBits)
        {
            // BigFloatingPoint square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root/blob/master/BigFloatingPointSquareRoot.cs
            var (numerator, numeratorShift) = SqrtWithShift(fraction.Numerator, precisionBits);
            var (denominator, denominatorShift) = SqrtWithShift(fraction.Denominator, precisionBits);
            var shift = numeratorShift - denominatorShift;
            switch (shift)
            {
                case < 0:
                    denominator >>= shift;
                    break;
                case > 0:
                    numerator >>= -shift;
                    break;
            }

            return new QuantityValue(numerator, denominator);
        }

        static (BigInteger val, int shift) SqrtWithShift(BigInteger x, int precisionBits)
        {
            if (x.IsOne)
            {
                return (x, 0);
            }

            if (x < 144838757784765629) // 1.448e17 = ~1<<57
            {
                var longX = (ulong)x;
                var vInt = (uint)Math.Sqrt(longX);
                if (vInt * vInt == longX)
                {
                    return (vInt, 0);
                }
            }
#if NET
            var totalLen = (int)x.GetBitLength();
#else
            var totalLen = (int)BigInteger.Log(x, 2);
#endif

            var needToShiftInputBy = 2 * precisionBits - totalLen - (totalLen & 1);
            var val = SqrtBigInt(x << needToShiftInputBy);
            var retShift = (totalLen + (totalLen > 0 ? 1 : 0)) / 2 - precisionBits;
            return (val, retShift);
        }

        static BigInteger SqrtBigInt(BigInteger x)
        {
            // BigInteger square root implementation based on https://github.com/SunsetQuest/NewtonPlus-Fast-BigInteger-and-BigFloat-Square-Root/blob/master/BigIntegerSquareRoot.cs
            if (x < 144838757784765629) // 1.448e17 = ~1<<57
            {
                var vInt = (uint)Math.Sqrt((ulong)x);
                return vInt;
            }

            var xAsDub = (double)x;
            if (xAsDub < 8.5e37) //   8.5e37 is V<sup>2</sup>long.max * long.max
            {
                var vInt = (ulong)Math.Sqrt(xAsDub);
                BigInteger v = (vInt + (ulong)(x / vInt)) >> 1;
                return v;
            }

            if (xAsDub < 4.3322e127)
            {
                var v = (BigInteger)Math.Sqrt(xAsDub);
                v = (v + x / v) >> 1;
                if (xAsDub > 2e63)
                {
                    v = (v + x / v) >> 1;
                }

                return v;
            }

#if NET
            var xLen = (int)x.GetBitLength();
#else
            var xLen = (int)BigInteger.Log(x, 2) + 1;
#endif
            var wantedPrecision = (xLen + 1) / 2;
            var xLenMod = xLen + (xLen & 1) + 1;

            //////// Do the first Sqrt on hardware ////////
            var tempX = (long)(x >> (xLenMod - 63));
            var tempSqrt1 = Math.Sqrt(tempX);
            var valLong = (ulong)BitConverter.DoubleToInt64Bits(tempSqrt1) & 0x1fffffffffffffL;
            if (valLong == 0)
            {
                valLong = 1UL << 53;
            }

            ////////  Classic Newton Iterations ////////
            var val = ((BigInteger)valLong << 52) + (x >> (xLenMod - 3 * 53)) / valLong;

            val = (val << (106 - 1)) + (x >> (xLenMod - 3 * 106)) / val;
            val = (val << (212 - 1)) + (x >> (xLenMod - 3 * 212)) / val;
            var size = 424;
            
            if (xAsDub > 4e254) // 1 << 845
            {
#if NET
                var numOfNewtonSteps = BitOperations.Log2((uint)(wantedPrecision / size)) + 2;
#else
                var numOfNewtonSteps = (int)Math.Log((uint)(wantedPrecision / size), 2) + 2;
#endif

                //////  Apply Starting Size  ////////
                var startingSize = (wantedPrecision >> numOfNewtonSteps) + 2;
                var needToShiftBy = size - startingSize;
                val >>= needToShiftBy;
                size = startingSize;
                do {
                    ////////  Newton Plus Iterations  ////////
                    var shiftX = xLenMod - 3 * size;
                    var valSqrd = (val * val) << (size - 1);
                    var valSU = (x >> shiftX) - valSqrd;
                    val = (val << size) + valSU / val;
                    size <<= 1;
                } while (size < wantedPrecision);
            }
            
            ////////  Shrink result to wanted Precision  ////////
            val >>= size - wantedPrecision;
            
            return val;
        }
    }

    /// <summary>
    ///     Raises a <see cref="QuantityValue" /> to the power of another <see cref="QuantityValue" /> with a specified
    ///     accuracy.
    /// </summary>
    /// <param name="number">The base <see cref="QuantityValue" /> to be raised to a power.</param>
    /// <param name="power">The exponent <see cref="QuantityValue" />.</param>
    /// <param name="accuracy">The number of decimal places of accuracy for the square root calculation. Default is 30.</param>
    /// <returns>
    ///     A new <see cref="QuantityValue" /> representing the result of raising <paramref name="number" /> to the power
    ///     of <paramref name="power" />.
    /// </returns>
    /// <remarks>
    ///     Uses Babylonian Method of computing square roots: increasing the accuracy would result in longer calculation
    ///     times.
    /// </remarks>
    internal static QuantityValue Pow(QuantityValue number, QuantityValue power, int accuracy = 30)
    {
        if (power == One)
        {
            return number;
        }

        if (number == One)
        {
            return number;
        }

        power = Reduce(power);
        var denominator = power.Denominator;
        if (denominator.IsOne)
        {
            return Round(Pow(number, (int)power), accuracy);
        }

        var numeratorRaised = Pow(number, (int)power.Numerator);
        return RootN(numeratorRaised, (int)denominator, accuracy);
    }

    /// <summary>
    ///     Calculates the n-th root of a given <see cref="QuantityValue" /> with a specified accuracy.
    /// </summary>
    /// <param name="number">The <see cref="QuantityValue" /> for which to calculate the root.</param>
    /// <param name="n">The degree of the root.</param>
    /// <param name="accuracy">The number of decimal places of accuracy for the square root calculation. Default is 15.</param>
    /// <returns>The n-th root of the given <see cref="QuantityValue" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="accuracy" /> is less than or equal to zero.</exception>
    internal static QuantityValue RootN(QuantityValue number, int n, int accuracy = 15)
    {
        if (accuracy <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(accuracy), accuracy, "The accuracy must be positive");
        }

        if (n == 0)
        {
            return NaN;
        }

        if (n == 1)
        {
            return Round(number, accuracy);
        }

        if (number == One || IsNaN(number))
        {
            return number;
        }

        if (IsZero(number))
        {
            return n < 0 ? PositiveInfinity : number;
        }

        if (IsPositiveInfinity(number))
        {
            return n < 0 ? Zero : PositiveInfinity;
        }

        if (IsNegativeInfinity(number))
        {
            if ((n & 1) == 0) // is even integer
            {
                return NaN;
            }

            return n < 0 ? Zero : number;
        }

        if (n > 0)
        {
            if (IsPositive(number))
            {
                return Root(number, n, accuracy);
            }

            if ((n & 1) == 0) // is even integer
            {
                return NaN;
            }

            return -Root(-number, n, accuracy);
        }

        // n < 0
        if (IsPositive(number))
        {
            return Root(Inverse(number), -n, accuracy);
        }

        if ((n & 1) == 0) // is even integer
        {
            return NaN;
        }

        return -Root(-Inverse(number), -n, accuracy);

        static QuantityValue Root(QuantityValue number, int n, int accuracy)
        {
            var precision = PowerOfTen(accuracy);
            // Initial guess
            var x = FromDoubleRounded(Math.Pow(number.ToDouble(), 1.0 / n), (byte)Math.Min(accuracy, 17));
            QuantityValue xPrev;
            var minChange = new QuantityValue(1, precision);
            do
            {
                xPrev = x;
                x = ((n - 1) * x + number / Pow(x, n - 1)) / n;
            } while (Abs(x - xPrev) > minChange);

            return Round(x, accuracy);
        }
    }
}
