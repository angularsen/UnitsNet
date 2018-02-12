## Test app: UWP WinJS and .NET 4.7.1

Illustrates using `UnitsNet.WindowsRuntimeComponent` from an UWP JavaScript app.
The Windows Runtime Component nuget can be consumed from C#, JavaScript and C++ UWP apps.


![image](https://user-images.githubusercontent.com/787816/35769565-700e4582-090d-11e8-80f6-19a4f06dea9e.png)

### Remarks
For some reason, out of the box UWP WinJS projects come with `packages.config` and it simply does not work without manually changing to `SpecificVersion=False` for each reference.
As a workaround, I have instead replaced it with `project.json` file, which although is end-of-life works better. I suspect the whole WinJS platform is also nearing end-of-life really..

Read more here: https://github.com/NuGet/Home/issues/2406