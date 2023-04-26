## OasysUnits

![Downloads](https://img.shields.io/nuget/dt/oasysunits?style=flat-square&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAsTAAALEwEAmpwYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAB3SURBVHgB7ZRBDoAgDASr8SH8/1PwE6yHJogEd5UeNMyNpN2hhFTEmQUtzMqpUUH6VnFmCqbASaBfPuaKRk1NhAXu6G1Ca4oOR21gHIyEDyckz8MByfvwjoQLty5Qcht+yUMEDGXe91fFVh5GPpNhEyQZT5JfsAN5UByV3bhHmAAAAABJRU5ErkJggg==) 

Official [Units.Net](https://github.com/angularsen/UnitsNet/blob/master/README.md) extended with additional Oasys units. 

| Latest | CI Pipeline | Dependencies |
| ------ | ----------- | ------------ |
| [![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/arup-group/oasysunits?include_prereleases&logo=github&style=flat-square)](https://github.com/arup-group/GSA-Grasshopper/releases) <br /> ![Nuget](https://img.shields.io/nuget/vpre/oasysunits?logo=nuget&style=flat-square) | ![Azure DevOps builds](https://img.shields.io/azure-devops/build/oasys-software/89fd051d-5c77-48bf-9b0e-05bca3e3e596/146?logo=azurepipelines&style=flat-square&label=Azure%20Pipelines) | ![Libraries.io dependency status for GitHub repo](https://img.shields.io/librariesio/github/arup-group/gsa-grasshopper?logo=nuget&style=flat-square) <br /> ![Dependents (via libraries.io)](https://img.shields.io/librariesio/dependents/nuget/oasysunits?logo=librariesdotio&logoColor=white) |

### How to get up to date with the main repository

* Check out the master branch from https://github.com/angularsen/UnitsNet/
* Batch replace all occurences of `UnitsNet` with `OasysUnits`
* Batch replace all occurences of `angularsen/OasysUnits` with `angularsen/UnitsNet`
* Rename all folders (in root folder) beginning with `UnitsNet.something` to `OasysUnits.something`
* Rename all .sln and .csproj files beginning with `UnitsNet.something` to `OasysUnits.something`
* Copy all files from `.\CustomOasys\` into the root folder
* Check differences in .csproj files and only commit the lines regarding `PackageId`, `Version`, `Authors`, `Title`, `Description`, `Copyright`, `RepositoryUrl`, `PackageIcon`, `PackageProjectUrl`, `PackageTags` and `PackageReleaseNotes`
* In a terminal change directory to `.\CodeGen\` and run `dotnet run -- --skip-nano-framework true` to regenerate the source code (running `.\generate-code.bat` could throw an error, but is actually generating all required files)
* Update assembly versions and package release notes in .csproj files

### How to add additional or modify units, tests, etc.

* Follow the steps described in the official [Units.Net wiki](https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit#quick-summary-of-steps)
* Copy all newly created custom files into `.\CustomOasys\`

## License
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?&style=flat-square&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAACXBIWXMAAAsTAAALEwEAmpwYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAADLSURBVHgB7ZPRDcIwDESvnYAROgIbkA1ghG7CKDACTNBs0m5QNgiO5I/IuLGLhJCgT7JUWXe5OHKBvyIxazytckhIC8gghQDHLYf0PoN1eFe7jZzE45NPdC6+T/Bj+yh5J8adc09oXiawfG0lOYt62FR9ZcBRMQfY+Hw8mmQWGu2Jqr6mNEOhIaRG6y35yieKiu4Gm+jy8S5feeRcF+cWmT43WoBFiw+zBXw/oNGavGY91YFqz+1OyB5UE9edKtK/NcEDBYxpPSN+kidmAJvClBsULQAAAABJRU5ErkJggg==)](/LICENSE)

## Acknowledgement
We would like to thank [Andreas Gullberg Larsen](https://github.com/angularsen/) and others for the great work of [UnitsNet](https://github.com/angularsen/UnitsNet/).
