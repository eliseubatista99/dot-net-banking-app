using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardNavigationLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;

    [Inject]
    protected IAppResponsive AppResponsive { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    [Parameter]
    public Action<string> OnOptionSelected { get; set; }

    [Parameter]
    public string SelectedOption { get; set; }

    public string[] navOptions = [DashboardFragments.Home, DashboardFragments.Search, DashboardFragments.Inbox, DashboardFragments.Settings];
    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    public void HandleOnOptionSelected(string option)
    {
        if (option != SelectedOption)
        {
            OnOptionSelected(option);
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

        await AppResponsive.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }
}