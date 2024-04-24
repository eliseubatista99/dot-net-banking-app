namespace DotNetBankingAppClient.Services
{
    public interface IStore
    {
        public Task PersistData(string key, object? value);
        public Task CacheData(string key, object? value);
        public Task<T> GetData<T>(string key);
        public Task<T> GetCachedData<T>(string key);
        public Task RemoveData(string key);
        public Task RemoveCachedData(string key);
        public Task ClearData();
        public Task ClearCachedData();
    }
}
