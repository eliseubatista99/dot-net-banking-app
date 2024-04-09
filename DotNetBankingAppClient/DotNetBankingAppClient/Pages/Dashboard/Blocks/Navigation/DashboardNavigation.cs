using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardNavigationLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;

    [Inject]
    protected IWindowHelper windowHelper { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    [Inject]
    protected HttpClient httpClient { get; set; } = default!;

    public UserDTO? user;

    protected override async Task OnInitializedAsync()
    {
        user = await browserStorage.GetFromLocalStorage<UserDTO>("user");

        this.StateHasChanged();
    }

}