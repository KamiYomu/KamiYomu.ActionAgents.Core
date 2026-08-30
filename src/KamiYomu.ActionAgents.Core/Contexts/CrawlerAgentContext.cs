namespace KamiYomu.ActionAgents.Core.Contexts;
/// <summary>
/// CrawlerAgentContext encapsulates information about a crawler agent, including its display name, type, version, and assembly path. This context is used to provide relevant details about the crawler agent within the KamiYomu framework, facilitating better understanding and management of crawler operations.
/// </summary>
public class CrawlerAgentContext
{
    /// <summary>
    /// DisplayName represents the human-readable name of the crawler agent, which can be used for identification and logging purposes.
    /// </summary>
    public string? DisplayName { get; internal set; }
    /// <summary>
    /// Type represents the specific type or category of the crawler agent, which can be used to differentiate between different kinds of crawlers within the system.
    /// </summary>
    public string? Type { get; internal set; }
    /// <summary>
    /// Version represents the version of the crawler agent, which can be used to track updates and ensure compatibility within the system.
    /// </summary>
    public string? Version { get; internal set; }
    /// <summary>
    /// AssemblyPath represents the file path to the assembly where the crawler agent is implemented, which can be used for loading and managing the agent within the system.
    /// </summary>
    public string? AssemblyPath { get; internal set; }
}
