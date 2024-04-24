using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class AccountsPageLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    private UserDTO? CurrentUser;

    public bool isFetching { get; set; } = false;
    public List<AccountDTO> checkingAccounts { get; set; } = new List<AccountDTO>();
    public List<AccountDTO> savingAccounts { get; set; } = new List<AccountDTO>();

    public void OnClickBack()
    {
        NavManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
    }


    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        checkingAccounts = await Store.GetData<List<AccountDTO>>(StoreKeys.CheckingAccounts);
        savingAccounts = await Store.GetData<List<AccountDTO>>(StoreKeys.SavingAccounts);

        isFetching = false;
        this.StateHasChanged();
    }
}