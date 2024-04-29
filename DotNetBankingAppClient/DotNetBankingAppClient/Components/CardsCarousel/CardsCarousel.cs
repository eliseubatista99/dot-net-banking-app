using DotNetBankingAppClient.Models;
using DotNetBankingAppClient.Services;
using Microsoft.AspNetCore.Components;

namespace DotNetBankingAppClient.Components;

public class CardsCarouselLogic : ComponentBase
{
    [Inject]
    public IAppLogger Logger { get; set; } = default!;

    [Parameter]
    public required Action<int> OnChange { get; set; }

    [Parameter]
    public required int SelectedCard { get; set; } = 0;

    [Parameter]
    public required List<CardDTO> Cards { get; set; } = new List<CardDTO>();

    [Parameter]
    public int? Gap { get; set; } = 20;


    [Parameter]
    public string? Classes { get; set; }

    [Parameter]
    public int ItemWidth { get; set; } = 300;

    public List<CardDTO> GetCards()
    {
        return Cards ?? new List<CardDTO>();
    }

    public void HandleOnChange(int index)
    {
        var newIndex = index;

        if (newIndex < 0)
        {
            newIndex = 0;
        }
        else if (Cards != null && newIndex > Cards.Count - 1)
        {
            newIndex = Cards.Count - 1;
        }

        OnChange(newIndex);
    }
}