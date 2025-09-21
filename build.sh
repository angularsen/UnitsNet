#!/bin/bash
set -e

# Build script for Standard (non-NanoFramework) projects on Linux/macOS
# This script builds, tests, and packs all main UnitsNet projects
# NanoFramework projects require Windows and should use build.ps1 instead

echo -e "\033[36m===== UnitsNet Build Script (Linux/macOS) =====\033[0m"
echo "Building Standard projects only (NanoFramework requires Windows)"
echo ""

# Change to script directory
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd "$SCRIPT_DIR/.."

# Check if dotnet is installed
if ! command -v dotnet &> /dev/null; then
    echo -e "\033[31mError: dotnet CLI is not installed\033[0m"
    exit 1
fi

# Clean artifacts directory
if [ -d "Artifacts" ]; then
    echo "Cleaning Artifacts directory..."
    rm -rf Artifacts
fi
mkdir -p Artifacts

# Generate code from JSON definitions
echo -e "\033[36m===== Generating Code =====\033[0m"
dotnet run --project CodeGen

# Build all Standard projects
echo -e "\033[36m===== Building Projects =====\033[0m"
dotnet build UnitsNet.slnx --configuration Release

# Run tests
echo -e "\033[36m===== Running Tests =====\033[0m"
dotnet test UnitsNet.slnx --configuration Release --no-build \
    --collect:"XPlat Code Coverage" \
    --logger:trx \
    --results-directory "Artifacts/TestResults"

# Pack NuGet packages
echo -e "\033[36m===== Packing NuGet Packages =====\033[0m"
dotnet pack UnitsNet.slnx --configuration Release --no-build \
    --output Artifacts/NuGet

# Summary
echo ""
echo -e "\033[32m===== Build Complete =====\033[0m"
echo "Artifacts:"
echo "  - Test Results: Artifacts/TestResults/"
echo "  - NuGet Packages: Artifacts/NuGet/"
echo "  - Coverage: Artifacts/TestResults/"
echo ""
echo "To build NanoFramework projects, use:"
echo "  Windows: powershell ./Build/build.ps1 -IncludeNanoFramework"