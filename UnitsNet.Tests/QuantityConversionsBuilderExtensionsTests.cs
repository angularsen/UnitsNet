// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests;

public class QuantityConversionsBuilderExtensionsTests
{
    [Fact]
    public void QuantityInfoLookup_GetQuantityConversions_ReturnsConversionsForQuantitiesPresentInTheLookup()
    {
        var quantityInfoLookup = new QuantityInfoLookup([Area.Info, ReciprocalArea.Info]);
        IEnumerable<QuantityConversionMapping> quantityConversionMappings = Quantity.Provider.DefaultConversions;

        QuantityConversion[] conversions = quantityInfoLookup.GetQuantityConversions(quantityConversionMappings).ToArray();

        Assert.Single(conversions);
        Assert.Equal(Area.Info, conversions[0].LeftQuantity);
        Assert.Equal(ReciprocalArea.Info, conversions[0].RightQuantity);
    }

    [Fact]
    public void QuantityInfoLookup_GetQuantityConversionMappingOptions_WithCustomConversion_ReturnsTheExpectedConversion()
    {
        var quantityInfoLookup = new QuantityInfoLookup([Mass.Info, Volume.Info]);
        QuantityConversionOptions conversionOptions = new QuantityConversionOptions().SetCustomConversion<Mass, Volume>();

        Dictionary<QuantityConversion, QuantityConversionMappingOptions> mappingOptions = quantityInfoLookup.GetQuantityConversionMappingOptions(conversionOptions);

        Assert.Empty(mappingOptions); // no QuantityConversionMappingOptions required
    }

    [Fact]
    public void QuantityInfoLookup_GetQuantityConversionMappingOptions_WithCustomUnitMapping_ReturnsTheExpectedConversion()
    {
        var quantityInfoLookup = new QuantityInfoLookup([Mass.Info, Volume.Info]);
        QuantityConversionOptions conversionOptions = new QuantityConversionOptions()
            .SetCustomConversion<Mass, Volume>()
            .SetConversionUnits(Mass.BaseUnit, Volume.BaseUnit);
        var mappingKey = new QuantityConversion(Mass.Info, Volume.Info);

        Dictionary<QuantityConversion, QuantityConversionMappingOptions> mappingOptions = quantityInfoLookup.GetQuantityConversionMappingOptions(conversionOptions);

        Assert.Single(mappingOptions);
        Assert.Contains(mappingKey, mappingOptions);
        Assert.Empty(mappingOptions[mappingKey].ConversionExpressions);
        Assert.Single(mappingOptions[mappingKey].CustomUnitMappings);
        Assert.Contains(mappingOptions[mappingKey].CustomUnitMappings, pair =>
            pair.Key == UnitConversionMapping.Create(Mass.BaseUnit, Volume.BaseUnit) &&
            pair.Value.SourceUnit == Mass.Info.BaseUnitInfo &&
            pair.Value.TargetUnit == Volume.Info.BaseUnitInfo);
    }

    [Fact]
    public void QuantityInfoLookup_GetQuantityConversionMappingOptions_WithCustomUnitMappingAndConversionFunction_ReturnsTheExpectedConversion()
    {
        var quantityInfoLookup = new QuantityInfoLookup([Mass.Info, Volume.Info]);
        var conversionExpression = new ConversionExpression(1);
        QuantityConversionOptions conversionOptions = new QuantityConversionOptions()
            .SetCustomConversion<Mass, Volume>()
            .SetConversionUnits(MassUnit.Gram, VolumeUnit.Liter)
            .SetCustomConversion(Mass.BaseUnit, Volume.BaseUnit, conversionExpression);
        var mappingKey = new QuantityConversion(Mass.Info, Volume.Info);

        Dictionary<QuantityConversion, QuantityConversionMappingOptions> mappingOptions = quantityInfoLookup.GetQuantityConversionMappingOptions(conversionOptions);

        Assert.Single(mappingOptions);
        Assert.Contains(mappingKey, mappingOptions);
        Assert.Single(mappingOptions[mappingKey].ConversionExpressions);
        Assert.Contains(mappingOptions[mappingKey].ConversionExpressions, pair =>
            pair.Key == UnitConversionMapping.Create(Mass.BaseUnit, Volume.BaseUnit) &&
            pair.Value.SourceUnit == Mass.Info.BaseUnitInfo &&
            pair.Value.TargetUnit == Volume.Info.BaseUnitInfo &&
            pair.Value.ConversionExpression == conversionExpression);
        Assert.Single(mappingOptions[mappingKey].CustomUnitMappings);
        Assert.Contains(mappingOptions[mappingKey].CustomUnitMappings, pair =>
            pair.Key == UnitConversionMapping.Create(MassUnit.Gram, VolumeUnit.Liter) &&
            pair.Value.SourceUnit == Mass.Info[MassUnit.Gram] &&
            pair.Value.TargetUnit == Volume.Info[VolumeUnit.Liter]);
    }

    [Fact]
    public void QuantityInfoLookup_GetQuantityConversionMappingOptions_IgnoresConversionsForQuantitiesNotPresentInTheLookup()
    {
        var quantityInfoLookup = new QuantityInfoLookup([Area.Info, ReciprocalArea.Info]);
        Assert.Multiple(() =>
        {
            Assert.Empty(quantityInfoLookup.GetQuantityConversionMappingOptions(new QuantityConversionOptions()
                .SetConversionUnits(Mass.BaseUnit, Volume.BaseUnit)));
        }, () =>
        {
            Assert.Empty(quantityInfoLookup.GetQuantityConversionMappingOptions(new QuantityConversionOptions()
                .SetCustomConversion(Mass.BaseUnit, Volume.BaseUnit, 1)));
        }, () =>
        {
            Assert.Empty(quantityInfoLookup.GetQuantityConversionMappingOptions(new QuantityConversionOptions()
                .SetCustomConversion<Mass, Volume>()
                .SetConversionUnits(Mass.BaseUnit, Volume.BaseUnit)
                .SetCustomConversion(Mass.BaseUnit, Volume.BaseUnit, 1)));
        });
    }

