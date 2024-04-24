using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class AccountsData
{
    public static async Task<List<AccountDTO>> GetAccountsOfUser(DatabaseContext context, string UserName)
    {
        var result = await context.Accounts.Where((item) => item.UserName == UserName).ToListAsync();

        if (result == null)
        {
            return new List<AccountDTO>();
        }

        return result.Select((item) => AccountDTO.ToDTO(item)).ToList();
    }

    public static async Task<AccountDTO> AddAccountToUser(DatabaseContext context, AccountDTO data, string UserName)
    {
        var dataToAdd = AccountDTO.FromDTO(data);

        dataToAdd.UserName = UserName;

        context.Accounts.Add(dataToAdd);
        await context.SaveChangesAsync();

        return AccountDTO.ToDTO(dataToAdd);
    }
}
