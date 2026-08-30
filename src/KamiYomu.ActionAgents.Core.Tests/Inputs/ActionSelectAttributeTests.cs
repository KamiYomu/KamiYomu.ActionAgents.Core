using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionSelectAttributeTests
{
    [Fact]
    public void Constructor_SetsOptionsAndConfiguredMetadata()
    {
        ActionSelectAttribute attribute = new("Language", "Language", true, 3, ["en", "pt"]);

        Assert.Equal(["en", "pt"], attribute.Options);
        Assert.True(attribute.Required);
        Assert.Equal((short)3, attribute.Order);
    }

    [Fact]
    public void Constructor_RejectsAnEmptyOptionsArray()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ActionSelectAttribute("Language", "Language", []));

        Assert.Equal("options", exception.ParamName);
    }
}
