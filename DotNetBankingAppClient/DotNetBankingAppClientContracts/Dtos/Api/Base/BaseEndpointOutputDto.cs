namespace DotNetBankingAppClientContracts.Dtos.Api
{
    public class BaseEndpointOutputDto<T>
    {
        public T? Data { get; set; }
        public required BaseEndpointOutputMetaData? MetaData { get; set; }
    }
}
