using System.Reflection;

using Microsoft.Extensions.Logging;

namespace KamiYomu.ActionAgents.Core;
/// <summary>
/// Abstract base class for action agents that provides common functionality and configuration options.
/// </summary>
public abstract partial class AbstractActionAgent
{
    /// <summary>
    /// Logger instance for the crawler.
    /// This constant is used as a key in the options dictionary to specify a custom logger for the crawler.
    /// </summary>
    private const string KamiYomuILogger = nameof(KamiYomuILogger);

    /// <summary>
    /// Options dictionary containing configuration settings for the crawler agent.
    /// </summary>
    protected readonly IDictionary<string, object> Options = new Dictionary<string, object>();
    /// <summary>
    /// Logger instance for the crawler agent. 
    /// This logger can be used for logging messages, errors, and diagnostics throughout the crawling process.
    /// </summary>
    protected readonly ILogger Logger;
    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractActionAgent"/> class with the specified options.
    /// </summary>
    /// <param name="options">A dictionary of options to configure the action agent.</param>
    protected AbstractActionAgent(IDictionary<string, object> options)
    {
        options ??= new Dictionary<string, object>();
        Options = options;

        if (Options.TryGetValue(KamiYomuILogger, out object? loggerObj))
        {
            Logger = loggerObj as ILogger;
        }
    }

    /// <summary>
    /// Gets the version of the assembly that contains the action core. 
    /// This can be useful for logging, diagnostics, or ensuring compatibility with other components.
    /// </summary>
    /// <returns>The version of the action core assembly.</returns>
    public Version GetActionCoreAssemblyVersion()
    {
        Assembly assembly = GetType().Assembly;
        return assembly.GetName().Version;
    }
    /// <summary>
    /// Gets the informational version of the assembly that contains the action core. 
    /// This can be useful for logging, diagnostics, or ensuring compatibility with other components.
    /// </summary>
    /// <returns>The informational version of the action core assembly.</returns>
    public string GetActionCoreInformationalVersion()
    {
        AssemblyInformationalVersionAttribute? attr = GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        return attr?.InformationalVersion ?? "unknown";
    }

}
