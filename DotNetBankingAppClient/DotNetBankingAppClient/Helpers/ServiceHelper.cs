using System.Text;
using System.Text.Json;

namespace DotNetBankingAppClient.Helpers
{
    public class ApiResponseMetaData
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }

    public class ApiResponse<T>
    {
        public required T? Data { get; set; }
        public required ApiResponseMetaData MetaData { get; set; }
    }


    public interface IApiServices
    {
        public Task<ApiResponse<TOutput?>> CallService<TInput, TOutput>(string endpoint, TInput input);
    }

    public class ApiServices : IApiServices
    {
        public static ApiServices Instance { get; private set; }
        private readonly HttpClient _httpClient;

        private ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static void Initialize(HttpClient httpClient)
        {
            if (Instance == null)
            {
                Instance = new ApiServices(httpClient);
            }
        }

        public async Task<ApiResponse<TOutput>> CallService<TInput, TOutput>(string endpoint, TInput input)
        {
            try
            {
                string jsonInput = JsonSerializer.Serialize(input);
                var serviceBody = new StringContent(jsonInput, Encoding.UTF8, "application/json");
                var serviceResponse = await _httpClient.PostAsync(endpoint, serviceBody);
                var serviceResponseContent = serviceResponse.Content;

                serviceResponse.EnsureSuccessStatusCode(); // throws if not 200-299

                if (!serviceResponse.IsSuccessStatusCode)
                {
                    string message = await serviceResponse.Content.ReadAsStringAsync() ?? "Invalid Response";
                    return new ApiResponse<TOutput>
                    {
                        Data = default,
                        MetaData = new ApiResponseMetaData
                        {
                            Success = false,
                            Message = message
                        },
                    };
                }

                if (serviceResponseContent == null || serviceResponseContent?.Headers.ContentType?.MediaType != "application/json")
                {
                    return new ApiResponse<TOutput>
                    {
                        Data = default,
                        MetaData = new ApiResponseMetaData
                        {
                            Success = false,
                            Message = "No content"
                        },
                    };
                }

                var contentStream = await serviceResponseContent.ReadAsStreamAsync();

                var response = await JsonSerializer.DeserializeAsync<ApiResponse<TOutput>>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                if(response == null)
                {
                    throw new Exception("Failed to deserialize data");
                }

                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<TOutput>
                {
                    Data = default,
                    MetaData = new ApiResponseMetaData
                    {
                        Success = false,
                        Message = ex.Message,
                    },
                };
            }
        }
    }
}
