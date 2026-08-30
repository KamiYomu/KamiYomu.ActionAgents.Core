using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;
using KamiYomu.ActionAgents.Core.Contexts.Definitions;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts;

public class ActionAgentContextTests
{
    [Fact]
    public void Build_SetsAllContextValues()
    {
        Uri baseUri = new("https://kamiyomu.example");
        ActionTriggerContext trigger = ActionTriggerContextBuilder.Create()
            .WithSource(ActionTriggerSource.Manual)
            .Build();
        CrawlerAgentContext source = CrawlerAgentContextBuilder.Create().WithDisplayName("Crawler").Build();
        MangaContext manga = MangaContextBuilder.Create().WithId("manga-1").Build();
        ChapterContext chapter = ChapterContextBuilder.Create().WithId("chapter-1").Build();

        ActionAgentContext context = ActionAgentContextBuilder.Create()
            .WithKamiYomuBaseUri(baseUri)
            .WithTempDirectory("C:\\temp")
            .WithTrigger(trigger)
            .WithSource(source)
            .WithManga(manga)
            .WithChapter(chapter)
            .Build();

        Assert.Equal(baseUri, context.KamiYomuBaseUri);
        Assert.Equal("C:\\temp", context.TempDirectory);
        Assert.Same(trigger, context.Trigger);
        Assert.Same(source, context.Source);
        Assert.Same(manga, context.Manga);
        Assert.Same(chapter, context.Chapter);
    }

    [Fact]
    public void Create_WithExistingContext_ReturnsAndUpdatesThatContext()
    {
        ActionAgentContext existing = new();

        ActionAgentContext built = ActionAgentContextBuilder.Create(existing)
            .WithTempDirectory("C:\\updated")
            .Build();

        Assert.Same(existing, built);
        Assert.Equal("C:\\updated", existing.TempDirectory);
    }
}
