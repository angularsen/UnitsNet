@echo off
SET ROOT=".."
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.net35.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.Net451.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.Portable40.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.Portable45.csproj /p:DefineConstants="PORTABLE45"
pause