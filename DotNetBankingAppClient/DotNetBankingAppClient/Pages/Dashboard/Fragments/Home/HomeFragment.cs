using DotNetBankingAppClient.Api;
using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class HomeFragmentItems
{
    public string name { get; set; } = "";
    public string path { get; set; } = "";
}

public class HomeFragmentLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IApiCommunication ApiCommunication { get; set; } = default!;
    [Inject]
    protected NavigationManager NavManager { get; set; } = default!;
    [Inject]
    protected IAppResponsive AppResponsive { get; set; } = default!;

    public bool IsFetching { get; set; } = false;
    public ResponsiveWindowSize WindowSize = ResponsiveWindowSize.Mobile;


    public HomeFragmentItems[] HomeFragmentItems = [
       new HomeFragmentItems {
        name = "Accounts",
        path = AppPages.Accounts
    }, new HomeFragmentItems {
        name = "Transfers",
        path = AppPages.Transfer
    }, new HomeFragmentItems {
        name = "PayMobile",
        path = AppPages.PayMobile
    }, new HomeFragmentItems {
        name = "PayBill",
        path = AppPages.PayBill
    }, new HomeFragmentItems {
        name = "Savings",
        path = AppPages.Savings
    }, new HomeFragmentItems {
        name = "Cards",
        path = AppPages.Cards
    }, new HomeFragmentItems {
        name = "Transactions",
        path = AppPages.Transactions
    }, new HomeFragmentItems {
        name = "Beneficiaries",
        path = AppPages.Beneficiaries
    }];


    public void OnClickItem(string path)
    {
        NavManager.NavigateTo(path, replace: true);
    }

    private async Task<List<AccountDTO>> GetAllAccounts(UserDTO user)
    {
        var result = await ApiCommunication.CallService<ServiceGetAccountsInput, ServiceGetAccountsOutput>(ApiEndpoints.GetAccounts, new ServiceGetAccountsInput { UserName = user.UserName });


        List<AccountDTO> accounts = new List<AccountDTO>();

        if (result.MetaData.Success)
        {
            accounts.AddRange(result.Data.CheckingAccounts);
            accounts.AddRange(result.Data.SavingAccounts);
            return accounts;
        }
        else
        {
            return new List<AccountDTO>();
        }
    }

    private async Task<List<CardDTO>> GetAllCardsForAllAccounts(List<AccountDTO> accounts)
    {
        List<CardDTO> cards = new List<CardDTO>();

        foreach (var account in accounts)
        {
            var result = await ApiCommunication.CallService<ServiceGetCardsInput, ServiceGetCardsOutput>(ApiEndpoints.GetCards, new ServiceGetCardsInput { AccountID = account.AccountId });

            if (result.MetaData.Success && result.Data != null)
            {
                cards.AddRange(result.Data.Cards);
            }
        }

        return cards;
    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;

        await AppResponsive.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            WindowSize = size;
            this.StateHasChanged();
        });

        this.StateHasChanged();
        var currentUser = await Store.GetData<UserDTO>(StoreKeys.User);

        var accounts = await GetAllAccounts(currentUser);
        var checkingAccounts = accounts.Where((acc) => acc.AccountType == AccountType.Checking).ToList();
        var savingAccounts = accounts.Where((acc) => acc.AccountType == AccountType.Savings).ToList();

        await Store.PersistData(StoreKeys.CheckingAccounts, checkingAccounts);
        await Store.PersistData(StoreKeys.SavingAccounts, savingAccounts);

        var cards = await GetAllCardsForAllAccounts(checkingAccounts);
        await Store.PersistData(StoreKeys.Cards, cards);

        IsFetching = false;
        this.StateHasChanged();
    }
}