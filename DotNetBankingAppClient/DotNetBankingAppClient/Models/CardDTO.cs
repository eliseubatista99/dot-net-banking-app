namespace DotNetBankingAppClient.Models;

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


public class CardDTO
{
    public string CardId { get; set; } = "";
    public string AccountId { get; set; } = "";
    public CardTier CardTier { get; set; } = CardTier.Classic;
    public CardType CardType { get; set; } = CardType.Credit;
    public string Embossing { get; set; } = "";
}
