class Quantity
{
  [string]$Name
  [string]$XmlDocSummary
  [string]$XmlDocRemarks
  [string]$BaseUnit
  [string]$BaseType # TODO Rename me to ValueType
  [BaseDimensions]$BaseDimensions = [BaseDimensions]::new()
  [boolean]$GenerateArithmetic = $true
  [boolean]$Logarithmic = $false
  [int]$LogarithmicScalingFactor = 1
  [Unit[]]$Units = @()
}

class Unit
{
  [string]$SingularName
  [string]$PluralName
  [string]$XmlDocSummary
  [string]$XmlDocRemarks
  [string]$FromUnitToBaseFunc
  [string]$FromBaseToUnitFunc
  [string[]]$Prefixes = @()
  [Localization[]]$Localization = @()
}

class Localization
{
  [string]$Culture
  [string[]]$Abbreviations = @()
  [string[]]$AbbreviationsWithPrefixes = @()
}

class BaseDimensions
{
    [int]$Length = 0
    [int]$Mass = 0
    [int]$Time = 0
    [int]$ElectricCurrent = 0
    [int]$Temperature = 0
    [int]$AmountOfSubstance = 0
    [int]$LuminousIntensity = 0
}
