namespace KamiYomu.ActionAgents.Core.Contexts.Builders;

/// <summary>
/// Builder class for constructing <see cref="MangaContext"/> instances using the fluent builder pattern.
/// </summary>
/// <remarks>
/// This builder enables step-by-step construction of manga context objects with configuration flexibility.
/// Use the static <see cref="Create()"/> or <see cref="Create(MangaContext)"/> methods to initialize the builder.
/// </remarks>
public class MangaContextBuilder
{
    private MangaContext _context = new();

    private MangaContextBuilder() { }

    /// <summary>
    /// Creates a new instance of the <see cref="MangaContextBuilder"/> with an empty <see cref="MangaContext"/>.
    /// </summary>
    /// <returns>A new builder instance ready for configuration.</returns>
    public static MangaContextBuilder Create()
    {
        MangaContextBuilder builder = new()
        {
            _context = new()
        };
        return builder;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="MangaContextBuilder"/> initialized with an existing <see cref="MangaContext"/>.
    /// </summary>
    /// <param name="context">The manga context to initialize the builder with.</param>
    /// <returns>A new builder instance initialized with the provided context.</returns>
    public static MangaContextBuilder Create(MangaContext context)
    {
        MangaContextBuilder builder = new()
        {
            _context = context
        };
        return builder;
    }

    /// <summary>
    /// Sets the unique identifier for the manga.
    /// </summary>
    /// <param name="id">The manga's unique identifier.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public MangaContextBuilder WithId(string id)
    {
        _context.Id = id;
        return this;
    }

    /// <summary>
    /// Sets the title of the manga.
    /// </summary>
    /// <param name="title">The manga's title, or null if not applicable.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public MangaContextBuilder WithTitle(string? title)
    {
        _context.Title = title;
        return this;
    }

    /// <summary>
    /// Sets the URL where the manga can be accessed or retrieved.
    /// </summary>
    /// <param name="url">The manga's URL, or null if not applicable.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public MangaContextBuilder WithUrl(string? url)
    {
        _context.Url = url;
        return this;
    }

    /// <summary>
    /// Sets the directory path where manga content will be downloaded or stored.
    /// </summary>
    /// <param name="downloadDirectory">The download directory path, or null if not applicable.</param>
    /// <returns>The current builder instance for method chaining.</returns>
    public MangaContextBuilder WithDownloadDirectory(string? downloadDirectory)
    {
        _context.DownloadDirectory = downloadDirectory;
        return this;
    }

    /// <summary>
    /// Builds and returns the <see cref="MangaContext"/> instance.
    /// </summary>
    /// <returns>A fully configured <see cref="MangaContext"/> instance.</returns>
    public MangaContext Build()
    {
        return _context;
    }
}
