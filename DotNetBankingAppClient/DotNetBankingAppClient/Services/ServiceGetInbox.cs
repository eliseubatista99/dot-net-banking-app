using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceGetInboxOutput
    {
        public List<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
    }

    [DataContract]
    public class ServiceGetInboxInput
    {
        [DataMember]
        public required string UserName { get; set; }
    }

    public class ServiceGetInbox
    {
        public static async Task<ApiResponse<ServiceGetInboxOutput>> CallAsync(ServiceGetInboxInput input)
        {
            return await ApiServices.Instance.CallService<ServiceGetInboxInput, ServiceGetInboxOutput>("GetInbox", input);
        }
    }
}
