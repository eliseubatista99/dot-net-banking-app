using DotNetBankingAppClient.Components;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace DotNetBankingAppClient.Layout;

public enum AppHeaderVariant
{
    Light,
    Dark,
}

public class AppHeaderLogic : ComponentBase
{
    [Parameter]
    public string classes { get; set; } = "";

    [Parameter]
    public AppHeaderVariant variant { get; set; } = AppHeaderVariant.Light;

    [Parameter]
    public Action? onClickBack { get; set; }

    [Parameter]
    public string title { get; set; } = "";

    public string GetClasses()
    {
        string result = "";
        if (variant == AppHeaderVariant.Dark)
        {
            result += " app-header-dark";
        }

        result += " " + classes;

        return result;
    }


    public void HandleOnClickBack()
    {
        if (onClickBack != null)
        {
            onClickBack();
        }
    }


}