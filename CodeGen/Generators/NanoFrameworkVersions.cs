// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace CodeGen.Generators
{
    /// <summary>
    /// NanoFramework dependency versions.
    /// </summary>
    /// <param name="MscorlibVersion">mscorlib assembly version in nanoFramework.CoreLibrary nuget.</param>
    /// <param name="MscorlibNugetVersion">Nuget version of nanoFramework.CoreLibrary.</param>
    /// <param name="MathVersion">System.Math assembly version in nanoFramework.System.Math nuget.</param>
    /// <param name="MathNugetVersion">Nuget version of nanoFramework.System.Math.</param>
    public record NanoFrameworkVersions(string MscorlibVersion, string MscorlibNugetVersion, string MathVersion, string MathNugetVersion);
}
