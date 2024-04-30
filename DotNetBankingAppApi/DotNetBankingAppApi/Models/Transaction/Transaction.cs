// Ignore Spelling: Iban

using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public enum TransactionType
{
    Whitdrawal,
    Debit,
    Credit,
}

public enum TransactionMethod
{
    Card,
    Homebanking,
}

public class Transaction
{
    [Key]
    public string Id { get; set; } = "";
    [Required]
    public double Amount { get; set; } = 0;
    [Required]
    public string Description { get; set; } = "";
    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;
    [Required]
    public TransactionType TransactionType { get; set; } = TransactionType.Debit;
    public string? Entity { get; set; } = "";
    public string? ReceiverAccount { get; set; } = "";
    public string? SenderAccount { get; set; } = "";
    public string? Comment { get; set; } = "";
    [Required]
    public double BalanceBeforeTransaction { get; set; } = 0;
    [Required]
    public double BalanceAfterTransaction { get; set; } = 0;
    public TransactionMethod? Method { get; set; } = TransactionMethod.Homebanking;
    public string? CardNumber { get; set; } = "";

}
