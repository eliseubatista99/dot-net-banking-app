using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class DashboardHeaderLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;

    public UserDTO? user;

    protected override async Task OnInitializedAsync()
    {
        user = await Store.GetData<UserDTO>("user");

        this.StateHasChanged();
    }

}