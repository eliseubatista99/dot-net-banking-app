using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardPageLogic : ComponentBase
{
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;
    [Inject]
    protected IWindowHelper windowHelper { get; set; } = default!;

    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    [Parameter]
    public string? SelectedFragment { get; set; }

    public async void OnFragmentSelected(string fragment)
    {
        navManager.NavigateTo(AppPages.Dashboard + "/" + fragment, replace: true);

        //selectedFragment = fragment;
        //this.StateHasChanged();
    }

    protected override void OnParametersSet()
    {
        if (SelectedFragment == null)
        {
            navManager.NavigateTo(AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
        }
        this.StateHasChanged();

    }

    protected override async Task OnInitializedAsync()
    {
        await windowHelper.ListenForResponsiveChanges(async (ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }

}