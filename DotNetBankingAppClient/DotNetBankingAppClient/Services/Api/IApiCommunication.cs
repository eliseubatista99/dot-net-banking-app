using DotNetBankingAppClientContracts.Dtos.Api;

namespace DotNetBankingAppClient.Services
{


    public interface IApiCommunication
    {
        public Task<BaseEndpointOutputDto<TOutput?>> CallService<TInput, TOutput>(string endpoint, TInput input);
    }
}
