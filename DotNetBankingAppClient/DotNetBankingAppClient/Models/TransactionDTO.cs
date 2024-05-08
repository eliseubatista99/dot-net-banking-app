namespace DotNetBankingAppClient.Models;

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

public class TransactionDTO
{
    public string Id { get; set; } = "";
    public double Amount { get; set; } = 0;
    public string Description { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public TransactionType TransactionType { get; set; } = TransactionType.Debit;
    public string? Entity { get; set; } = "";
    public string? ReceiverAccount { get; set; } = "";
    public string? SenderAccount { get; set; } = "";
    public string? Comment { get; set; } = "";
    public double BalanceBeforeTransaction { get; set; } = 0;
    public double BalanceAfterTransaction { get; set; } = 0;
    public TransactionMethod? Method { get; set; } = TransactionMethod.Homebanking;
    public string? CardNumber { get; set; } = "";
}

