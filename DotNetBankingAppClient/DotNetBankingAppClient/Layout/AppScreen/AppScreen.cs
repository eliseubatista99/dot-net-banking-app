using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AppScreenLogic : ComponentBase
{
    [Parameter]
    public AppHeaderVariant variant { get; set; } = AppHeaderVariant.Light;

    [Parameter]
    public string title { get; set; } = "";

    [Parameter]
    public bool withoutHeader { get; set; } = false;

    [Parameter]
    public Action? onClickBack { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? pageStyles { get; set; }

    [Parameter]
    public string? contentStyles { get; set; }
}