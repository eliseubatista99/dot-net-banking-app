namespace DotNetBankingAppApi.Models
{
    public class ApiResponseMetadata
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }

    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public ApiResponseMetadata? Metadata { get; set; }

        public ApiResponse()
        {
            Data = default;
            Metadata = new ApiResponseMetadata
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
            Metadata.Success = false;
            Metadata.Message = error;
        }
    }
}
