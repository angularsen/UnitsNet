// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

/// <summary>
///     The conversion to the specified is not supported. This is typically thrown for dynamic conversions,
///     such as <see cref="UnitConverter.ConvertByName" />.
/// </summary>
public class InvalidConversionException : UnitsNetException
{
    /// <inheritdoc />
    public InvalidConversionException()
    {
    }

    /// <inheritdoc />
    public InvalidConversionException(string message) : base(message)
    {
    }

    /// <inheritdoc />
    public InvalidConversionException(string message, Exception innerException) : base(message, innerException)
    {
    }

    internal static InvalidConversionException CreateImplicitConversionException(QuantityInfo sourceQuantity, QuantityInfo targetQuantity)
    {
        return new InvalidConversionException($"No implicit conversion exists for the quantities: source = '{sourceQuantity}', target = '{targetQuantity}'");
    }

    internal static InvalidConversionException CreateIncompatibleDimensionsException(BaseDimensions sourceDimensions, BaseDimensions targetDimensions)
    {
        return new InvalidConversionException($"The conversion expression cannot be determined from the base dimensions: source = '{sourceDimensions}', target = '{targetDimensions}'");
    }

    internal static InvalidConversionException CreateIncompatibleDimensionsException(QuantityInfo sourceQuantityInfo, QuantityInfo targetQuantityInfo)
    {
        return new InvalidConversionException($"The dimensions of the source quantity '{sourceQuantityInfo}' are not compatible with the dimensions of the target quantity '{targetQuantityInfo}'.");
    }

    internal static InvalidConversionException CreateIncompatibleUnitsException(UnitInfo sourceUnitInfo, QuantityInfo targetQuantityInfo)
    {
        return new InvalidConversionException($"No compatible base units found for the conversion from '{sourceUnitInfo}' to '{targetQuantityInfo}'");
    }
}
