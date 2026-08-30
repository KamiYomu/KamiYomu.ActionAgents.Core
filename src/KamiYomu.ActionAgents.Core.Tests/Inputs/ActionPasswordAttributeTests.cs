using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionPasswordAttributeTests
{
    [Fact]
    public void Constructor_SetsConfiguredPasswordMetadata()
    {
        ActionPasswordAttribute attribute = new("ApiKey", "API key", true, "default", 1);

        Assert.Equal("ApiKey", attribute.Name);
        Assert.Equal("API key", attribute.Legend);
        Assert.True(attribute.Required);
        Assert.Equal("default", attribute.DefaultValue);
        Assert.Equal((short)1, attribute.Order);
    }
}
