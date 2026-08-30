using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts;

public class ChapterContextTests
{
    [Fact]
    public void Build_SetsAllChapterValues()
    {
        DateTime releaseDate = new(2026, 8, 30);

        ChapterContext context = ChapterContextBuilder.Create()
            .WithId("chapter-1")
            .WithTitle("Chapter One")
            .WithUrl("https://example.test/chapter-1")
            .WithCbzFilePath("C:\\downloads\\chapter-1.cbz")
            .WithNumber(1.5m)
            .WithVolume(2m)
            .WithReleaseDate(releaseDate)
            .WithPageIndex(3)
            .WithPageCount(20)
            .Build();

        Assert.Equal("chapter-1", context.Id);
        Assert.Equal("Chapter One", context.Title);
        Assert.Equal("https://example.test/chapter-1", context.Url);
        Assert.Equal("C:\\downloads\\chapter-1.cbz", context.CbzFilePath);
        Assert.Equal(1.5m, context.Number);
        Assert.Equal(2m, context.Volume);
        Assert.Equal(releaseDate, context.ReleaseDate);
        Assert.Equal(3, context.PageIndex);
        Assert.Equal(20, context.PageCount);
    }

    [Fact]
    public void Build_WithoutAnId_ThrowsInvalidOperationException()
    {
        ChapterContextBuilder builder = ChapterContextBuilder.Create();

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(builder.Build);

        Assert.Equal("Chapter Id is required.", exception.Message);
    }
}
