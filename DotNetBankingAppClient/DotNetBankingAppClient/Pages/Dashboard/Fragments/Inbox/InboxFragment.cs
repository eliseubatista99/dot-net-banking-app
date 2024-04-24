using DotNetBankingAppClient.Api;
using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxFragmentLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IApiCommunication ApiCommunication { get; set; } = default!;
    [Inject]
    protected NavigationManager NavManager { get; set; } = default!;

    public bool IsFetching = false;
    private UserDTO? CurrentUser;
    public List<MessageDTOGroup> GroupedMessages { get; set; } = new List<MessageDTOGroup>();

    public async void OnMessageClicked(MessageDTO message)
    {
        IsFetching = true;
        this.StateHasChanged();
        await Store.CacheData(StoreKeys.SelectedMessage, message);

        NavManager.NavigateTo(AppPages.InboxMessageDetails, replace: true);
    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;
        this.StateHasChanged();
        CurrentUser = await Store.GetData<UserDTO>(StoreKeys.User);

        var result = await ApiCommunication.CallService<ServiceGetInboxInput, ServiceGetInboxOutput>(ApiEndpoints.GetInbox, new ServiceGetInboxInput { UserName = CurrentUser.UserName });

        if (result.MetaData.Success)
        {
            GroupedMessages = result.Data?.GroupedMessages ?? new List<MessageDTOGroup>();
            IsFetching = false;
            this.StateHasChanged();
        }
        else
        {
            IsFetching = false;
            this.StateHasChanged();
        }
    }
}