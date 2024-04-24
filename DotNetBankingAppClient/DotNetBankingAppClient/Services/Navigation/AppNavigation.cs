using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Services
{
    public class AppNavigation : IAppNavigation
    {
        private readonly NavigationManager _navigationManager;
        private readonly IAppResponsive _appResponsive;
        private readonly IAppLogger _logger;

        public AppNavigation(IAppResponsive appResponsive, NavigationManager navigationManager, IAppLogger logger)
        {
            _appResponsive = appResponsive;
            _navigationManager = navigationManager;
            _logger = logger;
        }


        public async void NavigateTo(string uri, bool replace = false, bool responsive = true)
        {
            string currentLocation = _navigationManager.Uri.Replace(_navigationManager.BaseUri, "");


            ResponsiveWindowSize currentSize = _appResponsive.GetCurrentSize();

            string finalPath = "";

            if (responsive)
            {
                if (currentSize == ResponsiveWindowSize.Desktop)
                {
                    finalPath = "d/";
                }
                else if (currentSize == ResponsiveWindowSize.Desktop)
                {
                    finalPath = "t/";
                }
                else
                {
                    finalPath = "m/";
                }
            }

            finalPath += uri;

            await _logger.Log("Current Location: " + currentLocation + ", FinalPath: " + finalPath);

            if (currentLocation != finalPath)
            {
                _navigationManager.NavigateTo(finalPath, forceLoad: false, replace);
            }
        }
    }
}
