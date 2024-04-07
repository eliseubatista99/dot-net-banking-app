using System.Text;
using System.Text.Json;

namespace DotNetBankingAppClient.Helpers
{
    public interface IApiServices
    {
        public Task<TOutput?> CallService<TInput, TOutput>(string endpoint, TInput input);
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

        public async Task<TOutput?> CallService<TInput, TOutput>(string endpoint, TInput input)
        {
            string jsonInput = JsonSerializer.Serialize(input);
            var httpContent = new StringContent(jsonInput, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync("Login", httpContent);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299


            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType?.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                try
                {
                    return await JsonSerializer.DeserializeAsync<TOutput>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });
                }
                catch (JsonException) // Invalid JSON
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return default;
        }
    }
}
