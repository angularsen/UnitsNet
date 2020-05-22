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
                AssertUnitValue(new Acceleration(1, UnitSystem.SI), 1, AccelerationUnit.MeterPerSecondSquared);
                AssertUnitValue(new AmountOfSubstance(1, UnitSystem.SI), 1, AmountOfSubstanceUnit.Mole);
                Assert.Throws<ArgumentException>(() => new AmplitudeRatio(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Angle(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ApparentEnergy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ApparentPower(1, UnitSystem.SI));
                AssertUnitValue(new AreaDensity(1, UnitSystem.SI), 1, AreaDensityUnit.KilogramPerSquareMeter);
                AssertUnitValue(new AreaMomentOfInertia(1, UnitSystem.SI), 1, AreaMomentOfInertiaUnit.MeterToTheFourth);
                AssertUnitValue(new Area(1, UnitSystem.SI), 1, AreaUnit.SquareMeter);
                Assert.Throws<ArgumentException>(() => new BitRate(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new BrakeSpecificFuelConsumption(1, UnitSystem.SI));
                AssertUnitValue(new Capacitance(1, UnitSystem.SI), 1, CapacitanceUnit.Farad);
                AssertUnitValue(new CoefficientOfThermalExpansion(1, UnitSystem.SI), 1, CoefficientOfThermalExpansionUnit.InverseKelvin);
                Assert.Throws<ArgumentException>(() => new Density(1, UnitSystem.SI));
                AssertUnitValue(new Duration(1, UnitSystem.SI), 1, DurationUnit.Second);
                Assert.Throws<ArgumentException>(() => new DynamicViscosity(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricAdmittance(1, UnitSystem.SI));
                AssertUnitValue(new ElectricChargeDensity(1, UnitSystem.SI), 1, ElectricChargeDensityUnit.CoulombPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new ElectricCharge(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricConductance(1, UnitSystem.SI));
                AssertUnitValue(new ElectricConductivity(1, UnitSystem.SI), 1, ElectricConductivityUnit.SiemensPerMeter);
                AssertUnitValue(new ElectricCurrentDensity(1, UnitSystem.SI), 1, ElectricCurrentDensityUnit.AmperePerSquareMeter);
                Assert.Throws<ArgumentException>(() => new ElectricCurrentGradient(1, UnitSystem.SI));
                AssertUnitValue(new ElectricField(1, UnitSystem.SI), 1, ElectricFieldUnit.VoltPerMeter);
                Assert.Throws<ArgumentException>(() => new ElectricInductance(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricPotentialAc(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricPotentialDc(1, UnitSystem.SI));
                AssertUnitValue(new ElectricPotential(1, UnitSystem.SI), 1, ElectricPotentialUnit.Volt);
                Assert.Throws<ArgumentException>(() => new ElectricResistance(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ElectricResistivity(1, UnitSystem.SI));
                AssertUnitValue(new ElectricSurfaceChargeDensity(1, UnitSystem.SI), 1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter);
                AssertUnitValue(new Energy(1, UnitSystem.SI), 1, EnergyUnit.Joule);
                Assert.Throws<ArgumentException>(() => new Entropy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ForceChangeRate(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ForcePerLength(1, UnitSystem.SI));
                AssertUnitValue(new Force(1, UnitSystem.SI), 1, ForceUnit.Newton);
                Assert.Throws<ArgumentException>(() => new Frequency(1, UnitSystem.SI));
                AssertUnitValue(new HeatFlux(1, UnitSystem.SI), 1, HeatFluxUnit.WattPerSquareMeter);
                Assert.Throws<ArgumentException>(() => new HeatTransferCoefficient(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Illuminance(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Information(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Irradiance(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Irradiation(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new KinematicViscosity(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LapseRate(1, UnitSystem.SI));
                AssertUnitValue(new Length(1, UnitSystem.SI), 1, LengthUnit.Meter);
                Assert.Throws<ArgumentException>(() => new Level(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LinearDensity(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Luminosity(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new LuminousFlux(1, UnitSystem.SI));
                AssertUnitValue(new LuminousIntensity(1, UnitSystem.SI), 1, LuminousIntensityUnit.Candela);
                Assert.Throws<ArgumentException>(() => new MagneticField(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MagneticFlux(1, UnitSystem.SI));
                AssertUnitValue(new Magnetization(1, UnitSystem.SI), 1, MagnetizationUnit.AmperePerMeter);
                Assert.Throws<ArgumentException>(() => new MassConcentration(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFlow(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFlux(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassFraction(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MassMomentOfInertia(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Mass(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MolarEnergy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new MolarEntropy(1, UnitSystem.SI));
                AssertUnitValue(new Molarity(1, UnitSystem.SI), 1, MolarityUnit.MolesPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new MolarMass(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Permeability(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Permittivity(1, UnitSystem.SI));
                AssertUnitValue(new PowerDensity(1, UnitSystem.SI), 1, PowerDensityUnit.WattPerCubicMeter);
                Assert.Throws<ArgumentException>(() => new PowerRatio(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Power(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new PressureChangeRate(1, UnitSystem.SI));
                AssertUnitValue(new Pressure(1, UnitSystem.SI), 1, PressureUnit.Pascal);
                Assert.Throws<ArgumentException>(() => new RatioChangeRate(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Ratio(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ReactiveEnergy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ReactivePower(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalAcceleration(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalSpeed(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new RotationalStiffness(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SolidAngle(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificEnergy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificEntropy(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificVolume(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new SpecificWeight(1, UnitSystem.SI));
                AssertUnitValue(new Speed(1, UnitSystem.SI), 1, SpeedUnit.MeterPerSecond);
                Assert.Throws<ArgumentException>(() => new TemperatureChangeRate(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new TemperatureDelta(1, UnitSystem.SI));
                AssertUnitValue(new Temperature(1, UnitSystem.SI), 1, TemperatureUnit.Kelvin);
                Assert.Throws<ArgumentException>(() => new ThermalConductivity(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new ThermalResistance(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new Torque(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VitaminA(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VolumeConcentration(1, UnitSystem.SI));
                Assert.Throws<ArgumentException>(() => new VolumeFlow(1, UnitSystem.SI));
                AssertUnitValue(new VolumePerLength(1, UnitSystem.SI), 1, VolumePerLengthUnit.CubicMeterPerMeter);
                Assert.Throws<ArgumentException>(() => new Volume(1, UnitSystem.SI));
            }

            private static void AssertUnitValue(IQuantity actual, double expectedValue, Enum expectedUnit)
            {
                Assert.Equal(expectedValue, actual.Value);
                Assert.Equal(expectedUnit, actual.Unit);
            }
        }
    }
}
