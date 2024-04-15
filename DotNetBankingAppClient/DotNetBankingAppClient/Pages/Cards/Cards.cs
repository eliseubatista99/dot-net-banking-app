using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Pages;

public class CardsPageLogic : ComponentBase
{
    [Inject]
    protected IBrowserStorage browserStorage { get; set; } = default!;
    [Inject]
    protected NavigationManager navManager { get; set; } = default!;

    public bool isFetching { get; set; } = false;
    public CardType selectedCardType { get; set; } = CardType.Debit;
    public List<CardDTO> debitCards { get; set; } = new List<CardDTO>();
    public List<CardDTO> creditCards { get; set; } = new List<CardDTO>();
    public List<CardDTO> prePaidCards { get; set; } = new List<CardDTO>();

    public void OnClickBack()
    {
        navManager.NavigateTo(uri: AppPages.Home, replace: true);
    }

    public void OnClickTab(CardType tab)
    {
        selectedCardType = tab;
        this.StateHasChanged();
    }


    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        var cards = await browserStorage.GetFromLocalStorage<List<CardDTO>>(StoreKeys.Cards);
        debitCards = cards.Where((card) => card.CardType == CardType.Debit).ToList();
        creditCards = cards.Where((card) => card.CardType == CardType.Credit).ToList();
        creditCards = cards.Where((card) => card.CardType == CardType.PrePaid).ToList();

        isFetching = false;
        this.StateHasChanged();
    }
}