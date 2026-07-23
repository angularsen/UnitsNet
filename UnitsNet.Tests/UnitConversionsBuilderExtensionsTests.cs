// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace UnitsNet.Tests;

public class UnitConversionsBuilderExtensionsTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void NoCaching_ReturnsNoConversions(bool reduceConstants)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        Assert.Empty(quantities.GetUnitConversionFunctions(ConversionCachingMode.None, reduceConstants));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void BaseOnlyCaching_ReturnsBaseUnitConversions(bool reduceConstants)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        // 2 * (27 - 1) (Mass) + 2 * (54 - 1) (Volume) = 52 + 106 = 158 conversions (the Volume has the 3rd hightest number of units: (VolumeFlow, 75), (Density, 56))
        // Quantity.Infos.Sum(info => 2 * (info.UnitInfos.Count - 1)) => 2880
        var expectedNumberOfConversions = quantities.Sum(info => 2 * (info.UnitInfos.Count - 1));

        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.BaseOnly, reduceConstants)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count), () =>
        {
            Assert.All(quantities, quantity =>
            {
                UnitInfo baseUnit = quantity.BaseUnitInfo;
                Assert.All(quantity.UnitInfos, fromUnit =>
                {
                    Assert.All(quantity.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if ((fromUnit == baseUnit || toUnit == baseUnit) && fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            });
        });
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AllCaching_ReturnsAllUnitConversions(bool reduceConstants)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        // 27 * 26 (Mass) + 54 * 53 (Volume) = 702 + 2862 = 3564 conversions (the Volume has the 3rd hightest number of units: (VolumeFlow, 75), (Density, 56))
        // Quantity.Infos.Sum(info => info.UnitInfos.Count * (info.UnitInfos.Count - 1)) =>	40114
        var expectedNumberOfConversions = quantities.Sum(info => info.UnitInfos.Count * (info.UnitInfos.Count - 1));

        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.All, reduceConstants)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count), () =>
        {
            Assert.All(quantities, quantity =>
            {
                Assert.All(quantity.UnitInfos, fromUnit =>
                {
                    Assert.All(quantity.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if (fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            });
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void AllCaching_WithSpecificNoneOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = Mass.Info.UnitInfos.Count * (Mass.Info.UnitInfos.Count - 1);
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Volume)] = new(ConversionCachingMode.None, volumeConstantsReduction) };
        
        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count),
            () =>
            {
                Assert.All(Mass.Info.UnitInfos, fromUnit =>
                {
                    Assert.All(Mass.Info.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if (fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            },
            () =>
            {
                Assert.All(Volume.Info.UnitInfos,
                    fromUnit =>
                    {
                        Assert.All(Volume.Info.UnitInfos,
                            toUnit => { Assert.DoesNotContain(UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey), unitConversions); });
                    });
            });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void AllCaching_WithSpecificBaseOnlyOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = Mass.Info.UnitInfos.Count * (Mass.Info.UnitInfos.Count - 1) + 2 * (Volume.Info.UnitInfos.Count - 1);
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Volume)] = new(ConversionCachingMode.BaseOnly, volumeConstantsReduction) };
        
        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count),
            () =>
            {
                Assert.All(Mass.Info.UnitInfos, fromUnit =>
                {
                    Assert.All(Mass.Info.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if (fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            },
            () =>
            {
                Assert.All(Volume.Info.UnitInfos, fromUnit =>
                {
                    UnitInfo baseUnit = Volume.Info.BaseUnitInfo;
                    Assert.All(Volume.Info.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if ((fromUnit == baseUnit || toUnit == baseUnit) && fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void BaseOnlyCaching_WithSpecificAllOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = Mass.Info.UnitInfos.Count * (Mass.Info.UnitInfos.Count - 1) + 2 * (Volume.Info.UnitInfos.Count - 1);
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Mass)] = new(ConversionCachingMode.All, volumeConstantsReduction) };
        
        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.BaseOnly, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count),
            () =>
            {
                Assert.All(Mass.Info.UnitInfos, fromUnit =>
                {
                    Assert.All(Mass.Info.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if (fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            }, () =>
            {
                Assert.All(Volume.Info.UnitInfos, fromUnit =>
                {
                    UnitInfo baseUnit = Volume.Info.BaseUnitInfo;
                    Assert.All(Volume.Info.UnitInfos, toUnit =>
                    {
                        var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                        if ((fromUnit == baseUnit || toUnit == baseUnit) && fromUnit != toUnit)
                        {
                            QuantityValue valueToConvert = 123.45m;
                            QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                            Assert.Contains(conversionKey, unitConversions);
                            Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                        }
                        else
                        {
                            Assert.DoesNotContain(conversionKey, unitConversions);
                        }
                    });
                });
            });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void BaseOnlyCaching_WithSpecificNoneOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = 2 * (Volume.Info.UnitInfos.Count - 1);
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Mass)] = new(ConversionCachingMode.None, volumeConstantsReduction) };

        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.BaseOnly, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count), () =>
        {
            Assert.All(Mass.Info.UnitInfos,
                fromUnit =>
                {
                    Assert.All(Mass.Info.UnitInfos,
                        toUnit => { Assert.DoesNotContain(UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey), unitConversions); });
                });
        }, () =>
        {
            Assert.All(Volume.Info.UnitInfos, fromUnit =>
            {
                UnitInfo baseUnit = Volume.Info.BaseUnitInfo;
                Assert.All(Volume.Info.UnitInfos, toUnit =>
                {
                    var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                    if ((fromUnit == baseUnit || toUnit == baseUnit) && fromUnit != toUnit)
                    {
                        QuantityValue valueToConvert = 123.45m;
                        QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                        Assert.Contains(conversionKey, unitConversions);
                        Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                    }
                    else
                    {
                        Assert.DoesNotContain(conversionKey, unitConversions);
                    }
                });
            });
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void NoCaching_WithSpecificAllOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = Volume.Info.UnitInfos.Count * (Volume.Info.UnitInfos.Count - 1);
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Volume)] = new(ConversionCachingMode.All, volumeConstantsReduction) };
        
        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.None, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count),
            () =>
        {
            Assert.All(Mass.Info.UnitInfos, fromUnit =>
            {
                Assert.All(Mass.Info.UnitInfos, toUnit =>
                {
                    var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                    Assert.DoesNotContain(conversionKey, unitConversions);
                });
            });
        }, () =>
        {
            Assert.All(Volume.Info.UnitInfos, fromUnit =>
            {
                Assert.All(Volume.Info.UnitInfos, toUnit =>
                {
                    var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                    if (fromUnit != toUnit)
                    {
                        QuantityValue valueToConvert = 123.45m;
                        QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                        Assert.Contains(conversionKey, unitConversions);
                        Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                    }
                    else
                    {
                        Assert.DoesNotContain(conversionKey, unitConversions);
                    }
                });
            });
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void NoCaching_WithSpecificBaseOnlyOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool volumeConstantsReduction)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        var expectedNumberOfConversions = 2 * (Volume.Info.UnitInfos.Count - 1);
        var customQuantityOptions =
            new Dictionary<Type, ConversionCacheOptions> { [typeof(Volume)] = new(ConversionCachingMode.BaseOnly, volumeConstantsReduction) };

        var unitConversions = quantities.GetUnitConversionFunctions(ConversionCachingMode.None, defaultConstantsReduction, customQuantityOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, unitConversions.Count), () =>
        {
            Assert.All(Mass.Info.UnitInfos, fromUnit =>
            {
                Assert.All(Mass.Info.UnitInfos, toUnit =>
                {
                    var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                    Assert.DoesNotContain(conversionKey, unitConversions);
                });
            });
        }, () =>
        {
            Assert.All(Volume.Info.UnitInfos, fromUnit =>
            {
                UnitInfo baseUnit = Volume.Info.BaseUnitInfo;
                Assert.All(Volume.Info.UnitInfos, toUnit =>
                {
                    var conversionKey = UnitConversionKey.Create(fromUnit.UnitKey, toUnit.UnitKey);
                    if ((fromUnit == baseUnit || toUnit == baseUnit) && fromUnit != toUnit)
                    {
                        QuantityValue valueToConvert = 123.45m;
                        QuantityValue expectedValue = toUnit.GetValueFrom(valueToConvert, fromUnit);
                        Assert.Contains(conversionKey, unitConversions);
                        Assert.Equal(expectedValue, unitConversions[conversionKey](valueToConvert));
                    }
                    else
                    {
                        Assert.DoesNotContain(conversionKey, unitConversions);
                    }
                });
            });
        });
    }
    
    [Theory]
    [InlineData(ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.BaseOnly, false)] // the conversions from/to the base units are already reduced by the CodeGen
    public void ReduceConstants_ReturnsUnitConversionsWithReducedCoefficients(ConversionCachingMode cachingMode, bool reduceConstants)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };

        IEnumerable<ConvertValueDelegate> unitConversions = quantities.GetUnitConversionFunctions(cachingMode, reduceConstants).Select(pair => pair.Value);

        Assert.All(unitConversions, valueDelegate => Assert.True(IsReduced(valueDelegate(QuantityValue.One))));
    }

    private static bool IsReduced(QuantityValue value)
    {
        (BigInteger numerator, BigInteger denominator) = value;
        return BigInteger.GreatestCommonDivisor(numerator, denominator) == BigInteger.One;
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetUnitConversionFunctions_WithInvalidCachingMode_ThrowsArgumentException(bool reduceConstants)
    {
        var quantities = new QuantityInfo[] { Mass.Info, Volume.Info };
        const ConversionCachingMode invalidCachingMode = (ConversionCachingMode)(-1);
        Assert.Multiple(() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => quantities.GetUnitConversionFunctions(invalidCachingMode, reduceConstants)),
            () =>
            {
                var emptyOptions = new Dictionary<Type, ConversionCacheOptions>();
                Assert.Throws<ArgumentOutOfRangeException>(() => quantities.GetUnitConversionFunctions(invalidCachingMode, reduceConstants, emptyOptions)
                    .ToList());
            },
            () =>
            {
                var validOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Mass)] = new() };
                Assert.Throws<ArgumentOutOfRangeException>(() => quantities.GetUnitConversionFunctions(invalidCachingMode, reduceConstants, validOptions)
                    .ToList());
            },
            () =>
            {
                var invalidOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Mass)] = new(invalidCachingMode) };
                Assert.Throws<ArgumentOutOfRangeException>(() => quantities.GetUnitConversionFunctions(default, reduceConstants, invalidOptions)
                    .ToList());
            });
    }
}
