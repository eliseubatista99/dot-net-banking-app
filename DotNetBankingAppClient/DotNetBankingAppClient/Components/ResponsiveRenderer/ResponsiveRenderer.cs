using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class ResponsiveRendererLogic : ComponentBase
{
    [Inject]
    public IAppLogger Logger { get; set; } = default!;
    [Inject]
    public IAppResponsive AppResponsive { get; set; } = default!;

    [Inject]
    public IStore Store { get; set; } = default!;

    [Parameter]
    public required RenderFragment MobileContent { get; set; }
    [Parameter]
    public RenderFragment? TabletContent { get; set; }
    [Parameter]
    public RenderFragment? DesktopContent { get; set; }

    public ResponsiveWindowSize WindowSize = ResponsiveWindowSize.Mobile;

    private async void OnResponsiveChange(ResponsiveWindowSize size)
    {
        WindowSize = size;

        await Store.CacheData(StoreKeys.Responsive, size);

        await Logger.Log("ResponsiveRenderer > Size: " + size);

        this.StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        await AppResponsive.ListenForResponsiveChanges((ResponsiveWindowSize size) =>
        {
            OnResponsiveChange(size);
        });
    }
}