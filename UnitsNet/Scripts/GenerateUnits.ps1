using module ".\Types.psm1"

#Requires -Version 5.1

# Set Write-Output used by Include- files to UTF8 encoding to fix copyright character
[Console]::OutputEncoding = [Text.UTF8Encoding]::UTF8
$OutputEncoding = [Text.UTF8Encoding]::UTF8

# DaddyCool => daddyCool
function ToCamelCase($str)
{
    return $str.Substring(0,1).ToLowerInvariant() + $str.Substring(1)
}

function ValueOrDefault($value, $defaultValue){
  if ($value -ne $null) { $value } else { $defaultValue }
}

function GenerateQuantity([Quantity]$quantity, $outDir)
{
    $outFileName = "$outDir/$($quantity.Name).NetFramework.g.cs"
    GenerateQuantitySourceCodeNetFramework $quantity "NetFramework" | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) { exit 1 }
    Write-Host -NoNewline "quantity .NET(OK) "

    $outFileName = "$outDir/../../../UnitsNet.WindowsRuntimeComponent/GeneratedCode/Quantities/$($quantity.Name).WindowsRuntimeComponent.g.cs"
    GenerateQuantitySourceCodeNetFramework $quantity "WindowsRuntimeComponent" | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) { exit 1 }
    Write-Host -NoNewline "quantity WRC(OK) "
}

function GenerateUnitTestBaseClass([Quantity]$quantity, $outDir)
{
    $outFileName = "$outDir/$($quantity.Name)TestsBase.g.cs"
    GenerateUnitTestBaseClassSourceCode $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "test base(OK) "
}

function GenerateUnitTestClassIfNotExists([Quantity]$quantity, $outDir)
{
    Write-Host -NoNewline "test stub"
    $outFileName = "$outDir/$($quantity.Name)Tests.cs"
    if (Test-Path $outFileName)
    {
        Write-Host -NoNewline "(skip) "
        return
    }
    else
    {
        GenerateUnitTestPlaceholderSourceCode $quantity | Out-File -Encoding "UTF8" $outFileName | Out-Null
        if (!$?) {
            exit 1
        }
        Write-Host -NoNewline "(OK) "
    }
}

function GenerateUnitType([Quantity]$quantity, $outDir)
{
    $outFileName = "$outDir/$($quantity.Name)Unit.g.cs"

    GenerateUnitTypeSourceCode $quantity | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        exit 1
    }
    Write-Host -NoNewline "unit(OK) "
}

function GenerateUnitSystemDefault($quantities, $outDir)
{
    Write-Host -NoNewline "UnitAbbreviationsCache.g.cs: "
    $outFileName = "$outDir/UnitAbbreviationsCache.g.cs"

    GenerateUnitSystemDefaultSourceCode $quantities | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        Write-Host "(error) "
        exit 1
    }
    Write-Host "(OK) "
}

function GenerateQuantityType($quantities, $outDir)
{
    Write-Host -NoNewline "QuantityType.g.cs: "
    $outFileName = "$outDir/QuantityType.g.cs"

    GenerateQuantityTypeSourceCode $quantities | Out-File -Encoding "UTF8" -Force $outFileName | Out-Null
    if (!$?) {
        Write-Host "(error) "
        exit 1
    }
    Write-Host "(OK) "
}

function EnsureDirExists([String] $dirPath) {
    New-Item -ItemType Directory -Force -Path $dirPath | Out-Null
    if (!$?) {
        exit 1
    }
}

function Set-ConversionFunctions
{
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        foreach ($u in $quantity.Units) {

            # Use decimal for internal calculations if base type is not double, such as for long or int.
            if ($quantity.BaseType -eq "decimal") {
                $u.FromUnitToBaseFunc = $u.FromUnitToBaseFunc -replace "d", "m"
                $u.FromBaseToUnitFunc = $u.FromBaseToUnitFunc -replace "d", "m"
            }

            # Convert to/from double for other base types
            $u.FromUnitToBaseFunc = "$($u.FromUnitToBaseFunc)"
            $u.FromBaseToUnitFunc = "$($u.FromBaseToUnitFunc)"
        }
        return $quantity
    }
}

