# External Integrations

## 1) Integration Inventory

| System | Type (API/DB/Queue/etc) | Purpose | Auth model | Criticality | Evidence |
|--------|---------------------------|---------|------------|-------------|----------|
| Microsoft.Extensions.Logging | Library abstraction | Optional host-supplied agent logging. | Not applicable. | Low | `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs` |
| GitHub Packages | Package registry | Publishes release package artifacts. | GitHub Actions repository secret. | High for GitHub package publication | `.github/workflows/release.yml` |
| NuGet.org | Package registry | Publishes release package artifacts. | GitHub Actions repository secret. | High for NuGet.org publication | `.github/workflows/release.yml` |
| Gitea NuGet feed | Package registry | Receives packages from Azure Pipelines. | Azure Pipelines secret variable. | High for Azure release publication | `azure-pipeline.yml` |

No runtime API, database, queue, or monitoring integration was found in the library source.

## 2) Data Stores

| Store | Role | Access layer | Key risk | Evidence |
|-------|------|--------------|----------|----------|
| [TODO] | No application data store was found. | Not applicable. | Host-managed context data is outside this repository. | `src/KamiYomu.ActionAgents.Core/Contexts/ActionAgentContext.cs` |

## 3) Secrets and Credentials Handling

- Credential sources: GitHub Actions references `GH_KAMIYOMU_GITHUB_PACKAGE_PUBLISHER` and `GH_KAMIYOMU_NUGETORG_PACKAGE_PUBLISHER` as repository secrets. Azure Pipelines references `KamiYomu-Secrets` and two secret variables for its Gitea feed.
- Hardcoding checks: No credentials or runtime external endpoint literals were found in the library source. Package registry URLs are intentionally declared in release workflow configuration.
- Rotation or lifecycle notes: [TODO] Secret rotation ownership and schedule are not documented in this repository.

## 4) Reliability and Failure Behavior

- Retry/backoff behavior: None is implemented in this library; it has no runtime client calls.
- Timeout policy: None is configured in this library. `IActionAgent.ExecuteAsync` and `IValidatableActionAgent.ValidateAsync` receive caller-provided cancellation tokens.
- Circuit-breaker or fallback behavior: None was found.

## 5) Observability for Integrations

- Logging around external calls: No runtime external calls exist. The base class exposes an optional `ILogger` for consumer implementations.
- Metrics/tracing coverage: No metrics or tracing integration was found.
- Missing visibility gaps: Consumer action implementations must establish their own structured logging, metrics, and external-call diagnostics.

## 6) Evidence

- `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs`
- `src/KamiYomu.ActionAgents.Core/IActionAgent.cs`
- `.github/workflows/release.yml`
- `azure-pipeline.yml`
