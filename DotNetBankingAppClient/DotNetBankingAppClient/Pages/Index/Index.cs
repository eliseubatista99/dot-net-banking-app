using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class IndexPageLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;

    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

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