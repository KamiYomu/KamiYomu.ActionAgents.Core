using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionTutorialAttributeTests
{
    [Fact]
    public void Constructor_SetsTutorialSteps()
    {
        ActionTutorialAttribute attribute = new("Open settings", "Enter API key");

        Assert.Equal(["Open settings", "Enter API key"], attribute.Steps);
    }

    [Fact]
    public void Constructor_RejectsEmptySteps()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ActionTutorialAttribute([]));

        Assert.Equal("steps", exception.ParamName);
    }
}
