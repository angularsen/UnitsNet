// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UnitsNet.Xp.SrcGen
{
    [Generator]
    public class QuantitySourceGenerator : ISourceGenerator
    {
        private const string SrcQuantitySource =
            """
            namespace UnitsNetSrcGen
            {
                public interface ISrcQuantity<TUnitEnum> where TUnitEnum : System.Enum
                {
                    double Value { get; }
                    TUnitEnum Unit { get; }
                }
            }
            """;

        private const string LengthSource = """
            namespace UnitsNetSrcGen
            {
                public enum LengthUnit
                {
                    Centimeter,
                    Meter,
                }

                public struct Length : ISrcQuantity<LengthUnit>
                {
                    public Length(double value, LengthUnit unit)
                    {
                        Value = value;
                        Unit = unit;
                    }

                    public required double Value { get; init; }
                    public required LengthUnit Unit { get; init; }
                        }
                    }
            """;

        private const string MassSource = """
            namespace UnitsNetSrcGen
            {
                public enum MassUnit
                {
                    Gram,
                    Kilogram,
                }

                public struct Mass : ISrcQuantity<MassUnit>
                {
                    public Mass(double value, MassUnit unit)
                    {
                        Value = value;
                        Unit = unit;
                    }

                    public required double Value { get; init; }
                    public required MassUnit Unit { get; init; }
                }
            }
            """;

        private const string AttributeSource =
            """
            [System.AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple = false)]
            internal sealed class UnitsNetSrcGenInitAttribute : System.Attribute
            {
                public string[] QuantityNames { get; }

                public UnitsNetSrcGenInitAttribute(string quantityNames)
                    => (QuantityNames) = (quantityNames.Split(',').Select(str => str.Trim()).ToArray());
            }
            """;

        public void Execute(GeneratorExecutionContext context)
        {
            SyntaxReceiver rx = (SyntaxReceiver)context.SyntaxContextReceiver!;
            foreach (string quantityName in rx.QuantityNames)
            {
                string source = quantityName switch
                {
                    "Length" => LengthSource,
                    "Mass" => MassSource,
                    _ => "",
                };

                if (source != "")
                {
                    context.AddSource($"UnitsNetSrc_{quantityName}.g.cs", source);
                }
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization((pi) =>
            {
                pi.AddSource("UnitsNetSrcGenInit.g.cs", AttributeSource);
                pi.AddSource("UnitsNetSrc_ISrcQuantity.g.cs", SrcQuantitySource);
            });
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        private class SyntaxReceiver : ISyntaxContextReceiver
        {
            public List<string> QuantityNames = new();

            public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
            {
                // find all valid mustache attributes
                if (context.Node is AttributeSyntax attrib
                    && context.SemanticModel.GetTypeInfo(attrib).Type?.ToDisplayString() == "UnitsNetSrcGenInitAttribute")
                {
                    // string[] quantityNames = (string[])context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[0].Expression).Value;
                    IList<string> quantityNames = ((string)context.SemanticModel.GetConstantValue(attrib.ArgumentList!.Arguments[0].Expression).Value).Split(',').Select(str => str.Trim()).ToList();

                    // string template = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[1].Expression).ToString();
                    // string hash = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[2].Expression).ToString();

                    QuantityNames.AddRange(quantityNames);
                }
            }
        }
    }
}
