using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxMessageDetailsLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    public MessageDTO? Message { get; set; }
    public bool IsFetching { get; set; } = false;

    public void OnClickBack()
    {
        NavManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Inbox, replace: true);
    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;
        this.StateHasChanged();
        Message = await Store.GetCachedData<MessageDTO>(StoreKeys.SelectedMessage);
        IsFetching = false;
        this.StateHasChanged();
    }
}