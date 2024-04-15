using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public class AccountDTO
{
    public string AccountId { get; set; } = "";
    public string AccountName { get; set; } = "";
    public AccountType AccountType { get; set; } = AccountType.Checking;
    public double Balance { get; set; }
    public double Interest { get; set; }


    public static AccountDTO ToDTO(Account data)
    {
        return new AccountDTO { AccountId = data.AccountId, AccountName = data.AccountName, AccountType = data.AccountType, Balance = data.Balance, Interest = data.Interest };
    }

    public static Account FromDTO(AccountDTO data)
    {
        return new Account { AccountId = data.AccountId, AccountName = data.AccountName, AccountType = data.AccountType, Balance = data.Balance, Interest = data.Interest };
    }
}