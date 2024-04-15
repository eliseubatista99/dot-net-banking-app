using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceGetAccountsOutput
    {
        public required List<AccountDTO> CheckingAccounts { get; set; }
        public required List<AccountDTO> SavingAccounts { get; set; }
    }

    [DataContract]
    public class ServiceGetAccountsInput
    {
        [DataMember]
        public required string UserName { get; set; }
    }

    public class ServiceGetAccounts
    {
        public static async Task<ApiResponse<ServiceGetAccountsOutput>> CallAsync(ServiceGetAccountsInput input)
        {
            return await ApiServices.Instance.CallService<ServiceGetAccountsInput, ServiceGetAccountsOutput>("GetAccounts", input);
        }
    }
}
