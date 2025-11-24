using Microsoft.AspNetCore.Mvc;
using WebCalculator.Controllers;
using WebCalculator.Models;
using Xunit;

public class CalculatorControllerTests
{
    private readonly CalculatorController _controller = new();

    [Fact]
    public void Calculate_ValidRequest_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new CalculatorRequest
        {
            Number1 = 10,
            Number2 = 5,
            Operation = "add"
        };

        // Act
        var result = _controller.Calculate(request);

        // Assert
        var okResult = Assert.IsType<ActionResult<CalculatorResponse>>(result);
        var response = Assert.IsType<OkObjectResult>(okResult.Result).Value as CalculatorResponse;

        Assert.NotNull(response);
        Assert.True(response.Success);
        Assert.Equal(15, response.Result);
        Assert.Equal(200, ((OkObjectResult)okResult.Result!).StatusCode);
    }

    [Fact]
    public void GetAvailableOperations_ReturnsListOfOperations()
    {
        // Act
        var result = _controller.GetAvailableOperations();

        // Assert
        var okResult = Assert.IsType<ActionResult<List<string>>>(result);
        var operations = Assert.IsType<OkObjectResult>(okResult.Result).Value as List<string>;

        Assert.NotNull(operations);
        Assert.Equal(5, operations.Count);
        Assert.Contains("add", operations);
        Assert.Contains("subtract", operations);
        Assert.Contains("multiply", operations);
        Assert.Contains("divide", operations);
        Assert.Contains("power", operations);
    }
}