using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;
public class CardsData
{
    public static async Task<List<CardDTO>> GetCardsOfAccounts(DatabaseContext context, string accountID)
    {
        var result = await context.Cards.Where((item) => item.AccountId == accountID).ToListAsync();

        if (result == null)
        {
            return new List<CardDTO>();
        }

        return result.Select((item) => CardDTO.ToDTO(item)).ToList();
    }

    public static async Task<CardDTO> AddCardToAccount(DatabaseContext context, CardDTO data)
    {
        var dataToAdd = CardDTO.FromDTO(data);

        context.Cards.Add(dataToAdd);
        await context.SaveChangesAsync();

        return CardDTO.ToDTO(dataToAdd);
    }
}