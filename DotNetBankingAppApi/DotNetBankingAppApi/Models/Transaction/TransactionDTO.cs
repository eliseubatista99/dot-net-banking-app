// Ignore Spelling: Iban

namespace DotNetBankingAppApi.Models;

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

    public static TransactionDTO ToDTO(Transaction data)
    {
        return new TransactionDTO
        {
            Id = data.Id,
            Amount = data.Amount,
            Description = data.Description,
            Date = data.Date,
            TransactionType = data.TransactionType,
            Entity = data.Entity,
            ReceiverAccount = data.ReceiverAccount,
            SenderAccount = data.SenderAccount,
            Comment = data.Comment,
            BalanceBeforeTransaction = data.BalanceBeforeTransaction,
            BalanceAfterTransaction = data.BalanceAfterTransaction,
            Method = data.Method,
            CardNumber = data.CardNumber
        };
    }

    public static Transaction FromDTO(TransactionDTO data)
    {
        return new Transaction
        {
            Id = data.Id,
            Amount = data.Amount,
            Description = data.Description,
            Date = data.Date,
            TransactionType = data.TransactionType,
            Entity = data.Entity,
            ReceiverAccount = data.ReceiverAccount,
            SenderAccount = data.SenderAccount,
            Comment = data.Comment,
            BalanceBeforeTransaction = data.BalanceBeforeTransaction,
            BalanceAfterTransaction = data.BalanceAfterTransaction,
            Method = data.Method,
            CardNumber = data.CardNumber
        };
    }
}
