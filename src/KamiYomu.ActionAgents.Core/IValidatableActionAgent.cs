using KamiYomu.ActionAgents.Core.Validations;

namespace KamiYomu.ActionAgents.Core;
/// <summary>
/// Validates the configuration of an action agent and ensures that it is ready to execute the configured action.
/// </summary>
public interface IValidatableActionAgent
{
    /// <summary>
    /// Validates the action agent configuration and verifies that it is ready
    /// to execute the configured action.
    /// </summary>
    /// <param name="options">
    /// The configuration options used by the action agent, such as credentials,
    /// connection settings, or other agent-specific configuration.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the validation operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous validation operation.
    /// The result indicates whether the configuration is valid and the action
    /// agent is ready to execute.
    /// </returns>
    Task<ActionAgentValidationResult> ValidateAsync(
        IDictionary<string, object> options,
        CancellationToken cancellationToken);
}
