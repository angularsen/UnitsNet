// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitConverterTest
    {
        /// <summary>
        ///     Generates a collection of <see cref="QuantityConverterBuildOptions" /> instances with all combinations of
        ///     constructor parameter values.
        /// </summary>
        /// <returns>
        ///     An <see cref="IEnumerable{T}" /> of <see cref="QuantityConverterBuildOptions" /> containing all possible
        ///     configurations
        ///     of freezing, caching modes, and constant reduction options.
        /// </returns>
        private static IEnumerable<QuantityConverterBuildOptions> GetQuantityConverterBuildOptions()
        {
            bool[] frozenOptions = [true, false];
            ConversionCachingMode[] cachingOptions = [ConversionCachingMode.None, ConversionCachingMode.BaseOnly, ConversionCachingMode.All];
            bool[] reductionOptions = [true, false];
            return frozenOptions.SelectMany(freeze => cachingOptions.SelectMany(cachingMode => reductionOptions.Select(reduce =>
                new QuantityConverterBuildOptions(freeze, cachingMode, reduce))));
        }

        /// <summary>
        ///     Gets the test data for the unit converter tests.
        /// </summary>
        /// <value>
        ///     A collection of tuples containing:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>A <see cref="bool" /> indicating whether to freeze the conversion.</description>
        ///         </item>
        ///         <item>
        ///             <description>A <see cref="ConversionCachingMode" /> specifying the caching mode.</description>
        ///         </item>
        ///         <item>
        ///             <description>A <see cref="bool" /> indicating whether to reduce constants.</description>
        ///         </item>
        ///     </list>
        /// </value>
        public static TheoryData<bool, ConversionCachingMode, bool> ConverterTestOptions =>
            new()
            {
                { true, ConversionCachingMode.None, true },
                { true, ConversionCachingMode.BaseOnly, true },
                { true, ConversionCachingMode.All, true },
                { false, ConversionCachingMode.None, true },
                { false, ConversionCachingMode.BaseOnly, true },
                { false, ConversionCachingMode.All, true },
                { true, ConversionCachingMode.None, false },
                { true, ConversionCachingMode.BaseOnly, false },
                { true, ConversionCachingMode.All, false },
                { false, ConversionCachingMode.None, false },
                { false, ConversionCachingMode.BaseOnly, false },
                { false, ConversionCachingMode.All, false }
            };
        
        // [Fact]
        // public void CopyConstructorCopiesCoversionFunctions()
        // {
        //     Length ConversionFunction(Length from) => Length.FromInches(18);
        //
        //     var unitConverter = new UnitConverter();
        //     unitConverter.SetConversionFunction<Length>(LengthUnit.Meter, LengthUnit.Inch, ConversionFunction);
        //
        //     var copiedUnitConverter = new UnitConverter(unitConverter);
        //     var foundConversionFunction = copiedUnitConverter.GetConversionFunction<Length>(LengthUnit.Meter, LengthUnit.Inch);
        //     Assert.NotNull(foundConversionFunction);
        // }

        // [Fact]
        // public void CustomConversionWithSameQuantityType()
        // {
        //     Length ConversionFunction(Length from) => Length.FromInches(18);
        //
        //     var unitConverter = new UnitConverter();
        //     unitConverter.SetConversionFunction<Length>(LengthUnit.Meter, LengthUnit.Inch, ConversionFunction);
        //
        //     var foundConversionFunction = unitConverter.GetConversionFunction<Length>(LengthUnit.Meter, LengthUnit.Inch);
        //     var converted = foundConversionFunction(Length.FromMeters(1.0));
        //
        //     Assert.Equal(Length.FromInches(18), converted);
        // }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void GetConversionFunction_WithSameQuantityType(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Meter, LengthUnit.Meter);
                QuantityValue converted = conversionFunction(1);

                Assert.Equal(1, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Centimeter, LengthUnit.Meter);
                QuantityValue converted = conversionFunction(10);

                Assert.Equal(0.1m, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Meter, LengthUnit.Centimeter);
                QuantityValue converted = conversionFunction(1);

                Assert.Equal(100, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Millimeter, LengthUnit.Centimeter);
                QuantityValue converted = conversionFunction(10);

                Assert.Equal(1, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Inch, LengthUnit.Inch);
                QuantityValue converted = conversionFunction(1);

                Assert.Equal(1, converted);
            });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryGetConversionFunction_WithSameQuantityType_ReturnsTrue(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(1, conversionFunction!(1));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Centimeter, LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(0.1m, conversionFunction!(10));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, LengthUnit.Centimeter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(100, conversionFunction!(1));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Millimeter, LengthUnit.Centimeter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(1, conversionFunction!(10));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Inch, LengthUnit.Inch, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(1, conversionFunction!(1));
            });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void GetConversionFunction_WithCustomUnitConversion(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var customLengthInfo = Length.LengthInfo.CreateDefault(unitDefinitions =>
                unitDefinitions.Configure(LengthUnit.Inch, definition => definition.WithConversionFromBase(18)));

            var unitParser = new UnitParser([customLengthInfo]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Meter, LengthUnit.Inch);
                QuantityValue converted = conversionFunction(1);

                Assert.Equal(18, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Inch, LengthUnit.Meter);
                QuantityValue converted = conversionFunction(18);

                Assert.Equal(1, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Meter, LengthUnit.Meter);
                QuantityValue converted = conversionFunction(18);

                Assert.Equal(18, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Inch, LengthUnit.Inch);
                QuantityValue converted = conversionFunction(18);

                Assert.Equal(18, converted);
            }, () =>
            {
                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(LengthUnit.Meter, LengthUnit.Centimeter);
                QuantityValue converted = conversionFunction(18);

                Assert.Equal(1800, converted);
            });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryGetConversionFunction_WithCustomUnitConversion_ReturnsTrue(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var customLengthInfo = Length.LengthInfo.CreateDefault(unitDefinitions =>
                unitDefinitions.Configure(LengthUnit.Inch, definition => definition.WithConversionFromBase(18)));

            var unitParser = new UnitParser([customLengthInfo]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, LengthUnit.Inch, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(18, conversionFunction!(1));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Inch, LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(1, conversionFunction!(18));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(18, conversionFunction!(18));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Inch, LengthUnit.Inch, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(18, conversionFunction!(18));
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, LengthUnit.Centimeter, out ConvertValueDelegate? conversionFunction);
                Assert.True(success);
                Assert.Equal(1800, conversionFunction!(18));
            });
        }
        
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void GetConversionFunction_WithUnknownUnit_ThrowsUnitNotFoundException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info, Mass.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction(LengthUnit.Meter, (LengthUnit)(-1)));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction((LengthUnit)(-1), LengthUnit.Meter));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction(MassUnit.Kilogram, (LengthUnit)(-1)));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction((LengthUnit)(-1), MassUnit.Kilogram));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction(VolumeUnit.Milliliter, (LengthUnit)(-1)));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => unitConverter.GetConversionFunction((LengthUnit)(-1), VolumeUnit.Milliliter));
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryGetConversionFunction_WithUnknownUnit_ReturnsFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info, Mass.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, (LengthUnit)(-1), out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction((LengthUnit)(-1), LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(MassUnit.Kilogram, (LengthUnit)(-1), out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction((LengthUnit)(-1), MassUnit.Kilogram, out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(VolumeUnit.Milliliter, (LengthUnit)(-1), out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction((LengthUnit)(-1), VolumeUnit.Milliliter, out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void GetConversionFunction_WithIncompatibleQuantities_ThrowsInvalidConversionException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info, Mass.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
                {
                    Assert.Throws<InvalidConversionException>(() => unitConverter.GetConversionFunction(LengthUnit.Meter, MassUnit.Kilogram));
                },
                () =>
                {
                    Assert.Throws<InvalidConversionException>(() => unitConverter.GetConversionFunction(MassUnit.Kilogram, LengthUnit.Meter));
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryGetConversionFunction_WithInvalidUnit_ReturnsFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var unitParser = new UnitParser([Length.Info, Mass.Info]);
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(unitParser, convertOptions);

            Assert.Multiple(() =>
            {
                var success = unitConverter.TryGetConversionFunction(LengthUnit.Meter, MassUnit.Kilogram, out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            }, () =>
            {
                var success = unitConverter.TryGetConversionFunction(MassUnit.Kilogram, LengthUnit.Meter, out ConvertValueDelegate? conversionFunction);
                Assert.False(success);
                Assert.Null(conversionFunction);
            });
        }
        
        [Theory]
        [InlineData(1, LengthUnit.Meter, ReciprocalLengthUnit.InverseMeter, 1)]
        [InlineData(1, LengthUnit.Centimeter, ReciprocalLengthUnit.InverseCentimeter, 1)]
        [InlineData(1, LengthUnit.Centimeter, ReciprocalLengthUnit.InverseMillimeter, 0.1)]
        [InlineData(1, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 10)]
        [InlineData(10, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 1)]
        [InlineData(-10, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, -1)]
        [InlineData(0, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 0)]
        [InlineData(double.NegativeInfinity, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 0)]
        [InlineData(double.NaN, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, double.NaN)]
        public void GetConversionFunction_WithCompatibleQuantityType(double fromValue, LengthUnit fromUnit, ReciprocalLengthUnit toUnit, double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Length.Info, ReciprocalLength.Info]), options);

                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(fromUnit, toUnit);
                QuantityValue converted = conversionFunction(fromValue);

                Assert.Equal(expectedValue, converted);
            });
        }
        
        [Theory]
        [InlineData(1, LengthUnit.Meter, ReciprocalLengthUnit.InverseMeter, 1)]
        [InlineData(1, LengthUnit.Centimeter, ReciprocalLengthUnit.InverseCentimeter, 1)]
        [InlineData(1, LengthUnit.Centimeter, ReciprocalLengthUnit.InverseMillimeter, 0.1)]
        [InlineData(1, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 10)]
        [InlineData(10, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 1)]
        [InlineData(-10, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, -1)]
        [InlineData(0, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 0)]
        [InlineData(double.NegativeInfinity, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, 0)]
        [InlineData(double.NaN, LengthUnit.Millimeter, ReciprocalLengthUnit.InverseCentimeter, double.NaN)]
        public void TryGetConversionFunction_WithCompatibleQuantityType(double fromValue, LengthUnit fromUnit, ReciprocalLengthUnit toUnit, double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Length.Info, ReciprocalLength.Info]), options);

                var success = unitConverter.TryGetConversionFunction(fromUnit, toUnit, out ConvertValueDelegate? conversionFunction);
                
                Assert.True(success);
                Assert.Equal(expectedValue, conversionFunction!(fromValue));
            });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConversionToSameUnit_ReturnsSameQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var unitConverter = UnitConverter.Create(new UnitParser([]), convertOptions);

            ConvertValueDelegate foundConversionFunction = unitConverter.GetConversionFunction(HowMuchUnit.ATon, HowMuchUnit.ATon);
            QuantityValue converted = foundConversionFunction(39); 

            Assert.Equal(39, converted);
        }

        [Theory]
        [InlineData(1, HowMuchUnit.Some, HowMuchUnit.Some, 1)]
        [InlineData(1, HowMuchUnit.Some, HowMuchUnit.ATon, 0.1)]
        [InlineData(1, HowMuchUnit.Some, HowMuchUnit.AShitTon, 0.01)]
        [InlineData(1, HowMuchUnit.ATon, HowMuchUnit.Some, 10)]
        [InlineData(1, HowMuchUnit.AShitTon, HowMuchUnit.Some, 100)]
        public void ConversionForUnitsOfCustomQuantity(double fromValue, HowMuchUnit fromUnit, HowMuchUnit toUnit, double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([HowMuch.Info]), options);

                ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(fromUnit, toUnit);
                QuantityValue converted = conversionFunction(fromValue);

                Assert.Equal(expectedValue, converted);
            });
        }

        [Theory]
        [InlineData(1, MassUnit.Tonne, HowMuchUnit.ATon, 1)]
        [InlineData(1000, MassUnit.Kilogram, HowMuchUnit.ATon, 1)]
        [InlineData(100, MassUnit.Kilogram, HowMuchUnit.Some, 1)]
        [InlineData(10000, MassUnit.Kilogram, HowMuchUnit.AShitTon, 1)]
        public void GetConversionFunction_WithCustomConversionForDifferentQuantities(double fromValue, MassUnit fromUnit, HowMuchUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                        // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                        conversionOptions.SetCustomConversion<Mass, HowMuch>()));

                Assert.Multiple(() =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(fromUnit, toUnit);
                        QuantityValue converted = conversionFunction(fromValue);
                        Assert.Equal(expectedValue, converted);
                    },
                    () =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(toUnit, fromUnit);
                        QuantityValue converted = conversionFunction(expectedValue);
                        Assert.Equal(fromValue, converted);
                    });
            });
        }

        [Theory]
        [InlineData(1, MassUnit.Tonne, HowMuchUnit.ATon, 1)]
        [InlineData(1000, MassUnit.Kilogram, HowMuchUnit.ATon, 1)]
        [InlineData(100, MassUnit.Kilogram, HowMuchUnit.Some, 1)]
        [InlineData(10000, MassUnit.Kilogram, HowMuchUnit.AShitTon, 1)]
        public void TryGetConversionFunction_WithCustomConversionForDifferentQuantities(double fromValue, MassUnit fromUnit, HowMuchUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                        // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                        conversionOptions.SetCustomConversion<Mass, HowMuch>()));

                Assert.Multiple(() =>
                    {
                        var success = unitConverter.TryGetConversionFunction(fromUnit, toUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(expectedValue, conversionFunction!(fromValue));
                    },
                    () =>
                    {
                        var success = unitConverter.TryGetConversionFunction(toUnit, fromUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(fromValue, conversionFunction!(expectedValue));
                    });
            });
        }

        [Theory]
        [InlineData(1, VolumeUnit.Liter, HowMuchUnit.Some, 1)]
        [InlineData(1000, VolumeUnit.Milliliter, HowMuchUnit.Some, 1)]
        [InlineData(10, VolumeUnit.Liter, HowMuchUnit.ATon, 1)]
        [InlineData(1, VolumeUnit.Kiloliter, HowMuchUnit.AShitTon, 10)]
        public void GetConversionFunction_WithCustomConversionExpressionForDifferentQuantities(double fromValue, VolumeUnit fromUnit, HowMuchUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Volume.Info, HowMuch.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        conversionOptions
                            // since the dimensions / base units are incompatible we have to explicitly specify a conversion expression
                            .SetCustomConversion<Volume, HowMuch>() 
                            .SetCustomConversion(VolumeUnit.Liter, HowMuchUnit.Some, QuantityValue.One, true)));

                Assert.Multiple(() =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(fromUnit, toUnit);
                        QuantityValue converted = conversionFunction(fromValue);
                        Assert.Equal(expectedValue, converted);
                    },
                    () =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(toUnit, fromUnit);
                        QuantityValue converted = conversionFunction(expectedValue);
                        Assert.Equal(fromValue, converted);
                    });
            });
        }

        [Theory]
        [InlineData(1, VolumeUnit.Liter, HowMuchUnit.Some, 1)]
        [InlineData(1000, VolumeUnit.Milliliter, HowMuchUnit.Some, 1)]
        [InlineData(10, VolumeUnit.Liter, HowMuchUnit.ATon, 1)]
        [InlineData(1, VolumeUnit.Kiloliter, HowMuchUnit.AShitTon, 10)]
        public void TryGetConversionFunction_WithCustomConversionExpressionForDifferentQuantities(double fromValue, VolumeUnit fromUnit, HowMuchUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([Volume.Info, HowMuch.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        conversionOptions
                            // since the dimensions / base units are incompatible we have to explicitly specify a conversion expression
                            .SetCustomConversion<Volume, HowMuch>() 
                            .SetCustomConversion(VolumeUnit.Liter, HowMuchUnit.Some, QuantityValue.One, true)));

                Assert.Multiple(() =>
                    {
                        var success = unitConverter.TryGetConversionFunction(fromUnit, toUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(expectedValue, conversionFunction!(fromValue));
                    },
                    () =>
                    {
                        var success = unitConverter.TryGetConversionFunction(toUnit, fromUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(fromValue, conversionFunction!(expectedValue));
                    });
            });
        }

        [Theory]
        [InlineData(1, MassFractionUnit.DecimalFraction, RatioUnit.DecimalFraction, 1)]
        [InlineData(1, MassFractionUnit.DecimalFraction, RatioUnit.PartPerThousand, 1000)]
        [InlineData(100, MassFractionUnit.Percent, RatioUnit.DecimalFraction, 1)]
        [InlineData(1, MassFractionUnit.GramPerKilogram, RatioUnit.PartPerThousand, 1)]
        public void GetConversionFunction_WithCustomConversionForDifferentDimensionlessQuantities(double fromValue, MassFractionUnit fromUnit, RatioUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([MassFraction.Info, Ratio.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        // since both quantities are dimensionless it is assumed that the quantities can be converted using their BaseUnit (i.e. the DecimalFraction)
                        conversionOptions.SetCustomConversion<MassFraction, Ratio>()));

                Assert.Multiple(() =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(fromUnit, toUnit);
                        QuantityValue converted = conversionFunction(fromValue);
                        Assert.Equal(expectedValue, converted);
                    },
                    () =>
                    {
                        ConvertValueDelegate conversionFunction = unitConverter.GetConversionFunction(toUnit, fromUnit);
                        QuantityValue converted = conversionFunction(expectedValue);
                        Assert.Equal(fromValue, converted);
                    });
            });
        }

        [Theory]
        [InlineData(1, MassFractionUnit.DecimalFraction, RatioUnit.DecimalFraction, 1)]
        [InlineData(1, MassFractionUnit.DecimalFraction, RatioUnit.PartPerThousand, 1000)]
        [InlineData(100, MassFractionUnit.Percent, RatioUnit.DecimalFraction, 1)]
        [InlineData(1, MassFractionUnit.GramPerKilogram, RatioUnit.PartPerThousand, 1)]
        public void TryGetConversionFunction_WithCustomConversionForDifferentDimensionlessQuantities(double fromValue, MassFractionUnit fromUnit, RatioUnit toUnit,
            double expectedValue)
        {
            IEnumerable<QuantityConverterBuildOptions> converterOptions = GetQuantityConverterBuildOptions();

            Assert.All(converterOptions, options =>
            {
                var unitConverter = UnitConverter.Create(new UnitParser([MassFraction.Info, Ratio.Info]),
                    options.WithImplicitConversionOptions(conversionOptions =>
                        // since both quantities are dimensionless it is assumed that the quantities can be converted using their BaseUnit (i.e. the DecimalFraction)
                        conversionOptions.SetCustomConversion<MassFraction, Ratio>()));

                Assert.Multiple(() =>
                    {
                        var success = unitConverter.TryGetConversionFunction(fromUnit, toUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(expectedValue, conversionFunction!(fromValue));
                    },
                    () =>
                    {
                        var success = unitConverter.TryGetConversionFunction(toUnit, fromUnit, out ConvertValueDelegate? conversionFunction);
                        Assert.True(success);
                        Assert.Equal(fromValue, conversionFunction!(expectedValue));
                    });
            });
        }

        [Theory]
        [InlineData(0, 0, "length", "meter", "centimeter")]
        [InlineData(0, 0, "Length", "Meter", "Centimeter")]
        [InlineData(100, 1, "Length", "Meter", "Centimeter")]
        [InlineData(1, 1000, "Mass", "Gram", "Kilogram")]
        [InlineData(1000, 1, "ElectricCurrent", "Kiloampere", "Ampere")]
        public void ConvertByName_ConvertsTheValueToGivenUnit(double expectedValue, double inputValue, string quantityTypeName, string fromUnit, string toUnit)
        {
            Assert.Equal(expectedValue, UnitConverter.ConvertByName(inputValue, quantityTypeName, fromUnit, toUnit));
        }

        [Fact]
        public void ConvertByName_QuantityCaseInsensitive()
        {
            Assert.Equal(0, UnitConverter.ConvertByName(0, "length", "Meter", "Centimeter"));
        }

        [Fact]
        public void ConvertByName_UnitTypeCaseInsensitive()
        {
            Assert.Equal(0, UnitConverter.ConvertByName(0, "Length", "meter", "Centimeter"));
        }

        [Theory]
        [InlineData(1, "UnknownQuantity", "Meter", "Centimeter")]
        public void ConvertByName_ThrowsQuantityNotFoundExceptionOnUnknownQuantity(double inputValue, string quantityTypeName, string fromUnit, string toUnit)
        {
            Assert.Throws<QuantityNotFoundException>(() => UnitConverter.ConvertByName(inputValue, quantityTypeName, fromUnit, toUnit));
        }

        [Theory]
        [InlineData(1, "Length", "UnknownFromUnit", "Centimeter")]
        [InlineData(1, "Length", "Meter", "UnknownToUnit")]
        public void ConvertByName_ThrowsUnitNotFoundExceptionOnUnknownFromOrToUnit(double inputValue, string quantityTypeName, string fromUnit, string toUnit)
        {
            Assert.Throws<UnitNotFoundException>(() => UnitConverter.ConvertByName(inputValue, quantityTypeName, fromUnit, toUnit));
        }

        [Theory]
        [InlineData(1, "UnknownQuantity", "Meter", "Centimeter")]
        [InlineData(1, "Length", "UnknownFromUnit", "Centimeter")]
        [InlineData(1, "Length", "Meter", "UnknownToUnit")]
        public void TryConvertByName_ReturnsFalseForInvalidInput(double inputValue, string quantityTypeName, string fromUnit, string toUnit)
        {
            Assert.False(UnitConverter.TryConvertByName(inputValue, quantityTypeName, fromUnit, toUnit, out _));
        }

        [Theory]
        [InlineData(0, 0, "Length", "Meter", "Centimeter")]
        [InlineData(100, 1, "Length", "Meter", "Centimeter")]
        [InlineData(1, 1000, "Mass", "Gram", "Kilogram")]
        [InlineData(1000, 1, "ElectricCurrent", "Kiloampere", "Ampere")]
        public void TryConvertByName_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, string quantityTypeName, string fromUnit,
            string toUnit)
        {
            Assert.True(UnitConverter.TryConvertByName(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(0, 0, "Length", "Meter", "Centimeter")] // base -> non-base (zero)
        [InlineData(100, 1, "Length", "Meter", "Centimeter")] // base -> non-base
        [InlineData(10, 1, "Length", "Centimeter", "Millimeter")] // non-base -> non-base
        [InlineData(1, 1, "Mass", "Gram", "Gram")] // same-units (non-base)
        [InlineData(1, 1000, "Mass", "Gram", "Kilogram")] // non-base -> base
        [InlineData(2000, 2, "Mass", "Gram", "Milligram")] // non-base -> non-base
        public void TryConvertValueByName_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, string quantityTypeName, string fromUnit,
            string toUnit)
        {
            Assert.Multiple(() =>
            {
                var converter = new UnitConverter(UnitParser.Default);

                Assert.True(converter.TryConvertValueByName(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            }, () =>
            {
                var converter = UnitConverter.Create(UnitParser.Default,
                    new QuantityConverterBuildOptions(defaultCachingMode: ConversionCachingMode.None, freeze: false));

                Assert.True(converter.TryConvertValueByName(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            }, () =>
            {
                var converter = UnitConverter.Create(UnitParser.Default,
                    new QuantityConverterBuildOptions(defaultCachingMode: ConversionCachingMode.None, freeze: true)
                        .WithCustomCachingOptions<Length>(new ConversionCacheOptions()));

                Assert.True(converter.TryConvertValueByName(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            });
        }

        [Theory]
        [InlineData(0, 0, "Length", "m", "cm")]
        [InlineData(1, 1, "Length", "cm", "cm")]
        [InlineData(100, 1, "Length", "m", "cm")]
        [InlineData(1, 1000, "Mass", "g", "kg")]
        [InlineData(1000, 1, "ElectricCurrent", "kA", "A")]
        public void ConvertByAbbreviation_ConvertsTheValueToGivenUnit(double expectedValue, double inputValue, string quantityTypeName, string fromUnit,
            string toUnit)
        {
            Assert.Equal(expectedValue, UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit));
            Assert.Equal(expectedValue, UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, CultureInfo.InvariantCulture));
            Assert.Equal(expectedValue, UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, "en-US"));
        }

        [Theory]
        [InlineData(1, "UnknownQuantity", "m", "cm")]
        public void ConvertByAbbreviation_ThrowsUnitNotFoundExceptionOnUnknownQuantity(double inputValue, string quantityTypeName, string fromUnit,
            string toUnit)
        {
            Assert.Throws<QuantityNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit));
            Assert.Throws<QuantityNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, CultureInfo.InvariantCulture));
            Assert.Throws<QuantityNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, "en-US"));
        }

        [Theory]
        [InlineData(1, "Length", "UnknownFromUnit", "cm")]
        [InlineData(1, "Length", "m", "UnknownToUnit")]
        public void ConvertByAbbreviation_ThrowsUnitNotFoundExceptionOnUnknownFromOrToUnitAbbreviation(double inputValue, string quantityTypeName,
            string fromUnit, string toUnit)
        {
            Assert.Throws<UnitNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit));
            Assert.Throws<UnitNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, CultureInfo.InvariantCulture));
            Assert.Throws<UnitNotFoundException>(() => UnitConverter.ConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, "en-US"));
        }

        [Theory]
        [InlineData(1, "UnknownQuantity", "m", "cm", "en-US")]
        [InlineData(1, "Length", "UnknownFromUnit", "cm", "en-US")]
        [InlineData(1, "Length", "m", "UnknownToUnit", "en-US")]
        public void TryConvertByAbbreviation_ReturnsFalseForInvalidInput(double inputValue, string quantityTypeName, string fromUnit, string toUnit,
            string culture)
        {
            Assert.False(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, null, out _));
            Assert.False(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, CultureInfo.GetCultureInfo(culture), out _));
            Assert.False(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out _, culture));
        }

        [Theory]
        [InlineData(0, 0, "Length", "m", "cm", "en-US")]
        [InlineData(100, 1, "Length", "m", "cm", "en-US")]
        [InlineData(1, 1000, "Mass", "g", "kg", "en-US")]
        [InlineData(1000, 1, "ElectricCurrent", "kA", "A", "en-US")]
        public void TryConvertByAbbreviation_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, string quantityTypeName,
            string fromUnit, string toUnit, string culture)
        {
            Assert.Multiple(
            () =>
            {
                Assert.True(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, CultureInfo.GetCultureInfo(culture), out QuantityValue result), "TryConvertByAbbreviation() return value.");
                Assert.Equal(expectedValue, result);
            },
            () =>
            {
                Assert.True(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result, culture), "TryConvertByAbbreviation() return value.");
                Assert.Equal(expectedValue, result); 
            });
        }

        [Theory] 
        // note: this test is culture-dependant, however using the international units should work with any "CurrentCulture"
        [InlineData(0, 0, "Length", "m", "cm")]
        [InlineData(1, 1, "Length", "cm", "cm")]
        [InlineData(100, 1, "Length", "m", "cm")]
        [InlineData(1, 1000, "Mass", "g", "kg")]
        [InlineData(1000, 1, "ElectricCurrent", "kA", "A")]
        public void TryConvertByAbbreviation_WithDefaultCulture_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, string quantityTypeName,
            string fromUnit, string toUnit)
        {
            Assert.True(UnitConverter.TryConvertByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
            Assert.Equal(expectedValue, result);
        }

        [Theory] 
        // note: this test is culture-dependant, however using the international units should work with any "CurrentCulture"
        [InlineData(0, 0, "Length", "m", "cm")]
        [InlineData(1, 1, "Length", "cm", "cm")]
        [InlineData(100, 1, "Length", "m", "cm")]
        [InlineData(1, 1000, "Mass", "g", "kg")]
        [InlineData(1000, 1, "ElectricCurrent", "kA", "A")]
        public void TryConvertValueByAbbreviation_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, string quantityTypeName,
            string fromUnit, string toUnit)
        {
            UnitParser unitParser = UnitParser.Default;
            Assert.Multiple(() =>
            {
                var converter = new UnitConverter(unitParser);

                Assert.True(converter.TryConvertValueByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            }, () =>
            {
                var converter = UnitConverter.Create(unitParser, new QuantityConverterBuildOptions(defaultCachingMode: ConversionCachingMode.None, freeze: false));

                Assert.True(converter.TryConvertValueByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            }, () =>
            {
                var converter = UnitConverter.Create(unitParser, new QuantityConverterBuildOptions(defaultCachingMode: ConversionCachingMode.None, freeze: true)
                    .WithCustomCachingOptions<Length>(new ConversionCacheOptions(cachingMode: ConversionCachingMode.All)));

                Assert.True(converter.TryConvertValueByAbbreviation(inputValue, quantityTypeName, fromUnit, toUnit, out QuantityValue result));
                Assert.Equal(expectedValue, result);
            });
        }

        [Theory]
        [InlineData(0, 0, LengthUnit.Meter, LengthUnit.Centimeter)] // base -> non-base (zero)
        [InlineData(100, 1, LengthUnit.Meter, LengthUnit.Centimeter)]  // base -> non-base
        [InlineData(1, 1, LengthUnit.Centimeter, LengthUnit.Centimeter)] // same units (non-base)
        [InlineData(1, 1000, MassUnit.Gram, MassUnit.Kilogram)]     // non-base -> base
        [InlineData(1000, 1, MassUnit.Gram, MassUnit.Milligram)]    // non-base -> non-base
        [InlineData(1000, 1, ElectricCurrentUnit.Kiloampere, ElectricCurrentUnit.Ampere)]
        [InlineData(0.1, 10, AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)] // inverse relationship
        public void Convert_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, Enum fromUnit, Enum toUnit)
        {
            QuantityValue convertedValue = UnitConverter.Convert(inputValue, fromUnit, toUnit);
            Assert.Equal(expectedValue, convertedValue);
        }
        
        [Theory]
        [InlineData(0, 0, LengthUnit.Meter, LengthUnit.Centimeter)] // base -> non-base (zero)
        [InlineData(100, 1, LengthUnit.Meter, LengthUnit.Centimeter)]  // base -> non-base
        [InlineData(1, 1, LengthUnit.Centimeter, LengthUnit.Centimeter)] // same units (non-base)
        [InlineData(1, 1000, MassUnit.Gram, MassUnit.Kilogram)]     // non-base -> base
        [InlineData(1000, 1, MassUnit.Gram, MassUnit.Milligram)]    // non-base -> non-base
        [InlineData(1000, 1, ElectricCurrentUnit.Kiloampere, ElectricCurrentUnit.Ampere)]
        [InlineData(0.1, 10, AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)] // inverse relationship
        public void TryConvert_ReturnsTrueOnSuccessAndOutputsResult(double expectedValue, double inputValue, Enum fromUnit, Enum toUnit)
        {
            Assert.True(UnitConverter.TryConvert(inputValue, fromUnit, toUnit, out QuantityValue result));
            Assert.Equal(expectedValue, result);
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.All(Quantity.Infos, quantityInfo =>
            {
                Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                {
                    Enum fromUnit = fromUnitInfo.Value;
                    Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                    {
                        Enum toUnit = toUnitInfo.Value;
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                        QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                        Assert.Equal(expectedValue, convertedValue);
                    });
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.All(Quantity.Infos, quantityInfo =>
            {
                Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                {
                    Enum fromUnit = fromUnitInfo.Value;
                    Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                    {
                        Enum toUnit = toUnitInfo.Value;
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                        Assert.True(success);
                        Assert.Equal(expectedValue, convertedValue);
                    });
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitWithinSameGenericQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                MassUnit fromUnit = fromUnitInfo.Value;
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    MassUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                    Assert.Equal(expectedValue, convertedValue);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitWithinSameGenericQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                MassUnit fromUnit = fromUnitInfo.Value;
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    MassUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                    Assert.True(success);
                    Assert.Equal(expectedValue, convertedValueFromUnit);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldConvertQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.All(Quantity.Infos, quantityInfo =>
            {
                Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                {
                    IQuantity quantityToConvert = fromUnitInfo.From(valueToConvert);
                    Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                    {
                        Enum toUnit = toUnitInfo.Value;
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                        IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                        Assert.IsType(quantityInfo.QuantityType, convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldConvertQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.All(Quantity.Infos, quantityInfo =>
            {
                Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                {
                    IQuantity quantityToConvert = fromUnitInfo.From(valueToConvert);
                    Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                    {
                        Enum toUnit = toUnitInfo.Value;
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType(quantityInfo.QuantityType, convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldConvertQuantityToUnitWithinSameConcreteQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Temperature, TemperatureUnit> quantityInfo = Temperature.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                Temperature quantityToConvert = fromUnitInfo.From(valueToConvert);
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    TemperatureUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    Temperature convertedQuantity = converter.ConvertToUnit(quantityToConvert, toUnit);

                    Assert.Equal(toUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldConvertQuantityToUnitWithinSameConcreteQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Temperature, TemperatureUnit> quantityInfo = Temperature.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                Temperature quantityToConvert = fromUnitInfo.From(valueToConvert);
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    TemperatureUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    var success = converter.TryConvertToUnit(quantityToConvert, toUnit, out Temperature convertedQuantity);

                    Assert.True(success);
                    Assert.Equal(toUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertQuantityToUnitWithinSameConcreteQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(UnitParser.Default, convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Temperature, TemperatureUnit> quantityInfo = Temperature.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                Temperature quantityToConvert = fromUnitInfo.From(valueToConvert);
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    TemperatureUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    var success = converter.TryConvertValue(quantityToConvert, toUnit, out QuantityValue convertedValue);

                    Assert.True(success);
                    Assert.Equal(expectedValue, convertedValue);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldThrowUnitNotFoundExceptionForUnknownUnits(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertValue(valueToConvert, MassUnit.Gram, MassUnit.Milligram));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertValue(new Mass(valueToConvert, MassUnit.Gram), MassUnit.Milligram));
                },
                () =>
                {
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertValue(valueToConvert, Mass.BaseUnit, Length.BaseUnit));
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertValue(valueToConvert, Length.BaseUnit, Mass.BaseUnit));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldReturnFalseForUnknownUnits(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.False(converter.TryConvertValue(valueToConvert, MassUnit.Gram, MassUnit.Milligram, out _));
                },
                () =>
                {
                    Assert.False(converter.TryConvertValue(new Mass(valueToConvert, MassUnit.Gram), MassUnit.Milligram, out _));
                },
                () =>
                {
                    Assert.False(converter.TryConvertValue(valueToConvert, Mass.BaseUnit, Length.BaseUnit, out _));
                    Assert.False(converter.TryConvertValue(valueToConvert, Length.BaseUnit, Mass.BaseUnit, out _));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldThrowUnitNotFoundExceptionForUnknownUnits(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    var quantityToConvert = new Mass(1, MassUnit.Gram);
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertToUnit(quantityToConvert, MassUnit.Milligram));
                },
                () =>
                {
                    IQuantity quantityToConvert = new Mass(1, MassUnit.Gram);
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertTo(quantityToConvert, MassUnit.Milligram));
                },
                () =>
                {
                    var quantityToConvert = new Length(1, LengthUnit.Meter);
                    Assert.Throws<UnitNotFoundException>(() => converter.ConvertTo(quantityToConvert, MassUnit.Milligram));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldReturnFalseForUnknownUnits(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info]), convertOptions);
            
            Assert.Multiple(() =>
                {
                    var quantityToConvert = new Mass(1, MassUnit.Gram);
                    var success = converter.TryConvertToUnit(quantityToConvert, MassUnit.Milligram, out Mass _);
                    Assert.False(success);
                },
                () =>
                {
                    IQuantity quantityToConvert = new Mass(1, MassUnit.Gram);
                    var success = converter.TryConvertTo(quantityToConvert, MassUnit.Milligram, out IQuantity? _);
                    Assert.False(success);
                },
                () =>
                {
                    var quantityToConvert = new Length(1, LengthUnit.Meter);
                    var success = converter.TryConvertTo(quantityToConvert, MassUnit.Milligram, out IQuantity? _);
                    Assert.False(success);
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_UnknownRelation_Throws_InvalidConversionException(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info, Mass.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    // left to right
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(Length.Zero, MassUnit.Milligram));
                },
                () =>
                {
                    // right to left
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(Mass.Zero, LengthUnit.Meter));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_UnknownRelation_ReturnsFalse(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Length.Info, Mass.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    var success = converter.TryConvertTo(Length.Zero, MassUnit.Milligram, out IQuantity? _);
                    Assert.False(success);
                },
                () =>
                {
                    var success = converter.TryConvertTo(Mass.Zero, LengthUnit.Meter, out IQuantity? _);
                    Assert.False(success);
                });
        }

        [Theory]
        [InlineData( true,true)]
        [InlineData( true,false)]
        [InlineData(false,true)]
        [InlineData(false,false)]
        public void ConvertTo_QuantityWithIncompatibleDimensions_Throws_InvalidConversionException(bool freeze, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, ConversionCachingMode.None, reduceConstants)
                // no conversion expressions can be determined using the base dimensions (a conversion function needs to be explicitly provided)
                .WithImplicitConversionOptions(options => options.SetCustomConversion<Length, Mass>());
            var converter = UnitConverter.Create(new UnitParser([Length.Info, Mass.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    // left to right
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(Length.Zero, MassUnit.Milligram));
                },
                () =>
                {
                    // right to left
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(Mass.Zero, LengthUnit.Meter));
                });
        }

        [Theory]
        [InlineData( true,true)]
        [InlineData( true,false)]
        [InlineData(false,true)]
        [InlineData(false,false)]
        public void TryConvertTo_QuantityWithIncompatibleDimensions_ReturnsFalse(bool freeze, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, ConversionCachingMode.None, reduceConstants)
                // no conversion expressions can be determined using the base dimensions (a conversion function needs to be explicitly provided)
                .WithImplicitConversionOptions(options => options.SetCustomConversion<Length, Mass>());
            var converter = UnitConverter.Create(new UnitParser([Length.Info, Mass.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    var success = converter.TryConvertTo(Length.Zero, MassUnit.Milligram, out IQuantity? _);
                    Assert.False(success);
                },
                () =>
                {
                    var success = converter.TryConvertTo(Mass.Zero, LengthUnit.Meter, out IQuantity? _);
                    Assert.False(success);
                });
        }

        [Theory]
        [InlineData( true,true)]
        [InlineData( true,false)]
        [InlineData(false,true)]
        [InlineData(false,false)]
        public void ConvertTo_QuantityWithoutBaseUnits_Throws_InvalidConversionException(bool freeze, bool reduceConstants)
        {
            // we simulate a target quantity without any base units
            var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
                unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, ConversionCachingMode.None, reduceConstants)
                // no conversion expressions can be determined without the base units (a conversion function needs to be explicitly provided)
                .WithImplicitConversionOptions(options => options.SetCustomConversion<Density, MassConcentration>());
            var converter = UnitConverter.Create(new UnitParser([densityInfo, MassConcentration.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    // left to right
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(Density.Zero, MassConcentrationUnit.KilogramPerCubicMeter));
                },
                () =>
                {
                    // right to left
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(MassConcentration.Zero, DensityUnit.KilogramPerCubicMeter));
                });
        }

        [Theory]
        [InlineData( true,true)]
        [InlineData( true,false)]
        [InlineData(false,true)]
        [InlineData(false,false)]
        public void TryConvertTo_QuantityWithoutBaseUnits_ReturnsFalse(bool freeze, bool reduceConstants)
        {
            // we simulate a target quantity without any base units
            var densityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
                unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, ConversionCachingMode.None, reduceConstants)
                // no conversion expressions can be determined without the base units (a conversion function needs to be explicitly provided)
                .WithImplicitConversionOptions(options => options.SetCustomConversion<Density, MassConcentration>());
            var converter = UnitConverter.Create(new UnitParser([densityInfo, MassConcentration.Info]), convertOptions);

            Assert.Multiple(() =>
                {
                    var success = converter.TryConvertTo(Density.Zero, MassConcentrationUnit.KilogramPerCubicMeter, out IQuantity? _);
                    Assert.False(success);
                },
                () =>
                {
                    var success = converter.TryConvertTo(MassConcentration.Zero, DensityUnit.KilogramPerCubicMeter, out IQuantity? _);
                    Assert.False(success);
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueForCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        MassUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    QuantityInfo quantityInfo = HowMuch.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueForCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        MassUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    QuantityInfo quantityInfo = HowMuch.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldConvertCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        Mass quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            Mass convertedQuantity = converter.ConvertToUnit(quantityToConvert, toUnit);

                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    QuantityInfo quantityInfo = HowMuch.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        IQuantity quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.IsType<HowMuch>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldConvertCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        Mass quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            var success = converter.TryConvertToUnit(quantityToConvert, toUnit, out Mass convertedQuantity);

                            Assert.True(success);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    QuantityInfo quantityInfo = HowMuch.Info;
                    Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
                    {
                        IQuantity quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                            var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                            Assert.True(success);
                            Assert.IsType<HowMuch>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                Mass quantityToConvert = fromUnitInfo.From(valueToConvert);
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    MassUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    QuantityValue convertedValue = converter.ConvertValue(quantityToConvert, toUnit);

                    Assert.Equal(expectedValue, convertedValue);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertCustomQuantityToUnitWithinSameQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            QuantityInfo<Mass, MassUnit> quantityInfo = Mass.Info;
            Assert.All(quantityInfo.UnitInfos, fromUnitInfo =>
            {
                Mass quantityToConvert = fromUnitInfo.From(valueToConvert);
                Assert.All(quantityInfo.UnitInfos, toUnitInfo =>
                {
                    MassUnit toUnit = toUnitInfo.Value;
                    QuantityValue expectedValue = toUnitInfo.GetValueFrom(valueToConvert, fromUnitInfo);

                    var success = converter.TryConvertValue(quantityToConvert, toUnit, out QuantityValue convertedValue);

                    Assert.True(success);
                    Assert.Equal(expectedValue, convertedValue);
                });
            });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<SpecificVolume, SpecificVolumeUnit> toQuantityInfo = SpecificVolume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            SpecificVolume expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<SpecificVolume, SpecificVolumeUnit> toQuantityInfo = SpecificVolume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            SpecificVolume expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                    // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                    options.SetCustomConversion<Mass, HowMuch>());
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Mass.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            IQuantity expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Mass, MassUnit> toQuantityInfo = Mass.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            Mass expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                    // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                    options.SetCustomConversion<Mass, HowMuch>());
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Mass.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            IQuantity expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Mass, MassUnit> toQuantityInfo = Mass.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            Mass expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                    // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                    options.SetCustomConversion<Mass, HowMuch>());
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Mass.Info.UnitInfos, fromUnitInfo =>
                    {
                        var quantityToConvert = new Mass(valueToConvert, fromUnitInfo.Value);
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            IQuantity expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        var quantityToConvert = new HowMuch(valueToConvert, fromUnitInfo.Value);
                        QuantityInfo<Mass, MassUnit> toQuantityInfo = Mass.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            Mass expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits (in our case these are the Mass.Tonne and HowMuch.ATon)
                    // we don't have to specify a conversion expression (it is assumed that "1 Tonne" is equal to "1 ATon")
                    options.SetCustomConversion<Mass, HowMuch>());
            var converter = UnitConverter.Create(new UnitParser([Mass.Info, HowMuch.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Mass.Info.UnitInfos, fromUnitInfo =>
                    {
                        var quantityToConvert = new Mass(valueToConvert, fromUnitInfo.Value);
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            IQuantity expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                            Assert.True(success);
                            Assert.Equal(toUnit, convertedQuantity!.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        var quantityToConvert = new HowMuch(valueToConvert, fromUnitInfo.Value);
                        QuantityInfo<Mass, MassUnit> toQuantityInfo = Mass.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassUnit toUnit = toUnitInfo.Value;
                            Mass expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                            Assert.True(success);
                            Assert.Equal(toUnit, convertedQuantity!.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversionViaBase(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            // unlike the conversion between HowMuch and Mass where HowMuch.BaseUnitInfo.BaseUnits == Undefined
            // here we have: Density.BaseUnitInfo.BaseUnits == MassConcentration.BaseUnitInfo.BaseUnits (an optimized scenario)
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits
                    // we don't have to specify a conversion expression (it is assumed that "1 Density.BaseUnit" is equal to "1 MassConcentration.BaseUnit")
                    options.SetCustomConversion<Density, MassConcentration>());
            var converter = UnitConverter.Create(new UnitParser([Density.Info, MassConcentration.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<MassConcentration, MassConcentrationUnit> toQuantityInfo = MassConcentration.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassConcentrationUnit toUnit = toUnitInfo.Value;
                            MassConcentration expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(MassConcentration.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassConcentrationUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversionViaBase(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            // unlike the conversion between HowMuch and Mass where HowMuch.BaseUnitInfo.BaseUnits == Undefined
            // here we have: Density.BaseUnitInfo.BaseUnits == MassConcentration.BaseUnitInfo.BaseUnits (an optimized scenario)
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since the dimensions of the two quantities are compatible and there is at least one pair of units that have the same BaseUnits
                    // we don't have to specify a conversion expression (it is assumed that "1 Density.BaseUnit" is equal to "1 MassConcentration.BaseUnit")
                    options.SetCustomConversion<Density, MassConcentration>());
            var converter = UnitConverter.Create(new UnitParser([Density.Info, MassConcentration.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<MassConcentration, MassConcentrationUnit> toQuantityInfo = MassConcentration.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassConcentrationUnit toUnit = toUnitInfo.Value;
                            MassConcentration expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                },
                () =>
                {
                    Assert.All(MassConcentration.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassConcentrationUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValueFromUnit);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValueFromUnit);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitOfAnotherDimensionlessQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since both quantities are dimensionless it is assumed that the quantities can be converted using their BaseUnit (i.e. the DecimalFraction)
                    options.SetCustomConversion<MassFraction, Ratio>());
            var converter = UnitConverter.Create(new UnitParser([MassFraction.Info, Ratio.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(MassFraction.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassFractionUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Ratio, RatioUnit> toQuantityInfo = Ratio.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            RatioUnit toUnit = toUnitInfo.Value;
                            Ratio expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(Ratio.Info.UnitInfos, fromUnitInfo =>
                    {
                        RatioUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<MassFraction, MassFractionUnit> toQuantityInfo = MassFraction.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassFractionUnit toUnit = toUnitInfo.Value;
                            MassFraction expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitOfAnotherDimensionlessQuantityWithCustomConversion(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => 
                    // since both quantities are dimensionless it is assumed that the quantities can be converted using their BaseUnit (i.e. the DecimalFraction)
                    options.SetCustomConversion<MassFraction, Ratio>());
            var converter = UnitConverter.Create(new UnitParser([MassFraction.Info, Ratio.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(MassFraction.Info.UnitInfos, fromUnitInfo =>
                    {
                        MassFractionUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Ratio, RatioUnit> toQuantityInfo = Ratio.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            RatioUnit toUnit = toUnitInfo.Value;
                            Ratio expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(Ratio.Info.UnitInfos, fromUnitInfo =>
                    {
                        RatioUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo<MassFraction, MassFractionUnit> toQuantityInfo = MassFraction.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            MassFractionUnit toUnit = toUnitInfo.Value;
                            MassFraction expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, toQuantityInfo[expectedQuantity.Unit]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);
                            
                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversionExpression(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => options
                    // since the dimensions / base units are incompatible we have to explicitly specify a conversion expression
                    .SetCustomConversion<Volume, HowMuch>()
                    .SetCustomConversion(VolumeUnit.Liter, HowMuchUnit.Some, QuantityValue.One, true));
            var converter = UnitConverter.Create(new UnitParser([Volume.Info, HowMuch.Info]), convertOptions);
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Volume.Info.UnitInfos, fromUnitInfo =>
                    {
                        VolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(Volume.Info[VolumeUnit.Liter].GetValueFrom(valueToConvert, fromUnitInfo), toQuantityInfo[HowMuchUnit.Some]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Volume, VolumeUnit> toQuantityInfo = Volume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            VolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(HowMuch.Info[HowMuchUnit.Some].GetValueFrom(valueToConvert, fromUnitInfo), toQuantityInfo[VolumeUnit.Liter]);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_ShouldConvertValueToUnitOfAnotherQuantityWithCustomConversionExpression(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options => options
                    // since the dimensions / base units are incompatible we have to explicitly specify a conversion expression
                    .SetCustomConversion<Volume, HowMuch>()
                    .SetCustomConversion(VolumeUnit.Liter, HowMuchUnit.Some, QuantityValue.One, true));
            var converter = UnitConverter.Create(new UnitParser([Volume.Info, HowMuch.Info]), convertOptions);
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Volume.Info.UnitInfos, fromUnitInfo =>
                    {
                        VolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo toQuantityInfo = HowMuch.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            Enum toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(Volume.Info[VolumeUnit.Liter].GetValueFrom(valueToConvert, fromUnitInfo), toQuantityInfo[HowMuchUnit.Some]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    Assert.All(HowMuch.Info.UnitInfos, fromUnitInfo =>
                    {
                        Enum fromUnit = fromUnitInfo.Value;
                        QuantityInfo<Volume, VolumeUnit> toQuantityInfo = Volume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            VolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(HowMuch.Info[HowMuchUnit.Some].GetValueFrom(valueToConvert, fromUnitInfo), toQuantityInfo[VolumeUnit.Liter]);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);
                            
                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_ShouldConvertQuantityToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        Density quantityToConvert = fromUnitInfo.From(valueToConvert);
                        QuantityInfo<SpecificVolume, SpecificVolumeUnit> toQuantityInfo = SpecificVolume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            SpecificVolume expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

                            // note that passing a unit of another quantity forces us into the IQuantity overload
                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(expectedQuantity, convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                        });
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolume quantityToConvert = fromUnitInfo.From(valueToConvert);
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

                            // note that passing a unit of another quantity forces us into the IQuantity overload
                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(expectedQuantity, convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_ShouldConvertQuantityToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        Density quantityToConvert = fromUnitInfo.From(valueToConvert);
                        QuantityInfo<SpecificVolume, SpecificVolumeUnit> toQuantityInfo = SpecificVolume.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            SpecificVolume expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

                            // note that passing a unit of another quantity forces us into the IQuantity overload
                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(expectedQuantity, convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                        });
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolume quantityToConvert = fromUnitInfo.From(valueToConvert);
                        QuantityInfo<Density, DensityUnit> toQuantityInfo = Density.Info;
                        Assert.All(toQuantityInfo.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = toQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

                            // note that passing a unit of another quantity forces us into the IQuantity overload
                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.Equal(expectedQuantity, convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_WithCustomConversionExpression_ShouldConvertValueToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(DensityUnit.MicrogramPerLiter, SpecificVolumeUnit.CubicFootPerPound, customConversionFromDensity);
                    options.SetCustomConversion(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.MicrogramPerLiter, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[DensityUnit.MicrogramPerLiter];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                    {
                        SpecificVolumeUnit toUnit = toUnitInfo.Value;
                        // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);

                        QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                        Assert.Equal(expectedValue, convertedValue);
                    });
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customSpecificVolumeInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                    {
                        DensityUnit toUnit = toUnitInfo.Value;
                        // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                        QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                        Assert.Equal(expectedValue, convertedValue);
                    });
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customDensityInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertValue_WithCustomConversionFunction_ShouldConvertValueToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            // note: unlike the ConversionExpression, the overload using a lambda function won't be able to create the same "single-operation" conversions (there is always going to be an extra call to the NestedFunction)
            ConvertValueDelegate customConversionFromDensity = value => -value / 2;
            ConvertValueDelegate customConversionFromSpecificVolume = value => -value * 2;
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(DensityUnit.MicrogramPerLiter, SpecificVolumeUnit.CubicFootPerPound, customConversionFromDensity);
                    options.SetCustomConversion(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.MicrogramPerLiter, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[DensityUnit.MicrogramPerLiter];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                    {
                        SpecificVolumeUnit toUnit = toUnitInfo.Value;
                        // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity(valueToConvert), customSpecificVolumeInfo);

                        QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                        Assert.Equal(expectedValue, convertedValue);
                    });
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion function
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customSpecificVolumeInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                    {
                        DensityUnit toUnit = toUnitInfo.Value;
                        // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume(valueToConvert), customDensityInfo);

                        QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                        Assert.Equal(expectedValue, convertedValue);
                    });
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion function
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customDensityInfo);

                            QuantityValue convertedValue = converter.ConvertValue(valueToConvert, fromUnit, toUnit);

                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertValue_WithCustomConversionExpression_ShouldConvertValueToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(DensityUnit.MicrogramPerLiter, SpecificVolumeUnit.CubicFootPerPound, customConversionFromDensity);
                    options.SetCustomConversion(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.MicrogramPerLiter, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[DensityUnit.MicrogramPerLiter];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                    {
                        SpecificVolumeUnit toUnit = toUnitInfo.Value;
                        // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);

                        var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                        Assert.True(success);
                        Assert.Equal(expectedValue, convertedValue);
                    });
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customSpecificVolumeInfo);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                    {
                        DensityUnit toUnit = toUnitInfo.Value;
                        // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                        var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                        Assert.True(success);
                        Assert.Equal(expectedValue, convertedValue);
                    });
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customDensityInfo);

                            var success = converter.TryConvertValue(valueToConvert, fromUnit, toUnit, out QuantityValue convertedValue);

                            Assert.True(success);
                            Assert.Equal(expectedValue, convertedValue);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_WithCustomConversionExpression_ShouldConvertQuantityToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(DensityUnit.MicrogramPerLiter, SpecificVolumeUnit.CubicFootPerPound, customConversionFromDensity);
                    options.SetCustomConversion(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.MicrogramPerLiter, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[DensityUnit.MicrogramPerLiter];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    Density quantityToConvert = customDensityInfo.From(valueToConvert);
                    Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                    {
                        SpecificVolumeUnit toUnit = toUnitInfo.Value;
                        // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);

                        IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        Density quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            SpecificVolume expectedQuantity = customSpecificVolumeInfo.From(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, customSpecificVolumeInfo);

                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.IsType<SpecificVolume>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolume quantityToConvert = customSpecificVolumeInfo.From(valueToConvert);
                    Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                    {
                        DensityUnit toUnit = toUnitInfo.Value;
                        // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                        IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolume quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, customDensityInfo);

                            IQuantity convertedQuantity = converter.ConvertTo(quantityToConvert, toUnit);

                            Assert.IsType<Density>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_WithCustomConversionExpression_ShouldConvertQuantityToUnitOfAnotherQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(DensityUnit.MicrogramPerLiter, SpecificVolumeUnit.CubicFootPerPound, customConversionFromDensity);
                    options.SetCustomConversion(SpecificVolumeUnit.CubicFootPerPound, DensityUnit.MicrogramPerLiter, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[DensityUnit.MicrogramPerLiter];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[SpecificVolumeUnit.CubicFootPerPound];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    Density quantityToConvert = customDensityInfo.From(valueToConvert);
                    Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                    {
                        SpecificVolumeUnit toUnit = toUnitInfo.Value;
                        // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);
                        
                        var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        Density quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(SpecificVolume.Info.UnitInfos, toUnitInfo =>
                        {
                            SpecificVolumeUnit toUnit = toUnitInfo.Value;
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)), customSpecificVolumeInfo);
                            
                            var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                            Assert.True(success);
                            Assert.IsType<SpecificVolume>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolume quantityToConvert = customSpecificVolumeInfo.From(valueToConvert);
                    Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                    {
                        DensityUnit toUnit = toUnitInfo.Value;
                        // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                        QuantityValue expectedValue = toUnitInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);
                        
                        var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(toUnit, convertedQuantity.Unit);
                        Assert.Equal(expectedValue, convertedQuantity.Value);
                    });
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolume quantityToConvert = fromUnitInfo.From(valueToConvert);
                        Assert.All(Density.Info.UnitInfos, toUnitInfo =>
                        {
                            DensityUnit toUnit = toUnitInfo.Value;
                            Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            QuantityValue expectedValue = toUnitInfo.GetValueFrom(expectedQuantity.Value, customDensityInfo);
                            
                            var success = converter.TryConvertTo(quantityToConvert, toUnit, out IQuantity? convertedQuantity);

                            Assert.True(success);
                            Assert.IsType<Density>(convertedQuantity);
                            Assert.Equal(toUnit, convertedQuantity.Unit);
                            Assert.Equal(expectedValue, convertedQuantity.Value);
                        });
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetQuantityInfo_ShouldConvertQuantityToTargetQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        SpecificVolume expectedQuantity = SpecificVolume.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        SpecificVolume convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, SpecificVolume.Info);

                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Density expectedQuantity = Density.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        Density convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, Density.Info);

                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }
       
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetIQuantityInfo_ShouldConvertQuantityToTargetIQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                        SpecificVolume expectedQuantity = SpecificVolume.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);

                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = Density.Info;
                        Density expectedQuantity = Density.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);

                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetQuantityInfo_FromUnknownUnit_ShouldThrow_UnitNotFoundException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);
            
            Assert.Throws<UnitNotFoundException>(() => converter.ConvertTo(1, SpecificVolumeUnit.CubicMeterPerKilogram, Density.Info));
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetQuantityInfo_FromUnknownQuantity_ShouldThrow_InvalidConversionException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);
            
            Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, DensityUnit.KilogramPerCubicMeter, SpecificVolume.Info));
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetIQuantityInfo_FromUnknownUnit_ShouldThrow_UnitNotFoundException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);
            QuantityInfo targetQuantityInfo = Density.Info;
            
            Assert.Throws<UnitNotFoundException>(() => converter.ConvertTo(1, SpecificVolumeUnit.CubicMeterPerKilogram, targetQuantityInfo));
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetIQuantityInfo_FromUnknownQuantity_ShouldThrow_InvalidConversionException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);
            QuantityInfo targetQuantityInfo = SpecificVolume.Info;
            
            Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, DensityUnit.KilogramPerCubicMeter, targetQuantityInfo));
        }

        [Fact]
        public void ConvertTo_TargetQuantityInfo_WithUnsupportedConversion_ShouldThrow_InvalidConversionException()
        {
            QuantityConversionOptions invalidConversionOptions = new QuantityConversionOptions().SetCustomConversion<Density, Mass>();
            // converter options with a custom conversion which cannot be deduced from the dimensions of the quantities (an explicit conversion function is required)
            Assert.All(GetQuantityConverterBuildOptions().Where(x => x.DefaultCachingMode == ConversionCachingMode.None)
                    .Select(options => options.WithImplicitConversionOptions(invalidConversionOptions)),
                convertOptions =>
                {
                    // this is not ideal, but since we aren't creating any conversion functions: no exception is thrown from the Create method
                    var converter = UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions);
                    // the invalid conversion is only detected when attempting to convert "on the fly"
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, DensityUnit.KilogramPerCubicMeter, Mass.Info));
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, MassUnit.Gram, Density.Info));
                });
        }

        [Fact]
        public void ConvertTo_TargetIQuantityInfo_WithUnsupportedConversion_ShouldThrow_InvalidConversionException()
        {
            QuantityConversionOptions invalidConversionOptions = new QuantityConversionOptions().SetCustomConversion<Density, Mass>();
            // converter options with a custom conversion which cannot be deduced from the dimensions of the quantities (an explicit conversion function is required)
            Assert.All(GetQuantityConverterBuildOptions().Where(x => x.DefaultCachingMode == ConversionCachingMode.None)
                    .Select(options => options.WithImplicitConversionOptions(invalidConversionOptions)),
                convertOptions =>
                {
                    // this is not ideal, but since we aren't creating any conversion functions: no exception is thrown from the Create method
                    var converter = UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions);
                    // the invalid conversion is only detected when attempting to convert "on the fly"
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, DensityUnit.KilogramPerCubicMeter, (QuantityInfo)Mass.Info));
                    Assert.Throws<InvalidConversionException>(() => converter.ConvertTo(1, MassUnit.Gram, (QuantityInfo)Density.Info));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void Create_WithCachingAndUnsupportedConversionUnits_ShouldThrow_InvalidConversionException(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            // converter options with a custom conversion unit-mapping which cannot be deduced from the dimensions of the quantities (an explicit conversion function is required)
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(conversionOptions => conversionOptions
                    .SetCustomConversion<Density, Mass>() // this is optional
                    .SetConversionUnits(DensityUnit.KilogramPerCubicMeter, MassUnit.Kilogram));

            Assert.Throws<InvalidConversionException>(() => UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions));
        }

        [Fact]
        public void Create_WithCachingAndUnsupportedConversion_ShouldThrow_InvalidConversionException()
        {
            // converter options with a custom conversion which cannot be deduced from the dimensions of the quantities (an explicit conversion function is required)
            Assert.All(GetQuantityConverterBuildOptions().Where(x => x.DefaultCachingMode != ConversionCachingMode.None)
                    .Select(options => options.WithImplicitConversionOptions(conversionOptions => conversionOptions.SetCustomConversion<Density, Mass>())),
                convertOptions =>
                {
                    Assert.Throws<InvalidConversionException>(() => UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions));
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetQuantityInfo_FromUnknownUnit_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);

            var success = converter.TryConvertTo(1, SpecificVolumeUnit.CubicMeterPerKilogram, Density.Info, out _);
                        
            Assert.False(success);
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetIQuantityInfo_FromUnknownUnit_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);

            var success = converter.TryConvertTo(1, SpecificVolumeUnit.CubicMeterPerKilogram, (QuantityInfo)Density.Info, out _);
                        
            Assert.False(success);
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetQuantityInfo_FromUnknownQuantity_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);

            var success = converter.TryConvertTo(1, DensityUnit.KilogramPerCubicMeter, SpecificVolume.Info, out _);
                        
            Assert.False(success);
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetIQuantityInfo_FromUnknownQuantity_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info]), convertOptions);

            var success = converter.TryConvertTo(1, DensityUnit.KilogramPerCubicMeter, (QuantityInfo)SpecificVolume.Info, out _);
                        
            Assert.False(success);
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetQuantityInfo_WithUnknownRelation_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, MassConcentration.Info]), convertOptions);

            Assert.False(converter.TryConvertTo(1, DensityUnit.KilogramPerCubicMeter, MassConcentration.Info, out _));
            Assert.False(converter.TryConvertTo(1, MassConcentrationUnit.KilogramPerCubicMeter, Density.Info, out _));
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetIQuantityInfo_WithUnknownRelation_ReturnFalse(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, MassConcentration.Info]), convertOptions);

            Assert.False(converter.TryConvertTo(1, DensityUnit.KilogramPerCubicMeter, (QuantityInfo)MassConcentration.Info, out _));
            Assert.False(converter.TryConvertTo(1, MassConcentrationUnit.KilogramPerCubicMeter, (QuantityInfo)Density.Info, out _));
        }

        [Fact]
        public void TryConvertTo_TargetQuantityInfo_WithUnsupportedConversion_ShouldReturnFalse()
        {
            Assert.All(GetQuantityConverterBuildOptions().Where(x => x.DefaultCachingMode == ConversionCachingMode.None)
                    .Select(options => options.WithImplicitConversionOptions(conversionOptions => conversionOptions.SetCustomConversion<Density, Mass>())),
                convertOptions =>
                {
                    // this is not ideal, but since we aren't creating any conversion functions: no exception is thrown from the Create method
                    var converter = UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions);
                    // all subsequent attempts to use the invalid conversions would fail
                    Assert.Multiple(() =>
                    {
                        var success = converter.TryConvertTo(1, MassUnit.Kilogram, Density.Info, out _);

                        Assert.False(success);
                    }, () =>
                    {
                        var success = converter.TryConvertTo(1, DensityUnit.KilogramPerLiter, Mass.Info, out _);

                        Assert.False(success);
                    });
                });
        }

        [Fact]
        public void TryConvertTo_TargetIQuantityInfo_WithUnsupportedConversion_ShouldReturnFalse()
        {
            Assert.All(GetQuantityConverterBuildOptions().Where(x => x.DefaultCachingMode == ConversionCachingMode.None)
                    .Select(options => options.WithImplicitConversionOptions(conversionOptions => conversionOptions.SetCustomConversion<Density, Mass>())),
                convertOptions =>
                {
                    // this is not ideal, but since we aren't creating any conversion functions: no exception is thrown from the Create method
                    var converter = UnitConverter.Create(new UnitParser([Density.Info, Mass.Info]), convertOptions);
                    // all subsequent attempts to use the invalid conversions would fail
                    Assert.Multiple(() =>
                    {
                        var success = converter.TryConvertTo(1, MassUnit.Kilogram, (QuantityInfo)Density.Info, out _);

                        Assert.False(success);
                    }, () =>
                    {
                        var success = converter.TryConvertTo(1, DensityUnit.KilogramPerLiter, (QuantityInfo)Mass.Info, out _);

                        Assert.False(success);
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetQuantityInfo_ShouldConvertQuantityToTargetQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        SpecificVolume expectedQuantity = SpecificVolume.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertTo(valueToConvert, fromUnit, SpecificVolume.Info, out SpecificVolume convertedQuantity);

                        Assert.True(success);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Density expectedQuantity = Density.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertTo(valueToConvert, fromUnit, Density.Info, out Density convertedQuantity);
                        
                        Assert.True(success);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }
       
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetIQuantityInfo_ShouldConvertQuantityToTargetIQuantity(bool freeze, ConversionCachingMode cachingMode, bool reduceConstants)
        {
            var convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants);
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    Assert.All(Density.Info.UnitInfos, fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                        SpecificVolume expectedQuantity = SpecificVolume.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    Assert.All(SpecificVolume.Info.UnitInfos, fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = Density.Info;
                        Density expectedQuantity = Density.Info.ConvertFrom(valueToConvert, fromUnitInfo);

                        var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);
                        
                        Assert.True(success);
                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }
        
        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetQuantityInfo_WithCustomConversionExpression_ShouldConvertQuantityToTargetQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            DensityUnit customDensityUnit = DensityUnit.MicrogramPerLiter;
            SpecificVolumeUnit customSpecificVolumeUnit = SpecificVolumeUnit.CubicFootPerPound;
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(customDensityUnit, customSpecificVolumeUnit, customConversionFromDensity);
                    options.SetCustomConversion(customSpecificVolumeUnit, customDensityUnit, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[customDensityUnit];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[customSpecificVolumeUnit];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                    QuantityValue expectedValue = customSpecificVolumeInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);
                   
                    SpecificVolume convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, SpecificVolume.Info);

                    Assert.Equal(customSpecificVolumeUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        SpecificVolume expectedQuantity = customSpecificVolumeInfo.From(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                        
                        SpecificVolume convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, SpecificVolume.Info);

                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                    QuantityValue expectedValue = customDensityInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                    Density convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, Density.Info);

                    Assert.Equal(customDensityUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            
                        Density convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, Density.Info);

                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void ConvertTo_TargetIQuantityInfo_WithCustomConversionExpression_ShouldConvertQuantityToTargetIQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            DensityUnit customDensityUnit = DensityUnit.MicrogramPerLiter;
            SpecificVolumeUnit customSpecificVolumeUnit = SpecificVolumeUnit.CubicFootPerPound;
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(customDensityUnit, customSpecificVolumeUnit, customConversionFromDensity);
                    options.SetCustomConversion(customSpecificVolumeUnit, customDensityUnit, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[customDensityUnit];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[customSpecificVolumeUnit];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                    // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                    QuantityValue expectedValue = customSpecificVolumeInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);

                    IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);
                    
                    Assert.IsType<SpecificVolume>(convertedQuantity);
                    Assert.Equal(customSpecificVolumeUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                        SpecificVolume expectedQuantity = customSpecificVolumeInfo.From(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                        
                        IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);
                        
                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    QuantityInfo targetQuantityInfo = Density.Info;
                    // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                    QuantityValue expectedValue = customDensityInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                    IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);
                    
                    Assert.IsType<Density>(convertedQuantity);
                    Assert.Equal(customDensityUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = Density.Info;
                        Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            
                        IQuantity convertedQuantity = converter.ConvertTo(valueToConvert, fromUnit, targetQuantityInfo);
                        
                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetQuantityInfo_WithCustomConversionExpression_ShouldConvertQuantityToTargetQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            DensityUnit customDensityUnit = DensityUnit.MicrogramPerLiter;
            SpecificVolumeUnit customSpecificVolumeUnit = SpecificVolumeUnit.CubicFootPerPound;
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(customDensityUnit, customSpecificVolumeUnit, customConversionFromDensity);
                    options.SetCustomConversion(customSpecificVolumeUnit, customDensityUnit, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[customDensityUnit];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[customSpecificVolumeUnit];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                    QuantityValue expectedValue = customSpecificVolumeInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);
                   
                    var success = converter.TryConvertTo(valueToConvert, fromUnit, SpecificVolume.Info, out SpecificVolume convertedQuantity);

                    Assert.True(success);
                    Assert.Equal(customSpecificVolumeUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        SpecificVolume expectedQuantity = customSpecificVolumeInfo.From(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                        
                        var success = converter.TryConvertTo(valueToConvert, fromUnit, SpecificVolume.Info, out SpecificVolume convertedQuantity);

                        Assert.True(success);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                    QuantityValue expectedValue = customDensityInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                    var success = converter.TryConvertTo(valueToConvert, fromUnit, Density.Info, out Density convertedQuantity);
                    
                    Assert.True(success);
                    Assert.Equal(customDensityUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            
                        var success = converter.TryConvertTo(valueToConvert, fromUnit, Density.Info, out Density convertedQuantity);
                    
                        Assert.True(success);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }

        [Theory]
        [MemberData(nameof(ConverterTestOptions))]
        public void TryConvertTo_TargetIQuantityInfo_WithCustomConversionExpression_ShouldConvertQuantityToTargetIQuantity(bool freeze, ConversionCachingMode cachingMode,
            bool reduceConstants)
        {
            DensityUnit customDensityUnit = DensityUnit.MicrogramPerLiter;
            SpecificVolumeUnit customSpecificVolumeUnit = SpecificVolumeUnit.CubicFootPerPound;
            var customConversionFromDensity = new ConversionExpression(new QuantityValue(-1, 2));
            var customConversionFromSpecificVolume = new ConversionExpression(-2);
            QuantityConverterBuildOptions convertOptions = new QuantityConverterBuildOptions(freeze, cachingMode, reduceConstants)
                .WithImplicitConversionOptions(options =>
                {
                    options.SetCustomConversion(customDensityUnit, customSpecificVolumeUnit, customConversionFromDensity);
                    options.SetCustomConversion(customSpecificVolumeUnit, customDensityUnit, customConversionFromSpecificVolume);
                });
            var converter = UnitConverter.Create(new UnitParser([Density.Info, SpecificVolume.Info]), convertOptions);

            UnitInfo<Density, DensityUnit> customDensityInfo = Density.Info[customDensityUnit];
            UnitInfo<SpecificVolume, SpecificVolumeUnit> customSpecificVolumeInfo = SpecificVolume.Info[customSpecificVolumeUnit];
            QuantityValue valueToConvert = 123.45m;
            Assert.Multiple(() =>
                {
                    // when the left unit is the customDensityInfo
                    DensityUnit fromUnit = customDensityInfo.Value;
                    QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                    // (123.45, customDensityInfo) => (-123.45/2, customSpecificVolumeInfo) => ConvertValue((-123.45/2, customSpecificVolumeInfo), toUnitInfo)
                    QuantityValue expectedValue = customSpecificVolumeInfo.GetValueFrom(customConversionFromDensity.Evaluate(valueToConvert), customSpecificVolumeInfo);

                    var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);

                    Assert.True(success);
                    Assert.IsType<SpecificVolume>(convertedQuantity);
                    Assert.Equal(customSpecificVolumeUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                },
                () =>
                {
                    // all other density units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(Density.Info.UnitInfos.Where(info => info != customDensityInfo), fromUnitInfo =>
                    {
                        DensityUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = SpecificVolume.Info;
                        SpecificVolume expectedQuantity = customSpecificVolumeInfo.From(customConversionFromDensity.Evaluate(customDensityInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                        
                        var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType<SpecificVolume>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                },
                () =>
                {
                    // when the left unit is the customSpecificVolumeInfo
                    SpecificVolumeUnit fromUnit = customSpecificVolumeInfo.Value;
                    QuantityInfo targetQuantityInfo = Density.Info;
                    // (123.45, customSpecificVolumeInfo) => (-123.45 * 2, customDensityInfo) => ConvertValue((-123.45 * 2, customDensityInfo), toUnitInfo)
                    QuantityValue expectedValue = customDensityInfo.GetValueFrom(customConversionFromSpecificVolume.Evaluate(valueToConvert), customDensityInfo);

                    var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);

                    Assert.True(success);
                    Assert.IsType<Density>(convertedQuantity);
                    Assert.Equal(customDensityUnit, convertedQuantity.Unit);
                    Assert.Equal(expectedValue, convertedQuantity.Value);
                }, () =>
                {
                    // all other specific-volume units are also converted using our custom conversion expression (possibly resulting in a different unit)
                    Assert.All(SpecificVolume.Info.UnitInfos.Where(info => info != customSpecificVolumeInfo), fromUnitInfo =>
                    {
                        SpecificVolumeUnit fromUnit = fromUnitInfo.Value;
                        QuantityInfo targetQuantityInfo = Density.Info;
                        Density expectedQuantity = customDensityInfo.From(customConversionFromSpecificVolume.Evaluate(customSpecificVolumeInfo.GetValueFrom(valueToConvert, fromUnitInfo)));
                            
                        var success = converter.TryConvertTo(valueToConvert, fromUnit, targetQuantityInfo, out IQuantity? convertedQuantity);

                        Assert.True(success);
                        Assert.IsType<Density>(convertedQuantity);
                        Assert.Equal(expectedQuantity, convertedQuantity);
                    });
                });
        }
    }
}
