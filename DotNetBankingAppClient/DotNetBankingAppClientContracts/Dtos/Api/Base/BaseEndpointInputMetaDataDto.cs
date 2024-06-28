using DotNetBankingAppClientContracts.Enums;

namespace DotNetBankingAppClientContracts.Dtos.Api
{
    public class BaseEndpointInputMetaData
    {
        public Language Language { get; set; }
        public string? Token { get; set; }

    }
}
