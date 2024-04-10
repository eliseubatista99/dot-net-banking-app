using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardLayoutLogic : LayoutComponentBase
{
    
    [Inject]
    protected IWindowHelper windowHelper { get; set; } = default!;

    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    protected override async Task OnInitializedAsync()
    {
        await windowHelper.ListenForResponsiveChanges(async (ResponsiveWindowSize size) => { 
            windowSize = size;
            this.StateHasChanged(); 
        });
    }

}