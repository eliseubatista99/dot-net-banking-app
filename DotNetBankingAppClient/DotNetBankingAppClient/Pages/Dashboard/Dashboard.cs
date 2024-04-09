using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    
    [Inject]
    protected IWindowHelper windowHelper { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    [Inject]
    protected HttpClient httpClient { get; set; } = default!;

    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;
    public UserDTO? user;


    protected override async Task OnInitializedAsync()
    {
        await windowHelper.ListenForResponsiveChanges(async (ResponsiveWindowSize size) => { 
            windowSize = size;
            this.StateHasChanged(); 
        });
    }

}