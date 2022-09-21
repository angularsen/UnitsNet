## OasysUnits

Official [Units.Net](https://github.com/angularsen/UnitsNet/blob/master/README.md) with additional Oasys units.

### How to get up to date with main repository

* Check out the master branch from https://github.com/angularsen/UnitsNet/
* Batch replace all occurences of `UnitsNet` with `OasysUnits`
* Batch replace all occurences of `angularsen/OasysUnits` with `angularsen/UnitsNet`
* Rename all folders (in root folder) beginning with `UnitsNet.something` to `OasysUnits.something`
* Rename all .sln and .csproj files beginning with `UnitsNet.something` to `OasysUnits.something`
* Cherry pick latest commit from `diff` branch 
* In a terminal change directory to `.\CodeGen\` and run `dotnet run -- --skip-nano-framwork true` to regenerate the source code
* Update assembly versions and package release notes in .csproj files
