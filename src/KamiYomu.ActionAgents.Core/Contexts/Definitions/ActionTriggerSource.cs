namespace KamiYomu.ActionAgents.Core.Contexts.Definitions;
/// <summary>
/// ActionTriggerSource enumerates the possible origins of an action trigger within the KamiYomu framework. It helps identify whether an action was initiated manually by a user or automatically by various components of the system, such as the manga downloader, chapter discovery, chapter downloader, or chapter page read events.
/// </summary>
public enum ActionTriggerSource
{
    /// <summary>
    /// None indicates that the action trigger source is unspecified or unknown.
    /// </summary>
    None = 0,
    /// <summary>
    /// Manual indicates that the action was triggered manually by a user, rather than automatically by the system.
    /// </summary>
    Manual = 1,
    /// <summary>
    /// Chained indicates that the action was triggered as part of a chain of actions,
    /// where one action led to the initiation of another.
    /// </summary>
    Chained = 2,
    /// <summary>
    /// MangaDownloader indicates that the action was triggered automatically by the manga downloader component.
    /// </summary>
    MangaDownloader = 3,
    /// <summary>
    /// ChapterDiscovery indicates that the action was triggered automatically by the chapter discovery component.
    /// </summary>
    ChapterDiscovery = 4,
    /// <summary>
    /// ChapterDownloader indicates that the action was triggered automatically by the chapter downloader component.
    /// </summary>
    ChapterDownloader = 5,
    /// <summary>
    /// ChapterPageRead indicates that the action was triggered automatically by the chapter page read component.
    /// </summary>
    ChapterPageRead = 6,
}
