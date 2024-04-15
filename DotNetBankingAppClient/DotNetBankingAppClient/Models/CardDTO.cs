using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetBankingAppClient.Models;

public enum CardType
{
    Credit,
    Debit,
    PrePaid,
}


public class CardDTO
{
    public string CardId { get; set; } = "";
    public string AccountId { get; set; } = "";
    public string CardName { get; set; } = "";
    public CardType CardType { get; set; } = CardType.Credit;
    public string Embossing { get; set; } = "";
}
