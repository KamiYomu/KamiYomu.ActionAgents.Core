using KamiYomu.ActionAgents.Core.Contexts;

namespace KamiYomu.ActionAgents.Core;
/// <summary>
/// Action agents are modular components that encapsulate specific behaviors or tasks within the system.
/// They can be invoked to perform actions based on the provided context and options.
/// </summary>
public interface IActionAgent
{
    /// <summary>
    /// Executes the action agent's behavior based on the provided context and options.
    /// </summary>
    /// <param name="context">The context in which the action agent is executed.</param>
    /// <param name="options">A dictionary of options that can influence the action agent's behavior.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExecuteAsync(ActionAgentContext context, IDictionary<string, object> options, CancellationToken cancellationToken);
}
