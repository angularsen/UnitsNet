// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.QuantityInfos.Builder;

public class QuantityInfoBuilderTest
{
    [Fact]
    public void Constructor_NullFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new QuantityInfoBuilder<Length, LengthUnit>(null!));
    }

    [Fact]
    public void Constructor_ValidFactory_DoesNotThrow()
    {
        var builder = new QuantityInfoBuilder<Length, LengthUnit>(() => Length.Info);
        Assert.NotNull(builder);
    }

    [Fact]
    public void Build_ValidFactory_ReturnsQuantityInfo()
    {
        var builder = new QuantityInfoBuilder<Length, LengthUnit>(() => Length.Info);

        QuantityInfo<Length, LengthUnit> result = builder.Build();

        Assert.Same(Length.Info, result);
    }

    [Fact]
    public void Build_CalledMultipleTimes_ReturnsSameInstance()
    {
        var builder = new QuantityInfoBuilder<Length, LengthUnit>(() => Length.Info);

        QuantityInfo<Length, LengthUnit> firstResult = builder.Build();
        QuantityInfo<Length, LengthUnit> secondResult = builder.Build();

        Assert.Same(firstResult, secondResult);
    }

    [Fact]
    public void Build_InterfaceImplementation_ReturnsQuantityInfo()
    {
        IQuantityInfoBuilder builder = new QuantityInfoBuilder<Length, LengthUnit>(() => Length.Info);

        QuantityInfo result = builder.Build();

        Assert.Same(Length.Info, result);
    }
}
