using DotNetBankingAppClientContracts.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class CardsTabNavigationLogic : ComponentBase
{
    [Parameter]
    public CardType SelectedCardType { get; set; } = CardType.Debit;

    [Parameter]
    public required Action<CardType> OnTabClicked { get; set; }

    public CardType[] tabs = [CardType.Debit, CardType.Credit, CardType.PrePaid];

    public void OnClickTab(CardType tab)
    {
        if (OnTabClicked != null)
        {
            OnTabClicked(tab);
        }
    }


}