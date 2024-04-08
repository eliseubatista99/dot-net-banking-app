using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class IndexPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        UserDTO storedUser = await browserStorage.GetFromLocalStorage<UserDTO>("user");
        string token = await browserStorage.GetFromSessionStorage<string>("token");

        if (storedUser != null && token != null)
        {
            navManager.NavigateTo("/dashboard");
        }
        else
        {
            navManager.NavigateTo("/signIn");
        }
    }
}