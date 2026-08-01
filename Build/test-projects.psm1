function Get-TestProjectPaths {
  return @(
    "UnitsNet.Tests/UnitsNet.Tests.csproj",
    "UnitsNet.GlobalSetup.DefaultFirst.Tests/UnitsNet.GlobalSetup.DefaultFirst.Tests.csproj",
    "UnitsNet.GlobalSetup.Tests/UnitsNet.GlobalSetup.Tests.csproj",
    "UnitsNet.NumberExtensions.Tests/UnitsNet.NumberExtensions.Tests.csproj",
    "UnitsNet.NumberExtensions.CS14.Tests/UnitsNet.NumberExtensions.CS14.Tests.csproj",
    "UnitsNet.Serialization.JsonNet.Tests/UnitsNet.Serialization.JsonNet.Tests.csproj",
    "UnitsNet.Serialization.SystemTextJson.Tests/UnitsNet.Serialization.SystemTextJson.Tests.csproj"
  )
}

Export-ModuleMember -Function Get-TestProjectPaths
