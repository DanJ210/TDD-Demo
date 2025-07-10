using TDD_Demo.Core;
using Xunit;

namespace TDD_Demo.Tests;

/// <summary>
/// TDD Example: String Calculator Tests
/// This demonstrates the Red-Green-Refactor cycle
/// Each test represents one small step in building the functionality
/// </summary>
public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    // 🔴 RED PHASE: Start with this failing test
    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = "";
        int expected = 0;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    // TODO: Uncomment tests one by one as you implement features
    // Follow the TDD cycle: Red -> Green -> Refactor

    [Fact]
    public void Add_SingleNumber_ReturnsThatNumber()
    {
        // Arrange
        string input = "1";
        int expected = 1;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        string input = "1,2";
        int expected = 3;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5", 15)]
    [InlineData("10,20,30", 60)]
    public void Add_MultipleNumbers_ReturnsSum(string input, int expected)
    {
        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_NumbersWithNewlines_ReturnsSum()
    {
        // Arrange
        string input = "1\n2,3";
        int expected = 6;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }
    /*

    [Fact]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        // Arrange
        string input = "//;\n1;2";
        int expected = 3;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_NegativeNumber_ThrowsException()
    {
        // Arrange
        string input = "1,-2,3";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));
        Assert.Contains("negatives not allowed", exception.Message);
        Assert.Contains("-2", exception.Message);
    }

    [Fact]
    public void Add_MultipleNegativeNumbers_ThrowsExceptionWithAllNegatives()
    {
        // Arrange
        string input = "1,-2,-3,4";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));
        Assert.Contains("negatives not allowed", exception.Message);
        Assert.Contains("-2", exception.Message);
        Assert.Contains("-3", exception.Message);
    }

    [Fact]
    public void Add_NumbersBiggerThan1000_AreIgnored()
    {
        // Arrange
        string input = "2,1001";
        int expected = 2; // 1001 should be ignored

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_CustomDelimiterAnyLength_ReturnsSum()
    {
        // Arrange
        string input = "//[***]\n1***2***3";
        int expected = 6;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_MultipleCustomDelimiters_ReturnsSum()
    {
        // Arrange
        string input = "//[*][%]\n1*2%3";
        int expected = 6;

        // Act
        int result = _calculator.Add(input);

        // Assert
        Assert.Equal(expected, result);
    }
    */
}
