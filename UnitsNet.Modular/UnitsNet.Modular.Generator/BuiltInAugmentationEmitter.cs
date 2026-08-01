// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Text;

namespace UnitsNet.Modular.Generator;

internal static class BuiltInAugmentationEmitter
{
    public static void Emit(
        StringBuilder writer,
        QuantitySelection selection,
        string unitType,
        IReadOnlyDictionary<string, QuantitySelection> selectionsBySemanticId)
    {
        QuantityDefinition quantity = selection.Definition;
        foreach (QuantityAugmentationDefinition augmentation in quantity.Augmentations)
        {
            if (augmentation.RequiredQuantities.Any(required => !selectionsBySemanticId.ContainsKey(required)))
            {
                continue;
            }

            if (augmentation.RequiredUnits.Any(required =>
                    !selection.Units.Any(unit => string.Equals(unit.SingularName, required, StringComparison.Ordinal))))
            {
                continue;
            }

            switch (augmentation.Kind)
            {
                case QuantityAugmentationKind.DurationTimeSpan:
                    EmitDurationTimeSpan(writer, quantity, unitType);
                    break;
                case QuantityAugmentationKind.AreaCircle:
                    EmitAreaCircle(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.MassFractionMass:
                    EmitMassFractionMass(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.ForcePressureArea:
                    EmitForcePressureArea(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.ForceMassAcceleration:
                    EmitForceMassAcceleration(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.MassGravitationalForce:
                    EmitMassGravitationalForce(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.AmountOfSubstanceParticles:
                    EmitAmountOfSubstanceParticles(writer);
                    break;
                case QuantityAugmentationKind.AmountOfSubstanceMass:
                    EmitAmountOfSubstanceMass(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.MassConcentrationMolarity:
                    EmitMassConcentrationMolarity(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.MassConcentrationVolumeConcentration:
                    EmitMassConcentrationVolumeConcentration(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.MolarityMassConcentration:
                    EmitMolarityMassConcentration(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.MolarityVolumeConcentration:
                    EmitMolarityVolumeConcentration(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[2]]);
                    break;
                case QuantityAugmentationKind.VolumeConcentrationMassConcentration:
                    EmitVolumeConcentrationMassConcentration(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.VolumeConcentrationMolarity:
                    EmitVolumeConcentrationMolarity(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[2]]);
                    break;
                case QuantityAugmentationKind.VolumeConcentrationVolumes:
                    EmitVolumeConcentrationVolumes(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.ElectricApparentPowerDivision:
                    EmitElectricApparentPowerDivision(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.EnergyDensityCombustionEnergy:
                    EmitEnergyDensityCombustionEnergy(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[2]]);
                    break;
                case QuantityAugmentationKind.AmplitudeRatioElectricPotential:
                    EmitAmplitudeRatioElectricPotential(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.AmplitudeRatioPowerRatio:
                    EmitAmplitudeRatioPowerRatio(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.ElectricPotentialAmplitudeRatio:
                    EmitElectricPotentialAmplitudeRatio(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.LevelRatio:
                    EmitLevelRatio(writer, quantity);
                    break;
                case QuantityAugmentationKind.PowerPowerRatio:
                    EmitPowerPowerRatio(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.PowerRatioPower:
                    EmitPowerRatioPower(
                        writer,
                        quantity,
                        selectionsBySemanticId[augmentation.RequiredQuantities.Single()]);
                    break;
                case QuantityAugmentationKind.PowerRatioAmplitudeRatio:
                    EmitPowerRatioAmplitudeRatio(
                        writer,
                        selectionsBySemanticId[augmentation.RequiredQuantities[0]],
                        selectionsBySemanticId[augmentation.RequiredQuantities[1]]);
                    break;
                case QuantityAugmentationKind.LengthFeetInches:
                    EmitLengthFeetInches(writer, quantity);
                    break;
                case QuantityAugmentationKind.MassStonePounds:
                    EmitMassStonePounds(writer, quantity);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported quantity augmentation '{augmentation.Kind}'.");
            }
        }
    }

    private static void EmitDurationTimeSpan(
        StringBuilder writer,
        QuantityDefinition quantity,
        string unitType)
    {
        string quantityType = quantity.Name;
        writer.AppendLine();
        writer.AppendLine("    public global::System.TimeSpan ToTimeSpan()");
        writer.AppendLine("    {");
        writer.Append("        double seconds = As(").Append(unitType).AppendLine(".Second);");
        writer.AppendLine("        if (seconds > global::System.TimeSpan.MaxValue.TotalSeconds)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(seconds), \"The duration is too large for a TimeSpan.\");");
        writer.AppendLine("        if (seconds < global::System.TimeSpan.MinValue.TotalSeconds)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(seconds), \"The duration is too small for a TimeSpan.\");");
        writer.AppendLine("        return global::System.TimeSpan.FromTicks((long)(seconds * global::System.TimeSpan.TicksPerSecond));");
        writer.AppendLine("    }");
        writer.Append("    public static global::System.DateTime operator +(global::System.DateTime time, ")
            .Append(quantityType).AppendLine(" duration) => time.AddSeconds(duration.As(" + unitType + ".Second));");
        writer.Append("    public static global::System.DateTime operator -(global::System.DateTime time, ")
            .Append(quantityType).AppendLine(" duration) => time.AddSeconds(-duration.As(" + unitType + ".Second));");
        writer.Append("    public static implicit operator global::System.TimeSpan(").Append(quantityType)
            .AppendLine(" duration) => duration.ToTimeSpan();");
        writer.Append("    public static implicit operator ").Append(quantityType)
            .AppendLine("(global::System.TimeSpan duration) => FromSeconds(duration.TotalSeconds);");
        foreach (string comparison in new[] { "<", ">", "<=", ">=" })
        {
            writer.Append("    public static bool operator ").Append(comparison).Append('(').Append(quantityType)
                .Append(" duration, global::System.TimeSpan timeSpan) => duration.As(").Append(unitType)
                .Append(".Second) ").Append(comparison).AppendLine(" timeSpan.TotalSeconds;");
            writer.Append("    public static bool operator ").Append(comparison)
                .Append("(global::System.TimeSpan timeSpan, ").Append(quantityType)
                .Append(" duration) => timeSpan.TotalSeconds ").Append(comparison)
                .Append(" duration.As(").Append(unitType).AppendLine(".Second);");
        }
    }

    private static void EmitAreaCircle(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection length)
    {
        string lengthType = QuantityType(length.Definition);
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromCircleDiameter(")
            .Append(lengthType).AppendLine(" diameter) =>");
        writer.Append("        FromCircleRadius(").Append(lengthType)
            .AppendLine(".FromMeters(diameter.Meters / 2d));");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromCircleRadius(")
            .Append(lengthType).AppendLine(" radius) =>");
        writer.AppendLine("        FromSquareMeters(global::System.Math.PI * radius.Meters * radius.Meters);");
    }

    private static void EmitMassFractionMass(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection mass)
    {
        string massType = QuantityType(mass.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(massType).Append(" GetComponentMass(").Append(massType)
            .AppendLine(" totalMass) =>");
        writer.Append("        ").Append(massType)
            .AppendLine(".From(totalMass.Value * DecimalFractions, totalMass.Unit);");
        writer.Append("    public ").Append(massType).Append(" GetTotalMass(").Append(massType)
            .AppendLine(" componentMass) =>");
        writer.Append("        ").Append(massType)
            .AppendLine(".From(componentMass.Value / DecimalFractions, componentMass.Unit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromMasses(").Append(massType)
            .Append(" componentMass, ").Append(massType).AppendLine(" mixtureMass) =>");
        writer.AppendLine("        FromDecimalFractions(componentMass.Value / mixtureMass.As(componentMass.Unit));");
    }

    private static void EmitForcePressureArea(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection pressure,
        QuantitySelection area)
    {
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromPressureByArea(")
            .Append(QuantityType(pressure.Definition)).Append(" pressure, ")
            .Append(QuantityType(area.Definition)).AppendLine(" area) =>");
        writer.AppendLine("        FromNewtons(pressure.Pascals * area.SquareMeters);");
    }

    private static void EmitForceMassAcceleration(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection mass,
        QuantitySelection acceleration)
    {
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromMassByAcceleration(")
            .Append(QuantityType(mass.Definition)).Append(" mass, ")
            .Append(QuantityType(acceleration.Definition)).AppendLine(" acceleration) =>");
        writer.AppendLine("        FromNewtons(mass.Kilograms * acceleration.MetersPerSecondSquared);");
    }

    private static void EmitMassGravitationalForce(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection force)
    {
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromGravitationalForce(")
            .Append(QuantityType(force.Definition)).AppendLine(" force) =>");
        writer.AppendLine("        FromKilograms(force.Newtons / 9.80665);");
    }

    private static void EmitAmountOfSubstanceParticles(StringBuilder writer)
    {
        writer.AppendLine();
        writer.AppendLine("    public static double AvogadroConstant { get; } = 6.02214076e23;");
        writer.AppendLine("    public double NumberOfParticles() => AvogadroConstant * As(BaseUnit);");
    }

    private static void EmitAmountOfSubstanceMass(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection mass,
        QuantitySelection molarMass)
    {
        string massType = QuantityType(mass.Definition);
        string molarMassType = QuantityType(molarMass.Definition);
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromMass(")
            .Append(massType).Append(" mass, ").Append(molarMassType).AppendLine(" molarMass) =>");
        writer.Append("        From(mass.As(").Append(massType).Append(".BaseUnit) / molarMass.As(")
            .Append(molarMassType).AppendLine(".BaseUnit), BaseUnit);");
    }

    private static void EmitMassConcentrationMolarity(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection molarity,
        QuantitySelection molarMass)
    {
        string molarityType = QuantityType(molarity.Definition);
        string molarMassType = QuantityType(molarMass.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(molarityType).Append(" ToMolarity(").Append(molarMassType)
            .AppendLine(" molecularWeight) =>");
        writer.Append("        ").Append(molarityType).Append(".From(As(BaseUnit) / molecularWeight.As(")
            .Append(molarMassType).Append(".BaseUnit), ").Append(molarityType).AppendLine(".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromMolarity(")
            .Append(molarityType).Append(" molarity, ").Append(molarMassType).AppendLine(" mass) =>");
        writer.Append("        From(molarity.As(").Append(molarityType).Append(".BaseUnit) * mass.As(")
            .Append(molarMassType).AppendLine(".BaseUnit), BaseUnit);");
    }

    private static void EmitMassConcentrationVolumeConcentration(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection volumeConcentration,
        QuantitySelection density)
    {
        string volumeConcentrationType = QuantityType(volumeConcentration.Definition);
        string densityType = QuantityType(density.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(volumeConcentrationType).Append(" ToVolumeConcentration(")
            .Append(densityType).AppendLine(" componentDensity) =>");
        writer.Append("        ").Append(volumeConcentrationType)
            .Append(".From(As(BaseUnit) / componentDensity.As(").Append(densityType).Append(".BaseUnit), ")
            .Append(volumeConcentrationType).AppendLine(".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromVolumeConcentration(")
            .Append(volumeConcentrationType).Append(" volumeConcentration, ").Append(densityType)
            .AppendLine(" componentDensity) =>");
        writer.Append("        From(volumeConcentration.As(").Append(volumeConcentrationType)
            .Append(".BaseUnit) * componentDensity.As(").Append(densityType).AppendLine(".BaseUnit), BaseUnit);");
    }

    private static void EmitMolarityMassConcentration(
        StringBuilder writer,
        QuantitySelection massConcentration,
        QuantitySelection molarMass)
    {
        string massConcentrationType = QuantityType(massConcentration.Definition);
        string molarMassType = QuantityType(molarMass.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(massConcentrationType).Append(" ToMassConcentration(")
            .Append(molarMassType).AppendLine(" molecularWeight) =>");
        writer.Append("        ").Append(massConcentrationType).Append(".From(As(BaseUnit) * molecularWeight.As(")
            .Append(molarMassType).Append(".BaseUnit), ").Append(massConcentrationType).AppendLine(".BaseUnit);");
    }

    private static void EmitMolarityVolumeConcentration(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection volumeConcentration,
        QuantitySelection density,
        QuantitySelection molarMass)
    {
        string volumeConcentrationType = QuantityType(volumeConcentration.Definition);
        string densityType = QuantityType(density.Definition);
        string molarMassType = QuantityType(molarMass.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(volumeConcentrationType).Append(" ToVolumeConcentration(")
            .Append(densityType).Append(" componentDensity, ").Append(molarMassType)
            .AppendLine(" componentMass) =>");
        writer.Append("        ").Append(volumeConcentrationType).Append(".From(As(BaseUnit) * componentMass.As(")
            .Append(molarMassType).Append(".BaseUnit) / componentDensity.As(").Append(densityType)
            .Append(".BaseUnit), ").Append(volumeConcentrationType).AppendLine(".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromVolumeConcentration(")
            .Append(volumeConcentrationType).Append(" volumeConcentration, ").Append(densityType)
            .Append(" componentDensity, ").Append(molarMassType).AppendLine(" componentMass) =>");
        writer.Append("        From(volumeConcentration.As(").Append(volumeConcentrationType)
            .Append(".BaseUnit) * componentDensity.As(").Append(densityType)
            .Append(".BaseUnit) / componentMass.As(").Append(molarMassType).AppendLine(".BaseUnit), BaseUnit);");
    }

    private static void EmitVolumeConcentrationMassConcentration(
        StringBuilder writer,
        QuantitySelection massConcentration,
        QuantitySelection density)
    {
        string massConcentrationType = QuantityType(massConcentration.Definition);
        string densityType = QuantityType(density.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(massConcentrationType).Append(" ToMassConcentration(")
            .Append(densityType).AppendLine(" componentDensity) =>");
        writer.Append("        ").Append(massConcentrationType).Append(".From(As(BaseUnit) * componentDensity.As(")
            .Append(densityType).Append(".BaseUnit), ").Append(massConcentrationType).AppendLine(".BaseUnit);");
    }

    private static void EmitVolumeConcentrationMolarity(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection molarity,
        QuantitySelection density,
        QuantitySelection molarMass)
    {
        string molarityType = QuantityType(molarity.Definition);
        string densityType = QuantityType(density.Definition);
        string molarMassType = QuantityType(molarMass.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(molarityType).Append(" ToMolarity(").Append(densityType)
            .Append(" componentDensity, ").Append(molarMassType).AppendLine(" compontMolarMass) =>");
        writer.Append("        ").Append(molarityType).Append(".From(As(BaseUnit) * componentDensity.As(")
            .Append(densityType).Append(".BaseUnit) / compontMolarMass.As(").Append(molarMassType)
            .Append(".BaseUnit), ").Append(molarityType).AppendLine(".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromMolarity(")
            .Append(molarityType).Append(" molarity, ").Append(densityType).Append(" componentDensity, ")
            .Append(molarMassType).AppendLine(" componentMolarMass) =>");
        writer.Append("        From(molarity.As(").Append(molarityType).Append(".BaseUnit) * componentMolarMass.As(")
            .Append(molarMassType).Append(".BaseUnit) / componentDensity.As(").Append(densityType)
            .AppendLine(".BaseUnit), BaseUnit);");
    }

    private static void EmitVolumeConcentrationVolumes(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection volume)
    {
        string volumeType = QuantityType(volume.Definition);
        writer.AppendLine();
        writer.Append("    public static ").Append(quantity.Name).Append(" FromVolumes(").Append(volumeType)
            .Append(" componentVolume, ").Append(volumeType).AppendLine(" mixtureMass) =>");
        writer.AppendLine("        From(componentVolume.Value / mixtureMass.As(componentVolume.Unit), BaseUnit);");
    }

    private static void EmitElectricApparentPowerDivision(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection electricPotential,
        QuantitySelection electricCurrent)
    {
        string potentialType = QuantityType(electricPotential.Definition);
        string currentType = QuantityType(electricCurrent.Definition);
        writer.AppendLine();
        writer.Append("    public static ").Append(currentType).Append(" operator /(").Append(quantity.Name)
            .Append(" power, ").Append(potentialType).AppendLine(" potential) =>");
        writer.Append("        ").Append(currentType).Append(".From(power.As(BaseUnit) / potential.As(")
            .Append(potentialType).Append(".BaseUnit), ").Append(currentType).AppendLine(".BaseUnit);");
        writer.Append("    public static ").Append(potentialType).Append(" operator /(").Append(quantity.Name)
            .Append(" power, ").Append(currentType).AppendLine(" current) =>");
        writer.Append("        ").Append(potentialType).Append(".From(power.As(BaseUnit) / current.As(")
            .Append(currentType).Append(".BaseUnit), ").Append(potentialType).AppendLine(".BaseUnit);");
    }

    private static void EmitEnergyDensityCombustionEnergy(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection energy,
        QuantitySelection volume,
        QuantitySelection ratio)
    {
        string energyType = QuantityType(energy.Definition);
        string volumeType = QuantityType(volume.Definition);
        string ratioType = QuantityType(ratio.Definition);
        writer.AppendLine();
        writer.Append("    public static ").Append(energyType).Append(" CombustionEnergy(")
            .Append(quantity.Name).Append(" energyDensity, ").Append(volumeType).Append(" volume, ")
            .Append(ratioType).AppendLine(" conversionFactor) =>");
        writer.Append("        ").Append(energyType).Append(".From(energyDensity.As(BaseUnit) * volume.As(")
            .Append(volumeType).Append(".BaseUnit) * conversionFactor.As(").Append(ratioType)
            .Append(".BaseUnit), ").Append(energyType).AppendLine(".BaseUnit);");
    }

    private static void EmitAmplitudeRatioElectricPotential(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection electricPotential)
    {
        string electricPotentialType = QuantityType(electricPotential.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(quantity.Name).Append('(').Append(electricPotentialType)
            .AppendLine(" voltage)");
        writer.AppendLine("    {");
        writer.Append("        double volts = voltage.As(").Append(electricPotentialType).AppendLine(".BaseUnit);");
        writer.AppendLine("        if (volts <= 0)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(voltage), \"The base-10 logarithm of a number ≤ 0 is undefined. Voltage must be greater than 0 V.\");");
        writer.AppendLine("        _value = 20 * global::System.Math.Log10(volts);");
        writer.AppendLine("        _unit = BaseUnit;");
        writer.AppendLine("    }");
        writer.Append("    public ").Append(electricPotentialType).AppendLine(" ToElectricPotential() =>");
        writer.Append("        ").Append(electricPotentialType)
            .AppendLine(".From(global::System.Math.Pow(10, As(BaseUnit) / 20), " + electricPotentialType + ".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromElectricPotential(")
            .Append(electricPotentialType).AppendLine(" voltage) => new(voltage);");
    }

    private static void EmitAmplitudeRatioPowerRatio(
        StringBuilder writer,
        QuantitySelection powerRatio,
        QuantitySelection electricResistance)
    {
        string powerRatioType = QuantityType(powerRatio.Definition);
        string resistanceType = QuantityType(electricResistance.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(powerRatioType).Append(" ToPowerRatio(").Append(resistanceType)
            .AppendLine(" impedance) =>");
        writer.Append("        ").Append(powerRatioType).Append(".From(As(BaseUnit) - 10 * global::System.Math.Log10(impedance.As(")
            .Append(resistanceType).Append(".BaseUnit)), ").Append(powerRatioType).AppendLine(".BaseUnit);");
    }

    private static void EmitElectricPotentialAmplitudeRatio(
        StringBuilder writer,
        QuantitySelection amplitudeRatio)
    {
        string amplitudeRatioType = QuantityType(amplitudeRatio.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(amplitudeRatioType).AppendLine(" ToAmplitudeRatio() =>");
        writer.Append("        ").Append(amplitudeRatioType).AppendLine(".FromElectricPotential(this);");
    }

    private static void EmitLevelRatio(StringBuilder writer, QuantityDefinition quantity)
    {
        writer.AppendLine();
        writer.Append("    public ").Append(quantity.Name).AppendLine("(double quantity, double reference)");
        writer.AppendLine("    {");
        writer.AppendLine("        string errorMessage = $\"The base-10 logarithm of a number ≤ 0 is undefined ({quantity}/{reference}).\";");
        writer.AppendLine("        if (quantity == 0 || quantity < 0 && reference > 0)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(quantity), errorMessage);");
        writer.AppendLine("        if (reference == 0 || quantity > 0 && reference < 0)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(reference), errorMessage);");
        writer.AppendLine("        _value = 10 * global::System.Math.Log10(quantity / reference);");
        writer.AppendLine("        _unit = BaseUnit;");
        writer.AppendLine("    }");
    }

    private static void EmitPowerPowerRatio(
        StringBuilder writer,
        QuantitySelection powerRatio)
    {
        string powerRatioType = QuantityType(powerRatio.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(powerRatioType).AppendLine(" ToPowerRatio() =>");
        writer.Append("        ").Append(powerRatioType).AppendLine(".FromPower(this);");
    }

    private static void EmitPowerRatioPower(
        StringBuilder writer,
        QuantityDefinition quantity,
        QuantitySelection power)
    {
        string powerType = QuantityType(power.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(quantity.Name).Append('(').Append(powerType).AppendLine(" power)");
        writer.AppendLine("    {");
        writer.Append("        double watts = power.As(").Append(powerType).AppendLine(".BaseUnit);");
        writer.AppendLine("        if (watts <= 0)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(power), \"The base-10 logarithm of a number ≤ 0 is undefined. Power must be greater than 0 W.\");");
        writer.AppendLine("        _value = 10 * global::System.Math.Log10(watts);");
        writer.AppendLine("        _unit = BaseUnit;");
        writer.AppendLine("    }");
        writer.Append("    public ").Append(powerType).AppendLine(" ToPower() =>");
        writer.Append("        ").Append(powerType)
            .AppendLine(".From(global::System.Math.Pow(10, As(BaseUnit) / 10), " + powerType + ".BaseUnit);");
        writer.Append("    public static ").Append(quantity.Name).Append(" FromPower(").Append(powerType)
            .AppendLine(" power) => new(power);");
    }

    private static void EmitPowerRatioAmplitudeRatio(
        StringBuilder writer,
        QuantitySelection amplitudeRatio,
        QuantitySelection electricResistance)
    {
        string amplitudeRatioType = QuantityType(amplitudeRatio.Definition);
        string resistanceType = QuantityType(electricResistance.Definition);
        writer.AppendLine();
        writer.Append("    public ").Append(amplitudeRatioType).Append(" ToAmplitudeRatio(")
            .Append(resistanceType).AppendLine(" impedance) =>");
        writer.Append("        ").Append(amplitudeRatioType).Append(".From(10 * global::System.Math.Log10(impedance.As(")
            .Append(resistanceType).Append(".BaseUnit)) + As(BaseUnit), ")
            .Append(amplitudeRatioType).AppendLine(".BaseUnit);");
    }

    private static void EmitLengthFeetInches(StringBuilder writer, QuantityDefinition quantity)
    {
        string companionType = "global::" + quantity.TargetNamespace + ".FeetInches";
        string unitType = UnitType(quantity);
        writer.AppendLine();
        writer.Append("    public ").Append(companionType).AppendLine(" FeetInches");
        writer.AppendLine("    {");
        writer.AppendLine("        get");
        writer.AppendLine("        {");
        writer.Append("            double totalInches = As(").Append(unitType).AppendLine(".Inch);");
        writer.AppendLine("            double feet = global::System.Math.Truncate(totalInches / 12);");
        writer.AppendLine("            double inches = totalInches % 12;");
        writer.Append("            return new ").Append(companionType).AppendLine("(feet, inches);");
        writer.AppendLine("        }");
        writer.AppendLine("    }");
        writer.Append("    public static ").Append(quantity.Name)
            .AppendLine(" FromFeetInches(double feet, double inches) =>");
        writer.AppendLine("        From(feet * 0.3048 + inches * 0.0254, BaseUnit);");
    }

    private static void EmitMassStonePounds(StringBuilder writer, QuantityDefinition quantity)
    {
        string companionType = "global::" + quantity.TargetNamespace + ".StonePounds";
        string unitType = UnitType(quantity);
        writer.AppendLine();
        writer.Append("    public ").Append(companionType).AppendLine(" StonePounds");
        writer.AppendLine("    {");
        writer.AppendLine("        get");
        writer.AppendLine("        {");
        writer.Append("            double totalPounds = As(").Append(unitType).AppendLine(".Pound);");
        writer.AppendLine("            double stone = global::System.Math.Truncate(totalPounds / 14);");
        writer.AppendLine("            double pounds = totalPounds % 14;");
        writer.Append("            return new ").Append(companionType).AppendLine("(stone, pounds);");
        writer.AppendLine("        }");
        writer.AppendLine("    }");
        writer.Append("    public static ").Append(quantity.Name)
            .AppendLine(" FromStonePounds(double stone, double pounds) =>");
        writer.AppendLine("        From((stone * 14 + pounds) * 0.45359237, BaseUnit);");
    }

    private static string QuantityType(QuantityDefinition definition) =>
        "global::" + definition.TargetNamespace + "." + definition.Name;

    private static string UnitType(QuantityDefinition definition) =>
        definition.TargetNamespace == "UnitsNet"
            ? "global::UnitsNet.Units." + definition.Name + "Unit"
            : "global::" + definition.TargetNamespace + "." + definition.Name + "Unit";
}
