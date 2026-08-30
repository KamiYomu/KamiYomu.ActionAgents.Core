namespace KamiYomu.ActionAgents.Core.Inputs;

/// <summary>
/// Represents a configurable capability or toggleable option exposed by an agent class.
/// Each <see cref="ActionPasswordAttribute"/> defines a input-password type
/// that can influence the crawler's behavior, execution mode, or diagnostic output.
/// Multiple instances of this attribute may be applied to a single agent to describe its complete set of supported features.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
public class ActionPasswordAttribute : AbstractActionInputAttribute
{
    /// <inheritdoc/>
    public ActionPasswordAttribute(string name, string legend) : base(name, legend)
    {
    }
    /// <inheritdoc/>
    public ActionPasswordAttribute(string name, string legend, bool required, string defaultValue) : base(name, legend, required, defaultValue)
    {
    }
    /// <inheritdoc/>
    public ActionPasswordAttribute(string name, string legend, bool required, string defaultValue, short order) : base(name, legend, required, defaultValue, order)
    {
    }
}
