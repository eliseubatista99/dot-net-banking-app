using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

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
        if (option != selectedOption)
        {
            navManager.NavigateTo(uri: option, replace: true);
        }
    }

    private string GetOptionFromUrl()
    {
        var baseUrl = navManager.BaseUri ?? "";
        var fullUrl = navManager.Uri ?? "";
        return fullUrl.Replace(baseUrl, "").Trim();
    }

    private void OnUrlChanged(object? sender, LocationChangedEventArgs e)
    {
        selectedOption = GetOptionFromUrl();
        this.StateHasChanged();
    }


    protected override async Task OnInitializedAsync()
    {
        navManager.LocationChanged += OnUrlChanged;

        selectedOption = GetOptionFromUrl();

        await windowHelper.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }
}