using DotNetBankingAppClientContracts.Constants;
using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;
using DotNetBankingAppClientContracts.Providers;

namespace DotNetBankingAppClient.Components;

public class DashboardHeaderLogic : ComponentBase
{
    [Inject]
    protected IStoreProvider Store { get; set; } = default!;

    public UserDTO? user;

    protected override async Task OnInitializedAsync()
    {
        user = await Store.GetData<UserDTO>(StoreKeys.User);

        this.StateHasChanged();
    }

}