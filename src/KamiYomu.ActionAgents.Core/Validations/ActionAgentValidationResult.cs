namespace KamiYomu.ActionAgents.Core.Validations;
public sealed class ActionAgentValidationResult
{
    public bool IsValid { get; internal set; }

    public string? Message { get; internal set; }

    public IDictionary<string, object>? Data { get; internal set; } = new Dictionary<string, object>();
}
