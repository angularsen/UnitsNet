# Units.NET Code Generator

This tool will replace the PowerShell scripts for generating source code.
It is faster, easier to debug and more familiar to C# developers.

## Generating code

The generator runs after it builds, when the unit definitions or the generator changed, see `CodeGen.csproj`. UnitsNet
references it, so building the solution or any project with generated code runs it. Set `SkipUnitsNetCodeGen=true` to
build without it.

To run it on its own:
```cmd
cd /dev/UnitsNet/CodeGen
dotnet run
```

Alternatively, build the .exe and run it:
```cmd
cd /dev/UnitsNet/CodeGen
dotnet publish -c Release -r win10-x64
cd ../Artifacts/CodeGen/netcoreapp2.1/win10-x64/
CodeGen.exe
```

## Bonus: .NET CLI Parameter Suggestions

The new, experimental DragonFruit .NET Core console app model has a suggestion API to query parameters of .exe files in order to suggest or auto-complete like PowerShell does.
To get parameter suggestions, follow the [instructions](https://github.com/dotnet/command-line-api/wiki/Features-overview#suggestions).

PowerShell:
```powershell
cd /dev/UnitsNet/CodeGen
dotnet publish -c Release -r win10-x64 CodeGen
cd ../Artifacts/CodeGen/netcoreapp2.1/win10-x64/
CodeGen.exe --ver
```

Hit TAB and it should now suggest `--version` and `--verbose` parameters.
This should work with any .exe that is compiled with Dragonfruit's app model.
