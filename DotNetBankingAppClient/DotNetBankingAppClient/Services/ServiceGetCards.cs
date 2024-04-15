using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services;

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

public class ServiceGetCards
{
    public static async Task<ApiResponse<ServiceGetCardsOutput>> CallAsync(ServiceGetCardsInput input)
    {
        return await ApiServices.Instance.CallService<ServiceGetCardsInput, ServiceGetCardsOutput>("GetCards", input);
    }
}
