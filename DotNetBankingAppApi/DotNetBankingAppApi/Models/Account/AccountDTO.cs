using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public class AccountDTO
{
    public string AccountId { get; set; } = "";
    public string AccountName { get; set; } = "";
    public AccountType AccountType { get; set; } = AccountType.Checking;
    public double Balance { get; set; }
    public double Interest { get; set; }


    public static AccountDTO FromAccount(Account account)
    {
        return new AccountDTO { AccountId = account.AccountId, AccountName = account.AccountName, AccountType = account.AccountType, Balance = account.Balance, Interest = account.Interest };
    }

    public static Account ToAccount(AccountDTO accountDTO)
    {
        return new Account { AccountId = accountDTO.AccountId, AccountName = accountDTO.AccountName, AccountType = accountDTO.AccountType, Balance = accountDTO.Balance, Interest = accountDTO.Interest };
    }
}