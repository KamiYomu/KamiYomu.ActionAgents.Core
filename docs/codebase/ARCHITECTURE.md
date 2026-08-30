# Architecture

## 1) Architectural Style

- Primary style: Contract-and-model class library.
- Why this classification: The library defines action execution and validation interfaces, context/result data models, builder helpers, and metadata attributes. It does not include an executable host, event dispatcher, persistence layer, or integration client.
- Primary constraints:
  - Action behavior is implemented by consumers through `IActionAgent.ExecuteAsync`.
  - Context properties use `internal set`, so construction is intended through library builders or assembly-internal code.
  - Logging is optional and supplied through an object options dictionary under the `KamiYomuILogger` key.

## 2) System Flow

```text
KamiYomu host event -> ActionTriggerContext and optional source/manga/chapter data
-> context builders -> ActionAgentContext -> consumer IActionAgent.ExecuteAsync
-> consumer-owned action behavior -> caller-owned completion/error handling
```

1. A host identifies an event origin with `ActionTriggerSource`, including manual, chained, manga, chapter, and page-read triggers.
2. The host or consumer constructs trigger, manga, chapter, crawler, and aggregate context objects through the fluent `Create`, `With...`, and `Build` methods.
3. The host passes the aggregate `ActionAgentContext`, agent-specific options, and a cancellation token to `IActionAgent.ExecuteAsync`.
4. A consumer can derive from `AbstractActionAgent` to retain its options and obtain an optional `ILogger`.
5. Consumers that support preflight checks return `ActionAgentValidationResult` from `IValidatableActionAgent.ValidateAsync`; the caller decides how to use the result.

## 3) Layer/Module Responsibilities

| Layer or module | Owns | Must not own | Evidence |
|-----------------|------|--------------|----------|
| `IActionAgent` | The asynchronous execution contract. | An execution implementation. | `src/KamiYomu.ActionAgents.Core/IActionAgent.cs` |
| `IValidatableActionAgent` | The optional asynchronous validation contract. | A specific agent's validation rules. | `src/KamiYomu.ActionAgents.Core/IValidatableActionAgent.cs` |
| `AbstractActionAgent` | Reusable options storage, optional logging, and assembly-version access. | Dispatching events or executing actions. | `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs` |
| `Contexts` | Describing the current host, trigger, manga, and chapter. | Fetching or persisting those entities. | `src/KamiYomu.ActionAgents.Core/Contexts/ActionAgentContext.cs` |
| `Inputs` | Annotation metadata that describes configuration controls. | UI rendering and configuration persistence. | `src/KamiYomu.ActionAgents.Core/Inputs/AbstractActionInputAttribute.cs` |
| `Validations` | Transporting validation status, message, and data. | Executing validation policy. | `src/KamiYomu.ActionAgents.Core/Validations/ActionAgentValidationResult.cs` |

## 4) Reused Patterns

| Pattern | Where found | Why it exists |
|---------|-------------|---------------|
| Fluent builder | `Contexts/Builders/*.cs`; `Validations/Builders/ActionAgentValidationResultBuilder.cs` | Constructs objects whose public properties have `internal set` and supports chained setup. |
| Interface-based extension point | `IActionAgent.cs`; `IValidatableActionAgent.cs` | Lets external agent packages supply execution and optional validation logic. |
| Attribute metadata | `Inputs/*.cs` | Lets an action class or assembly declare input and presentation metadata declaratively. |
| Abstract base class | `AbstractActionAgent.cs` | Reuses option, logger, and assembly-version behavior for agent implementations. |

## 5) Known Architectural Risks

- Builders generally return their current mutable context instance rather than a copy. Reusing a builder or calling `Create(existingContext)` can mutate an instance shared with other code.
- Only `ChapterContextBuilder.Build` checks a required identifier. `MangaContextBuilder` and `ActionAgentContextBuilder` can return objects whose non-nullable members remain their `default!` value.
- The `IDictionary<string, object>` options boundary is untyped; incorrect keys or value types are detected only by consumer code, and an invalid logger silently becomes `null`.

## 6) Evidence

- `src/KamiYomu.ActionAgents.Core/IActionAgent.cs`
- `src/KamiYomu.ActionAgents.Core/AbstractActionAgent.cs`
- `src/KamiYomu.ActionAgents.Core/Contexts/ActionAgentContext.cs`
- `src/KamiYomu.ActionAgents.Core/Contexts/Builders/ActionAgentContextBuilder.cs`
- `src/KamiYomu.ActionAgents.Core/Validations/Builders/ActionAgentValidationResultBuilder.cs`
