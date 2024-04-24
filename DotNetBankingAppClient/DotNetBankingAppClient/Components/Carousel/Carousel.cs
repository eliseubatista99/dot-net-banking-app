using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class CarouselLogic : ComponentBase
{
    [Parameter]
    public Action<int, object>? OnChange { get; set; }

    [Parameter]
    public required RenderFragment Elements { get; set; }

    [Parameter]
    public string? Classes { get; set; }
}