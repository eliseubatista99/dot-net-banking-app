using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class AccountsData
{
    public static async Task<List<AccountDTO>> GetAccountsOfUser(DatabaseContext context, string username)
    {
        var accounts = await context.Accounts.Where((a) => a.UserName == username).ToListAsync();

        if (accounts == null)
        {
            return new List<AccountDTO>();
        }

        return accounts.Select((a) => AccountDTO.FromAccount(a)).ToList();
    }

    public static async Task<AccountDTO> AddAccountToUser(DatabaseContext context, AccountDTO accountDTO, string username)
    {
        var account = AccountDTO.ToAccount(accountDTO);

        account.UserName = username;

        context.Accounts.Add(account);
        await context.SaveChangesAsync();

        return AccountDTO.FromAccount(account);
    }
}