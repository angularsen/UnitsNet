using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using UnitsNet;
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

        static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public class TypeDescriptorContext : ITypeDescriptorContext
        {
            public class PropertyDescriptor_ : PropertyDescriptor
            {
                public PropertyDescriptor_(string name, Attribute[] attributes) : base(name, attributes)
                {

                }

                public override Type ComponentType => throw new NotImplementedException();

                public override bool IsReadOnly => throw new NotImplementedException();

                public override Type PropertyType => throw new NotImplementedException();

                public override bool CanResetValue(object component)
                {
                    throw new NotImplementedException();
                }

                public override object GetValue(object component)
                {
                    throw new NotImplementedException();
                }

                public override void ResetValue(object component)
                {
                    throw new NotImplementedException();
                }

                public override void SetValue(object component, object value)
                {
                    throw new NotImplementedException();
                }

                public override bool ShouldSerializeValue(object component)
                {
                    throw new NotImplementedException();
                }
            }

            public TypeDescriptorContext(string name, Attribute[] attributes)
            {
                PropertyDescriptor = new PropertyDescriptor_(name, attributes);
            }

            public IContainer Container => throw new NotImplementedException();

            public object Instance => throw new NotImplementedException();

            public PropertyDescriptor PropertyDescriptor { get; set; }

            public object GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }

            public void OnComponentChanged()
            {
                throw new NotImplementedException();
            }

            public bool OnComponentChanging()
            {
                throw new NotImplementedException();
            }
        }

        [Theory]
        [InlineData(typeof(string))]
        public void CanConvertFrom_GiveSomeTypes_ReturnsTrue(Type value)
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();

            Assert.True(unitsNETTypeConverter.CanConvertFrom(value));
        }

        [Theory]
        [InlineData(typeof(double))]
        [InlineData(typeof(object))]
        [InlineData(typeof(float))]
        [InlineData(typeof(Length))]
        public void CanConvertFrom_GiveSomeTypes_ReturnsFalse(Type value)
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();

            Assert.False(unitsNETTypeConverter.CanConvertFrom(value));
        }

        [Theory]
        [InlineData(typeof(string))]
        public void CanConvertTo_GiveSomeTypes_ReturnsTrue(Type value)
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();

            Assert.True(unitsNETTypeConverter.CanConvertTo(value));
        }

        [Theory]
        [InlineData(typeof(double))]
        [InlineData(typeof(object))]
        [InlineData(typeof(float))]
        [InlineData(typeof(Length))]
        public void CanConvertTo_GiveSomeTypes_ReturnsFalse(Type value)
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();

            Assert.False(unitsNETTypeConverter.CanConvertTo(value));
        }

        [Fact]
        public void ConvertFrom_GiveSomeStrings()
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Length.FromMillimeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1mm"));
            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1"));
            Assert.Equal(Length.FromKilometers(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1km"));

            context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { new DefaultUnitAttribute(Units.LengthUnit.Centimeter) });

            Assert.Equal(Length.FromMillimeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1mm"));
            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromCentimeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1"));
            Assert.Equal(Length.FromKilometers(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1km"));

            context = new TypeDescriptorContext("SomeMemberName", new Attribute[]
                {
                    new DefaultUnitAttribute(Units.LengthUnit.Centimeter),
                    new ConvertToUnitAttribute(Units.LengthUnit.Meter)
                });

            Assert.Equal(Length.FromMeters(0.001), unitsNETTypeConverter.ConvertFrom(context, culture, "1mm"));
            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromMeters(0.01), unitsNETTypeConverter.ConvertFrom(context, culture, "1"));
            Assert.Equal(Length.FromMeters(1000), unitsNETTypeConverter.ConvertFrom(context, culture, "1km"));
        }

        [Fact]
        public void ConvertFrom_GiveEmpyString()
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<NotSupportedException>(() => unitsNETTypeConverter.ConvertFrom(context, culture, ""));
        }

        [Fact]
        public void ConvertFrom_GiveWrongQuantity()
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Throws<ArgumentException>(() => unitsNETTypeConverter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void WrongUnitTypeInAttribut_DefaultUnit()
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { new DefaultUnitAttribute(Units.VolumeUnit.CubicMeter) });

            Assert.Throws<InvalidOperationException>(() => unitsNETTypeConverter.ConvertFrom(context, culture, "1"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_1()
        {
            UnitsNetTypeConverter<Length> unitsNETTypeConverter = new UnitsNetTypeConverter<Length>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m"));
            Assert.Equal(Length.FromMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m^1"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_2()
        {
            UnitsNetTypeConverter<Area> unitsNETTypeConverter = new UnitsNetTypeConverter<Area>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Area.FromSquareMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m²"));
            Assert.Equal(Area.FromSquareMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m^2"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_3()
        {
            UnitsNetTypeConverter<Volume> unitsNETTypeConverter = new UnitsNetTypeConverter<Volume>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(Volume.FromCubicMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m³"));
            Assert.Equal(Volume.FromCubicMeters(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m^3"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_4()
        {
            UnitsNetTypeConverter<AreaMomentOfInertia> unitsNETTypeConverter = new UnitsNetTypeConverter<AreaMomentOfInertia>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m⁴"));
            Assert.Equal(AreaMomentOfInertia.FromMetersToTheFourth(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1m^4"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_minus1()
        {
            UnitsNetTypeConverter<CoefficientOfThermalExpansion> unitsNETTypeConverter = new UnitsNetTypeConverter<CoefficientOfThermalExpansion>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1K⁻¹"));
            Assert.Equal(CoefficientOfThermalExpansion.FromInverseKelvin(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1K^-1"));
        }

        [Fact]
        public void ConvertFrom_GiveStringWithPower_minus2()
        {
            UnitsNetTypeConverter<MassFlux> unitsNETTypeConverter = new UnitsNetTypeConverter<MassFlux>();
            ITypeDescriptorContext context = new TypeDescriptorContext("SomeMemberName", new Attribute[] { });

            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1kg·s⁻¹·m⁻²"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1kg·s^-1·m^-2"));
            Assert.Equal(MassFlux.FromKilogramsPerSecondPerSquareMeter(1), unitsNETTypeConverter.ConvertFrom(context, culture, "1kg*s^-1*m^-2"));
        }
    }
}
