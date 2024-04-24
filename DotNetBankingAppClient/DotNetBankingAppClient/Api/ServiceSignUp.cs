using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

public class ServiceSignUpOutput
{
    public UserDTO? User { get; set; }
    public string? Token { get; set; }
}

[DataContract]
public class ServiceSignUpInput
{
    [DataMember]
    public required string UserName { get; set; }
    [DataMember]
    public required string Password { get; set; }
    [DataMember]
    public required string PhoneNumber { get; set; }
}