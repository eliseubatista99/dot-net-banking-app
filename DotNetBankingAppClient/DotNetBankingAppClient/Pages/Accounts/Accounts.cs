using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
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
        navManager.NavigateTo(uri: AppPages.Home, replace: true);
    }


    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        currentUser = await browserStorage.GetFromLocalStorage<UserDTO>("user");

        var result = await ServiceGetAccounts.CallAsync(new ServiceGetAccountsInput { UserName = currentUser.UserName });

        if (result.Metadata.Success)
        {
            checkingAccounts = result.Data?.CheckingAccounts ?? new List<AccountDTO>();
            savingAccounts = result.Data?.SavingAccounts ?? new List<AccountDTO>();
            isFetching = false;
            this.StateHasChanged();
        }
        else
        {
            isFetching = false;
            this.StateHasChanged();
        }
    }
}