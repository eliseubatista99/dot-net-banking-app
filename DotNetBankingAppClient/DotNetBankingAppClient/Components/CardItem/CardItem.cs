using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class CardItemLogic : ComponentBase
{
    [Parameter]
    public required CardDTO Card { get; set; }

    [Parameter]
    public Action? OnClick { get; set; }

    public bool IsHovered { get; set; } = false;

    [Parameter]
    public string Classes { get; set; } = "";

    public void HandleOnItemClicked()
    {
        if (OnClick != null)
        {
            OnClick();
        }
    }

    public void HandleOnItemHovered()
    {
        IsHovered = true;
        this.StateHasChanged();
    }

    public void HandleOnItemUnhovered()
    {
        IsHovered = false;
        this.StateHasChanged();
    }

    public string GetCardName(CardTier tier)
    {
        return tier.ToString();
    }

}