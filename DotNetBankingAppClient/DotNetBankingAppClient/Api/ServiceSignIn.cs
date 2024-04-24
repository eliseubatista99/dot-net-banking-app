using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

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
