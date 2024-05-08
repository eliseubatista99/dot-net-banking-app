using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

public class ServiceGetInboxInput
{
    public string? UserName { get; set; }
}

[DataContract]

public class ServiceGetInboxOutput
{
    [DataMember]

    public required List<MessageDTOGroup> GroupedMessages { get; set; }
}
