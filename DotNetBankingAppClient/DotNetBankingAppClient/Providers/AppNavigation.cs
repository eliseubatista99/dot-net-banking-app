using DotNetBankingAppClientContracts.Providers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Providers
{
    public class AppNavigation : IAppNavigationProvider
    {
        private readonly NavigationManager _navigationManager;
        private readonly IAppLoggerProvider _logger;

        public AppNavigation(NavigationManager navigationManager, IAppLoggerProvider logger)
        {
            _navigationManager = navigationManager;
            _logger = logger;
        }


        public async void NavigateTo(string uri, bool replace = false)
        {
            string currentLocation = _navigationManager.Uri.Replace(_navigationManager.BaseUri, "");

            await _logger.Log("Current Location: " + currentLocation + ", FinalPath: " + uri);

            if (currentLocation != uri)
            {
                _navigationManager.NavigateTo(uri, forceLoad: false, replace);
            }
        }
    }
}
