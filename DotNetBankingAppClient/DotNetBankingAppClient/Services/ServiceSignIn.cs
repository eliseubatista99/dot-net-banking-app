using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceSignInOutput
    {
        public UserDTO? User { get; set; }
        public string? Token { get; set; }
    }

    [DataContract]
    public class ServiceSignInInput
    {
        [DataMember]
        public required string UserName { get; set; }
        [DataMember]
        public required string Password { get; set; }
    }

    public class ServiceSignIn
    {
        public static async Task<ApiResponse<ServiceSignInOutput>> CallAsync(ServiceSignInInput input)
        {
            return await ApiServices.Instance.CallService<ServiceSignInInput, ServiceSignInOutput>("signIn", input);
        }
    }
}
