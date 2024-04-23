using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class CardItemLogic : ComponentBase
{
    [Parameter]
    public required CardDTO card { get; set; }

    [Parameter]
    public Action? onClick { get; set; }

    public bool isHovered { get; set; } = false;

    public void HandleOnItemClicked()
    {
        if (onClick != null)
        {
            onClick();
        }
    }

    public void HandleOnItemHovered()
    {
        isHovered = true;
        this.StateHasChanged();
    }

    public void HandleOnItemUnhovered()
    {
        isHovered = false;
        this.StateHasChanged();
    }
}