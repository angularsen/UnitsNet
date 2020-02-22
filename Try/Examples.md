# Units.NET interactive examples

⚠ This will not work in the web browser just yet. Nuget support is still being worked on.
When that support is added, you could test this with `dotnet try` and a browser would launch to `localhost`.

In the meantime, you can test it from CLI and .NET Core 3.0 SDK with:
```bash
dotnet run -- --region hello-world
dotnet run -- --region tostring
```

See `Program.cs` or the source of this markdown file for all the region names.

[Support NuGet packages · Issue #36 · dotnet/try](https://github.com/dotnet/try/issues/36)

## Hello World!
```cs --region hello-world --source-file ./Program.cs --project ./Try.csproj
```

## ToString
```cs --region tostring --source-file ./Program.cs --project ./Try.csproj
```
