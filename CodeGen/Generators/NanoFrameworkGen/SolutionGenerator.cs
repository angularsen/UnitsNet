using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.NanoFrameworkGen
{
    class SolutionGenerator:GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly string _outputDir;
        private readonly string _globalGuid;

        public SolutionGenerator(Quantity[] quantities, string outputDir)
        {
            _quantities = quantities;
            _outputDir = outputDir;
            _globalGuid = Guid.NewGuid().ToString();
        }

        public override string Generate()
        {
            StringBuilder sb = new StringBuilder();
            Writer.WL($@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.30413.136
MinimumVisualStudioVersion = 10.0.40219.1");

            var outputDir = Path.Combine(_outputDir, "UnitsNet.NanoFramework", "GeneratedCode");

            foreach (var quantity in _quantities)
            {
                // Skip decimal based units, they are not supported by nanoFramework
                if (quantity.BaseType == "decimal")
                {
                    continue;
                }

                // need to grab the project GUID from the project file
                using var projectFileReader = new StreamReader(Path.Combine(outputDir, quantity.Name));
                string projectFileContent = projectFileReader.ReadToEnd();

                var pattern = @"(?<=<ProjectGuid>)(.*)(?=<)";
                var projectGuid = Regex.Matches(projectFileContent, pattern, RegexOptions.IgnoreCase);

                var guid = Guid.NewGuid();
                Writer.WL($@"
Project(""{{{_globalGuid}}}"") = ""{quantity.Name}"", ""{quantity.Name}\{quantity.Name}.nfproj"", ""{{{projectGuid}}}""
EndProject");
                sb.Append($"{{{guid.ToString()}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
                sb.Append($"{{{guid.ToString()}}}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
                sb.Append($"{{{guid.ToString()}}}.Debug|Any CPU.Deploy.0 = Debug|Any CPU\r\n");
                sb.Append($"{{{guid.ToString()}}}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
                sb.Append($"{{{guid.ToString()}}}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
                sb.Append($"{{{guid.ToString()}}}.Release|Any CPU.Deploy.0 = Release|Any CPU\r\n");
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
		SolutionGuid = {{{Guid.NewGuid().ToString()}}}
	EndGlobalSection
EndGlobal
");
            return Writer.ToString();
        }
    }
}
