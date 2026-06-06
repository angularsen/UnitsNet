# Collaborators: Releasing NuGet Packages

Collaborators are able to release new nugets by pushing new versions of project files directly to the `master` branch, although the same could be achieved by pull requests from anyone. Usually we release a new version of nugets for every merged pull request, or for a batch of PRs if several were merged in.

## Release New Nugets Using AppVeyor Build Server

The build server will build and attempt to push nugets for every git push to the `master` branch. It will only succeed to push new nugets if the version changed since nuget.org does not accept publishing the same version twice.

### Prerequisites

Set up your local `master` branch to use `angularsen/UnitsNet` repo as upstream. Optionally, use your fork `myuser/UnitsNet` as upstream for feature branches. [See guide](#initial-setup) on setting this up.

### Typical example in Git for Windows / Bash

This is what I do to publish new UnitsNet nugets. I have checked out `angularsen/UnitsNet` repo as my `origin` remote.
```
git checkout master                          # Checkout master
git pull --fast-forward                      # Pull latest origin/master, fail if there are local commits
./Build/bump-version-UnitsNet-minor.bat      # Increase the version and create an annotated git tag
git log                                      # Verify that it is only the version commit about to be pushed
git push --follow-tags                       # Push commits and tags
git log --oneline --first-parent             # Compact log for copy & paste of commits into release page, see below
```

* [Create GitHub release](https://github.com/angularsen/UnitsNet/releases) by editing the newly published tag in GitHub releases page
  - The title should read something like `UnitsNet/4.10.0`
  - Copy in all notable commit messages since previous tag (usually pull request commits)
  - Post a link to the release in the respective pull requests, so it is easy to backtrack what release a PR was included in
* Optionally, view build progress and details at https://ci.appveyor.com/project/angularsen/unitsnet

### Versioning

Versioning follows [SemVer](https://semver.org/).
- Major **for breaking changes**
- Minor **for new things**
- Patch **for bug fixes**

### Versioning scripts: UnitsNet

When adding units or new features in UnitsNet, bump the version of `UnitsNet` nugets.
* [/Build/bump-version-UnitsNet-major.bat](https://github.com/angularsen/UnitsNet/blob/master/Build/bump-version-UnitsNet-major.bat)
* [/Build/bump-version-UnitsNet-minor.bat](https://github.com/angularsen/UnitsNet/blob/master/Build/bump-version-UnitsNet-minor.bat)
* [/Build/bump-version-UnitsNet-patch.bat](https://github.com/angularsen/UnitsNet/blob/master/Build/bump-version-UnitsNet-patch.bat)

### Versioning scripts: UnitsNet.Serialization.JsonNet

If JSON serialization has changed or it is dependent on a newer version of UnitsNet, then the JSON library version should be bumped similar to above.
* `/Build/bump-version-UnitsNet.Serialization.JsonNet-major.bat`
* `/Build/bump-version-UnitsNet.Serialization.JsonNet-minor.bat`
* `/Build/bump-version-UnitsNet.Serialization.JsonNet-patch.bat`

## NuGet Packages

We currently have 3 nugets:

### UnitsNet (Core)

The core nuget holds all the widely used units and conversions.

* [UnitsNet on nuget.org](https://nuget.org/packages/UnitsNet)

### UnitsNet.Serialization.JsonNet

Serialization using Json.NET.

* [UnitsNet.Serialization.JsonNet on nuget.org](https://nuget.org/packages/UnitsNet.Serialization.JsonNet)

## Initial setup

The goal of this guide is to have a consistent setup of git remotes:
* `origin`: `angularsen/UnitsNet`, for master branch
* `my`: `myuser/UnitsNet`, for pull request branches

### If you have cloned your fork

Then point `master` to official repo.

```
# rename the fork remote to 'my'
git remote rename origin my

# Add official repo as origin remote using either SSH or HTTPS url
git remote add origin git@github.com:angularsen/UnitsNet.git
git remote add origin https://github.com/angularsen/UnitsNet.git

# Checkout master and point it to origin/master
git checkout master
git branch --set-upstream-to=origin/master
```

### If you have cloned the official repo

Then `master` branch is already pointing to official repo and you just need to add your fork as a remote to push feature branches there.

```
# Add your fork repo as 'my' remote using either SSH or HTTPS url
git remote add my git@github.com:myuser/UnitsNet.git
git remote add my https://github.com/myuser/UnitsNet.git
```

### Use your fork for pull requests and experimental branches

Use your fork when creating and pushing new branches. This is to avoid a clutter of work-in-progress branches before they are ready for review.

```
git checkout -b new-branch origin/master  # new branch, based on remote master
# Add some commits...
git push my new-branch                    # push branch to your fork
# Create PR from your fork's github web page
```

### Alternative: Manually push nugets

This should normally never be necessary, but if for any reason you need to deploy new nugets outside AppVeyor build server then you can do it like this.

The general flow is documented at nuget.org: https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package

* Obtain nuget API key with access to push `UnitsNet` and related nuget packages
* Set nuget API key on your PC: `nuget setApiKey Your-API-Key`
* Run `build.bat` to build everything
* Run `/Build/push-nugets.bat` to push nugets
* Alternatively run `dotnet nuget push <nuget path>` for nugets in `/Artifacts/NuGet` folder
