using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;
public class TransactionsData
{
    public static async Task<List<TransactionDTO>> GetTransactionsOfAccount(DatabaseContext context, string accountID)
    {
        var result = await context.Transactions.Where((item) => item.SenderAccount == accountID || item.ReceiverAccount == accountID).ToListAsync();

        if (result == null)
        {
            return new List<TransactionDTO>();
        }

        return result.Select((item) => TransactionDTO.ToDTO(item)).ToList();
    }

    public static async Task<TransactionDTO> AddTransaction(DatabaseContext context, TransactionDTO data)
    {
        var dataToAdd = TransactionDTO.FromDTO(data);

        context.Transactions.Add(dataToAdd);
        await context.SaveChangesAsync();

        return TransactionDTO.ToDTO(dataToAdd);
    }
}