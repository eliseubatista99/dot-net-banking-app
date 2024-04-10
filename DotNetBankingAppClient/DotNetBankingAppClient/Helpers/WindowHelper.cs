using Microsoft.JSInterop;
using System.Drawing;
using System.Text.Json;

namespace DotNetBankingAppClient.Helpers
{
    public enum ResponsiveWindowSize
    {
        Mobile,
        Tablet,
        Desktop,
    }

    public interface IWindowHelper
    {
        public Task Log(object value);
        public Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback);
    }

    public class WindowHelper : IWindowHelper
    {
        private readonly IJSRuntime _jsRuntime;
        private List<Action<ResponsiveWindowSize>> onWindowWidthChangedCallbacks = new List<Action<ResponsiveWindowSize>>();
        private ResponsiveWindowSize currentWindowSize = ResponsiveWindowSize.Mobile;

        public WindowHelper(IJSRuntime jsRuntime)
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
                    foreach(var callback  in onWindowWidthChangedCallbacks)
                    {
                        callback(size);
                    }
                }
            }
        }

        public async Task ListenForResponsiveChanges(Action<ResponsiveWindowSize> callback)
        {
            onWindowWidthChangedCallbacks.Add(callback);
            DotNetObjectReference<WindowHelper> _objectReference = DotNetObjectReference.Create(this);

            int currentWidth = await _jsRuntime.InvokeAsync<int>("getWidth");
            ResponsiveWindowSize size = CalculateWindowSize(currentWidth);
            callback(size);

            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
        }

        public async Task Log(object value)
        {
            //Log is a function declared in index.html
            await _jsRuntime.InvokeVoidAsync("log", value);
        }
    }
}
