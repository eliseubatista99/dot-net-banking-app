using DotNetBankingAppClient.Api;
using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SignUpPageLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IApiCommunication ApiCommunication { get; set; } = default!;
    [Inject]
    protected NavigationManager NavManager { get; set; } = default!;

    public bool IsFetching = false;
    public string UserName = "";
    public string Password = "";
    public string PhoneNumber = "";

    public string? ErrorMessage = null;

    public void OnChangeUserName(string value)
    {
        UserName = value;
        this.StateHasChanged();
    }

    public void OnChangePassword(string value)
    {
        Password = value;
        this.StateHasChanged();
    }

    public void OnChangePhoneNumber(string value)
    {
        PhoneNumber = value;
        this.StateHasChanged();
    }

    public async void OnClickSignUpButton()
    {
        IsFetching = true;
        ErrorMessage = null;
        this.StateHasChanged();

        var result = await ApiCommunication.CallService<ServiceSignUpInput, ServiceSignUpOutput>(ApiEndpoints.SignUp, new ServiceSignUpInput
        {
            UserName = UserName,
            Password = Password,
            PhoneNumber = PhoneNumber,
        });

        if (result.MetaData.Success)
        {
            await Store.PersistData(StoreKeys.User, result?.Data?.User);
            await Store.CacheData(StoreKeys.AuthToken, result?.Data?.Token);

            NavManager.NavigateTo(AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
        }
        else
        {
            ErrorMessage = result.MetaData.Message;
            IsFetching = false;
            this.StateHasChanged();
        }
    }

    public void OnClickSignInLink()
    {
        NavManager.NavigateTo(AppPages.SignIn, replace: true);
    }
}