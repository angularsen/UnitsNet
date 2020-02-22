# Units.NET interactive examples

⚠ This won't work if you are browsing github.com, you need to clone the repo and run it locally.
There is ongoing work to add support for publishing static files to github pages or similar.

[Dotnet try publish by ax0l0tl · Pull Request #741 · dotnet/try](https://github.com/dotnet/try/pull/741)

## Trying it out locally from CLI
```bash
git clone https://github.com/angularsen/unitsnet
cd unitsnet
cd Try

# Launch browser at localhost with interactive samples
dotnet try

# Or you can run examples locally in the CLI
dotnet run -- --region hello-world
dotnet run -- --region tostring
```

See `Program.cs` or the source of this markdown file for all the region names.

## Interactive Examples
### Hello World!
```cs --region hello-world --source-file ./Program.cs --project ./Try.csproj
```

### ToString
```cs --region tostring --source-file ./Program.cs --project ./Try.csproj
```

## Future enhancements
Some things on the roadmap to look for:
- Dynamically referencing nugets in the interactive web: [Support NuGet packages · Issue #36 · dotnet/try](https://github.com/dotnet/try/issues/36)
- Publishing static files to GitHub pages or any CDN: [Dotnet try publish by ax0l0tl · Pull Request #741 · dotnet/try](https://github.com/dotnet/try/pull/741)

