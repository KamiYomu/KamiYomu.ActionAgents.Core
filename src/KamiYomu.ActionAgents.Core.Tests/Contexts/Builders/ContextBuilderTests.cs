using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts.Builders;

public class ContextBuilderTests
{
    [Fact]
    public void ActionAgentContextBuilder_Create_ReturnsAContext()
    {
        ActionAgentContext context = ActionAgentContextBuilder.Create().Build();

        Assert.NotNull(context);
    }

    [Fact]
    public void ActionTriggerContextBuilder_Create_ReturnsAContext()
    {
        ActionTriggerContext context = ActionTriggerContextBuilder.Create().Build();

        Assert.NotNull(context);
    }

    [Fact]
    public void ChapterContextBuilder_Create_WithIdReturnsAContext()
    {
        ChapterContext context = ChapterContextBuilder.Create().WithId("chapter-1").Build();

        Assert.Equal("chapter-1", context.Id);
    }

    [Fact]
    public void CrawlerAgentContextBuilder_Create_ReturnsAContext()
    {
        CrawlerAgentContext context = CrawlerAgentContextBuilder.Create().Build();

        Assert.NotNull(context);
    }

    [Fact]
    public void MangaContextBuilder_Create_ReturnsAContext()
    {
        MangaContext context = MangaContextBuilder.Create().Build();

        Assert.NotNull(context);
    }
}
