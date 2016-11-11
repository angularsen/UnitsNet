@echo off
set StrongNameSignFile=%1
set ROOT=%~dp0..
if exist %StrongNameSignFile% (
	echo "BUILD WITH STRONG NAME SIGNING USING %StrongNameSignFile%"
	pause
	"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" %ROOT%\Build\all.msbuild /verbosity:normal /p:Configuration=Release /p:Platform="AnyCPU" /target:CleanAndBuild /p:RestorePackages=false /p:SignAssembly=true /p:AssemblyOriginatorKeyFile=%StrongNameSignFile%
) else (
	echo "NO STRONG NAME SIGNING FILE"
	pause
	"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" %ROOT%\Build\all.msbuild /verbosity:normal /p:Configuration=Release /p:Platform="AnyCPU" /target:CleanAndBuild /p:RestorePackages=false
)
if %errorlevel% neq 0 exit /b %errorlevel%
