## OasysUnits

![Downloads](https://img.shields.io/nuget/dt/oasysunits?style=flat-square) 

Official [Units.Net](https://github.com/angularsen/UnitsNet/blob/master/README.md) with additional Oasys units.

| Latest | CI Pipeline | Dependencies |
| ------ | ----------- | ------------ |
| [![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/arup-group/oasysunits?include_prereleases&logo=github&style=flat-square)](https://github.com/arup-group/GSA-Grasshopper/releases) <br /> ![Nuget](https://img.shields.io/nuget/vpre/oasysunits?logo=nuget&style=flat-square) | [![Build Status](https://dev.azure.com/oasys-software/OASYS%20libraries/_apis/build/status/arup-group.OasysUnits?branchName=main?style=flat-square)](https://dev.azure.com/oasys-software/OASYS%20libraries/_build/latest?definitionId=146&branchName=main) <br /> ![Azure DevOps builds](https://img.shields.io/azure-devops/build/oasys-software/89fd051d-5c77-48bf-9b0e-05bca3e3e596/146?logo=azurepipelines&style=flat-square) <br /> ![GitHub branch checks state](https://img.shields.io/github/checks-status/arup-group/oasysunits/main?logo=github&style=flat-square) | ![Libraries.io dependency status for GitHub repo](https://img.shields.io/librariesio/github/arup-group/gsa-grasshopper?logo=nuget&style=flat-square) |

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
