namespace UI.Services
{
    public interface IStorageService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T data);
        Task RemoveAsync(string key);
        void ClearStorage();
    }
}