using Microsoft.JSInterop;
using System.Text.Json;

namespace DotNetBankingAppClient.Helpers
{
    public interface IBrowserStorage
    {
        public Task SetInLocalStorage(string key, object? value);
        public Task SetInSessionStorage(string key, object? value);
        public Task<T> GetFromLocalStorage<T>(string key);
        public Task<T> GetFromSessionStorage<T>(string key);
        public Task RemoveFromLocalStorage(string key);
        public Task RemoveFromSessionStorage(string key);
        public Task ClearLocalStorage();
        public Task ClearSessionStorage();
    }

    public class BrowserStorage : IBrowserStorage
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetInLocalStorage(string key, object? value)
        {
            string jsVal = null;
            if (value != null)
                jsVal = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem",
                new object[] { key, jsVal });
        }

        public async Task SetInSessionStorage(string key, object? value)
        {
            string jsVal = null;
            if (value != null)
                jsVal = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem",
                new object[] { key, jsVal });
        }

        public async Task<T> GetFromLocalStorage<T>(string key)
        {
            string val = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (val == null) return default;
            T result = JsonSerializer.Deserialize<T>(val);
            return result;
        }

        public async Task<T> GetFromSessionStorage<T>(string key)
        {
            string val = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", key);
            if (val == null) return default;
            T result = JsonSerializer.Deserialize<T>(val);
            return result;
        }

        public async Task RemoveFromLocalStorage(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task RemoveFromSessionStorage(string key)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", key);
        }

        public async Task ClearLocalStorage()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.clear");
        }

        public async Task ClearSessionStorage()
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.clear");
        }
    }
}
