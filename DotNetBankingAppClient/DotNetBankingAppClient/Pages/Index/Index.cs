using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class IndexPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        UserDTO storedUser = await browserStorage.GetFromLocalStorage<UserDTO>(StoreKeys.User);
        string token = await browserStorage.GetFromSessionStorage<string>(StoreKeys.AuthToken);

        if (storedUser != null && token != null)
        {
            navManager.NavigateTo(AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
        }
        else
        {
            navManager.NavigateTo(AppPages.SignIn, replace: true);
        }
    }
}