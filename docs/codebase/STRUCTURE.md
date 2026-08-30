# Codebase Structure

## 1) Top-Level Map

| Path | Purpose | Evidence |
|------|---------|----------|
| `src/KamiYomu.ActionAgents.Core/` | Main class-library project and public API surface. | `src/KamiYomu.ActionAgents.Core/KamiYomu.ActionAgents.Core.csproj` |
| `src/KamiYomu.ActionAgents.Core/Contexts/` | Event context models, trigger enum, and their builders. | `src/KamiYomu.ActionAgents.Core/Contexts/ActionAgentContext.cs` |
| `src/KamiYomu.ActionAgents.Core/Inputs/` | Attributes that declare action-agent configuration input metadata. | `src/KamiYomu.ActionAgents.Core/Inputs/AbstractActionInputAttribute.cs` |
| `src/KamiYomu.ActionAgents.Core/Validations/` | Action-agent validation result model and builder. | `src/KamiYomu.ActionAgents.Core/Validations/ActionAgentValidationResult.cs` |
| `src/KamiYomu.ActionAgents.Core.Tests/` | Test project configuration; no C# test source files were found. | `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj` |
| `.github/workflows/` | Pull-request and release automation. | `.github/workflows/pull-request.yml`; `.github/workflows/release.yml` |
| `azure-pipeline.yml` | Azure Pipelines release build and publication workflow. | `azure-pipeline.yml` |

## 2) Entry Points

- Main runtime entry: None. `KamiYomu.ActionAgents.Core` is a class library with no executable `Main` method.
- Secondary entry points: `IActionAgent.ExecuteAsync` and `IValidatableActionAgent.ValidateAsync` are the consumer-implemented entry contracts.
- How entry is selected: A host loads an implementation of these interfaces; the library contains only contracts and supporting types. The host-discovery mechanism is [TODO] because it is outside this repository.

## 3) Module Boundaries

| Boundary | What belongs here | What must not be here |
|----------|-------------------|------------------------|
| Root library project | Public interfaces and the reusable base agent class. | Host-specific action implementations or a process entry point. |
| `Contexts/` | Immutable-to-consumers context data shapes and construction helpers. | Action execution behavior. |
| `Inputs/` | Declarative metadata attributes for agent configuration inputs. | Rendering or collecting input values. |
| `Validations/` | Readiness result data and a fluent result builder. | Validation policy for a specific agent. |

## 4) Naming and Organization Rules

- File naming pattern: PascalCase C# files matching the primary public type, such as `ActionAgentContext.cs` and `ActionAgentContextBuilder.cs`.
- Directory organization pattern: Type/layer-oriented folders (`Contexts`, `Inputs`, `Validations`), with builder types in nested `Builders` directories and an enum in `Contexts/Definitions`.
- Import aliasing or path conventions: Source uses namespace imports and relative project compilation; no aliases or explicit public export/barrel mechanism were found.

## 5) Evidence

- `src/KamiYomu.ActionAgents.Core.sln`
- `src/KamiYomu.ActionAgents.Core/IActionAgent.cs`
- `src/KamiYomu.ActionAgents.Core/Contexts/Builders/ActionAgentContextBuilder.cs`
- `src/KamiYomu.ActionAgents.Core/Inputs/AbstractActionInputAttribute.cs`
- `src/KamiYomu.ActionAgents.Core/Validations/Builders/ActionAgentValidationResultBuilder.cs`
