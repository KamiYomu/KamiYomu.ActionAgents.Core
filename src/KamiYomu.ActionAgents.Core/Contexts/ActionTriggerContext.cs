using KamiYomu.ActionAgents.Core.Contexts.Definitions;

namespace KamiYomu.ActionAgents.Core.Contexts;
/// <summary>
/// ActionTriggerContext encapsulates information about the source and timing of an action trigger within the KamiYomu framework. It provides details about the origin of the trigger and the exact time it occurred, facilitating context-aware processing of actions.
/// </summary>
public class ActionTriggerContext
{
    /// <summary>
    /// Source represents the origin of the action trigger.
    /// </summary>
    public ActionTriggerSource Source { get; internal set; }
    /// <summary>
    /// TriggeredAt indicates the exact time when the action trigger occurred.
    /// </summary>
    public DateTimeOffset TriggeredAt { get; internal set; } = DateTimeOffset.UtcNow;
}
