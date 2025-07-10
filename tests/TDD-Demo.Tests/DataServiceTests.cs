using TDD_Demo.Core;
using Xunit;
using Moq;

namespace TDD_Demo.Tests;

public class DataServiceTests
{
    private readonly Mock<IDataRepository> _mockRepository;
    private readonly Mock<ILogger> _mockLogger;
    private readonly DataService _dataService;

    public DataServiceTests()
    {
        _mockRepository = new Mock<IDataRepository>();
        _mockLogger = new Mock<ILogger>();
        _dataService = new DataService(_mockRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void Constructor_WithNullRepository_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new DataService(null, _mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new DataService(_mockRepository.Object, null));
    }

    [Fact]
    public async Task ProcessDataAsync_WithValidId_ReturnsProcessedData()
    {
        // Arrange
        int id = 1;
        string rawData = "hello world";
        string expectedData = "HELLO WORLD";

        _mockRepository.Setup(r => r.GetDataAsync(id))
                      .ReturnsAsync(rawData);

        // Act
        string result = await _dataService.ProcessDataAsync(id);

        // Assert
        Assert.Equal(expectedData, result);
        _mockRepository.Verify(r => r.GetDataAsync(id), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Processing data for ID: {id}"), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Successfully processed data for ID: {id}"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_WithInvalidId_ThrowsArgumentException()
    {
        // Arrange
        int invalidId = 0;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _dataService.ProcessDataAsync(invalidId));
        Assert.Equal("ID must be greater than 0 (Parameter 'id')", exception.Message);
        _mockLogger.Verify(l => l.LogWarning("Invalid ID provided"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_WithNegativeId_ThrowsArgumentException()
    {
        // Arrange
        int invalidId = -1;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _dataService.ProcessDataAsync(invalidId));
        Assert.Equal("ID must be greater than 0 (Parameter 'id')", exception.Message);
        _mockLogger.Verify(l => l.LogWarning("Invalid ID provided"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_WithEmptyData_ReturnsNoDataMessage()
    {
        // Arrange
        int id = 1;
        string emptyData = "";

        _mockRepository.Setup(r => r.GetDataAsync(id))
                      .ReturnsAsync(emptyData);

        // Act
        string result = await _dataService.ProcessDataAsync(id);

        // Assert
        Assert.Equal("No data available", result);
        _mockLogger.Verify(l => l.LogWarning($"No data found for ID: {id}"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_WithNullData_ReturnsNoDataMessage()
    {
        // Arrange
        int id = 1;
        string nullData = null;

        _mockRepository.Setup(r => r.GetDataAsync(id))
                      .ReturnsAsync(nullData);

        // Act
        string result = await _dataService.ProcessDataAsync(id);

        // Assert
        Assert.Equal("No data available", result);
        _mockLogger.Verify(l => l.LogWarning($"No data found for ID: {id}"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_WhenRepositoryThrows_LogsErrorAndRethrows()
    {
        // Arrange
        int id = 1;
        var expectedException = new InvalidOperationException("Database error");

        _mockRepository.Setup(r => r.GetDataAsync(id))
                      .ThrowsAsync(expectedException);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _dataService.ProcessDataAsync(id));
        Assert.Equal("Database error", exception.Message);
        _mockLogger.Verify(l => l.LogError($"Error processing data for ID {id}: Database error"), Times.Once);
    }

    [Fact]
    public async Task CreateDataAsync_WithValidData_ReturnsTrue()
    {
        // Arrange
        int id = 1;
        string data = "test data";

        _mockRepository.Setup(r => r.SaveDataAsync(id, data))
                      .ReturnsAsync(true);

        // Act
        bool result = await _dataService.CreateDataAsync(id, data);

        // Assert
        Assert.True(result);
        _mockRepository.Verify(r => r.SaveDataAsync(id, data), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Creating data for ID: {id}"), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Successfully created data for ID: {id}"), Times.Once);
    }

    [Fact]
    public async Task CreateDataAsync_WithInvalidId_ThrowsArgumentException()
    {
        // Arrange
        int invalidId = 0;
        string data = "test data";

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _dataService.CreateDataAsync(invalidId, data));
        Assert.Equal("ID must be greater than 0 (Parameter 'id')", exception.Message);
        _mockLogger.Verify(l => l.LogWarning("Invalid ID provided for creation"), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CreateDataAsync_WithInvalidData_ThrowsArgumentException(string invalidData)
    {
        // Arrange
        int id = 1;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _dataService.CreateDataAsync(id, invalidData));
        Assert.Equal("Data cannot be null or empty (Parameter 'data')", exception.Message);
        _mockLogger.Verify(l => l.LogWarning("Invalid data provided for creation"), Times.Once);
    }

    [Fact]
    public async Task CreateDataAsync_WhenSaveFails_ReturnsFalse()
    {
        // Arrange
        int id = 1;
        string data = "test data";

        _mockRepository.Setup(r => r.SaveDataAsync(id, data))
                      .ReturnsAsync(false);

        // Act
        bool result = await _dataService.CreateDataAsync(id, data);

        // Assert
        Assert.False(result);
        _mockLogger.Verify(l => l.LogWarning($"Failed to create data for ID: {id}"), Times.Once);
    }

    [Fact]
    public async Task GetAllProcessedDataAsync_WithData_ReturnsProcessedData()
    {
        // Arrange
        var rawData = new List<string> { "hello", "world", "test" };
        var expectedData = new List<string> { "HELLO", "WORLD", "TEST" };

        _mockRepository.Setup(r => r.GetAllDataAsync())
                      .ReturnsAsync(rawData);

        // Act
        var result = await _dataService.GetAllProcessedDataAsync();

        // Assert
        Assert.Equal(expectedData, result);
        _mockRepository.Verify(r => r.GetAllDataAsync(), Times.Once);
        _mockLogger.Verify(l => l.LogInfo("Retrieving all data"), Times.Once);
        _mockLogger.Verify(l => l.LogInfo($"Successfully retrieved and processed {expectedData.Count} items"), Times.Once);
    }

    [Fact]
    public async Task GetAllProcessedDataAsync_WithEmptyData_ReturnsEmptyList()
    {
        // Arrange
        var emptyData = new List<string>();

        _mockRepository.Setup(r => r.GetAllDataAsync())
                      .ReturnsAsync(emptyData);

        // Act
        var result = await _dataService.GetAllProcessedDataAsync();

        // Assert
        Assert.Empty(result);
        _mockLogger.Verify(l => l.LogInfo("Successfully retrieved and processed 0 items"), Times.Once);
    }

    [Fact]
    public async Task GetAllProcessedDataAsync_WhenRepositoryThrows_LogsErrorAndRethrows()
    {
        // Arrange
        var expectedException = new InvalidOperationException("Database connection failed");

        _mockRepository.Setup(r => r.GetAllDataAsync())
                      .ThrowsAsync(expectedException);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _dataService.GetAllProcessedDataAsync());
        Assert.Equal("Database connection failed", exception.Message);
        _mockLogger.Verify(l => l.LogError("Error retrieving all data: Database connection failed"), Times.Once);
    }

    [Fact]
    public async Task ProcessDataAsync_VerifyLoggingSequence()
    {
        // Arrange
        int id = 1;
        string rawData = "test";
        var logMessages = new List<string>();

        _mockRepository.Setup(r => r.GetDataAsync(id))
                      .ReturnsAsync(rawData);

        _mockLogger.Setup(l => l.LogInfo(It.IsAny<string>()))
                   .Callback<string>(message => logMessages.Add(message));

        // Act
        await _dataService.ProcessDataAsync(id);

        // Assert
        Assert.Equal(2, logMessages.Count);
        Assert.Equal("Processing data for ID: 1", logMessages[0]);
        Assert.Equal("Successfully processed data for ID: 1", logMessages[1]);
    }
}
