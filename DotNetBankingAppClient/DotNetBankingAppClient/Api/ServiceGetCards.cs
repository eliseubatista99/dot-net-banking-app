using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

public class ServiceGetCardsOutput
{
    public required List<CardDTO> Cards { get; set; }

}

[DataContract]
public class ServiceGetCardsInput
{
    [DataMember]
    public required string AccountID { get; set; }
}

