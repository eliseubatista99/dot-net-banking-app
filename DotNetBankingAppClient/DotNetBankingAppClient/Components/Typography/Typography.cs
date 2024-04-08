using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class TypographyLogic : ComponentBase
{
    [Parameter]
    public string? styles { get; set; }

    [Parameter]
    public string text { get; set; } = "";
}