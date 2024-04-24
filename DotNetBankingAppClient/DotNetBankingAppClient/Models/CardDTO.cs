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

    public string GetCardColors()
    {
        switch (CardTier)
        {
            case CardTier.Premium:
                if (CardType == CardType.Credit)
                {
                    return "linear-gradient(60deg, #b73054 40%, #a1a1a1)";
                }
                else if (CardType == CardType.PrePaid)
                {
                    return "linear-gradient(60deg, #309db7 40%, #a1a1a1)";
                }
                else
                {
                    return "linear-gradient(60deg, #f9af00 30%, #a1a1a1)";
                }
            case CardTier.Carbon:
                if (CardType == CardType.Credit)
                {
                    return "linear-gradient(60deg, #ab2424 10%, #c76157 35%, #701c71 100%)";
                }
                else if (CardType == CardType.PrePaid)
                {
                    return "linear-gradient(60deg, #2491ab 10%, #575fc7 35%, #1c6071 100%)";
                }
                else
                {
                    return "linear-gradient(60deg, #bb7a16 10%, #d99d12 35%, #756826 100%)";
                }
            case CardTier.Stellar:
                if (CardType == CardType.Credit)
                {
                    return "linear-gradient(60deg, #ab5d24 0%, #8d1313 30%, #bd1449 50%, #ad672b 81%, #470808 93%, #bd1414 100%)";
                }
                else if (CardType == CardType.PrePaid)
                {
                    return "linear-gradient(60deg, #2491ab 0%, #132d8d 30%, #1466bd 50%, #2b89ad 81%, #080c47 93%, #1428bd 100%)";
                }
                else
                {
                    return "linear-gradient(60deg, #ab9c24 0%, #5f270d 30%, #cfa016 50%, #ad912b 81%, #853f0c 93%, #bd5a14 100%)";
                }
            default:
                if (CardType == CardType.Credit)
                {
                    return "linear-gradient(60deg, #b73061, #d14155)";
                }
                else if (CardType == CardType.PrePaid)
                {
                    return "linear-gradient(60deg, #309db7, #41b5d1)";
                }
                else
                {
                    return "linear-gradient(60deg, #f9af00, #e5c900)";
                }
        }
    }
}
