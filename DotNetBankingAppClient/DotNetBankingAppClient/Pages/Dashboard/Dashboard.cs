using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardPageLogic : ComponentBase
{
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;
    [Inject]
    protected IAppResponsive AppResponsive { get; set; } = default!;

    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    [Parameter]
    public string? SelectedFragment { get; set; }

    public void OnFragmentSelected(string fragment)
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
        await AppResponsive.ListenForResponsiveChanges(async (ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }

}