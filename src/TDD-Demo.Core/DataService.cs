namespace TDD_Demo.Core;

public interface ILogger
{
    void LogInfo(string message);
    void LogError(string message);
    void LogWarning(string message);
}

public class DataService
{
    private readonly IDataRepository _repository;
    private readonly ILogger _logger;

    public DataService(IDataRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> ProcessDataAsync(int id)
    {
        try
        {
            _logger.LogInfo($"Processing data for ID: {id}");
            
            if (id <= 0)
            {
                _logger.LogWarning("Invalid ID provided");
                throw new ArgumentException("ID must be greater than 0", nameof(id));
            }

            var data = await _repository.GetDataAsync(id);
            
            if (string.IsNullOrEmpty(data))
            {
                _logger.LogWarning($"No data found for ID: {id}");
                return "No data available";
            }

            var processedData = data.ToUpperInvariant();
            _logger.LogInfo($"Successfully processed data for ID: {id}");
            
            return processedData;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing data for ID {id}: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> CreateDataAsync(int id, string data)
    {
        try
        {
            _logger.LogInfo($"Creating data for ID: {id}");
            
            if (id <= 0)
            {
                _logger.LogWarning("Invalid ID provided for creation");
                throw new ArgumentException("ID must be greater than 0", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(data))
            {
                _logger.LogWarning("Invalid data provided for creation");
                throw new ArgumentException("Data cannot be null or empty", nameof(data));
            }

            var result = await _repository.SaveDataAsync(id, data);
            
            if (result)
            {
                _logger.LogInfo($"Successfully created data for ID: {id}");
            }
            else
            {
                _logger.LogWarning($"Failed to create data for ID: {id}");
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating data for ID {id}: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<string>> GetAllProcessedDataAsync()
    {
        try
        {
            _logger.LogInfo("Retrieving all data");
            
            var allData = await _repository.GetAllDataAsync();
            var processedData = allData.Select(data => data.ToUpperInvariant()).ToList();
            
            _logger.LogInfo($"Successfully retrieved and processed {processedData.Count} items");
            
            return processedData;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving all data: {ex.Message}");
            throw;
        }
    }
}
