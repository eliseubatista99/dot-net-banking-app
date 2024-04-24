using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Layout;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class HomeNavigationItemLogic : ComponentBase
{
    [Parameter]
    public string name { get; set; } = "";
    [Parameter]
    public string path { get; set; } = "";

    [Parameter]
    public Action<string>? OnClickItem { get; set; } = null;

    public void OnItemClicked()
    {
        if(OnClickItem != null)
        {
            OnClickItem(path);
        }
    }
}