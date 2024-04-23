using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class AccountsPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    private UserDTO? currentUser;

    public bool isFetching { get; set; } = false;
    public List<AccountDTO> checkingAccounts { get; set; } = new List<AccountDTO>();
    public List<AccountDTO> savingAccounts { get; set; } = new List<AccountDTO>();

    public void OnClickBack()
    {
        navManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
    }


    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        checkingAccounts = await browserStorage.GetFromLocalStorage<List<AccountDTO>>(StoreKeys.CheckingAccounts);
        savingAccounts = await browserStorage.GetFromLocalStorage<List<AccountDTO>>(StoreKeys.SavingAccounts);

        isFetching = false;
        this.StateHasChanged();
    }
}