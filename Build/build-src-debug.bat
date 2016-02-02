SET ROOT=%~dp0..
"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe" %ROOT%\Build\src.msbuild /verbosity:normal /p:Configuration=Debug /p:Platform="AnyCPU" /target:CleanAndBuild /p:RestorePackages=false
