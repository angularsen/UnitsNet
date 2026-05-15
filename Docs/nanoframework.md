# .NET nanoFramework

.NET nanoFramework is a free and open-source platform that enables the writing of managed code applications for constrained embedded devices. It is suitable for many types of projects including IoT sensors, wearables, academic proof of concept, robotics, hobbyist/makers creations or even complex industrial equipment.

https://www.nanoframework.net/

## Update nanoFramework dependencies

Units.NET publishes quantities as individual nuget packages, which means there is a large number of projects to maintain.
To overcome this, the CodeGen project generates the solution file, project files and .nuspec files - in addition to source code.

The dependencies are hard coded in the code generator, so in order to update the dependencies you must specify an extra flag.

```sh
cd CodeGen
dotnet run --update-nano-framework-dependencies
```

As of this writing, `mscorlib` and `System.Math` are the two nuget dependencies to update.
