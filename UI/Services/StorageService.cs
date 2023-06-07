using System.Text.Json;

namespace UI.Services;

public class StorageService : IStorageService
{
    private const string StorageFolder = "AppLocalStorage";

    public async Task<T> GetAsync<T>(string key)
    {
        var filePath = GetFilePath(key);
        if (!File.Exists(filePath))
        {
            return default;
        }
        
        var json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task SetAsync<T>(string key, T data)
    {
        var json = JsonSerializer.Serialize(data);
        var filePath = GetFilePath(key);
        await File.WriteAllTextAsync(filePath, json);
    }
    
    public async Task RemoveAsync(string key)
    {
        var filePath = GetFilePath(key);
        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath));
        }
    }
    
    public void ClearStorage()
    {
        var folderPath = Path.Combine(FileSystem.AppDataDirectory, StorageFolder);
        if (Directory.Exists(folderPath))
        {
            Directory.Delete(folderPath, true);
        }
    }
    
    private string GetFilePath(string key)
    {
        var folderPath = Path.Combine(FileSystem.AppDataDirectory, StorageFolder);
        Directory.CreateDirectory(folderPath);
        return Path.Combine(folderPath, $"{key}.json");
    }
}