# UnitsNet.Modular playground

This small console app runs the real UnitsNet.Modular source generator from the current repository
checkout. The generated quantity structs and unit enums become part of this app at build time; no
generated C# is checked in.

## Run it from VS Code

The Codespace builds the project once while it is being created. Open `Program.cs`, then press `F5`
to debug or `Ctrl+F5` to run without the debugger. If VS Code asks for a profile, choose
**UnitsNet.Modular playground**. Output appears in the integrated terminal.

You can also open a terminal and run:

```shell
dotnet run
```

Every edit uses the usual .NET feedback loop: save a file and run `dotnet run` again.

## Experiment

Start with any of these:

1. In `ApplicationUnits.cs`, add or remove a built-in `IInclude<...>` quantity selection.
2. Change a `[UnitSet]` list and see which enum members remain available after rebuilding.
3. In `GameScore.unitsnet.json`, add a unit or change a conversion expression.
4. In `Program.cs`, use the generated types, conversions, parsing, formatting, or operators.

The project enables `EmitCompilerGeneratedFiles`, so after a build you can also inspect the emitted
C# under `obj/Generated/UnitsNet.Modular.Generator/UnitsNet.Modular.Generator.UnitsNetModularGenerator/`.
Delete or ignore that folder when you are done; it is build output and is not part of the project.

For the complete authoring model, see the [UnitsNet.Modular documentation](../../README.md).
