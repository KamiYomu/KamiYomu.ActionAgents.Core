namespace KamiYomu.ActionAgents.Core.Contexts.Builders;

/// <summary>
/// Builder class for constructing <see cref="ChapterContext"/> instances using the fluent builder pattern.
/// </summary>
/// <remarks>
/// This builder allows incremental construction of chapter context objects with validation to ensure required fields are set.
/// Use the static <see cref="Create()"/> or <see cref="Create(ChapterContext)"/> methods to initialize the builder.
/// </remarks>
public class ChapterContextBuilder
{
    private ChapterContext _context = new();

    private ChapterContextBuilder() { }

    /// <summary>
    /// Creates a new instance of the <see cref="ChapterContextBuilder"/> with an empty <see cref="ChapterContext"/>.
    /// </summary>
    /// <returns>A new builder instance ready for configuration.</returns>
    public static ChapterContextBuilder Create()
    {
        ChapterContextBuilder builder = new()
        {
            _context = new()
        };
        return builder;
    }
    /// <summary>
    /// Creates a new instance of the <see cref="ChapterContextBuilder"/> initialized with an existing <see cref="ChapterContext"/>.
    /// </summary>
    /// <param name="chapterContext">The chapter context to initialize the builder with.</param>
    /// <returns>A new builder instance initialized with the provided context.</returns>
    public static ChapterContextBuilder Create(ChapterContext chapterContext)
    {
        ChapterContextBuilder builder = new()
        {
            _context = chapterContext
        };
        return builder;
    }

    /// <summary>
    /// Sets the unique identifier for the chapter.
    /// </summary>
    /// <param name="id">The chapter's unique identifier.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public ChapterContextBuilder WithId(string id)
    {
        _context.Id = id;
        return this;
    }

    /// <summary>
    /// Sets the title of the chapter.
    /// </summary>
    /// <param name="title">The chapter's title, or null if not applicable.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public ChapterContextBuilder WithTitle(string? title)
    {
        _context.Title = title;
        return this;
    }

    /// <summary>
    /// Sets the URL where the chapter can be accessed or retrieved.
    /// </summary>
    /// <param name="url">The chapter's URL, or null if not applicable.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public ChapterContextBuilder WithUrl(string? url)
    {
        _context.Url = url;
        return this;
    }

    public ChapterContextBuilder WithCbzFilePath(string? cbzFilePath)
    {
        _context.CbzFilePath = cbzFilePath;
        return this;
    }

    public ChapterContextBuilder WithNumber(decimal? number)
    {
        _context.Number = number;
        return this;
    }

    public ChapterContextBuilder WithVolume(decimal? volume)
    {
        _context.Volume = volume;
        return this;
    }

    public ChapterContextBuilder WithReleaseDate(DateTime? releaseDate)
    {
        _context.ReleaseDate = releaseDate;
        return this;
    }
    public ChapterContextBuilder WithPageIndex(int? pageIndex)
    {
        _context.PageIndex = pageIndex;
        return this;
    }

    public ChapterContextBuilder WithPageCount(int? pageCount)
    {
        _context.PageCount = pageCount;
        return this;
    }

    public ChapterContext Build()
    {
        if (string.IsNullOrWhiteSpace(_context.Id))
        {
            throw new InvalidOperationException("Chapter Id is required.");
        }

        return _context;
    }
}
