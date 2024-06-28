using DotNetBankingAppClientContracts.Dtos.Api;
using DotNetBankingAppClientContracts.Enums;
using DotNetBankingAppClientContracts.Providers;
using System.Text.Json;
using System.Text;
using DotNetBankingAppClient.Constants;
using DotNetBankingAppClient.Services;

namespace DotNetBankingAppClient.Providers
{
    public class ApiProvider : IApiProvider
    {
        private readonly HttpClient _httpClient;

        public ApiProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<BaseEndpointOutputDto<TOutput>> CallService<TInput, TOutput>(string endpoint, TInput input)
        {
            try
            {
                BaseEndpointInputDto<TInput> endpointInput = new BaseEndpointInputDto<TInput>
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
                    return new BaseEndpointOutputDto<TOutput>
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
                    return new BaseEndpointOutputDto<TOutput>
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

                var response = await JsonSerializer.DeserializeAsync<BaseEndpointOutputDto<TOutput>>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                if (response == null)
                {
                    return new BaseEndpointOutputDto<TOutput>
                    {
                        Data = default,
                        MetaData = new BaseEndpointOutputMetaData
                        {
                            Success = false,
                            Message = "Failed to deserialize data",
                        },
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                return new BaseEndpointOutputDto<TOutput>
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

        public async Task<BaseEndpointOutputDto<GetAccountsOperationOutput>> GetAccounts(GetAccountsOperationInput input)
        {
            var result = await CallService<GetAccountsOperationInput, GetAccountsOperationOutput>(ApiEndpoints.GetAccounts, input);

            return result;
        }

        public async Task<BaseEndpointOutputDto<GetCardsOperationOutput>> GetCards(GetCardsOperationInput input)
        {
            var result = await CallService<GetCardsOperationInput, GetCardsOperationOutput>(ApiEndpoints.GetCards, input);

            return result;
        }

        public async Task<BaseEndpointOutputDto<GetInboxOperationOutput>> GetInbox(GetInboxOperationInput input)
        {
            var result = await CallService<GetInboxOperationInput, GetInboxOperationOutput>(ApiEndpoints.GetInbox, input);

            return result;
        }

        public async Task<BaseEndpointOutputDto<GetTransactionsOperationOutput>> GetTransactions(GetTransactionsOperationInput input)
        {
            var result = await CallService<GetTransactionsOperationInput, GetTransactionsOperationOutput>(ApiEndpoints.GetTransactions, input);

            return result;
        }

        public async Task<BaseEndpointOutputDto<SignInOperationOutput>> SignIn(SignInOperationInput input)
        {
            var result = await CallService<SignInOperationInput, SignInOperationOutput>(ApiEndpoints.SignIn, input);

            return result;
        }

        public async Task<BaseEndpointOutputDto<SignUpOperationOutput>> SignUp(SignUpOperationIntput input)
        {
            var result = await CallService<SignUpOperationIntput, SignUpOperationOutput>(ApiEndpoints.SignUp, input);

            return result;
        }
    }
}
