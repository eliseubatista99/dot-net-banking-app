using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class DashboardHeaderLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;

    public UserDTO? user;

    protected override async Task OnInitializedAsync()
    {
        user = await browserStorage.GetFromLocalStorage<UserDTO>("user");

        this.StateHasChanged();
    }

}