function Add-PrefixUnits {
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        $prefixUnits = @()

        foreach ($unit in $quantity.Units)
        {
            foreach ($localization in $unit.Localization){
                if($localization.AbbreviationsWithPrefixes.Count -gt 0){
                    if($unit.Prefixes.Count -ne $localization.AbbreviationsWithPrefixes.Count){
                        Write-Error "The prefix count ($($unit.Prefixes.Count)) does not match the abbreviations with prefixes count ($($localization.AbbreviationsWithPrefixes.Count)) for $($quantity.Name).$($unit.SingularName)" -ErrorAction Stop
                    }
                }
            }

            $prefixIndex = 0
            foreach ($prefix in $unit.Prefixes)
            {
                $prefixInfo = switch ($prefix)
                {
                    "Kilo" { "k", "1e3d"; break; }
                    "Hecto" { "h", "1e2d"; break; }
                    "Deca" { "da", "1e1d"; break; }
                    "Deci" { "d", "1e-1d"; break; }
                    "Centi" { "c", "1e-2d"; break; }
                    "Milli" { "m", "1e-3d"; break; }
                    "Micro" { "µ", "1e-6d"; break; }
                    "Nano" { "n", "1e-9d"; break; }

                    # Optimization, move less frequently used prefixes to the end
                    "Pico" { "p", "1e-12d"; break; }
                    "Femto" { "f", "1e-15d"; break; }
                    "Atto" { "a", "1e-18d"; break; }
                    "Zepto" { "z", "1e-21d"; break; }
                    "Yocto" { "y", "1e-24d"; break; }

                    "Yotta" { "Y", "1e24d"; break; }
                    "Zetta" { "Z", "1e21d"; break; }
                    "Exa" { "E", "1e18d"; break; }
                    "Peta" { "P", "1e15d"; break; }
                    "Tera" { "T", "1e12d"; break; }
                    "Giga" { "G", "1e9d"; break; }
                    "Mega" { "M", "1e6d"; break; }

                    # Binary prefixes
                    "Kibi" { "Ki", "1024d"; break; }
                    "Mebi" { "Mi", "(1024d * 1024)"; break; }
                    "Gibi" { "Gi", "(1024d * 1024 * 1024)"; break; }
                    "Tebi" { "Ti", "(1024d * 1024 * 1024 * 1024)"; break; }
                    "Pebi" { "Pi", "(1024d * 1024 * 1024 * 1024 * 1024)"; break; }
                    "Exbi" { "Ei", "(1024d * 1024 * 1024 * 1024 * 1024 * 1024)"; break; }
                }

                $prefixAbbreviation = $prefixInfo[0]
                $prefixFactor = $prefixInfo[1]

                $prefixUnit = New-Object PsObject -Property @{
                    SingularName=$prefix + $(ToCamelCase $unit.SingularName)
                    PluralName=$prefix + $(ToCamelCase $unit.PluralName)
                    FromUnitToBaseFunc="("+$unit.FromUnitToBaseFunc+") * $prefixFactor"
                    FromBaseToUnitFunc="("+$unit.FromBaseToUnitFunc+") / $prefixFactor"

                    Localization=$unit.Localization | % {
                        $abbrev = $prefixAbbreviation + $_.Abbreviations[0]
                        if ($_.AbbreviationsWithPrefixes) {
                            $abbrev = $_.AbbreviationsWithPrefixes[$prefixIndex]
                        }

                    New-Object PsObject -Property @{
                        Culture=$_.Culture
                        Abbreviations= $abbrev
                    }}
                }

                # Append prefix unit
                $prefixUnits += $prefixUnit
                $prefixIndex++;
            } # foreach prefixes
        } # foreach units

    $quantity.Units += $prefixUnits
    return $quantity
    }
}

function Set-UnitsOrderedByName {
    param ([Parameter(Mandatory = $true, ValueFromPipeline=$true)] $quantity)
    PROCESS {
        $quantity.Units = ($quantity.Units | sort SingularName)
        return $quantity
    }
}

function Add-InheritedUnits([Quantity]$quantity, $quantities) {

    foreach ($inheritFromQuantityName in $quantity.InheritUnitsFrom) {
        $inheritFromQuantity = $quantities | Where { $_.Name -eq $inheritFromQuantityName } | Select -First 1
        $quantity.Units += $inheritFromQuantity.Units

        Write-Host -NoNewline "(inherit $inheritFromQuantityName) "
    }
}

