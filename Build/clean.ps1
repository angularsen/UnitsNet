# Don't allow using undeclared variables
Set-Strictmode -version latest

$root = (Resolve-Path "$PSScriptRoot\..").Path
$artifactsDir = "$root\Artifacts"
$toolsDir = "$root\.tools"

Write-Host -Foreground Blue "Delete .tools"
Remove-Item -Recurse -Force -ErrorAction Ignore "$toolsDir"

Write-Host -Foreground Blue "Delete Artifacts"
Remove-Item -Recurse -Force -ErrorAction Ignore "$artifactsDir"

Write-Host -Foreground Blue "Delete dirs: bin, obj"

[int]$deleteCount = 0
[array]$failedToDeleteDirs = @()
Get-ChildItem $root -Include bin,obj -Recurse -Force | %{
  Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $_.FullName
  if ($?) { $deleteCount++ }
  else {
    $failedToDeleteDirs += $_
  }
}

Write-Host -Foreground Green "Deleted $deleteCount folders."

if ($failedToDeleteDirs) {
  $failCount = $failedToDeleteDirs.Count
  Write-Host ""
  Write-Host -Foreground Red "Failed to delete $failCount dirs:"
  $failedToDeleteDirs | %{
    Write-Host -Foreground Red $_.FullName
  }
  exit /B 1
}
