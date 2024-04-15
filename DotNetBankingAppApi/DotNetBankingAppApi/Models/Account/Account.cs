using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public enum AccountType
{
    Checking,
    Savings,
}

public class Account
{
    [Key]
    public string AccountId { get; set; } = "";

    [Required]
    public string UserName { get; set; } = "";

    [Required]
    public string AccountName { get; set; } = "";

    [Required]
    public AccountType AccountType { get; set; } = AccountType.Checking;

    [DataType(DataType.Currency)]
    public double Balance { get; set; }

    public double Interest { get; set; }
}
