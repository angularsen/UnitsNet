# Read current UTC date time
$date = Get-Date
$dateString = $date.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")

#$file = "Src\MyProject\ApplicationInformation.cs"
#$srcString = 'const string buildDateString = "(.*)";'
#$newString = 'const string buildDateString = "'+$dateString+'";'

# Update buildDateString field in ApplicationInformation.cs
#(Get-Content $file) | 
#Foreach-Object {$_ -replace $srcString, $newString} | 
#Set-Content $file -Encoding UTF8

write-host "Build date: $dateString"