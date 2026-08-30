# Coding Conventions

## 1) Naming Rules

| Item | Rule | Example | Evidence |
|------|------|---------|----------|
| Files | PascalCase and normally match their public type. | `ChapterContextBuilder.cs` | `src/KamiYomu.ActionAgents.Core/Contexts/Builders/ChapterContextBuilder.cs` |
| Functions/methods | PascalCase; fluent configuration methods begin with `With`; factories use `Create`; materializers use `Build`. | `WithId`, `Create`, `Build` | `src/KamiYomu.ActionAgents.Core/Contexts/Builders/MangaContextBuilder.cs` |
| Types/interfaces | PascalCase; interfaces begin with `I`. | `IActionAgent`, `ActionAgentContext` | `src/.editorconfig`; `src/KamiYomu.ActionAgents.Core/IActionAgent.cs` |
| Constants/env vars | Private constants are PascalCase; no application environment variables are defined in source. | `KamiYomuILogger` | `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs` |

## 2) Formatting and Linting

- Formatter: EditorConfig specifies UTF-8, CRLF endings, final newlines, four-space indentation, and spaces rather than tabs. No separate formatter configuration was found.
- Linter: .NET EditorConfig analyzer settings, including style diagnostics set to errors. No separate lint command was found.
- Most relevant enforced rules: explicit types instead of `var`, file-scoped namespaces, braces, and separate `using` groups with system directives first.
- Run commands: [TODO] No dedicated formatting or linting command is defined. `dotnet build .\src\KamiYomu.ActionAgents.Core.sln --configuration Release` runs the project build used in CI.

## 3) Import and Module Conventions

- Import grouping/order: System namespaces are ordered first, and separate import directive groups are configured.
- Alias vs relative import policy: Namespace imports are used; no aliases are present in library source.
- Public exports/barrel policy: Every compiled C# file contributes types through its declared namespace; no barrel export pattern applies.

## 4) Error and Logging Conventions

- Error strategy by layer: Constructors and `ChapterContextBuilder.Build` use argument/invalid-operation exceptions for invalid required inputs. Interface implementations determine execution and validation errors.
- Logging style and required context fields: `AbstractActionAgent` accepts an optional non-generic `ILogger` from options key `KamiYomuILogger`; required log fields are [TODO] because the repository contains no concrete log calls.
- Sensitive-data redaction rules: [TODO] No redaction policy or implementation was found.

## 5) Testing Conventions

- Test file naming/location rule: Tests are PascalCase files with a `Tests` suffix in folders mirroring the production namespaces, such as `Contexts/Builders` and `Inputs`.
- Mocking strategy norm: Use Moq for framework-abstraction dependencies such as `ILogger`.
- Coverage expectation: coverlet collector is configured, but no threshold or CI coverage command is configured.

## 6) Evidence

- `src/.editorconfig`
- `src/KamiYomu.ActionAgents.Core/Contexts/Builders/MangaContextBuilder.cs`
- `src/KamiYomu.ActionAgents.Core/Inputs/AbstractActionInputAttribute.cs`
- `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs`
- `src/KamiYomu.ActionAgents.Core.Tests/ActionAgentTests.cs`
