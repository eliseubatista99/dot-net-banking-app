using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class HomePageItems
{
    public string name { get; set; } = "";
    public string path { get; set; } = "";
}

public class HomePageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public HomePageItems[] homePageItems = [
       new HomePageItems {
        name = "Accounts",
        path = AppPages.Accounts
    }, new HomePageItems {
        name = "Transfers",
        path = AppPages.Transfer
    }, new HomePageItems {
        name = "PayMobile",
        path = AppPages.PayMobile
    }, new HomePageItems {
        name = "PayBill",
        path = AppPages.PayBill
    }, new HomePageItems {
        name = "Savings",
        path = AppPages.Savings
    }, new HomePageItems {
        name = "Cards",
        path = AppPages.Cards
    }, new HomePageItems {
        name = "Transactions",
        path = AppPages.Transactions
    }, new HomePageItems {
        name = "Beneficiaries",
        path = AppPages.Beneficiaries
    }];


    public void OnClickItem(string path)
    {
        navManager.NavigateTo(path, replace: true);
    }
}