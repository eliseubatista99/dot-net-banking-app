namespace DotNetBankingAppApi.Models._Base
{
    public enum Language
    {
        English,
        Portuguese,
    }

    public class BaseEndpointInputMetaData
    {
        public Language Language { get; set; }
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
        public string Token { get; set; } = "";
    }

    public class BaseEndpointOutput<T>
    {
        public T? Data { get; set; }
        public BaseEndpointOutputMetaData? MetaData { get; set; }

        public BaseEndpointOutput()
        {
            Data = default;
            MetaData = new BaseEndpointOutputMetaData
            {
                Success = true,
                Message = "",
            };
        }

        public void SetData(T data)
        {
            Data = data;
        }

        public void SetError(string error)
        {
            MetaData.Success = false;
            MetaData.Message = error;
        }
    }
}
