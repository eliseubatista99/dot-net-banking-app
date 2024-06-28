using DotNetBankingAppClient.Services;
using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class AccountsCarouselLogic : ComponentBase
{
    [Inject]
    public IAppLogger Logger { get; set; } = default!;

    [Inject]
    public IAppResponsive AppResponsive { get; set; } = default!;

    [Parameter]
    public required Action<int> OnChange { get; set; }

    [Parameter]
    public required int Value { get; set; } = 0;

    [Parameter]
    public required List<AccountDTO> Items { get; set; } = new List<AccountDTO>();

    [Parameter]
    public int? Gap { get; set; } = 20;

    [Parameter]
    public string? Classes { get; set; }

    public int ItemWidth { get; set; } = 300;

    [Parameter]
    public bool FullWidthItem { get; set; } = true;

    public List<AccountDTO> GetItems()
    {
        return Items ?? new List<AccountDTO>();
    }

    public void HandleOnChange(int index)
    {
        var newIndex = index;

        if (newIndex < 0)
        {
            newIndex = 0;
        }
        else if (Items != null && newIndex > Items.Count - 1)
        {
            newIndex = Items.Count - 1;
        }

        OnChange(newIndex);
    }
}