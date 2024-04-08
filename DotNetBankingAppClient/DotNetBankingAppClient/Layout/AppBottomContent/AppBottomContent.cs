using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AppBottomContentLogic : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? styles { get; set; }
}