namespace DotNetBankingAppApi.Models;

public class CardDTO
{
    public string CardId { get; set; } = "";
    public string AccountId { get; set; } = "";
    public CardTier CardTier { get; set; } = CardTier.Classic;
    public CardType CardType { get; set; } = CardType.Credit;
    public string Embossing { get; set; } = "";

    public static CardDTO ToDTO(Card data)
    {
        return new CardDTO { CardId = data.CardId, AccountId = data.AccountId, CardTier = data.CardTier, CardType = data.CardType, Embossing = data.Embossing };
    }

    public static Card FromDTO(CardDTO data)
    {
        return new Card { CardId = data.CardId, AccountId = data.AccountId, CardTier = data.CardTier, CardType = data.CardType, Embossing = data.Embossing };
    }
}
