using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class DashboardTemplateLogic : ComponentBase
{
    [Inject]
    protected IWindowHelper windowHelper { get; set; } = default!;

    public ResponsiveWindowSize windowSize = ResponsiveWindowSize.Mobile;

    [Parameter]
    public bool? showHeaderOnMobile { get; set; } = false;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await windowHelper.ListenForResponsiveChanges(async (ResponsiveWindowSize size) =>
        {
            windowSize = size;
            this.StateHasChanged();
        });
    }

}