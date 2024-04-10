using DotNetBankingAppClient.Constants;
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

    public string[] navOptions = [AppPages.Home, AppPages.Search, AppPages.Inbox, AppPages.Settings];
    public string selectedOption = AppPages.Home;
    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    public void OnOptionSelected(string option)
    {
        if(option != selectedOption)
        {
            selectedOption = option;
            navManager.NavigateTo(option);
            this.StateHasChanged();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await windowHelper.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }

}