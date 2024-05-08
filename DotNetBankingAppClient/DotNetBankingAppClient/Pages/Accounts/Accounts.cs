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
    public int SelectedAccount { get; set; } = 0;

    public bool isFetching { get; set; } = false;
    public List<AccountDTO> Accounts { get; set; } = new List<AccountDTO>();

    public void OnClickBack()
    {
        NavManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
    }

    public void OnAccountSelected(int index)
    {
        SelectedAccount = index;
        this.StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        Accounts = await Store.GetCachedData<List<AccountDTO>>(StoreKeys.CheckingAccounts);
        Accounts.AddRange(await Store.GetCachedData<List<AccountDTO>>(StoreKeys.SavingAccounts));

        isFetching = false;
        this.StateHasChanged();
    }
}