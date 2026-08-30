using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts;

public class MangaContextTests
{
    [Fact]
    public void Build_SetsAllMangaValues()
    {
        MangaContext context = MangaContextBuilder.Create()
            .WithId("manga-1")
            .WithTitle("Example Manga")
            .WithUrl("https://example.test/manga-1")
            .WithDownloadDirectory("C:\\downloads\\manga-1")
            .Build();

        Assert.Equal("manga-1", context.Id);
        Assert.Equal("Example Manga", context.Title);
        Assert.Equal("https://example.test/manga-1", context.Url);
        Assert.Equal("C:\\downloads\\manga-1", context.DownloadDirectory);
    }

    [Fact]
    public void Create_WithExistingContext_ReturnsTheProvidedContext()
    {
        MangaContext existing = new();

        MangaContext built = MangaContextBuilder.Create(existing)
            .WithTitle("Updated Manga")
            .Build();

        Assert.Same(existing, built);
        Assert.Equal("Updated Manga", existing.Title);
    }
}
