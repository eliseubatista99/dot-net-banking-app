﻿using DotNetBankingAppClientContracts.Constants;
using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Dtos.Api;
using DotNetBankingAppClientContracts.Models;
using DotNetBankingAppClientContracts.Providers;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class SignInPageLogic : ComponentBase
{
    [Inject]
    protected IStoreProvider Store { get; set; } = default!;
    [Inject]
    protected IApiProvider ApiProvider { get; set; } = default!;
    [Inject]
    protected IAppNavigationProvider NavManager { get; set; } = default!;

    public bool isFetching = false;
    public string userName = "";
    public string password = "";

    public string? errorMessage = null;


    protected override async Task OnInitializedAsync()
    {
        UserDTO user = await Store.GetData<UserDTO>(StoreKeys.User);
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

        var result = await ApiProvider.SignIn(new SignInOperationInput
        {
            UserName = userName,
            Password = password,
        });

        if (result.MetaData.Success)
        {
            await Store.PersistData(StoreKeys.User, result?.Data?.User);
            await Store.CacheData(StoreKeys.AuthToken, result?.Data?.Token);

            NavManager.NavigateTo(AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
        }
        else
        {
            errorMessage = result.MetaData.Message;
            isFetching = false;
            this.StateHasChanged();
        }
    }

    public void OnClickSignUpLink()
    {
        NavManager.NavigateTo(AppPages.SignUp, replace: true);
    }
}