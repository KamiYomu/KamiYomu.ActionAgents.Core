using KamiYomu.ActionAgents.Core.Contexts;
using KamiYomu.ActionAgents.Core.Contexts.Builders;
using KamiYomu.ActionAgents.Core.Contexts.Definitions;

namespace KamiYomu.ActionAgents.Core.Tests.Contexts;

public class ActionTriggerContextTests
{
    [Fact]
    public void Build_SetsTriggerSourceAndTime()
    {
        DateTimeOffset triggeredAt = new(2026, 8, 30, 18, 0, 0, TimeSpan.Zero);

        ActionTriggerContext context = ActionTriggerContextBuilder.Create()
            .WithSource(ActionTriggerSource.ChapterDownloader)
            .WithTriggeredAt(triggeredAt)
            .Build();

        Assert.Equal(ActionTriggerSource.ChapterDownloader, context.Source);
        Assert.Equal(triggeredAt, context.TriggeredAt);
    }

    [Fact]
    public void Create_WithExistingContext_ReturnsTheProvidedContext()
    {
        ActionTriggerContext existing = new();

        ActionTriggerContext built = ActionTriggerContextBuilder.Create(existing)
            .WithSource(ActionTriggerSource.Manual)
            .Build();

        Assert.Same(existing, built);
        Assert.Equal(ActionTriggerSource.Manual, existing.Source);
    }
}
