#!/usr/bin/env bash
# TEMP CHANGE

declare -r SCRIPT_DIR=$(realpath "$(dirname "$0")")

dotnet run --project "$SCRIPT_DIR/CodeGen"
