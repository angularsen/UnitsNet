@echo off
set StrongNameSignFile="%1"
set errorlevel=0
set ROOT=%~dp0..
set SrcDir="%ROOT%\Artifacts\Bin\Src"
set SrcSignedDir="%ROOT%\Artifacts\Bin\Src-signed"

if exist "%StrongNameSignFile%" (
	echo Build signed binaries with key: %StrongNameSignFile%
	"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" %ROOT%\Build\build-signed.msbuild /verbosity:Normal /p:Configuration=Release /target:Clean;Rebuild /p:RestorePackages=false /p:SignAssembly=true /p:AssemblyOriginatorKeyFile=%StrongNameSignFile%

	if %errorlevel% neq 0 (
		echo Error: %errorlevel%
		exit /b %errorlevel%
	)

	echo %SrcDir%
	echo Move signed binaries to: %SrcSignedDir%
	@echo on
	if exist %SrcSignedDir% rmdir /Q /S %SrcSignedDir%
	ren %SrcDir% "Src-signed"
	@echo off
) else (
	echo NO STRONG NAME SIGNING FILE: %StrongNameSignFile%
)