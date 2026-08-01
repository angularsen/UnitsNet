// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Text;

namespace UnitsNet.Modular.Generator;

internal static class BuiltInCompanionEmitter
{
    public static bool CanEmit(
        CompanionTypeDefinition companion,
        QuantitySelection owner,
        IReadOnlyDictionary<string, QuantitySelection> selectionsBySemanticId) =>
        companion.RequiredQuantities.All(selectionsBySemanticId.ContainsKey) &&
        companion.RequiredUnits.All(required =>
            owner.Units.Any(unit => string.Equals(unit.SingularName, required, StringComparison.Ordinal)));

    public static string Emit(QuantitySelection owner, CompanionTypeDefinition companion) =>
        companion.Kind switch
        {
            CompanionTypeKind.FeetInches => EmitFeetInches(owner.Definition),
            CompanionTypeKind.StonePounds => EmitStonePounds(owner.Definition),
            CompanionTypeKind.ReferencePressure => EmitReferencePressure(owner.Definition),
            _ => throw new InvalidOperationException($"Unsupported companion type '{companion.Kind}'."),
        };

    private static string EmitFeetInches(QuantityDefinition length)
    {
        string quantityType = QuantityType(length);
        string unitType = UnitType(length);
        var writer = BeginNamespace(length.TargetNamespace);
        writer.AppendLine("public sealed class FeetInches");
        writer.AppendLine("{");
        writer.AppendLine("    public FeetInches(double feet, double inches)");
        writer.AppendLine("    {");
        writer.AppendLine("        Feet = feet;");
        writer.AppendLine("        Inches = inches;");
        writer.AppendLine("    }");
        writer.AppendLine();
        writer.AppendLine("    public double Feet { get; }");
        writer.AppendLine("    public double Inches { get; }");
        writer.AppendLine();
        writer.AppendLine("    public override string ToString() => ToString(null);");
        writer.AppendLine();
        writer.AppendLine("    public string ToString(global::System.IFormatProvider? cultureInfo)");
        writer.AppendLine("    {");
        writer.AppendLine("        cultureInfo ??= global::System.Globalization.CultureInfo.CurrentCulture;");
        writer.Append("        string footUnit = ").Append(quantityType).Append(".GetAbbreviation(")
            .Append(unitType).AppendLine(".Foot, cultureInfo);");
        writer.Append("        string inchUnit = ").Append(quantityType).Append(".GetAbbreviation(")
            .Append(unitType).AppendLine(".Inch, cultureInfo);");
        writer.AppendLine("        return global::System.String.Format(");
        writer.AppendLine("            cultureInfo,");
        writer.AppendLine("            \"{0:n0} {1} {2:n0} {3}\",");
        writer.AppendLine("            Feet,");
        writer.AppendLine("            footUnit,");
        writer.AppendLine("            global::System.Math.Round(Inches),");
        writer.AppendLine("            inchUnit);");
        writer.AppendLine("    }");
        writer.AppendLine();
        writer.AppendLine("    public string ToArchitecturalString(int fractionDenominator)");
        writer.AppendLine("    {");
        writer.AppendLine("        if (fractionDenominator < 1)");
        writer.AppendLine("            throw new global::System.ArgumentOutOfRangeException(nameof(fractionDenominator), \"Denominator for fractional inch must be greater than zero.\");");
        writer.AppendLine();
        writer.AppendLine("        int inchTrunc = (int)global::System.Math.Truncate(Inches);");
        writer.AppendLine("        int numerator = (int)global::System.Math.Round((Inches - inchTrunc) * fractionDenominator);");
        writer.AppendLine("        if (numerator == fractionDenominator)");
        writer.AppendLine("        {");
        writer.AppendLine("            inchTrunc++;");
        writer.AppendLine("            numerator = 0;");
        writer.AppendLine("        }");
        writer.AppendLine();
        writer.AppendLine("        var inchPart = new global::System.Text.StringBuilder();");
        writer.AppendLine("        if (inchTrunc != 0 || numerator == 0)");
        writer.AppendLine("            inchPart.Append(inchTrunc);");
        writer.AppendLine("        if (numerator > 0)");
        writer.AppendLine("        {");
        writer.AppendLine("            int GreatestCommonDivisor(int a, int b)");
        writer.AppendLine("            {");
        writer.AppendLine("                while (a != 0 && b != 0)");
        writer.AppendLine("                {");
        writer.AppendLine("                    if (a > b) a %= b;");
        writer.AppendLine("                    else b %= a;");
        writer.AppendLine("                }");
        writer.AppendLine("                return a | b;");
        writer.AppendLine("            }");
        writer.AppendLine();
        writer.AppendLine("            int divisor = GreatestCommonDivisor(numerator, fractionDenominator);");
        writer.AppendLine("            if (inchPart.Length > 0) inchPart.Append(' ');");
        writer.AppendLine("            inchPart.Append($\"{numerator / divisor}/{fractionDenominator / divisor}\");");
        writer.AppendLine("        }");
        writer.AppendLine();
        writer.AppendLine("        inchPart.Append('\"');");
        writer.AppendLine("        return Feet == 0 ? inchPart.ToString() : $\"{Feet}' - {inchPart}\";");
        writer.AppendLine("    }");
        writer.AppendLine("}");
        EndNamespace(writer);
        return writer.ToString();
    }

