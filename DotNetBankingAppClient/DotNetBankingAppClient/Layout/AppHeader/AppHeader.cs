using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public enum AppHeaderVariant { 
    Light,
    Dark,
}

public class AppHeaderLogic : ComponentBase
{


    [Parameter]
    public AppHeaderVariant variant { get; set; } = AppHeaderVariant.Light;

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
}