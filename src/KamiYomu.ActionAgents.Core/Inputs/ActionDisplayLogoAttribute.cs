namespace KamiYomu.ActionAgents.Core.Inputs;
/// <summary>
/// Displays a logo for the action in the GitHub Actions UI.
/// This attribute can be applied to an assembly to specify a logo URL and an optional legend for the action.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
public class ActionDisplayLogoAttribute : Attribute
{
    public ActionDisplayLogoAttribute(string logoUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(logoUrl, nameof(logoUrl));
        LogoUrl = logoUrl;
    }

    public ActionDisplayLogoAttribute(string logoUrl, string legend)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(logoUrl, nameof(logoUrl));
        ArgumentException.ThrowIfNullOrWhiteSpace(legend, nameof(legend));
        LogoUrl = logoUrl;
        Legend = legend;
    }

    public string LogoUrl { get; }
    public string Legend { get; }
}
