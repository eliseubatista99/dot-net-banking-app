using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AccountItemLogic : ComponentBase
{
    [Parameter]
    public required AccountDTO Value { get; set; }

    [Parameter]
    public Action? OnClick { get; set; }

    public bool IsHovered { get; set; } = false;

    [Parameter]
    public string Classes { get; set; } = "";

    [Parameter]
    public string? Styles { get; set; } = "";

    public void HandleOnItemClicked()
    {
        if (OnClick != null)
        {
            OnClick();
        }
    }

    public void HandleOnItemHovered()
    {
        IsHovered = true;
        this.StateHasChanged();
    }

    public void HandleOnItemUnhovered()
    {
        IsHovered = false;
        this.StateHasChanged();
    }

    public string GetAccountType()
    {
        return Value.AccountType == AccountType.Checking ? "Checking" : "Savings";
    }

}