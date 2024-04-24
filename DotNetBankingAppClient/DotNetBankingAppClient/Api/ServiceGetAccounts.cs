using DotNetBankingAppClient.Models;
using System.Runtime.Serialization;

namespace DotNetBankingAppClient.Api;

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
