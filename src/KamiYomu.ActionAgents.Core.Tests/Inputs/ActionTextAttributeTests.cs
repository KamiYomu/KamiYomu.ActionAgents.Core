using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionTextAttributeTests
{
    [Fact]
    public void Constructor_SetsConfiguredTextMetadata()
    {
        ActionTextAttribute attribute = new("Endpoint", "Service endpoint", true, "https://example.test", 4);

        Assert.Equal("Endpoint", attribute.Name);
        Assert.Equal("Service endpoint", attribute.Legend);
        Assert.True(attribute.Required);
        Assert.Equal("https://example.test", attribute.DefaultValue);
        Assert.Equal((short)4, attribute.Order);
    }
}
