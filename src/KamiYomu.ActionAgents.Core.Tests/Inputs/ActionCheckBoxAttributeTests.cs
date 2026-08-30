using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionCheckBoxAttributeTests
{
    [Fact]
    public void Constructor_SetsOptionsAndConfiguredMetadata()
    {
        ActionCheckBoxAttribute attribute = new("Languages", "Languages", true, "en", 2, ["en", "pt"]);

        Assert.Equal(["en", "pt"], attribute.Options);
        Assert.True(attribute.Required);
        Assert.Equal("en", attribute.DefaultValue);
        Assert.Equal((short)2, attribute.Order);
    }

    [Fact]
    public void Constructor_RejectsAnEmptyOptionsArray()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new ActionCheckBoxAttribute("Languages", "Languages", []));

        Assert.Equal("options", exception.ParamName);
    }
}
