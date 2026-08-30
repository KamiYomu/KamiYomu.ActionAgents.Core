using KamiYomu.ActionAgents.Core.Validations;
using KamiYomu.ActionAgents.Core.Validations.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Validations.Builders;

public class ActionAgentValidationResultBuilderTests
{
    [Fact]
    public void AddData_CreatesDataWhenTheResultDataIsNull()
    {
        ActionAgentValidationResult result = new();

        ActionAgentValidationResult built = ActionAgentValidationResultBuilder.Create(result)
            .Invalid("Unavailable")
            .WithData(null)
            .AddData("reason", "network")
            .Build();

        Assert.Same(result, built);
        Assert.False(built.IsValid);
        Assert.Equal("Unavailable", built.Message);
        Assert.NotNull(built.Data);
        Assert.Equal("network", built.Data["reason"]);
    }
}
