using System;
using System.Text;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.NanoFrameworkGen
{
    class SolutionGenerator:GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly Guid _globalGuid = new("d608a2b1-6ead-4383-a205-ad1ce69d9ef7"); // Randomly generated guids.
        private readonly Guid _solutionGuid = new("43971d92-3663-4f28-82ac-e63ce06ba1a3");

        public SolutionGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public string Generate()
        {
            StringBuilder sb = new();
            Writer.WL($@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.30413.136
MinimumVisualStudioVersion = 10.0.40219.1");

            foreach (var quantity in _quantities)
            {
                var projectGuid = HashGuid.ToHashGuid(quantity.Name);
                Writer.WL($@"
Project(""{_globalGuid:B}"") = ""{quantity.Name}"", ""{quantity.Name}\{quantity.Name}.nfproj"", ""{projectGuid:B}""
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
