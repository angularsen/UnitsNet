using System;
using System.Text;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class SolutionGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly Guid _globalGuid = new("71d2836c-ed62-4b76-ba38-e15badcca916"); // Randomly generated guids.
        private readonly Guid _solutionGuid = new("1f322b1f-1612-4e69-a31f-cb46bf87ec3e");

        public SolutionGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public string Generate()
        {
            StringBuilder sb = new();
            Writer.WL($@"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.29609.76
MinimumVisualStudioVersion = 10.0.40219.1");

            foreach (var quantity in _quantities)
            {
                var projectGuid = HashGuid.ToHashGuid(quantity.Name);
                var projectName = $"UnitsNet.{quantity.Name}";
                Writer.WL($@"
Project(""{_globalGuid:B}"") = ""{projectName}"", ""{projectName}\{projectName}.csproj"", ""{projectGuid:B}""
EndProject");
                sb.Append($"{{{projectGuid}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
                sb.Append($"{{{projectGuid}}}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
                sb.Append($"{{{projectGuid}}}.Debug|Any CPU.Deploy.0 = Debug|Any CPU\r\n");
                sb.Append($"{{{projectGuid}}}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
                sb.Append($"{{{projectGuid}}}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
                sb.Append($"{{{projectGuid}}}.Release|Any CPU.Deploy.0 = Release|Any CPU\r\n");
            }

            Writer.WL(@"Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution");

            Writer.WL(sb.ToString());

            Writer.WL($@"	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {_solutionGuid:B}
	EndGlobalSection
EndGlobal
");
            return Writer.ToString();
        }
    }
}
