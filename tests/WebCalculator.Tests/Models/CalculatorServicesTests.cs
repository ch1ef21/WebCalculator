using WebCalculator.Models;
using Xunit;

public class CalculatorServiceTests
{
    private readonly CalculatorService _calculator = new();

    [Theory]
    [InlineData(5, 3, "add", 8)]
    [InlineData(10, 4, "subtract", 6)]
    [InlineData(3, 4, "multiply", 12)]
    [InlineData(10, 2, "divide", 5)]
    [InlineData(2, 3, "power", 8)]
    public void Calculate_ValidOperations_ReturnsCorrectResult(double a, double b, string op, double expected)
    {
        // Act
        var result = _calculator.Calculate(a, b, op);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_DivideByZero_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<DivideByZeroException>(() =>
            _calculator.Calculate(10, 0, "divide"));
    }

    [Fact]
    public void Calculate_InvalidOperation_ThrowsException()
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            _calculator.Calculate(10, 5, "invalid"));

        Assert.Contains("Неизвестная операция", ex.Message);
    }
}