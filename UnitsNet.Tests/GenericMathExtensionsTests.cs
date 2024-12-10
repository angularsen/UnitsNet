// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System;
using System.Collections.Generic;
using UnitsNet.GenericMath;
using Xunit;

namespace UnitsNet.Tests;

public class GenericMathExtensionsTests
{
    [Fact]
    public void Sum_Empty_ReturnsTheAdditiveIdentity()
    {
        Length[] values = [];

        Assert.Equal(Length.Zero, GenericMathExtensions.Sum(values));
    }

    [Fact]
    public void Sum_OneQuantity_ReturnsTheSameQuantity()
    {
        IEnumerable<Length> values = [Length.FromCentimeters(100)];

        Length sumOfQuantities = GenericMathExtensions.Sum(values);

        Assert.Equal(Length.FromCentimeters(100), sumOfQuantities);
    }

    [Fact]
    public void Sum_TwoQuantities_ReturnsTheExpectedSum()
    {
        IEnumerable<Length> values = [Length.FromCentimeters(100), Length.FromCentimeters(200)];

        Length sumOfQuantities = GenericMathExtensions.Sum(values);

        Assert.Equal(Length.FromCentimeters(300), sumOfQuantities);
    }

    [Fact]
    public void Average_Empty_ThrowsInvalidOperationException()
    {
        IEnumerable<Length> values = [];

        Assert.Throws<InvalidOperationException>(() => GenericMathExtensions.Average(values));
    }

    [Fact]
    public void Average_OneQuantity_ReturnsTheSameQuantity()
    {
        IEnumerable<Length> values = [Length.FromCentimeters(100)];

        Length averageOfQuantities = GenericMathExtensions.Average(values);

        Assert.Equal(Length.FromCentimeters(100), averageOfQuantities);
    }

    [Fact]
    public void Average_TwoQuantities_ReturnsTheExpectedAverage()
    {
        IEnumerable<Length> values = [Length.FromCentimeters(100), Length.FromCentimeters(200)];

        Length averageOfQuantities = GenericMathExtensions.Average(values);

        Assert.Equal(Length.FromCentimeters(150), averageOfQuantities);
    }
}

#endif
