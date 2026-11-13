// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class ThermalConductanceTests : ThermalConductanceTestsBase
    {
        protected override double WattsPerKelvinInOneWattPerKelvin => 1;

        protected override double WattsPerDegreeCelsiusInOneWattPerKelvin => 1;

        protected override double KilowattsPerDegreeCelsiusInOneWattPerKelvin => 1E-3;

        protected override double KilowattsPerKelvinInOneWattPerKelvin => 1E-3;

        // NIST SP 811, Appendix B.9: 1 Btu_IT/h = 2.930711E-01 W, and 1 °F (interval) = 5/9 K.
        // 1 W/K = 1 / (0.2930711 × 1.8) Btu_IT/(h·°F) ≈ 1.895634.
        protected override double BtusPerHourDegreeFahrenheitInOneWattPerKelvin => 1.895634;

        [Fact]
        public void ThermalConductanceTimesTemperatureDeltaEqualsPower()
        {
            ThermalConductance thermalConductance = ThermalConductance.FromWattsPerKelvin(2);
            TemperatureDelta temperatureDelta = TemperatureDelta.FromKelvins(6);
            Power expected = Power.FromWatts(12);

            Assert.Equal(expected, thermalConductance * temperatureDelta);
            Assert.Equal(expected, temperatureDelta * thermalConductance);
            Assert.Equal(temperatureDelta, expected / thermalConductance);
            Assert.Equal(thermalConductance, expected / temperatureDelta);
        }

        [Fact]
        public void ThermalConductivityTimesLengthEqualsThermalConductance()
        {
            ThermalConductivity thermalConductivity = ThermalConductivity.FromWattsPerMeterKelvin(0.5);
            Length length = Length.FromMeters(4);
            ThermalConductance expected = ThermalConductance.FromWattsPerKelvin(2);

            Assert.Equal(expected, thermalConductivity * length);
            Assert.Equal(expected, length * thermalConductivity);
            Assert.Equal(length, expected / thermalConductivity);
            Assert.Equal(thermalConductivity, expected / length);
        }

        [Fact]
        public void HeatTransferCoefficientTimesAreaEqualsThermalConductance()
        {
            HeatTransferCoefficient heatTransferCoefficient = HeatTransferCoefficient.FromWattsPerSquareMeterKelvin(25);
            Area area = Area.FromSquareMeters(2);
            ThermalConductance expected = ThermalConductance.FromWattsPerKelvin(50);

            Assert.Equal(expected, heatTransferCoefficient * area);
            Assert.Equal(expected, area * heatTransferCoefficient);
            Assert.Equal(area, expected / heatTransferCoefficient);
            Assert.Equal(heatTransferCoefficient, expected / area);
        }

        [Fact]
        public static void InverseThermalConductanceEqualsThermalResistance()
        {
            ThermalResistance thermalResistance = ThermalConductance.FromKilowattsPerKelvin(4).Inverse();
            Assert.Equal(thermalResistance, ThermalResistance.FromKelvinsPerWatt(0.00025));
        }

        [Fact]
        public static void Inverse_WattsPerDegreeCelsius_ReturnsDegreesCelsiusPerWatt()
        {
            ThermalResistance thermalResistance = ThermalConductance.FromWattsPerDegreeCelsius(4).Inverse();

            Assert.Equal(ThermalResistance.FromDegreesCelsiusPerWatt(0.25), thermalResistance);
            Assert.Equal(ThermalResistanceUnit.DegreeCelsiusPerWatt, thermalResistance.Unit);
        }

        [Fact]
        public static void Inverse_BtusPerHourDegreeFahrenheit_ReturnsKelvinsPerWatt()
        {
            ThermalResistance thermalResistance = ThermalConductance.FromBtusPerHourDegreeFahrenheit(1).Inverse();

            // 1 Btu_IT/(h·°F) = 0.2930711 W × 1.8 / K ≈ 0.527528 W/K (NIST SP 811), so its inverse is ≈ 1.895634 K/W.
            AssertEx.EqualTolerance(1.895634, thermalResistance.KelvinsPerWatt, 1e-5);
        }
    }
}
