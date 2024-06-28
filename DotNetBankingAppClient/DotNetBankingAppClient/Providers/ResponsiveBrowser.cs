using DotNetBankingAppClientContracts.Enums;
using DotNetBankingAppClientContracts.Providers;
using Microsoft.JSInterop;

namespace DotNetBankingAppClient.Providers
{
    public class ResponsiveBrowser : IAppResponsiveProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private List<Action<ResponsiveWindowSize, int>> onWindowWidthChangedCallbacks = new List<Action<ResponsiveWindowSize, int>>();
        private ResponsiveWindowSize currentWindowSize = ResponsiveWindowSize.Mobile;
        private int currentWindowWidth = 0;
        protected int cachedWindowWidth = 0;

        public ResponsiveBrowser(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ResponsiveWindowSize GetCurrentSize()
        {
            return currentWindowSize;
        }

        public async Task<int> GetWindowWidth()
        {
            currentWindowWidth = await _jsRuntime.InvokeAsync<int>("getWidth");

            return currentWindowWidth;
        }

        public ResponsiveWindowSize CalculateWindowSize(int windowWidth)
        {
            ResponsiveWindowSize size = ResponsiveWindowSize.Mobile;
            if (windowWidth > 768)
            {
                size = ResponsiveWindowSize.Desktop;
            }
            else if (windowWidth > 425)
            {
                size = ResponsiveWindowSize.Tablet;
            }

            return size;
        }

        [JSInvokable]
        public async Task OnWindowWidthChange(int windowWidth)
        {
            if (onWindowWidthChangedCallbacks.Count > 0)
            {
                cachedWindowWidth = windowWidth;
                await Task.Delay(300);

                //If no change was made after 300ms
                if (cachedWindowWidth == windowWidth)
                {
                    ResponsiveWindowSize size = CalculateWindowSize(windowWidth);

                    currentWindowSize = size;
                    currentWindowWidth = windowWidth;
                    for (int i = 0; i < onWindowWidthChangedCallbacks.Count; i++)
                    {
                        var callback = onWindowWidthChangedCallbacks[i];

                        if (callback != null)
                        {
                            callback(size, currentWindowWidth);
                        }
                    }
                }
            }
        }

        public async Task ListenForResponsiveChanges(Action<ResponsiveWindowSize, int> callback)
        {
            onWindowWidthChangedCallbacks.RemoveAll(elem => elem == null);
            onWindowWidthChangedCallbacks.Add(callback);
            DotNetObjectReference<ResponsiveBrowser> _objectReference = DotNetObjectReference.Create(this);

            await GetWindowWidth();
            ResponsiveWindowSize size = CalculateWindowSize(currentWindowWidth);
            callback(size, currentWindowWidth);

            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
        }
    }
}
