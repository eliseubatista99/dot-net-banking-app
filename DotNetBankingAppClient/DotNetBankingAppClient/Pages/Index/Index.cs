using DotNetBankingAppClientContracts.Constants;
using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;
using DotNetBankingAppClientContracts.Providers;

namespace DotNetBankingAppClient.Pages;

public class IndexPageLogic : ComponentBase
{
    [Inject]
    protected IStoreProvider Store { get; set; } = default!;

    [Inject]
    protected IAppNavigationProvider NavManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        UserDTO storedUser = await Store.GetData<UserDTO>(StoreKeys.User);
        string token = await Store.GetCachedData<string>(StoreKeys.AuthToken);

        if (storedUser != null && token != null)
        {
            NavManager.NavigateTo(AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
        }
        else
        {
            NavManager.NavigateTo(AppPages.SignIn, replace: true);
        }
    }
}