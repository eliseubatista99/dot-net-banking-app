using DotNetBankingAppClient.Helpers;
using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Services
{
    public class ServiceGetInboxInput
    {
        public string? username { get; set; }
    }

    [DataContract]

    public class ServiceGetInboxOutput
    {
        [DataMember]

        public required List<MessageDTOGroup> groupedMessages { get; set; }
    }

    public class ServiceGetInbox
    {
        public static async Task<ApiResponse<ServiceGetInboxOutput>> CallAsync(ServiceGetInboxInput input)
        {
            return await ApiServices.Instance.CallService<ServiceGetInboxInput, ServiceGetInboxOutput>("GetInbox", input);
        }
    }
}