# Load external generator functions with same name as file
. "$PSScriptRoot/Include-GenerateTemplates.ps1"
. "$PSScriptRoot/Include-GenerateUnitSystemDefaultSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateQuantityTypeSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateQuantitySourceCodeNetFramework.ps1"
. "$PSScriptRoot/Include-GenerateUnitTypeSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestBaseClassSourceCode.ps1"
. "$PSScriptRoot/Include-GenerateUnitTestPlaceholderSourceCode.ps1"

EnsureDirExists ($quantityDir = "$PSScriptRoot/../GeneratedCode/Quantities")
EnsureDirExists ($unitEnumDir = "$PSScriptRoot/../GeneratedCode/Units")
EnsureDirExists ($unitSystemDir = "$PSScriptRoot/../GeneratedCode")
EnsureDirExists ($testsDir = "$PSScriptRoot/../../UnitsNet.Tests/GeneratedCode")
EnsureDirExists ($testsCustomCodeDir = "$PSScriptRoot/../../UnitsNet.Tests/CustomCode")

$templatesDir = "$PSScriptRoot/../../Common/UnitDefinitions"
$pad = 25

# Parse unit definitions from .json files
# TODO Find a way to automap from JSON into Quantity type
$quantities = Get-ChildItem -Path $templatesDir -filter "*.json" `
    | %{(Get-Content $_.FullName -Encoding "UTF8" | Out-String)} `
    | ConvertFrom-Json `
    | %{
      # $_ | fl | out-string | write-host -foreground blue
      # New-Object -TypeName Quantity -Verbose -Property @{
      [Quantity]@{
        Name = $_.Name
        XmlDocSummary = $_.XmlDoc
        XmlDocRemarks = $_.XmlDocRemarks
        BaseUnit = $_.BaseUnit
        BaseType = ValueOrDefault $_.BaseType "double"
        BaseDimensions = @{
          Length = ValueOrDefault $_.BaseDimensions.L 0
          Mass = ValueOrDefault $_.BaseDimensions.M 0
          Time = ValueOrDefault $_.BaseDimensions.T 0
          ElectricCurrent = ValueOrDefault $_.BaseDimensions.I 0
          Temperature = ValueOrDefault $_.BaseDimensions.Θ 0
          AmountOfSubstance = ValueOrDefault $_.BaseDimensions.N 0
          LuminousIntensity = ValueOrDefault $_.BaseDimensions.J 0
        }
        GenerateArithmetic = ValueOrDefault $_.GenerateArithmetic $true
        Logarithmic = ValueOrDefault $_.Logarithmic $false
        LogarithmicScalingFactor = ValueOrDefault $_.LogarithmicScalingFactor 1
        Units = $_.Units | %{
          # $_ | fl | out-string | Write-Host -ForegroundColor blue
          [Unit]@{
            SingularName = $_.SingularName
            PluralName = $_.PluralName
            XmlDocSummary = $_.XmlDocSummary
            XmlDocRemarks = $_.XmlDocRemarks
            FromUnitToBaseFunc = $_.FromUnitToBaseFunc
            FromBaseToUnitFunc = $_.FromBaseToUnitFunc
            Prefixes = [string[]](ValueOrDefault $_.Prefixes @())
            Localization = $_.Localization | %{
              # $_ | fl | out-string | Write-Host -ForegroundColor blue
              [Localization]@{
                Culture = $_.Culture
                Abbreviations = $_.Abbreviations
                AbbreviationsWithPrefixes = $_.AbbreviationsWithPrefixes
              }
            }
          }
        }
      }
    } `
    | Add-PrefixUnits `
    | Set-ConversionFunctions `
    | Set-UnitsOrderedByName

foreach ($quantity in $quantities) {
    Write-Host -NoNewline "$($quantity.Name):".PadRight($pad)

    Add-InheritedUnits $quantity $quantities

    GenerateQuantity $quantity $quantityDir
    GenerateUnitType $quantity $unitEnumDir
    GenerateUnitTestBaseClass $quantity $testsDir
    GenerateUnitTestClassIfNotExists $quantity $testsCustomCodeDir

    Write-Host ""
}

Write-Host ""
GenerateUnitSystemDefault $quantities $unitSystemDir
GenerateQuantityType $quantities $unitSystemDir

$unitCount = ($quantities | %{$_.Units.Count} | Measure -Sum).Sum

Write-Host "`n`n"
Write-Host -Foreground Yellow "Summary: $unitCount units in $($quantities.Count) quantities".PadRight($pad)
Write-Host "`n`n"
exit 0
