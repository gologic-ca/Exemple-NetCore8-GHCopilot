using Microsoft.AspNetCore.Mvc;
using Xunit;
using Conduit.Features.Hello;

namespace Conduit.IntegrationTests.Features.Hello;

public class HelloTests
{
    [Fact]
    public void Expect_Hello_World_Response()
    {
        var controller = new HelloController();
        var result = controller.Get() as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
        var value = result.Value;
        Assert.NotNull(value);
        
        // Verify the message property exists and has the correct value
        var json = System.Text.Json.JsonSerializer.Serialize(value);
        Assert.Contains("\"message\":\"Hello World\"", json);
    }
}
