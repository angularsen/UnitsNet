## Units.NET

Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations, Units.NET gives you all the common units of measurement and the conversions between them. It is light-weight and thoroughly tested.

### Build Targets

* .NET Standard 1.0
* .NET 3.5 Client
* [Windows Runtime Component](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/) for UWP apps (JavaScript, C++ or C#)

### Overview

* [50+ quantities with a total of 500+ units](UnitsNet/GeneratedCode/Enums) generated from [JSON](UnitsNet/UnitDefinitions/) by [Powershell scripts](UnitsNet/Scripts/GenerateUnits.ps1)
* [1000+ unit tests](https://ci.appveyor.com/project/angularsen/unitsnet) on conversions and localizations
* Quantities as immutable structs that implement `IEquatable`, `IComparable`
* [Static typing](#static-typing) to avoid ambiguous quantities or units
* [Operator overloads](#operator-overloads) for arithmetic on quantities
* [Extension methods](#extension-methods) for short-hand creation and conversions
* [Parse and ToString()](#culture) supports cultures and localization
* [Example: Creating a unit converter app](#example-app)
* [Precision and accuracy](#precision)
* [Serializable with JSON.NET](#serialization)
* Extensible with [custom units](https://github.com/angularsen/UnitsNet/wiki/Extending-with-Custom-Units)
* [Contribute](#contribute) if you are missing some units
* [Continuous integration](#ci) posts status reports to pull requests and commits
* [Who are using this?](#who-are-using)

### Installing

Run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/) for the complete relase history.

```
Install-Package UnitsNet
```
