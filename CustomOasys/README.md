## OasysUnits

Official [Units.Net](https://github.com/angularsen/UnitsNet/blob/master/README.md) with additional Oasys units.

### How to get up to date with the main repository

* Check out the master branch from https://github.com/angularsen/UnitsNet/
* Batch replace all occurences of `UnitsNet` with `OasysUnits`
* Batch replace all occurences of `angularsen/OasysUnits` with `angularsen/UnitsNet`
* Rename all folders (in root folder) beginning with `UnitsNet.something` to `OasysUnits.something`
* Rename all .sln and .csproj files beginning with `UnitsNet.something` to `OasysUnits.something`
* Copy all files from `.\CustomOasys\` into the root folder
* Check differences in .csproj files and only commit the lines regarding `PackageId`, `Version`, `Authors`, `Title`, `Description`, `Copyright`, `RepositoryUrl`, `PackageIcon`, `PackageProjectUrl`, `PackageTags` and `PackageReleaseNotes`
* In a terminal change directory to `.\CodeGen\` and run `dotnet run -- --skip-nano-framwork true` to regenerate the source code (running `.\generate-code.bat` will throw an error, but is actually generating all required files)
* Update assembly versions and package release notes in .csproj files

### How to add additional or modify units, tests, etc.

* Follow the steps described in the official [Units.Net wiki](https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit#quick-summary-of-steps)
* Copy all newly created custom files into `.\CustomOasys\`
