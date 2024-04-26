using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class CarouselLogic : ComponentBase
{
    [Parameter]
    public Action<int, object>? OnChange { get; set; }

    [Parameter]
    public RenderFragment Elements { get; set; }

    [Parameter]
    public string? Classes { get; set; }
    [Parameter]
    public Func<RenderFragment>? RenderContent { get; set; }

    public RenderFragment? RenderCarouselItem()
    {
        if (RenderContent != null)
        {
            return RenderContent();
        }

        return null;
    }
}