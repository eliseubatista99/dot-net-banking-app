using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class DashboardHeaderLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;

    public UserDTO? user;

    protected override async Task OnInitializedAsync()
    {
        user = await Store.GetData<UserDTO>(StoreKeys.User);

        this.StateHasChanged();
    }

}