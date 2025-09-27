// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Serialization;
#if NET
using System.Buffers.Binary;
#endif

namespace UnitsNet;

/// <summary>
///     Represents a numeric value used in the UnitsNet library to provide precise representation of numbers
///     with unbounded scale and precision, unlike standard numeric types such as <see cref="double" /> or
///     <see cref="decimal" />.
/// </summary>
/// <remarks>
///     This implementation is derived from the Fractions library: <see href="https://github.com/danm-de/Fractions" />.
///     Internally, it uses a fraction represented by two <see cref="System.Numerics.BigInteger" /> values
///     (numerator and denominator) to ensure arbitrary precision without loss of accuracy.
/// </remarks>
/// <example>
///     The <see cref="QuantityValue" /> struct can be used to represent precise numeric values for unit conversions
///     and calculations in the UnitsNet library.
/// </example>
[DataContract]
[Serializable]
[TypeConverter(typeof(QuantityValueTypeConverter))]
[DebuggerDisplay("{ToString(), nq}")]
[DebuggerTypeProxy(typeof(QuantityValueDebugView))]
public readonly partial struct QuantityValue :
#if NET7_0_OR_GREATER
    INumber<QuantityValue>, ISignedNumber<QuantityValue>, IConvertible
#else
    IFormattable, IConvertible, IEquatable<QuantityValue>, IComparable<QuantityValue>, IComparable
#endif
{
    
    [DataMember(Name = "N", Order = 1)]
    private readonly BigInteger _numerator;
    
    [DataMember(Name = "D", Order = 2)]
    private readonly BigInteger? _denominator;

    /// <summary>
    ///     Gets the numerator of the fraction representing the <see cref="QuantityValue" />.
    /// </summary>
    /// <remarks>
    ///     The numerator is a <see cref="System.Numerics.BigInteger" /> that, together with the denominator,
    ///     defines the value of the fraction stored in this <see cref="QuantityValue" />.
    /// </remarks>
    internal BigInteger Numerator => _numerator;

    /// <summary>
    ///     Gets the denominator of the fraction representing the value of this <see cref="QuantityValue" />.
    /// </summary>
    /// <remarks>
    ///     The denominator is part of the internal fractional representation of the value, which ensures
    ///     high precision and supports arbitrary values without loss of accuracy.
    /// </remarks>
    internal BigInteger Denominator => _denominator.GetValueOrDefault(BigInteger.One);


    /// <summary>
    ///     Construct using a value <paramref name="numerator" /> and <paramref name="denominator" />.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    internal QuantityValue(BigInteger numerator, BigInteger denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValue"/> struct with the specified numerator, denominator, 
    ///     and a power of ten exponent.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction representing the value.</param>
    /// <param name="denominator">The denominator of the fraction representing the value.</param>
    /// <param name="powerOfTen">
    ///     The power of ten to adjust the value. A positive exponent multiplies the numerator by 10 raised to the power, 
    ///     while a negative exponent multiplies the denominator by 10 raised to the absolute value of the power.
    /// </param>
    /// <remarks>
    ///     This constructor enables precise representation of values using a fraction and a power of ten, 
    ///     corresponding to the scientific notation: (numerator/denominator) * 10 ^ powerOfTen.
    /// </remarks>
    internal QuantityValue(BigInteger numerator, BigInteger denominator, int powerOfTen)
    {
        if (powerOfTen > 0)
        {
            _numerator = numerator * PowerOfTen(powerOfTen);
            _denominator = denominator;
        }
        else
        {
            _numerator = numerator;
            _denominator = denominator * PowerOfTen(-powerOfTen);
        }
    }

    /// <summary>
    ///     Creates a normalized fraction using a signed 32bit integer.
    /// </summary>
    /// <param name="value">integer value that will be used for the numerator. The denominator will be 1.</param>
    public QuantityValue(int value)
    {
        _numerator = new BigInteger(value);
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Creates a normalized fraction using a signed 64bit integer.
    /// </summary>
    /// <param name="value">integer value that will be used for the numerator. The denominator will be 1.</param>
    public QuantityValue(long value)
    {
        _numerator = new BigInteger(value);
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Creates a normalized fraction using a unsigned 32bit integer.
    /// </summary>
    /// <param name="value">integer value that will be used for the numerator. The denominator will be 1.</param>
    [CLSCompliant(false)]
    public QuantityValue(uint value)
    {
        _numerator = new BigInteger(value);
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Creates a normalized fraction using a unsigned 64bit integer.
    /// </summary>
    /// <param name="value">integer value that will be used for the numerator. The denominator will be 1.</param>
    [CLSCompliant(false)]
    public QuantityValue(ulong value)
    {
        _numerator = new BigInteger(value);
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Creates a normalized fraction using a big integer.
    /// </summary>
    /// <param name="value">big integer value that will be used for the numerator. The denominator will be 1.</param>
    public QuantityValue(BigInteger value)
    {
        _numerator = value;
        _denominator = BigInteger.One;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValue" /> struct using a <see cref="decimal" /> value.
    /// </summary>
    /// <param name="value">The decimal value to initialize the <see cref="QuantityValue" /> with.</param>
    /// <remarks>
    ///     This constructor converts the provided <paramref name="value" /> into a fraction represented by a numerator
    ///     and a denominator using <see cref="BigInteger" /> for precise representation without loss of precision.
    /// </remarks>
    public QuantityValue(decimal value)
    {
#if NET
        Span<int> bits = stackalloc int[4];
        decimal.GetBits(value, bits);
        Span<byte> buffer = stackalloc byte[16];
        // Assume BitConverter.IsLittleEndian = true
        BinaryPrimitives.WriteInt32LittleEndian(buffer[..4], bits[0]);
        BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(4, 4), bits[1]);
        BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(8, 4), bits[2]);
        BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(12, 4), bits[3]);
        var exp = buffer[14];
        var positiveSign = (buffer[15] & 0x80) == 0;
        // Pass false to the isBigEndian parameter
        var numerator = new BigInteger(buffer[..13]);
#else
        var bits = decimal.GetBits(value);
        var low = BitConverter.GetBytes(bits[0]);
        var middle = BitConverter.GetBytes(bits[1]);
        var high = BitConverter.GetBytes(bits[2]);
        var scale = BitConverter.GetBytes(bits[3]);

        var exp = scale[2];
        var positiveSign = (scale[3] & 0x80) == 0;

        // value = 0x00,high,middle,low / 10^exp
        var numerator = new BigInteger([
            low[0], low[1], low[2], low[3],
            middle[0], middle[1], middle[2], middle[3],
            high[0], high[1], high[2], high[3],
            0x00
        ]);
#endif
        _numerator = positiveSign ? numerator : -numerator;
        _denominator = PowerOfTen(exp);
    }
}
