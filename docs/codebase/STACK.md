# Technology Stack

## 1) Runtime Summary

| Area | Value | Evidence |
|------|-------|----------|
| Primary language | C# | `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj` |
| Runtime + version | .NET 8 (`net8.0`) | `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj` |
| Package manager | NuGet via the .NET SDK | `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj` |
| Module/build system | SDK-style .NET projects in a Visual Studio solution | `src/KamiYomu.ActionAgents.Core.sln` |

## 2) Production Frameworks and Dependencies

| Dependency | Version | Role in system | Evidence |
|------------|---------|----------------|----------|
| `Microsoft.Extensions.Logging` | `10.0.11` | Provides the optional `ILogger` accepted by `AbstractActionAgent`. | `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj`; `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs` |

## 3) Development Toolchain

| Tool | Purpose | Evidence |
|------|---------|----------|
| .NET SDK 8 | Restore, build, test, and package projects. | `.github/workflows/pull-request.yml`; `azure-pipeline.yml` |
| xUnit | Test framework configured in the test project. | `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj` |
| Moq | Mocking library configured in the test project. | `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj` |
| coverlet collector | Collects test coverage when enabled by the test command. | `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj` |
| EditorConfig analyzers | Enforces C# style preferences, including explicit types and file-scoped namespaces. | `src/.editorconfig` |

## 4) Key Commands

```powershell
dotnet restore .\src\KamiYomu.ActionAgents.Core.sln
dotnet build .\src\KamiYomu.ActionAgents.Core.sln --configuration Release --no-restore
dotnet test .\src\KamiYomu.ActionAgents.Core.sln --configuration Release --no-build
dotnet pack .\src\KamiYomu.ActionAgents.Core\KamiYomu.ActionAgents.Core.csproj --configuration Release
```

The first three commands are used by pull-request validation. Release pipelines also invoke `dotnet pack`.

## 5) Environment and Config

- Config sources: `src/.editorconfig`, project files, `.github/workflows/*.yml`, and `azure-pipeline.yml`.
- Required application environment variables: [TODO] No application environment-variable reads or environment template files were found in the library source.
- Deployment/runtime constraints: Consumer action-agent projects must target .NET 8 according to the README; this repository itself builds as a class library for `net8.0`.
- Release credentials: GitHub Actions uses repository secrets for GitHub Packages and NuGet.org; Azure Pipelines uses the `KamiYomu-Secrets` variable group. See `release.yml` and `azure-pipeline.yml`.

## 6) Evidence

- `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj`
- `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj`
- `src/KamiYomu.ActionAgents.Core.sln`
- `.github/workflows/pull-request.yml`
- `azure-pipeline.yml`
