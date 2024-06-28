using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Providers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SearchFragmentLogic : ComponentBase
{
    [Inject]
    protected IStoreProvider Store { get; set; } = default!;
    [Inject]
    protected IAppNavigationProvider NavManager { get; set; } = default!;
}