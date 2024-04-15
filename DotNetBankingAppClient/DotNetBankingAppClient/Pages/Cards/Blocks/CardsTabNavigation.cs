using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class CardsTabNavigationLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public bool isFetching { get; set; } = false;
    [Parameter]
    public CardType selectedCardType { get; set; } = CardType.Debit;

    [Parameter]
    public required Action<CardType> onTabClicked { get; set; }

    public CardType[] tabs = [CardType.Debit, CardType.Credit, CardType.PrePaid];

    public void OnClickTab(CardType tab)
    {
        if (onTabClicked != null)
        {
            onTabClicked(tab);
        }
    }


}