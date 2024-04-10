using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AppLoaderLogic : ComponentBase
{
    [Parameter]
    public string classes { get; set; } = "";
}