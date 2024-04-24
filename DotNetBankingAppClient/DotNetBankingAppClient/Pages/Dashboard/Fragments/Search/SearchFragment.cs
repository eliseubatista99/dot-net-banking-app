using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SearchFragmentLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected NavigationManager NavManager { get; set; } = default!;
}