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
    private List<CardDTO> debitCards { get; set; } = new List<CardDTO>();
    private List<CardDTO> creditCards { get; set; } = new List<CardDTO>();
    private List<CardDTO> prePaidCards { get; set; } = new List<CardDTO>();

    public void OnClickBack()
    {
        navManager.NavigateTo(uri: AppPages.Dashboard + "/" + DashboardFragments.Home, replace: true);
    }

    public void OnClickTab(CardType tab)
    {
        selectedCardType = tab;
        this.StateHasChanged();
    }

    public List<CardDTO> GetCards()
    {
        if (selectedCardType == CardType.Credit)
        {
            return creditCards;
        }
        else if (selectedCardType == CardType.PrePaid)
        {
            return prePaidCards;
        }

        return debitCards;
    }


    protected override async Task OnInitializedAsync()
    {
        isFetching = true;
        this.StateHasChanged();
        var cards = await browserStorage.GetFromLocalStorage<List<CardDTO>>(StoreKeys.Cards);
        debitCards = cards.Where((card) => card.CardType == CardType.Debit).ToList();
        creditCards = cards.Where((card) => card.CardType == CardType.Credit).ToList();
        prePaidCards = cards.Where((card) => card.CardType == CardType.PrePaid).ToList();

        isFetching = false;
        this.StateHasChanged();
    }


}