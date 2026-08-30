using KamiYomu.ActionAgents.Core.Contexts.Definitions;

namespace KamiYomu.ActionAgents.Core.Contexts.Builders;
/// <summary>
/// ActionTriggerContextBuilder is a builder class for constructing <see cref="ActionTriggerContext"/> instances using the fluent builder pattern. It allows for step-by-step configuration of the context, including setting the source and the time of the trigger. Use the static <see cref="Create()"/> or <see cref="Create(ActionTriggerContext)"/> methods to initialize the builder.
/// </summary>
public class ActionTriggerContextBuilder
{
    private ActionTriggerContext _context = new();
    private ActionTriggerContextBuilder() { }
    /// <summary>
    /// Creates a new instance of the <see cref="ActionTriggerContextBuilder"/> with an empty <see cref="ActionTriggerContext"/>.
    /// </summary>
    /// <returns></returns>
    public static ActionTriggerContextBuilder Create()
    {
        ActionTriggerContextBuilder builder = new()
        {
            _context = new ActionTriggerContext()
        };
        return builder;
    }
    /// <summary>
    /// Creates a new instance of the <see cref="ActionTriggerContextBuilder"/> initialized with an existing <see cref="ActionTriggerContext"/>.
    /// </summary>
    /// <param name="context">The existing <see cref="ActionTriggerContext"/> to initialize the builder with.</param>
    /// <returns>A new instance of the <see cref="ActionTriggerContextBuilder"/>.</returns>
    public static ActionTriggerContextBuilder Create(ActionTriggerContext context)
    {
        ActionTriggerContextBuilder builder = new()
        {
            _context = context
        };
        return builder;
    }

    public ActionTriggerContextBuilder WithSource(ActionTriggerSource source)
    {
        _context.Source = source;
        return this;
    }

    public ActionTriggerContextBuilder WithTriggeredAt(DateTimeOffset triggeredAt)
    {
        _context.TriggeredAt = triggeredAt;
        return this;
    }

    public ActionTriggerContext Build()
    {
        return _context;
    }
}
