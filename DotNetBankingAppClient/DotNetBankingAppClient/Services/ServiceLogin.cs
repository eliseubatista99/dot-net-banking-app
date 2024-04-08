using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceLoginOutput
    {
        public UserDTO? User { get; set; }
        public string? Token { get; set; }
    }

    [DataContract]
    public class ServiceLoginInput
    {
        [DataMember]
        public required string UserName { get; set; }
        [DataMember]
        public required string Password { get; set; }
    }

    public class ServiceLogin
    {
        public static async Task<ServiceLoginOutput?> CallAsync(HttpClient Http, ServiceLoginInput input)
        {
            return await ApiServices.Instance.CallService<ServiceLoginInput, ServiceLoginOutput>("login", input);
        }
    }
}
