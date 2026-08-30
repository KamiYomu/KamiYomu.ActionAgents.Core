# Codebase Concerns

## 1) Top Risks (Prioritized)

| Severity | Concern | Evidence | Impact | Suggested action |
|----------|---------|----------|--------|------------------|
| high | GitHub release workflow references files absent from the repository. | `.github/workflows/release.yml` references `./src/NuGet.config` and `./tests/KamiYomu.ActionAgents.Core.Tests/...`; root/source tree scan | Release builds can fail before package publication. | Correct workflow paths or add the intended NuGet config and test-project layout. |
| medium | The mutable builders do not consistently validate required non-nullable members. | `Contexts/Builders/ActionAgentContextBuilder.cs`; `Contexts/Builders/MangaContextBuilder.cs`; `Contexts/Builders/ChapterContextBuilder.cs` | Consumers can receive partially initialized contexts and encounter failures later in execution. | Define required-field invariants and apply them consistently in builders. |
| medium | Agent options are an untyped string/object dictionary; a wrong logger value becomes `null` silently. | `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs` | Integration errors are discovered late and can disable expected diagnostic output. | Introduce typed options or validate known keys/types at the host boundary. |
| low | Public interfaces and the trigger enum do not have direct test source. | `src/KamiYomu.ActionAgents.Core/IActionAgent.cs`; `src/KamiYomu.ActionAgents.Core/Contexts/Definitions/ActionTriggerSource.cs` | Contract signatures and enum members have limited direct regression protection. | Add compile-time contract and enum-value assertions when their API evolves. |

## 2) Technical Debt

| Debt item | Why it exists | Where | Risk if ignored | Suggested fix |
|-----------|---------------|-------|-----------------|---------------|
| Coverage thresholds | Tests cover public classes, but CI does not collect or enforce coverage. | `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj`; `.github/workflows/pull-request.yml` | Test completeness can regress without a quantitative quality gate. | Decide whether coverage collection and a minimum threshold are required. |
| Inconsistent validation | Only chapter IDs are enforced by a builder. | `Contexts/Builders/*.cs` | Required context contracts are unclear and inconsistently enforced. | Document and validate required aggregate/manga/trigger fields. |
| Workflow drift | A release workflow uses a `tests/` path, while the test project is in `src/`; it also references an absent `src/NuGet.config`. | `.github/workflows/release.yml` | Automated release process is unreliable. | Align CI paths with the solution and decide whether a NuGet config is required. |

## 3) Security Concerns

| Risk | OWASP category (if applicable) | Evidence | Current mitigation | Gap |
|------|--------------------------------|----------|--------------------|-----|
| Package-publishing credentials are high-value release secrets. | N/A | `.github/workflows/release.yml`; `azure-pipeline.yml` | Credentials are referenced as CI secrets/variable-group values rather than committed in source. | [ASK USER] Confirm least-privilege scope, rotation process, and release approval controls. |
| Configuration metadata can represent passwords, but the core library has no handling for values. | A02:2021 Cryptographic Failures (potential consumer concern) | `src/KamiYomu.ActionAgents.Core/Inputs/ActionPasswordAttribute.cs` | This repository only marks an input as password metadata and does not store or log its value. | Consumer hosts need a documented secure-storage and redaction policy. |

## 4) Performance and Scaling Concerns

| Concern | Evidence | Current symptom | Scaling risk | Suggested improvement |
|---------|----------|-----------------|-------------|-----------------------|
| No runtime data path is implemented here. | `IActionAgent.cs`; repository source scan | No database, HTTP, or queue work exists to profile. | Performance characteristics reside in consumer action packages and host code. | [TODO] Assess performance in host and concrete agent repositories. |
| Builder mutation can leak shared state. | `Contexts/Builders/ActionAgentContextBuilder.cs` and similar builders return their held instance. | A reused builder changes a previously built object. | Concurrent or reused construction can create inconsistent context observations. | Return immutable/copy-on-build values or document single-use builders. |

## 5) Fragile/High-Churn Areas

| Area | Why fragile | Churn signal | Safe change strategy |
|------|-------------|-------------|----------------------|
| `src/KamiYomu.ActionAgents.Core/Inputs/AbstractActionInputAttribute.cs` | It is the base metadata contract for several attributes. | Two commits in the last 90 days, the highest source-file churn in scan output. | Preserve constructor behavior and add compatibility tests before changing properties or overloads. |
| `src/KamiYomu.ActionAgents.Core.sln` | It connects the library and test projects for every build. | Three commits in the last 90 days, the highest tracked-file churn in scan output. | Validate CI paths after solution/project changes. |

## 6) `[ASK USER]` Questions

1. [ASK USER] Are `KamiYomuBaseUri`, `TempDirectory`, and `Trigger` required for every execution, and should their builders reject missing values?
2. [ASK USER] Should the library guarantee that builders produce independent immutable snapshots, or is shared mutable context intentional?
3. [ASK USER] Is GitHub Actions intended to be the authoritative release path, Azure Pipelines the authoritative release path, or are both required?
4. [ASK USER] What secure storage, redaction, rotation, and approval policy should host implementations use for values annotated with `ActionPasswordAttribute` and for package-publishing credentials?

## 7) Evidence

- `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj`
- `.github/workflows/release.yml`
- `src/KamiYomu.ActionAgents.Core/Contexts/Builders/ActionAgentContextBuilder.cs`
- `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs`
