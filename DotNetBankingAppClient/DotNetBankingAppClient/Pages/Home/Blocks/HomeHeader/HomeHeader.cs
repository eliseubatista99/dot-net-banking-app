using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class HomeHeaderLogic : ComponentBase
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