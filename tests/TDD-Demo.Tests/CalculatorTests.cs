using TDD_Demo.Core;
using Xunit;

namespace TDD_Demo.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;
        int expected = 8;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_PositiveAndNegativeNumber_ReturnsCorrectSum()
    {
        // Arrange
        int a = 10;
        int b = -3;
        int expected = 7;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(100, 50, 150)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 3;
        int expected = 7;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 4;
        int b = 5;
        int expected = 20;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        // Arrange
        int a = 10;
        int b = 0;
        int expected = 0;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 10;
        int b = 2;
        double expected = 5.0;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(expected, result, 2); // 2 decimal places precision
    }

    [Fact]
    public void Divide_WithRemainder_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 10;
        int b = 3;
        double expected = 3.333333333333333;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(expected, result, 10); // 10 decimal places precision
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void Divide_ByZero_ThrowsExceptionWithCorrectMessage()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        var exception = Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        Assert.Equal("Cannot divide by zero", exception.Message);
    }
}
