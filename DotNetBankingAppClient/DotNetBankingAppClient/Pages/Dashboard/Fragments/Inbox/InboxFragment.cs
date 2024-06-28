﻿using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Dtos.Api;
using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class InboxFragmentLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IApiCommunication ApiCommunication { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    public bool IsFetching = false;
    private UserDTO? CurrentUser;
    public List<MessageDTOGroup> GroupedMessages { get; set; } = new List<MessageDTOGroup>();

    public async void OnMessageClicked(MessageDTO message)
    {
        IsFetching = true;
        this.StateHasChanged();
        await Store.CacheData(StoreKeys.SelectedMessage, message);

        NavManager.NavigateTo(AppPages.InboxMessageDetails, replace: true);
    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;
        this.StateHasChanged();
        CurrentUser = await Store.GetData<UserDTO>(StoreKeys.User);

        var result = await ApiCommunication.CallService<GetInboxOperationInput, GetInboxOperationOutput>(ApiEndpoints.GetInbox, new GetInboxOperationInput { UserName = CurrentUser.UserName });

        if (result.MetaData.Success)
        {
            GroupedMessages = result.Data?.GroupedMessages ?? new List<MessageDTOGroup>();
            IsFetching = false;
            this.StateHasChanged();
        }
        else
        {
            IsFetching = false;
            this.StateHasChanged();
        }
    }
}