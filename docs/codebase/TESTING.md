# Testing Patterns

## 1) Test Stack and Commands

- Primary test framework: xUnit `2.9.3`.
- Assertion/mocking tools: xUnit assertions, Moq `4.20.72`, and `Microsoft.NET.Test.Sdk` `18.9.0`; coverlet collector `10.0.1` is available for coverage collection.
- Commands:

```powershell
dotnet test .\src\KamiYomu.ActionAgents.Core.sln --configuration Release --no-build
dotnet test .\src\KamiYomu.ActionAgents.Core.Tests\KamiYomu.ActionAgents.Core.Tests.csproj --configuration Release
# [TODO] No separate unit, integration, E2E, or coverage command is configured.
```

## 2) Test Layout

- Test file placement pattern: `src/KamiYomu.ActionAgents.Core.Tests/` mirrors production folders, including `Contexts/`, `Contexts/Builders/`, `Inputs/`, `Validations/`, and `Validations/Builders/`.
- Naming convention: PascalCase files with a `Tests` suffix, such as `ActionAgentTests.cs`; test methods use `Method_Scenario_ExpectedBehavior`.
- Setup files and where they run: None found.

## 3) Test Scope Matrix

| Scope | Covered? | Typical target | Notes |
|-------|----------|----------------|-------|
| Unit | Yes | All public classes | Covers action-agent contracts, context models/builders, input attributes, and validation result construction. |
| Integration | No verified test source | Host/action-agent boundary | No integration test configuration or source was found. |
| E2E | No verified test source | Host-driven action workflow | This repository has no executable host or E2E configuration. |

## 4) Mocking and Isolation Strategy

- Main mocking approach: Moq mocks `ILogger`; its `Log` method is verified after action execution.
- Isolation guarantees: Each test creates its own test agent, option dictionaries, logger mock, context, and cancellation-token source.
- Common failure mode in tests: A concrete test agent is required to exercise the abstract base class and execution contract.

## 5) Coverage and Quality Signals

- Coverage tool + threshold: coverlet collector is configured; no threshold is defined.
- Current reported coverage: [TODO] No committed coverage report or CI coverage invocation was found.
- Known gaps/flaky areas: Public interfaces and the trigger enum have no direct test source; public-class coverage has been added.

## 6) Evidence

- `src/KamiYomu.ActionAgents.Core.Tests/KamiYomu.ActionAgents.Core.Tests.csproj`
- `src/KamiYomu.ActionAgents.Core.Tests/ActionAgentTests.cs`
- `src/KamiYomu.ActionAgents.Core.Tests/Contexts/Builders/ContextBuilderTests.cs`
- `src/KamiYomu.ActionAgents.Core.Tests/Inputs/ActionCheckBoxAttributeTests.cs`
- `src/KamiYomu.ActionAgents.Core.Tests/Validations/Builders/ActionAgentValidationResultBuilderTests.cs`
- `src/KamiYomu.ActionAgents.Core.sln`
- `.github/workflows/pull-request.yml`
- `azure-pipeline.yml`
