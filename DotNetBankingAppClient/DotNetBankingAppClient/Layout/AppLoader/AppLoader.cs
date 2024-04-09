using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Layout;

public class AppLoaderLogic : ComponentBase
{
    [Parameter]
    public string classes { get; set; } = "";
}