using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AppButtonLogic : ComponentBase
{
    [Parameter]
    public string? defaultClasses { get; set; }
    [Parameter]
    public string? hoveredClasses { get; set; }

    [Parameter]
    public string text { get; set; } = "Button";

    [Parameter]
    public Action? onClick { get; set; }

    public bool isHovered { get; set; } = false;

    public void HandleOnButtonClicked()
    {
        if (onClick != null)
        {
            onClick();
        }
    }

    public void HandleOnButtonHovered()
    {
        isHovered = true;
        this.StateHasChanged();
    }

    public void HandleOnButtonUnhovered()
    {
        isHovered = false;
        this.StateHasChanged();
    }

    public string GetClasses()
    {
        string result = defaultClasses ?? "";

        if(isHovered)
        {
            result += " " + hoveredClasses;
        }

        return result;
    }
}