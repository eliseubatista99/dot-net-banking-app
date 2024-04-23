using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
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

    [Parameter]
    public Action<string> onOptionSelected { get; set; }

    [Parameter]
    public string selectedOption { get; set; }

    public string[] navOptions = [DashboardFragments.Home, DashboardFragments.Search, DashboardFragments.Inbox, DashboardFragments.Settings];
    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    public void OnOptionSelected(string option)
    {
        if (option != selectedOption)
        {
            onOptionSelected(option);
        }
    }

    /*
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
    }*/


    protected override async Task OnInitializedAsync()
    {
        //navManager.LocationChanged += OnUrlChanged;

        //selectedOption = GetOptionFromUrl();

        await windowHelper.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }
}