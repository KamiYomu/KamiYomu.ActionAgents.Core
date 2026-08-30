using KamiYomu.ActionAgents.Core.Contexts;

using Microsoft.Extensions.Logging;

using Moq;

namespace KamiYomu.ActionAgents.Core.Tests;

public class ActionAgentTests
{
    [Fact]
    public async Task ExecuteAsync_PassesSuppliedArgumentsToTheAction()
    {
        Mock<ILogger> logger = new();
        IDictionary<string, object> constructorOptions = new Dictionary<string, object>
        {
            ["KamiYomuILogger"] = logger.Object
        };
        IDictionary<string, object> executionOptions = new Dictionary<string, object>
        {
            ["configuration"] = "value"
        };
        using CancellationTokenSource cancellationTokenSource = new();
        ActionAgentContext context = new();
        TestActionAgent agent = new(constructorOptions);

        await agent.ExecuteAsync(context, executionOptions, cancellationTokenSource.Token);

        Assert.Same(context, agent.ReceivedContext);
        Assert.Same(executionOptions, agent.ReceivedOptions);
        Assert.Equal(cancellationTokenSource.Token, agent.ReceivedCancellationToken);
        logger.Verify(
            value => value.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, type) => state.ToString() == TestActionAgent.ExecutionMessage),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void Constructor_StoresAnEmptyOptionsDictionaryWhenOptionsAreNull()
    {
        TestActionAgent agent = new(null!);

        Assert.Empty(agent.ConstructorOptions);
        Assert.False(agent.HasLogger);
    }

    [Fact]
    public void Constructor_IgnoresAnOptionThatIsNotAnILogger()
    {
        IDictionary<string, object> options = new Dictionary<string, object>
        {
            ["KamiYomuILogger"] = "not a logger"
        };

        TestActionAgent agent = new(options);

        Assert.Same(options, agent.ConstructorOptions);
        Assert.False(agent.HasLogger);
    }

    [Fact]
    public void VersionMethods_ReturnValuesFromTheAgentAssembly()
    {
        TestActionAgent agent = new(new Dictionary<string, object>());

        Assert.Equal(typeof(TestActionAgent).Assembly.GetName().Version, agent.GetActionCoreAssemblyVersion());
        Assert.Equal(
            typeof(TestActionAgent).Assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyInformationalVersionAttribute), false)
                .Cast<System.Reflection.AssemblyInformationalVersionAttribute>()
                .SingleOrDefault()?.InformationalVersion ?? "unknown",
            agent.GetActionCoreInformationalVersion());
    }

    private sealed class TestActionAgent(IDictionary<string, object> options) : AbstractActionAgent(options), IActionAgent
    {
        internal const string ExecutionMessage = "Action executed";

        internal ActionAgentContext? ReceivedContext { get; private set; }

        internal IDictionary<string, object>? ReceivedOptions { get; private set; }

        internal CancellationToken ReceivedCancellationToken { get; private set; }

        internal IDictionary<string, object> ConstructorOptions => Options;

        internal bool HasLogger => Logger is not null;

        public Task ExecuteAsync(
            ActionAgentContext context,
            IDictionary<string, object> options,
            CancellationToken cancellationToken)
        {
            ReceivedContext = context;
            ReceivedOptions = options;
            ReceivedCancellationToken = cancellationToken;
            Logger?.LogInformation(ExecutionMessage);

            return Task.CompletedTask;
        }
    }
}
