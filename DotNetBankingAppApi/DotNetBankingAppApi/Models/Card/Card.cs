using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public enum CardType
{
    Credit,
    Debit,
    PrePaid,
}

public class Card
{
    [Key]
    public string CardId { get; set; } = "";
    [Required]
    public string AccountId { get; set; } = "";
    [Required]
    public string CardName { get; set; } = "";
    [Required]
    public CardType CardType { get; set; } = CardType.Credit;
    public string Embossing { get; set; } = "";
}
