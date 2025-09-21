# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

UnitsNet is a .NET library that provides strongly-typed physical units and quantities, enabling safe and intuitive unit conversions in code. The library uses code generation from JSON definitions to create type-safe APIs for over 130 physical quantities.

## Key Commands

### Build and Test
- **Build project**: `build.bat` or `dotnet build UnitsNet.slnx`
- **Build all targets** (including nanoFramework): `build-all-targets.bat`
- **Run tests**: `test.bat` or `dotnet test UnitsNet.slnx`
- **Run single test**: `dotnet test UnitsNet.Tests --filter "FullyQualifiedName~TestClassName.TestMethodName"`
- **Clean artifacts**: `clean.bat`

### Code Generation
- **Generate code from JSON definitions**: `generate-code.bat` or `dotnet run --project CodeGen`
  - Always run this after modifying any JSON files in `Common/UnitDefinitions/`
  - The generator reads 131 JSON definition files and creates C# code

### Development Workflow
1. Modify unit definitions in `Common/UnitDefinitions/*.json`
2. Run `generate-code.bat` to regenerate C# code
3. Run `build.bat` to compile and test
4. Use `test.bat` for isolated test runs

## Code Architecture

### Project Structure
- **UnitsNet/**: Main library with quantity types and units
  - `GeneratedCode/`: Auto-generated from JSON definitions (do not edit manually)
  - `CustomCode/`: Hand-written code extending generated types
- **UnitsNet.Tests/**: Comprehensive test suite
- **CodeGen/**: Code generation tool that creates C# from JSON definitions
- **Common/UnitDefinitions/**: 131 JSON files defining physical quantities
- **UnitsNet.NumberExtensions/**: Extension methods for numeric types
- **UnitsNet.Serialization.*/**: JSON.NET and System.Text.Json serialization support
- **UnitsNet.NanoFramework/**: Support for embedded .NET nanoFramework

### Code Generation Process
The project uses a sophisticated code generation system:
1. JSON definitions in `Common/UnitDefinitions/` describe units, conversions, and localizations
2. `CodeGen` project processes these to generate:
   - Quantity types (e.g., `Length`, `Mass`)
   - Unit enums (e.g., `LengthUnit`, `MassUnit`)
   - Conversion logic and unit abbreviations
3. Generated code goes to `*/GeneratedCode/` folders
4. Custom code in `*/CustomCode/` extends generated types

### Key Classes and Patterns
- **IQuantity**: Base interface for all quantity types
- **Quantity**: Static class for dynamic quantity operations
- **UnitConverter**: Handles conversions between units
- **QuantityParser/UnitParser**: Parse strings to quantities/units
- **UnitsNetSetup**: Configuration singleton

### Adding or Modifying Units
1. Edit or create JSON file in `Common/UnitDefinitions/`
2. Follow conversion function guidelines:
   - Use multiplication for `FromUnitToBaseFunc`
   - Use division for `FromBaseToUnitFunc`
   - Prefer scientific notation (1e3, 1e-5)
3. Run `generate-code.bat`
4. Add tests if needed

## Important Conventions

### Coding Standards
- Follow `.editorconfig` specifications
- Use ReSharper settings in `UnitsNet.sln.DotSettings`
- Treat warnings as errors (except obsolete warnings)
- Add file headers to new files

### Unit Definition Rules
- Base units are chosen for each quantity (e.g., meter for Length)
- All conversions go through the base unit
- Use superscript in abbreviations: cm², m³
- Compound units format: N·m (dot), km/h (slash)

### Testing
- Test class naming: `<Type>Tests`
- Test method naming: `<method>_<condition>_<result>`
- Tests accept error margin of 1E-5 for most units

## Special Considerations

### .NET nanoFramework Support
- Separate projects for nanoFramework compatibility
- Use `build-all-targets.bat` to include nanoFramework builds
- Limited feature set compared to full .NET

### Performance
- Conversion functions are compiled to delegates for performance
- All conversions go through base units (potential for small errors)
- Precision goal is 1E-5 for most units

### Localization
- Unit abbreviations support multiple cultures
- JSON definitions include translations for various languages
- Default culture: Thread.CurrentCulture, fallback to en-US

## Common Tasks

### Find specific quantity or unit implementation
- Quantity types: `UnitsNet/GeneratedCode/Quantities/*.g.cs`
- Unit enums: `UnitsNet/GeneratedCode/Units/*.g.cs`
- Custom extensions: `UnitsNet/CustomCode/Quantities/*.extra.cs`
- Unit definitions: `Common/UnitDefinitions/*.json`

### Debug code generation
- Generator entry: `CodeGen/Program.cs`
- Generator logic: `CodeGen/Generators/`
- Enable verbose logging: Check Serilog configuration in Program.cs

### Run performance benchmarks
- Execute: `dotnet run -c Release --project UnitsNet.Benchmark`
- Results saved to `Artifacts/` folder

## Pull request reviews

### Adding new quantities or units

See `.claude/criteria-for-adding-quantities-and-units.md` for instructions on adding new quantities or units to ensure they are widely used and well defined.
