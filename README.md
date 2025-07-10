# TDD-Demo .NET Core Application

This is a demonstration .NET Core application showcasing Test-Driven Development (TDD) practices using XUnit and Moq.

## Project Structure

```
TDD-Demo/
├── src/
│   └── TDD-Demo.Core/
│       ├── Calculator.cs          # Simple calculator with basic operations
│       ├── StringCalculator.cs    # TDD Kata example (String Calculator)
│       ├── DataService.cs         # Service class demonstrating dependency injection
│       └── IDataRepository.cs     # Interface for data access
├── tests/
│   └── TDD-Demo.Tests/
│       ├── CalculatorTests.cs     # Unit tests for Calculator
│       ├── StringCalculatorTests.cs # TDD Kata tests (step-by-step example)
│       └── DataServiceTests.cs    # Unit tests for DataService using Moq
├── TestList.md                    # TDD test planning document
├── TDD-Workflow-Guide.md         # Step-by-step TDD process guide
├── run-tdd-tests.ps1             # Helper script for running TDD tests
└── TDD-Demo.sln
```

## Features

### Calculator Class
- Basic arithmetic operations (Add, Subtract, Multiply, Divide)
- Proper exception handling for division by zero
- Comprehensive unit tests with various test scenarios

### StringCalculator Class (TDD Kata)
- **Purpose**: Demonstrates the complete TDD Red-Green-Refactor cycle
- **Features**: String parsing, custom delimiters, error handling
- **Learning**: Step-by-step TDD process with guided test list

**TDD Files for Team Learning:**
- `TestList.md` - Test planning and progress tracking
- `TDD-Workflow-Guide.md` - Step-by-step TDD process
- `StringCalculatorTests.cs` - Commented tests to uncomment one by one
- `run-tdd-tests.ps1` - Helper script for running specific tests

### DataService Class
- Demonstrates dependency injection pattern
- Uses IDataRepository and ILogger interfaces
- Includes comprehensive error handling and logging
- Unit tests use Moq to mock dependencies

## Technologies Used

- **.NET 9.0**: Latest .NET framework
- **XUnit**: Testing framework for .NET
- **Moq**: Mocking framework for creating test doubles
- **Coverlet**: Code coverage collector

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

### Building the Solution
```powershell
dotnet restore
dotnet build
```

### Running Tests
```powershell
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Running Specific Test Classes
```powershell
# Run only Calculator tests
dotnet test --filter "FullyQualifiedName~CalculatorTests"

# Run only DataService tests
dotnet test --filter "FullyQualifiedName~DataServiceTests"
```

## Test Examples

### Basic Unit Test (Calculator)
```csharp
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
```

### Parameterized Test
```csharp
[Theory]
[InlineData(0, 0, 0)]
[InlineData(1, 1, 2)]
[InlineData(-1, -1, -2)]
public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
{
    // Act & Assert
    Assert.Equal(expected, _calculator.Add(a, b));
}
```

### Exception Testing
```csharp
[Fact]
public void Divide_ByZero_ThrowsDivideByZeroException()
{
    // Act & Assert
    Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
}
```

### Mocking with Moq
```csharp
[Fact]
public async Task ProcessDataAsync_WithValidId_ReturnsProcessedData()
{
    // Arrange
    _mockRepository.Setup(r => r.GetDataAsync(1))
                  .ReturnsAsync("hello world");

    // Act
    string result = await _dataService.ProcessDataAsync(1);

    // Assert
    Assert.Equal("HELLO WORLD", result);
    _mockRepository.Verify(r => r.GetDataAsync(1), Times.Once);
}
```

## TDD Best Practices Demonstrated

1. **Red-Green-Refactor Cycle**: Write failing tests, make them pass, then refactor
2. **Arrange-Act-Assert Pattern**: Clear test structure for better readability
3. **Single Responsibility**: Each test method tests one specific behavior
4. **Descriptive Test Names**: Test names clearly describe what is being tested
5. **Mock Dependencies**: Use Moq to isolate units under test
6. **Test Edge Cases**: Include tests for boundary conditions and error scenarios
7. **Verify Interactions**: Use Moq.Verify to ensure dependencies are called correctly

## Code Coverage

To generate and view code coverage reports:

```powershell
# Generate coverage report
dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage

# Install ReportGenerator tool (one time)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Generate HTML report
reportgenerator -reports:"coverage/**/coverage.cobertura.xml" -targetdir:"coverage/report" -reporttypes:Html
```

## Additional Resources

- [XUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)
- [.NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/best-practices)
- [Test-Driven Development with .NET](https://docs.microsoft.com/en-us/dotnet/core/testing/)

## 🎓 TDD Learning Experience

### For Team Learning - String Calculator Kata

This project includes a complete TDD learning experience using the classic "String Calculator" kata:

#### 🚀 Getting Started with TDD
1. **Read the requirements** in `TestList.md`
2. **Follow the workflow** in `TDD-Workflow-Guide.md`
3. **Start with the first test**: Run `dotnet test --filter "Add_EmptyString_ReturnsZero"`
4. **See it fail** ❌ (Red phase)
5. **Make it pass** ✅ (Green phase)
6. **Refactor if needed** 🔵 (Refactor phase)
7. **Repeat** for each test

#### 📝 Step-by-Step Process
```bash
# 1. Run the failing test
dotnet test --filter "Add_EmptyString_ReturnsZero"

# 2. Implement minimal code in StringCalculator.cs
# 3. Run test again to see it pass
dotnet test --filter "Add_EmptyString_ReturnsZero"

# 4. Uncomment next test in StringCalculatorTests.cs
# 5. Repeat the cycle
```

#### 🛠 Helper Tools
- **PowerShell Script**: `.\run-tdd-tests.ps1` - Interactive test runner
- **Test List**: `TestList.md` - Track your progress
- **Workflow Guide**: `TDD-Workflow-Guide.md` - Detailed instructions
