using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public enum TypographyColor
{
    Default,
    Highlight,
    Error,
}

public enum TypographyOverflow
{
    Ellipsis,
    LineBreak,
}

public class TypographyLogic : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? styles { get; set; }

    [Parameter]
    public TypographyOverflow overflowMode { get; set; } = TypographyOverflow.LineBreak;

    [Parameter]
    public TypographyColor color { get; set; } = TypographyColor.Default;


    public string GetClassName()
    {
        string className = "typography";

        if (overflowMode == TypographyOverflow.Ellipsis)
        {
            className += " ellipsis";
        }

        if (color == TypographyColor.Highlight)
        {
            className += " highlight";
        }
        else if (color == TypographyColor.Error)
        {
            className += " error";
        }

        return className;
    }
}