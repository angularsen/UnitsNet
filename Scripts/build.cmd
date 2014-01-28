@echo off
SET ROOT=".."
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.net35.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.pcl.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.sl4.csproj
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild /t:Rebuild /p:Configuration=Release %ROOT%\Src\UnitsNet\UnitsNet.netcore45.csproj
pause