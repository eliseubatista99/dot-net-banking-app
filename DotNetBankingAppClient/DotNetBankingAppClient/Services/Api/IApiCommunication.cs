namespace DotNetBankingAppClient.Services
{
    public enum Language
    {
        English,
        Portuguese,
    }

    public class BaseEndpointInputMetaData
    {
        public Language Language { get; set; }
        public string? Token { get; set; }

    }

    public class BaseEndpointOutputMetaData
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }

    public class BaseEndpointInput<T>
    {
        public required T Data { get; set; }
        public required BaseEndpointInputMetaData MetaData { get; set; }
    }

    public class BaseEndpointOutput<T>
    {
        public T? Data { get; set; }
        public required BaseEndpointOutputMetaData? MetaData { get; set; }
    }


    public interface IApiCommunication
    {
        public Task<BaseEndpointOutput<TOutput?>> CallService<TInput, TOutput>(string endpoint, TInput input);
    }
}
