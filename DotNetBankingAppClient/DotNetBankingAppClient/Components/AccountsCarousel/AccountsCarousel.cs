using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AccountsCarouselLogic : ComponentBase
{
    [Inject]
    public IAppLogger Logger { get; set; } = default!;

    [Parameter]
    public required Action<int> OnChange { get; set; }

    [Parameter]
    public required int Value { get; set; } = 0;

    [Parameter]
    public required List<CardDTO> Items { get; set; } = new List<CardDTO>();

    [Parameter]
    public int? Gap { get; set; } = 20;


    [Parameter]
    public string? Classes { get; set; }

    [Parameter]
    public int ItemWidth { get; set; } = 300;


    public List<CardDTO> GetItems()
    {
        return Items ?? new List<CardDTO>();
    }
}