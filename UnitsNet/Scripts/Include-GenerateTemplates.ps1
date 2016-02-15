<#
.SYNOPSIS
Returns the Obsolete attribute if ObsoleteText has been defined on the JSON input - otherwise returns empty string
It is up to the consumer to wrap any padding/new lines in order to keep to correct indentation formats
#>
function GetObsoleteAttribute($unitClass)
{
    if ($unitClass.ObsoleteText)
    {
        return  "[System.Obsolete(""$($unitClass.ObsoleteText)"")]";
    }
    return "";
}