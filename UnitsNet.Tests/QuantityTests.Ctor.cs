using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    [UsedImplicitly]
    public partial class QuantityTests
    {
        /// <summary>
        /// Tests constructors of quantity types.
        /// </summary>
        public class Ctor
        {
            [Fact]
            [SuppressMessage("ReSharper", "ObjectCreationAsStatement", Justification = "Only testing the ctor itself, not the resulting value.")]
            public void DefaultCtorOfRepresentativeTypes_DoesNotThrow()
            {
                // double types
                new Length<double>();

                // decimal types
                new Information<decimal>();

                // logarithmic types
                new Level<double>();
            }

            [Fact]
            public void DefaultCtorOfRepresentativeTypes_SetsValueToZeroAndUnitToBaseUnit()
            {
                // double types
                Assert.Equal(0, new Mass<double>().Value);
                Assert.Equal(MassUnit.Kilogram, new Mass<double>().Unit);

                // decimal types
                Assert.Equal(0, new Information<decimal>().Value);
                Assert.Equal(InformationUnit.Bit, new Information<decimal>().Unit);

                // logarithmic types
                Assert.Equal(0, new Level<double>().Value);
                Assert.Equal(LevelUnit.Decibel, new Level<double>().Unit);
            }

            /// <summary>
            ///     This test is a bit misplaced, but was added because when working on #389 unit+value there were two
            ///     ways to implement this; either assume BaseUnit of unit is not specified or throw if quantity did not have unit explicitly set.
            ///     Struct types do not allow custom default ctor implementations, so that exception would then be thrown when trying to convert.
            /// </summary>
            [Fact]
            public void DefaultCtorOfRepresentativeTypes_DoesNotThrowWhenConvertingToOtherUnits()
            {
                // double types
                Assert.Equal(0, new Mass<double>().Hectograms);

                // decimal types
                Assert.Equal(0, new Information<decimal>().Kibibits);

                // logarithmic types
                Assert.Equal(0, new Level<double>().Nepers);
            }

            [Fact]
            public void CtorWithOnlyValueOfRepresentativeTypes_SetsValueToGivenValueAndUnitToBaseUnit()
            {
#pragma warning disable 618
                // double types
                Assert.Equal(5, new Mass<double>(5L, MassUnit.Kilogram).Value);
                Assert.Equal(5, new Mass<double>(5d, MassUnit.Kilogram).Value);
                Assert.Equal(MassUnit.Kilogram, new Mass<double>(5L, MassUnit.Kilogram).Unit);
                Assert.Equal(MassUnit.Kilogram, new Mass<double>(5d, MassUnit.Kilogram).Unit);

                // decimal types
                Assert.Equal(5, new Information<decimal>(5L, InformationUnit.Bit).Value);
                Assert.Equal(5, new Information<decimal>(5m, InformationUnit.Bit).Value);
                Assert.Equal(InformationUnit.Bit, new Information<decimal>(5L, InformationUnit.Bit).Unit);
                Assert.Equal(InformationUnit.Bit, new Information<decimal>(5m, InformationUnit.Bit).Unit);

                // logarithmic types
                Assert.Equal(5, new Level<double>(5L, LevelUnit.Decibel).Value);
                Assert.Equal(5, new Level<double>(5d, LevelUnit.Decibel).Value);
                Assert.Equal(LevelUnit.Decibel, new Level<double>(5L, LevelUnit.Decibel).Unit);
                Assert.Equal(LevelUnit.Decibel, new Level<double>(5d, LevelUnit.Decibel).Unit);
#pragma warning restore 618
            }

            [Fact]
            public void CtorWithValueAndUnitOfRepresentativeTypes_SetsValueAndUnit()
            {
                // double types
                var mass = new Mass<double>(5L, MassUnit.Centigram);
                Assert.Equal(5, mass.Value);
                Assert.Equal(MassUnit.Centigram, mass.Unit);

                // decimal types
                var information = new Information<decimal>(5, InformationUnit.Kibibit);
                Assert.Equal(5, information.Value);
                Assert.Equal(InformationUnit.Kibibit, information.Unit);

                // logarithmic types
                var level = new Level<double>(5, LevelUnit.Neper);
                Assert.Equal(5, level.Value);
                Assert.Equal(LevelUnit.Neper, level.Unit);
            }

            [Fact]
            public void Constructor_UnitSystemGivenNull_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => new Length<double>(1.0, null));
            }

            /// <summary>
            /// This test shows what quantities support the SI UnitSystem, which is not many.
            /// UnitSystem is still experimental and this design will probably change at some point as we see problems with ambiguity
            /// as well as representing anything else but the SI unit system like CGS or British Engineering Units.
            ///
            /// Extending the functionality of BaseUnits & UnitSystem · Issue #651 · angularsen/UnitsNet
            /// https://github.com/angularsen/UnitsNet/issues/651
            /// </summary>
            [Fact]
            public void Ctor_WithValueAndSIUnitSystem_ReturnsQuantityWithSIUnitOrThrowsArgumentExceptionIfNotImplemented()
            {
                AssertUnitValue(new Acceleration<double>(1, UnitSystem.SI), 1, AccelerationUnit.MeterPerSecondSquared);
                AssertUnitValue(new AmountOfSubstance<double>(1, UnitSystem.SI), 1, AmountOfSubstanceUnit.Mole);
                Assert.Throws<ArgumentException>(() => new AmplitudeRatio<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Angle<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ApparentEnergy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ApparentPower<double>(1, UnitSystem.SI));
                AssertUnitValue(new AreaDensity<double>(1, UnitSystem.SI), 1, AreaDensityUnit.KilogramPerSquareMeter);
                AssertUnitValue(new AreaMomentOfInertia<double>(1, UnitSystem.SI), 1, AreaMomentOfInertiaUnit.MeterToTheFourth);
                AssertUnitValue(new Area<double>(1, UnitSystem.SI), 1, AreaUnit.SquareMeter);
                Assert.Throws<ArgumentException>(() => new BitRate<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new BrakeSpecificFuelConsumption<double>(1, UnitSystem.SI));
                AssertUnitValue(new Capacitance<double>(1, UnitSystem.SI), 1, CapacitanceUnit.Farad);
                AssertUnitValue(new CoefficientOfThermalExpansion<double>(1, UnitSystem.SI), 1, CoefficientOfThermalExpansionUnit.InverseKelvin);
                Assert.Throws<ArgumentException>(() => new Density<double>(1, UnitSystem.SI));
                AssertUnitValue(new Duration<double>(1, UnitSystem.SI), 1, DurationUnit.Second);
                Assert.Throws<ArgumentException>(() => new DynamicViscosity<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricAdmittance<double>(1, UnitSystem.SI));
                AssertUnitValue(new ElectricChargeDensity<double>(1, UnitSystem.SI), 1, ElectricChargeDensityUnit.CoulombPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new ElectricCharge<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricConductance<double>(1, UnitSystem.SI));
                AssertUnitValue(new ElectricConductivity<double>(1, UnitSystem.SI), 1, ElectricConductivityUnit.SiemensPerMeter);
                AssertUnitValue(new ElectricCurrentDensity<double>(1, UnitSystem.SI), 1, ElectricCurrentDensityUnit.AmperePerSquareMeter);
                Assert.Throws<ArgumentException>(() => new ElectricCurrentGradient<double>(1, UnitSystem.SI));
                AssertUnitValue(new ElectricField<double>(1, UnitSystem.SI), 1, ElectricFieldUnit.VoltPerMeter);
                Assert.Throws<ArgumentException>(() => new ElectricInductance<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricPotentialAc<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricPotentialDc<double>(1, UnitSystem.SI));
                AssertUnitValue(new ElectricPotential<double>(1, UnitSystem.SI), 1, ElectricPotentialUnit.Volt);
                Assert.Throws<ArgumentException>(() => new ElectricResistance<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricResistivity<double>(1, UnitSystem.SI));
                AssertUnitValue(new ElectricSurfaceChargeDensity<double>(1, UnitSystem.SI), 1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter);
                AssertUnitValue(new Energy<double>(1, UnitSystem.SI), 1, EnergyUnit.Joule);
                Assert.Throws<ArgumentException>(() => new Entropy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ForceChangeRate<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ForcePerLength<double>(1, UnitSystem.SI));
                AssertUnitValue(new Force<double>(1, UnitSystem.SI), 1, ForceUnit.Newton);
                Assert.Throws<ArgumentException>(() => new Frequency<double>(1, UnitSystem.SI));
                AssertUnitValue(new HeatFlux<double>(1, UnitSystem.SI), 1, HeatFluxUnit.WattPerSquareMeter);
                Assert.Throws<ArgumentException>(() => new HeatTransferCoefficient<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Illuminance<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Information<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Irradiance<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Irradiation<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new KinematicViscosity<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LapseRate<double>(1, UnitSystem.SI));
                AssertUnitValue(new Length<double>(1, UnitSystem.SI), 1, LengthUnit.Meter);
                Assert.Throws<ArgumentException>(() => new Level<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LinearDensity<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Luminosity<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LuminousFlux<double>(1, UnitSystem.SI));
                AssertUnitValue(new LuminousIntensity<double>(1, UnitSystem.SI), 1, LuminousIntensityUnit.Candela);
                Assert.Throws<ArgumentException>(() => new MagneticField<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MagneticFlux<double>(1, UnitSystem.SI));
                AssertUnitValue(new Magnetization<double>(1, UnitSystem.SI), 1, MagnetizationUnit.AmperePerMeter);
                Assert.Throws<ArgumentException>(() => new MassConcentration<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFlow<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFlux<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFraction<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassMomentOfInertia<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Mass<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MolarEnergy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MolarEntropy<double>(1, UnitSystem.SI));
                AssertUnitValue(new Molarity<double>(1, UnitSystem.SI), 1, MolarityUnit.MolesPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new MolarMass<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Permeability<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Permittivity<double>(1, UnitSystem.SI));
                AssertUnitValue(new PowerDensity<double>(1, UnitSystem.SI), 1, PowerDensityUnit.WattPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new PowerRatio<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Power<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new PressureChangeRate<double>(1, UnitSystem.SI));
                AssertUnitValue(new Pressure<double>(1, UnitSystem.SI), 1, PressureUnit.Pascal);
                Assert.Throws<ArgumentException>(() => new RatioChangeRate<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Ratio<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ReactiveEnergy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ReactivePower<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalAcceleration<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalSpeed<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalStiffness<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SolidAngle<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificEnergy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificEntropy<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificVolume<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificWeight<double>(1, UnitSystem.SI));
                AssertUnitValue(new Speed<double>(1, UnitSystem.SI), 1, SpeedUnit.MeterPerSecond);
                Assert.Throws<ArgumentException>(() => new TemperatureChangeRate<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new TemperatureDelta<double>(1, UnitSystem.SI));
                AssertUnitValue(new Temperature<double>(1, UnitSystem.SI), 1, TemperatureUnit.Kelvin);
                Assert.Throws<ArgumentException>(() => new ThermalConductivity<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ThermalResistance<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Torque<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VitaminA<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VolumeConcentration<double>(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VolumeFlow<double>(1, UnitSystem.SI));
                AssertUnitValue(new VolumePerLength<double>(1, UnitSystem.SI), 1, VolumePerLengthUnit.CubicMeterPerMeter);
                Assert.Throws<ArgumentException>(() => new Volume<double>(1, UnitSystem.SI));
            }

            private static void AssertUnitValue(IQuantity actual, double expectedValue, Enum expectedUnit)
            {
                Assert.Equal(expectedValue, actual.Value);
                Assert.Equal(expectedUnit, actual.Unit);
            }
        }
    }
}
