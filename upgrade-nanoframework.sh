#!/usr/bin/env bash
# Convenience script to update nanoFramework dependencies.
declare -r SCRIPT_DIR=$(realpath "$(dirname "$0")")

dotnet run --project "$SCRIPT_DIR/CodeGen" --update-nano-framework-dependencies
