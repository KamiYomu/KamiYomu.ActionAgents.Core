namespace KamiYomu.ActionAgents.Core.Inputs;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
public class TutorialDisplayLogoAttribute : Attribute
{
    public TutorialDisplayLogoAttribute(params string[] steps)
    {
        if (steps == null || steps.Length == 0)
        {
            throw new ArgumentException("Steps cannot be null or empty.", nameof(steps));
        }
        Steps = steps;
    }

    public string[] Steps { get; }
}
