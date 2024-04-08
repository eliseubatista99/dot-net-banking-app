﻿using DotNetBankingAppClient.Helpers;
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

    public bool isFetching = false;
    public string userName = "";
    public string password = "";

    public string? errorMessage = null;


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
        errorMessage = null;
        this.StateHasChanged();

        var result = await ServiceSignIn.CallAsync(new ServiceSignInInput
        {
            UserName = userName,
            Password = password,
        });

        if (result.Metadata.Success)
        {
            await browserStorage.SetInLocalStorage("user", result?.Data?.User);
            await browserStorage.SetInSessionStorage("token", result?.Data?.Token);

            navManager.NavigateTo("/dashboard");
        }
        else
        {
            errorMessage = result.Metadata.Message;
            isFetching = false;
            this.StateHasChanged();
        }
    }

    public void OnClickSignUpLink()
    {
        navManager.NavigateTo("/signUp");
    }
}