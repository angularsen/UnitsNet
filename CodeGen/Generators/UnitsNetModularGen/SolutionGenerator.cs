using System;
using System.Text;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetModularGen
{
    class SolutionGenerator:GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly string _globalGuid = new Guid("660e8a78-57a3-4365-b7b5-336a552181ce").ToString("B").ToUpperInvariant(); // Randomly generated guids.
        private readonly string _solutionGuid = new Guid("39648d62-4f58-4c39-9a1c-5a1d884dedab").ToString("B").ToUpperInvariant();

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
                var projectGuid = HashGuid.ToHashGuid(quantity.Name).ToString("B").ToUpperInvariant();
                Writer.WL($@"
Project(""{_globalGuid}"") = ""{quantity.Name}"", ""UnitsNet.Modular\GeneratedCode\{quantity.Name}\{quantity.Name}.csproj"", ""{projectGuid}""
EndProject");
                sb.Append($"{projectGuid}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
                sb.Append($"{projectGuid}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
                sb.Append($"{projectGuid}.Debug|Any CPU.Deploy.0 = Debug|Any CPU\r\n");
                sb.Append($"{projectGuid}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
                sb.Append($"{projectGuid}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
                sb.Append($"{projectGuid}.Release|Any CPU.Deploy.0 = Release|Any CPU\r\n");
            }

            Writer.WL($@"
Project(""{_globalGuid}"") = ""UnitsNet.Core"", ""UnitsNet.Core\UnitsNet.Core.csproj"", ""{HashGuid.ToHashGuid("UnitsNet.Core").ToString("B").ToUpperInvariant()}""
EndProject");

            Writer.WL(@"Global
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
				GlobalSection(SolutionConfigurationPlatforms) = preSolution
								Debug|Any CPU = Debug|Any CPU
								Release|Any CPU = Release|Any CPU
	EndGlobalSection
				GlobalSection(ProjectConfigurationPlatforms) = postSolution");

            Writer.WL(sb.ToString());

            Writer.WL($@"
				EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {_solutionGuid}
	EndGlobalSection
EndGlobal
");
            return Writer.ToString();
        }
    }
}
