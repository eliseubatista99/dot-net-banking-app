using DotNetBankingAppClient.Services;

namespace DotNetBankingAppClient.Dtos.Api
{
    public class BaseEndpointOutputDto<T>
    {
        public T? Data { get; set; }
        public required BaseEndpointOutputMetaData? MetaData { get; set; }
    }
}
