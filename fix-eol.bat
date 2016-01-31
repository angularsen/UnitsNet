@ECHO OFF
SET Dir=%1
IF "%1"=="" (
    SET Dir=%~dp0.
)

ECHO Using dir: %Dir%
ECHO Normalizing EOL to LF on: 
ECHO .cs .cshtml .js .html .ts .csproj .config

REM Exclude .sln files, they need to be CRLF
%~dp0\tools\sfk.exe crlf-to-lf %Dir% .cs .cshtml .js .html .ts -yes

ECHO Normalizing EOL to CRLF on: 
ECHO .sln .csproj .config
%~dp0\tools\sfk.exe lf-to-crlf %Dir% .sln .csproj .config -yes
