namespace TDD_Demo.Core;

public interface IDataRepository
{
    Task<string> GetDataAsync(int id);
    Task<bool> SaveDataAsync(int id, string data);
    Task<IEnumerable<string>> GetAllDataAsync();
}
