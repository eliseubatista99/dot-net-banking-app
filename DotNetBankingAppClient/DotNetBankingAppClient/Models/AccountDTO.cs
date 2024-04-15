
namespace DotNetBankingAppClient.Models;

public enum AccountType
{
    Checking,
    Savings,
}

public class AccountDTO
{
    public string AccountId { get; set; } = "";
    public string AccountName { get; set; } = "";
    public AccountType AccountType { get; set; } = AccountType.Checking;
    public double Balance { get; set; }
    public double Interest { get; set; }
}