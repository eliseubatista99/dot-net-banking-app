using System.Text;
using System.Text.Json;

namespace DotNetBankingAppClient.Services
{
    public class ApiServices : IApiCommunication
    {
        private readonly HttpClient _httpClient;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseEndpointOutput<TOutput>> CallService<TInput, TOutput>(string endpoint, TInput input)
        {
            try
            {
                BaseEndpointInput<TInput> endpointInput = new BaseEndpointInput<TInput>
                {
                    Data = input,
                    MetaData = new BaseEndpointInputMetaData
                    {
                        Language = Language.English,
                    }
                };

                string jsonInput = JsonSerializer.Serialize(endpointInput);
                var serviceBody = new StringContent(jsonInput, Encoding.UTF8, "application/json");
                var serviceResponse = await _httpClient.PostAsync(endpoint, serviceBody);
                var serviceResponseContent = serviceResponse.Content;

                serviceResponse.EnsureSuccessStatusCode(); // throws if not 200-299

                if (!serviceResponse.IsSuccessStatusCode)
                {
                    string message = await serviceResponse.Content.ReadAsStringAsync() ?? "Invalid Response";
                    return new BaseEndpointOutput<TOutput>
                    {
                        Data = default,
                        MetaData = new BaseEndpointOutputMetaData
                        {
                            Success = false,
                            Message = message
                        },
                    };
                }

                if (serviceResponseContent == null || serviceResponseContent?.Headers.ContentType?.MediaType != "application/json")
                {
                    return new BaseEndpointOutput<TOutput>
                    {
                        Data = default,
                        MetaData = new BaseEndpointOutputMetaData
                        {
                            Success = false,
                            Message = "No content"
                        },
                    };
                }

                var contentStream = await serviceResponseContent.ReadAsStreamAsync();

                var response = await JsonSerializer.DeserializeAsync<BaseEndpointOutput<TOutput>>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                if (response == null)
                {
                    throw new Exception("Failed to deserialize data");
                }

                return response;
            }
            catch (Exception ex)
            {
                return new BaseEndpointOutput<TOutput>
                {
                    Data = default,
                    MetaData = new BaseEndpointOutputMetaData
                    {
                        Success = false,
                        Message = ex.Message,
                    },
                };
            }
        }
    }
}
