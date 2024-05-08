using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Services
{
    public class AppNavigation : IAppNavigation
    {
        private readonly NavigationManager _navigationManager;
        private readonly IAppLogger _logger;

        public AppNavigation(NavigationManager navigationManager, IAppLogger logger)
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
