using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class AbstractActionInputAttributeTests
{
    [Fact]
    public void Constructor_SetsDefaultInputMetadata()
    {
        TestInputAttribute attribute = new("Username", "User name");

        Assert.Equal("Username", attribute.Name);
        Assert.Equal("User name", attribute.Legend);
        Assert.Equal(string.Empty, attribute.DefaultValue);
        Assert.Equal((short)0, attribute.Order);
        Assert.False(attribute.Required);
        Assert.Equal("Order=0 | Name=\"Username\" | Legend=\"User name\" | Required=False | Type=\"TestInputAttribute\"", attribute.ToString());
    }

    [Fact]
    public void Constructor_RejectsAnEmptyName()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() => new TestInputAttribute(" ", "Legend"));

        Assert.Equal("name", exception.ParamName);
    }

    private sealed class TestInputAttribute(string name, string legend) : AbstractActionInputAttribute(name, legend)
    {
    }
}
