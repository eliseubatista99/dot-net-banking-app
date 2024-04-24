using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Layout;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class AccountsAccountItemLogic : ComponentBase
{
    [Parameter]
    public required AccountDTO account { get; set; }
   
    [Parameter]
    public Action<AccountDTO>? OnClickItem { get; set; } = null;

    public void OnItemClicked()
    {
        if(OnClickItem != null)
        {
            OnClickItem(account);
        }
    }
}