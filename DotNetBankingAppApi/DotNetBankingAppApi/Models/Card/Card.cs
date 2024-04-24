using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public enum CardType
{
    Credit,
    Debit,
    PrePaid,
}

public enum CardTier
{
    Classic,
    Premium,
    Carbon,
    Stellar,
}

public class Card
{
    [Key]
    public string CardNumber { get; set; } = "";
    [Required]
    public string AccountId { get; set; } = "";
    [Required]
    public CardTier CardTier { get; set; } = CardTier.Classic;
    [Required]
    public CardType CardType { get; set; } = CardType.Credit;
    public string Embossing { get; set; } = "";
}
