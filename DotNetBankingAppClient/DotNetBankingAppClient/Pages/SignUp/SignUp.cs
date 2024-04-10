using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SignUpPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public bool isFetching = false;
    public string userName = "";
    public string password = "";
    public string phoneNumber = "";

    public string? errorMessage = null;

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

    public void OnChangePhoneNumber(string value)
    {
        phoneNumber = value;
        this.StateHasChanged();
    }

    public async void OnClickSignUpButton()
    {
        isFetching = true;
        errorMessage = null;
        this.StateHasChanged();

        var result = await ServiceSignUp.CallAsync(new ServiceSignUpInput
        {
            UserName = userName,
            Password = password,
            PhoneNumber = phoneNumber,
        });

        if (result.Metadata.Success)
        {
            await browserStorage.SetInLocalStorage("user", result?.Data?.User);
            await browserStorage.SetInSessionStorage("token", result?.Data?.Token);

            navManager.NavigateTo(AppPages.Home);
        }
        else
        {
            errorMessage = result.Metadata.Message;
            isFetching = false;
            this.StateHasChanged();
        }
    }

    public void OnClickSignInLink()
    {
        navManager.NavigateTo(AppPages.SignIn);
    }
}