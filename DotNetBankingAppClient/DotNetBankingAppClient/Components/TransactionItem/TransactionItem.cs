using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class TransactionItemLogic : ComponentBase
{
    [Parameter]
    public required TransactionDTO Value { get; set; }

    [Parameter]
    public Action? OnClick { get; set; }

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
}