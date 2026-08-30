namespace KamiYomu.ActionAgents.Core.Contexts.Builders;
/// <summary>
/// ActionAgentContextBuilder is a builder class for constructing <see cref="ActionAgentContext"/> instances using the fluent builder pattern. It allows for step-by-step configuration of the context, enabling flexibility in setting various properties such as the KamiYomu base URI, temporary directory, trigger context, source context, manga context, and chapter context.
/// </summary>
public class ActionAgentContextBuilder
{
    private ActionAgentContext _context = new();
    /// <summary>
    /// Creates a new instance of the <see cref="ActionAgentContextBuilder"/> with an empty <see cref="ActionAgentContext"/>.
    /// </summary>
    /// <returns></returns>
    public static ActionAgentContextBuilder Create()
    {
        ActionAgentContextBuilder builder = new()
        {
            _context = new ActionAgentContext()
        };
        return builder;
    }
    /// <summary>
    /// Creates a new instance of the <see cref="ActionAgentContextBuilder"/> initialized with an existing <see cref="ActionAgentContext"/>.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ActionAgentContextBuilder Create(ActionAgentContext context)
    {
        ActionAgentContextBuilder builder = new()
        {
            _context = context
        };
        return builder;
    }

    public ActionAgentContextBuilder WithKamiYomuBaseUri(Uri kamiYomuBaseUri)
    {
        _context.KamiYomuBaseUri = kamiYomuBaseUri;
        return this;
    }

    public ActionAgentContextBuilder WithTempDirectory(string tempDirectory)
    {
        _context.TempDirectory = tempDirectory;
        return this;
    }

    public ActionAgentContextBuilder WithTrigger(ActionTriggerContext trigger)
    {
        _context.Trigger = trigger;
        return this;
    }

    public ActionAgentContextBuilder WithSource(CrawlerAgentContext? source)
    {
        _context.Source = source;
        return this;
    }

    public ActionAgentContextBuilder WithManga(MangaContext? manga)
    {
        _context.Manga = manga;
        return this;
    }

    public ActionAgentContextBuilder WithChapter(ChapterContext? chapter)
    {
        _context.Chapter = chapter;
        return this;
    }

    public ActionAgentContext Build()
    {
        return _context;
    }
}
