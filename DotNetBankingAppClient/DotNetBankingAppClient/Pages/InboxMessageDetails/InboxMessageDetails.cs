using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxMessageDetailsLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public MessageDTO? message { get; set; }
    public bool isFetching { get; set; } = false;

    public void OnClickBack()
    {
        navManager.NavigateTo(uri: AppPages.Inbox, replace: true);
    }

    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        message = await browserStorage.GetFromSessionStorage<MessageDTO>(StoreKeys.SelectedMessage);
        isFetching = false;
        this.StateHasChanged();
    }
}