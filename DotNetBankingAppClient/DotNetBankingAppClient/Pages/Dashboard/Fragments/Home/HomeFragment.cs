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
    protected IAppLogger Logger { get; set; } = default!;
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IApiCommunication ApiCommunication { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    public bool IsFetching { get; set; } = false;

    public List<AccountDTO>? Accounts { get; set; }
    public List<CardDTO>? Cards { get; set; }
    public int SelectedAccount { get; set; } = 0;

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

    public void OnAccountSelected(int index)
    {
        var newIndex = index;

        if (newIndex < 0)
        {
            newIndex = 0;
        }
        else if (Cards != null && newIndex > Cards.Count - 1)
        {
            newIndex = Cards.Count - 1;
        }
        SelectedAccount = newIndex;
        this.StateHasChanged();
    }

    public void OnClickSeeAllTransactions()
    {

    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;


        this.StateHasChanged();
        var currentUser = await Store.GetData<UserDTO>(StoreKeys.User);

        Accounts = await GetAllAccounts(currentUser);
        var checkingAccounts = Accounts.Where((acc) => acc.AccountType == AccountType.Checking).ToList();
        var savingAccounts = Accounts.Where((acc) => acc.AccountType == AccountType.Savings).ToList();

        await Store.PersistData(StoreKeys.CheckingAccounts, checkingAccounts);
        await Store.PersistData(StoreKeys.SavingAccounts, savingAccounts);

        Cards = await GetAllCardsForAllAccounts(checkingAccounts);
        await Store.PersistData(StoreKeys.Cards, Cards);

        IsFetching = false;

        this.StateHasChanged();
    }
}