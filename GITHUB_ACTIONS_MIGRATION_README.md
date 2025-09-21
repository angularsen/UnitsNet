# GitHub Actions Migration

This PR adds GitHub Actions workflows to run alongside the existing Azure Pipelines configuration.

## Files to Move

Due to GitHub App permission restrictions, the workflow files are created in the root directory. Please move these files to `.github/workflows/` after merging:

1. `github-actions-ci.yml` → `.github/workflows/ci.yml`
2. `github-actions-pr.yml` → `.github/workflows/pr.yml`

## Key Features

### CI Workflow (ci.yml)
- Triggers on pushes to master, release/*, and maintenance/* branches
- Builds with .NET nanoFramework support using `nanoframework/nanobuild@v1` action
- Runs tests and uploads coverage to codecov.io
- Publishes NuGet packages to nuget.org (only on master branch)
- Uses Windows runner to match Azure Pipelines configuration

### PR Workflow (pr.yml)
- Triggers on pull requests to master, release/*, and maintenance/* branches
- Same build and test process as CI workflow
- Publishes test results as PR checks
- Uploads test coverage to codecov.io
- No NuGet publishing for PRs

## .NET nanoFramework Support

The key challenge mentioned in the issue was .NET nanoFramework support. This is handled using the `nanoframework/nanobuild@v1` GitHub Action, which is the official GitHub Actions equivalent of the Azure Pipelines `InstallNanoMSBuildComponents@1` task.

## Migration Notes

- Both workflows use the existing PowerShell build script (`Build/build.ps1`) with the `-IncludeNanoFramework` flag
- Secrets needed: `CODECOV_TOKEN` and `NUGET_ORG_APIKEY` (should already be configured)
- The workflows are designed to run alongside Azure Pipelines for comparison
- Azure Pipelines configuration files remain unchanged as requested

## Next Steps

1. Move the workflow files to `.github/workflows/`
2. Test both workflows to ensure they work correctly
3. Compare results with Azure Pipelines
4. Make any necessary adjustments based on testing