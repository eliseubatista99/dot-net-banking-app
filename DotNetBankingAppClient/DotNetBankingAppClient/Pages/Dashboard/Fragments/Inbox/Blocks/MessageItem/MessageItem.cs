using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class MessageItemLogic : ComponentBase
{
    [Parameter]
    public MessageDTO? message { get; set; }
    [Parameter]
    public Action onClickItem { get; set; } = default!;
}