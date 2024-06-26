﻿using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public enum TypographyColor
{
    DefaultLight,
    DefaultDark,
    Default02,
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
    public string? classes { get; set; } = "";

    [Parameter]
    public string? Styles { get; set; } = "";

    [Parameter]
    public Action? OnClick { get; set; }

    [Parameter]
    public TypographyOverflow overflowMode { get; set; } = TypographyOverflow.LineBreak;

    [Parameter]
    public TypographyColor color { get; set; } = TypographyColor.DefaultLight;


    public string GetClasses()
    {
        string result = "";
        if (overflowMode == TypographyOverflow.Ellipsis)
        {
            result += " typography-overflow-ellipsis";
        }

        switch (color)
        {
            case TypographyColor.DefaultDark:
                result += " typography-color-dark";
                break;
            case TypographyColor.Highlight:
                result += " typography-color-highlight";
                break;
            case TypographyColor.Error:
                result += " typography-color-error";
                break;
            case TypographyColor.Default02:
                result += " typography-color-default-02";
                break;
            default:
                break;
        }

        result += " " + classes;

        return result;
    }
}