    private static string EmitStonePounds(QuantityDefinition mass)
    {
        string quantityType = QuantityType(mass);
        string unitType = UnitType(mass);
        var writer = BeginNamespace(mass.TargetNamespace);
        writer.AppendLine("public sealed class StonePounds");
        writer.AppendLine("{");
        writer.AppendLine("    public StonePounds(double stone, double pounds)");
        writer.AppendLine("    {");
        writer.AppendLine("        Stone = stone;");
        writer.AppendLine("        Pounds = pounds;");
        writer.AppendLine("    }");
        writer.AppendLine();
        writer.AppendLine("    public double Stone { get; }");
        writer.AppendLine("    public double Pounds { get; }");
        writer.AppendLine();
        writer.AppendLine("    public override string ToString() => ToString(null);");
        writer.AppendLine();
        writer.AppendLine("    public string ToString(global::System.IFormatProvider? cultureInfo)");
        writer.AppendLine("    {");
        writer.AppendLine("        cultureInfo ??= global::System.Globalization.CultureInfo.CurrentCulture;");
        writer.Append("        string stoneUnit = ").Append(quantityType).Append(".GetAbbreviation(")
            .Append(unitType).AppendLine(".Stone, cultureInfo);");
        writer.Append("        string poundUnit = ").Append(quantityType).Append(".GetAbbreviation(")
            .Append(unitType).AppendLine(".Pound, cultureInfo);");
        writer.AppendLine("        return global::System.String.Format(");
        writer.AppendLine("            cultureInfo,");
        writer.AppendLine("            \"{0:n0} {1} {2:n0} {3}\",");
        writer.AppendLine("            Stone,");
        writer.AppendLine("            stoneUnit,");
        writer.AppendLine("            global::System.Math.Round(Pounds),");
        writer.AppendLine("            poundUnit);");
        writer.AppendLine("    }");
        writer.AppendLine("}");
        EndNamespace(writer);
        return writer.ToString();
    }

