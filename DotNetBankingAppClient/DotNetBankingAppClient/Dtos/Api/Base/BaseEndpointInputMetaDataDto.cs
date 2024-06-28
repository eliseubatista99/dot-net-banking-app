using DotNetBankingAppClient.Services;

namespace DotNetBankingAppClient.Dtos.Api
{
    public class BaseEndpointInputMetaData
    {
        public Language Language { get; set; }
        public string? Token { get; set; }

    }
}
