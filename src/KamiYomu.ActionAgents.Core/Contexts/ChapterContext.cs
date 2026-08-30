namespace KamiYomu.ActionAgents.Core.Contexts;
/// <summary>
/// ChapterContext encapsulates information about a specific chapter within a manga, including its unique identifier, title, URL, file path for the CBZ file, chapter number, volume number, release date, and pagination details. This context is used to provide relevant data for actions related to manga chapters within the KamiYomu framework.
/// </summary>
public class ChapterContext
{
    /// <summary>
    /// Id represents the unique identifier of the chapter.
    /// </summary>
    public string Id { get; internal set; } = default!;
    /// <summary>
    /// Title represents the title of the chapter.
    /// </summary>
    public string? Title { get; internal set; }
    /// <summary>
    /// Url represents the URL where the chapter can be accessed or retrieved.
    /// </summary>
    public string? Url { get; internal set; }
    /// <summary>
    /// CbzFilePath represents the file path to the CBZ file associated with the chapter, if applicable.
    /// </summary>
    public string? CbzFilePath { get; internal set; }
    /// <summary>
    /// Number represents the chapter number, which may be a decimal to accommodate special chapters or side stories.
    /// </summary>
    public decimal? Number { get; internal set; }
    /// <summary>
    /// Volume represents the volume number associated with the chapter, which may be a decimal to accommodate special volumes or editions.
    /// </summary>
    public decimal? Volume { get; internal set; }
    /// <summary>
    /// ReleaseDate represents the date when the chapter was released, if known. This property is nullable to account for cases where the release date is not available.
    /// </summary>
    public DateTime? ReleaseDate { get; internal set; }
    /// <summary>
    /// PageIndex represents the index of the page within the chapter, if applicable. 
    /// This property is nullable to account for cases where pagination information is not available.
    /// Can be filled when the user is reading a chapter and the page index is known, or when the chapter is being processed and the page index is relevant.
    /// </summary>
    public int? PageIndex { get; internal set; }
    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    /// <remarks>Returns null if the page count is not specified.</remarks>
    public int? PageCount { get; internal set; }
}