    private static string EmitReferencePressure(QuantityDefinition pressure)
    {
        bool compatibilityMode = pressure.TargetNamespace == "UnitsNet";
        string pressureType = QuantityType(pressure);
        string enumNamespace = compatibilityMode
            ? "UnitsNet.CustomCode.Units"
            : pressure.TargetNamespace + ".Wrappers";
        string wrapperNamespace = compatibilityMode
            ? "UnitsNet.Wrappers"
            : pressure.TargetNamespace + ".Wrappers";
        string referenceType = "global::" + enumNamespace + ".PressureReference";
        var writer = new StringBuilder();
        writer.AppendLine("// <auto-generated />");
        writer.AppendLine("#nullable enable");
        writer.AppendLine();
        writer.Append("namespace ").Append(enumNamespace).AppendLine();
        writer.AppendLine("{");
        writer.AppendLine("    public enum PressureReference");
        writer.AppendLine("    {");
        writer.AppendLine("        Absolute,");
        writer.AppendLine("        Gauge,");
        writer.AppendLine("        Vacuum,");
        writer.AppendLine("    }");
        writer.AppendLine("}");
        writer.AppendLine();
        writer.Append("namespace ").Append(wrapperNamespace).AppendLine();
        writer.AppendLine("{");
        writer.AppendLine("    public struct ReferencePressure");
        writer.AppendLine("    {");
        writer.Append("        private static readonly ").Append(pressureType)
            .Append(" DefaultAtmosphericPressure = ").Append(pressureType)
            .Append(".From(101325, ").Append(pressureType).AppendLine(".BaseUnit);");
        writer.AppendLine();
        writer.Append("        public static ").Append(referenceType).AppendLine("[] References { get; } = new[]");
        writer.AppendLine("        {");
        writer.Append("            ").Append(referenceType).AppendLine(".Absolute,");
        writer.Append("            ").Append(referenceType).AppendLine(".Gauge,");
        writer.Append("            ").Append(referenceType).AppendLine(".Vacuum,");
        writer.AppendLine("        };");
        writer.AppendLine();
        writer.Append("        public const ").Append(referenceType).Append(" BaseReference = ")
            .Append(referenceType).AppendLine(".Absolute;");
        writer.AppendLine();
        writer.Append("        public ReferencePressure(").Append(pressureType)
            .AppendLine(" pressure) : this(pressure, BaseReference) { }");
        writer.Append("        public ReferencePressure(").Append(pressureType).Append(" pressure, ")
            .Append(referenceType).AppendLine(" reference) :");
        writer.AppendLine("            this(pressure, reference, DefaultAtmosphericPressure) { }");
        writer.Append("        public ReferencePressure(").Append(pressureType).Append(" pressure, ")
            .Append(referenceType).Append(" reference, ").Append(pressureType).AppendLine(" atmosphericPressure)");
        writer.AppendLine("        {");
        writer.AppendLine("            Reference = reference;");
        writer.AppendLine("            Pressure = pressure;");
        writer.AppendLine("            AtmosphericPressure = atmosphericPressure;");
        writer.AppendLine("        }");
        writer.AppendLine();
        writer.Append("        public ").Append(pressureType).AppendLine(" AtmosphericPressure { get; set; }");
        writer.Append("        public ").Append(referenceType).AppendLine(" Reference { get; }");
        writer.Append("        public ").Append(pressureType).AppendLine(" Pressure { get; }");
        writer.Append("        public ").Append(pressureType).Append(" Gauge => As(").Append(referenceType)
            .AppendLine(".Gauge);");
        writer.Append("        public ").Append(pressureType).Append(" Absolute => As(").Append(referenceType)
            .AppendLine(".Absolute);");
        writer.Append("        public ").Append(pressureType).Append(" Vacuum => As(").Append(referenceType)
            .AppendLine(".Vacuum);");
        writer.AppendLine();
        writer.Append("        private ").Append(pressureType).Append(" As(").Append(referenceType)
            .AppendLine(" reference) =>");
        writer.AppendLine("            " + pressureType + ".From(AsNumeric(reference), Pressure.Unit);");
        writer.AppendLine();
        writer.Append("        private double AsNumeric(").Append(referenceType).AppendLine(" reference)");
        writer.AppendLine("        {");
        writer.AppendLine("            double absoluteValue = AsAbsolute();");
        writer.AppendLine("            if (Reference == reference) return Pressure.Value;");
        writer.Append("            double atmosphericValue = AtmosphericPressure.As(Pressure.Unit);").AppendLine();
        writer.Append("            int sign = Reference == ").Append(referenceType).AppendLine(".Vacuum ? -1 : 1;");
        writer.AppendLine("            return reference switch");
        writer.AppendLine("            {");
        writer.Append("                ").Append(referenceType).AppendLine(".Absolute => absoluteValue,");
        writer.Append("                ").Append(referenceType).AppendLine(".Gauge => absoluteValue - atmosphericValue,");
        writer.Append("                ").Append(referenceType).AppendLine(".Vacuum => atmosphericValue - sign * absoluteValue,");
        writer.AppendLine("                _ => throw new global::System.NotImplementedException($\"Can't convert {Reference} to {reference}.\"),");
        writer.AppendLine("            };");
        writer.AppendLine("        }");
        writer.AppendLine();
        writer.AppendLine("        private double AsAbsolute()");
        writer.AppendLine("        {");
        writer.AppendLine("            double atmosphericValue = AtmosphericPressure.As(Pressure.Unit);");
        writer.AppendLine("            return Reference switch");
        writer.AppendLine("            {");
        writer.Append("                ").Append(referenceType)
            .AppendLine(".Absolute when Pressure.Value >= 0 => Pressure.Value,");
        writer.Append("                ").Append(referenceType)
            .AppendLine(".Gauge when -Pressure.Value <= atmosphericValue => atmosphericValue + Pressure.Value,");
        writer.Append("                ").Append(referenceType)
            .AppendLine(".Vacuum when Pressure.Value <= atmosphericValue => atmosphericValue - Pressure.Value,");
        writer.Append("                ").Append(referenceType).Append(".Absolute or ").Append(referenceType)
            .Append(".Gauge or ").Append(referenceType).AppendLine(".Vacuum =>");
        writer.AppendLine("                    throw new global::System.ArgumentOutOfRangeException(nameof(Pressure), \"Absolute pressure cannot be less than zero.\"),");
        writer.AppendLine("                _ => throw new global::System.NotImplementedException($\"Can't convert {Reference} to base reference.\"),");
        writer.AppendLine("            };");
        writer.AppendLine("        }");
        writer.AppendLine("    }");
        writer.AppendLine("}");
        return writer.ToString();
    }

    private static StringBuilder BeginNamespace(string targetNamespace)
    {
        var writer = new StringBuilder();
        writer.AppendLine("// <auto-generated />");
        writer.AppendLine("#nullable enable");
        writer.AppendLine();
        writer.Append("namespace ").Append(targetNamespace).AppendLine();
        writer.AppendLine("{");
        return writer;
    }

    private static void EndNamespace(StringBuilder writer) => writer.AppendLine("}");

    private static string QuantityType(QuantityDefinition definition) =>
        "global::" + definition.TargetNamespace + "." + definition.Name;

    private static string UnitType(QuantityDefinition definition) =>
        definition.TargetNamespace == "UnitsNet"
            ? "global::UnitsNet.Units." + definition.Name + "Unit"
            : "global::" + definition.TargetNamespace + "." + definition.Name + "Unit";
}
