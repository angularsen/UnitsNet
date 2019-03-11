﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Dynamically parse or construct quantities when types are only known at runtime.
    /// </summary>
    internal static partial class Quantity
    {
        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name="quantity"/> assigned the value, otherwise <c>false</c>.</returns>
        internal static bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            switch (unit)
            {
                case AccelerationUnit accelerationUnit:
                    quantity = Acceleration.From(value, accelerationUnit);
                    return true;
                case AmountOfSubstanceUnit amountOfSubstanceUnit:
                    quantity = AmountOfSubstance.From(value, amountOfSubstanceUnit);
                    return true;
                case AmplitudeRatioUnit amplitudeRatioUnit:
                    quantity = AmplitudeRatio.From(value, amplitudeRatioUnit);
                    return true;
                case AngleUnit angleUnit:
                    quantity = Angle.From(value, angleUnit);
                    return true;
                case ApparentEnergyUnit apparentEnergyUnit:
                    quantity = ApparentEnergy.From(value, apparentEnergyUnit);
                    return true;
                case ApparentPowerUnit apparentPowerUnit:
                    quantity = ApparentPower.From(value, apparentPowerUnit);
                    return true;
                case AreaUnit areaUnit:
                    quantity = Area.From(value, areaUnit);
                    return true;
                case AreaDensityUnit areaDensityUnit:
                    quantity = AreaDensity.From(value, areaDensityUnit);
                    return true;
                case AreaMomentOfInertiaUnit areaMomentOfInertiaUnit:
                    quantity = AreaMomentOfInertia.From(value, areaMomentOfInertiaUnit);
                    return true;
                case BitRateUnit bitRateUnit:
                    quantity = BitRate.From(value, bitRateUnit);
                    return true;
                case BrakeSpecificFuelConsumptionUnit brakeSpecificFuelConsumptionUnit:
                    quantity = BrakeSpecificFuelConsumption.From(value, brakeSpecificFuelConsumptionUnit);
                    return true;
                case CapacitanceUnit capacitanceUnit:
                    quantity = Capacitance.From(value, capacitanceUnit);
                    return true;
                case CoefficientOfThermalExpansionUnit coefficientOfThermalExpansionUnit:
                    quantity = CoefficientOfThermalExpansion.From(value, coefficientOfThermalExpansionUnit);
                    return true;
                case DensityUnit densityUnit:
                    quantity = Density.From(value, densityUnit);
                    return true;
                case DurationUnit durationUnit:
                    quantity = Duration.From(value, durationUnit);
                    return true;
                case DynamicViscosityUnit dynamicViscosityUnit:
                    quantity = DynamicViscosity.From(value, dynamicViscosityUnit);
                    return true;
                case ElectricAdmittanceUnit electricAdmittanceUnit:
                    quantity = ElectricAdmittance.From(value, electricAdmittanceUnit);
                    return true;
                case ElectricChargeUnit electricChargeUnit:
                    quantity = ElectricCharge.From(value, electricChargeUnit);
                    return true;
                case ElectricChargeDensityUnit electricChargeDensityUnit:
                    quantity = ElectricChargeDensity.From(value, electricChargeDensityUnit);
                    return true;
                case ElectricConductanceUnit electricConductanceUnit:
                    quantity = ElectricConductance.From(value, electricConductanceUnit);
                    return true;
                case ElectricConductivityUnit electricConductivityUnit:
                    quantity = ElectricConductivity.From(value, electricConductivityUnit);
                    return true;
                case ElectricCurrentUnit electricCurrentUnit:
                    quantity = ElectricCurrent.From(value, electricCurrentUnit);
                    return true;
                case ElectricCurrentDensityUnit electricCurrentDensityUnit:
                    quantity = ElectricCurrentDensity.From(value, electricCurrentDensityUnit);
                    return true;
                case ElectricCurrentGradientUnit electricCurrentGradientUnit:
                    quantity = ElectricCurrentGradient.From(value, electricCurrentGradientUnit);
                    return true;
                case ElectricFieldUnit electricFieldUnit:
                    quantity = ElectricField.From(value, electricFieldUnit);
                    return true;
                case ElectricInductanceUnit electricInductanceUnit:
                    quantity = ElectricInductance.From(value, electricInductanceUnit);
                    return true;
                case ElectricPotentialUnit electricPotentialUnit:
                    quantity = ElectricPotential.From(value, electricPotentialUnit);
                    return true;
                case ElectricPotentialAcUnit electricPotentialAcUnit:
                    quantity = ElectricPotentialAc.From(value, electricPotentialAcUnit);
                    return true;
                case ElectricPotentialDcUnit electricPotentialDcUnit:
                    quantity = ElectricPotentialDc.From(value, electricPotentialDcUnit);
                    return true;
                case ElectricResistanceUnit electricResistanceUnit:
                    quantity = ElectricResistance.From(value, electricResistanceUnit);
                    return true;
                case ElectricResistivityUnit electricResistivityUnit:
                    quantity = ElectricResistivity.From(value, electricResistivityUnit);
                    return true;
                case ElectricSurfaceChargeDensityUnit electricSurfaceChargeDensityUnit:
                    quantity = ElectricSurfaceChargeDensity.From(value, electricSurfaceChargeDensityUnit);
                    return true;
                case EnergyUnit energyUnit:
                    quantity = Energy.From(value, energyUnit);
                    return true;
                case EntropyUnit entropyUnit:
                    quantity = Entropy.From(value, entropyUnit);
                    return true;
                case ForceUnit forceUnit:
                    quantity = Force.From(value, forceUnit);
                    return true;
                case ForceChangeRateUnit forceChangeRateUnit:
                    quantity = ForceChangeRate.From(value, forceChangeRateUnit);
                    return true;
                case ForcePerLengthUnit forcePerLengthUnit:
                    quantity = ForcePerLength.From(value, forcePerLengthUnit);
                    return true;
                case FrequencyUnit frequencyUnit:
                    quantity = Frequency.From(value, frequencyUnit);
                    return true;
                case HeatFluxUnit heatFluxUnit:
                    quantity = HeatFlux.From(value, heatFluxUnit);
                    return true;
                case HeatTransferCoefficientUnit heatTransferCoefficientUnit:
                    quantity = HeatTransferCoefficient.From(value, heatTransferCoefficientUnit);
                    return true;
                case IlluminanceUnit illuminanceUnit:
                    quantity = Illuminance.From(value, illuminanceUnit);
                    return true;
                case InformationUnit informationUnit:
                    quantity = Information.From(value, informationUnit);
                    return true;
                case IrradianceUnit irradianceUnit:
                    quantity = Irradiance.From(value, irradianceUnit);
                    return true;
                case IrradiationUnit irradiationUnit:
                    quantity = Irradiation.From(value, irradiationUnit);
                    return true;
                case KinematicViscosityUnit kinematicViscosityUnit:
                    quantity = KinematicViscosity.From(value, kinematicViscosityUnit);
                    return true;
                case LapseRateUnit lapseRateUnit:
                    quantity = LapseRate.From(value, lapseRateUnit);
                    return true;
                case LengthUnit lengthUnit:
                    quantity = Length.From(value, lengthUnit);
                    return true;
                case LevelUnit levelUnit:
                    quantity = Level.From(value, levelUnit);
                    return true;
                case LinearDensityUnit linearDensityUnit:
                    quantity = LinearDensity.From(value, linearDensityUnit);
                    return true;
                case LuminousFluxUnit luminousFluxUnit:
                    quantity = LuminousFlux.From(value, luminousFluxUnit);
                    return true;
                case LuminousIntensityUnit luminousIntensityUnit:
                    quantity = LuminousIntensity.From(value, luminousIntensityUnit);
                    return true;
                case MagneticFieldUnit magneticFieldUnit:
                    quantity = MagneticField.From(value, magneticFieldUnit);
                    return true;
                case MagneticFluxUnit magneticFluxUnit:
                    quantity = MagneticFlux.From(value, magneticFluxUnit);
                    return true;
                case MagnetizationUnit magnetizationUnit:
                    quantity = Magnetization.From(value, magnetizationUnit);
                    return true;
                case MassUnit massUnit:
                    quantity = Mass.From(value, massUnit);
                    return true;
                case MassFlowUnit massFlowUnit:
                    quantity = MassFlow.From(value, massFlowUnit);
                    return true;
                case MassFluxUnit massFluxUnit:
                    quantity = MassFlux.From(value, massFluxUnit);
                    return true;
                case MassMomentOfInertiaUnit massMomentOfInertiaUnit:
                    quantity = MassMomentOfInertia.From(value, massMomentOfInertiaUnit);
                    return true;
                case MolarEnergyUnit molarEnergyUnit:
                    quantity = MolarEnergy.From(value, molarEnergyUnit);
                    return true;
                case MolarEntropyUnit molarEntropyUnit:
                    quantity = MolarEntropy.From(value, molarEntropyUnit);
                    return true;
                case MolarityUnit molarityUnit:
                    quantity = Molarity.From(value, molarityUnit);
                    return true;
                case MolarMassUnit molarMassUnit:
                    quantity = MolarMass.From(value, molarMassUnit);
                    return true;
                case PermeabilityUnit permeabilityUnit:
                    quantity = Permeability.From(value, permeabilityUnit);
                    return true;
                case PermittivityUnit permittivityUnit:
                    quantity = Permittivity.From(value, permittivityUnit);
                    return true;
                case PowerUnit powerUnit:
                    quantity = Power.From(value, powerUnit);
                    return true;
                case PowerDensityUnit powerDensityUnit:
                    quantity = PowerDensity.From(value, powerDensityUnit);
                    return true;
                case PowerRatioUnit powerRatioUnit:
                    quantity = PowerRatio.From(value, powerRatioUnit);
                    return true;
                case PressureUnit pressureUnit:
                    quantity = Pressure.From(value, pressureUnit);
                    return true;
                case PressureChangeRateUnit pressureChangeRateUnit:
                    quantity = PressureChangeRate.From(value, pressureChangeRateUnit);
                    return true;
                case RatioUnit ratioUnit:
                    quantity = Ratio.From(value, ratioUnit);
                    return true;
                case ReactiveEnergyUnit reactiveEnergyUnit:
                    quantity = ReactiveEnergy.From(value, reactiveEnergyUnit);
                    return true;
                case ReactivePowerUnit reactivePowerUnit:
                    quantity = ReactivePower.From(value, reactivePowerUnit);
                    return true;
                case RotationalAccelerationUnit rotationalAccelerationUnit:
                    quantity = RotationalAcceleration.From(value, rotationalAccelerationUnit);
                    return true;
                case RotationalSpeedUnit rotationalSpeedUnit:
                    quantity = RotationalSpeed.From(value, rotationalSpeedUnit);
                    return true;
                case RotationalStiffnessUnit rotationalStiffnessUnit:
                    quantity = RotationalStiffness.From(value, rotationalStiffnessUnit);
                    return true;
                case RotationalStiffnessPerLengthUnit rotationalStiffnessPerLengthUnit:
                    quantity = RotationalStiffnessPerLength.From(value, rotationalStiffnessPerLengthUnit);
                    return true;
                case SolidAngleUnit solidAngleUnit:
                    quantity = SolidAngle.From(value, solidAngleUnit);
                    return true;
                case SpecificEnergyUnit specificEnergyUnit:
                    quantity = SpecificEnergy.From(value, specificEnergyUnit);
                    return true;
                case SpecificEntropyUnit specificEntropyUnit:
                    quantity = SpecificEntropy.From(value, specificEntropyUnit);
                    return true;
                case SpecificVolumeUnit specificVolumeUnit:
                    quantity = SpecificVolume.From(value, specificVolumeUnit);
                    return true;
                case SpecificWeightUnit specificWeightUnit:
                    quantity = SpecificWeight.From(value, specificWeightUnit);
                    return true;
                case SpeedUnit speedUnit:
                    quantity = Speed.From(value, speedUnit);
                    return true;
                case TemperatureUnit temperatureUnit:
                    quantity = Temperature.From(value, temperatureUnit);
                    return true;
                case TemperatureChangeRateUnit temperatureChangeRateUnit:
                    quantity = TemperatureChangeRate.From(value, temperatureChangeRateUnit);
                    return true;
                case TemperatureDeltaUnit temperatureDeltaUnit:
                    quantity = TemperatureDelta.From(value, temperatureDeltaUnit);
                    return true;
                case ThermalConductivityUnit thermalConductivityUnit:
                    quantity = ThermalConductivity.From(value, thermalConductivityUnit);
                    return true;
                case ThermalResistanceUnit thermalResistanceUnit:
                    quantity = ThermalResistance.From(value, thermalResistanceUnit);
                    return true;
                case TorqueUnit torqueUnit:
                    quantity = Torque.From(value, torqueUnit);
                    return true;
                case VitaminAUnit vitaminAUnit:
                    quantity = VitaminA.From(value, vitaminAUnit);
                    return true;
                case VolumeUnit volumeUnit:
                    quantity = Volume.From(value, volumeUnit);
                    return true;
                case VolumeFlowUnit volumeFlowUnit:
                    quantity = VolumeFlow.From(value, volumeFlowUnit);
                    return true;
                case VolumePerLengthUnit volumePerLengthUnit:
                    quantity = VolumePerLength.From(value, volumePerLengthUnit);
                    return true;
                default:
                {
                    quantity = default(IQuantity);
                    return false;
                }
            }
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        internal static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        internal static IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity quantity)) return quantity;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        internal static bool TryParse(Type quantityType, string quantityString, out IQuantity quantity) =>
            TryParse(null, quantityType, quantityString, out quantity);

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        internal static bool TryParse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString, out IQuantity quantity)
        {
            quantity = default(IQuantity);

            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                return false;

            var parser = QuantityParser.Default;

            if (quantityType == typeof(Acceleration))
                return parser.TryParse<Acceleration, AccelerationUnit>(quantityString, formatProvider, Acceleration.From, out quantity);

            if (quantityType == typeof(AmountOfSubstance))
                return parser.TryParse<AmountOfSubstance, AmountOfSubstanceUnit>(quantityString, formatProvider, AmountOfSubstance.From, out quantity);

            if (quantityType == typeof(AmplitudeRatio))
                return parser.TryParse<AmplitudeRatio, AmplitudeRatioUnit>(quantityString, formatProvider, AmplitudeRatio.From, out quantity);

            if (quantityType == typeof(Angle))
                return parser.TryParse<Angle, AngleUnit>(quantityString, formatProvider, Angle.From, out quantity);

            if (quantityType == typeof(ApparentEnergy))
                return parser.TryParse<ApparentEnergy, ApparentEnergyUnit>(quantityString, formatProvider, ApparentEnergy.From, out quantity);

            if (quantityType == typeof(ApparentPower))
                return parser.TryParse<ApparentPower, ApparentPowerUnit>(quantityString, formatProvider, ApparentPower.From, out quantity);

            if (quantityType == typeof(Area))
                return parser.TryParse<Area, AreaUnit>(quantityString, formatProvider, Area.From, out quantity);

            if (quantityType == typeof(AreaDensity))
                return parser.TryParse<AreaDensity, AreaDensityUnit>(quantityString, formatProvider, AreaDensity.From, out quantity);

            if (quantityType == typeof(AreaMomentOfInertia))
                return parser.TryParse<AreaMomentOfInertia, AreaMomentOfInertiaUnit>(quantityString, formatProvider, AreaMomentOfInertia.From, out quantity);

            if (quantityType == typeof(BitRate))
                return parser.TryParse<BitRate, BitRateUnit>(quantityString, formatProvider, BitRate.From, out quantity);

            if (quantityType == typeof(BrakeSpecificFuelConsumption))
                return parser.TryParse<BrakeSpecificFuelConsumption, BrakeSpecificFuelConsumptionUnit>(quantityString, formatProvider, BrakeSpecificFuelConsumption.From, out quantity);

            if (quantityType == typeof(Capacitance))
                return parser.TryParse<Capacitance, CapacitanceUnit>(quantityString, formatProvider, Capacitance.From, out quantity);

            if (quantityType == typeof(CoefficientOfThermalExpansion))
                return parser.TryParse<CoefficientOfThermalExpansion, CoefficientOfThermalExpansionUnit>(quantityString, formatProvider, CoefficientOfThermalExpansion.From, out quantity);

            if (quantityType == typeof(Density))
                return parser.TryParse<Density, DensityUnit>(quantityString, formatProvider, Density.From, out quantity);

            if (quantityType == typeof(Duration))
                return parser.TryParse<Duration, DurationUnit>(quantityString, formatProvider, Duration.From, out quantity);

            if (quantityType == typeof(DynamicViscosity))
                return parser.TryParse<DynamicViscosity, DynamicViscosityUnit>(quantityString, formatProvider, DynamicViscosity.From, out quantity);

            if (quantityType == typeof(ElectricAdmittance))
                return parser.TryParse<ElectricAdmittance, ElectricAdmittanceUnit>(quantityString, formatProvider, ElectricAdmittance.From, out quantity);

            if (quantityType == typeof(ElectricCharge))
                return parser.TryParse<ElectricCharge, ElectricChargeUnit>(quantityString, formatProvider, ElectricCharge.From, out quantity);

            if (quantityType == typeof(ElectricChargeDensity))
                return parser.TryParse<ElectricChargeDensity, ElectricChargeDensityUnit>(quantityString, formatProvider, ElectricChargeDensity.From, out quantity);

            if (quantityType == typeof(ElectricConductance))
                return parser.TryParse<ElectricConductance, ElectricConductanceUnit>(quantityString, formatProvider, ElectricConductance.From, out quantity);

            if (quantityType == typeof(ElectricConductivity))
                return parser.TryParse<ElectricConductivity, ElectricConductivityUnit>(quantityString, formatProvider, ElectricConductivity.From, out quantity);

            if (quantityType == typeof(ElectricCurrent))
                return parser.TryParse<ElectricCurrent, ElectricCurrentUnit>(quantityString, formatProvider, ElectricCurrent.From, out quantity);

            if (quantityType == typeof(ElectricCurrentDensity))
                return parser.TryParse<ElectricCurrentDensity, ElectricCurrentDensityUnit>(quantityString, formatProvider, ElectricCurrentDensity.From, out quantity);

            if (quantityType == typeof(ElectricCurrentGradient))
                return parser.TryParse<ElectricCurrentGradient, ElectricCurrentGradientUnit>(quantityString, formatProvider, ElectricCurrentGradient.From, out quantity);

            if (quantityType == typeof(ElectricField))
                return parser.TryParse<ElectricField, ElectricFieldUnit>(quantityString, formatProvider, ElectricField.From, out quantity);

            if (quantityType == typeof(ElectricInductance))
                return parser.TryParse<ElectricInductance, ElectricInductanceUnit>(quantityString, formatProvider, ElectricInductance.From, out quantity);

            if (quantityType == typeof(ElectricPotential))
                return parser.TryParse<ElectricPotential, ElectricPotentialUnit>(quantityString, formatProvider, ElectricPotential.From, out quantity);

            if (quantityType == typeof(ElectricPotentialAc))
                return parser.TryParse<ElectricPotentialAc, ElectricPotentialAcUnit>(quantityString, formatProvider, ElectricPotentialAc.From, out quantity);

            if (quantityType == typeof(ElectricPotentialDc))
                return parser.TryParse<ElectricPotentialDc, ElectricPotentialDcUnit>(quantityString, formatProvider, ElectricPotentialDc.From, out quantity);

            if (quantityType == typeof(ElectricResistance))
                return parser.TryParse<ElectricResistance, ElectricResistanceUnit>(quantityString, formatProvider, ElectricResistance.From, out quantity);

            if (quantityType == typeof(ElectricResistivity))
                return parser.TryParse<ElectricResistivity, ElectricResistivityUnit>(quantityString, formatProvider, ElectricResistivity.From, out quantity);

            if (quantityType == typeof(ElectricSurfaceChargeDensity))
                return parser.TryParse<ElectricSurfaceChargeDensity, ElectricSurfaceChargeDensityUnit>(quantityString, formatProvider, ElectricSurfaceChargeDensity.From, out quantity);

            if (quantityType == typeof(Energy))
                return parser.TryParse<Energy, EnergyUnit>(quantityString, formatProvider, Energy.From, out quantity);

            if (quantityType == typeof(Entropy))
                return parser.TryParse<Entropy, EntropyUnit>(quantityString, formatProvider, Entropy.From, out quantity);

            if (quantityType == typeof(Force))
                return parser.TryParse<Force, ForceUnit>(quantityString, formatProvider, Force.From, out quantity);

            if (quantityType == typeof(ForceChangeRate))
                return parser.TryParse<ForceChangeRate, ForceChangeRateUnit>(quantityString, formatProvider, ForceChangeRate.From, out quantity);

            if (quantityType == typeof(ForcePerLength))
                return parser.TryParse<ForcePerLength, ForcePerLengthUnit>(quantityString, formatProvider, ForcePerLength.From, out quantity);

            if (quantityType == typeof(Frequency))
                return parser.TryParse<Frequency, FrequencyUnit>(quantityString, formatProvider, Frequency.From, out quantity);

            if (quantityType == typeof(HeatFlux))
                return parser.TryParse<HeatFlux, HeatFluxUnit>(quantityString, formatProvider, HeatFlux.From, out quantity);

            if (quantityType == typeof(HeatTransferCoefficient))
                return parser.TryParse<HeatTransferCoefficient, HeatTransferCoefficientUnit>(quantityString, formatProvider, HeatTransferCoefficient.From, out quantity);

            if (quantityType == typeof(Illuminance))
                return parser.TryParse<Illuminance, IlluminanceUnit>(quantityString, formatProvider, Illuminance.From, out quantity);

            if (quantityType == typeof(Information))
                return parser.TryParse<Information, InformationUnit>(quantityString, formatProvider, Information.From, out quantity);

            if (quantityType == typeof(Irradiance))
                return parser.TryParse<Irradiance, IrradianceUnit>(quantityString, formatProvider, Irradiance.From, out quantity);

            if (quantityType == typeof(Irradiation))
                return parser.TryParse<Irradiation, IrradiationUnit>(quantityString, formatProvider, Irradiation.From, out quantity);

            if (quantityType == typeof(KinematicViscosity))
                return parser.TryParse<KinematicViscosity, KinematicViscosityUnit>(quantityString, formatProvider, KinematicViscosity.From, out quantity);

            if (quantityType == typeof(LapseRate))
                return parser.TryParse<LapseRate, LapseRateUnit>(quantityString, formatProvider, LapseRate.From, out quantity);

            if (quantityType == typeof(Length))
                return parser.TryParse<Length, LengthUnit>(quantityString, formatProvider, Length.From, out quantity);

            if (quantityType == typeof(Level))
                return parser.TryParse<Level, LevelUnit>(quantityString, formatProvider, Level.From, out quantity);

            if (quantityType == typeof(LinearDensity))
                return parser.TryParse<LinearDensity, LinearDensityUnit>(quantityString, formatProvider, LinearDensity.From, out quantity);

            if (quantityType == typeof(LuminousFlux))
                return parser.TryParse<LuminousFlux, LuminousFluxUnit>(quantityString, formatProvider, LuminousFlux.From, out quantity);

            if (quantityType == typeof(LuminousIntensity))
                return parser.TryParse<LuminousIntensity, LuminousIntensityUnit>(quantityString, formatProvider, LuminousIntensity.From, out quantity);

            if (quantityType == typeof(MagneticField))
                return parser.TryParse<MagneticField, MagneticFieldUnit>(quantityString, formatProvider, MagneticField.From, out quantity);

            if (quantityType == typeof(MagneticFlux))
                return parser.TryParse<MagneticFlux, MagneticFluxUnit>(quantityString, formatProvider, MagneticFlux.From, out quantity);

            if (quantityType == typeof(Magnetization))
                return parser.TryParse<Magnetization, MagnetizationUnit>(quantityString, formatProvider, Magnetization.From, out quantity);

            if (quantityType == typeof(Mass))
                return parser.TryParse<Mass, MassUnit>(quantityString, formatProvider, Mass.From, out quantity);

            if (quantityType == typeof(MassFlow))
                return parser.TryParse<MassFlow, MassFlowUnit>(quantityString, formatProvider, MassFlow.From, out quantity);

            if (quantityType == typeof(MassFlux))
                return parser.TryParse<MassFlux, MassFluxUnit>(quantityString, formatProvider, MassFlux.From, out quantity);

            if (quantityType == typeof(MassMomentOfInertia))
                return parser.TryParse<MassMomentOfInertia, MassMomentOfInertiaUnit>(quantityString, formatProvider, MassMomentOfInertia.From, out quantity);

            if (quantityType == typeof(MolarEnergy))
                return parser.TryParse<MolarEnergy, MolarEnergyUnit>(quantityString, formatProvider, MolarEnergy.From, out quantity);

            if (quantityType == typeof(MolarEntropy))
                return parser.TryParse<MolarEntropy, MolarEntropyUnit>(quantityString, formatProvider, MolarEntropy.From, out quantity);

            if (quantityType == typeof(Molarity))
                return parser.TryParse<Molarity, MolarityUnit>(quantityString, formatProvider, Molarity.From, out quantity);

            if (quantityType == typeof(MolarMass))
                return parser.TryParse<MolarMass, MolarMassUnit>(quantityString, formatProvider, MolarMass.From, out quantity);

            if (quantityType == typeof(Permeability))
                return parser.TryParse<Permeability, PermeabilityUnit>(quantityString, formatProvider, Permeability.From, out quantity);

            if (quantityType == typeof(Permittivity))
                return parser.TryParse<Permittivity, PermittivityUnit>(quantityString, formatProvider, Permittivity.From, out quantity);

            if (quantityType == typeof(Power))
                return parser.TryParse<Power, PowerUnit>(quantityString, formatProvider, Power.From, out quantity);

            if (quantityType == typeof(PowerDensity))
                return parser.TryParse<PowerDensity, PowerDensityUnit>(quantityString, formatProvider, PowerDensity.From, out quantity);

            if (quantityType == typeof(PowerRatio))
                return parser.TryParse<PowerRatio, PowerRatioUnit>(quantityString, formatProvider, PowerRatio.From, out quantity);

            if (quantityType == typeof(Pressure))
                return parser.TryParse<Pressure, PressureUnit>(quantityString, formatProvider, Pressure.From, out quantity);

            if (quantityType == typeof(PressureChangeRate))
                return parser.TryParse<PressureChangeRate, PressureChangeRateUnit>(quantityString, formatProvider, PressureChangeRate.From, out quantity);

            if (quantityType == typeof(Ratio))
                return parser.TryParse<Ratio, RatioUnit>(quantityString, formatProvider, Ratio.From, out quantity);

            if (quantityType == typeof(ReactiveEnergy))
                return parser.TryParse<ReactiveEnergy, ReactiveEnergyUnit>(quantityString, formatProvider, ReactiveEnergy.From, out quantity);

            if (quantityType == typeof(ReactivePower))
                return parser.TryParse<ReactivePower, ReactivePowerUnit>(quantityString, formatProvider, ReactivePower.From, out quantity);

            if (quantityType == typeof(RotationalAcceleration))
                return parser.TryParse<RotationalAcceleration, RotationalAccelerationUnit>(quantityString, formatProvider, RotationalAcceleration.From, out quantity);

            if (quantityType == typeof(RotationalSpeed))
                return parser.TryParse<RotationalSpeed, RotationalSpeedUnit>(quantityString, formatProvider, RotationalSpeed.From, out quantity);

            if (quantityType == typeof(RotationalStiffness))
                return parser.TryParse<RotationalStiffness, RotationalStiffnessUnit>(quantityString, formatProvider, RotationalStiffness.From, out quantity);

            if (quantityType == typeof(RotationalStiffnessPerLength))
                return parser.TryParse<RotationalStiffnessPerLength, RotationalStiffnessPerLengthUnit>(quantityString, formatProvider, RotationalStiffnessPerLength.From, out quantity);

            if (quantityType == typeof(SolidAngle))
                return parser.TryParse<SolidAngle, SolidAngleUnit>(quantityString, formatProvider, SolidAngle.From, out quantity);

            if (quantityType == typeof(SpecificEnergy))
                return parser.TryParse<SpecificEnergy, SpecificEnergyUnit>(quantityString, formatProvider, SpecificEnergy.From, out quantity);

            if (quantityType == typeof(SpecificEntropy))
                return parser.TryParse<SpecificEntropy, SpecificEntropyUnit>(quantityString, formatProvider, SpecificEntropy.From, out quantity);

            if (quantityType == typeof(SpecificVolume))
                return parser.TryParse<SpecificVolume, SpecificVolumeUnit>(quantityString, formatProvider, SpecificVolume.From, out quantity);

            if (quantityType == typeof(SpecificWeight))
                return parser.TryParse<SpecificWeight, SpecificWeightUnit>(quantityString, formatProvider, SpecificWeight.From, out quantity);

            if (quantityType == typeof(Speed))
                return parser.TryParse<Speed, SpeedUnit>(quantityString, formatProvider, Speed.From, out quantity);

            if (quantityType == typeof(Temperature))
                return parser.TryParse<Temperature, TemperatureUnit>(quantityString, formatProvider, Temperature.From, out quantity);

            if (quantityType == typeof(TemperatureChangeRate))
                return parser.TryParse<TemperatureChangeRate, TemperatureChangeRateUnit>(quantityString, formatProvider, TemperatureChangeRate.From, out quantity);

            if (quantityType == typeof(TemperatureDelta))
                return parser.TryParse<TemperatureDelta, TemperatureDeltaUnit>(quantityString, formatProvider, TemperatureDelta.From, out quantity);

            if (quantityType == typeof(ThermalConductivity))
                return parser.TryParse<ThermalConductivity, ThermalConductivityUnit>(quantityString, formatProvider, ThermalConductivity.From, out quantity);

            if (quantityType == typeof(ThermalResistance))
                return parser.TryParse<ThermalResistance, ThermalResistanceUnit>(quantityString, formatProvider, ThermalResistance.From, out quantity);

            if (quantityType == typeof(Torque))
                return parser.TryParse<Torque, TorqueUnit>(quantityString, formatProvider, Torque.From, out quantity);

            if (quantityType == typeof(VitaminA))
                return parser.TryParse<VitaminA, VitaminAUnit>(quantityString, formatProvider, VitaminA.From, out quantity);

            if (quantityType == typeof(Volume))
                return parser.TryParse<Volume, VolumeUnit>(quantityString, formatProvider, Volume.From, out quantity);

            if (quantityType == typeof(VolumeFlow))
                return parser.TryParse<VolumeFlow, VolumeFlowUnit>(quantityString, formatProvider, VolumeFlow.From, out quantity);

            if (quantityType == typeof(VolumePerLength))
                return parser.TryParse<VolumePerLength, VolumePerLengthUnit>(quantityString, formatProvider, VolumePerLength.From, out quantity);

            throw new ArgumentException(
                $"Type {quantityType} is not a known quantity type. Did you pass in a third-party quantity type defined outside UnitsNet library?");
        }
    }
}
