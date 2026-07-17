# Collaborators: Regenerate nuget.org API Key

Every year the nuget.org API keys expire and must be regenerated. A reminder email is sent out to the registered owners on nuget.org.

## Steps

- Log in to https://www.nuget.org/account/ApiKeys with an account that is admin of [UnitsNet organization](https://www.nuget.org/organization/UnitsNet)
- Create or regenerate key with name `AppVeyor for UnitsNet project`
  - Expires in: `365 days`
  - Package owner: `UnitsNet`
  - Select scopes: `Push > Push new packages and package versions`
  - Select packages > Glob pattern: `*` to include all UnitsNet packages
- Copy the API key
- Encrypt the API key by pasting it into https://ci.appveyor.com/tools/encrypt (log in with account that is admin of UnitsNet project)
- Update [appveyor.yml](https://github.com/angularsen/UnitsNet/blob/master/appveyor.yml) with the **ENCRYPTED** API key
```yaml
deploy:
- provider: NuGet
  api_key:
    secure: <ENCRYPTED_KEY_HERE>
  on:
    branch: master

- provider: NuGet
  api_key:
    secure: <ENCRYPTED_KEY_HERE>
  on:
    branch: release/*
```
- Commit and push to `master`, or go via pull request if you want some extra eyes on it
- Bump nuget versions to test the new API key
  - On `master` branch, run https://github.com/angularsen/UnitsNet/blob/master/Build/bump-version-UnitsNet-patch.bat
  - Push the bumped version commits
- Verify that within 20 minutes, the new [UnitsNet package](https://www.nuget.org/packages/UnitsNet/) version is out on nuget.org
  - Monitor or troubleshoot the build at: https://ci.appveyor.com/project/angularsen/unitsnet/
  - You will typically receive an email when the new package version is made available
