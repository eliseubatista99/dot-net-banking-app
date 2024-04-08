using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace DotNetBankingAppClient.Pages;

public class LoginPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    [Inject]
    protected HttpClient httpClient { get; set; } = default!;

    public UserDTO? user;
    public bool isFetching = false;
    public string username = "";
    public string password = "";

    protected override async Task OnInitializedAsync()
    {
        user = await browserStorage.GetFromLocalStorage<UserDTO>("user");
        this.StateHasChanged();
    }

    public void onChangeUsername(string value)
    {
        username = value;
        this.StateHasChanged();
    }

    public void onChangePassword(string value)
    {
        password = value;
        this.StateHasChanged();
    }

    public async void onClickLoginButton()
    {
        isFetching = true;
        this.StateHasChanged();

        try
        {
            var result = await ServiceLogin.CallAsync(httpClient, new ServiceLoginInput
            {
                username = username,
                password = password,
            });

            await browserStorage.SetInLocalStorage("user", result.user);
            await browserStorage.SetInSessionStorage("token", result.token);

            isFetching = false;
            navManager.NavigateTo("/dashboard");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Error login > " + e);
            isFetching = false;
            this.StateHasChanged();
        }
    }
}