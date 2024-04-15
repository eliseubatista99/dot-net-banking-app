using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SettingsPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;
}