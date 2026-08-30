using KamiYomu.ActionAgents.Core.Inputs;

namespace KamiYomu.ActionAgents.Core.Tests.Inputs;

public class ActionDisplayLogoAttributeTests
{
    [Fact]
    public void Constructor_WithLegend_SetsLogoMetadata()
    {
        ActionDisplayLogoAttribute attribute = new("https://example.test/logo.png", "Example logo");

        Assert.Equal("https://example.test/logo.png", attribute.LogoUrl);
        Assert.Equal("Example logo", attribute.Legend);
    }

    [Fact]
    public void Constructor_RejectsAnEmptyLogoUrl()
    {
        Assert.Throws<ArgumentException>(() => new ActionDisplayLogoAttribute(" "));
    }
}
