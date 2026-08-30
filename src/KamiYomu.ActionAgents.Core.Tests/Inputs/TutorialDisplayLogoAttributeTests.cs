using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class TutorialDisplayLogoAttributeTests
{
    [Fact]
    public void Constructor_SetsTutorialSteps()
    {
        TutorialDisplayLogoAttribute attribute = new("Open settings", "Enter API key");

        Assert.Equal(["Open settings", "Enter API key"], attribute.Steps);
    }

    [Fact]
    public void Constructor_RejectsEmptySteps()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new TutorialDisplayLogoAttribute([]));

        Assert.Equal("steps", exception.ParamName);
    }
}
