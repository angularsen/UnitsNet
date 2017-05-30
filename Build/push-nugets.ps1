$root = "$PSScriptRoot\.."

ls "$root\Artifacts\NuGet\*.nupkg" | %{
    $nugetPath = $_
    write-host -foreground blue "Push nuget: $nugetPath"
    dotnet nuget push $nugetPath
}