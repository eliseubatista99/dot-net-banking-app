namespace DotNetBankingAppClient.Services
{


    public interface IApiCommunication
    {
        public Task<BaseEndpointOutput<TOutput?>> CallService<TInput, TOutput>(string endpoint, TInput input);
    }
}
