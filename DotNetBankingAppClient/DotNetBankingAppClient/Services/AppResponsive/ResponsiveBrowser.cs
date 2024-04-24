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

        private ResponsiveWindowSize CalculateWindowSize(int windowWidth)
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
                    onWindowWidthChangedCallbacks.RemoveAll(elem => elem == null);
                    currentWindowSize = size;
                    foreach (var callback in onWindowWidthChangedCallbacks)
                    {
                        callback(size);
                    }
                }
            }
        }

        public async Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback)
        {
            onWindowWidthChangedCallbacks.Add(callback);
            DotNetObjectReference<ResponsiveBrowser> _objectReference = DotNetObjectReference.Create(this);

            int currentWidth = await _jsRuntime.InvokeAsync<int>("getWidth");
            ResponsiveWindowSize size = CalculateWindowSize(currentWidth);
            callback(size);

            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
        }
    }
}
