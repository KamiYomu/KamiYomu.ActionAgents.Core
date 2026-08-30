namespace KamiYomu.ActionAgents.Core.Contexts;
/// <summary>
/// MangaContext encapsulates information about a manga, including its unique identifier, title, URL, and download directory. This context is used to provide relevant details about the manga within the KamiYomu framework, facilitating better understanding and management of manga-related operations.
/// </summary>
public class MangaContext
{
    /// <summary>
    /// Id represents the unique identifier of the manga.
    /// </summary>
    public string Id { get; internal set; } = default!;
    /// <summary>
    /// Title represents the title of the manga.
    /// </summary>
    public string? Title { get; internal set; }
    /// <summary>
    /// Url represents the URL where the manga can be accessed or retrieved.
    /// </summary>
    public string? Url { get; internal set; }
    /// <summary>
    /// DownloadDirectory represents the directory path where the manga's files are downloaded and stored. This property is nullable to account for cases where the download directory is not specified or applicable.
    /// </summary>
    public string? DownloadDirectory { get; internal set; }
}
