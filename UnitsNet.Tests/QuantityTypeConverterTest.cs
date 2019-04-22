// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using UnitsNet;
using UnitsNet.Tests.Helpers;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityTypeConverterTest
    {
        // https://stackoverflow.com/questions/3612909/why-is-this-typeconverter-not-working
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AppDomain domain = (AppDomain)sender;
            foreach (Assembly asm in domain.GetAssemblies())
            {
                if (asm.FullName == args.Name)
                {
                    return asm;
                }
            }
            return null;
        }

        static QuantityTypeConverterTest()
        {
            // NOTE: After this, you can use your typeconverter.
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        /// <summary>
        /// Is used for tests that are culture dependent
        /// </summary>
        static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length), false)]
        public void CanConvertFrom_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new UnitsNetTypeConverter<Length>();

            Assert.True(converter.CanConvertFrom(value) == expectedResult);
        }

        [Theory]
        [InlineData(typeof(string), true)]
        [InlineData(typeof(double), false)]
        [InlineData(typeof(object), false)]
        [InlineData(typeof(float), false)]
        [InlineData(typeof(Length), false)]
        public void CanConvertTo_GivenSomeTypes(Type value, bool expectedResult)
        {
            var converter = new UnitsNetTypeConverter<Length>();

            Assert.True(converter.CanConvertTo(value) == expectedResult);
        }

        [Theory]
        [InlineData("1mm", 1, Units.LengthUnit.Millimeter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 1, Units.LengthUnit.Meter)]
        [InlineData("1km", 1, Units.LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithNoAttributes_ReturnsQuantityWithBaseUnitIfNotSpecified(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            var convertedValue = (Length)converter.ConvertFrom(context, culture, str);

            Assert.Equal(convertedValue.Value, expectedValue);
            Assert.Equal(convertedValue.Unit, expectedUnit);
        }

        [Theory]
        [InlineData("1mm", 1, Units.LengthUnit.Millimeter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 1, Units.LengthUnit.Centimeter)]
        [InlineData("1km", 1, Units.LengthUnit.Kilometer)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAttribute_ReturnsQuantityWithGivenDefaultUnitIfNotSpecified(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { new DefaultUnitAttribute(Units.LengthUnit.Centimeter) });

            var convertedValue = (Length)converter.ConvertFrom(context, culture, str);

            Assert.Equal(convertedValue.Value, expectedValue);
            Assert.Equal(convertedValue.Unit, expectedUnit);
        }

        [Theory]
        [InlineData("1mm", 0.001, Units.LengthUnit.Meter)]
        [InlineData("1m", 1, Units.LengthUnit.Meter)]
        [InlineData("1", 0.01, Units.LengthUnit.Meter)]
        [InlineData("1km", 1000, Units.LengthUnit.Meter)]
        public void ConvertFrom_GivenQuantityStringAndContextWithDefaultUnitAndConvertToUnitAttributes_ReturnsQuantityConvertedToUnit(string str, double expectedValue, Enum expectedUnit)
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
                {
                    new DefaultUnitAttribute(Units.LengthUnit.Centimeter),
                    new ConvertToUnitAttribute(Units.LengthUnit.Meter)
                });

            var convertedValue = (Length)converter.ConvertFrom(context, culture, str);

            Assert.Equal(convertedValue.Value, expectedValue);
            Assert.Equal(convertedValue.Unit, expectedUnit);
        }

        [Fact]
        public void ConvertFrom_GivenEmpyString_ThrowsNotSupportedException()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<NotSupportedException>(() => converter.ConvertFrom(context, culture, ""));
        }

        [Fact]
        public void ConvertFrom_GivenWrongQuantity_ThrowsArgumentException()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Theory]
        [InlineData(typeof(Length))]
        [InlineData(typeof(IQuantity))]
        [InlineData(typeof(object))]
        public void ConvertTo_GivenWrongType_ThrowsExceptionNotSupportedException(Type value)
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length length = Length.FromMeters(1);

            Assert.Throws<NotSupportedException>(() => converter.ConvertTo(length, value));
        }

        [Fact]
        public void ConvertTo_GivenStringType_ReturnsQuantityString()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length length = Length.FromMeters(1);

            Assert.Equal("1 m", converter.ConvertTo(length, typeof(string)));
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantitysAndContextWithNoAttributes_ReturnsQuantityStringInUnitOfQuantity()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });
            Length length = Length.FromMeters(1);

            Assert.Equal("1 m", converter.ConvertTo(length, typeof(string)));
            Assert.Equal("1 m", converter.ConvertTo(context, culture, length, typeof(string)));
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitDefaultFormating()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter)
            });

            Length length = Length.FromMeters(1);

            Assert.Equal("10 dm", converter.ConvertTo(context, culture, length, typeof(string)));
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormatting_ReturnsQuantityStringWithDisplayUnitFormateAsValueOnly()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter, "v")
            });

            Length length = Length.FromMeters(1);

            Assert.Equal("10", converter.ConvertTo(context, culture, length, typeof(string)));
        }

        [Fact]
        public void ConvertTo_TestDisplayAsFormattingWithoutDefinedUnit_ReturnsQuantityStringWithQuantetiesUnitAndFormatedAsValueOnly()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DisplayAsUnitAttribute(null, "v")
            });

            Length length = Length.FromMeters(1);

            Assert.Equal("1", converter.ConvertTo(context, culture, length, typeof(string)));
        }

        [Fact]
        public void ConvertTo_GivenSomeQuantitysAndContextWithDisplayAsUnitAttributes_ReturnsQuantityStringInSpecifiedDisplayUnit()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DefaultUnitAttribute(Units.LengthUnit.Centimeter),
                new ConvertToUnitAttribute(Units.LengthUnit.Millimeter),
                new DisplayAsUnitAttribute(Units.LengthUnit.Decimeter)
            });

            Length length = Length.FromMeters(1);

            Assert.Equal("1 m", converter.ConvertTo(length, typeof(string)));
            Assert.Equal("10 dm", converter.ConvertTo(context, culture, length, typeof(string)));
        }

        [Fact]
        public void WrongUnitTypeInAttribut_DefaultUnit()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
            {
                new DefaultUnitAttribute(Units.VolumeUnit.CubicMeter)
            });

            Assert.Throws<ArgumentException>(() => converter.ConvertFrom(context, culture, "1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_1()
        {
            var converter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Length.FromMeters(1), converter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromMeters(1), converter.ConvertFrom(context, culture, "1m^1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_2()
        {
            var converter = new UnitsNetTypeConverter<Area>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Area.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m²"));
            Assert.Equal(Area.FromSquareMeters(1), converter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_3()
        {
            var converter = new UnitsNetTypeConverter<Volume>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Volume.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m³"));
            Assert.Equal(Volume.FromCubicMeters(1), converter.ConvertFrom(context, culture, "1m^3"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_4()
        {
            var converter = new UnitsNetTypeConverter<AreaMomentOfInertia>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m⁴"));
            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), converter.ConvertFrom(context, culture, "1m^4"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus1()
        {
            var converter = new UnitsNetTypeConverter<CoefficientOfThermalExpansion>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K⁻¹"));
            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), converter.ConvertFrom(context, culture, "1K^-1"));
        }

        [Fact]
        public void ConvertFrom_GivenStringWithPower_minus2()
        {
            var converter = new UnitsNetTypeConverter<MassFlux>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s⁻¹·m⁻²"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg·s^-1·m^-2"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), converter.ConvertFrom(context, culture, "1kg*s^-1*m^-2"));
        }
    }
}
