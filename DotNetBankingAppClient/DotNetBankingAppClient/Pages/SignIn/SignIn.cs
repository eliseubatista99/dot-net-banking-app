using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SignInPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    [Inject]
    protected HttpClient httpClient { get; set; } = default!;

    public bool isFetching = false;
    public string userName = "";
    public string password = "";

    protected override async Task OnInitializedAsync()
    {
        UserDTO user = await browserStorage.GetFromLocalStorage<UserDTO>("user");
        if (user != null)
        {
            userName = user.UserName;
        }
        this.StateHasChanged();
    }

    public void OnChangeUserName(string value)
    {
        userName = value;
        this.StateHasChanged();
    }

    public void OnChangePassword(string value)
    {
        password = value;
        this.StateHasChanged();
    }

    public async void OnClickLoginButton()
    {
        isFetching = true;
        this.StateHasChanged();

        try
        {
            var result = await ServiceLogin.CallAsync(httpClient, new ServiceLoginInput
            {
                UserName = userName,
                Password = password,
            });

            await browserStorage.SetInLocalStorage("user", result?.User);
            await browserStorage.SetInSessionStorage("token", result?.Token);

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

    public void OnClickSignUp()
    {
        navManager.NavigateTo("/signup");
    }
}