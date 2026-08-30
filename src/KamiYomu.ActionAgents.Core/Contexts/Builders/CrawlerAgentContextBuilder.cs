namespace KamiYomu.ActionAgents.Core.Contexts.Builders;
/// <summary>
/// CrawlerAgentContextBuilder is a builder class for constructing <see cref="CrawlerAgentContext"/> instances using the fluent builder pattern. It allows for step-by-step configuration of the context, including setting properties such as display name, type, version, and assembly path. Use the static <see cref="Create()"/> or <see cref="Create(CrawlerAgentContext)"/> methods to initialize the builder.
/// </summary>
public class CrawlerAgentContextBuilder
{
    private CrawlerAgentContext _context = new();
    private CrawlerAgentContextBuilder() { }
    /// <summary>
    /// Creates a new instance of the <see cref="CrawlerAgentContextBuilder"/> with an empty <see cref="CrawlerAgentContext"/>.
    /// </summary>
    /// <returns></returns>
    public static CrawlerAgentContextBuilder Create()
    {
        CrawlerAgentContextBuilder builder = new()
        {
            _context = new()
        };
        return builder;
    }
    /// <summary>
    /// Creates a new instance of the <see cref="CrawlerAgentContextBuilder"/> initialized with an existing <see cref="CrawlerAgentContext"/>.
    /// </summary>
    /// <param name="crawlerAgentContext">The existing <see cref="CrawlerAgentContext"/> to initialize the builder with.</param>
    /// <returns>A new instance of the <see cref="CrawlerAgentContextBuilder"/>.</returns>
    public static CrawlerAgentContextBuilder Create(CrawlerAgentContext crawlerAgentContext)
    {
        CrawlerAgentContextBuilder builder = new()
        {
            _context = crawlerAgentContext
        };
        return builder;
    }

    public CrawlerAgentContextBuilder WithDisplayName(string? displayName)
    {
        _context.DisplayName = displayName;
        return this;
    }

    public CrawlerAgentContextBuilder WithType(string? type)
    {
        _context.Type = type;
        return this;
    }

    public CrawlerAgentContextBuilder WithVersion(string? version)
    {
        _context.Version = version;
        return this;
    }

    public CrawlerAgentContextBuilder WithAssemblyPath(string? assemblyPath)
    {
        _context.AssemblyPath = assemblyPath;
        return this;
    }

    public CrawlerAgentContext Build()
    {
        return _context;
    }
}