    [Fact]
    public void DefaultQuantityInfoLookup_GetQuantityConversions_ReturnsAllDefaultConversions()
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        
        QuantityConversion[] quantityConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();

        Assert.Equal(conversionMappings.Count, quantityConversions.Length);
        Assert.All(conversionMappings.Zip(quantityConversions, (mapping, conversion) => (mapping, conversion)), tuple =>
        {
            (QuantityConversionMapping mapping, QuantityConversion conversion) = tuple;
            Assert.Equal(mapping.FirstQuantityType, conversion.LeftQuantity.QuantityType);
            Assert.Equal(mapping.SecondQuantityType, conversion.RightQuantity.QuantityType);
        });
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void NoCaching_ReturnsNoConversions(bool reduceConstants)
    {
        IEnumerable<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        
        IEnumerable<QuantityConversion> conversions = UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityConversions(conversionMappings);
        
        Assert.Empty(conversions.GetConversionFunctions(ConversionCachingMode.None, reduceConstants));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void BaseOnlyCaching_ReturnsBaseUnitConversions(bool reduceConstants)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        
        // there are currently 32 conversions here
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.BaseOnly, reduceConstants)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            Assert.Multiple(
                () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
        });
    }

    private static void ConversionsWithBaseUnits_ConvertToTargetQuantity(Dictionary<QuantityConversionKey, QuantityConversionFunction> conversionExpressions,
        QuantityInfo fromQuantityInfo, QuantityInfo toQuantityInfo)
    {
        Assert.All(fromQuantityInfo.UnitInfos, fromUnit =>
        {
            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantityInfo.UnitType);
            if (fromUnit.BaseUnits != BaseUnits.Undefined)
            {
                Assert.All(toQuantityInfo.UnitInfos.GetUnitInfosFor(fromUnit.BaseUnits), targetUnit =>
                {
                    QuantityValue valueToConvert = 123.45m;
                    QuantityValue expectedValue = toQuantityInfo.ConvertFrom(valueToConvert, fromUnit).As(targetUnit.Value);
                    Assert.Contains(conversionKey, conversionExpressions);
                    Assert.Equal(targetUnit.UnitKey, conversionExpressions[conversionKey].TargetUnit);
                    Assert.Equal(expectedValue, conversionExpressions[conversionKey].Convert(valueToConvert));
                });
            }
            else
            {
                Assert.DoesNotContain(conversionKey, conversionExpressions);
            }
        });
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AllCaching_ReturnsAllUnitConversions(bool reduceConstants)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        // there are currently 156 conversions here
        var expectedNumberOfConversions = defaultConversions.Sum(x => x.LeftQuantity.UnitInfos.Count + x.RightQuantity.UnitInfos.Count);

        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, reduceConstants)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            Assert.Multiple(
                () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
        });
        Assert.Equal(expectedNumberOfConversions, conversionExpressions.Count);
    }

    private static void ConversionsWithAllUnits_ConvertToTargetQuantity(Dictionary<QuantityConversionKey, QuantityConversionFunction> conversionExpressions,
        QuantityInfo fromQuantityInfo, QuantityInfo toQuantityInfo)
    {
        Assert.All(fromQuantityInfo.UnitInfos, fromUnit =>
        {
            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantityInfo.UnitType);
            QuantityValue valueToConvert = 123.45m;
            IQuantity expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnit);

            Assert.Contains(conversionKey, conversionExpressions);
            QuantityConversionFunction conversionFunction = conversionExpressions[conversionKey];
            QuantityValue convertedValue = conversionFunction.Convert(valueToConvert);
            Assert.Equal(expectedQuantity, toQuantityInfo.From(convertedValue, (Enum)conversionFunction.TargetUnit));
        });
    }

    [Theory]
    [InlineData(true,  typeof(Density), true)]
    [InlineData(true,  typeof(Density), false)]
    [InlineData(false,  typeof(Density), true)]
    [InlineData(false, typeof(Density), false)]
    [InlineData(true,  typeof(SpecificVolume), true)]
    [InlineData(true,  typeof(SpecificVolume), false)]
    [InlineData(false,  typeof(SpecificVolume), true)]
    [InlineData(false, typeof(SpecificVolume), false)]
    public void AllCaching_WithSpecificNoneOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction, Type customizedType,
        bool customConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        // when removing the Density (with it's 56 units) the number of conversions drops from 156 to 100 (there are only 3 units of SpecificVolume which are all cached)
        var expectedNumberOfConversions = defaultConversions
            .Sum(x => (x.LeftQuantity.QuantityType == customizedType ? 0 : x.LeftQuantity.UnitInfos.Count) + (x.RightQuantity.QuantityType == customizedType ? 0 : x.RightQuantity.UnitInfos.Count));
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [customizedType] = new(ConversionCachingMode.None, customConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, conversionExpressions.Count), () =>
        {
            Assert.All(defaultConversions, conversion =>
            {
                if (conversion.LeftQuantity.QuantityType == customizedType)
                {
                    Assert.Multiple(() => { ContainsNoConversionsFor(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
                }
                else if (conversion.RightQuantity.QuantityType == customizedType)
                {
                    Assert.Multiple(() => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); },
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); });
                }
                else
                {
                    Assert.Multiple(
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
                }
            });
        });
    }
    [Theory]
    [InlineData(true,  true, false)]
    [InlineData(true,   false, false)]
    [InlineData(false,  true, false)]
    [InlineData(false, false, false)]
    [InlineData(true,  true, true)]
    [InlineData(true,   false, true)]
    [InlineData(false,  true, true)]
    [InlineData(false, false, true)]
    public void AllCaching_WithSpecificNoneOptionsForBoth_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction, bool specificVolumeConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        // when removing the Density (with its 56 units) and the SpecificVolume (with its 3 units) the number of conversions drops from 156 to 97
        var expectedNumberOfConversions = defaultConversions
            .Where(conversion => conversion != new QuantityConversion(Density.Info, SpecificVolume.Info))
            .Sum(conversion => conversion.LeftQuantity.UnitInfos.Count + conversion.RightQuantity.UnitInfos.Count);
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
        {
            [typeof(Density)] = new(ConversionCachingMode.None, densityConstantsReduction),
            [typeof(SpecificVolume)] = new(ConversionCachingMode.None, specificVolumeConstantsReduction)
        };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.Multiple(() => Assert.Equal(expectedNumberOfConversions, conversionExpressions.Count), () =>
        {
            Assert.All(defaultConversions, conversion =>
            {
                if (conversion.LeftQuantity.QuantityType == typeof(Density) || conversion.LeftQuantity.QuantityType == typeof(SpecificVolume))
                {
                    Assert.Multiple(() => { ContainsNoConversionsFor(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                        () => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
                }
                else
                {
                    Assert.Multiple(
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                        () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
                }
            });
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void AllCaching_WithSpecificBaseOnlyOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.BaseOnly, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            if (conversion.LeftQuantity.QuantityType == typeof(Density))
            {
                Assert.Multiple(
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
            else
            {
                Assert.Multiple(
                    () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void AllCaching_WithSpecificAllOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        // the only difference is in the constants reduction parameter (there should still be 156 conversions here)
        var expectedNumberOfConversions = defaultConversions.Sum(x => x.LeftQuantity.UnitInfos.Count + x.RightQuantity.UnitInfos.Count);
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.All, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            Assert.Multiple(
                () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
        });
        Assert.Equal(expectedNumberOfConversions, conversionExpressions.Count);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void BaseOnlyCaching_WithSpecificNoneOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.None, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.BaseOnly, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            if (conversion.LeftQuantity.QuantityType == typeof(Density))
            {
                Assert.Multiple(() => { ContainsNoConversionsFor(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
            else
            {
                Assert.Multiple(
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void BaseOnlyCaching_WithSpecificBaseOnlyOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.BaseOnly, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.BaseOnly, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            Assert.Multiple(
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void BaseOnlyCaching_WithSpecificAllOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.All, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.BaseOnly, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            if (conversion.LeftQuantity.QuantityType == typeof(Density))
            {
                Assert.Multiple(
                    () => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
            else
            {
                Assert.Multiple(
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void NoCaching_WithSpecificAllOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        // 56 units of Density
        var expectedNumberOfConversions = Density.Info.UnitInfos.Count;
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.All, densityConstantsReduction) };
        
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.None, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            if (conversion.LeftQuantity.QuantityType == typeof(Density))
            {
                Assert.Multiple(() => { ConversionsWithAllUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
            else
            {
                Assert.Multiple(
                    () => { ContainsNoConversionsFor(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
        });
        Assert.Equal(expectedNumberOfConversions, conversionExpressions.Count);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void NoCaching_WithSpecificBaseOnlyOptions_ReturnsSpecifiedUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.BaseOnly, densityConstantsReduction) };
        
        // there are currently only 3 conversions here (3 density units matching the 3 units of specific volume)
        var conversionExpressions = defaultConversions.GetConversionFunctions(ConversionCachingMode.None, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Assert.All(defaultConversions, conversion =>
        {
            if (conversion.LeftQuantity.QuantityType == typeof(Density))
            {
                Assert.Multiple(
                    () => { ConversionsWithBaseUnits_ConvertToTargetQuantity(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
            else
            {
                Assert.Multiple(() => { ContainsNoConversionsFor(conversionExpressions, conversion.LeftQuantity, conversion.RightQuantity); },
                    () => { ContainsNoConversionsFor(conversionExpressions, conversion.RightQuantity, conversion.LeftQuantity); });
            }
        });
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void NoCaching_WithSpecificNoneOptions_ReturnsNoUnitConversions(bool defaultConstantsReduction,
        bool densityConstantsReduction)
    {
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings).ToArray();
        var customQuantityOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(ConversionCachingMode.None, densityConstantsReduction) };
        
        Assert.Empty(defaultConversions.GetConversionFunctions(ConversionCachingMode.None, defaultConstantsReduction, customQuantityOptions));
    }

    private static void ContainsNoConversionsFor(Dictionary<QuantityConversionKey, QuantityConversionFunction> conversionExpressions,
        QuantityInfo fromQuantityInfo, QuantityInfo toQuantityInfo)
    {
        Assert.All(fromQuantityInfo.UnitInfos, fromUnit =>
        {
            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantityInfo.UnitType);
            Assert.DoesNotContain(conversionKey, conversionExpressions);
        });
    }

    [Theory]
    [InlineData(ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.BaseOnly, false)] // the conversions from/to the base units are already reduced by the CodeGen
    public void ReduceConstants_ReturnsUnitConversionsWithReducedCoefficients(ConversionCachingMode cachingMode, bool reduceConstants)
    {
        // Arrange
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings);
        
        // Act
        IEnumerable<ConvertValueDelegate> conversionExpressions = defaultConversions.GetConversionFunctions(cachingMode, reduceConstants)
            .Select(pair => pair.Value.Convert);
        
        // Assert
        Assert.All(conversionExpressions, valueDelegate => Assert.True(IsReduced(valueDelegate(QuantityValue.One))));
    }

    private static bool IsReduced(QuantityValue value)
    {
        (BigInteger numerator, BigInteger denominator) = value;
        return BigInteger.GreatestCommonDivisor(numerator, denominator) == BigInteger.One;
    }

    [Theory]
    [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.None, true)]
    [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.All, false)]
    [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.None, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.All, false)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.None, true)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.All, false)]
    public void GetConversionFunctions_WithCustomConversionsAndCustomCachingOptions_ReturnsUnitConversionsThatIncludeTheCustomConversions(
        ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction,
        ConversionCachingMode densityCachingMode, bool densityConstantsReduction)
    {
        // Arrange
        var customConversionFromDensity = new CustomQuantityConversionExpressionMapping(
            Density.Info[DensityUnit.KilogramPerCubicMeter],
            SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram],
            new ConversionExpression(2, null, -1));

        var customConversionFromSpecificVolume = new CustomQuantityConversionExpressionMapping(
            SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram],
            Density.Info[DensityUnit.KilogramPerCubicMeter],
            new ConversionExpression(new QuantityValue(1, 2), null, -1));

        var conversionMappingOptions = new QuantityConversionMappingOptions
        {
            ConversionExpressions =
            {
                {
                    new UnitConversionMapping(customConversionFromDensity.SourceUnit.UnitKey, customConversionFromDensity.TargetUnit.UnitKey),
                    customConversionFromDensity
                },
                {
                    new UnitConversionMapping(customConversionFromSpecificVolume.SourceUnit.UnitKey, customConversionFromSpecificVolume.TargetUnit.UnitKey),
                    customConversionFromSpecificVolume
                }
            }
        };
        var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
        {
            { new QuantityConversion(Density.Info, SpecificVolume.Info), conversionMappingOptions }
        };
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(densityCachingMode, densityConstantsReduction) };
        IEnumerable<QuantityConversion> defaultConversions = UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityConversions(Quantity.Provider.DefaultConversions);
        
        // Act
        var conversionExpressions = defaultConversions.GetConversionFunctions(conversionOptions, defaultCachingMode, defaultConstantsReduction, customCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        // Assert
        Assert.Multiple(() =>
            {
                // the returned result contains all our custom conversions
                Assert.All(conversionMappingOptions.ConversionExpressions, pair =>
                {
                    UnitConversionMapping unitConversionKey = pair.Key;
                    CustomQuantityConversionExpressionMapping expressionMapping = pair.Value;
                    ConversionExpression conversionExpression = expressionMapping.ConversionExpression;
                    var conversionKey = new QuantityConversionKey(unitConversionKey.FromUnitKey, unitConversionKey.ToUnitKey.UnitType);
                    Assert.Contains(conversionKey, conversionExpressions);
                    Assert.Equal(expressionMapping.TargetUnit.UnitKey, conversionExpressions[conversionKey].TargetUnit);
                    Assert.Equal(conversionExpression.Evaluate(10), conversionExpressions[conversionKey].Convert(10));
                });
            },
            () =>
            {
                // all generated conversions from a DensityUnit are a function of the custom conversion expressions in our customConversionFromDensity
                Assert.All(conversionExpressions.Where(x => x.Key.FromUnit.UnitType == typeof(DensityUnit)),
                    pair =>
                    {
                        QuantityConversionKey conversionKey = pair.Key;
                        QuantityConversionFunction conversionFunction = pair.Value;

                        UnitInfo<Density, DensityUnit> sourceUnit = Density.Info[conversionKey.FromUnit.ToUnit<DensityUnit>()];
                        UnitInfo<SpecificVolume, SpecificVolumeUnit> targetUnit =
                            SpecificVolume.Info[conversionFunction.TargetUnit.ToUnit<SpecificVolumeUnit>()];
                        QuantityValue valueToConvert = 10;
                        QuantityValue valueInSourceConversionUnit = customConversionFromDensity.SourceUnit.GetValueFrom(valueToConvert, sourceUnit);
                        QuantityValue valueInTargetConversionUnit = customConversionFromDensity.ConversionExpression.Evaluate(valueInSourceConversionUnit);
                        QuantityValue expectedValue = targetUnit.GetValueFrom(valueInTargetConversionUnit, customConversionFromDensity.TargetUnit);

                        Assert.Equal(expectedValue, conversionFunction.Convert(valueToConvert));
                        if (densityConstantsReduction)
                        {
                            Assert.True(IsReduced(conversionFunction.Convert(1)));
                        }
                    });
            },
            () =>
            {
                // all generated conversions from a SpecificVolumeUnit are a function of the custom conversion expressions in our customConversionFromSpecificVolume
                Assert.All(conversionExpressions.Where(x => x.Key.FromUnit.UnitType == typeof(SpecificVolumeUnit)),
                    pair =>
                    {
                        QuantityConversionKey conversionKey = pair.Key;
                        QuantityConversionFunction conversionFunction = pair.Value;

                        UnitInfo<SpecificVolume, SpecificVolumeUnit> sourceUnit = SpecificVolume.Info[conversionKey.FromUnit.ToUnit<SpecificVolumeUnit>()];
                        UnitInfo<Density, DensityUnit> targetUnit = Density.Info[conversionFunction.TargetUnit.ToUnit<DensityUnit>()];
                        QuantityValue valueToConvert = 10;
                        QuantityValue valueInSourceConversionUnit = customConversionFromSpecificVolume.SourceUnit.GetValueFrom(valueToConvert, sourceUnit);
                        QuantityValue valueInTargetConversionUnit =
                            customConversionFromSpecificVolume.ConversionExpression.Evaluate(valueInSourceConversionUnit);
                        QuantityValue expectedValue = targetUnit.GetValueFrom(valueInTargetConversionUnit, customConversionFromSpecificVolume.TargetUnit);

                        Assert.Equal(expectedValue, conversionFunction.Convert(valueToConvert));
                        if (defaultConstantsReduction)
                        {
                            Assert.True(IsReduced(conversionFunction.Convert(1)));
                        }
                    });
            }
        );
    }
    
    [Theory]
    [InlineData(ConversionCachingMode.None, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, false)]
    public void GetConversionFunctions_WithUnitConversionMappings_ReturnsTheSpecifiedConversions(ConversionCachingMode conversionCachingMode, bool reduceConstants)
    {
        // Arrange
        var conversionMappingOptions = new QuantityConversionMappingOptions
        {
            CustomUnitMappings =
            {
                {
                    new UnitConversionMapping(DensityUnit.GramPerLiter, SpecificVolumeUnit.CubicMeterPerKilogram),
                    new CustomQuantityConversionUnitMapping(Density.Info[DensityUnit.GramPerLiter],
                        SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram])
                },
                {
                    new UnitConversionMapping(DensityUnit.GramPerCubicCentimeter, SpecificVolumeUnit.CubicFootPerPound),
                    new CustomQuantityConversionUnitMapping(Density.Info[DensityUnit.GramPerCubicCentimeter],
                        SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound])
                },
                {
                    new UnitConversionMapping(DensityUnit.NanogramPerMilliliter, SpecificVolumeUnit.CubicFootPerPound),
                    new CustomQuantityConversionUnitMapping(Density.Info[DensityUnit.NanogramPerMilliliter],
                        SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound])
                },
                {
                    new UnitConversionMapping(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.NanogramPerMilliliter),
                    new CustomQuantityConversionUnitMapping(SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound],
                        Density.Info[DensityUnit.NanogramPerMilliliter])
                },
                {
                    new UnitConversionMapping(SpecificVolumeUnit.CubicMeterPerKilogram, DensityUnit.MilligramPerMilliliter),
                    new CustomQuantityConversionUnitMapping(SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram],
                        Density.Info[DensityUnit.MilligramPerMilliliter])
                },
            }
        };
        var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>()
        {
            {
                new QuantityConversion(Density.Info, SpecificVolume.Info),
                conversionMappingOptions
            }
        };
        IEnumerable<QuantityConversion> defaultConversions = UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityConversions(Quantity.Provider.DefaultConversions);
        var emptyCachingOptions = new Dictionary<Type, ConversionCacheOptions>();
        
        // Act
        var conversionExpressions = defaultConversions.GetConversionFunctions(conversionOptions, conversionCachingMode, reduceConstants, emptyCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
        
        // Assert
        Assert.All(conversionMappingOptions.CustomUnitMappings, mapping =>
        {
            UnitInfo fromUnit = mapping.Value.SourceUnit;
            UnitInfo toUnit = mapping.Value.TargetUnit;
            QuantityValue valueToConvert = 123.45m;
            QuantityValue expectedValue = toUnit.QuantityInfo.ConvertFrom(valueToConvert, fromUnit).As(toUnit.Value);
            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toUnit.QuantityInfo.UnitType);
            Assert.Contains(conversionKey, conversionExpressions);
            Assert.Equal(expectedValue, conversionExpressions[conversionKey].Convert(valueToConvert));
            Assert.Equal(toUnit.UnitKey, conversionExpressions[conversionKey].TargetUnit);
            // this maybe a bit redundant but that's the only covering line for the ResultType property (its only used for the default equality contract)
            Assert.Equal(conversionKey.ResultType, conversionExpressions[conversionKey].TargetUnit.UnitType); 
            if (reduceConstants)
            {
                Assert.True(IsReduced(conversionExpressions[conversionKey].Convert(1)));
            }
        });
        
        if (conversionCachingMode == ConversionCachingMode.None)
        {
            Assert.Equal(conversionMappingOptions.CustomUnitMappings.Count, conversionExpressions.Count);
        }
    }

    [Theory]
    [InlineData(ConversionCachingMode.None, true)]
    [InlineData(ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, false)]
    public void GetConversionFunctions_WithUnitConversionMappingsAndCustomFunctions_ReturnsTheMergedConversions(ConversionCachingMode conversionCachingMode, bool reduceConstants)
    {
        // Arrange
        var customConversionFromDensity = new CustomQuantityConversionExpressionMapping(
            Density.Info[DensityUnit.PoundPerCubicFoot],
            SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound],
            new ConversionExpression(2, null, -1));
        var customConversionFromSpecificVolume = new CustomQuantityConversionExpressionMapping(
            SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound],
            Density.Info[DensityUnit.PoundPerCubicFoot],
            new ConversionExpression(new QuantityValue(1, 2), null, -1));
        var conversionMappingOptions = new QuantityConversionMappingOptions
        {
            ConversionExpressions =
            {
                {
                    new UnitConversionMapping(customConversionFromDensity.SourceUnit.UnitKey, customConversionFromDensity.TargetUnit.UnitKey),
                    customConversionFromDensity
                },
                {
                    new UnitConversionMapping(customConversionFromSpecificVolume.SourceUnit.UnitKey, customConversionFromSpecificVolume.TargetUnit.UnitKey),
                    customConversionFromSpecificVolume
                }
            },
            CustomUnitMappings =
            {
                {
                    new UnitConversionMapping(DensityUnit.GramPerLiter, SpecificVolumeUnit.CubicMeterPerKilogram), new CustomQuantityConversionUnitMapping(
                        Density.Info[DensityUnit.GramPerLiter],
                        SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram])
                },
                {
                    new UnitConversionMapping(DensityUnit.NanogramPerMilliliter, SpecificVolumeUnit.CubicFootPerPound), new CustomQuantityConversionUnitMapping(
                        Density.Info[DensityUnit.NanogramPerMilliliter],
                        SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound])
                }
            }
        };
        var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
        {
            { new QuantityConversion(Density.Info, SpecificVolume.Info), conversionMappingOptions }
        };
        IEnumerable<QuantityConversion> defaultConversions = UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityConversions(Quantity.Provider.DefaultConversions);
        var emptyCachingOptions = new Dictionary<Type, ConversionCacheOptions>();
        
        // Act
        var conversionExpressions = defaultConversions.GetConversionFunctions(conversionOptions, conversionCachingMode, reduceConstants, emptyCachingOptions)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.All(conversionMappingOptions.ConversionExpressions, pair =>
            {
                var conversionKey = new QuantityConversionKey(pair.Key.FromUnitKey, pair.Key.ToUnitKey.UnitType);
                Assert.True(conversionExpressions.ContainsKey(conversionKey));
                Assert.Equal(pair.Value.ConversionExpression.Evaluate(10), conversionExpressions[conversionKey].Convert(10));
            });
        }, () =>
        {
            Assert.All(conversionMappingOptions.CustomUnitMappings, pair =>
            {
                var conversionKey = new QuantityConversionKey(pair.Key.FromUnitKey, pair.Key.ToUnitKey.UnitType);
                UnitInfo sourceUnit = pair.Value.SourceUnit;
                UnitInfo targetUnit = pair.Value.TargetUnit;
                QuantityValue valueToConvert = 10;
                QuantityValue valueInSourceConversionUnit = customConversionFromDensity.SourceUnit.GetValueFrom(valueToConvert, sourceUnit);
                QuantityValue valueInTargetConversionUnit = customConversionFromDensity.ConversionExpression.Evaluate(valueInSourceConversionUnit);
                QuantityValue expectedValue = targetUnit.GetValueFrom(valueInTargetConversionUnit, customConversionFromDensity.TargetUnit);
                Assert.True(conversionExpressions.ContainsKey(conversionKey));
                Assert.Equal(expectedValue, conversionExpressions[conversionKey].Convert(valueToConvert));
                if (reduceConstants)
                {
                    Assert.True(IsReduced(conversionExpressions[conversionKey].Convert(1)));
                }
            });
        });
        
        if (conversionCachingMode == ConversionCachingMode.None)
        {
            Assert.Equal(Density.Units.Count + SpecificVolume.Units.Count,
                conversionExpressions.Count); // an expression is provided for each of the units (irrespective of the caching mode)
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetConversionFunctions_WithInvalidConversionDimensions_And_Caching_None_ReturnsEmpty(bool reduceConstants)
    {
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversionMapping> defaultConversionMappings = Quantity.Provider.DefaultConversions;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(defaultConversionMappings)
            .Append(new QuantityConversion(Mass.Info, Volume.Info)).ToList();

        Assert.Empty(defaultConversions.GetConversionFunctions(ConversionCachingMode.None, reduceConstants));
    }

    [Theory]
    [InlineData(ConversionCachingMode.BaseOnly, true)]
    [InlineData(ConversionCachingMode.All, true)]
    [InlineData(ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, false)]
    public void GetConversionFunctions_WithInvalidConversionDimensions_And_Caching_ThrowsInvalidConversionException(ConversionCachingMode cachingMode, bool reduceConstants)
    {
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IEnumerable<QuantityConversionMapping> defaultConversionMappings = Quantity.Provider.DefaultConversions;
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(defaultConversionMappings)
            .Append(new QuantityConversion(Mass.Info, Volume.Info)).ToList();

        Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(cachingMode, reduceConstants).ToList());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetConversionFunctions_WithNoMatchingBaseUnits_And_Caching_BaseOnly_ReturnsEmpty(bool reduceConstants)
    {
        // we simulate a target quantity without any base units
        var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
        IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];
        
        Assert.Empty(defaultConversions.GetConversionFunctions(ConversionCachingMode.BaseOnly, reduceConstants));
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetConversionFunctions_WithNoMatchingBaseUnits_And_Caching_All_ThrowsInvalidConversionException(bool reduceConstants)
    {
        // we simulate a target quantity without any base units
        var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
        IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];

        Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(ConversionCachingMode.All, reduceConstants).ToList());
    }

    // [Theory]
    // [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.None, false)]
    // public void GetConversionFunctions_WithUnitConversionMappings_WithInvalidDimensions_ThrowsInvalidConversionException(ConversionCachingMode cachingMode, bool defaultConstantsReduction,
    //     ConversionCachingMode massCachingMode,  bool massConstantsReduction)
    // {
    //     QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
    //     IEnumerable<QuantityConversionMapping> defaultConversionMappings = Quantity.Provider.DefaultConversions;
    //     IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(defaultConversionMappings)
    //         .Append(new QuantityConversion(Mass.Info, Volume.Info)).ToList();
    //     var conversionMappingOptions = new QuantityConversionMappingOptions
    //     {
    //         CustomUnitMappings =
    //         {
    //             {
    //                 new UnitConversionMapping(Mass.BaseUnit, Volume.BaseUnit), new CustomQuantityConversionUnitMapping(Mass.Info.BaseUnitInfo, Volume.Info.BaseUnitInfo)
    //             }
    //         }
    //     };
    //     var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
    //     {
    //         { new QuantityConversion(Mass.Info, Volume.Info), conversionMappingOptions }
    //     };
    //     
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Mass)] = new(massCachingMode, massConstantsReduction) };
    //     
    //     Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(conversionOptions, cachingMode, defaultConstantsReduction, customCachingOptions).ToList());
    // }

    // [Theory]
    // [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.None, false)]
    // [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.None, false)]
    // public void GetConversionFunctions_WithUnitConversionMappings_WithNoBaseUnits_ThrowsInvalidConversionException(ConversionCachingMode cachingMode, bool defaultConstantsReduction,
    //     ConversionCachingMode massCachingMode,  bool massConstantsReduction)
    // {
    //     // we simulate a target quantity without any base units
    //     var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
    //         unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
    //     IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];
    //     
    //     var conversionMappingOptions = new QuantityConversionMappingOptions
    //     {
    //         CustomUnitMappings =
    //         {
    //             {
    //                 new UnitConversionMapping(Density.BaseUnit, SpecificVolume.BaseUnit), new CustomQuantityConversionUnitMapping(densityInfo.BaseUnitInfo, SpecificVolume.Info.BaseUnitInfo)
    //             }
    //         }
    //     };
    //     var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
    //     {
    //         { new QuantityConversion(densityInfo, SpecificVolume.Info), conversionMappingOptions }
    //     };
    //     
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
    //     {
    //         [typeof(Mass)] = new(massCachingMode, massConstantsReduction)
    //     };
    //     
    //     Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(conversionOptions, cachingMode, defaultConstantsReduction, customCachingOptions).ToList());
    // }

    [Theory]
    [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.None, false)]
    [InlineData(ConversionCachingMode.None, true, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.BaseOnly, true, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.BaseOnly, false)]
    [InlineData(ConversionCachingMode.All, true, ConversionCachingMode.All, false)]
    [InlineData(ConversionCachingMode.None, false, ConversionCachingMode.All, false)]
    [InlineData(ConversionCachingMode.BaseOnly, false, ConversionCachingMode.All, false)]
    [InlineData(ConversionCachingMode.All, false, ConversionCachingMode.All, false)]
    public void GetConversionFunctions_WithUnitConversionMappings_WithNoBaseUnits_ThrowsInvalidConversionException(ConversionCachingMode cachingMode, bool defaultConstantsReduction,
        ConversionCachingMode massCachingMode,  bool massConstantsReduction)
    {
        // we simulate a target quantity without any base units
        var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
        IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];
        
        var conversionMappingOptions = new QuantityConversionMappingOptions
        {
            CustomUnitMappings =
            {
                // {
                //     new UnitConversionMapping(Density.BaseUnit, SpecificVolume.BaseUnit), new CustomQuantityConversionUnitMapping(densityInfo.BaseUnitInfo, SpecificVolume.Info.BaseUnitInfo)
                // },
                {
                    new UnitConversionMapping(SpecificVolume.BaseUnit, Density.BaseUnit), new CustomQuantityConversionUnitMapping(SpecificVolume.Info.BaseUnitInfo, densityInfo.BaseUnitInfo)
                }
            }
        };
        var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
        {
            { new QuantityConversion(densityInfo, SpecificVolume.Info), conversionMappingOptions }
        };
        
        var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
        {
            [typeof(Density)] = new(cachingMode, defaultConstantsReduction),
            [typeof(SpecificVolume)] = new(massCachingMode, massConstantsReduction)
        };
        
        Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(conversionOptions, ConversionCachingMode.All, true, customCachingOptions).ToList());
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetConversionFunctions_WithInvalidCachingMode_ThrowsArgumentException(bool reduceConstants)
    {
        QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
        IReadOnlyCollection<QuantityConversionMapping> conversionMappings = Quantity.Provider.DefaultConversions;
        const ConversionCachingMode invalidCachingMode = (ConversionCachingMode)(-1);
        IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(conversionMappings);
        
        Assert.Multiple(() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => defaultConversions.GetConversionFunctions(invalidCachingMode, reduceConstants)),
            () =>
            {
                var emptyOptions = new Dictionary<Type, ConversionCacheOptions>();
                Assert.Throws<ArgumentOutOfRangeException>(() => defaultConversions.GetConversionFunctions(invalidCachingMode, reduceConstants, emptyOptions)
                    .ToList());
            },
            () =>
            {
                var validOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new() };
                Assert.Throws<ArgumentOutOfRangeException>(() => defaultConversions.GetConversionFunctions(invalidCachingMode, reduceConstants, validOptions)
                    .ToList());
            },
            () =>
            {
                var invalidOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(invalidCachingMode) };
                Assert.Throws<ArgumentOutOfRangeException>(() => defaultConversions.GetConversionFunctions(default, reduceConstants, invalidOptions)
                    .ToList());
            },
            () =>
            {
                var invalidOptions = new Dictionary<Type, ConversionCacheOptions> { [typeof(Density)] = new(invalidCachingMode) };
                var conversionMappingOptions = new QuantityConversionMappingOptions
                {
                    CustomUnitMappings =
                    {
                        {
                            new UnitConversionMapping(DensityUnit.GramPerLiter, SpecificVolumeUnit.CubicMeterPerKilogram), new CustomQuantityConversionUnitMapping(
                                Density.Info[DensityUnit.GramPerLiter],
                                SpecificVolume.Info[SpecificVolumeUnit.CubicMeterPerKilogram])
                        },
                        {
                            new UnitConversionMapping(DensityUnit.NanogramPerMilliliter, SpecificVolumeUnit.CubicFootPerPound), new CustomQuantityConversionUnitMapping(
                                Density.Info[DensityUnit.NanogramPerMilliliter],
                                SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound])
                        }
                    }
                };
                var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>
                {
                    { new QuantityConversion(Density.Info, SpecificVolume.Info), conversionMappingOptions }
                };
                
                Assert.Throws<ArgumentOutOfRangeException>(() => defaultConversions.GetConversionFunctions(conversionOptions, default, reduceConstants, invalidOptions)
                    .ToList());
            });
    }

    
    // [Theory]
    // [InlineData(true)]
    // [InlineData(false)]
    // public void GetConversionFunctions_WithInvalidConversionDimensions_And_CachingOptions_None_ReturnsEmpty(bool reduceConstants)
    // {
    //     QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
    //     IEnumerable<QuantityConversionMapping> defaultConversionMappings = Quantity.Provider.DefaultConversions;
    //     IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(defaultConversionMappings)
    //         .Append(new QuantityConversion(Mass.Info, Volume.Info)).ToList();
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
    //     {
    //         [typeof(Mass)] = new(ConversionCachingMode.None, reduceConstants),
    //         [typeof(Volume)] = new(ConversionCachingMode.None, reduceConstants)
    //     };
    //
    //     var conversions = defaultConversions.GetConversionFunctions(ConversionCachingMode.All, reduceConstants, customCachingOptions)
    //         .ToDictionary(pair => pair.Key, pair => pair.Value);
    //     
    //     Assert.NotEmpty(conversions);
    //     Assert.False(conversions.ContainsKey(new QuantityConversionKey(Mass.BaseUnit, typeof(Volume))));
    // }
    //
    // [Theory]
    // [InlineData(ConversionCachingMode.BaseOnly, true)]
    // [InlineData(ConversionCachingMode.All, true)]
    // [InlineData(ConversionCachingMode.BaseOnly, false)]
    // [InlineData(ConversionCachingMode.All, false)]
    // public void GetConversionFunctions_WithInvalidConversionDimensions_And_CachingOptions_ThrowsInvalidConversionException(ConversionCachingMode cachingMode, bool reduceConstants)
    // {
    //     QuantityInfoLookup quantityInfoLookup = UnitsNetSetup.Default.QuantityInfoLookup;
    //     IEnumerable<QuantityConversionMapping> defaultConversionMappings = Quantity.Provider.DefaultConversions;
    //     IEnumerable<QuantityConversion> defaultConversions = quantityInfoLookup.GetQuantityConversions(defaultConversionMappings)
    //         .Append(new QuantityConversion(Mass.Info, Volume.Info)).ToList();
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
    //     {
    //         [typeof(Mass)] = new(cachingMode, reduceConstants),
    //         [typeof(Volume)] = new(cachingMode, reduceConstants)
    //     };
    //
    //     Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(ConversionCachingMode.None, reduceConstants, customCachingOptions).ToList());
    // }
    //
    // [Theory]
    // [InlineData(true)]
    // [InlineData(false)]
    // public void GetConversionFunctions_WithNoMatchingBaseUnits_And_CachingOptions_BaseOnly_ReturnsEmpty(bool reduceConstants)
    // {
    //     // we simulate a target quantity without any base units
    //     var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
    //         unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
    //     IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
    //     {
    //         [typeof(Density)] = new(ConversionCachingMode.BaseOnly, reduceConstants),
    //         [typeof(SpecificVolume)] = new(ConversionCachingMode.BaseOnly, reduceConstants)
    //     };
    //     
    //     Assert.Empty(defaultConversions.GetConversionFunctions(ConversionCachingMode.None, reduceConstants, customCachingOptions));
    // }
    //
    // [Theory]
    // [InlineData(true)]
    // [InlineData(false)]
    // public void GetConversionFunctions_WithNoMatchingBaseUnits_And_CachingOptions_All_ThrowsInvalidConversionException(bool reduceConstants)
    // {
    //     // we simulate a target quantity without any base units
    //     var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
    //         unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
    //     IEnumerable<QuantityConversion> defaultConversions = [new(densityInfo, SpecificVolume.Info)];
    //     var customCachingOptions = new Dictionary<Type, ConversionCacheOptions>
    //     {
    //         [typeof(Density)] = new(ConversionCachingMode.All, reduceConstants),
    //         [typeof(SpecificVolume)] = new(ConversionCachingMode.All, reduceConstants)
    //     };
    //
    //     Assert.Throws<InvalidConversionException>(() => defaultConversions.GetConversionFunctions(ConversionCachingMode.None, reduceConstants, customCachingOptions).ToList());
    // }


    [Theory]
    [InlineData(AreaUnit.SquareMeter, ReciprocalAreaUnit.InverseSquareMeter, 1)]
    [InlineData(AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter, 1)]
    [InlineData(AreaUnit.SquareFoot, ReciprocalAreaUnit.InverseSquareFoot, 1)]
    [InlineData(AreaUnit.Acre, ReciprocalAreaUnit.InverseSquareKilometer, 247.1053814671653)]
    public void GetQuantityConversionFrom_QuantityWithInverseDimensions_ReturnsTheClosestMatchingUnit(AreaUnit fromUnit, ReciprocalAreaUnit expectedUnit, double expectedCoefficient)
    {
        QuantityConversionFunction conversionFunction = ReciprocalArea.Info.GetQuantityConversionFrom(Area.Info[fromUnit]);
        
        Assert.Equal(expectedUnit, conversionFunction.TargetUnit.ToUnit<ReciprocalAreaUnit>());
        Assert.Equal(expectedCoefficient, conversionFunction.Convert(QuantityValue.One).ToDouble(), 14);
    }

    [Theory]
    [InlineData(MassConcentrationUnit.KilogramPerCubicMeter, DensityUnit.KilogramPerCubicMeter, 1)]
    [InlineData(MassConcentrationUnit.GramPerCubicMeter, DensityUnit.GramPerCubicMeter, 1)]
    [InlineData(MassConcentrationUnit.PoundPerCubicFoot, DensityUnit.PoundPerCubicFoot, 1)]
    [InlineData(MassConcentrationUnit.GramPerLiter, DensityUnit.GramPerLiter, 1)]
    [InlineData(MassConcentrationUnit.PoundPerUSGallon, DensityUnit.PoundPerUSGallon, 1)]
    public void GetQuantityConversionFrom_QuantityWithSameDimensions_ReturnsTheClosestMatchingUnit(MassConcentrationUnit fromUnit, DensityUnit expectedUnit, double expectedCoefficient)
    {
        QuantityConversionFunction conversionFunction = Density.Info.GetQuantityConversionFrom(MassConcentration.Info[fromUnit]);
        
        Assert.Equal(expectedUnit, conversionFunction.TargetUnit.ToUnit<DensityUnit>());
        Assert.Equal(expectedCoefficient, conversionFunction.Convert(QuantityValue.One));
    }

    [Theory]
    [InlineData(MassFractionUnit.DecimalFraction, RatioUnit.DecimalFraction, 1)]
    [InlineData(MassFractionUnit.Percent, RatioUnit.Percent, 1)]
    [InlineData(MassFractionUnit.PartPerMillion, RatioUnit.PartPerMillion, 1)]
    [InlineData(MassFractionUnit.GramPerKilogram, RatioUnit.PartPerThousand, 1)]
    [InlineData(MassFractionUnit.HectogramPerGram, RatioUnit.DecimalFraction, 100)]
    public void GetQuantityConversionFrom_DimensionlessQuantity_ReturnsTheClosestMatchingUnit(MassFractionUnit fromUnit, RatioUnit expectedUnit, double expectedCoefficient)
    {
        QuantityConversionFunction conversionFunction = Ratio.Info.GetQuantityConversionFrom(MassFraction.Info[fromUnit]);
        
        Assert.Equal(expectedUnit, conversionFunction.TargetUnit.ToUnit<RatioUnit>());
        Assert.Equal(expectedCoefficient, conversionFunction.Convert(QuantityValue.One));
    }

    [Fact]
    public void GetQuantityConversionFrom_QuantityWithIncompatibleBaseDimensions_ThrowsInvalidConversionException()
    {
        Assert.Throws<InvalidConversionException>(() => Mass.Info.GetQuantityConversionFrom(Volume.Info.BaseUnitInfo));
    }

    [Fact]
    public void GetQuantityConversionFrom_QuantityWithIncompatibleBaseUnits_ThrowsInvalidConversionException()
    {
        UnitInfo sourceUnitInfo = MassConcentration.Info.BaseUnitInfo;
        // we simulate a target quantity without any base units
        var targetQuantityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
        
        Assert.Throws<InvalidConversionException>(() => targetQuantityInfo.GetQuantityConversionFrom(sourceUnitInfo));
    }
}
