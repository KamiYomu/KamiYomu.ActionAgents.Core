using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts;

public class CrawlerAgentContextTests
{
    [Fact]
    public void Build_SetsAllCrawlerAgentValues()
    {
        CrawlerAgentContext context = CrawlerAgentContextBuilder.Create()
            .WithDisplayName("Example Crawler")
            .WithType("Manga")
            .WithVersion("1.2.3")
            .WithAssemblyPath("C:\\agents\\example.dll")
            .Build();

        Assert.Equal("Example Crawler", context.DisplayName);
        Assert.Equal("Manga", context.Type);
        Assert.Equal("1.2.3", context.Version);
        Assert.Equal("C:\\agents\\example.dll", context.AssemblyPath);
    }
}
