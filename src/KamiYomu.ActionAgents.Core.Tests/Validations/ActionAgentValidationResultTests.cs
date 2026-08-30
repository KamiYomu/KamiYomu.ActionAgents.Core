using KamiYomu.ActionAgents.Core.Validations;
using KamiYomu.ActionAgents.Core.Validations.Builders;

namespace KamiYomu.ActionAgents.Core.Tests.Validations;

public class ActionAgentValidationResultTests
{
    [Fact]
    public void Build_ValidResultSetsMessageAndData()
    {
        IDictionary<string, object> data = new Dictionary<string, object>
        {
            ["endpoint"] = "https://example.test"
        };

        ActionAgentValidationResult result = ActionAgentValidationResultBuilder.Create()
            .Valid("Ready")
            .WithData(data)
            .Build();

        Assert.True(result.IsValid);
        Assert.Equal("Ready", result.Message);
        Assert.Same(data, result.Data);
    }
}
