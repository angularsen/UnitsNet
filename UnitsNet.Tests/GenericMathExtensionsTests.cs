// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using UnitsNet.GenericMath;
using Xunit;

namespace UnitsNet.Tests;

public class GenericMathExtensionsTests
{
    [Fact]
    public void CanCalcSum()
    {
        Length[] values = { Length.FromCentimeters(100), Length.FromCentimeters(200) };

        Assert.Equal(Length.FromCentimeters(300), values.Sum());
    }

    [Fact]
    public void CanCalcAverage_ForQuantitiesWithDoubleValueType()
    {
        Length[] values = { Length.FromCentimeters(100), Length.FromCentimeters(200) };

        Assert.Equal(Length.FromCentimeters(150), values.Average());
    }

    [Fact]
    public void CanCalcAverage_ForQuantitiesWithDecimalValueType()
    {
        Information[] values = { Information.FromBytes(100), Information.FromBytes(200) };

        Assert.Equal(Information.FromBytes(150), values.Average());
    }
}

#endif
