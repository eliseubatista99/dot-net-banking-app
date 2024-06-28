using DotNetBankingAppClientContracts.Providers;
using Microsoft.JSInterop;

namespace DotNetBankingAppClient.Services
{
    public class BrowserLogger : IAppLoggerProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public BrowserLogger(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Log(string value)
        {
            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("log", value);
        }
    }
}
