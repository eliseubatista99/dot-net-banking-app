﻿using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class CardsPageLogic : ComponentBase
{
    [Inject]
    protected IStore Store { get; set; } = default!;
    [Inject]
    protected IAppNavigation NavManager { get; set; } = default!;

    public bool IsFetching { get; set; } = false;
    public CardType SelectedCardType { get; set; } = CardType.Debit;
    private List<CardDTO> DebitCards { get; set; } = new List<CardDTO>();
    private List<CardDTO> CreditCards { get; set; } = new List<CardDTO>();
    private List<CardDTO> PrePaidCards { get; set; } = new List<CardDTO>();

    public int SelectedCard { get; set; } = 0;


    public void OnClickBack()
    {
        NavManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
    }

    public void OnClickTab(CardType tab)
    {
        SelectedCardType = tab;
        this.StateHasChanged();
    }

    public List<CardDTO> GetCards()
    {
        if (SelectedCardType == CardType.Credit)
        {
            return CreditCards;
        }
        else if (SelectedCardType == CardType.PrePaid)
        {
            return PrePaidCards;
        }

        return DebitCards;
    }

    public void OnCardSelected(int index)
    {
        var newIndex = index;
        var currentCards = GetCards();

        if (newIndex < 0)
        {
            newIndex = 0;
        }
        else if (currentCards != null && newIndex > currentCards.Count - 1)
        {
            newIndex = currentCards.Count - 1;
        }
        SelectedCard = newIndex;
        this.StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        IsFetching = true;
        this.StateHasChanged();
        var cards = await Store.GetCachedData<List<CardDTO>>(StoreKeys.Cards);
        DebitCards = cards.Where((card) => card.CardType == CardType.Debit).ToList();
        CreditCards = cards.Where((card) => card.CardType == CardType.Credit).ToList();
        PrePaidCards = cards.Where((card) => card.CardType == CardType.PrePaid).ToList();

        IsFetching = false;
        this.StateHasChanged();
    }


}