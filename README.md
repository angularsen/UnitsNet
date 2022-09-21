## OasysUnits

Units.Net implementation with additional Oasys units.

[Official Units.Net Readme](https://github.com/angularsen/UnitsNet/blob/master/README.md)

### How to get up to date with main repository (https://github.com/angularsen/UnitsNet/)

* Check out the incoming branch
* Batch replace all occurences of 'UnitsNet' with 'OasysUnits'
* Batch replace all occurences of 'angularsen/OasysUnits' with 'angularsen/UnitsNet'
* Rename all folders (in root folder) beginning with 'UnitsNet.something' to 'OasysUnits.something'
* Rename all .sln and .csproj files beginning with 'UnitsNet.something' to 'OasysUnits.something'
* Cherry pick latest commit from 'diff' branch 
* In a terminal change directory to '.\CodeGen\' and run 'dotnet run -- --skip-nano-framwork true' to regenerate the source code
* Update assembly versions and package release notes in .csproj files
