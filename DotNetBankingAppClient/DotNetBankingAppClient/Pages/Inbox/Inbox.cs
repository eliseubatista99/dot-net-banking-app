using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public bool isFetching = false;
    private UserDTO? currentUser;
    public List<MessageDTOGroup> groupedMessages { get; set; } = new List<MessageDTOGroup>();

    public async void OnMessageClicked(MessageDTO message)
    {
        isFetching = true;
        this.StateHasChanged();
        await browserStorage.SetInSessionStorage("message", message);

        navManager.NavigateTo(AppPages.InboxMessageDetails, replace: true);
    }

    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        currentUser = await browserStorage.GetFromLocalStorage<UserDTO>("user");

        var result = await ServiceGetInbox.CallAsync(new ServiceGetInboxInput { username = currentUser.UserName });

        if (result.Metadata.Success)
        {
            groupedMessages = result.Data?.groupedMessages ?? new List<MessageDTOGroup>();
            isFetching = true;
            this.StateHasChanged();
        }
        else
        {
            isFetching = false;
            this.StateHasChanged();
        }
    }
}