using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace DotNetBankingAppClient.Pages;

public class DashboardPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    [Inject]
    protected HttpClient httpClient { get; set; } = default!;

    public UserDTO? user;

}