using Microsoft.JSInterop;
using System.Text.Json;

namespace DotNetBankingAppClient.Services
{
    public class BrowserStore : IStore
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserStore(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task PersistData(string key, object? value)
        {
            string jsVal = null;
            if (value != null)
                jsVal = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem",
                new object[] { key, jsVal });
        }

        public async Task CacheData(string key, object? value)
        {
            string jsVal = null;
            if (value != null)
                jsVal = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem",
                new object[] { key, jsVal });
        }

        public async Task<T> GetData<T>(string key)
        {
            string val = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (val == null) return default;
            T result = JsonSerializer.Deserialize<T>(val);
            return result;
        }

        public async Task<T> GetCachedData<T>(string key)
        {
            string val = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
            if (val == null) return default;
            T result = JsonSerializer.Deserialize<T>(val);
            return result;
        }

        public async Task RemoveData(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task RemoveCachedData(string key)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);
        }

        public async Task ClearData()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.clear");
        }

        public async Task ClearCachedData()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.clear");
        }
    }
}
