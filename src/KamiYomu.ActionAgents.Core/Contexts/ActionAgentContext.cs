namespace KamiYomu.ActionAgents.Core.Contexts;
/// <summary>
/// ActionAgentContext serves as a comprehensive context container for action agents, encapsulating essential information such as the base URI for KamiYomu, temporary directory paths, trigger context, and optional source, manga, and chapter contexts. This class is designed to facilitate the execution of actions within the KamiYomu framework by providing a structured way to access relevant data and configurations.
/// </summary>
public class ActionAgentContext
{
    /// <summary>
    /// KamiYomuBaseUri represents the base URI for the KamiYomu platform, which is used as a reference point for constructing URLs and making requests within the action agent's operations.
    /// </summary>
    public Uri KamiYomuBaseUri { get; internal set; } = default!;
    /// <summary>
    /// TempDirectory specifies the path to a temporary directory used for storing intermediate files and data during the execution of action agent operations.
    /// </summary>
    public string TempDirectory { get; internal set; } = default!;
    /// <summary>
    /// Trigger represents the context of the action trigger that initiated the current action agent operation.
    /// </summary>
    public ActionTriggerContext Trigger { get; internal set; } = default!;
    /// <summary>
    /// Source represents the context of the crawler agent that provided the source data for the current action agent operation, if applicable.
    /// </summary>
    public CrawlerAgentContext? Source { get; internal set; }
    /// <summary>
    /// Manga represents the context of the manga associated with the current action agent operation, if applicable.
    /// </summary>
    public MangaContext? Manga { get; internal set; }
    /// <summary>
    /// Chapter represents the context of the chapter associated with the current action agent operation, if applicable.
    /// </summary>
    public ChapterContext? Chapter { get; internal set; }
}
