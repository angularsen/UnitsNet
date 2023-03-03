#!/usr/bin/env bash
# TEMP CHANGE
# TEMP MORE

declare -r SCRIPT_DIR=$(realpath "$(dirname "$0")")

dotnet run --project "$SCRIPT_DIR/CodeGen"
