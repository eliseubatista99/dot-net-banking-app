using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxPageLogic : ComponentBase
{
    // Gets a reference to the DashboardLayout
    [CascadingParameter]
    public DashboardLayout DashboardLayout { get; set; }
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public bool isFetching = false;
    private UserDTO? currentUser;
    public List<MessageDTO> messages { get; set; } = new List<MessageDTO>();



    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        currentUser = await browserStorage.GetFromLocalStorage<UserDTO>("user");

        var result = await ServiceGetInbox.CallAsync(new ServiceGetInboxInput { UserName = currentUser.UserName });

        if (result.Metadata.Success)
        {
            messages = result.Data?.Messages ?? new List<MessageDTO>();
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