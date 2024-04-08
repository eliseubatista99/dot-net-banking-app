using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Layout;

public enum AppHeaderVariant
{
    Light,
    Dark,
}

public class AppHeaderLogic : ComponentBase
{
    [Parameter]
    public string styles { get; set; } = "";

    [Parameter]
    public AppHeaderVariant variant { get; set; } = AppHeaderVariant.Light;

    [Parameter]
    public Action? onClickBack { get; set; }

    [Parameter]
    public string title { get; set; } = "";

    public string GetClassName()
    {
        if (variant == AppHeaderVariant.Dark)
        {
            return "app-header dark";
        }

        return "app-header";
    }

    public void HandleOnClickBack()
    {
        if (onClickBack != null)
        {
            onClickBack();
        }
    }
}