using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceLoginOutput
    {
        public UserDTO user { get; set; }
        public string token { get; set; }
    }

    [DataContract]
    public class ServiceLoginInput
    {
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
    }

    public class ServiceLogin
    {
        public static async Task<ServiceLoginOutput?> CallAsync(HttpClient Http, ServiceLoginInput input)
        {
            return await ApiServices.Instance.CallService<ServiceLoginInput, ServiceLoginOutput>("login", input);
        }
    }
}
