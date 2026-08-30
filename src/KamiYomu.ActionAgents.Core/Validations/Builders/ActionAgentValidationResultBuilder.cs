namespace KamiYomu.ActionAgents.Core.Validations.Builders;
public class ActionAgentValidationResultBuilder
{
    private ActionAgentValidationResult _result = new();

    public static ActionAgentValidationResultBuilder Create()
    {
        ActionAgentValidationResultBuilder builder = new()
        {
            _result = new()
        };
        return builder;
    }

    public static ActionAgentValidationResultBuilder Create(ActionAgentValidationResult result)
    {
        ActionAgentValidationResultBuilder builder = new()
        {
            _result = result
        };
        return builder;
    }

    public ActionAgentValidationResultBuilder Valid(string? message = null)
    {
        _result.IsValid = true;
        _result.Message = message;
        return this;
    }

    public ActionAgentValidationResultBuilder Invalid(string? message = null)
    {
        _result.IsValid = false;
        _result.Message = message;
        return this;
    }

    public ActionAgentValidationResultBuilder WithMessage(string? message)
    {
        _result.Message = message;
        return this;
    }

    public ActionAgentValidationResultBuilder WithData(
        IDictionary<string, object>? data)
    {
        _result.Data = data;
        return this;
    }

    public ActionAgentValidationResultBuilder AddData(
        string key,
        object value)
    {
        (_result.Data ??= new Dictionary<string, object>())[key] = value;
        return this;
    }

    public ActionAgentValidationResult Build()
    {
        return _result;
    }
}
