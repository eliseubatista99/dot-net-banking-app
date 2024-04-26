using Microsoft.JSInterop;

namespace DotNetBankingAppClient.Services
{
    public class ResponsiveBrowser : IAppResponsive
    {
        private readonly IJSRuntime _jsRuntime;
        private List<Action<ResponsiveWindowSize>> onWindowWidthChangedCallbacks = new List<Action<ResponsiveWindowSize>>();
        private ResponsiveWindowSize currentWindowSize = ResponsiveWindowSize.Mobile;

        public ResponsiveBrowser(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
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
                ResponsiveWindowSize size = CalculateWindowSize(windowWidth);

                if (size != currentWindowSize)
                {
                    currentWindowSize = size;
                    for (int i = 0; i < onWindowWidthChangedCallbacks.Count; i++)
                    {
                        var callback = onWindowWidthChangedCallbacks[i];

                        if (callback != null)
                        {
                            callback(size);

                        }
                    }
                }
            }
        }

        public async Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback)
        {
            onWindowWidthChangedCallbacks.RemoveAll(elem => elem == null);
            onWindowWidthChangedCallbacks.Add(callback);
            DotNetObjectReference<ResponsiveBrowser> _objectReference = DotNetObjectReference.Create(this);

            int currentWidth = await _jsRuntime.InvokeAsync<int>("getWidth");
            ResponsiveWindowSize size = CalculateWindowSize(currentWidth);
            callback(size);

            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
        }

        public ResponsiveWindowSize GetCurrentSize()
        {
            return currentWindowSize;
        }
    }
}
