#!/bin/bash
set -e

# Apply migrations if schema is outdated
if dotnet ef database update --no-build; then
  echo "Database checked/updated"
else
  echo "Failed to update database" >&2
fi

exec dotnet Multitenant.Api.dll
